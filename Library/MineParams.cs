using System.Collections;
using System.Xml.Serialization;

namespace GodLesZ.Tools.WebScraper.Library {
    public class MineParams {
        private int pageMaxCount = -1;
        [XmlIgnore]
        public string ConfigName = "";
        private UrlData startURL;
        private ArrayList fieldList;
        private ArrayList categoryList;
        private ArrayList keywordList;
        private bool insertMode;
        private int insertIndex;

        public UrlData StartURL {
            get { return startURL; }
            set { startURL = value; }
        }

        [XmlArrayItem(typeof(DataField))]
        public ArrayList FieldList {
            get { return fieldList; }
            set { fieldList = value; }
        }

        [XmlArrayItem(typeof(UrlData))]
        public ArrayList CategoryList {
            get { return categoryList; }
            set { categoryList = value; }
        }

        [XmlArrayItem(typeof(string))]
        public ArrayList KeywordList {
            get { return keywordList; }
            set { keywordList = value; }
        }

        [XmlIgnore]
        public int PageMaxCount {
            get { return pageMaxCount; }
            set { pageMaxCount = value; }
        }

        public bool SinglePage {
            get { return IsSinglePage(); }
        }

        public bool SupportsMineTillEnd {
            get { return DoesSupportsMineTillEnd(); }
        }

        public bool AutoScrollEnabled {
            get { return DoesSupportsAutoScroll(); }
        }


        public bool AddDataField(EDataType type, string fieldName, string xpath, bool isPattern, string heading, string regex = "") {
            var flag1 = true;
            var flag2 = false;
            if (fieldList == null)
                fieldList = new ArrayList();
            if ((type == EDataType.Text || type == EDataType.Text_Near_Heading || (type == EDataType.Image || type == EDataType.HTML) || (type == EDataType.File || type == EDataType.Url || type == EDataType.Image_RegEx)) && fieldName != null) {
                foreach (DataField datafield in fieldList) {
                    if (datafield.name == fieldName) {
                        flag1 = false;
                        break;
                    }
                }
                if (!flag1)
                    goto label_32;
            }
            if (type == EDataType.Link_NextPage) {
                for (var index = 0; index < fieldList.Count; ++index) {
                    var datafield = (DataField)fieldList[index];
                    if (datafield.type == EDataType.Link_NextPage) {
                        datafield.xpath = xpath;
                        datafield.name = fieldName;
                        fieldList[index] = datafield;
                        flag2 = true;
                    }
                }
            }
            if (type == EDataType.Link_Follow) {
                var flag3 = false;
                for (var index = 0; index < fieldList.Count; ++index) {
                    var datafield = (DataField)fieldList[index];
                    if (datafield.type == EDataType.Link_Follow && datafield.xpath == xpath)
                        flag3 = true;
                    if (flag3 && datafield.type == EDataType.Link_Back) {
                        insertMode = true;
                        insertIndex = index;
                        flag2 = true;
                        break;
                    }
                }
            }
            if (insertMode && type == EDataType.Link_Back) {
                insertMode = false;
                flag2 = true;
            }
            if (flag1 && !flag2) {
                DataField datafield;
                datafield.type = type;
                datafield.name = fieldName;
                datafield.xpath = xpath;
                datafield.pattern = isPattern;
                datafield.heading = heading;
                datafield.regex = regex;
                if (insertMode)
                    fieldList.Insert(insertIndex, datafield);
                else
                    fieldList.Add(datafield);
            }
        label_32:
            return flag1;
        }

        public void DeleteDataField(string fieldName) {
            for (var index = 0; index < fieldList.Count; ++index) {
                var datafield = (DataField)fieldList[index];
                if (datafield.name == fieldName) {
                    fieldList.Remove(datafield);
                    if (!insertMode || insertIndex < index)
                        break;
                    --insertIndex;
                    break;
                }
            }
        }

        public void Optimize() {
            var num = 0;
            if (fieldList == null)
                return;
            DataField datafield1;
            for (var index = 0; index < fieldList.Count; ++index) {
                datafield1 = (DataField)fieldList[index];
                if (datafield1.type == EDataType.Link_Follow)
                    ++num;
                if (datafield1.type == EDataType.Link_Back)
                    --num;
            }
            for (var index = 0; index < num; ++index)
                AddDataField(EDataType.Link_Back, null, null, false, null, "");
            for (var index = 0; index < fieldList.Count; ++index) {
                datafield1 = (DataField)fieldList[index];
                if (datafield1.type == EDataType.Link_NextPage && index != fieldList.Count - 1) {
                    fieldList.Add(datafield1);
                    fieldList.Remove(datafield1);
                    break;
                }
            }
            var index1 = 0;
            while (index1 < fieldList.Count) {
                datafield1 = (DataField)fieldList[index1];
                if (datafield1.type == EDataType.Link_Follow && index1 + 1 < fieldList.Count) {
                    var datafield2 = (DataField)fieldList[index1 + 1];
                    if (datafield2.type == EDataType.Link_Back) {
                        fieldList.Remove(datafield1);
                        fieldList.Remove(datafield2);
                        continue;
                    }
                }
                ++index1;
            }
        }

        private bool IsSinglePage() {
            var flag = true;
            if (fieldList != null) {
                foreach (DataField datafield in fieldList) {
                    if (datafield.type == EDataType.Link_NextPage || datafield.type == EDataType.Link_LoadMoreContent || datafield.type == EDataType.Auto_Scroll) {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        private bool DoesSupportsMineTillEnd() {
            var flag = true;
            if (fieldList != null) {
                foreach (DataField datafield in fieldList) {
                    if (datafield.type == EDataType.Link_LoadMoreContent || datafield.type == EDataType.Auto_Scroll) {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        private bool DoesSupportsAutoScroll() {
            var flag = false;
            if (fieldList != null) {
                foreach (DataField datafield in fieldList) {
                    if (datafield.type == EDataType.Auto_Scroll) {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public void RemoveAutoScroll() {
            if (fieldList == null)
                return;
            foreach (DataField datafield in fieldList) {
                if (datafield.type == EDataType.Auto_Scroll) {
                    fieldList.Remove(datafield);
                    break;
                }
            }
        }

        public void AddAutoScroll() {
            AddDataField(EDataType.Auto_Scroll, "AutoScroll", "", false, "", "");
        }

    }

}

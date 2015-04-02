using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class KeywordForm : Form {
        private string mainKeyword = "";
        private string[] keywords;

        public string[] Keywords {
            get {
                return keywords;
            }
            set {
                var str = "";
                mainKeyword = value[0];
                for (var index = 0; index < value.Length; ++index)
                    str = str + value[index].ToString() + "\r\n";
                textBoxKeywords.Text = str;
            }
        }

        public KeywordForm() {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            try {
                var arrayList = new ArrayList();
                var str = textBoxKeywords.Text.Trim();
                if (str != "") {
                    arrayList.AddRange(str.Split(new char[3]
                      {
                          '\r',
                          '\n',
                          ','
                      }, StringSplitOptions.RemoveEmptyEntries));
                    if (mainKeyword != "") {
                        arrayList.Remove(mainKeyword);
                        arrayList.Insert(0, mainKeyword);
                    }
                    keywords = (string[])arrayList.ToArray(typeof(string));
                } else {
                    keywords = new string[1];
                    keywords[0] = mainKeyword;
                }
            } catch {
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            Close();
        }

    }
}

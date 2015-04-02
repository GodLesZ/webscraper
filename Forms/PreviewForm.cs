using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;
using WeifenLuo.WinFormsUI.Docking;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class PreviewForm : DockContent {
        private MineParams mineParams;
        private bool configMode;

        public bool ConfigMode {
            set {
                configMode = value;
            }
        }

        public MineParams MineParameters {
            set {
                mineParams = value;
            }
        }

        public int RowCount {
            get {
                return listPreview.Items.Count;
            }
        }

        public int ColCount {
            get {
                var num = 0;
                for (var index = 0; index < listPreview.Columns.Count; ++index) {
                    if (listPreview.Columns[index].Width != 0)
                        ++num;
                }
                return num;
            }
        }

        public PreviewForm() {
            InitializeComponent();
            contextMenuStrip.Items[1].Click += PreviewFormCopy_Click;
        }

        private void PreviewFormCopy_Click(object sender, EventArgs e) {
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < listPreview.Columns.Count; ++index) {
                if (listPreview.Columns[index].Width != 0) {
                    stringBuilder.Append(listPreview.Columns[index].Text);
                    stringBuilder.Append("\t");
                }
            }
            stringBuilder.Append("\n");
            for (var index1 = 0; index1 < listPreview.Items.Count; ++index1) {
                for (var index2 = 0; index2 < listPreview.Columns.Count; ++index2) {
                    if (listPreview.Columns[index2].Width != 0) {
                        stringBuilder.Append(listPreview.Items[index1].SubItems[index2].Text);
                        stringBuilder.Append("\t");
                    }
                }
                stringBuilder.Append("\n");
            }
            Clipboard.SetText(stringBuilder.ToString());
        }

        public void AddColumn(string colName) {
            listPreview.Columns.Add(colName);
            listPreview.GridLines = true;
        }

        public void AddSingleItem(string itemText) {
            AddItem(0, itemText);
            for (var row = 1; row < listPreview.Items.Count; ++row)
                AddItem(row, "--");
        }

        public void AddItem(int row, string itemText) {
            AddItem(row, itemText, null);
        }

        public void AddItem(int row, string itemText, object itemContext) {
            if (ColCount == 1) {
                listPreview.Items.Add(itemText);
                listPreview.Items[listPreview.Items.Count - 1].Tag = itemContext;
            } else if (row < listPreview.Items.Count)
                listPreview.Items[row].SubItems.Add(itemText);
            if (!(itemText != "--"))
                return;
            listPreview.AutoResizeColumn(listPreview.Columns.Count - 1, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public object GetItemData(int row) {
            object obj = null;
            if (row < listPreview.Items.Count)
                obj = listPreview.Items[row].Tag;
            return obj;
        }

        public void Clear() {
            listPreview.Clear();
            listPreview.GridLines = false;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e) {
            e.Cancel = true;
            if (ColCount == 0)
                return;
            var toolStripMenuItem1 = (ToolStripMenuItem)contextMenuStrip.Items[0];
            toolStripMenuItem1.DropDownItems.Clear();
            foreach (ColumnHeader columnHeader in listPreview.Columns) {
                if (columnHeader.Width != 0) {
                    var toolStripMenuItem2 = new ToolStripMenuItem(columnHeader.Text);
                    toolStripMenuItem2.Click += subMenuItem_Delete;
                    toolStripMenuItem1.DropDownItems.Add(toolStripMenuItem2);
                    e.Cancel = false;
                }
            }
            contextMenuStrip.Items[0].Enabled = configMode;
        }

        private void subMenuItem_Delete(object sender, EventArgs e) {
            var toolStripItem = sender as ToolStripItem;
            foreach (ColumnHeader columnHeader in listPreview.Columns) {
                if (columnHeader.Text == toolStripItem.Text && columnHeader.Width != 0) {
                    columnHeader.Width = 0;
                    break;
                }
            }
            mineParams.DeleteDataField(toolStripItem.Text);
            if (ColCount != 0)
                return;
            Clear();
        }

        private void listPreview_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            if (listPreview.Columns[e.ColumnIndex].Width != 0)
                return;
            e.NewWidth = 0;
            e.Cancel = true;
        }

    }
}

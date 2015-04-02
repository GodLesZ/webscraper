using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AddUrlForm : Form {
        private ArrayList urlList = new ArrayList();

        public ArrayList URLList {
            get {
                return urlList;
            }
            set {
                if (value == null)
                    return;
                var str = "";
                for (var index = 1; index < value.Count; ++index)
                    str = str + ((UrlData)value[index]).url + "\n";
                textBoxURLs.Text = str;
            }
        }

        public AddUrlForm() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            if (textBoxURLs.Text.Trim() != "") {
                urlList.Clear();
                var text = textBoxURLs.Text;
                var separator = new char[2]
        {
          '\n',
          ' '
        };
                var num = 1;
                foreach (var str in text.Split(separator, (StringSplitOptions)num))
                    urlList.Add(new UrlData() {
                        name = "URL",
                        url = str
                    });
            }
            Close();
        }

        private void textBoxURLs_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right)
                return;
            var contextMenu = new ContextMenu();
            var menuItem1 = new MenuItem("Cut");
            menuItem1.Click += CutAction;
            contextMenu.MenuItems.Add(menuItem1);
            var menuItem2 = new MenuItem("Copy");
            menuItem2.Click += CopyAction;
            contextMenu.MenuItems.Add(menuItem2);
            var menuItem3 = new MenuItem("Paste");
            menuItem3.Click += PasteAction;
            contextMenu.MenuItems.Add(menuItem3);
            textBoxURLs.ContextMenu = contextMenu;
        }

        private void CutAction(object sender, EventArgs e) {
            if (textBoxURLs.SelectionLength == 0)
                return;
            textBoxURLs.Cut();
        }

        private void CopyAction(object sender, EventArgs e) {
            if (textBoxURLs.SelectionLength == 0)
                return;
            Clipboard.SetText(textBoxURLs.SelectedText);
        }

        private void PasteAction(object sender, EventArgs e) {
            if (!Clipboard.ContainsText())
                return;
            textBoxURLs.Paste();
        }

    }
}

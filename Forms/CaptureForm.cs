using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class CaptureForm : Form {
        private string regex = "";
        private string urlLinkRegEx = "";
        private EDataType captureMode;
        private HtmlElement capElement;
        private EDataType type;
        private bool isClickable;
        private bool isLink;
        private bool isEmail;
        private bool isImage;
        private bool isPattern;
        private string fieldName;
        private HtmlDocument htmlDoc;
        private bool imageRegEx;
        private bool linkRegEx;

        public HtmlElement CapElement {
            get {
                return capElement;
            }
            set {
                capElement = value;
                textBoxCaptureText.Text = capElement.InnerText;
                if (textBoxCaptureText.Text.Length == 0)
                    return;
                buttonCaptureItemText.Enabled = true;
            }
        }

        public EDataType Type {
            get {
                return type;
            }
        }

        public bool IsPattern {
            get {
                return isPattern;
            }
            set {
                isPattern = value;
            }
        }

        public string FieldName {
            get {
                return fieldName;
            }
            set {
                fieldName = value;
            }
        }

        public bool IsClickable {
            set {
                isClickable = value;
            }
        }

        public bool IsLink {
            set {
                isLink = value;
            }
        }

        public bool IsImage {
            set {
                isImage = value;
            }
        }

        public bool IsEmail {
            set {
                isEmail = value;
            }
        }

        public string RegEx {
            get {
                return regex;
            }
        }

        public HtmlDocument Document {
            set {
                htmlDoc = value;
            }
        }

        public string URLLinkRegEx {
            get {
                return urlLinkRegEx;
            }
        }

        public CaptureForm() {
            InitializeComponent();
        }

        private void CaptureForm_Shown(object sender, EventArgs e) {
            if (textBoxCaptureText.Text == null || textBoxCaptureText.Text.Length == 0) {
                buttonCaptureItemText.Enabled = false;
                captureFollowingTextToolStripMenuItem.Enabled = false;
            } else
                toolTipControl.SetToolTip(textBoxCaptureText, "To capture only a portion of this text, select and highlight\nthe required portion before selecting one of the options below");
            if (!isClickable) {
                buttonFollowLink.Enabled = false;
                if (!isPattern) {
                    setAsshowMoreResultsLinkToolStripMenuItem.Enabled = false;
                    buttonSetNextPageLink.Enabled = false;
                }
            }
            if (!isLink)
                buttonCaptureLink.Enabled = false;
            if (isEmail)
                buttonCaptureLink.Text = " Capture Email Address";
            if (!isImage)
                buttonCaptureImage.Enabled = false;
            if (!(textBoxCaptureText.Text != string.Empty) || !(textBoxCaptureText.Text.Trim() == "2"))
                return;
            buttonSetNextPageLink.Enabled = true;
        }

        private void buttonFollowLink_Click(object sender, EventArgs e) {
            type = linkRegEx ? EDataType.Link_RegEx : EDataType.Link_Follow;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DisplayCaptureItemForm(EDataType itemType) {
            var captureItem = new CaptureItem();
            captureItem.StartPosition = FormStartPosition.CenterParent;
            if (captureItem.ShowDialog(this) != DialogResult.OK)
                return;
            type = itemType;
            fieldName = captureItem.FieldName;
            DialogResult = DialogResult.OK;
            Close();
            if (!(textBoxCaptureText.SelectedText != "") || !(textBoxCaptureText.SelectedText.Trim() != ""))
                return;
            GenerateRegExForSelectedText();
        }

        private void GenerateRegExForSelectedText() {
            var text = textBoxCaptureText.Text;
            var index1 = text.IndexOf(textBoxCaptureText.SelectedText);
            var startIndex1 = 0;
            regex = "";
            var ch = ' ';
            try {
                if (index1 - 1 >= 0) {
                    if (char.IsPunctuation(text, index1 - 1) || char.IsSymbol(text, index1 - 1))
                        ch = text[index1 - 1];
                    else if (char.IsPunctuation(text, index1) || text[index1] == 32) {
                        ch = text[index1];
                        ++index1;
                    }
                }
                while (startIndex1 < index1) {
                    var num1 = text.IndexOf('\n', startIndex1);
                    if (num1 != -1 && num1 < index1) {
                        var captureForm = this;
                        var str = captureForm.regex + "[^\n]*\n";
                        captureForm.regex = str;
                        startIndex1 = num1 + 1;
                    } else {
                        var num2 = text.IndexOf(',', startIndex1);
                        if (num2 != -1 && num2 < index1) {
                            var captureForm = this;
                            var str = captureForm.regex + "[^,]*,";
                            captureForm.regex = str;
                            startIndex1 = num2 + 1;
                        } else {
                            var num3 = text.IndexOf(' ', startIndex1);
                            if (num3 != -1 && num3 < index1) {
                                var captureForm = this;
                                var str = captureForm.regex + "[^ ]* ";
                                captureForm.regex = str;
                                startIndex1 = num3 + 1;
                            } else if (ch != 32) {
                                var num4 = text.IndexOf(ch, startIndex1);
                                if (num4 != -1 && num4 < index1) {
                                    var captureForm = this;
                                    var str = captureForm.regex + (object)"[^" + (string)(object)ch + "]*[" + (string)(object)ch + "]";
                                    captureForm.regex = str;
                                    startIndex1 = num4 + 1;
                                } else
                                    break;
                            } else
                                break;
                        }
                    }
                }
                var captureForm1 = this;
                var str1 = captureForm1.regex + "(";
                captureForm1.regex = str1;
                var startIndex2 = index1;
                var index2 = index1 + textBoxCaptureText.SelectedText.Length;
                if (char.IsPunctuation(text[index2 - 1]) || text[index2 - 1] == 32)
                    --index2;
                for (var num = 0; startIndex2 < index2; startIndex2 = num + 1) {
                    num = text.IndexOf(' ', startIndex2, index2 - startIndex2);
                    if (num != -1) {
                        var captureForm2 = this;
                        var str2 = captureForm2.regex + "[^ ]* ";
                        captureForm2.regex = str2;
                    } else
                        break;
                }
                var captureForm3 = this;
                var str3 = captureForm3.regex + "[^ \r\n]*)";
                captureForm3.regex = str3;
                if (index2 >= text.Length || !char.IsPunctuation(text, index2) && !char.IsSymbol(text, index2))
                    return;
                var captureForm4 = this;
                var str4 = string.Concat(new object[4]
        {
          captureForm4.regex,
          "[",
          text[index2],
          "]"
        });
                captureForm4.regex = str4;
            } catch (Exception ex) {
                regex = "";
            }
        }

        private void buttonCaptureItemText_Click(object sender, EventArgs e) {
            DisplayCaptureItemForm(captureMode);
        }

        private void buttonCaptureLink_Click(object sender, EventArgs e) {
            DisplayCaptureItemForm(EDataType.Url);
        }

        private void buttonCaptureImage_Click(object sender, EventArgs e) {
            if (imageRegEx)
                DisplayCaptureItemForm(EDataType.Image_RegEx);
            else
                buttonCaptureImage.ContextMenuStrip.Show(Cursor.Position);
        }

        private void downloadImageToolStripMenuItem_Click(object sender, EventArgs e) {
            DisplayCaptureItemForm(EDataType.Image);
        }

        private void captureImageURLToolStripMenuItem_Click(object sender, EventArgs e) {
            DisplayCaptureItemForm(EDataType.Image_URL);
        }

        private void captureFollowingTextToolStripMenuItem_Click(object sender, EventArgs e) {
            captureMode = EDataType.Text_Near_Heading;
            if (isPattern)
                textBoxCaptureText.Text = HtmlParser.GetTextNearHeading(capElement.Parent.Parent, capElement.InnerText);
            else if (htmlDoc != null)
                textBoxCaptureText.Text = HtmlParser.GetTextNearHeadingBruteForce(htmlDoc, capElement.InnerText);
            buttonCaptureImage.Enabled = false;
            buttonCaptureLink.Enabled = false;
            buttonSetNextPageLink.Enabled = false;
            buttonFollowLink.Enabled = false;
            captureFollowingTextToolStripMenuItem.Enabled = false;
            captureHTMLOfItemToolStripMenuItem.Enabled = false;
            captureTextAsFileToolStripMenuItem.Enabled = false;
            setAsshowMoreResultsLinkToolStripMenuItem.Enabled = false;
            clickToolStripMenuItem.Enabled = false;
        }

        private void captureHTMLOfItemToolStripMenuItem_Click(object sender, EventArgs e) {
            captureMode = EDataType.HTML;
            buttonCaptureItemText.Text = buttonCaptureItemText.Text.Replace("Text", "HTML");
            textBoxCaptureText.Text = HtmlParser.GetElementHtml(capElement);
            buttonCaptureItemText.Enabled = !textBoxCaptureText.Text.Equals(string.Empty);
            textBoxCaptureText.BackColor = Color.White;
            buttonCaptureImage.Enabled = false;
            buttonCaptureLink.Enabled = false;
            buttonSetNextPageLink.Enabled = false;
            buttonFollowLink.Enabled = false;
            captureFollowingTextToolStripMenuItem.Enabled = false;
            captureHTMLOfItemToolStripMenuItem.Enabled = false;
            captureTextAsFileToolStripMenuItem.Enabled = false;
            setAsshowMoreResultsLinkToolStripMenuItem.Enabled = false;
            clickToolStripMenuItem.Enabled = false;
        }

        private void captureParentElementToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!(capElement.Parent != null))
                return;
            CapElement = capElement.Parent;
            CaptureForm_Shown(null, null);
        }

        private void captureTextAsFileToolStripMenuItem_Click(object sender, EventArgs e) {
            DisplayCaptureItemForm(EDataType.File);
        }

        private void clickToolStripMenuItem_Click(object sender, EventArgs e) {
            type = linkRegEx ? EDataType.Link_RegEx : EDataType.Click;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonMoreOptions_Click(object sender, EventArgs e) {
            buttonMoreOptions.ContextMenuStrip.Show(Cursor.Position);
        }

        private void buttonSetNextPageLink_Click(object sender, EventArgs e) {
            type = EDataType.Link_NextPage;
            if (capElement.InnerText != null && capElement.InnerText.ToLower().Contains("more"))
                type = EDataType.Link_LoadMoreContent;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void setAsShowMoreResultsLinkToolStripMenuItem_Click(object sender, EventArgs e) {
            type = EDataType.Link_LoadMoreContent;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void HandleURLInRefinedText(string refinedText) {
            Uri result;
            if (buttonCaptureImage.Enabled || refinedText == null || !Uri.TryCreate(refinedText, UriKind.RelativeOrAbsolute, out result))
                return;
            refinedText = HtmlParser.GetAbsoluteUrl(htmlDoc.Url, refinedText);
            if (HtmlParser.IsFileImage(refinedText)) {
                imageRegEx = true;
                buttonCaptureImage.Enabled = true;
            } else if (isPattern) {
                linkRegEx = true;
                urlLinkRegEx = refinedText;
                buttonFollowLink.Enabled = true;
            } else {
                linkRegEx = true;
                urlLinkRegEx = refinedText;
                clickToolStripMenuItem.Enabled = true;
            }
        }

        private void applyRegularExpressionToolStripMenuItem_Click(object sender, EventArgs e) {
            var regExForm = new RegExForm();
            regExForm.StartPosition = FormStartPosition.CenterParent;
            if (DialogResult.OK != regExForm.ShowDialog() || !(textBoxCaptureText.Text != ""))
                return;
            if (!(regExForm.RegEx != ""))
                return;
            try {
                var refinedText = HtmlParser.RefineElementText(textBoxCaptureText.Text, regExForm.RegEx);
                regex = regExForm.RegEx;
                textBoxCaptureText.Text = refinedText;
                HandleURLInRefinedText(refinedText);
            } catch (Exception ex) {
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Escape)
                Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

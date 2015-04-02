using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;

namespace GodLesZ.Tools.WebScraper.Forms
{
  public partial class EditStartUrlForm : Form
  {
    private Encoding utf8Encoding = new UTF8Encoding();
    private UrlData startURL;
    
    public UrlData StartURL
    {
      get
      {
        return startURL;
      }
      set
      {
        startURL = value;
        textBoxURL.Text = startURL.url;
        textBoxHeaders.Text = startURL.headers;
        textBoxPostData.Text = startURL.postData == null ? "" : utf8Encoding.GetString(startURL.postData);
      }
    }

    public EditStartUrlForm()
    {
      InitializeComponent();
    }

    private void buttonChange_Click(object sender, EventArgs e)
    {
      startURL.url = textBoxURL.Text;
      startURL.postData = utf8Encoding.GetBytes(textBoxPostData.Text);
      startURL.headers = textBoxHeaders.Text;
      DialogResult = DialogResult.OK;
    }

  }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms
{
  public partial class CaptureItem : Form
  {
    
    public string FieldName
    {
      get
      {
        return textBoxFieldName.Text;
      }
      set
      {
        textBoxFieldName.Text = value;
      }
    }

    public CaptureItem()
    {
      InitializeComponent();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      if (textBoxFieldName.Text.Trim().Length == 0)
      {
        DialogResult = DialogResult.None;
      }
      else
      {
        DialogResult = DialogResult.OK;
        Close();
      }
    }

    private void textBoxFieldName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 13)
        return;
      buttonOK_Click(sender, null);
    }

  }
}

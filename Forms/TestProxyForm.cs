using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms
{
  public partial class TestProxyForm : Form
  {
    public TestProxyForm()
    {
      InitializeComponent();
    }

    public void SetStatus(string status)
    {
      if (labelProgress.InvokeRequired)
        Invoke(new SetStatusCallback(SetStatus), (object) status);
      else
        labelProgress.Text = status;
    }

    private delegate void SetStatusCallback(string status);
  }
}

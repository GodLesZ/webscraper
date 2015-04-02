using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms
{
  public partial class RegExForm : Form
  {

    public string RegEx
    {
      get
      {
        return textBoxRegEx.Text;
      }
    }

    public RegExForm()
    {
      InitializeComponent();
    }

  }
}

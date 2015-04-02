using System;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Forms;

namespace GodLesZ.Tools.WebScraper
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}

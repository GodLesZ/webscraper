using System;
using System.Diagnostics;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AboutForm : Form {

        public AboutForm() {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            try {
                var versionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
                labelAppName.Text = versionInfo.ProductName + " " + versionInfo.ProductVersion;
                labelCopyright.Text = versionInfo.LegalCopyright;
                var registrationManager = new RegistrationManager();
                if (!registrationManager.Registered)
                    return;
                labelRegName.Text = StringResource.RegistrationName + registrationManager.RegistrationName;
            } catch (Exception) {
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

    }
}

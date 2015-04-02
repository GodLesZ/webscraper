using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class NagForm : Form {
        private readonly RegistrationManager _regManager = new RegistrationManager();
 
        public NagForm() {
            InitializeComponent();
        }

        private void linkPurchase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.GodLesZ.Tools.WebScraper.com/buy.html");
        }

        private void NagForm_Load(object sender, EventArgs e) {
            var evaluationDaysRemaining = _regManager.GetEvaluationDaysRemaining();
            progressBar.Value = evaluationDaysRemaining;
            labelEvalLimit.Text = string.Format(StringResource.EvalDays, evaluationDaysRemaining);
            if (evaluationDaysRemaining > 0)
                return;
            buttonContinueEval.Enabled = false;
        }

        private void buttonRegister_Click(object sender, EventArgs e) {
            openFileDialog.DefaultExt = "dat";
            openFileDialog.Filter = "License file (*.dat)|*.dat| All files (*.*)|*.*";
            openFileDialog.AddExtension = true;
            openFileDialog.RestoreDirectory = true;
            try {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                string registrationName;
                if (_regManager.ValidateLicenseFile(openFileDialog.FileName, out registrationName)) {
                    File.Copy(openFileDialog.FileName, RegistrationManager.WebScraperLicenseFileFullPath, true);
                    MessageBox.Show(StringResource.RegisterMessage, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.OK;
                    Close();
                } else if (_regManager.EligibleForUpgrade) {
                    if (DialogResult.Yes != MessageBox.Show(StringResource.UpgradeMsg, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                        return;
                    Process.Start("http://www.GodLesZ.Tools.WebScraper.com/upgrade.html");
                } else {
                    MessageBox.Show(StringResource.InvalidLicenseFile, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


    }
}

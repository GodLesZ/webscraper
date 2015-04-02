using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AdvancedMinerOptionsForm : Form {

        public AdvancedMinerOptionsForm() {
            InitializeComponent();
        }

        private void AdvancedMinerOptionsForm_Load(object sender, EventArgs e) {
            var minChildCount = Settings.Default.MinChildCount;
            var minLevelsUp = Settings.Default.MinLevelsUp;
            comboBoxMinChildCount.Text = minChildCount.ToString();
            comboBoxMinLevelsUp.Text = minLevelsUp.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            Settings.Default.MinChildCount = int.Parse(comboBoxMinChildCount.Text);
            Settings.Default.MinLevelsUp = int.Parse(comboBoxMinLevelsUp.Text);
        }

    }
}

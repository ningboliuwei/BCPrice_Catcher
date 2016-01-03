#region

using System;
using System.Windows.Forms;
using BCPrice_Catcher.Properties;

#endregion

namespace BCPrice_Catcher
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            var settings = Settings.Default;

            settings.BtccAccessKey = txtBtccAccessKey.Text.Trim();
            settings.BtccSecretKey = txtBtccSecretKey.Text.Trim();
            settings.HuobiAccessKey = txtHuobiAccessKey.Text.Trim();
            settings.HuobiSecretKey = txtHuobiSecretKey.Text.Trim();

            settings.Save();
        }

        /// <summary>
        ///     载入当前设置
        /// </summary>
        private void LoadSettings()
        {
            var settings = Settings.Default;

            txtBtccAccessKey.Text = settings.BtccAccessKey;
            txtBtccSecretKey.Text = settings.BtccSecretKey;
            txtHuobiAccessKey.Text = settings.HuobiAccessKey;
            txtHuobiSecretKey.Text = settings.HuobiSecretKey;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
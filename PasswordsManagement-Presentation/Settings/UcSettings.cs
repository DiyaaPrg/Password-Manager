using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordsManagement.Global;
using PasswordsManagement.Settings;

namespace PasswordsManagement.Settings
{
    public partial class UcSettings : UserControl
    {
        public UcSettings()
        {
            InitializeComponent();
        }

        public event Action OnCancel;

        protected virtual void CancelOperation()
        {
            Action handler = OnCancel;
            if (handler != null)
            {
                handler();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _GetSettings()
        {
            //cmbAutoLock
            if (Properties.Settings.Default.AutoLockMinutes == -1)
                cmbAutoLock.Text = "Never";

            else
                cmbAutoLock.Text = $"{Properties.Settings.Default.AutoLockMinutes} minutes";

            //cmbClearClipboard
            if (Properties.Settings.Default.ClipboardTimeoutSeconds == -1)
                cmbClearClipboard.Text = "Disabled";
            else if (Properties.Settings.Default.ClipboardTimeoutSeconds == 180)
                cmbClearClipboard.Text = $"2 minutes";

            else
                cmbClearClipboard.Text = $"{Properties.Settings.Default.ClipboardTimeoutSeconds} seconds";
        }

        private void UcSettings_Load(object sender, EventArgs e)
        {
            this.BackColor = clsGlobal.systemColor;

            _GetSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //cmbAutoLock
            if (cmbAutoLock.SelectedIndex == 3)
                Properties.Settings.Default.AutoLockMinutes = -1;
            else if (cmbAutoLock.SelectedIndex == 0)
                Properties.Settings.Default.AutoLockMinutes = 5;
            else if (cmbAutoLock.SelectedIndex == 1)
                Properties.Settings.Default.AutoLockMinutes = 15;
            else if (cmbAutoLock.SelectedIndex == 2)
                Properties.Settings.Default.AutoLockMinutes = 30;


            //cmbClearClipboard
            if (cmbClearClipboard.SelectedIndex == 3)
                Properties.Settings.Default.ClipboardTimeoutSeconds = -1;
            else if (cmbClearClipboard.SelectedIndex == 0)
                Properties.Settings.Default.ClipboardTimeoutSeconds = 30;
            else if (cmbClearClipboard.SelectedIndex == 1)
                Properties.Settings.Default.ClipboardTimeoutSeconds = 60;
            else if (cmbClearClipboard.SelectedIndex == 2)
                Properties.Settings.Default.ClipboardTimeoutSeconds = 180;

            Properties.Settings.Default.Save();

            MessageBox.Show("Data Saved Successfully!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clsGlobal.RecordActivity("Settings Changed", "  ---  ", PasswordsManagement_Business.clsHistory.enStatus.Success, "System");


           
        }

        private void btnSetToDefault_Click(object sender, EventArgs e)
        {
            cmbAutoLock.SelectedIndex = 3;
            cmbClearClipboard.SelectedIndex = 3;
            TsRequireMasterPassword.Checked = false;
            btnLight.Checked = true;
        }
    }
}

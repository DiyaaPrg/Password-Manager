using PasswordsManagement;
using PasswordsManagement.Accounts.Add_Account;
using PasswordsManagement.Accounts.Show_Accounts;
using PasswordsManagement.Add_Account;
using PasswordsManagement.Dashbord;
using PasswordsManagement.Password_Generator;
using PasswordsManagement.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordsManagement.Properties;
using PasswordsManagement.Global;
using PasswordsManagement.History;
using PasswordsManagement_Business;

namespace PasswordsManagemnt
{
    public partial class MainForm : Form
    {
        private FrmLogin _frm;
        public MainForm(FrmLogin frm)
        {
            InitializeComponent();
            _frm = frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizeTheFrm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAccount_Enter(object sender, EventArgs e)
        {
            btnAddAccount.Checked = true;
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            _frm.Close();

        }

        private void btnEditAccount2_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount();
            frm.ShowDialog();
        }

        public void AddFormToPnlMain(UserControl userControl)
        {
            MainPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(userControl);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            UcAddEditAccount uc = new UcAddEditAccount();
            uc.OnCancel += SetDashbordControl;
            AddFormToPnlMain(uc);
        }

        private void SetDashbordControl()
        {
            btnDashbord.PerformClick();

        }

        private void btnAllAccounts_Click(object sender, EventArgs e)
        {
            UcManageAccounts uc = new UcManageAccounts();
            AddFormToPnlMain(uc);

        }

        private void btnPasswordgenerator_Click(object sender, EventArgs e)
        {
            UCGeneratePassword uc = new UCGeneratePassword();
            AddFormToPnlMain(uc);

        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            UcDashbord Uc = new UcDashbord();
            AddFormToPnlMain(Uc);

        }

        private void LogOut()
        {
            this.Close();
            _frm.Show();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDashbord.PerformClick();

            this.BackColor = clsGlobal.systemColor;

            clsInactivityMonitor.Start();
            clsInactivityMonitor.OnLogOut += LogOut;
        }


        private void btnLockVault_Click(object sender, EventArgs e)
        {
            this.Close();
            //_frm.Close();
            clsGlobal.RecordActivity("Logged Out", "  ---  ", PasswordsManagement_Business.clsHistory.enStatus.Success, "System");

            _frm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            UcSettings Uc = new UcSettings();
            Uc.OnCancel += SetDashbordControl;
            AddFormToPnlMain(Uc);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            UcAbout Uc = new UcAbout();
            AddFormToPnlMain(Uc);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsClipboardManager.Clear();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            UcHistory Uc = new UcHistory();
            AddFormToPnlMain(Uc);
        }

        private void btnFavorites_Click(object sender, EventArgs e)
        {
            UcFavoriteAccounts uc = new UcFavoriteAccounts();
            AddFormToPnlMain(uc);
        }
    }
}

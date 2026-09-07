using PasswordManagement_Business;
using PasswordsManagement.Accounts.Add_Account;
using PasswordsManagement.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagement.Accounts.Show_Accounts
{

    public partial class FrmQuickView : Form
    {
        private clsAccount _CurrentAccount = new clsAccount();
        //private clsClipboardManager _Cmanager = new clsClipboardManager();
        private int _AccountID = 0;

        private short Seconds = 10;

        public FrmQuickView(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            Clipboard.SetText(tbusername.Text);
        }

        private void tbWebsiteUrl_IconRightClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = tbWebsiteUrl.Text.Trim(),
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not open browser: {ex.Message}");
            }
        }

        private void _LoadInfo()
        {
            _CurrentAccount = clsAccount.Find(_AccountID);

            if (_CurrentAccount == null)
            {
                MessageBox.Show($"No Account Exist With ID: {_AccountID}!", "Edit Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbServiceName.Text = _CurrentAccount.Service;

            btnAccountCategory.Text = _CurrentAccount.AccountTypeName;
            btnAccoutStatus.Text = (_CurrentAccount.IsActive) ? "Active" : "Not Active";

            btnAccoutStatus.FillColor = (_CurrentAccount.IsActive) ? Color.FromArgb(220, 252, 231) : Color.FromArgb(255, 192, 192);

            tbusername.Text = _CurrentAccount.Username;
            tbWebsiteUrl.Text = _CurrentAccount.Website;
            tbEmail.Text = _CurrentAccount.Email;
            tbPhone.Text = _CurrentAccount.PhoneNumber;
            tbPassword.Text = _CurrentAccount.EncryptedPassword;
            tbNotes.Text = _CurrentAccount.Notes;

            lbCreatedAt.Text = _CurrentAccount.CreatedDate.ToString();
            lbLastModified.Text = _CurrentAccount.LastModifiedDate.ToString();


        }

        private void FrmQuickView_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (!tbPassword.UseSystemPasswordChar) //password is shown
            {
                timer1.Stop();
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.PasswordChar = '●';
                Seconds = 10;
                lbtime.Text = $"{Seconds:D2}s";
                btnShowPassword.Text = "Show Password";

                clsGlobal.RecordActivity("Password Viewed", _CurrentAccount.Service, PasswordsManagement_Business.clsHistory.enStatus.Success, _CurrentAccount.Username);


            }
            else
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.PasswordChar = '\0';

                btnShowPassword.Text = "Hide Password";
                timer1.Start();
            }




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Seconds == 0)
            {
                timer1.Stop();
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.PasswordChar = '●';
                Seconds = 10;
                btnShowPassword.Text = "Show Password";

            }
            else
            {
                --Seconds;
            }
            lbtime.Text = $"{Seconds:D2}s";

        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            clsClipboardManager.Copy(tbPassword.Text);


        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount(_AccountID);
            frm.ShowDialog();

            _LoadInfo();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

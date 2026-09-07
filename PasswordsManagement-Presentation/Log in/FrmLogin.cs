using PasswordManagement_Business;
using PasswordsManagement.Accounts.Add_Account;
using PasswordsManagement.Accounts.Show_Accounts;
using PasswordsManagement.Global;
using PasswordsManagement.Properties;
using PasswordsManagement_Business;
using PasswordsManagemnt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagement
{
    public partial class FrmLogin : Form
    {
        private int Tries = 1;
        private int seconds = 59;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }



        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "This field is required!");
                tbUsername.BorderColor = Color.Red;
                tbUsername.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
                tbUsername.FocusedState.BorderColor = Color.RoyalBlue;
                tbUsername.BorderColor = Color.Gainsboro;

            }
        }

        private void tbMasterPassword_IconRightClick(object sender, EventArgs e)
        {
            tbMasterPassword.UseSystemPasswordChar = !(tbMasterPassword.UseSystemPasswordChar);

            if (!tbMasterPassword.UseSystemPasswordChar)
            {
                tbMasterPassword.PasswordChar = '\0';
                tbMasterPassword.IconRight = Resources.view;
            }
            else
            {
                tbMasterPassword.PasswordChar = '●';
                tbMasterPassword.IconRight = Resources.hide;
            }
        }

        private void tbMasterPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMasterPassword.Text))
            {
                errorProvider1.SetError(tbMasterPassword, "This field is required!");
                tbMasterPassword.BorderColor = Color.Red;
                tbMasterPassword.FocusedState.BorderColor = Color.Red;
            }

            else
            {
                errorProvider1.SetError(tbMasterPassword, null);
                tbMasterPassword.FocusedState.BorderColor = Color.RoyalBlue;
                tbMasterPassword.BorderColor = Color.Gainsboro;
            }
        }

        private void btnUnlockVault_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbMasterPassword.Text))
            {
                MessageBox.Show("Some Fields are not valid! Put the mouse over the red icon to see the error message", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser? User = clsUser.Find(tbUsername.Text.Trim());


            if (User == null)
            {
                MessageBox.Show($"No user exist with username: {tbUsername.Text}", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!User.CheckPassword(tbMasterPassword.Text.Trim()))
            {
                if (Tries > 3)
                {
                    btnUnlockVault.Enabled = false;
                    lblTime.Visible = true;
                    timer1.Start();
                    Tries = 1;
                    seconds = 59;
                }

                MessageBox.Show($"Wrong Password! Try again!", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.RecordActivity("Failed Login", "  ---  ", PasswordsManagement_Business.clsHistory.enStatus.Fail, "System");

                lblHinttitle.Visible = true;

                lbPasswordHint.Visible = true;
                lbPasswordHint.Text = User.PasswordHint;

                ++Tries;
                return;
            }

            lblHinttitle.Visible = false;
            lbPasswordHint.Visible = false;

            //MessageBox.Show("Correct Credentials");

            clsGlobal.RecordActivity("Logged In", "  ---  ", PasswordsManagement_Business.clsHistory.enStatus.Success, "System");


            clsGlobal.loggedInUser = User;

            tbUsername.Text = "";
            tbMasterPassword.Text = "";

            this.Hide();
            MainForm frm = new MainForm(this);
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds == 0)
            {
                timer1.Stop();
                lblTime.Visible = false;
                btnUnlockVault.Enabled = true;
            }
            else
                --seconds;

            lblTime.Text = $"({seconds:D2})";
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnUnlockVault.PerformClick();
        }

        private void tbMasterPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnUnlockVault.PerformClick();
        }

    }
}

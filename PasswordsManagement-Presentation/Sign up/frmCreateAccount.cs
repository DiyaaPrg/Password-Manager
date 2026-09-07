using PasswordManagement_Business;
using PasswordsManagement.Global;
using PasswordsManagement.Properties;
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
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void tbConfirmMasterPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsername_MouseDown(object sender, MouseEventArgs e)
        {

        }


        private void tbMasterPassword_TextChanged(object sender, EventArgs e)
        {
           clsGlobal.UpdatePasswordStrength(guna2ProgressBar1, tbMasterPassword.Text);
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "This field is required!");
                tbUsername.BorderColor = Color.Red;
                tbUsername.FocusedState.BorderColor = Color.Red;
            }
            if (tbUsername.Text.Length < 5)
            {
                errorProvider1.SetError(tbUsername, "Username should be at least 5 characters!");
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

        private void tbConfirmMasterPassword_Validating(object sender, CancelEventArgs e)
        {

            bool isMatch = (tbConfirmMasterPassword.Text == tbMasterPassword.Text);

            if (!isMatch)
            {
                errorProvider1.SetError(tbConfirmMasterPassword, "Passwords do not match!");
                tbConfirmMasterPassword.BorderColor = Color.Red;
                tbConfirmMasterPassword.FocusedState.BorderColor = Color.Red;

            }
            else
            {

                errorProvider1.SetError(tbConfirmMasterPassword, null);
                tbConfirmMasterPassword.FocusedState.BorderColor = Color.RoyalBlue;
                tbConfirmMasterPassword.BorderColor = Color.Gainsboro;

            }
        }

        private bool CheckInputs()
        {

            if (tbUsername.Text.Length < 5)
            {
                MessageBox.Show("Username should be at least 5 characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (guna2ProgressBar1.Value < 60)
            {
                MessageBox.Show("Master password is not strong enough!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (tbMasterPassword.Text != tbConfirmMasterPassword.Text)
            {
                MessageBox.Show("password & confirm password does not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                return true;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!CheckInputs())
            {
                //MessageBox.Show("Some Fields are not valid! Put the mouse over the red icon to see the error message", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser User = new clsUser();

            User.UserName = tbUsername.Text.Trim();
            User.Password = tbMasterPassword.Text.Trim();
            User.PasswordHint = tbPasswordHint.Text;
            User.IsActive = true;
            

            if (User.Save())
            {
                MessageBox.Show("You have signed up successfully!", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(Application.ExecutablePath);

                Application.Exit();
            }
            else
            {
                MessageBox.Show("Failed To Sign Up!", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (tbMasterPassword.Text.Length < 12)
            {
                errorProvider1.SetError(tbMasterPassword, "Master password should be at least 12 character!");
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

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

    }

}

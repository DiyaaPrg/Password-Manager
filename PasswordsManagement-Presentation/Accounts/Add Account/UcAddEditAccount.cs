using Guna.UI2.WinForms;
using PasswordManagement_Business;
using PasswordsManagement.Global;
using PasswordsManagement.Properties;
using PasswordsManagement_Business;
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

namespace PasswordsManagement.Add_Account
{
    public partial class UcAddEditAccount : UserControl
    {
        public event Action OnCancel;

        protected virtual void CancelOperation()
        {
            Action handler = OnCancel;
            if (handler != null)
            {
                handler();
            }
        }

        public enum enMode { AddNew = 1, Update = 2 };
        public enMode _Mode;

        private clsAccount? _CurrentAccount;
        public int _AccountID;

        private string _currentAccountPassword = null; //for history

        public clsAccount SelectedAccountInfo { get { return _CurrentAccount; } }

        public UcAddEditAccount()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public UcAddEditAccount(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
            _Mode = enMode.Update;
        }

        private void UcAddAccount_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void _LoadInfo()
        {
            //fill category combo box
            DataTable AccountTypes = clsAccountTypes.GetAllAccountTypes();
            CmbVaultCategory.DataSource = AccountTypes;
            CmbVaultCategory.DisplayMember = "Name";



            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Account";
                _CurrentAccount = new clsAccount();

            }
            else
            {
                lblTitle.Text = "Update Account";
                _CurrentAccount = clsAccount.Find(_AccountID);


                if (_CurrentAccount == null)
                {
                    MessageBox.Show($"No Account Exist With ID: {_AccountID}!", "Edit Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tbServiceName.Text = _CurrentAccount.Service;
                tbWebsiteUrl.Text = _CurrentAccount.Website;
                tbMasterPassword.Text = _CurrentAccount.EncryptedPassword;
                CmbVaultCategory.SelectedIndex = (int)_CurrentAccount.AccountTypeID-1;
                tbNotes.Text = _CurrentAccount.Notes;
                tbUsername.Text = _CurrentAccount.Username;
                tbEmail.Text = _CurrentAccount.Email;
                tbPhone.Text = _CurrentAccount.PhoneNumber;

                clsGlobal.UpdatePasswordStrength(ProgressBarPasswordStrength, tbMasterPassword.Text);

                _currentAccountPassword = _CurrentAccount.EncryptedPassword;
            }
        }

        public void LoadAccountInfo(int AccountID)
        {
            _Mode = enMode.Update;

            _AccountID = AccountID;
            _LoadInfo();
        }

        private void tbMasterPassword_TextChanged(object sender, EventArgs e)
        {
            clsGlobal.UpdatePasswordStrength(ProgressBarPasswordStrength, tbMasterPassword.Text);

        }

        private bool ValidateInputs()
        {

            if (!clsValidation.IsWebsite(tbWebsiteUrl.Text) && !string.IsNullOrEmpty(tbWebsiteUrl.Text))
            {
                errorProvider1.SetError(tbWebsiteUrl, "Please enter a correct website format!");
                tbWebsiteUrl.BorderColor = Color.Red;
                tbWebsiteUrl.FocusedState.BorderColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(tbWebsiteUrl, null);
                tbWebsiteUrl.FocusedState.BorderColor = Color.RoyalBlue;
                tbWebsiteUrl.BorderColor = Color.Gainsboro;
            }


            if (string.IsNullOrEmpty(tbMasterPassword.Text))
            {
                errorProvider1.SetError(tbMasterPassword, "This field is required!");
                tbMasterPassword.BorderColor = Color.Red;
                tbMasterPassword.FocusedState.BorderColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "This field is required!");
                tbUsername.BorderColor = Color.Red;
                tbUsername.FocusedState.BorderColor = Color.Red;
                return false;
            }

            if (tbMasterPassword.Text.Length < 8)
            {
                errorProvider1.SetError(tbMasterPassword, "Master password should be at least 8 character!");
                tbMasterPassword.BorderColor = Color.Red;
                tbMasterPassword.FocusedState.BorderColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(tbMasterPassword, null);
                tbMasterPassword.FocusedState.BorderColor = Color.RoyalBlue;
                tbMasterPassword.BorderColor = Color.Gainsboro;
            }

            return true;

        }

        private bool _DoesPasswordChanged()
        {
            string passwordDecrypted = clsEncryption.Decrypt(_CurrentAccount.IV, _CurrentAccount.EncryptedPassword, clsSecurityConstantscs.MasterKey);
            return (passwordDecrypted != _currentAccountPassword);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Some Fields are not valid! Put the mouse over the red icon to see the error message", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _CurrentAccount.Service = tbServiceName.Text.Trim();
            _CurrentAccount.Website = (string.IsNullOrEmpty(tbWebsiteUrl.Text)) ? null : tbWebsiteUrl.Text.Trim();
            _CurrentAccount.EncryptedPassword = tbMasterPassword.Text.Trim();
            _CurrentAccount.LastModifiedDate = DateTime.Now;
            _CurrentAccount.Notes = (string.IsNullOrEmpty(tbNotes.Text)) ? null : tbNotes.Text.Trim();
            _CurrentAccount.AccountTypeID = (CmbVaultCategory.SelectedIndex + 1);
            _CurrentAccount.Username = tbUsername.Text.Trim();
            _CurrentAccount.Email = (string.IsNullOrEmpty(tbEmail.Text)) ? null : tbEmail.Text.Trim();
            _CurrentAccount.PhoneNumber = (string.IsNullOrEmpty(tbPhone.Text)) ? null : tbPhone.Text.Trim();


            _CurrentAccount.IsActive = true;

            if (_Mode == enMode.AddNew)
                _CurrentAccount.CreatedDate = DateTime.Now;

            if (_CurrentAccount.Save())
            {
                if (_Mode == enMode.AddNew)
                    clsGlobal.RecordActivity("Account Added", _CurrentAccount.Service, PasswordsManagement_Business.clsHistory.enStatus.Success, _CurrentAccount.Username);
                else
                {
                    clsGlobal.RecordActivity("Account Updated", _CurrentAccount.Service, PasswordsManagement_Business.clsHistory.enStatus.Success, _CurrentAccount.Username);

                    if (_DoesPasswordChanged())
                        clsGlobal.RecordActivity("Password Changed", _CurrentAccount.Service, PasswordsManagement_Business.clsHistory.enStatus.Success, _CurrentAccount.Username);

                }

                MessageBox.Show("Data Saved Sucessfully!", "Add/Edit Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblTitle.Text = "Update Account";
                // raise event to add dashbord to pnl main:

            }
            else
            {
                MessageBox.Show("Data Failed To Save! Check Your Inputs", "Data Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbLoginIdentifier_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "This field is required!");
                tbUsername.BorderColor = Color.Red;
                tbUsername.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUsername, null);
                tbUsername.FocusedState.BorderColor = Color.RoyalBlue;
                tbUsername.BorderColor = Color.Gainsboro;
            }
        }

        private void tbWebsiteUrl_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbWebsiteUrl.Text))
                return;

            if (!clsValidation.IsWebsite(tbWebsiteUrl.Text))
            {
                errorProvider1.SetError(tbWebsiteUrl, "Please enter a correct website format!");
                tbWebsiteUrl.BorderColor = Color.Red;
                tbWebsiteUrl.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                errorProvider1.SetError(tbWebsiteUrl, null);
                tbWebsiteUrl.FocusedState.BorderColor = Color.RoyalBlue;
                tbWebsiteUrl.BorderColor = Color.Gainsboro;
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

            if (tbMasterPassword.Text.Length < 8)
            {
                errorProvider1.SetError(tbMasterPassword, "Master password should be at least 8 character!");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //raise event to show dashbord
            OnCancel?.Invoke();
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            tbMasterPassword.Text = clsUtil.GeneratePassword(15, true, true, true, true);
        }

        private void tbNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
                return;

            if (!clsValidation.ValidateEmail(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Please enter a correct email format!");
                tbEmail.BorderColor = Color.Red;
                tbEmail.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
                tbEmail.FocusedState.BorderColor = Color.RoyalBlue;
                tbEmail.BorderColor = Color.Gainsboro;
            }
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPhone.Text))
                return;

            if (!clsValidation.IsPhoneNumber(tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone, "Please enter a correct phone number format!");
                tbPhone.BorderColor = Color.Red;
                tbPhone.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                errorProvider1.SetError(tbPhone, null);
                tbPhone.FocusedState.BorderColor = Color.RoyalBlue;
                tbPhone.BorderColor = Color.Gainsboro;
            }
        }

       
    }
}

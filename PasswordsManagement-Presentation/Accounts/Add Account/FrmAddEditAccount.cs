using PasswordsManagement.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagement.Accounts.Add_Account
{
    public partial class FrmAddEditAccount : Form
    {
        public FrmAddEditAccount()
        {
            InitializeComponent();
            this.Text = "Add New Account";
        }

        public FrmAddEditAccount(int AccountID)
        {
            InitializeComponent();
            this.Text = "Edit Account";

            ucAddEditAccount1.LoadAccountInfo(AccountID);
        }

        private void FrmAddEditAccount_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

        }

        private void ucAddEditAccount1_OnCancel()
        {
            this.Close();
        }

        private void ucAddEditAccount1_Load(object sender, EventArgs e)
        {

        }
    }
}

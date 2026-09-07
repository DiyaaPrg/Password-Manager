using PasswordManagement_Business;
using PasswordsManagement.Accounts.Add_Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagement.Accounts.Show_Accounts
{
    public partial class UcFavoriteAccounts : UserControl
    {
        public UcFavoriteAccounts()
        {
            InitializeComponent();
        }

        private DataTable _Accounts = new DataTable();

        private void _RefreshTable()
        {
            _Accounts = clsAccount.GetFavoriteAccounts();

            DGVFavoriteAccounts.DataSource = _Accounts;

            for (int i = 0; i < DGVFavoriteAccounts.Rows.Count; ++i)
            {
                DGVFavoriteAccounts.Rows[i].Cells["PASSWORD"].Value = "••••••••••";
            }

        }

        private void UcFavoriteAccounts_Load(object sender, EventArgs e)
        {
            _RefreshTable();

            if (_Accounts.Rows.Count == 0)
            {
                DGVFavoriteAccounts.Visible = false;
                PnlNoAccounts.Visible = true;
            }
            else
            {
                DGVFavoriteAccounts.Visible = true;
                PnlNoAccounts.Visible = false;
            }


        }

        private void PnlNoAccounts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuickView frm = new FrmQuickView((int)DGVFavoriteAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount();
            frm.ShowDialog();

            _RefreshTable();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount((int)DGVFavoriteAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshTable();
        }

        private void removeFromFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAccount _currentaccount = clsAccount.Find((int)DGVFavoriteAccounts.CurrentRow.Cells[0].Value);

            _currentaccount.IsFavorite = false;

            _currentaccount.Save();

            _RefreshTable();
        }
    }
}

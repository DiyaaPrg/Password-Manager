using PasswordManagement_Business;
using PasswordsManagement.Accounts.Add_Account;
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

namespace PasswordsManagement.Accounts.Show_Accounts
{
    public partial class UcManageAccounts : UserControl
    {
        private DataTable _AllAccounts = new DataTable();

        private enum enFilterBy { Service = 0, Username = 1, Category = 2 };
        private enFilterBy _filter;

        public UcManageAccounts()
        {
            InitializeComponent();
        }

        private void RenameColumns()
        {

            DGVAllAccounts.Columns["ID"].HeaderText = "ID";
            DGVAllAccounts.Columns["Service"].HeaderText = "Service";
            DGVAllAccounts.Columns["Category"].HeaderText = "Category";
            DGVAllAccounts.Columns["Username"].HeaderText = "Username";
            DGVAllAccounts.Columns["EncryptedPassword"].HeaderText = "Password";
            DGVAllAccounts.Columns["LastModificationDate"].HeaderText = "Modified Date";
            DGVAllAccounts.Columns["IsActive"].HeaderText = "Status";
        }

        private void SetColumnsWidths()
        {
            DGVAllAccounts.Columns["ID"].FillWeight = 10;
            DGVAllAccounts.Columns["Service"].FillWeight = 30;
            DGVAllAccounts.Columns["Username"].FillWeight = 30;
            DGVAllAccounts.Columns["EncryptedPassword"].FillWeight = 40;
            DGVAllAccounts.Columns["Category"].FillWeight = 30;
            DGVAllAccounts.Columns["LastModificationDate"].FillWeight = 35;
            DGVAllAccounts.Columns["IsActive"].FillWeight = 20;
            DGVAllAccounts.Columns["IsFavorite"].FillWeight = 20;


            DGVAllAccounts.Columns["LastModificationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            for (int i = 0; i < DGVAllAccounts.Rows.Count; ++i)
            {
                DGVAllAccounts.Rows[i].Cells["EncryptedPassword"].Value = "••••••••••";
            }
        }

        private void _RefreshTable()
        {
            _AllAccounts = clsAccount.GetAllAccounts();
            DGVAllAccounts.DataSource = _AllAccounts;

            if (_AllAccounts.Rows.Count <= 0)
                return;

            RenameColumns();
            SetColumnsWidths();

            lbNumberofRecords.Text = DGVAllAccounts.Rows.Count.ToString();
            //DGVAllAccounts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

        }

        private void UCShowAccounts_Load(object sender, EventArgs e)
        {

            if (!DesignMode)
            {
                DataTable Categories = clsAccountTypes.GetAllAccountTypes();
                CmbCategory.DataSource = Categories;
                CmbCategory.DisplayMember = "Name";
                CmbCategory.StartIndex = 0;

                int totalAccounts = 0, activeAccounts = 0, favoritesAccounts = 0, categories = 0;

                clsAccount.GetStatistics(ref totalAccounts, ref activeAccounts, ref favoritesAccounts, ref categories);

                lbTotalAccounts.Text = totalAccounts.ToString();
                lbActiveAccounts.Text = activeAccounts.ToString();
                lbFavorites.Text = favoritesAccounts.ToString();
                lbDisabledAccounts.Text = (totalAccounts - activeAccounts).ToString();

                _RefreshTable();
            }

           


        }

        private string _MapFiterToColumn(enFilterBy filter)
        {
            switch (filter)
            {
                case enFilterBy.Service:
                    return "Service";

                case enFilterBy.Username:
                    return "Username";

                case enFilterBy.Category:
                    return "Category";


                default:
                    return "";
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = _MapFiterToColumn(_filter);

            if (string.IsNullOrEmpty(tbSearch.Text) || tbSearch.Text.Contains('%'))
            {
                _AllAccounts.DefaultView.RowFilter = "";
                return;
            }


            _AllAccounts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnName, tbSearch.Text.Trim());

        }

        private void CmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter = (enFilterBy)CmbFilterBy.SelectedIndex;

            if (_filter == enFilterBy.Category)
            {
                tbSearch.Visible = false;
                CmbCategory.Visible = true;
            }
            else
            {
                tbSearch.Visible = true;
                CmbCategory.Visible = false;
            }

            tbSearch.Text = "";

        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_AllAccounts.Columns.Count < 1)
                return;


            _AllAccounts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", "Category", CmbCategory.Text.Trim());

        }

        private void DGVAllAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount();
            frm.ShowDialog();

            _RefreshTable();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount((int)DGVAllAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshTable();

        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to disactivate this account?", "Disable", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsAccount.Disactivate((int)DGVAllAccounts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Account Desactivated Successfully!", "Disable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clsAccount _currentAccount = clsAccount.Find((int)DGVAllAccounts.CurrentRow.Cells[0].Value);

                    clsGlobal.RecordActivity("Account Disabled", _currentAccount.Service, PasswordsManagement_Business.clsHistory.enStatus.Success, _currentAccount.Username);

                    _RefreshTable();
                }
                else
                {
                    MessageBox.Show("Account Failed to Disactivate!", "Disable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Operation Cancelled!", "Disable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuickView frm = new FrmQuickView((int)DGVAllAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount();
            frm.ShowDialog();

            _RefreshTable();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '%')
                e.Handled = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((bool)DGVAllAccounts.CurrentRow.Cells[7].Value)
            {
                markAsFavoriteToolStripMenuItem.Text = "Remove From Favorites";
                markAsFavoriteToolStripMenuItem.Image = Resources.removeFromFavorite_32_;
                markAsFavoriteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            }
            else
            {
                markAsFavoriteToolStripMenuItem.Text = "Mark As Favorite";
                markAsFavoriteToolStripMenuItem.Image = Resources.star__32_;
                markAsFavoriteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            }
        }
    }
}

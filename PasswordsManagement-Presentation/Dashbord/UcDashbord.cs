using PasswordManagement_Business;
using PasswordsManagement.Accounts.Add_Account;
using PasswordsManagement.Global;
using PasswordsManagement.History;
using PasswordsManagement_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace PasswordsManagement.Dashbord
{
    public partial class UcDashbord : UserControl
    {
        public UcDashbord()
        {
            InitializeComponent();
        }

        private int _Strongpasswords, _weakPasswords, _reusedpasswords;
        private double _StrongPassPercentage, _ReusedpassPercentage;

        private DataTable _RecentHistory = new DataTable();

        private void _RefreshTable()
        {
            _RecentHistory = clsHistory.GetRecentHistory();

            DGVHistory.DataSource = _RecentHistory;

        }

        private List<string> _passwordsDecrypted = clsAccount.GetPasswordsDecrypted();

        private int GetReusedPasswordCount()
        {
            return _passwordsDecrypted.GroupBy(p => p).Where(g => g.Count() > 1).Sum(g => g.Count());
        }

        private short _CountStrongPasswords()
        {
            short count = 0;
            foreach (string password in _passwordsDecrypted)
            {
                count = (clsGlobal._GetPasswordScore(password) >= 60) ? ++count : count;
            }
            return count;
        }

        private void _FillInfo()
        {
            _Strongpasswords = _CountStrongPasswords();
            _weakPasswords = _passwordsDecrypted.Count - _Strongpasswords;



            _reusedpasswords = GetReusedPasswordCount();

            lbStrongpasswords.Text = _Strongpasswords.ToString();
            lbWeakpasswords.Text = _weakPasswords.ToString();
            lbreusedPasswords.Text = _reusedpasswords.ToString();

            lbstrongpass.Text = _Strongpasswords.ToString();
            lbweakpass.Text = _weakPasswords.ToString();
            lbresuedpass.Text = _reusedpasswords.ToString();

            _StrongPassPercentage = _Strongpasswords * 100 / _passwordsDecrypted.Count;

            //guna2vProgressBar1.Value = Convert.ToInt32(_StrongPassPercentage);


            _ReusedpassPercentage = _reusedpasswords * 100 / _passwordsDecrypted.Count;

            lbSecurityScore.Text = (_StrongPassPercentage - _ReusedpassPercentage).ToString();



            int totalWidth = pnlProgressBar.Width;

            int strongWidth = (int)(totalWidth * (_StrongPassPercentage / 100));
            int weakWidth = totalWidth - strongWidth;

            pnlStrong.Width = strongWidth;
            pnlWeak.Location = new Point(x: pnlStrong.Width, y: pnlStrong.Location.Y);


            pnlWeak.Width = weakWidth;



            pnlStrong.BackColor = Color.Green;
            pnlWeak.BackColor = Color.Orange;

            int totalAccounts = 0, activeAccounts = 0, favoritesAccounts = 0, categories = 0;

            clsAccount.GetStatistics(ref totalAccounts, ref activeAccounts, ref favoritesAccounts, ref categories);


            lbTotalAccounts.Text = totalAccounts.ToString();
            lbCategories.Text = categories.ToString();
            lbFavoriteAccounts.Text = favoritesAccounts.ToString();
        }

        private void UcDashbord_Load(object sender, EventArgs e)
        {
            lbUsername.Text = clsGlobal.loggedInUser.UserName;

            _FillInfo();

            _RefreshTable();

        }

        private void btnEditAccount2_Click(object sender, EventArgs e)
        {
            FrmAddEditAccount frm = new FrmAddEditAccount();
            frm.ShowDialog();
        }

        private void lbTotalAccounts_Click(object sender, EventArgs e)
        {

        }

        private void lbViewAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

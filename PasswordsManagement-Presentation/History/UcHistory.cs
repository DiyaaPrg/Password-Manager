using PasswordsManagement.Global;
using PasswordsManagement_Business;
using PasswordsManagement_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagement.History
{
    public partial class UcHistory : UserControl
    {
        public UcHistory()
        {
            InitializeComponent();
        }

        private DataTable _History = new DataTable();


        private void _RefreshTable()
        {
            _History = clsHistory.GetHistory();

            DGVHistory.DataSource = _History;

            lbNumberofRecords.Text = DGVHistory.Rows.Count.ToString();
        }

        private void UcHistory_Load(object sender, EventArgs e)
        {

            _RefreshTable();
        }


        private void btnDeleteAllRecords_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to remove History?", "Remove History", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                clsHistory.DeleteAllRecords();
                _RefreshTable();
            }
            else
            {
                MessageBox.Show("Operation Cancelled", "Remove History");
            }
        }
    }
}

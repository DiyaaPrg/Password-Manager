using PasswordsManagement.Properties;

namespace PasswordsManagement.History
{
    partial class UcHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label4 = new Label();
            lblTitle = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            DGVHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            label1 = new Label();
            lbNumberofRecords = new Label();
            btnDeleteAllRecords = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVHistory).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.75F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(20, 67);
            label4.Name = "label4";
            label4.Size = new Size(474, 28);
            label4.TabIndex = 11;
            label4.Text = "Track changes and activity performed on your stored accounts";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(142, 47);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "History";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderRadius = 16;
            guna2Panel1.Controls.Add(DGVHistory);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(33, 102);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Color = Color.Gainsboro;
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.ShadowDecoration.Depth = 2;
            guna2Panel1.Size = new Size(1604, 831);
            guna2Panel1.TabIndex = 12;
            // 
            // DGVHistory
            // 
            DGVHistory.AllowUserToAddRows = false;
            DGVHistory.AllowUserToDeleteRows = false;
            DGVHistory.AllowUserToResizeColumns = false;
            DGVHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            DGVHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVHistory.ColumnHeadersHeight = 48;
            DGVHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle3.Padding = new Padding(12);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DGVHistory.DefaultCellStyle = dataGridViewCellStyle3;
            DGVHistory.Dock = DockStyle.Fill;
            DGVHistory.GridColor = Color.FromArgb(243, 244, 246);
            DGVHistory.Location = new Point(0, 0);
            DGVHistory.Name = "DGVHistory";
            DGVHistory.ReadOnly = true;
            DGVHistory.RowHeadersVisible = false;
            DGVHistory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGVHistory.RowTemplate.Height = 64;
            DGVHistory.ScrollBars = ScrollBars.Vertical;
            DGVHistory.Size = new Size(1604, 831);
            DGVHistory.TabIndex = 0;
            DGVHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DGVHistory.ThemeStyle.GridColor = Color.FromArgb(243, 244, 246);
            DGVHistory.ThemeStyle.HeaderStyle.BackColor = Color.White;
            DGVHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DGVHistory.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(107, 114, 128);
            DGVHistory.ThemeStyle.HeaderStyle.Height = 48;
            DGVHistory.ThemeStyle.ReadOnly = true;
            DGVHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 11F);
            DGVHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(17, 24, 39);
            DGVHistory.ThemeStyle.RowsStyle.Height = 64;
            DGVHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            DGVHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(33, 964);
            label1.Name = "label1";
            label1.Size = new Size(115, 38);
            label1.TabIndex = 13;
            label1.Text = "# Records:";
            // 
            // lbNumberofRecords
            // 
            lbNumberofRecords.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbNumberofRecords.ForeColor = Color.Black;
            lbNumberofRecords.Location = new Point(140, 964);
            lbNumberofRecords.Name = "lbNumberofRecords";
            lbNumberofRecords.Size = new Size(102, 38);
            lbNumberofRecords.TabIndex = 14;
            lbNumberofRecords.Text = "0";
            // 
            // btnDeleteAllRecords
            // 
            btnDeleteAllRecords.BackColor = Color.Red;
            btnDeleteAllRecords.BorderRadius = 12;
            btnDeleteAllRecords.BorderThickness = 2;
            btnDeleteAllRecords.Cursor = Cursors.Hand;
            btnDeleteAllRecords.CustomizableEdges = customizableEdges3;
            btnDeleteAllRecords.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteAllRecords.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteAllRecords.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeleteAllRecords.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteAllRecords.FillColor = Color.Transparent;
            btnDeleteAllRecords.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDeleteAllRecords.ForeColor = Color.FromArgb(75, 85, 99);
            btnDeleteAllRecords.Image = Resources.delete;
            btnDeleteAllRecords.ImageAlign = HorizontalAlignment.Left;
            btnDeleteAllRecords.ImageSize = new Size(30, 30);
            btnDeleteAllRecords.Location = new Point(695, 964);
            btnDeleteAllRecords.Name = "btnDeleteAllRecords";
            btnDeleteAllRecords.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDeleteAllRecords.Size = new Size(224, 40);
            btnDeleteAllRecords.TabIndex = 22;
            btnDeleteAllRecords.Text = "Delete All Records";
            btnDeleteAllRecords.TextAlign = HorizontalAlignment.Right;
            btnDeleteAllRecords.Click += btnDeleteAllRecords_Click;
            // 
            // UcHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDeleteAllRecords);
            Controls.Add(lbNumberofRecords);
            Controls.Add(label1);
            Controls.Add(guna2Panel1);
            Controls.Add(label4);
            Controls.Add(lblTitle);
            Name = "UcHistory";
            Size = new Size(1666, 1018);
            Load += UcHistory_Load;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label4;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVHistory;
        private Label label1;
        private Label lbNumberofRecords;
        private Guna.UI2.WinForms.Guna2Button btnDeleteAllRecords;
    }
}

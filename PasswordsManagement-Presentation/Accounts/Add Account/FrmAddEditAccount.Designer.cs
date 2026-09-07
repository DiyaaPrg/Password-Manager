namespace PasswordsManagement.Accounts.Add_Account
{
    partial class FrmAddEditAccount
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucAddEditAccount1 = new PasswordsManagement.Add_Account.UcAddEditAccount();
            SuspendLayout();
            // 
            // ucAddEditAccount1
            // 
            ucAddEditAccount1.BackColor = Color.FromArgb(248, 249, 252);
            ucAddEditAccount1.Location = new Point(3, -1);
            ucAddEditAccount1.Name = "ucAddEditAccount1";
            ucAddEditAccount1.Size = new Size(1639, 999);
            ucAddEditAccount1.TabIndex = 0;
            ucAddEditAccount1.OnCancel += ucAddEditAccount1_OnCancel;
            ucAddEditAccount1.Load += ucAddEditAccount1_Load;
            // 
            // FrmAddEditAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1647, 988);
            Controls.Add(ucAddEditAccount1);
            Name = "FrmAddEditAccount";
            Text = "AddEditAccount";
            Load += FrmAddEditAccount_Load;
            ResumeLayout(false);
        }

        #endregion

        private PasswordsManagement.Add_Account.UcAddEditAccount ucAddEditAccount1;
    }
}
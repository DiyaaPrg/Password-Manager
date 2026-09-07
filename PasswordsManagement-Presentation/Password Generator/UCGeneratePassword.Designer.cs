namespace PasswordsManagement.Password_Generator
{
    partial class UCGeneratePassword
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblGeneratedPassword = new Label();
            Passwordpnl = new Guna.UI2.WinForms.Guna2Panel();
            pbCopyPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            label10 = new Label();
            lbPassLength = new Label();
            label2 = new Label();
            ChbUppercase = new Guna.UI2.WinForms.Guna2CheckBox();
            ChbNumbers = new Guna.UI2.WinForms.Guna2CheckBox();
            ChbLowercase = new Guna.UI2.WinForms.Guna2CheckBox();
            ChbSymbols = new Guna.UI2.WinForms.Guna2CheckBox();
            label3 = new Label();
            ProgressBarPasswordStrength = new Guna.UI2.WinForms.Guna2ProgressBar();
            TrackBarPasswordLength = new Guna.UI2.WinForms.Guna2TrackBar();
            btnGeneratePassword = new Guna.UI2.WinForms.Guna2Button();
            Passwordpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCopyPassword).BeginInit();
            SuspendLayout();
            // 
            // lblGeneratedPassword
            // 
            lblGeneratedPassword.Font = new Font("Segoe UI", 15.25F, FontStyle.Bold);
            lblGeneratedPassword.Location = new Point(3, 21);
            lblGeneratedPassword.Name = "lblGeneratedPassword";
            lblGeneratedPassword.Size = new Size(806, 99);
            lblGeneratedPassword.TabIndex = 0;
            // 
            // Passwordpnl
            // 
            Passwordpnl.BackColor = Color.FromArgb(248, 249, 252);
            Passwordpnl.BorderColor = Color.Gainsboro;
            Passwordpnl.BorderThickness = 1;
            Passwordpnl.Controls.Add(pbCopyPassword);
            Passwordpnl.Controls.Add(lblGeneratedPassword);
            Passwordpnl.CustomizableEdges = customizableEdges3;
            Passwordpnl.Location = new Point(374, 243);
            Passwordpnl.Name = "Passwordpnl";
            Passwordpnl.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Passwordpnl.Size = new Size(822, 141);
            Passwordpnl.TabIndex = 1;
            // 
            // pbCopyPassword
            // 
            pbCopyPassword.Cursor = Cursors.Hand;
            pbCopyPassword.CustomizableEdges = customizableEdges1;
            pbCopyPassword.Image = Properties.Resources.copy__24_;
            pbCopyPassword.ImageRotate = 0F;
            pbCopyPassword.Location = new Point(748, 21);
            pbCopyPassword.Name = "pbCopyPassword";
            pbCopyPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pbCopyPassword.Size = new Size(45, 38);
            pbCopyPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pbCopyPassword.TabIndex = 2;
            pbCopyPassword.TabStop = false;
            pbCopyPassword.Click += guna2PictureBox1_Click;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(75, 85, 99);
            label10.Location = new Point(374, 403);
            label10.Name = "label10";
            label10.Size = new Size(135, 37);
            label10.TabIndex = 8;
            label10.Text = "LENGTH";
            // 
            // lbPassLength
            // 
            lbPassLength.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lbPassLength.ForeColor = SystemColors.Highlight;
            lbPassLength.Location = new Point(1155, 400);
            lbPassLength.Name = "lbPassLength";
            lbPassLength.Size = new Size(63, 40);
            lbPassLength.TabIndex = 9;
            lbPassLength.Text = "12";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(75, 85, 99);
            label2.Location = new Point(377, 494);
            label2.Name = "label2";
            label2.Size = new Size(155, 28);
            label2.TabIndex = 10;
            label2.Text = "PARAMTERS";
            // 
            // ChbUppercase
            // 
            ChbUppercase.AutoSize = true;
            ChbUppercase.Checked = true;
            ChbUppercase.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ChbUppercase.CheckedState.BorderRadius = 0;
            ChbUppercase.CheckedState.BorderThickness = 0;
            ChbUppercase.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ChbUppercase.CheckState = CheckState.Checked;
            ChbUppercase.Font = new Font("Segoe UI", 14F);
            ChbUppercase.Location = new Point(377, 551);
            ChbUppercase.Name = "ChbUppercase";
            ChbUppercase.Size = new Size(120, 29);
            ChbUppercase.TabIndex = 11;
            ChbUppercase.Text = "Uppercase";
            ChbUppercase.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ChbUppercase.UncheckedState.BorderRadius = 0;
            ChbUppercase.UncheckedState.BorderThickness = 0;
            ChbUppercase.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ChbUppercase.CheckedChanged += ChbUppercase_CheckedChanged;
            // 
            // ChbNumbers
            // 
            ChbNumbers.AutoSize = true;
            ChbNumbers.Checked = true;
            ChbNumbers.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ChbNumbers.CheckedState.BorderRadius = 0;
            ChbNumbers.CheckedState.BorderThickness = 0;
            ChbNumbers.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ChbNumbers.CheckState = CheckState.Checked;
            ChbNumbers.Font = new Font("Segoe UI", 14F);
            ChbNumbers.Location = new Point(377, 593);
            ChbNumbers.Name = "ChbNumbers";
            ChbNumbers.Size = new Size(108, 29);
            ChbNumbers.TabIndex = 12;
            ChbNumbers.Text = "Numbers";
            ChbNumbers.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ChbNumbers.UncheckedState.BorderRadius = 0;
            ChbNumbers.UncheckedState.BorderThickness = 0;
            ChbNumbers.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // ChbLowercase
            // 
            ChbLowercase.AutoSize = true;
            ChbLowercase.Checked = true;
            ChbLowercase.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ChbLowercase.CheckedState.BorderRadius = 0;
            ChbLowercase.CheckedState.BorderThickness = 0;
            ChbLowercase.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ChbLowercase.CheckState = CheckState.Checked;
            ChbLowercase.Font = new Font("Segoe UI", 14F);
            ChbLowercase.Location = new Point(1099, 551);
            ChbLowercase.Name = "ChbLowercase";
            ChbLowercase.Size = new Size(119, 29);
            ChbLowercase.TabIndex = 13;
            ChbLowercase.Text = "Lowercase";
            ChbLowercase.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ChbLowercase.UncheckedState.BorderRadius = 0;
            ChbLowercase.UncheckedState.BorderThickness = 0;
            ChbLowercase.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // ChbSymbols
            // 
            ChbSymbols.AutoSize = true;
            ChbSymbols.Checked = true;
            ChbSymbols.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ChbSymbols.CheckedState.BorderRadius = 0;
            ChbSymbols.CheckedState.BorderThickness = 0;
            ChbSymbols.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ChbSymbols.CheckState = CheckState.Checked;
            ChbSymbols.Font = new Font("Segoe UI", 15F);
            ChbSymbols.Location = new Point(1099, 593);
            ChbSymbols.Name = "ChbSymbols";
            ChbSymbols.Size = new Size(105, 32);
            ChbSymbols.TabIndex = 14;
            ChbSymbols.Text = "Symbols";
            ChbSymbols.TextAlign = ContentAlignment.MiddleRight;
            ChbSymbols.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ChbSymbols.UncheckedState.BorderRadius = 0;
            ChbSymbols.UncheckedState.BorderThickness = 0;
            ChbSymbols.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(75, 85, 99);
            label3.Location = new Point(377, 660);
            label3.Name = "label3";
            label3.Size = new Size(270, 37);
            label3.TabIndex = 16;
            label3.Text = "PASSWORD STRENGTH";
            // 
            // ProgressBarPasswordStrength
            // 
            ProgressBarPasswordStrength.BorderRadius = 4;
            ProgressBarPasswordStrength.CustomizableEdges = customizableEdges5;
            ProgressBarPasswordStrength.FillColor = Color.FromArgb(229, 231, 235);
            ProgressBarPasswordStrength.Location = new Point(377, 700);
            ProgressBarPasswordStrength.Name = "ProgressBarPasswordStrength";
            ProgressBarPasswordStrength.ProgressColor = Color.FromArgb(239, 68, 68);
            ProgressBarPasswordStrength.ProgressColor2 = Color.FromArgb(34, 197, 94);
            ProgressBarPasswordStrength.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ProgressBarPasswordStrength.Size = new Size(822, 18);
            ProgressBarPasswordStrength.TabIndex = 15;
            ProgressBarPasswordStrength.Text = "PASSWORD STRENGTH";
            ProgressBarPasswordStrength.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // TrackBarPasswordLength
            // 
            TrackBarPasswordLength.FillColor = Color.FromArgb(40, 40, 40);
            TrackBarPasswordLength.Location = new Point(371, 443);
            TrackBarPasswordLength.Maximum = 40;
            TrackBarPasswordLength.Minimum = 12;
            TrackBarPasswordLength.Name = "TrackBarPasswordLength";
            TrackBarPasswordLength.Size = new Size(819, 30);
            TrackBarPasswordLength.TabIndex = 19;
            TrackBarPasswordLength.ThumbColor = Color.DodgerBlue;
            TrackBarPasswordLength.Value = 12;
            TrackBarPasswordLength.ValueChanged += TrackBarPasswordLength_ValueChanged;
            TrackBarPasswordLength.Scroll += TrackBarPasswordLength_Scroll;
            TrackBarPasswordLength.KeyDown += TrackBarPasswordLength_KeyDown;
            TrackBarPasswordLength.KeyPress += TrackBarPasswordLength_KeyPress;
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.BorderRadius = 8;
            btnGeneratePassword.Cursor = Cursors.Hand;
            btnGeneratePassword.CustomizableEdges = customizableEdges7;
            btnGeneratePassword.DisabledState.BorderColor = Color.DarkGray;
            btnGeneratePassword.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGeneratePassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGeneratePassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGeneratePassword.FillColor = SystemColors.Highlight;
            btnGeneratePassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnGeneratePassword.ForeColor = Color.White;
            btnGeneratePassword.Image = Properties.Resources.ai_technology__24_;
            btnGeneratePassword.ImageAlign = HorizontalAlignment.Left;
            btnGeneratePassword.ImageSize = new Size(30, 30);
            btnGeneratePassword.Location = new Point(703, 763);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnGeneratePassword.Size = new Size(201, 40);
            btnGeneratePassword.TabIndex = 20;
            btnGeneratePassword.Text = "Generate";
            btnGeneratePassword.Click += btnGeneratePassword_Click;
            // 
            // UCGeneratePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 252);
            Controls.Add(btnGeneratePassword);
            Controls.Add(TrackBarPasswordLength);
            Controls.Add(label3);
            Controls.Add(ProgressBarPasswordStrength);
            Controls.Add(ChbSymbols);
            Controls.Add(ChbLowercase);
            Controls.Add(ChbNumbers);
            Controls.Add(ChbUppercase);
            Controls.Add(label2);
            Controls.Add(lbPassLength);
            Controls.Add(label10);
            Controls.Add(Passwordpnl);
            Name = "UCGeneratePassword";
            Size = new Size(1653, 895);
            Load += UCGeneratePassword_Load;
            Passwordpnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCopyPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGeneratedPassword;
        private Guna.UI2.WinForms.Guna2Panel Passwordpnl;
        private Guna.UI2.WinForms.Guna2PictureBox pbCopyPassword;
        private Label label10;
        private Label lbPassLength;
        private Label label2;
        private Guna.UI2.WinForms.Guna2CheckBox ChbUppercase;
        private Guna.UI2.WinForms.Guna2CheckBox ChbNumbers;
        private Guna.UI2.WinForms.Guna2CheckBox ChbLowercase;
        private Guna.UI2.WinForms.Guna2CheckBox ChbSymbols;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBarPasswordStrength;
        private Guna.UI2.WinForms.Guna2TrackBar TrackBarPasswordLength;
        private Guna.UI2.WinForms.Guna2Button btnGeneratePassword;
    }
}

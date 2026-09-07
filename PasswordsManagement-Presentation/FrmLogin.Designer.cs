namespace PasswordsManagement
{
    partial class FrmLogin
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            errorProvider1 = new ErrorProvider(components);
            label12 = new Label();
            btnUnlockVault = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblTime = new Label();
            lbPasswordHint = new Label();
            lblHinttitle = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            tbMasterPassword = new Guna.UI2.WinForms.Guna2TextBox();
            label9 = new Label();
            tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            Rgistrationpnl = new Guna.UI2.WinForms.Guna2Panel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            Brandingpnl = new Guna.UI2.WinForms.Guna2Panel();
            label5 = new Label();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            Rgistrationpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            Brandingpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 11F);
            label12.ForeColor = Color.Firebrick;
            label12.Location = new Point(3, 10);
            label12.Name = "label12";
            label12.Size = new Size(432, 62);
            label12.TabIndex = 0;
            label12.Text = "⚠ Important: Your master password cannot be recovered if forgotten. VaultGuard does not store it on any server.\r\nKeep it safe.\r\n ";
            label12.Click += label12_Click;
            // 
            // btnUnlockVault
            // 
            btnUnlockVault.BorderRadius = 8;
            btnUnlockVault.Cursor = Cursors.Hand;
            btnUnlockVault.CustomizableEdges = customizableEdges1;
            btnUnlockVault.DisabledState.BorderColor = Color.DarkGray;
            btnUnlockVault.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUnlockVault.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUnlockVault.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUnlockVault.FillColor = SystemColors.Highlight;
            btnUnlockVault.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnUnlockVault.ForeColor = Color.White;
            btnUnlockVault.ImageSize = new Size(20, 55);
            btnUnlockVault.Location = new Point(43, 338);
            btnUnlockVault.Name = "btnUnlockVault";
            btnUnlockVault.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUnlockVault.Size = new Size(454, 55);
            btnUnlockVault.TabIndex = 11;
            btnUnlockVault.Text = "Unlock Vault";
            btnUnlockVault.Click += btnUnlockVault_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.LightGray;
            guna2Panel1.BorderRadius = 15;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(lblTime);
            guna2Panel1.Controls.Add(lbPasswordHint);
            guna2Panel1.Controls.Add(lblHinttitle);
            guna2Panel1.Controls.Add(btnUnlockVault);
            guna2Panel1.Controls.Add(guna2Panel2);
            guna2Panel1.Controls.Add(tbMasterPassword);
            guna2Panel1.Controls.Add(label9);
            guna2Panel1.Controls.Add(tbUsername);
            guna2Panel1.Controls.Add(label8);
            guna2Panel1.Controls.Add(label7);
            guna2Panel1.Controls.Add(label6);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(90, 86);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(520, 549);
            guna2Panel1.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.FromArgb(156, 163, 175);
            lblTime.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(334, 350);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(46, 30);
            lblTime.TabIndex = 14;
            lblTime.Text = "(59)";
            lblTime.TextAlign = ContentAlignment.MiddleLeft;
            lblTime.Visible = false;
            lblTime.Click += lblTime_Click;
            // 
            // lbPasswordHint
            // 
            lbPasswordHint.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPasswordHint.ForeColor = Color.Red;
            lbPasswordHint.Location = new Point(163, 296);
            lbPasswordHint.Name = "lbPasswordHint";
            lbPasswordHint.Size = new Size(313, 24);
            lbPasswordHint.TabIndex = 13;
            lbPasswordHint.Text = "123";
            lbPasswordHint.TextAlign = ContentAlignment.MiddleLeft;
            lbPasswordHint.Visible = false;
            // 
            // lblHinttitle
            // 
            lblHinttitle.Font = new Font("Segoe UI", 13F);
            lblHinttitle.ForeColor = Color.Black;
            lblHinttitle.Location = new Point(25, 296);
            lblHinttitle.Name = "lblHinttitle";
            lblHinttitle.Size = new Size(143, 24);
            lblHinttitle.TabIndex = 12;
            lblHinttitle.Text = "Password Hint:";
            lblHinttitle.TextAlign = ContentAlignment.MiddleRight;
            lblHinttitle.Visible = false;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BorderColor = Color.FromArgb(255, 200, 200);
            guna2Panel2.BorderRadius = 6;
            guna2Panel2.BorderThickness = 1;
            guna2Panel2.Controls.Add(label12);
            guna2Panel2.CustomizableEdges = customizableEdges3;
            guna2Panel2.FillColor = Color.FromArgb(255, 245, 245);
            guna2Panel2.Location = new Point(43, 409);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(457, 81);
            guna2Panel2.TabIndex = 10;
            // 
            // tbMasterPassword
            // 
            tbMasterPassword.BorderColor = Color.Gainsboro;
            tbMasterPassword.BorderRadius = 6;
            tbMasterPassword.CustomizableEdges = customizableEdges5;
            tbMasterPassword.DefaultText = "";
            tbMasterPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbMasterPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbMasterPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbMasterPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbMasterPassword.FocusedState.BorderColor = SystemColors.Highlight;
            tbMasterPassword.Font = new Font("Segoe UI", 14F);
            tbMasterPassword.ForeColor = Color.Black;
            tbMasterPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbMasterPassword.IconLeft = Properties.Resources.Lock__64_;
            tbMasterPassword.IconRight = Properties.Resources.hide;
            tbMasterPassword.Location = new Point(43, 239);
            tbMasterPassword.Margin = new Padding(6, 7, 6, 7);
            tbMasterPassword.MaxLength = 30;
            tbMasterPassword.Name = "tbMasterPassword";
            tbMasterPassword.PasswordChar = '●';
            tbMasterPassword.PlaceholderText = "Enter your master password";
            tbMasterPassword.SelectedText = "";
            tbMasterPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbMasterPassword.Size = new Size(457, 50);
            tbMasterPassword.TabIndex = 5;
            tbMasterPassword.UseSystemPasswordChar = true;
            tbMasterPassword.IconRightClick += tbMasterPassword_IconRightClick;
            tbMasterPassword.KeyDown += tbMasterPassword_KeyDown;
            tbMasterPassword.Validating += tbMasterPassword_Validating;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 13F);
            label9.Location = new Point(40, 207);
            label9.Name = "label9";
            label9.Size = new Size(146, 25);
            label9.TabIndex = 4;
            label9.Text = "Master Password";
            // 
            // tbUsername
            // 
            tbUsername.AutoSize = true;
            tbUsername.BorderColor = Color.Gainsboro;
            tbUsername.BorderRadius = 6;
            tbUsername.CustomizableEdges = customizableEdges7;
            tbUsername.DefaultText = "";
            tbUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.FocusedState.BorderColor = SystemColors.Highlight;
            tbUsername.Font = new Font("Segoe UI", 14F);
            tbUsername.ForeColor = Color.Black;
            tbUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.IconLeft = Properties.Resources.Accounts__64_;
            tbUsername.Location = new Point(40, 142);
            tbUsername.Margin = new Padding(5);
            tbUsername.MaxLength = 20;
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "Enter your username";
            tbUsername.SelectedText = "";
            tbUsername.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbUsername.Size = new Size(457, 50);
            tbUsername.TabIndex = 3;
            tbUsername.KeyDown += tbUsername_KeyDown;
            tbUsername.Validating += tbUsername_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 13F);
            label8.Location = new Point(40, 112);
            label8.Name = "label8";
            label8.Size = new Size(91, 25);
            label8.TabIndex = 2;
            label8.Text = "Username";
            // 
            // label7
            // 
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 12F);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(92, 50);
            label7.Name = "label7";
            label7.Size = new Size(333, 27);
            label7.TabIndex = 1;
            label7.Text = "Sign in using your Master Account.";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(163, 18);
            label6.Name = "label6";
            label6.Size = new Size(179, 32);
            label6.TabIndex = 0;
            label6.Text = "Welcome Back";
            // 
            // Rgistrationpnl
            // 
            Rgistrationpnl.BackColor = Color.White;
            Rgistrationpnl.Controls.Add(guna2Panel1);
            Rgistrationpnl.CustomizableEdges = customizableEdges11;
            Rgistrationpnl.Dock = DockStyle.Fill;
            Rgistrationpnl.FillColor = Color.White;
            Rgistrationpnl.Location = new Point(686, 0);
            Rgistrationpnl.Name = "Rgistrationpnl";
            Rgistrationpnl.ShadowDecoration.CustomizableEdges = customizableEdges12;
            Rgistrationpnl.Size = new Size(666, 729);
            Rgistrationpnl.TabIndex = 3;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges15;
            guna2PictureBox1.Image = Properties.Resources.vaultguard_logo;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(-48, 0);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2PictureBox1.Size = new Size(350, 120);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            // 
            // Brandingpnl
            // 
            Brandingpnl.Controls.Add(label5);
            Brandingpnl.Controls.Add(guna2PictureBox2);
            Brandingpnl.Controls.Add(label1);
            Brandingpnl.Controls.Add(label4);
            Brandingpnl.Controls.Add(label3);
            Brandingpnl.Controls.Add(label2);
            Brandingpnl.Controls.Add(guna2PictureBox1);
            Brandingpnl.CustomizableEdges = customizableEdges17;
            Brandingpnl.Dock = DockStyle.Left;
            Brandingpnl.FillColor = Color.FromArgb(245, 246, 248);
            Brandingpnl.Location = new Point(0, 0);
            Brandingpnl.Name = "Brandingpnl";
            Brandingpnl.ShadowDecoration.CustomizableEdges = customizableEdges18;
            Brandingpnl.Size = new Size(686, 729);
            Brandingpnl.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(213, 695);
            label5.Name = "label5";
            label5.Size = new Size(162, 19);
            label5.TabIndex = 7;
            label5.Text = " 🗄️ Local Secure Storage";
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.BorderRadius = 4;
            guna2PictureBox2.CustomizableEdges = customizableEdges13;
            guna2PictureBox2.Image = Properties.Resources.Gemini_Generated_Image_ed5ovped5ovped5o;
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(165, 129);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2PictureBox2.Size = new Size(310, 294);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox2.TabIndex = 5;
            guna2PictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(36, 695);
            label1.Name = "label1";
            label1.Size = new Size(150, 19);
            label1.TabIndex = 6;
            label1.Text = "🔒AES-256 Encryption\r\n";
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(165, 546);
            label4.Name = "label4";
            label4.Size = new Size(422, 65);
            label4.TabIndex = 4;
            label4.Text = "Securely access your encrypted vault and manage all your\r\npasswords from one trusted place.";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(148, 495);
            label3.Name = "label3";
            label3.Size = new Size(439, 60);
            label3.TabIndex = 3;
            label3.Text = "Unlimited Security.";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(148, 446);
            label2.Name = "label2";
            label2.Size = new Size(372, 60);
            label2.TabIndex = 2;
            label2.Text = "One Master Password.";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1352, 729);
            Controls.Add(Rgistrationpnl);
            Controls.Add(Brandingpnl);
            Name = "FrmLogin";
            Text = "Login";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            Rgistrationpnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            Brandingpnl.ResumeLayout(false);
            Brandingpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Panel Rgistrationpnl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnUnlockVault;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Label label12;
        private Guna.UI2.WinForms.Guna2TextBox tbMasterPassword;
        private Label label9;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private Label label8;
        private Label label7;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Panel Brandingpnl;
        private Label label5;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label lbPasswordHint;
        private Label lblHinttitle;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}
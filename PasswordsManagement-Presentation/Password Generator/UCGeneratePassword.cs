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

namespace PasswordsManagement.Password_Generator
{
    public partial class UCGeneratePassword : UserControl
    {
        public UCGeneratePassword()
        {
            InitializeComponent();
        }

        private void GeneratePassword()
        {
            lblGeneratedPassword.Text = clsUtil.GeneratePassword(TrackBarPasswordLength.Value, ChbLowercase.Checked, ChbUppercase.Checked, ChbNumbers.Checked, ChbSymbols.Checked);

            clsGlobal.UpdatePasswordStrength(ProgressBarPasswordStrength, lblGeneratedPassword.Text);
        }

        private void UCGeneratePassword_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // copy password:
            if (lblGeneratedPassword.Text.Length >0)
                Clipboard.SetText(lblGeneratedPassword.Text);
        }

        private void TrackBarPasswordLength_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void ChbUppercase_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TrackBarPasswordLength_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TrackBarPasswordLength_KeyDown(object sender, KeyEventArgs e)
        {
            //if (TrackBarPasswordLength.Value == TrackBarPasswordLength.Maximum || TrackBarPasswordLength.Value == TrackBarPasswordLength.Minimum)
            //    return;

            //if (e.KeyCode == Keys.Right)
            //{
            //    TrackBarPasswordLength.Value++;
            //}
            //else if (e.KeyCode == Keys.Left)
            //    TrackBarPasswordLength.Value--;


            //lbPassLength.Text = TrackBarPasswordLength.Value.ToString();

            //GeneratePassword(sender, e);
        }

        private void TrackBarPasswordLength_ValueChanged(object sender, EventArgs e)
        {
            lbPassLength.Text = TrackBarPasswordLength.Value.ToString();
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            lblGeneratedPassword.Text = clsUtil.GeneratePassword(TrackBarPasswordLength.Value, ChbLowercase.Checked, ChbUppercase.Checked, ChbNumbers.Checked, ChbSymbols.Checked);


            clsGlobal.UpdatePasswordStrength(ProgressBarPasswordStrength, lblGeneratedPassword.Text);
        }
    }
}

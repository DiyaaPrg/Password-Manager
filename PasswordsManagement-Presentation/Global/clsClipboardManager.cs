using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordsManagement.Global
{
    internal class clsClipboardManager
    {
        public static string Text { set; get; }

        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        

        private static void _settime()
        {
            if (Properties.Settings.Default.ClipboardTimeoutSeconds == -1)
                return;
            else
                timer.Interval = Properties.Settings.Default.ClipboardTimeoutSeconds * 1000;

            timer.Tick += (sender, e) =>
            {
                Clear();
                timer.Stop();
            };

            timer.Start();
        }

        public static void Copy(string copiedtext)
        {
            Text = copiedtext;
            Clipboard.SetText(Text);

            _settime();
        }

        public static void Clear()
        {
            if (Clipboard.ContainsText() && Clipboard.GetText() == Text)
                Clipboard.Clear();
        }
    }
}

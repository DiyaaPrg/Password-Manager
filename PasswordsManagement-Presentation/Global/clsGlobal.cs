using Guna.UI2.WinForms;
using PasswordManagement_Business;
using PasswordsManagement_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsManagement.Global
{
    public class clsGlobal
    {
        public static clsUser loggedInUser = null;

        public static short _GetPasswordScore(string password)
        {
            short score = 0;

            if (password.Length >= 12)
                score += 20;

            if (password.Any(char.IsLower))
                score += 20;

            if (password.Any(char.IsUpper))
                score += 20;

            if (password.Any(char.IsDigit))
                score += 20;

            if (password.Any(ch => !char.IsLetterOrDigit(ch)))
                score += 20;

            return score;
        }

        public static void UpdatePasswordStrength(Guna2ProgressBar guna2ProgressBar1, string password)
        {

            short score = _GetPasswordScore(password);

            guna2ProgressBar1.Value = score;

            if (score <= 20)
            {
                guna2ProgressBar1.ProgressColor =
                guna2ProgressBar1.ProgressColor2 = Color.Red;

            }
            else if (score <= 40)
            {
                guna2ProgressBar1.ProgressColor =
                guna2ProgressBar1.ProgressColor2 = Color.Orange;

            }
            else if (score <= 60)
            {
                guna2ProgressBar1.ProgressColor =
                guna2ProgressBar1.ProgressColor2 = Color.Goldenrod;

            }
            else if (score <= 80)
            {
                guna2ProgressBar1.ProgressColor =
                guna2ProgressBar1.ProgressColor2 = Color.YellowGreen;

            }
            else
            {
                guna2ProgressBar1.ProgressColor = guna2ProgressBar1.ProgressColor2 = Color.Green;

            }
        }

        public static bool RecordActivity(string action, string service, clsHistory.enStatus status, string username)
        {
            clsHistory record = new clsHistory();
            record.Action = action;
            record.Date = DateTime.Now;
            record.Service = service;
            record.Status = status;
            record.Username = username;

            return record.Save();
        }

        public static Color systemColor;
    }
}

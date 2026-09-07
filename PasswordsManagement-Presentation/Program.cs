using PasswordsManagement;
using PasswordsManagemnt;
using PasswordManagement_Business;
using PasswordsManagement.Accounts.Show_Accounts;
namespace AccountsManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (!clsUser.FindActiveUser())
            {
                Application.Run(new frmCreateAccount());
            }
            else
            {
                Application.Run(new FrmLogin());

            }
            //Application.Run(new Frmexample());
        }
    }
}
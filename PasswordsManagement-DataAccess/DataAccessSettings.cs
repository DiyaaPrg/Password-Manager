using Microsoft.IdentityModel.Protocols;
using System;

using System.Configuration;

namespace PasswordsManagement_DataAccess
{
    internal class DataAccessSettings
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["PasswordsManagement"].ConnectionString;
    }
}

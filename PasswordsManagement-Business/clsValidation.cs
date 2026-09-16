using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordsManagement.Global
{
    public class clsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        public static bool IsPhoneNumber(string phone)
        {
            string pattern = @"^\+?[0-9]{8,15}$";
            return Regex.IsMatch(phone, pattern);
        }


        public static bool IsWebsite(string url)
        {
            string pattern = @"^(https?:\/\/)?([\w\-]+\.)+[\w\-]{2,}(\/\S*)?$";
            return Regex.IsMatch(url, pattern);
        }


        public static bool ValidateRequired(object obj)
        {
            Type classType = obj.GetType();

            foreach (PropertyInfo property in classType.GetProperties())
            {
                if (property.IsDefined(typeof(RequiredAttribute)))
                {
                    var value = property.GetValue(obj);

                    if (value == null)
                        return false;

                    if (property.PropertyType == typeof(string) &&
                        string.IsNullOrWhiteSpace((string)value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }

}

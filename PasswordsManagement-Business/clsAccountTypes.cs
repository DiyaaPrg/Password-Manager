using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordsManagement_DataAccess;

namespace PasswordManagement_Business
{
    public class clsAccountTypes
    {
        enum enMode { AddNew = 1, Update }
        enMode mode;

        public int ?ID { get; set; }
        public string Name { get; set; }

        private clsAccountTypes(int ?ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            mode = enMode.Update;
        }

        static public DataTable GetAllAccountTypes()
        {
            return clsAccountTypesData.GetAllAccountTypes();
        }

        private bool Update()
        {
            return clsAccountTypesData.Update(this.ID, this.Name);
        }

        static public clsAccountTypes Find(int ?ID)
        {
            string name = "";
            if (clsAccountTypesData.FindByID(ID, ref name))
            {
                return new clsAccountTypes(ID, name);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            if (mode == enMode.Update)
            {
                return Update();
            }
            else
            {
                return false;
            }
        }


    }
}

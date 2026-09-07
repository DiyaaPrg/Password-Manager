using PasswordManagement_Business;
using PasswordsManagement_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordsManagement_Business
{
    public class clsHistory
    {

        enum enMode { AddNew = 1, Update = 2 }
        public enum enStatus { Fail=0, Success=1}
        private enMode _Mode;
        public int? ID { set; get; }
        public string Action { set; get; }
        public DateTime Date { set; get; }

        public string Service { set; get; }

        public enStatus Status { set; get; }
        public string StatusText 
        {
            get
            {
                if (this.Status == enStatus.Fail)
                    return "Fail";
                else
                    return "Success";

            }
        }
        public string Username { set; get; }



        private clsHistory(int ?ID, string action, DateTime date, string service, enStatus status, string username)
        {
            this.ID = ID;
            this.Action = action;
            this.Date = date;
            this.Service = service;
            this.Status = status;
            this.Username = username;

            _Mode = enMode.Update;
        }

        public clsHistory()
        {
            this.ID = null;
            this.Action = null;
            this.Date = DateTime.Now;
            this.Service = null;
            this.Status = enStatus.Fail;
            this.Username = null;

            _Mode = enMode.AddNew;
        }


        public static DataTable GetHistory()
        {
            return clsHistoryData.GetAllHistory();
        }

        public static DataTable GetRecentHistory()
        {
            return clsHistoryData.GetRecentHistory();
        }

        public static clsHistory Find(int ID)
        {
            string action = "", service = "", username="";
            DateTime date = DateTime.Now;
            int status = 0;

            if (clsHistoryData.GetHistoryByID(ID, ref action, ref date, ref service, ref status, ref username))
            {
                return new clsHistory(ID, action, date, service, (enStatus)status, username);
            }
            else
                return null;
        }


        private bool _AddNew()
        {
            this.ID = clsHistoryData.AddNewHistory(this.Action, this.Date, this.Service, (int)this.Status, this.Username);
            return (this.ID != -1);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
            }
            return false;
        }

        public static bool DeleteHistory(int ID)
        {
            return clsHistoryData.DeleteHistory(ID);
        }

        public static bool DeleteAllRecords()
        {
            return clsHistoryData.DeleteAllRecords();
        }
    }
}


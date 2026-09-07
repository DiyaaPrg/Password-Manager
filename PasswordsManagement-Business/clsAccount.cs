using PasswordsManagement_Business;
using PasswordsManagement_DataAccess;
using System.Data;

namespace PasswordManagement_Business
{
    public enum enIdentifierType { Username = 0, Email = 1, Phone = 2 }

    public class clsAccount
    {
        private enum enMode { AddNew = 1, Update = 2 };

        public int? ID { set; get; }
        public string? Service { set; get; }
        public int? AccountTypeID { set; get; }
        public string AccountTypeName { set; get; }

        private clsAccountTypes _AccountType;
        public clsAccountTypes AccountType
        {
            get
            {
                if (_AccountType == null)
                {
                    _AccountType = clsAccountTypes.Find(this.AccountTypeID);
                }
                return _AccountType;
            }
        }
        public string? Website { set; get; }
        public string? EncryptedPassword { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? LastModifiedDate { set; get; }
        public string? Notes { set; get; }
        public bool IsFavorite { set; get; }
        public bool IsActive { set; get; }
        public string IV { set; get; }
        public string Username { set; get; }
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }


        private enMode _Mode;


        public clsAccount()
        {
            this.ID = null;
            this.Service = null;
            this.AccountTypeID = null;
            this.Website = null;
            this.EncryptedPassword = null;
            this.CreatedDate = null;
            this.LastModifiedDate = null;
            this.Notes = null;
            this.IsFavorite = false;
            this.IsActive = false;
            this.Username = null;
            this.Email = null;
            this.PhoneNumber = null;
            this._Mode = enMode.AddNew;
        }

        private clsAccount(int ID, string service, int accountTypeID, string website, string encryptedPassword, DateTime createdDate,
            DateTime lastModifiedDate, string notes, bool isFavorite, bool isActive, string IV, string username, string email, string phone)
        {
            this.ID = ID;
            this.Service = service;
            this.AccountTypeID = accountTypeID;
            this.Website = website;
            this.CreatedDate = createdDate;
            this.LastModifiedDate = lastModifiedDate;
            this.Notes = notes;
            this.IsFavorite = isFavorite;
            this.IsActive = isActive;
            this.IV = IV;
            this.Username = username;
            this.Email = email;
            this.PhoneNumber = phone;

            this.AccountTypeName = clsAccountTypes.Find(this.AccountTypeID).Name;

            this.EncryptedPassword = clsEncryption.Decrypt(this.IV, encryptedPassword, clsSecurityConstantscs.MasterKey);

            this._Mode = enMode.Update;
        }

        static public clsAccount? Find(int ID)
        {
            string? service = null;
            int? accountTypeID = null;
            string? website = null;
            string? encryptedPassword = null;
            DateTime createdDate = DateTime.MinValue;
            DateTime lastModifiedDate = DateTime.MinValue;
            string? notes = null;
            bool isFavorite = false;
            bool isActive = false;
            string IV = "", username="", email="", phone="";

            if (clsAccountData.FindByID(ID, ref service, ref accountTypeID, ref website, ref encryptedPassword, ref createdDate, ref lastModifiedDate,
                    ref notes, ref isFavorite, ref isActive, ref IV, ref username, ref email, ref phone))
            {
                return new clsAccount(ID, service!, accountTypeID!.Value, website!, encryptedPassword!, createdDate,
                    lastModifiedDate, notes!, isFavorite, isActive, IV, username, email, phone);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            var result = clsEncryption.Encrypt(this.EncryptedPassword, clsSecurityConstantscs.MasterKey);
            
            this.EncryptedPassword = result.CipherText;
            this.IV = result.IV;


            this.ID = clsAccountData.AddNewAccount(
                this.Service!,
                this.AccountTypeID!.Value,
                this.Website,
                this.EncryptedPassword!,
                this.Notes!,
                this.IsFavorite,
                this.IsActive,
                this.IV,
                this.Username,
                this.Email!,
                this.PhoneNumber!
            );

            return (this.ID != null);
        }
         
        private bool _Update()
        {
            var result = clsEncryption.Encrypt(this.EncryptedPassword, clsSecurityConstantscs.MasterKey);

            this.EncryptedPassword = result.CipherText;
            this.IV = result.IV;

            return clsAccountData.UpdateAccount(
                this.ID!.Value,
                this.Service!,
                this.AccountTypeID!.Value,
                this.Website,
                this.EncryptedPassword!,
                this.Notes!,
                this.IsFavorite,
                this.IsActive,
                this.IV,
                this.Username,
                this.Email!,
                this.PhoneNumber!
            );
        }

        public static DataTable GetAllAccounts()
        {
            return clsAccountData.GetAllAccounts();
        }

        public static DataTable GetFavoriteAccounts()
        {
            return clsAccountData.GetFavoriteAccounts();
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

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public static void GetStatistics(ref int AllAccounts, ref  int ActiveAccounts, ref int FavoriteAccounts, ref int categories)
        {
             clsAccountData.GetStatistics(ref AllAccounts, ref ActiveAccounts, ref FavoriteAccounts, ref categories);
        }

        static public bool Disactivate(int accountID)
        {
            return clsAccountData.Disactivate(accountID);
        }

        static public List<string>  GetPasswordsDecrypted()
        {
            List<string> passwordsDecrypted = new List<string>();

            DataTable PasswordsEncrypted = clsAccountData.GetEncryptedPasswords();

            foreach(DataRow row in PasswordsEncrypted.Rows)
            {
                string password = (string)row[0];
                string IV = (string)row[1];

                passwordsDecrypted.Add(clsEncryption.Decrypt(IV, password, clsSecurityConstantscs.MasterKey));
            }

            return passwordsDecrypted;
        }



    }
}
using PasswordsManagement_Business;
using PasswordsManagement_DataAccess;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagement_Business
{
    public class clsUser
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;

        public int? ID { set; get; }
        public string UserName { set; get; }
        public string EncryptedVerification { set; get; }
        public string Password { set; get; }
        public string Salt { set; get; }
        public string PasswordHint { set; get; }
        public string EncryptedMEK { set; get; }

        public DateTime? CreatedDate { set; get; }

        public bool IsActive { set; get; }

        public clsUser()
        {
            this.ID = null;
            this.UserName = "";
            this.EncryptedVerification = "";
            this.Salt = "";
            this.PasswordHint = "";
            this.CreatedDate = null;
            this.Password = "";
            this.IsActive = false;
            this.EncryptedMEK = "";

            this._Mode = enMode.AddNew;
        }

        private clsUser(int ?ID, string username, string encryptedVerification, string salt,
            string passwordHint, DateTime createdDate, string MEK, bool IsActive)
        {
            this.ID = ID;
            this.UserName = username;
            this.EncryptedVerification = encryptedVerification;
            this.Salt = salt;
            this.PasswordHint = passwordHint;
            this.CreatedDate = createdDate;
            this.Password = "";
            this.IsActive = IsActive;
            this.EncryptedMEK = MEK;

            this._Mode = enMode.Update;
        }

        static public clsUser? Find(int ID)
        {
            string encryptedVerification = "", username = "", salt = "", passwordHint = "", EncryptedMEK="";
            DateTime createdDate = DateTime.MinValue;
            bool IsActive = false;

            if (clsUserData.FindByID(ID, ref encryptedVerification, ref username, ref salt,
                    ref passwordHint, ref createdDate, ref IsActive, ref EncryptedMEK))
            {
                return new clsUser(ID, username!, encryptedVerification!, salt!,
                    passwordHint, createdDate, EncryptedMEK , IsActive);
            }
            else
            {
                return null;
            }
        }

        static public clsUser? Find(string Username)
        {
            string encryptedVerification = "", salt = "", passwordHint = "", EncryptedMEK = "";
            DateTime createdDate = DateTime.MinValue;
            int ?ID = null;
            bool IsActive = false;


            if (clsUserData.FindByUsername(Username, ref encryptedVerification, ref ID, ref salt,
                    ref passwordHint, ref createdDate, ref IsActive, ref EncryptedMEK))
            {
                return new clsUser(ID, Username!, encryptedVerification!, salt!,
                    passwordHint, createdDate, EncryptedMEK, IsActive);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            //byte[] salt = clsEncryption.GenerateSalt();

            //byte[] masterKey = clsEncryption.DeriveKEKey(this.Password, salt);

            //this.Salt = Convert.ToBase64String(salt);
            //this.EncryptedVerification = Convert.ToBase64String(clsEncryption.EncryptVerification(masterKey));


            (byte[], byte[], byte[]) tuple =  clsEncryption.InitializeUserSecurity(this.Password);

            this.Salt = Convert.ToBase64String(tuple.Item1);
            this.EncryptedVerification = Convert.ToBase64String(tuple.Item2);
            this.EncryptedMEK = Convert.ToBase64String(tuple.Item3);

            this.ID = clsUserData.AddNewUser(
                this.EncryptedVerification,
                this.UserName,
                this.Salt,
                this.PasswordHint,
                this.IsActive,
                this.EncryptedMEK
            );

            return (this.ID != null);
        }

        private bool _Update()
        {
            return clsUserData.UpdateUser(
                this.ID!.Value,
                this.EncryptedVerification,
                this.UserName,
                this.Salt,
                this.PasswordHint,
                this.IsActive,
                this.EncryptedMEK
            );
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

        static public bool FindActiveUser()
        {
            return clsUserData.FindActiveUser();
        }

       public bool CheckPassword(string EnteredPassword)
       {
           byte[] KEKey = clsEncryption.DeriveKEKey(EnteredPassword, Convert.FromBase64String(this.Salt));
           byte[] DataEncrypted = Convert.FromBase64String(this.EncryptedVerification);


           if (clsEncryption.VerifyPassword(KEKey, DataEncrypted))
           {
                clsSecurityConstantscs.KEKey = KEKey; // password is correct.
                clsSecurityConstantscs.MasterKey = clsEncryption.DecryptMEK(KEKey, Convert.FromBase64String(this.EncryptedMEK));

                return true;
           }

            return false;

       }



    }
}
using PasswordManagement_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsManagement_Business
{
    public class clsEncryption
    {
            // =========================
            // 1. Generate Salt
            // =========================
            public static byte[] GenerateSalt(int size = 16)
            {
                return RandomNumberGenerator.GetBytes(size);
            }

            public static string ConvertToHex(byte[] data)
            {
                return Convert.ToHexString(data);
            }

            public static byte[] ConvertFromHex(string hex)
            {
                return Convert.FromHexString(hex);
            }

            // =========================
            // 2. Derive Master Key (PBKDF2)
            // =========================
            public static byte[] DeriveKEKey(string password, byte[] salt)
            {
                return Rfc2898DeriveBytes.Pbkdf2(
                    password: password,
                    salt: salt,
                    iterations: 600000,
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    outputLength: 32 // AES-256
                );
            }

            // =========================
            // 3. Encrypt Verification Value
            // =========================
            public static byte[] EncryptVerification(byte[] key)
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.GenerateIV();

                    using (var encryptor = aes.CreateEncryptor())
                    using (var ms = new System.IO.MemoryStream())
                    {
                        // store IV first
                        ms.Write(aes.IV, 0, aes.IV.Length);

                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(clsSecurityConstantscs.VerificationText);
                        }

                        return ms.ToArray();
                    }
                }
            }

            // =========================
            // 4. Decrypt Verification
            // =========================
            public static bool VerifyPassword(byte[] key, byte[] encryptedData)
            {
            try
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[16];
                        Array.Copy(encryptedData, 0, iv, 0, iv.Length);

                        aes.Key = key;
                        aes.IV = iv;

                        using (var decryptor = aes.CreateDecryptor())
                        using (var memorystream = new System.IO.MemoryStream(encryptedData, 16, encryptedData.Length - 16))
                        using (var cryptostream = new CryptoStream(memorystream, decryptor, CryptoStreamMode.Read))
                        using (var streamreader = new StreamReader(cryptostream))
                        {
                            string result = streamreader.ReadToEnd();
                            return result == clsSecurityConstantscs.VerificationText;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }

            public static clsEncryptionResult Encrypt(string ?plainPassword, byte[]? key)
            {
            clsEncryptionResult result = new clsEncryptionResult();

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;

                    // Generate a new random IV for every encryption
                    aes.GenerateIV();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainPassword);
                        }

                        result.CipherText = Convert.ToBase64String(ms.ToArray());

                        result.IV = Convert.ToBase64String(aes.IV);
                    }
                }
           
                
            }
            catch(Exception ex)
            {
                //
            }

                return result;

        }

        public static string? Decrypt(string IV, string EncryptedPassword, byte[] ?key)
        {
            //Console.WriteLine(Convert.ToBase64String(key));

            Console.WriteLine(IV);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;

                // تحويل IV من Base64 إلى byte[]
                //byte[] ivBytes = Convert.FromBase64String(IV);
                //Console.WriteLine(ivBytes.Length);

                aes.IV = Convert.FromBase64String(IV); 

                // تحويل النص المشفر من Base64 إلى byte[]
                byte[] cipherBytes = Convert.FromBase64String(EncryptedPassword);

                using (MemoryStream ms = new MemoryStream(cipherBytes))
                using (CryptoStream cs = new CryptoStream(
                           ms,
                           aes.CreateDecryptor(),
                           CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    // هنا يتم فك التشفير فعليًا 
                    return sr.ReadToEnd();  //here
                }
            }
        }


        public static byte[] GenerateMasterEncryptionKey()
       {
            return RandomNumberGenerator.GetBytes(32);
       }

        public static byte[] EncryptMEK(byte[] kek, byte[] mek)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = kek;
                aes.GenerateIV();

                using (var ms = new MemoryStream())
                {
                    // نحفظ IV أولاً
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var encryptor = aes.CreateEncryptor())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(mek, 0, mek.Length);
                    }

                    return ms.ToArray(); // IV + Encrypted MEK
                }
            }
        }

        public static byte[] DecryptMEK(byte[] kek, byte[] encryptedMEK)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] iv = new byte[16];
                Array.Copy(encryptedMEK, 0, iv, 0, 16);

                aes.Key = kek;
                aes.IV = iv;

                using (var ms = new MemoryStream(encryptedMEK, 16, encryptedMEK.Length - 16))
                using (var decryptor = aes.CreateDecryptor())
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var br = new BinaryReader(cs))
                {
                    return br.ReadBytes(32); // MEK = 32 bytes
                }
            }
        }

        public static (byte[], byte[], byte[]) InitializeUserSecurity(string password)
        {
            // generate salt:
            byte[] SaltForDerive = GenerateSalt();

            // derive KEK:
            byte[] DerivedKEK = DeriveKEKey(password, SaltForDerive);

            // Generate Random MEK:
            byte[] MasterKey = GenerateMasterEncryptionKey();

            // Encrypt MEK By KEK:
            byte[] EncryptedMasterKey = EncryptMEK(DerivedKEK, MasterKey);

            // Save MEK & KEK static:
            clsSecurityConstantscs.KEKey = DerivedKEK;
            clsSecurityConstantscs.MasterKey = MasterKey; // for accounts passwords encryption


            return (SaltForDerive, EncryptVerification(DerivedKEK), EncryptedMasterKey);
        }

    }


    public class clsEncryptionResult
    {
        public string CipherText { get; set; }

         public string IV { get; set; }
        
    }

}

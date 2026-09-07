using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PasswordsManagement_DataAccess
{
    public class clsUserData
    {
        static public bool FindByID(int ID, ref string EncryptedVerification, ref string username, ref string salt,
            ref string passwordHint, ref DateTime createdDate, ref bool IsActive, ref string EncryptedMEK)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE ID = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("id", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                EncryptedVerification = (string)reader["EncryptedVerification"];
                                username = (string)reader["UserName"];
                                salt = (string)reader["Salt"];
                                passwordHint = (reader["PasswordHint"] == DBNull.Value) ? "": (string)reader["PasswordHint"];
                                createdDate = (DateTime)reader["CreatedDate"];
                                IsActive = (bool)reader["IsActive"];
                                EncryptedMEK = (string)reader["EncryptedMEK"];


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return isFound;
        }

        static public bool FindByUsername(string username, ref string EncryptedVerification, ref int? ID, ref string salt,
    ref string passwordHint, ref DateTime createdDate, ref bool IsActive, ref string EncryptedMEK)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE UserName = @username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("username", username);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                EncryptedVerification = (string)reader["EncryptedVerification"];
                                ID = (int)reader["ID"];
                                salt = (string)reader["Salt"];
                                passwordHint = (reader["PasswordHint"] == DBNull.Value) ? "" : (string)reader["PasswordHint"];
                                createdDate = (DateTime)reader["CreatedAt"];
                                IsActive = (bool)reader["IsActive"];
                                EncryptedMEK = (string)reader["EncryptedMEK"];

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return isFound;
        }

        static public int? AddNewUser(string EncryptedVerification, string username, string salt,
            string? passwordHint, bool IsActive, string EncryptedMEK)
        {
            int? ID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @"INSERT INTO Users (EncryptedVerification, Salt, PasswordHint, CreatedAt, UserName, IsActive, EncryptedMEK)
                                     VALUES (@encryptedVerification, @salt, @passwordHint, @createdDate, @username, @isActive, @EncryptedMEK);
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("encryptedVerification", EncryptedVerification);
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("salt", salt);
                        command.Parameters.AddWithValue("passwordHint", passwordHint);
                        command.Parameters.AddWithValue("createdDate", DateTime.Now);
                        command.Parameters.AddWithValue("IsActive", IsActive);
                        command.Parameters.AddWithValue("EncryptedMEK", EncryptedMEK);



                        object? result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            ID = newID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ID;
        }

        static public bool UpdateUser(int ID, string EncryptedVerification, string username , string salt,
            string? passwordHint, bool IsActive, string EncryptedMEK)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @"UPDATE Users SET
                                        EncryptedVerification = @encryptedVerification,
                                        Salt              = @salt,
                                        PasswordHint      = @passwordHint,
                                        UserName          = @username,
                                        IsActive          = @IsActive,
                                        EncryptedMEK      = @EncryptedMEK
                                     WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("id", ID);
                        command.Parameters.AddWithValue("encryptedVerification", EncryptedVerification);
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("salt", salt);
                        command.Parameters.AddWithValue("passwordHint", passwordHint);
                        command.Parameters.AddWithValue("IsActive", IsActive);
                        command.Parameters.AddWithValue("EncryptedMEK", EncryptedMEK);


                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return (rowsAffected > 0);
        }

        static public bool FindActiveUser()
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE IsActive=1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object? result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return isFound;
        }

    }
}


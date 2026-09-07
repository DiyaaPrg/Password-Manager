using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PasswordsManagement_DataAccess
{
    public class clsAccountData
    {

        static public DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @" SELECT Accounts.ID, Accounts.Service, Accounts.Username, Accounts.EncryptedPassword, AccountTypes.NAME As 'Category', Accounts.LastModificationDate,
Accounts.IsActive, Accounts.IsFavorite
From Accounts INNER JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.ID ORDER BY CreationDate DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //clsLogger.LogError(ex.Message, ex);
            }


            return dt;
        }

        static public DataTable GetFavoriteAccounts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @" SELECT Accounts.ID,  Accounts.Service AS 'SERVICE & DOMAIN', Accounts.Username As 'USERNAME', Accounts.EncryptedPassword As 'PASSWORD', AccountTypes.NAME As 'CATEGORY'
From Accounts INNER JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.ID WHERE IsFavorite=1 ORDER BY CreationDate DESC ;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //clsLogger.LogError(ex.Message, ex);
            }


            return dt;
        }


        static public int? AddNewAccount(string service, int accountTypeID, string? website,  string password, string notes,
            bool isFavorite, bool IsActive, string IV, string username, string email, string phone)
        {
            int? ID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @" INSERT INTO Accounts(Service, AccountTypeID, Website, EncryptedPassword, 
CreationDate, LastModificationDate, Notes, IsFavorite, IsActive, IV, username, EmailAddress, PhoneNumber) 
values (@service, @accounttypeID, @website, @password, 
@creationdate, @lastmodifiedDate, @notes, @isFavorite, @isActive, @IV, @username, @email, @phone)
                   Select SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("service", service);
                        command.Parameters.AddWithValue("accounttypeID", accountTypeID);

                        if (website == null)
                            command.Parameters.AddWithValue("website", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("website", website);


                        command.Parameters.AddWithValue("password", password);
                        command.Parameters.AddWithValue("creationdate", DateTime.Now);
                        command.Parameters.AddWithValue("lastmodifiedDate", DateTime.Now);
                        if (notes == null)
                            command.Parameters.AddWithValue("notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("notes", notes);

                        command.Parameters.AddWithValue("isFavorite", isFavorite);
                        command.Parameters.AddWithValue("isActive", IsActive);
                        command.Parameters.AddWithValue("IV", IV);
                        command.Parameters.AddWithValue("username", username);
                       
                        if (email == null)
                            command.Parameters.AddWithValue("email", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("email", email);

                        if (phone == null)
                            command.Parameters.AddWithValue("phone", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("phone", phone);



                        object number = command.ExecuteScalar();
                        if (number != null && int.TryParse(number.ToString(), out int PersonID))
                        {
                            ID = PersonID;
                        }


                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ID;
        }


        static public bool UpdateAccount(int ID, string service, int accountTypeID, string? website, string password, string notes, bool isFavorite, bool IsActive, string IV, string username, string email, string phone)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @"UPDATE Accounts SET 
                Service = @service,
                AccountTypeID = @accountTypeID,
                Website = @website,
                EncryptedPassword = @password,
                LastModificationDate = @lastModifiedDate,
                Notes = @notes,
                IsFavorite = @isFavorite,
                IsActive = @isActive,
                IV = @IV,
                Username = @username,
                EmailAddress = @email,
                PhoneNumber = @phone

                WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ID", ID);
                        command.Parameters.AddWithValue("service", service);
                        command.Parameters.AddWithValue("accountTypeID", accountTypeID);
                        if (website == null)
                            command.Parameters.AddWithValue("website", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("website", website);

                        command.Parameters.AddWithValue("password", password);
                        command.Parameters.AddWithValue("lastModifiedDate", DateTime.Now);
                        if (notes == null)
                            command.Parameters.AddWithValue("notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("notes", notes); 

                        command.Parameters.AddWithValue("isFavorite", isFavorite);
                        command.Parameters.AddWithValue("isActive", IsActive);
                        command.Parameters.AddWithValue("IV", IV);
                        command.Parameters.AddWithValue("username", username);

                        if (email == null)
                            command.Parameters.AddWithValue("email", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("email", email);

                        if (phone == null)
                            command.Parameters.AddWithValue("phone", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("phone", phone);



                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //clsLogger.LogError(ex.Message, ex);
            }
            return (RowsAffected > 0);
        }

        static public bool FindByID(int ID, ref string? service, ref int? accountTypeID, ref string? website, ref string? encryptedPassword,
    ref DateTime createdDate, ref DateTime lastModifiedDate, ref string? notes,
    ref bool isFavorite, ref bool isActive, ref string IV, ref string username, ref string email, ref string phone)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    string query = "SELECT * FROM Accounts WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("id", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                service = (string)reader["Service"];
                                accountTypeID = (int)reader["AccountTypeID"];
                                website = reader["Website"] as string;
                                encryptedPassword = (string)reader["EncryptedPassword"];
                                createdDate = (DateTime)reader["CreationDate"];
                                lastModifiedDate = (DateTime)reader["LastModificationDate"];
                                notes = reader["Notes"] as string;
                                isFavorite = (bool)reader["IsFavorite"];
                                isActive = (bool)reader["IsActive"];
                                IV = (string)reader["IV"];
                                username = (string)reader["username"];
                                email = reader["EmailAddress"] == DBNull.Value ? null : (string)reader["EmailAddress"];
                                phone = reader["PhoneNumber"] == DBNull.Value ? null : (string)reader["PhoneNumber"];

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


        static public void GetStatistics(ref int AllAccounts, ref int ActiveAccounts, ref int FavoriteAccounts, ref int categories)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @"SELECT (SELECT COUNT(*) FROM Accounts) AS TotalAccounts, 
(SELECT COUNT(*) FROM Accounts WHERE IsActive = 1) AS ActiveAccounts, (SELECT COUNT(*) FROM Accounts WHERE IsFavorite = 1) AS FavoriteAccounts, 
(SELECT COUNT(*) FROM AccountTypes) As Categories;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AllAccounts = (int)reader["TotalAccounts"];
                                ActiveAccounts = (int)reader["ActiveAccounts"];
                                FavoriteAccounts = (int)reader["FavoriteAccounts"];
                                categories = (int)reader["Categories"];

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //clsLogger.LogError(ex.Message, ex);
            }
        }

        static public bool Disactivate(int accountID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "Update Accounts Set IsActive=0 where  ID=@ID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ID", accountID);

                        RowsAffected = command.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {

            }

            return (RowsAffected > 0);
        }

        static public DataTable GetEncryptedPasswords()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = @" SELECT EncryptedPassword, IV from Accounts;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //clsLogger.LogError(ex.Message, ex);
            }


            return dt;
        }


    }
}

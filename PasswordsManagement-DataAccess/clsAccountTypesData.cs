using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PasswordsManagement_DataAccess
{
    public class clsAccountTypesData
    {
        static public DataTable GetAllAccountTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM AccountTypes";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        static public bool FindByID(int ?ID, ref string name)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM AccountTypes WHERE ID = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("id", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                name = (string)reader["Name"];
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

        static public bool Update(int ?ID, string name)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();
                    string query = "UPDATE AccountTypes SET Name = @name WHERE ID = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("name", name);
                        command.Parameters.AddWithValue("id", ID);
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return (RowsAffected > 0);
        }
    
}
}


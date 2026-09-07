using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PasswordsManagement_DataAccess
{
    public static class clsHistoryData
    {
        static public int AddNewHistory(string action, DateTime date, string service, int status, string username)
        {
            int ID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(@"
                INSERT INTO History 
                (Action, ActionDate, Service, Status, Username) 
                VALUES 
                (@action, @date, @service, @status, @username);
                SELECT SCOPE_IDENTITY();", connection))
                    {
                        command.Parameters.AddWithValue("@action", action);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@service", (object)service ?? DBNull.Value);
                        command.Parameters.AddWithValue("@status", status);
                        if (username == null)
                            command.Parameters.AddWithValue("@username", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@username", username);



                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return ID;
        }
        static public bool GetHistoryByID(
            int historyID,
            ref string action,
            ref DateTime date,
            ref string service,
            ref int status,
            ref string username)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM History WHERE ID = @id",
                        connection))
                    {
                        command.Parameters.AddWithValue("@id", historyID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                action = (string)reader["Action"];
                                date = (DateTime)reader["Date"];
                                service = (string)reader["Service"];
                                status = (int)reader["Status"];
                                username = reader["Username"]== DBNull.Value ? null: (string)reader["Username"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return IsFound;
        }

        static public DataTable GetAllHistory()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"
SELECT Action, ActionDate, Username, Service, 
CASE Status
WHEN 1 THEN 'Success'
WHEN 0 Then 'Fail'
END AS Status
From History
ORDER BY ActionDate DESC;

", connection))
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
            }

            return dt;
        }

        static public DataTable GetRecentHistory()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"
SELECT TOP 5 *
FROM
(
    SELECT 
        Action,
        ActionDate,
        Username,
        Service,
        CASE Status
            WHEN 1 THEN 'Success'
            WHEN 0 THEN 'Fail'
        END AS Status
    FROM History
) AS T1
ORDER BY ActionDate DESC;

", connection))
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
            }

            return dt;
        }


        static public bool DeleteHistory(int recordID)
        {
            int rows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(
                        @"DELETE FROM History WHERE ID = @id",
                        connection))
                    {
                        command.Parameters.AddWithValue("@id", recordID);

                        rows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return (rows > 0);
        }

        static public bool DeleteAllRecords()
        {
            int rows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(
                        @"DELETE FROM History",
                        connection))
                    {
                        rows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return (rows > 0);
        }

    }
}

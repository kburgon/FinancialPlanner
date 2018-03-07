using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;

namespace FinancialPlannerBack
{
    public class StorageManager
    {
        private static readonly string _connectionString = "Server=KEVINSUNG\\SQLEXPRESS";

        public DataTable GetResultsFromQuery(string query, List<SqlParameter> parameters, CommandType commandType)
        {
            var results = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                da.Fill(results);
                connection.Close();
            }
            return results;
        }

        public void ExecuteNonQuery(string query, List<SqlParameter> parameters, CommandType commandType)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void StoreUser(User user)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", SqlDbType.VarChar) {Value = user.Name},
                new SqlParameter("@Username", SqlDbType.VarChar) {Value = user.Username},
                new SqlParameter("@Password", SqlDbType.VarChar) {Value = user.Password},
                new SqlParameter("@TotalWorth", SqlDbType.Float) {Value = user.TotalWorth}
            };
            ExecuteNonQuery("FinanceTracker.dbo.UserCreate", parameters, CommandType.StoredProcedure);
        }
    }
}

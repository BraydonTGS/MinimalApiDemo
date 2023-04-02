using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MinimalApi.DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> LoadData<T>(string storedProcedure, object? parameters = null)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_connectionString);
                var result = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<bool> SaveData<T>(string storedProcedure, object? parameters = null)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_connectionString);
                var rowsAffected = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                if (rowsAffected == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

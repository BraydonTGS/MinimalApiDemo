﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MinimalApi.DataAccess.Models;
using System.Data;
using System.Data.SqlClient;

namespace MinimalApi.DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T>(string storedProcedure, object? parameters = null, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, object? parameters = null, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

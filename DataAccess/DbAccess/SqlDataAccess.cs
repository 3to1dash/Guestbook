using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<MessageModel>> LoadMessages<U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<MessageModel, UserModel, MessageModel>(
                storedProcedure,
                (msg, usr) =>
                {
                    msg.User = usr;
                    return msg;
                },
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ReplyModel>> LoadReplies<U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<ReplyModel, UserModel, ReplyModel>(
                storedProcedure,
                (rply, usr) =>
                {
                    rply.User = usr;
                    return rply;
                },
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

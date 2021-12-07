﻿using Dapper;
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

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MessageModel>> LoadMessage<U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<MessageModel>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
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
                splitOn: "UserId",
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
                splitOn: "UserId",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

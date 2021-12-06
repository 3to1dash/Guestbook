using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<MessageModel>> LoadMessages<U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<ReplyModel>> LoadReplies<U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}
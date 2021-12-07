using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<MessageModel>> LoadMessages<U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<MessageModel>> LoadMessage<U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<ReplyModel>> LoadReplies<U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
        Task<int> DeleteData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IMessageData
    {
        Task DeleteMessage(int id);
        Task<MessageModel> GetMessage(int id);
        Task<IEnumerable<MessageModel>> GetMessages();
        Task InsertMessage(MessageModel message, int userId);
        Task UpdateMessage(MessageModel message);
    }
}
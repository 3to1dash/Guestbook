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
        Task<MessageModel> GetMessageWithUser(int id);
        Task<IEnumerable<MessageModel>> GetTop15Messages();
        Task InsertMessage(string content, int userId);
        Task UpdateMessage(MessageModel message);
    }
}
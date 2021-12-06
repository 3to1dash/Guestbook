using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IReplyData
    {
        Task DeleteReply(int id);
        Task<IEnumerable<ReplyModel>> GetReplies(int id);
        Task InsertReply(ReplyModel reply, int userId);
    }
}
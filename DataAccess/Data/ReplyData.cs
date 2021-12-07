using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ReplyData : IReplyData
    {
        private readonly ISqlDataAccess _db;

        public ReplyData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<ReplyModel>> GetReplies(int id) =>
            _db.LoadReplies<dynamic>("dbo.spReply_GetAllByMessageId", new { MessageId = id });

        public Task InsertReply(string content, int messageId, int userId) =>
            _db.SaveData("spReply_Insert",
                new { Content = content, MessageId = messageId, UserId = userId });

        public Task DeleteReply(int id) =>
            _db.SaveData("dbo.spReply_Delete", new { Id = id });
    }
}

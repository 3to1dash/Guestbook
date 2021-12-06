using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MessageData : IMessageData
    {
        private readonly ISqlDataAccess _db;

        public MessageData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<MessageModel>> GetMessages() =>
            _db.LoadMessages<dynamic>("dbo.spMessage_GetAll", new { });

        public async Task<MessageModel> GetMessage(int id)
        {
            var results = await _db.LoadMessages<dynamic>(
                "dbo.spMessage_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertMessage(MessageModel message, int userId) =>
            _db.SaveData("spMessage_Insert",
                new { message.Content, UserId = userId });

        public Task UpdateMessage(MessageModel message) =>
            _db.SaveData("spMessage_Update",
                new { message.Id, message.Content });

        public Task DeleteMessage(int id) =>
            _db.SaveData("dbo.Message_Delete", new { Id = id });
    }
}

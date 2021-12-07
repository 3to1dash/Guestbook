using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public String Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserModel User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserModel User { get; set; }
    }
}

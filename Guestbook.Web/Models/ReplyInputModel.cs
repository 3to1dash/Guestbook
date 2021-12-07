using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guestbook.Web.Models
{
    public class ReplyInputModel
    {
        public string Content { get; set; }
        public int MessageId { get; set; }
    }
}

using DataAccess.Data;
using Guestbook.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Guestbook.Web.Controllers
{
    [Authorize]
    public class RepliesController : Controller
    {
        private readonly IReplyData _replyData;

        public RepliesController(IReplyData replyData)
        {
            _replyData = replyData;
        }

        public IActionResult Create(int MessageId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReplyInputModel input)
        {
            var currentUser = this.User;
            var currentUserId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _replyData.InsertReply(input.Content, input.MessageId, currentUserId);

            return RedirectToAction("Show", "Messages", 
                new { MessageId = input.MessageId });
        }

        public async Task<IActionResult> Delete(int ReplyId, int UserId, int MessageId)
        {
            var currentUser = this.User;
            var currentUserId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != UserId) return Unauthorized();

            await _replyData.DeleteReply(ReplyId);
            return RedirectToAction("Show", "Messages", new { MessageId });
        }
    }
}

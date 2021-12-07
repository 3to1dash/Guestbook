using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Guestbook.Web.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageData _messageData;
        private readonly IReplyData _replyData;

        public MessagesController(IMessageData messageData, IReplyData replyData)
        {
            _messageData = messageData;
            _replyData = replyData;
        }

        public async Task<IActionResult> Edit(int MessageId, int UserId)
        {
            var currentUser = this.User;
            var currentUserId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != UserId) return Unauthorized();

            var message = await _messageData.GetMessage(MessageId);
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MessageModel input)
        {
            var currentUser = this.User;
            var currentUserId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != input.User.UserId) return Unauthorized();

            await _messageData.UpdateMessage(input);
            return LocalRedirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Content)
        {
            var currentUser = this.User;
            var userId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _messageData.InsertMessage(Content, userId);
            return LocalRedirect("/");
        }

        public async Task<IActionResult> Show(int MessageId)
        {
            var message = await _messageData.GetMessageWithUser(MessageId);
            var replies = await _replyData.GetReplies(MessageId);
            dynamic mymodel = new ExpandoObject();
            mymodel.Message = message;
            mymodel.Replies = replies;
            return View(mymodel);
        }

        public async Task<IActionResult> Delete(int MessageId, int UserId)
        {
            var currentUser = this.User;
            var currentUserId = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != UserId) return Unauthorized();

            await _messageData.DeleteMessage(MessageId);
            return LocalRedirect("/");
        }
    }
}

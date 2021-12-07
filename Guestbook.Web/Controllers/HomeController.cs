using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Guestbook.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMessageData _messageData;

        public HomeController(IMessageData messageData)
        {
            _messageData = messageData;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageData.GetTop15Messages();
            return View(messages);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

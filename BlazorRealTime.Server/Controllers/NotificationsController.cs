using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRealTime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubcontext;
        public NotificationsController(IHubContext<NotificationHub> hubcontext)
        {
            _hubcontext = hubcontext;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string title)
        {
            await _hubcontext.Clients.All.SendAsync("notification", $"{DateTime.Now}: {title}");
            return Ok("Notification has been sent successfully!");
        }
    }
}

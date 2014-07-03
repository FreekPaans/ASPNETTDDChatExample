using MvcApplication9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication9.Controllers
{
    public class ChatController : Controller
    {
		static List<string> _messages =new List<string>();

        public ActionResult Start(ChatUser user, string message)
        {
			_messages.Add(message);

		    return View(new ChatRoomView { 
				Companyname = user.Companyname,
				Username = user.Username,
				Messages = _messages
			});
        }
    }
}

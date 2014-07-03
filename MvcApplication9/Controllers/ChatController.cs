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

        public ActionResult Start(ChatPackage package)
        {
            return View(package);
        }

    }
}

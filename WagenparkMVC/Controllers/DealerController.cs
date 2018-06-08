using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WagenparkMVC.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult DealerPage()
        {
            return View();
        }
    }
}
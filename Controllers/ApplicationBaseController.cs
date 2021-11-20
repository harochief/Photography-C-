using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity4Example.Controllers
{
    public class ApplicationBaseController : Controller
    {
        // GET: ApplicationBase
        public ActionResult Index()
        {
            return View();
        }
    }
}
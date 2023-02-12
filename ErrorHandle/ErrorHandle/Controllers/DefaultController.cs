using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErrorHandle.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //[HandleError(View="Error")]
        public ActionResult Index()
        {
            try {
            int x = 9;
            int d = 0;
            int f = x / 0;
            return View(f.ToString());
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
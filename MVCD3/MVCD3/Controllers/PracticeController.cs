using MVCD3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCD3.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
       
        public ActionResult DataAnnotation()
        {
            return View();
        }

       

        public ActionResult Helper()
        {
            return View();
        }

        public ActionResult Details(DataAnnotaion AB)
        {
            if (ModelState.IsValid)
            {
                return View(AB);
            }
            else
            {
                return View("DataAnnotation");
            }
        }

       
    }
}
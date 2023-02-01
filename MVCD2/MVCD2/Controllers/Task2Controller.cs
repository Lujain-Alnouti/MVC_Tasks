using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCD2.Controllers
{
    public class Task2Controller : Controller
    {
        // GET: Task2
        List<Models.Student> cor = new List<Models.Student>()
        {
            new Models.Student() { id=2,name="HTML",major="HTML",Faculity="XXX" },
            new Models.Student() { id=3,name="C#",major="C#",Faculity="YYY" },
            new Models.Student() { id=4,name="CSS",major="CSS",Faculity="OOO" },
            new Models.Student() { id=5,name="ASP.net",major="ASP.NEt",Faculity="NNN0" },
            };
        public ActionResult Student()
        {

            Session["cor"] = "Lujain Alnouti";
            //ViewBag.Personal = cor;
            return View(cor);
        }
       
    }
}
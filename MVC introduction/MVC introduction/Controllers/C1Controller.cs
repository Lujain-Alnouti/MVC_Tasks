using MVC_introduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_introduction.Controllers
{
    public class C1Controller : Controller
    {
        // GET: C1
        public ActionResult Index()
        {
            return View();
        }

        public string Sum()
        {
            int x = 9 + 9 + 9 + 9 + 9 + 9 + 9;
            return "<h3>Action 2 Task1 Part2</h3>The Sum = " + x + "<br/> <a href='https://localhost:44306/C1/Information'>Back </a>";
        }

        public string Information()
        {
            
            return "<h3>Action 1 Task1 Part2</h3>My Name Is Lujain Alnouti , 22 Years Ago " +
                "<br/> <a href='https://localhost:44306/C1/Sum'> Action 2 </a>"+
                "<br/> <a href='https://localhost:44306/C1/XXX'> Action 3</a>" +
                "<br/> <a href='https://localhost:44306/C1/YYY'> Action 4</a>" +
                "<br/> <a href='https://localhost:44306/Default/showImage'> Task 1 Part 1  4</a>";
        }

        public string XXX()
        {
            
            return "<h3>Action 3 Task1 Part2</h3> XXX" + "<br/> <a href='https://localhost:44306/C1/Information'>Back </a>";
        }

        public string YYY()
        {
           
            return "<h3>Action 4 Task1 Part2</h3> YYY" + "<br/> <a href='https://localhost:44306/C1/Information'>Back </a>";
        }


    }
}
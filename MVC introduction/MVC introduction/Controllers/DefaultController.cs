using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_introduction.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public string showImage()
        {
            return ("<a href='..\\Images\\Juc.png' download> <img src='..\\Images\\Juc.png'/></a> " +
                "<br/> <a href='https://localhost:44306/Default/AboutUS'> About Us</a><br/> <a href='https://localhost:44306/Default/Contact'> Contact</a>" +
                "<br/> <a href='https://localhost:44306/C1/Information'> Task1 Part 2</a>");
        }
        //public ActionResult DownLoadImage()
        //{
        //    var imagePath = Path.Combine(Server.MapPath("~/Images"), "Juc.png");
        //    return File(imagePath, "image/jpeg", "Juc.png");
        //    //string path = Server.MapPath("~/Images/Juc.png");
        //    //byte[] imageByteData = System.IO.File.ReadAllBytes(path);
        //    //return File(imageByteData, "image/png");

        //}

        public string AboutUS()
        {
            return "<h3>About Us Action</h3><h1> Hello,Welcome In About Us Page</h1> <p>This is task 1 in MVC tutorial</p><br> <a href='https://localhost:44306/Default/showImage'> Back</a>";
        }

        public string Contact()
        {
            return "<h3>Contact Action</h3><h1> Hello, Welcome In Contact Page</h1> <p>Phone Number is : 0780798564</p><br> <a href='https://localhost:44306/Default/showImage'> Back</a>";
        }
    }
}
using CentiSoftCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentiSoftMVCWebCourse3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CentiSoftCore.DAL.CentiSoftDBContext context = new CentiSoftCore.DAL.CentiSoftDBContext();
            Client firstClient = new Client();
            firstClient.Name = "First Client";
            firstClient.Token = "abcd1234";
            context.Clients.Add(firstClient);
            context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
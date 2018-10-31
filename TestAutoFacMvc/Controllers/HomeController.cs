using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAutoFacLib;
using TestAutoFacMvc.Models;

namespace TestAutoFacMvc.Controllers
{
    public class HomeController : Controller
    {
        //IOutput _output;
        IDateWriter _DateWriter;

        public HomeController(IDateWriter DateWriter)
        {
            _DateWriter = DateWriter;
        }

        public ActionResult Index()
        {
            _DateWriter.WriteDate();

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
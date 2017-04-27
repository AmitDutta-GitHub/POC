using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitySampleBL.Interfaces;

namespace UnityWebApiSample.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HomeController));
        public HomeController(IEmployee employee)
        {
            this.Lead = employee;
        }
        public IEmployee Employee { get; set; }
        public IEmployee Lead { get; set; }

        public ActionResult Index()
        {
            Logger.Info("Home.Index entered.");
            Employee.WhoCalledMe();
            return View();
        }
    }
}

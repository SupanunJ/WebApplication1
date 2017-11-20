using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisController : Controller
    {
        private linebotDBEntities db = new linebotDBEntities();
        private int sum = 0;
        // GET: Regis
        public ActionResult Index()
        {
            return View();
        }
    }
}
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
        //DB connection
        private linebotDBEntities db = new linebotDBEntities();
        // GET: Regis
        public ActionResult Index()
        {
            return View();
        }
    }
}
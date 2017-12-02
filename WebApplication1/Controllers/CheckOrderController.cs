using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class CheckOrderController : Controller
    {
        private linebotDBEntities db = new linebotDBEntities();
        // GET: CheckOrder
        [Route("{id}")]
        public ActionResult Check(string id)
        {
            ViewBag.query = db.order_list.Where(x => x.line_id == id).ToList();
            return View();
        }
    }
}
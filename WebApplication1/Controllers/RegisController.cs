using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class RegisController : Controller
    {
        //DB connection
        private linebotDBEntities db = new linebotDBEntities();
        //
        // GET: Regis
        [Route("{id}")]
        public ActionResult Index(string id)
        {
            ViewBag.idreturn = id;
            return View();
        }
        

        [HttpPost]
        public ActionResult LineRegister()
        {
            var c = new customer
            {
                line_id = Request.Form["u_id"],
                u_name = Request.Form["name"],
                u_lastname = Request.Form["lastname"],
                u_status = 0,
                u_tel = Request.Form["tel"],
                house_no = Request.Form["house_no"],
                village = Request.Form["village"],
                lane = Request.Form["lane"],
                road = Request.Form["road"],
                subarea = Request.Form["subarea"],
                area = Request.Form["area"],
                province = Request.Form["province"],
                postal_code = Request.Form["postal_code"],
                annotation = Request.Form["annotation"]
            };

            db.customers.Add(c);
            db.SaveChanges();
            return View();
        }
    }
}
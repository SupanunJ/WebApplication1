using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult ShopProduct()
        {
            linebotDBEntities _db = new linebotDBEntities();

            ViewBag.query = _db.products.ToList();
            return View("ShopProduct");
        }


    }
}
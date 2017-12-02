using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {

        linebotDBEntities db = new linebotDBEntities();

        // GET: Product
        [Route("{id}")]
        public ActionResult ShopProduct(string id)
        {
            ViewBag.idreturn = id;
            ViewBag.query = db.products.ToList();
            return View("ShopProduct");
        }

        [HttpPost]
        public ActionResult CalProduct(HttpPostedFileBase file)
        {

            DateTime dt;

            var productquery = db.products.ToList();
            int sum_price = 0;
            foreach(var listorder in productquery)
            {
                string text = listorder.p_id.ToString();
                
                if(Int32.Parse(Request.Form[text])<100)
                {
                    sum_price += Int32.Parse(Request.Form[text]) * listorder.retail_price;
                }
                else if (Int32.Parse(Request.Form[text])>=100 && Int32.Parse(Request.Form[text])<200)
                {
                    sum_price += Int32.Parse(Request.Form[text]) * listorder.wholesale_price;
                }
                else
                {
                    sum_price += Int32.Parse(Request.Form[text]) * listorder.agent_price;
                }
            }

            //เชคข้อมูลที่ส่งมา return Json(Request.Form["option_payment"]);
            string payment = Request.Form["option_payment"];
            if(payment=="0")
            {
                var set_order = new order_list
                {
                    o_date = DateTime.Now,
                    o_status = 1,
                    o_address = Request.Form["address"],
                    payment = 0,
                    image_slip = "เก็บเงินปลายทาง",
                    total_price = (short)sum_price,
                    line_id = Request.Form["u_id"]
                };
                db.order_list.Add(set_order);
                db.SaveChanges();

                foreach (var listorder in productquery)
                {
                    string text = listorder.p_id.ToString();
                    if (Int32.Parse(Request.Form[text]) > 0)
                    {
                        var set_ProductInOrder = new products_in_order
                        {
                            o_id = set_order.o_id,
                            p_id = listorder.p_id,
                            quantity = (short)Int32.Parse(Request.Form[text])
                        };
                        db.products_in_order.Add(set_ProductInOrder);
                        db.SaveChanges();
                    }
                }

                ViewBag.queryOrder = set_order;
                ViewBag.queryInOrder = db.products_in_order.Where(x => x.o_id == set_order.o_id);
                return View();
            }
            else
            {
                ///*string newName = file.FileName.ToString() + System.DateTime.Now.ToString("ddMMyyhhmmss");
                //Microsoft.VisualBasic.FileIO.RenameFile(file, newName);*/
                
                string pic = Path.GetFileName(file.FileName.ToString());
                string path = Path.Combine(Server.MapPath("" +
                    "~/Image"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

                dt = DateTime.Now;
                var set_order = new order_list
                {
                    o_date = dt,
                    o_status = 0,
                    o_address = Request.Form["address"],
                    payment = 1,
                    image_slip = pic,
                    total_price = (short)sum_price,
                    line_id = "U7240bc9d3c67ae4379728ea554f44284"
                };
                db.order_list.Add(set_order);
                db.SaveChanges();

                foreach (var listorder in productquery)
                {
                    string text = listorder.p_id.ToString();
                    if (Int32.Parse(Request.Form[text]) > 0)
                    {
                        var set_ProductInOrder = new products_in_order
                        {
                            o_id = set_order.o_id,
                            p_id = listorder.p_id,
                            quantity = (short)Int32.Parse(Request.Form[text])
                        };
                        db.products_in_order.Add(set_ProductInOrder);
                        db.SaveChanges();
                    }
                }

                ViewBag.queryOrder = set_order;
                ViewBag.queryInOrder = db.products_in_order.Where(x => x.o_id == set_order.o_id);
                return View();
            }
        }
    }
}
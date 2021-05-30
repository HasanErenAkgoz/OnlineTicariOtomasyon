using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using PagedList;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class SalesController : Controller
    {
        // GET: Sales
        Context context = new Context();
        public ActionResult Index()
        {

            var result = context.Sales.ToList();
            return View(result);
        }
   

        public ActionResult GetBySatısId(int id)

        {


            List<SelectListItem> personelName = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.personelName = personelName;

            List<SelectListItem> cariName = (from x in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.cariName = cariName;


            List<SelectListItem> productName = (from x in context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.productName = productName;



            var result = context.Sales.Find(id);

            return View("GetBySatısId", result);

        }
        public ActionResult Update(Sales sales)
        {

            var result = context.Sales.Find(sales.Id);
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            result.PersonelId = sales.PersonelId;
            result.CariId = sales.CariId;
            result.ProductId = sales.ProductId;
            result.Price = sales.Price;
            result.TotalProduct = sales.TotalProduct;
            result.TotalPrice = sales.TotalPrice;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var result = context.Sales.Where(sales => sales.Id == id).ToList();
            return View(result);
        }

    }
}
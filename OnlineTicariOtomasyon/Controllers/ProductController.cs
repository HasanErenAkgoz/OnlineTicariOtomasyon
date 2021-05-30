using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index(string P)
        {
            var result = from urun in context.Products select urun;
            if (!string.IsNullOrEmpty(P))
            {
                result = result.Where(y => y.Name.Contains(P)||y.Brand.Contains(P));
            }
            return View(result.Where(product=>product.Status==true).ToList()) ;
        }
        public ActionResult ProductDetail(int id)
        {
            var result = context.Products.Where(product => product.Id == id).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> result = (from product in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = product.Name,
                                               Value = product.Id.ToString()
                                           }).ToList();
            ViewBag.value = result;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {

            using (var context = new Context())
            {
                if (Request.Files.Count > 0)
                {
                    string imgName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string ulr = "~/image/" + imgName + Extension;
                    Request.Files[0].SaveAs(Server.MapPath(ulr));
                    product.ProductImage = "/image/" + imgName + Extension;

                }
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            using (var context = new Context())
            {
                var result = context.Products.Find(Id);
                result.Status = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetByProductId(int Id)
        {
            Context context = new Context();
            List<SelectListItem> category = (from product in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = product.Name,
                                               Value = product.Id.ToString()
                                           }).ToList();
            ViewBag.value = category;
            var result = context.Products.Find(Id);
            return View("GetByProductId", result);

        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            using (var context = new Context())
            {
                if (Request.Files.Count > 0)
                {
                    string imgName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string ulr = "~/image/" + imgName + Extension;
                    Request.Files[0].SaveAs(Server.MapPath(ulr));
                    product.ProductImage = "/image/" + imgName + Extension;

                }
                var result = context.Products.Find(product.Id);
                result.Name = product.Name;
                result.Brand = product.Brand;
                result.Stock = product.Stock;
                result.PurchasePrice = product.PurchasePrice;
                result.SalesPrice = product.SalesPrice;
                result.ProductImage = product.ProductImage;
                result.Status = true;
                result.CategoryId = product.CategoryId;
                result.Explanation = product.Explanation;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult ProductIdList(int id)
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


            List<SelectListItem> productName = (from x in context.Products.Where(product => product.Id == id).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()

                                                }).ToList();
            ViewBag.productName = productName;


            var result = context.Sales.Find(id);
            var productPrice = context.Products.Find(id);
            ViewBag.productPrice =Convert.ToInt32(productPrice.SalesPrice);
            return View("ProductIdList", result);
        }
        [HttpPost]
        public ActionResult ProductIdList(Sales sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.Sales.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
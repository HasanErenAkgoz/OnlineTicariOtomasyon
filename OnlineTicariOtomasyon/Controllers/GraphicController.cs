using OnlineTicariOtomasyon.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Index3()
        {

            return View();
        }
        public ActionResult LineIndex()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<ProductGraphic> ProductList2()
        {
            List<ProductGraphic> snf = new List<ProductGraphic>();
            using (var context=new Context())
            {
                snf = context.Products.Select(product => new ProductGraphic {
                    Name = product.Name,
                    Stock = product.Stock
                }).ToList ();
            }
            return snf;
        }
        public List<ProductGraphic> ProductList()
        {
            List<ProductGraphic> snf = new List<ProductGraphic>();
            using (var context = new Context())
            {
                snf = context.Categories.Select(sales => new ProductGraphic
                {
                    Name = sales.Name,
                    Stock = sales.Products.Count()
                }).ToList();
            }
            return snf;
        }
    }
   

}
using OnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var totalCari = context.Caris.Count().ToString();
            ViewBag.totalCari = totalCari;

            var totalProduct = context.Products.Count().ToString();
            ViewBag.totalProduct = totalProduct;

            var totalPersonel = context.Personels.Count().ToString();
            ViewBag.totalPersonel = totalPersonel;

            var totalCategory = context.Categories.Count().ToString();
            ViewBag.totalCategory = totalCategory;

            var totalDepartmen = context.Departments.Count().ToString();
            ViewBag.totalDepartmen = totalDepartmen;

            var totalStock = context.Products.Sum(product => product.Stock).ToString();
            ViewBag.totalStock = totalStock;

            var criticalStock = context.Products.Count(product => product.Stock <= 5).ToString();
            ViewBag.criticalStock = criticalStock;

            var totalBrand = (from product in context.Products select product.Brand).Distinct().Count().ToString();
            ViewBag.totalBrand = totalBrand;

            var maxProductPrice = (from product in context.Products orderby product.SalesPrice descending select product.Name).FirstOrDefault();
            ViewBag.maxProductPrice = maxProductPrice;

            var minProductPrice = (from product in context.Products orderby product.SalesPrice ascending select product.Name).FirstOrDefault();
            ViewBag.minProductPrice = minProductPrice;

            var totalMony = context.Sales.Sum(sales => sales.TotalPrice).ToString();
            ViewBag.totalMony = totalMony;

            DateTime Today = DateTime.Today;
            var dailySale = context.Sales.Count(sales => sales.Date ==Today).ToString();
            ViewBag.dailySale = dailySale;


            var todaySale = context.Sales.Where(sales => sales.Date == Today).Sum(y =>(decimal?) y.TotalPrice).ToString();
            ViewBag.todaySale = todaySale;

            

            var maxBrand = context.Products.GroupBy(produt=>produt.Brand).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.maxBrand = maxBrand;

            var bestPersonel = context.Personels.Where(personel => personel.Id == (context.Sales.GroupBy(sales => sales.PersonelId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.Name).FirstOrDefault() ;
            ViewBag.bestPersonel=bestPersonel;


            var bestProduct = context.Products.Where(product => product.Id == (context.Sales.GroupBy(sales => sales.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.Name).FirstOrDefault();
            ViewBag.bestProduct = bestProduct;
            return View();
        }
        public ActionResult SimplesTable()
        {
            var result = from x in context.Caris
                         group x by x.City
                       into g
                         select new SinifGrup
                         {
                             City = g.Key,
                             Toplam = g.Count()
                         };
            return View(result.ToList());
        }
        public PartialViewResult Partial1()
        {
            var result = from x in context.Personels
                         group x by x.Department.Name into g select new SinifGrup2
                         {
                             Departmen = g.Key,
                             Number = g.Count()
                        
                       };
            return PartialView(result.ToList());
        }

        public PartialViewResult PartialBrand()
        {
            var result = from x in context.Products
                         group x by x.Brand into g
                         select new Group3
                         {
                             Name = g.Key,
                             Number = g.Count()
                         };
            return PartialView(result.ToList()); ;
        }
        public PartialViewResult PartialProduct()
        {
            var result = context.Products.ToList();
            return PartialView(result) ;
        }
    }
}
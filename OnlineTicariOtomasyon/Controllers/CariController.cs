using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();

        public ActionResult Index()
        {
            var result = context.Caris.Where(cari=>cari.Status==true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Cari cari)
        {
            
                cari.Status = true;
                context.Caris.Add(cari);
                context.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult Delete(int id)
        {
            var result = context.Caris.Find(id);
            result.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GeyByCariId(int id)
        {
            var result = context.Caris.Find(id);
            return View("GeyByCariId", result);
        }
        public ActionResult Update(Cari cari)
        {
            var result = context.Caris.Find(cari.Id);
            result.Name = cari.Name;
            result.Surname = cari.Surname;
            result.City = cari.City;
            result.Email = cari.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSales(int id)
        {
            var result = context.Sales.Where(sales => sales.CariId == id).ToList();
            var cr = context.Caris.Where(cari => cari.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(result);
        }
    }
}
using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class CargoController : Controller
    {
        // GET: Cargo

        public ActionResult Index(string p)
        {
            using (var context=new Context())
            {


                Random random = new Random();
                string[] Code = { "A", "B", "C", "D", "E", "F", "G" };
                int value1, value2, value3;
                value1 = random.Next(0, 7);
                value2 = random.Next(0, 7);
                value3 = random.Next(0, 7);
                int sayı1, sayı2, sayı3;
                sayı1 = random.Next(100, 1000);
                sayı2 = random.Next(10, 99);
                sayı3 = random.Next(10, 99);
                string trackigCode = sayı1.ToString() + Code[value1] + sayı2 + Code[value2] + sayı3 + Code[value3];
                ViewBag.trackingCode = trackigCode.ToString();
                var cargo = from x in context.Cargos select x;
                if (!string.IsNullOrEmpty(p))
                {
                    cargo = cargo.Where(y => y.TrackingCode.Contains(p)); 
                }
                return View(cargo.ToList());

            }
        }
        [HttpGet]
        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(Cargo cargo)
        {
            using (var context = new Context())
            {
                context.Cargos.Add(cargo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult CargoTracking(string id)
        {
            Context context = new Context();
            var result = context.CargoTrackings.Where(personel => personel.TrackingCode == id).ToList();
          
            return View(result);
        }
    }
}
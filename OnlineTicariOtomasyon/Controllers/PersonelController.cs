using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class PersonelController : Controller
    {

        // GET: Personel
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Personels.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> department = (from departmen in context.Departments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = departmen.Name,
                                                   Value = departmen.Id.ToString()
                                               }).ToList();
            ViewBag.value = department;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Personel personel)
        {
            if (Request.Files.Count>0)
            {
                string imgName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string ulr = "~/image/" + imgName + Extension;
                Request.Files[0].SaveAs(Server.MapPath(ulr));
                personel.PersonelImagePath = "/image/" + imgName + Extension;

            }
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = context.Personels.Find(id);
            context.Personels.Remove(result);
            return RedirectToAction("Index");
        }
        public ActionResult GeyByPersonelId(int id)
        {
            List<SelectListItem> department = (from departmen in context.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = departmen.Name,
                                                 Value = departmen.Id.ToString()
                                             }).ToList();
            ViewBag.value = department;
            var result = context.Personels.Find(id);
            return View("GeyByPersonelId", result);
        }
        public ActionResult Update(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string imgName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string ulr = "~/image/" + imgName + Extension;
                Request.Files[0].SaveAs(Server.MapPath(ulr));
                personel.PersonelImagePath = "/image/" + imgName + Extension;

            }
            var result = context.Personels.Find(personel.Id);
            result.TcKimlik = personel.TcKimlik;
            result.Name = personel.Name;
            result.Surname = personel.Surname;
            result.PersonelImagePath = personel.PersonelImagePath;
            result.DepartmentId = personel.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSales(int id)
        {
            var result = context.Sales.Where(sales => sales.PersonelId == id).ToList();
            var cr = context.Personels.Where(personel => personel.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(result);
        }
    }
}
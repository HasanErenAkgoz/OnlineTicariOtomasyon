using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class InvoicesController : Controller
    {
        // GET: Invoices
        Context context = new Context();
        public ActionResult Index()
        {
            InvoiceOperation ınvoiceOperation = new InvoiceOperation();
            ınvoiceOperation.Value = context.Invoices.ToList();
            ınvoiceOperation.Value2 = context.InvoicesItems.ToList();
            return View(ınvoiceOperation);
        }
        public ActionResult Delete(int id)
        {
            var result = context.Invoices.Find(id);
            context.Invoices.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult Add()
        {
            List<SelectListItem> Personel = (from personel in context.Personels.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = personel.Name,
                                                   Value = personel.Id.ToString()
                                               }).ToList();
            ViewBag.personel = Personel;
            List<SelectListItem> Cari = (from cari in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = cari.Name,
                                                 Value = cari.Id.ToString()
                                             }).ToList();
            ViewBag.cari = Cari;
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(Invoice ınvoice)
        {
            context.Invoices.Add(ınvoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GtByInvoices(int id)
        {
            List<SelectListItem> Personel = (from personel in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = personel.Name,
                                                 Value = personel.Id.ToString()
                                             }).ToList();
            ViewBag.personel = Personel;
            List<SelectListItem> Cari = (from cari in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = cari.Name,
                                             Value = cari.Id.ToString()
                                         }).ToList();
            ViewBag.cari = Cari;

            var result = context.Personels.Find(id);
            return View("GeyByPersonelId", result);
        }
        public ActionResult Update(Invoice ınvoice)
        {
            var result = context.Invoices.Find(ınvoice.Id);
            result.InvoiceNo = ınvoice.InvoiceNo;
            result.DateTime = ınvoice.DateTime;
            result.TaxAdministration = ınvoice.TaxAdministration;
            result.PersonelId = ınvoice.PersonelId;
            result.CariId = ınvoice.CariId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult InvoicesDetail()
        {
            List<SelectListItem> Personel = (from personel in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = personel.Name,
                                                 Value = personel.Id.ToString()
                                             }).ToList();
            ViewBag.personel = Personel;
            List<SelectListItem> Cari = (from cari in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = cari.Name,
                                             Value = cari.Id.ToString()
                                         }).ToList();
            ViewBag.cari = Cari;
            return PartialView();
        }
    }
}
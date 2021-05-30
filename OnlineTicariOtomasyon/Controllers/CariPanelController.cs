using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class CariPanelController : Controller
    {
        // GET: CariPanel

        Context context = new Context();
        public ActionResult Index()
        {
            Sales sales1 = new Sales();
            var result = (string)Session["Email"];
            var value = context.Messages.Where(cari => cari.Alıcı == result).ToList();
            ViewBag.email = result;

            var mailId = context.Caris.Where(cari => cari.Email == result).Select(y => y.Id).FirstOrDefault();
            ViewBag.mailId = mailId;

            var totalSales = context.Sales.Where(sales => sales.CariId == mailId).Count();
            ViewBag.totalSales = totalSales;

            
                var totalPrice = context.Sales.Where(sales => sales.CariId == mailId).Sum(y => (decimal?)y.TotalPrice);
                ViewBag.totalPrice = totalPrice;
                var totalProduct = context.Sales.Where(sales => sales.CariId == mailId).Sum(y => (decimal?)y.TotalProduct);
                ViewBag.totalProduct = totalProduct;
            
           

            var nameSurname = context.Caris.Where(cari => cari.Email == result).Select(y=>y.Name+" "+y.Surname).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;

            var City = context.Caris.Where(cari => cari.Email == result).Select(y => y.City).FirstOrDefault();
            ViewBag.City = City;
            return View(value);
        }
        public ActionResult MyOrders()
        {
            var email = (string)Session["Email"];
            var ıd = context.Caris.Where(cari => cari.Email == email.ToString()).Select(c => c.Id).FirstOrDefault();
            var value = context.Sales.Where(sales => sales.CariId == ıd).ToList();
            return View(value);
        }
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["Email"];
            var messages = context.Messages.Where(message => message.Alıcı == mail).OrderByDescending(x => x.Id).ToList();
            var messageCount = context.Messages.Count(message => message.Alıcı == mail).ToString();
            ViewBag.messageCount = messageCount;
            var OutgoingMessages = context.Messages.Count(message => message.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            return View(messages);
        }
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["Email"];
            var messages = context.Messages.Where(message => message.Gonderici == mail).OrderByDescending(x => x.Id).ToList();
            var OutgoingMessages = context.Messages.Count(message => message.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = context.Messages.Count(message => message.Alıcı == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(messages);
        }


        [HttpGet]
        public ActionResult NewMessages()
        {
            var mail = (string)Session["Email"];
            var OutgoingMessages = context.Messages.Count(message => message.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = context.Messages.Count(message => message.Alıcı == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages messages)
        {
            var mail = (string)Session["Email"];
            messages.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            messages.Gonderici = mail;
            context.Messages.Add(messages);
            context.SaveChanges();
            return View();
        }
        public ActionResult MessageDetail(int id)
        {
            var value = context.Messages.Where(messages => messages.Id == id).ToList();
            var mail = (string)Session["Email"];
            var OutgoingMessages = context.Messages.Count(message => message.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = context.Messages.Count(message => message.Alıcı == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(value);
        }
        public ActionResult MessageDetail2(int id)
        {
            var value = context.Messages.Where(messages => messages.Id == id).ToList();
            var mail = (string)Session["Email"];
            var OutgoingMessages = context.Messages.Count(message => message.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = context.Messages.Count(message => message.Alıcı == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(value);
        }
        public ActionResult TrackingCargo(string p)
        {
            var cargo = from x in context.Cargos select x;
            cargo = cargo.Where(y => y.TrackingCode.Contains(p));
            return View(cargo.ToList());
        }
        public ActionResult CargoDetails(string id)
        {
            Context context = new Context();
            var result = context.CargoTrackings.Where(personel => personel.TrackingCode == id).ToList();

            return View(result);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Settings()
        {
            var mail = (string)Session["Email"];
            var id = context.Caris.Where(cari => cari.Email == mail).Select(x => x.Id).FirstOrDefault();
            var cariSearch = context.Caris.Find(id);
            return PartialView("Settings", cariSearch);

        }
        public PartialViewResult Announs()
        {
            var value = context.Messages.Where(messages => messages.Gonderici == "admin").ToList();
            return PartialView(value);
        }
        public ActionResult Update(Cari cari)
        {
            var value = context.Caris.Find(cari.Id);
            value.Name = cari.Name;
            value.Surname = cari.Surname;
            value.Password = cari.Password;
            value.City = cari.City;
            value.Email = cari.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
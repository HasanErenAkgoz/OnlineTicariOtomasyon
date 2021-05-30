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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Add(Cari cari)
        {
            using (var context=new Context())
            {
                context.Caris.Add(cari);
                context.SaveChanges();
                return PartialView();
            }

        }
        [HttpGet]
        public ActionResult CariLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin(Cari cari)
        {

            using (var context = new Context())
            {
                var result = context.Caris.FirstOrDefault(caris => caris.Email == cari.Email && caris.Password == cari.Password);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.Email, false);
                    Session["Email"] = result.Email.ToString();
                    return RedirectToAction("Index", "CariPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }

            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            using (var context=new Context())
            {
                var result = context.Admins.FirstOrDefault((admins => admins.Email == admin.Email && admins.Password
                == admin.Password));
                if (result!=null)
                {
                    FormsAuthentication.SetAuthCookie(result.Email, false);
                    Session["Email"] = result.Email.ToString();
                    return RedirectToAction("Index","Product");
                }
                else
                    return RedirectToAction("Index","Login");

            }

        }

    }
}
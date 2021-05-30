using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (var context = new Context())
            {
                var result = context.Categories.ToList();
                return View(result);

            }
        }
        [Authorize(Roles = "yönetici")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "yönetici")]

        public ActionResult Add(Category category)
        {
            using (var context = new Context())
            {

                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
                    
            }
        }
        public ActionResult Delete(int Id)
        {
            using (var context = new Context())
            {
                var reuslt = context.Categories.Find(Id);
                context.Categories.Remove(reuslt);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetByCategoryId(int Id)
        {
            Context context = new Context();
            var result = context.Categories.Find(Id);
            return View("GetByCategoryId", result);


        } 
        public ActionResult Update(Category category)
        {
            using (var context = new Context())
            {
                var result = context.Categories.Find(category.Id);
                result.Name = category.Name;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    
    }
}
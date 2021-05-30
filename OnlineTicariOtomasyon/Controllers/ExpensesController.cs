 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Entity;
using OnlineTicariOtomasyon.Models;
namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class ExpensesController : Controller
    {

        // GET: Expenses
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Expenses.ToList();
            return View(result);
        }
      
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Expenses expenses)
        {
            using (var context = new Context())
            {
                expenses.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                context.Expenses.Add(expenses);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            using (var context = new Context())
            {
                var reuslt = context.Expenses.Find(Id);
                context.Expenses.Remove(reuslt);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetByExpensesId(int Id)
        {
            Context context = new Context();
            var result = context.Expenses.Find(Id);
            return View("GetByExpensesId", result);


        }
        public ActionResult Update(Expenses expenses)
        {
            using (var context = new Context())
            {
                var result = context.Expenses.Find(expenses.Id);
                result.Explanation = expenses.Explanation;
                result.Date = expenses.Date;
                result.Price = expenses.Price;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
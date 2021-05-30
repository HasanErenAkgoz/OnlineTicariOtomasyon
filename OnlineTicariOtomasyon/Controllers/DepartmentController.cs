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

    public class DepartmentController : Controller
    {

        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Departments.Where(department => department.Status == true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department Department)
        {
            using (var context = new Context())
            {
                context.Departments.Add(Department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            using (var context = new Context())
            {
                var result = context.Departments.Find(Id);
                result.Status = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetByDepartmentId(int Id)
        {
            Context context = new Context();
            var result = context.Departments.Find(Id);
            return View("GetByDepartmentId", result);


        }
        public ActionResult Update(Department department)
        {
            using (var context = new Context())
            {
                var result = context.Departments.Find(department.Id);
                result.Name = department.Name;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult DepartmentDetails(int id)
        {
            Context context = new Context();
            var result = context.Personels.Where(personel => personel.DepartmentId == id).ToList();
            var department = context.Departments.Where(departmentName => departmentName.Id == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.dpt = department;
                return View(result);
        }
        public ActionResult DepartmentPersonelSales(int id)
        {
            var result = context.Sales.Where(personel => personel.PersonelId == id).ToList();
            var name = context.Personels.Where(personel => personel.Id == id).Select(personel1 => personel1.Name + " " + personel1.Surname).FirstOrDefault();
            ViewBag.personelName = name;
            return View(result);


            
        }

    }
}
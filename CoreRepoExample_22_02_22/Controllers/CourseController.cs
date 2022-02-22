using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository rep;
        public CourseController(ICourseRepository _rep)
        {
            rep = _rep;
        }

        //public IActionResult Index()
        //{
        //    var courses = rep.GetCoursesSit(true);

        //    return View(courses);
        //}


        public IActionResult Index(string name = null, decimal? price = null, string sit = null)
        {
            var courses = rep.GetCoursesFiltre(name, price, sit);
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.Sit = sit == "on" ? true : false;
            return View(courses);
        }

        public IActionResult Guncelle(int id)
        {
          
                ViewBag.Actionmode = "Guncelle";
                return View(rep.GetById(id));

           
        }
        [HttpPost]
        public IActionResult Guncelle(Course entity)
        {
            rep.UpdateCourse(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            ViewBag.Actionmode = "Ekle";
            return View("Guncelle",new Course());
        }


        [HttpPost]
        public IActionResult Ekle(Course entity)
        {
            rep.CreateCourse(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            rep.CourseDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            ;
            return View(rep.GetById(id));
        }

    }
}
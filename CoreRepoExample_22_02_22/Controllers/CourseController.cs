using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models;
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
        private IEgitmenRepository erep;
        CourseModel cm = new CourseModel();
        public CourseController(ICourseRepository _rep, IEgitmenRepository erep = null)
        {
            rep = _rep;
            this.erep = erep;
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
            cm.Course = rep.GetById(id);
            cm.eList = erep.GetEgitmenAll().ToList();
            List<Course> test = rep.GetCourses().ToList();
            foreach (var item in test)
            {
                if (item.EgitmenID != null)
                {
                    foreach (var item2 in cm.eList)
                    {                       
                         if (item.EgitmenID == item2.EgitmenID)
                        {
                            if (cm.Course.EgitmenID == item2.EgitmenID)
                            {
                                break;
                            }
                            else
                            {
                                cm.eList.Remove(item2);
                                break;
                            }                           
                        }
                    }
                }
            }

            return View(cm);           
        }
        [HttpPost]
        public IActionResult Guncelle(int id, CourseModel entity)
        {
            ViewBag.Actionmode = "Guncelle";
            rep.UpdateCourse(id,entity.Course);            
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            cm.eList = erep.GetTeacher().ToList();
            List<Course> test = rep.GetCourses().ToList();
            foreach (var item in test)
            {
                if (item.EgitmenID != null)
                {
                    foreach (var item2 in cm.eList)
                    {
                        if (item.EgitmenID==item2.EgitmenID)
                        {
                            cm.eList.Remove(item2);
                            break;
                        }
                    }
                }
            }
            ViewBag.Actionmode = "Ekle";
            return View("Guncelle", cm);
        }


        [HttpPost]
        public IActionResult Ekle(CourseModel entity)
        {            
            rep.CreateCourse(entity.Course);
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            rep.CourseDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            cm.Course = rep.GetById(id);
           cm.Egitmen = erep.GetEgitmenAll().FirstOrDefault(x => x.EgitmenID == cm.Course.EgitmenID);
            return View(cm);
        }
    }
}
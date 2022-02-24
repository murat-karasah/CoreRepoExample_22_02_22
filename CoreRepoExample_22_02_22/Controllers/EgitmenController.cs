using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers
{
    public class EgitmenController : Controller
    {
        EgitmenModel em = new EgitmenModel();
        private IEgitmenRepository erep;
        public EgitmenController(IEgitmenRepository _erep)
        {
            erep = _erep;
        }
        private ICourseRepository crep;       
        public IActionResult Index()
        {
            em.eList = erep.GetEgitmenAll()
                .Include(a => a.Adres).ToList();               
            return View(em);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(EgitmenModel entity)
        {
            erep.CreateEgitmen(entity.Egitmen);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            em.Egitmen = erep.GetById(id);            
            return View(em);
        }

        [HttpPost]
        public IActionResult Edit(int id,EgitmenModel entity)
        {
            erep.UpdateEgitmen(id,entity.Egitmen);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            erep.EgitmenDel(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            em.Egitmen = erep.GetById(id);
            return View(em);
        }
    }
}
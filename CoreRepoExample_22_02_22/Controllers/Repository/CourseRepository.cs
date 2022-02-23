using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private DataContext db;
        public CourseRepository(DataContext _db)
        {
            db = _db;

        }

        public void CourseDelete(int id)
        {
            if (id!=null)
            {
                var c = GetById(id);
                db.Courses.Remove(c);
                db.SaveChanges();

            }
        }

        public void CreateCourse(Course entity)
        {
           
            if (entity.ID == 0)
            {
             
            db.Add(entity);
            db.SaveChanges();
            }
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        public IQueryable<Course> GetCoursesAll()
        {
            return db.Courses.AsQueryable();
        }

        public IEnumerable<Course> GetCoursesFiltre(string name = null, decimal? price = null, string sit = null)
        {
            IQueryable<Course> query = db.Courses;
            if (name!=null)
            {
                query = query.Where(i => i.Ad.Contains(name));
            }
            if (price!=null)
            {
                query = query.Where(i => i.Fiyat >= price);
            }
            if (sit=="on")
            {
                query = query.Where(i => i.Aktif == true);
            }
            query = query.Include(i => i.Egitmen);
            return (query.ToList());
        }

        public IEnumerable<Course> GetCoursesSit(bool sit)
        {
            return db.Courses.AsQueryable().Where(x=>x.Aktif== sit);
        }

        public void UpdateCourse(int id,Course entity)
        {
            var c = GetById(id);
            if (c!=null)
            {
                c.Ad = entity.Ad;
                c.Aciklama = entity.Aciklama;
                c.Aktif = entity.Aktif;
                c.Fiyat = entity.Fiyat;
                c.EgitmenID = entity.EgitmenID;
                db.SaveChanges();
            }
            
           
        }
    }
}

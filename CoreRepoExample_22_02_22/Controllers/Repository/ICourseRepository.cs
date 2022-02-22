using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
  public  interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesSit(bool sit);
        IEnumerable<Course> GetCoursesFiltre(string name = null, decimal? price = null, string sit = null);

        void UpdateCourse(Course entity);
        void CreateCourse(Course entity);
        void CourseDelete(int id);
        Course GetById(int id);
        IQueryable<Course> GetCoursesAll();
    }
}

using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Models
{
    public class CourseModel
    {

        public List<Egitmen> eList { get; set; }
        public IList<Adres> aList { get; set; }
        public IList<Course> cList { get; set; }
        public Egitmen Egitmen { get; set; }

        public ICollection<Course> Courses{ get; set; }
        public Course Course { get; set; }

    }
}

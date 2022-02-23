using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Models
{
    public class EgitmenModel
    {
       public IList<Egitmen> eList { get; set; }
        public IList<Adres> aList { get; set; }
        public IList<Course> cList { get; set; }

        public Adres Adres{ get; set; }

        public Egitmen Egitmen { get; set; }
        public IEnumerable<Egitmen> Egitmens { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Models.Entity
{
    public class Egitmen
    {
        public int EgitmenID { get; set; }
        public string isim{ get; set; }
        public string Soyisim{ get; set; }
        public Course Course{ get; set; }
        public Adres Adres{ get; set; }

    }
}

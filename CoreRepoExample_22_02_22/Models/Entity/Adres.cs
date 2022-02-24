using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Models.Entity
{
    public class Adres
    {
        public int  AdresId{ get; set; }
        [DisplayName("Şehir")]
        public string  sehir{ get; set; }
        public string  ulke{ get; set; }
    }
}

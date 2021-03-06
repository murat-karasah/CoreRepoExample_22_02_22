using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRepoExample_22_02_22.Models.Entity
{
    public class Course
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public bool Aktif { get; set; }
        [ForeignKey("Egitmen")]
        public int EgitmenID { get; set; }
        public Egitmen Egitmen{ get; set; }
        
        
    }
}

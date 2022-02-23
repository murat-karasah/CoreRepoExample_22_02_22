using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class EgitmenRepository : IEgitmenRepository
    {
        private DataContext db;
        public EgitmenRepository(DataContext _db)
        {
            db = _db;

        }
        public void EgitmenDel(int id)
        {
            
            var c = GetById(id);
            int adresId = c.Adres.AdresId;
            db.Egitmen.Remove(c);
            db.SaveChanges();

            db.Database.ExecuteSqlInterpolated($"Exec delete_adres @AdresId={adresId}");

                db.SaveChanges();
            
        }

        public void CreateEgitmen(Egitmen entity)
        {

            if (entity.EgitmenID == 0)
            {

                db.Add(entity);
                db.SaveChanges();
            }
        }

        public Egitmen GetById(int id)
        {
            IQueryable<Egitmen> query = db.Egitmen.Include(x => x.Adres) ;
             query.FirstOrDefault(x => x.EgitmenID == id);

            return query.FirstOrDefault(x => x.EgitmenID == id);
        }

        public IEnumerable<Egitmen> GetTeacher()
        {
            
            return db.Egitmen.ToList();
        }

        public void UpdateEgitmen(int id,Egitmen entity)
        {
            var c = GetById(id);
            if (c != null)
            {
                c.isim = entity.isim;
                c.Soyisim = entity.Soyisim;
                c.Adres.sehir = entity.Adres.sehir;
                c.Adres.ulke = entity.Adres.ulke;
              
                db.SaveChanges();
            }
        }

        public IQueryable<Egitmen> GetEgitmenAll()
        {
            return db.Egitmen.AsQueryable();
        }
    }
}
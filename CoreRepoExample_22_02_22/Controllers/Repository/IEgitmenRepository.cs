using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
   public interface IEgitmenRepository
    {
        IEnumerable<Egitmen> GetTeacher();

        void UpdateEgitmen(int id,Egitmen entity);
        void CreateEgitmen(Egitmen entity);
        void EgitmenDel(int id);
        Egitmen GetById(int id);
        IQueryable<Egitmen> GetEgitmenAll();

    }
}

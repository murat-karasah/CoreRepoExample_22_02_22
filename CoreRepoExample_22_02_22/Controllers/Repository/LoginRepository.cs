using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private DataContext db;
        public LoginRepository(DataContext _db)
        {
            db = _db;
        }

        public Admin GetAdmin(string username, string pass)
        {
            return db.Admin.FirstOrDefault(x => x.username == username && x.pass == pass) ;
        }
    }
}

using CoreRepoExample_22_02_22.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public interface ILoginRepository
    {
        Admin GetAdmin(string username,string pass);

    }
}

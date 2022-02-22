using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Models.Data
{
    public class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context is DataContext)
                {
                    DataContext _context = context as DataContext;
                    if (_context.Courses.Count()==0)
                    {
                        _context.Courses.AddRange(Courses);
                        
                    }
                }
                context.SaveChanges();
            }
        }

        private static Course[] Courses =
        {
            new Course()
            {Ad="Html",Aciklama="HTML Hakkında",Fiyat=50,Aktif=true },
            new Course()
            {Ad="CSS",Aciklama="CSS Hakkında",Fiyat=40,Aktif=false },
            new Course()
            {Ad="REACT",Aciklama="REACT Hakkında",Fiyat=100,Aktif=true },
             new Course()
            {Ad="JS",Aciklama="JS Hakkında",Fiyat=100,Aktif=true },
             new Course()
            {Ad="aNGULA",Aciklama="aNGULA Hakkında",Fiyat=1000,Aktif=false }

        };
    }
}

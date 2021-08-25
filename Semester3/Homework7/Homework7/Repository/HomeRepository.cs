using Homework7.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Repository
{
    public class HomeRepository : DbContext
    {
        public DbSet<AssemblyLoadViewModel> Assemblies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestsRunHistory;Trusted_Connection=True;");
        }
    }
}

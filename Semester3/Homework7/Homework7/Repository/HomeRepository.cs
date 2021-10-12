using Homework7.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework7.Repository
{
    /// <summary>
    /// Repository class.
    /// </summary>
    public class HomeRepository : DbContext
    {
        /// <summary>
        /// History assembly testing.
        /// </summary>
        public DbSet<AssemblyViewModel> AssembliesHistory { get; set; }

        /// <summary>
        /// Loaded assemblies.
        /// </summary>
        public DbSet<LoadAssemblyViewModel> LoadAssemblies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Testing;Trusted_Connection=True;");
        }
    }
}

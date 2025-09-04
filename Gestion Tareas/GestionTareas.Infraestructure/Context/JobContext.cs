using Microsoft.EntityFrameworkCore;
using GestionTareas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Infraestructure.Context
{
    public class JobContext : DbContext
    {
        public JobContext () { }
        public JobContext (DbContextOptions options) : base (options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=GestionTareas;server=(local);TrustServerCertificate=True;");
        }
        public DbSet<Job> Jobs { get; set; }
    }
}

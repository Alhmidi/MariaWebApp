using MariaWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person_Eintrag>().HasKey(pe => new
            {
                pe.PersonId,
                pe.EintragId
            });

            modelBuilder.Entity<Person_Eintrag>().HasOne(e=>e.Einträge).WithMany(pe => pe.Personen_Einträge).HasForeignKey(e => e.EintragId);


            modelBuilder.Entity<Person_Eintrag>().HasOne(e => e.Personen).WithMany(pe => pe.Personen_Einträge).HasForeignKey(e => e.PersonId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Person{ get; set; }
        public DbSet<Organ> Organ { get; set; }
        public DbSet<Eintrag> Eintrag { get; set; }
        public DbSet<Person_Eintrag> Person_Eintrag { get; set; }
       

    }
}

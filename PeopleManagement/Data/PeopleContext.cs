using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Data.Entities
{
    public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options):base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasData(new Group()
                { 
                 GroupId=1,
                 GroupName= "COVID19 Negative"
                });
        }
    }
}

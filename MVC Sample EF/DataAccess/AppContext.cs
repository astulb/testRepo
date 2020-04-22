using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class AppContext : DbContext
    {
        public AppContext()
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Course>().HasMany(c => c.Instructors).WithMany(i => i.Courses).Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID").ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}

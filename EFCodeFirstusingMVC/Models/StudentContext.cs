using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirstusingMVC.Models
{
    public class StudentContext :DbContext
    {
       public StudentContext():base("name = MyConnectionString")
       {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext,EFCodeFirstusingMVC.Migrations.Configuration>());
       }
        public DbSet<Student> Students { get; set; }    
    }
}
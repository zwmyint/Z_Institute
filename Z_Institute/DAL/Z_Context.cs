﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Z_Institute.Models;

namespace Z_Institute.DAL
{
    public class Z_Context: DbContext
    {
        //

        //1
        public DbSet<Course> tbl_Course { get; set; }
        //2
        public DbSet<Department> tbl_Department { get; set; }


        public Z_Context(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //build 1
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseConfig());

            //build 2
            modelBuilder.ApplyConfiguration(new DepartmentConfig());





            //
        }


        //
    }
}

using Microsoft.EntityFrameworkCore;
using Z_Institute.Models;

namespace Z_Institute.DAL
{
    public class ZDb_Context:DbContext
    {
        //

        //1
        public DbSet<Course> tbl_Course { get; set; }
        //2
        public DbSet<Department> tbl_Department { get; set; }
        //3
        public DbSet<Student> tbl_Student { get; set; }
        //4
        public DbSet<Enrollment> tbl_Enrollment { get; set; }



        public ZDb_Context(DbContextOptions options)
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

            //build 3
            modelBuilder.ApplyConfiguration(new StudentConfig());

            //build 4
            modelBuilder.ApplyConfiguration(new EnrollmentConfig());

            //
        }


        //
    }
}

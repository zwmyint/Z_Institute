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
        //5
        public DbSet<Instructor> tbl_Instructor { get; set; }
        //6
        public DbSet<CourseAssignment> tbl_CourseAssignment { get; set; }
        //7
        public DbSet<OfficeAssignment> tbl_OfficeAssignment { get; set; }


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

            //build 5
            modelBuilder.ApplyConfiguration(new InstructorConfig());

            //build 6
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfig());

            //build 7
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfig());

            //
        }


        //
    }
}

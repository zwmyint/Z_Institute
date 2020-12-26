using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.DAL
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ZDb_Context>();

                if (!context.tbl_Department.Any())
                {
                    context.tbl_Department.AddRange(Departments.Values);
                }

                if (!context.tbl_Course.Any())
                {
                    var courseList = new List<Course>
                    {
                        new Course() {CourseName = "C#", Department = Departments["Programming"], Credits = 8},
                        new Course() {CourseName = "CCNA", Department = Departments["Network"], Credits = 8},
                        new Course() {CourseName = "HTML", Department = Departments["Design"], Credits = 8}
                    };

                    context.tbl_Course.AddRange(courseList);
                }

                context.SaveChanges();

                //
            }
        }

        private static Dictionary<string, Department> _departments;

        public static Dictionary<string, Department> Departments
        {

            get
            {
                if (_departments != null)
                {
                    return _departments;
                }

                var deptList = new[]
                {
                    new Department() {DepartmentName = "Programming"},
                    new Department() {DepartmentName = "Design"},
                    new Department() {DepartmentName = "Network"}
                };

                _departments = new Dictionary<string, Department>();

                foreach (var department in deptList)
                {
                    _departments.Add(department.DepartmentName, department);
                }

                return _departments;
            }
        }

        //
    }
}

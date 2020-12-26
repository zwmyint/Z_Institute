using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z_Institute.DAL;
using Z_Institute.Services.IRepository;

namespace Z_Institute.Controllers
{
    public class CourseController : Controller
    {
        //
        //private readonly ZDb_Context _context;

        //public CourseController(ZDb_Context context)
        //{
        //    _context = context;
        //}

        private readonly ICourseRepository _courseReposity;

        //public CourseController(ZDb_Context context, ICourseRepository courseRepository)
        public CourseController(ICourseRepository courseRepository)
        {
            _courseReposity = courseRepository;
        }


        //
        public IActionResult Index()
        {

            // method syntax 
            //var allCourse = _context.tbl_Course.Include(x => x.Department).ToList();

            // query syntax
            //var querySyntax = from dept in _context.tbl_Department
            //                  join course in _context.tbl_Course on dept.DepartmentId equals course.DepartmentId
            //                  select course;

            //var allcourses = _courseReposity.GetAll();
            var allcourses = _courseReposity.CoursesToDepartment();

            //return View(allCourse); // method syntax 
            //return View(querySyntax); // query syntax
            return View(allcourses);

        }



        //
    }
}
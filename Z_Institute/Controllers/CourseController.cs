using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z_Institute.DAL;

namespace Z_Institute.Controllers
{
    public class CourseController : Controller
    {
        //
        private readonly Z_Context _context;

        public CourseController(Z_Context context)
        {
            _context = context;
        }

        //
        public IActionResult Index()
        {

            // method syntax 
            //var allCourse = _context.tbl_Course.Include(x => x.Department).ToList();

            // query syntax
            var querySyntax = from dept in _context.tbl_Department
                              join course in _context.tbl_Course on dept.DepartmentId equals course.DepartmentId
                              select course;


            return View(querySyntax);
        }



        //
    }
}
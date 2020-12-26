using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Z_Institute.DAL;
using Z_Institute.Models;
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

        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        //public CourseController(ZDb_Context context, ICourseRepository courseRepository)
        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }
        
        // 0
        public IActionResult Index()
        {

            // method syntax 
            //var allCourse = _context.tbl_Course.Include(x => x.Department).ToList();

            // query syntax
            //var querySyntax = from dept in _context.tbl_Department
            //                  join course in _context.tbl_Course on dept.DepartmentId equals course.DepartmentId
            //                  select course;

            //var allcourses = _courseReposity.GetAll();
            var allcourses = _courseRepository.CoursesToDepartment();

            //return View(allCourse); // method syntax 
            //return View(querySyntax); // query syntax
            return View(allcourses);

        }

        // 1
        [HttpGet]
        public IActionResult Create()
        {
            //for Department DropDown
            //ViewBag.Departments = _departmentRepository.GetAll();
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName");

            return View();
        }

        // 2
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Course model)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(model);
                return RedirectToAction("Index");
            }

            return View("Create");

        }
         
        // 1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            //ViewBag.Departments = _departmentRepository.GetAll();
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName");

            return View(course);
        }

        // 2
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course model)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(model);
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        // 1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null && id == 0)
            {
                return NotFound();
            }

            return View(course);
        }

        // 2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null && id == 0)
            {
                return NotFound();
            }
            _courseRepository.Delete(course);
            return RedirectToAction("Index");
        }


        //
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;
using Z_Institute.ViewModels;

namespace Z_Institute.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // 0 
        public IActionResult Index(string sortOrder, string searchString)
        {

            //if (string.IsNullOrEmpty(sortOrder))
            //{
            //    ViewData["sortName"] = "name_desc";
            //}
            //else
            //{
            //    ViewData["sortName"] = "";
            //}

            ViewData["sortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["sortByDate"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["currentFilter"] = searchString;

            //if (sortOrder == "Date")
            //{
            //    ViewData["sortByDate"] = "date_desc";
            //}
            //else
            //{
            //    ViewData["sortByDate"] = "Date";
            //}

            var students = _studentRepository.GetAll();

            // where
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName.ToLower().Contains(searchString.ToLower()) || 
                s.LastName.ToLower().Contains(searchString.ToLower()));
            }

            // order
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.FirstName);
                    break;

            }

            return View(students);
        }

        // 1
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 2
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(model);
                return RedirectToAction("Index");
            }

            return View("Create");
        }





        // 0
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //ViewBag.Courses = _courseRepository.GetAll();
            var student = _studentRepository.GetById(id);
            var model = new StudentViewModel()
            {
                Student = student,
                Enrollments = _studentRepository.CoursesToStudent(student.StudentId)
            };

            return View(model);

        }




        //
    }
}
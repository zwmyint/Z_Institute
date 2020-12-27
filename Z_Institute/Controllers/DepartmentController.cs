using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;

namespace Z_Institute.Controllers
{
    public class DepartmentController : Controller
    {
        //
        //private readonly ZDb_Context _context;

        //public CourseController(ZDb_Context context)
        //{
        //    _context = context;
        //}

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;

        public DepartmentController(IDepartmentRepository departmentRepository,
            IInstructorRepository instructorRepository)
        {
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.InstructorToDepartments();
            //var departments = _departmentRepository.GetAll();

            return View(departments);
        }

        // 1
        [HttpGet]
        public IActionResult Create()
        {
            InstructorList();
            //ViewBag.Instructors = _instructorRepository.GetAll();

            return View();
        }

        // 2
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Department model)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(model);
            }

            return RedirectToAction("Details", new { detailId = model.DepartmentId });
        }

        // 1
        public IActionResult Edit(int id)
        {
            //var department = _departmentRepository.GetById(id);
            var department = _departmentRepository.InstructorToDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            InstructorList();
            return View(department);
        }

        // 2
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Department model)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(model);
                return RedirectToAction("Details", new { detailId = model.DepartmentId });
            }

            return View("Edit");
        }

        // 1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.InstructorToDepartment(id);
            //var department = _departmentRepository.GetById(id);
            return View(department);
        }

        // 2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(department);
            return RedirectToAction("Index");
        }


        // 0
        public void InstructorList()
        {
            //ViewBag.Instructors = _instructorRepository.GetAll();
            ViewBag.Instructors = new SelectList(_instructorRepository.GetAll(), "InstructorId", "FullName");
        }

        // 0
        public IActionResult Details(int detailId)
        {
            //var department = _departmentRepository.GetById(detailId);
            var department = _departmentRepository.InstructorToDepartment(detailId);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //

    }
}
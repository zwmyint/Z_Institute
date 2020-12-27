using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;
using System.Linq;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;
using Z_Institute.ViewModels;

namespace Z_Institute.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentController(IStudentRepository studentRepository,
            IEnrollmentRepository enrollmentRepository,
            ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
        }

        // 0 
        public IActionResult Index(string sortOrder, string searchString, int pageindex = 1)
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

            // paging
            var model = PagingList.Create(students, 2, pageindex);

            //return View(students);
            return View(model);
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

        // 3
        public IActionResult AddCourseToStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Enrollment.StudentId == 0 || model.Enrollment.CourseId == 0)
                {
                    return RedirectToAction("Index");
                }
                _enrollmentRepository.Add(model.Enrollment);

            }

            return RedirectToAction("Details", new { id = model.Enrollment.StudentId });

        }

        // 1
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null && id == 0)
            {
                return NotFound();
            }

            return View(student);
        }

        // 2
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(model);
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        // 1
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null && id == 0)
            {
                return NotFound();
            }

            return View(student);
        }

        // 2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var course = _studentRepository.GetById(id);
            if (course == null && id == 0)
            {

                return NotFound();
            }

            _studentRepository.Delete(course);
            return RedirectToAction("Index");
        }



        // 0
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //ViewBag.Courses = _courseRepository.GetAll();
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "CourseId", "CourseName");

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
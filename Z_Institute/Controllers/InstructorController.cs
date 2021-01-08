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
    public class InstructorController : Controller
    {
        //
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseAssignmentRepository _courseAssignmentRepository;

        public InstructorController(IInstructorRepository instructorRepository,
            ICourseRepository courseRepository,
            ICourseAssignmentRepository courseAssignmentRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _courseAssignmentRepository = courseAssignmentRepository;
        }

        // 0
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var allInstructors = await _instructorRepository.InstructorsAsync();

            var model = new IntructorViewModel()
            {
                Instructors = allInstructors
            };

            if(id != null)
            {
                ViewData["instructorId"] = id.Value;

                var instructor = model.Instructors.FirstOrDefault(x => x.InstructorId == id);
                if (instructor != null) model.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if(courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;
                model.Enrollments = model.Courses.FirstOrDefault(x => x.CourseId == courseId).Enrollments;
                //
            }


            return View(model);
        }

        // 1
        public IActionResult Create()
        {
            var allcourses = _courseRepository.GetAll();
            var model = new EditCreateViewModel()
            {
                AssignedCourseData = allcourses.Select(s => new AssignedCourseData()
                {
                    CourseId = s.CourseId,
                    CourseName = s.CourseName,
                    Assigned = false
                }).ToList()
            };

            return View(model);

        }

        // 2
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(EditCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            if(model.Instructor != null)
            {

                _instructorRepository.Add(model.Instructor);

                var instrId = model.Instructor.InstructorId;
                foreach(var data in model.AssignedCourseData)
                {
                    if(data.Assigned)
                    {
                        _courseAssignmentRepository.Add(new CourseAssignment()
                        {
                            CourseId = data.CourseId,
                            InstructorId = instrId
                        });
                    }
                }

                return RedirectToAction("Index");
            }

            return View("Create");
        }


        // 1
        public async Task<IActionResult>Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = _instructorRepository.GetById((int)id);
            var allCourses = _courseRepository.GetAll();
            var coursesToInstructor = await _courseAssignmentRepository.CoursesToInstructorAsync(instructor.InstructorId);
            var model = new EditCreateViewModel()
            {
                Instructor = instructor,
                AssignedCourseData = allCourses.Select(s => new AssignedCourseData()
                {
                    CourseId = s.CourseId,
                    CourseName = s.CourseName,
                    Assigned = coursesToInstructor.Exists(x => x.Course.CourseId == s.CourseId)

                }).OrderBy(x => x.CourseName).ToList()
            };


            return View(model);

        }

        // 2
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(EditCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _instructorRepository.Update(model.Instructor);

            var insId = model.Instructor.InstructorId;

            foreach (var data in model.AssignedCourseData)
            {
                if (data.Assigned)
                {
                    var isExist = IsExistModel(_courseAssignmentRepository.GetAll(), insId, data.CourseId);

                    if(!isExist)
                    {
                        _courseAssignmentRepository.Add(new CourseAssignment()
                        {
                            CourseId = data.CourseId,
                            InstructorId = model.Instructor.InstructorId
                        });
                    }
                    
                    //

                }
                else
                {
                    var isExist = IsExistModel(_courseAssignmentRepository.GetAll(), insId, data.CourseId);
                    if (isExist)
                    {

                        var filter = _courseAssignmentRepository
                            .GetByFiler(x => x.InstructorId == insId && x.CourseId == data.CourseId)
                            .FirstOrDefault();
                        _courseAssignmentRepository.Delete(filter);
                    }

                    //
                }

                //
            }

            //

            return RedirectToAction("Index");

        }

        // 3
        private bool IsExistModel(IEnumerable<CourseAssignment> source, int instructorId, int courseId)
        {
            return source.Where(x => x.InstructorId == instructorId).Any(c => c.CourseId == courseId);
        }


        // 1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _instructorRepository.InstructorAsync((int)id);

            return View(model);

        }

        // 2
        public IActionResult DeletePost(int? instructorId)
        {
            if(instructorId == null)
            {
                return NotFound();
            }

            var instructor = _instructorRepository.GetById((int)instructorId);
            if (instructor == null)
            {
                return NotFound();
            }

            _instructorRepository.Delete(instructor);
            return RedirectToAction("Index");
        }


        // 0
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _instructorRepository.InstructorAsync((int)id);

            return View(instructor);
        }



        //
    }
}
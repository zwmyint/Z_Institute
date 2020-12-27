using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Z_Institute.Services.IRepository;
using Z_Institute.ViewModels;

namespace Z_Institute.Controllers
{
    public class InstructorController : Controller
    {
        //
        private readonly IInstructorRepository _instructorRepository;
        
        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        // 0
        public async Task<IActionResult> Index(int? id)
        {
            var allInstructors = await _instructorRepository.InstructorsAsync();

            var model = new IntructorViewModel()
            {
                Instructors = allInstructors
            };

            if(id != null)
            {
                var instructor = model.Instructors.FirstOrDefault(x => x.InstructorId == id);
                model.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            return View(model);
        }




        //
    }
}
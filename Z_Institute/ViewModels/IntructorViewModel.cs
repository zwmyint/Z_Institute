using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.ViewModels
{
    public class IntructorViewModel
    {

        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_Institute.Models
{
    public class CourseAssignment
    {
        public int CourseAssignmentId { get; set; }
        public Instructor Instructor { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

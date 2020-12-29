using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_Institute.Models
{
    public class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Z_Institute.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        //
    }
}

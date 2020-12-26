using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_Institute.Models
{
    public class Department
    {
        // Each Department have many Courses
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Budget { get; set; }


        public ICollection<Course> Courses { get; set; }
        //
    }
}

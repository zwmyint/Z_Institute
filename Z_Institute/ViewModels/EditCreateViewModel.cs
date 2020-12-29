using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.ViewModels
{
    public class EditCreateViewModel
    {
        public Instructor Instructor { get; set; }
        public List<AssignedCourseData> AssignedCourseData { get; set; }
    }
}

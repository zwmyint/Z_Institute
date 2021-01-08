using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.Services.IRepository
{
    public interface ICourseAssignmentRepository: IRepository<CourseAssignment>
    {
        Task<List<CourseAssignment>> CoursesToInstructorAsync(int id);
        //List<CourseAssignment> CoursesToInstructor(int id);
        //
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.DAL;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;

namespace Z_Institute.Services.Repository
{
    public class CourseAssignmentRepository: Repository<CourseAssignment>, ICourseAssignmentRepository
    {
        //
        private readonly ZDb_Context _context;

        public CourseAssignmentRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<CourseAssignment>> CoursesToInstructorAsync(int id)
        //{
        //    return await _context.tbl_CourseAssignment
        //        .Where(x => x.CourseAssignmentId == id)
        //        .Include(x => x.Course)
        //        .ToListAsync();
        //}

        //public List<CourseAssignment> CoursesToInstructor(int id)
        //{
        //    return _context.tbl_CourseAssignment
        //        .Where(x => x.CourseAssignmentId == id)
        //        .Include(x => x.Course)
        //        .ToList();
        //}
        //
    }
}

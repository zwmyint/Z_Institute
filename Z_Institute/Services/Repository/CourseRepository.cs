using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.DAL;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Z_Institute.Services.Repository
{
    public class CourseRepository:Repository<Course>,ICourseRepository
    {
        //
        private readonly ZDb_Context _context;

        public CourseRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }
        

        public IEnumerable<Course> CoursesToDepartment()
        {
            return _context.tbl_Course.Include(x => x.Department).ToList();
        }




        //
    }
}

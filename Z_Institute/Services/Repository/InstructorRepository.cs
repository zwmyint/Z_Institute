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
    public class InstructorRepository:Repository<Instructor>, IInstructorRepository
    {
        //
        private readonly ZDb_Context _context;

        public InstructorRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> InstructorsAsync()
        {

            return await _context.tbl_Instructor
                .Include(x => x.OfficeAssignment)
                .Include(x => x.CourseAssignments)
                    .ThenInclude(x => x.Course)
                        .ThenInclude(x => x.Department)
                .Include(x => x.CourseAssignments)
                    .ThenInclude(x => x.Course)
                        .ThenInclude(x => x.Enrollments)
                            .ThenInclude(x => x.Student)
                .AsNoTracking()
                .ToListAsync();

        }

        public async Task<Instructor> Instructor(int id)
        {

            return await _context.tbl_Instructor
                .Include(x => x.CourseAssignments)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(i => i.InstructorId == id);


        }

        //
    }
}

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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        //

        private readonly ZDb_Context _context;

        public StudentRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }

        //
        public IEnumerable<Enrollment> CoursesToStudent(int studentId)
        {
            return _context.tbl_Enrollment
                .Where(e => e.StudentId == studentId)
                .Include(x => x.Student)
                .Include(x => x.Course)
                .ToList();
        }

        //
    }
}

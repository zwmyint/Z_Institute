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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        //
        //private readonly ZDb_Context _context;

        //public CourseRepository(ZDb_Context context) : base(context)
        //{
        //    _context = context;
        //}

        private readonly ZDb_Context _context;

        public DepartmentRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Department> InstructorToDepartments()
        {
            return _context.tbl_Department.Include(x => x.Instructor).ToList();

        }

        public Department InstructorToDepartment(int id)
        {
            //return (from department in _context.tbl_Department
            //        join instructor in _context.tbl_Instructor on department.DepartmentId equals instructor.InstructorId
            //        select department).FirstOrDefault(x => x.DepartmentId == id);

            return _context.tbl_Department.Include(x => x.Instructor).FirstOrDefault(x => x.DepartmentId == id);
        }

        //
    }
}

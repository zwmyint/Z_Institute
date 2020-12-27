using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.DAL;
using Z_Institute.Models;
using Z_Institute.Services.IRepository;

namespace Z_Institute.Services.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {

        private readonly ZDb_Context _context;

        public EnrollmentRepository(ZDb_Context context) : base(context)
        {
            _context = context;
        }


        //

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.Services.IRepository
{
    public interface IInstructorRepository:IRepository<Instructor>
    {

        Task<IEnumerable<Instructor>> InstructorsAsync();
        Task<Instructor> InstructorAsync(int id);

        //
    }
}

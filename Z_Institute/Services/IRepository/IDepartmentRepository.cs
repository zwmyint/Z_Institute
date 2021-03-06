﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_Institute.Models;

namespace Z_Institute.Services.IRepository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        IEnumerable<Department> InstructorToDepartments();

        Department InstructorToDepartment(int id);

        //

    }
}

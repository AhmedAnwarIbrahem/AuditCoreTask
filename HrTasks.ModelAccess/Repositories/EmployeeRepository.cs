using Common;
using HrTasks.Model;
using HrTasks.Model.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.ModelAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(HrTasksContext context) : base(context)
        {
        }
    }
    
}

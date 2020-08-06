using Common;
using HrTasks.Model;
using HrTasks.Model.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.ModelAccess.Repositories
{
    public class EmployeeTaskRepository : Repository<EmployeeTask>
    {
        public EmployeeTaskRepository(HrTasksContext context) : base(context)
        {
        }
    }
    
}

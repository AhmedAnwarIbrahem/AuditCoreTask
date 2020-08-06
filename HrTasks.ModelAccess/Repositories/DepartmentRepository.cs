using Common;
using HrTasks.Model;
using HrTasks.Model.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.ModelAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(HrTasksContext context) : base(context)
        {
        }
    }
    
}

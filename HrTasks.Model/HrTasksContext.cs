using HrTasks.Model.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Model
{
   public class HrTasksContext: DbContext
    {
        public HrTasksContext(DbContextOptions<HrTasksContext> options) : base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}

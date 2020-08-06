using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Model.Entites
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNameAr { get; set; }
        public string EmployeeNameEn { get; set; }
        public bool IsManger { get; set; }
        public DateTime JoinDate { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
        public virtual ICollection<EmployeeTask> Tasks { get; set; }

    }
}

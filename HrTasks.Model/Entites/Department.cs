using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Model.Entites
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentEn { get; set; }
        public string DepartmentAr { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

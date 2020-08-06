using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Model.Entites
{
    public class EmployeeTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
    }
}

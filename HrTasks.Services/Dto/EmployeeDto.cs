using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.Dto
{
  public  class EmployeeDto
    {
        public int? Id { get; set; }
        public string EmployeeNameAr { get; set; }
        public string EmployeeNameEn { get; set; }
        public bool? IsManger { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentEn { get; set; }
        public string DepartmentAr { get; set; }
    }
}

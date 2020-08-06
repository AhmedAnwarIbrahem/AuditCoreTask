using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.Dto
{
  public  class EmployeeTaskDto
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeNameAr { get; set; }
        public string EmployeeNameEn { get; set; }

    }
}

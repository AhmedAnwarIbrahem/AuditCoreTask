using System.Collections.Generic;
using HrTasks.Services.Dto;

namespace HrTasks.Services.Interfaces
{
    public interface IEmployeeTaskService
    {
        void Add(EmployeeTaskDto EmployeeTaskDto);
        void Delete(int id);
        EmployeeTaskDto Get(int id);
        IEnumerable<EmployeeTaskDto> GetAll();
        void Update(EmployeeTaskDto EmployeeTaskDto);
    }
}
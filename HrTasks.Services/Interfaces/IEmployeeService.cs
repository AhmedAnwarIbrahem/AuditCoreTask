using System.Collections.Generic;
using HrTasks.Services.Dto;

namespace HrTasks.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Add(EmployeeDto employeeDto);
        void Delete(int id);
        EmployeeDto Get(int id);
        IEnumerable<EmployeeDto> GetAll();
        void Update(EmployeeDto employeeDto);
    }
}
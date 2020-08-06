using System.Collections.Generic;
using HrTasks.Services.Dto;

namespace HrTasks.Services.Interfaces
{
    public interface IDepartmentService
    {
        void Add(DepartmentDto DepartmentDto);
        void Delete(int id);
        DepartmentDto Get(int id);
        IEnumerable<DepartmentDto> GetAll();
        void Update(DepartmentDto DepartmentDto);
    }
}
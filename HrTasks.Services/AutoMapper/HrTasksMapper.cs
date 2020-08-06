using AutoMapper;
using HrTasks.Model.Entites;
using HrTasks.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.AutoMapper
{
    public class HrTasksMapper : Profile
    {
        public HrTasksMapper(){

            CreateMap<EmployeeDto, Employee>().ReverseMap().ForMember(p => p.DepartmentAr, d => d.MapFrom(u => (u.DepartmentId != null) ? u.Departments.DepartmentAr : string.Empty)).ForMember(p => p.DepartmentEn, d => d.MapFrom(u => (u.DepartmentId != null) ? u.Departments.DepartmentEn : string.Empty));
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<EmployeeTaskDto, EmployeeTask>().ReverseMap().ForMember(p => p.EmployeeNameAr, d => d.MapFrom(u => (u.EmployeeId != null) ? u.Employees.EmployeeNameAr : string.Empty)).ForMember(p => p.EmployeeNameEn, d => d.MapFrom(u => (u.EmployeeId != null) ? u.Employees.EmployeeNameEn : string.Empty));


        }
    }
}

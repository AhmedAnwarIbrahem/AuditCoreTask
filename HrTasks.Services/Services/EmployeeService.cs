using AutoMapper;
using HrTasks.Model.Entites;
using HrTasks.ModelAccess;
using HrTasks.Services.Dto;
using HrTasks.Services.Interfaces;
using HrTasks.Services.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.Services
{
  public  class EmployeeService : BaseServices, IEmployeeService
    {
        public EmployeeService(IMapper mapper, IUnitofWork unitofWork)
         : base(mapper, unitofWork) { }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var list = _unitofWork.EmployeeRepository.GetAll(source => source.Include(u => u.Departments));
            return _mapper.Map<IEnumerable<EmployeeDto>>(list);
        }
        public EmployeeDto Get(int id)
        {
            var employee = _unitofWork.EmployeeRepository.Get(id);
            return _mapper.Map<EmployeeDto>(employee);
        }
        public void Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            _unitofWork.EmployeeRepository.Add(employee);
            _unitofWork.SaveChanges();
        }
        public void Update(EmployeeDto employeeDto)
        {

            var employeeOld = _unitofWork.EmployeeRepository.Get(employeeDto.Id);
            var employeeNew = _mapper.Map<Employee>(employeeDto);
            //_mapper.Map(employeeDto, employeeNew);
            _unitofWork.EmployeeRepository.Update(employeeNew, employeeOld);
            _unitofWork.SaveChanges();
        }
        public void Delete(int id)
        {
            var employee = _unitofWork.EmployeeRepository.Get(id);
            if (employee != null)
            {
                _unitofWork.EmployeeRepository.Remove(employee);

                _unitofWork.SaveChanges();
            }
        }
    }
}

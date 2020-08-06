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
  public  class EmployeeTaskService : BaseServices, IEmployeeTaskService
    {
        public EmployeeTaskService(IMapper mapper, IUnitofWork unitofWork)
         : base(mapper, unitofWork) { }

        public IEnumerable<EmployeeTaskDto> GetAll()
        {
            var list = _unitofWork.EmployeeTaskRepository.GetAll(source => source.Include(u => u.Employees));
            return _mapper.Map<IEnumerable<EmployeeTaskDto>>(list);
        }
        public EmployeeTaskDto Get(int id)
        {
            var EmployeeTask = _unitofWork.EmployeeTaskRepository.Get(id);
            return _mapper.Map<EmployeeTaskDto>(EmployeeTask);
        }
        public void Add(EmployeeTaskDto EmployeeTaskDto)
        {
            var EmployeeTask = _mapper.Map<EmployeeTaskDto, EmployeeTask>(EmployeeTaskDto);
            _unitofWork.EmployeeTaskRepository.Add(EmployeeTask);
            _unitofWork.SaveChanges();
        }
        public void Update(EmployeeTaskDto EmployeeTaskDto)
        {
            var EmployeeTask = _unitofWork.EmployeeTaskRepository.Get(EmployeeTaskDto.Id);
            _mapper.Map(EmployeeTaskDto, EmployeeTask);

            _unitofWork.SaveChanges();
        }
        public void Delete(int id)
        {
            var EmployeeTask = _unitofWork.EmployeeTaskRepository.Get(id);
            if (EmployeeTask != null)
            {
                _unitofWork.EmployeeTaskRepository.Remove(EmployeeTask);

                _unitofWork.SaveChanges();
            }
        }
    }
}

using Audit.Core;
using AutoMapper;
using Common;
using HrTasks.Model.Entites;
using HrTasks.ModelAccess;
using HrTasks.Services.Dto;
using HrTasks.Services.Interfaces;
using HrTasks.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.Services
{
  public  class DepartmentService : BaseServices, IDepartmentService
    {
        public DepartmentService(IMapper mapper, IUnitofWork unitofWork)
         : base(mapper, unitofWork) { }



        public IEnumerable<DepartmentDto> GetAll()
        {
            var list = _unitofWork.DepartmentRepository.GetAll();
            return _mapper.Map<IEnumerable<DepartmentDto>>(list);
        }
        public DepartmentDto Get(int id)
        {
            var Department = _unitofWork.DepartmentRepository.Get(id);
            return _mapper.Map<DepartmentDto>(Department);
        }
        public void Add(DepartmentDto DepartmentDto)
        {
            var department = _mapper.Map<DepartmentDto, Department>(DepartmentDto);
            _unitofWork.DepartmentRepository.Add(department);
            _unitofWork.SaveChanges();
        }
        public async void Update(DepartmentDto DepartmentDto)
        {
            var departmentOld = _unitofWork.DepartmentRepository.Get(DepartmentDto.Id);
            var departmentNew = _mapper.Map<Department>(DepartmentDto);
            _unitofWork.DepartmentRepository.Update(departmentNew, departmentOld);
            _unitofWork.SaveChanges();
        }
        public void Delete(int id)
        {
            var Department = _unitofWork.DepartmentRepository.Get(id);
            if (Department != null)
            {
                _unitofWork.DepartmentRepository.Remove(Department);

                _unitofWork.SaveChanges();
            }
        }
    }
}

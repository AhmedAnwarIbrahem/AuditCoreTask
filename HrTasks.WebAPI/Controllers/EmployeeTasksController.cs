using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrTasks.Services.Dto;
using HrTasks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HrTasks.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private IEmployeeTaskService _EmployeeTaskService;
        public EmployeeTasksController(IEmployeeTaskService EmployeeTaskService) 
        {
            _EmployeeTaskService = EmployeeTaskService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _EmployeeTaskService.GetAll();

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var EmployeeTasks = _EmployeeTaskService.Get(id);

            return Ok(EmployeeTasks);
        }
        [HttpPost]
        public IActionResult Add(EmployeeTaskDto EmployeeTaskDto)
        {
            _EmployeeTaskService.Add(EmployeeTaskDto);

            return Ok();
        }
        [HttpPut()]
        public IActionResult Update(EmployeeTaskDto EmployeeTaskDto)
        {
            _EmployeeTaskService.Update(EmployeeTaskDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EmployeeTaskService.Delete(id);

            return Ok();
        }

        [HttpGet("{empId}")]
        public IActionResult GetAllTasksByEmpId(int empId)
        {
            var list = _EmployeeTaskService.GetAll().Where(a => a.EmployeeId == empId).ToList();
            return Ok(list);
        }
    }
}
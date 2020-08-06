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
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _EmployeeService;
        public EmployeesController(IEmployeeService EmployeeService) 
        {
            _EmployeeService = EmployeeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _EmployeeService.GetAll();

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employees = _EmployeeService.Get(id);

            return Ok(employees);
        }
        [HttpPost]
        public IActionResult Add(EmployeeDto employeeDto)
        {
            _EmployeeService.Add(employeeDto);

            return Ok();
        }
        [HttpPut()]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            _EmployeeService.Update(employeeDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EmployeeService.Delete(id);

            return Ok();
        }
    }
}
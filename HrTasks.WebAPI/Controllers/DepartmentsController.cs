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
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _DepartmentService;
        public DepartmentsController(IDepartmentService DepartmentService) 
        {
            _DepartmentService = DepartmentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _DepartmentService.GetAll();

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Departments = _DepartmentService.Get(id);

            return Ok(Departments);
        }
        [HttpPost]
        public IActionResult Add(DepartmentDto DepartmentDto)
        {
            _DepartmentService.Add(DepartmentDto);

            return Ok();
        }
        [HttpPut()]
        public IActionResult Update(DepartmentDto DepartmentDto)
        {
            _DepartmentService.Update(DepartmentDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _DepartmentService.Delete(id);

            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPIPostman.EmployeeData;
using RESTAPIPostman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIPostman.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employee.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employee.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"employee with id: {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            employee = _employee.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+HttpContext.Request.Path+"/"+employee.Id
                ,employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DelEmployee(Guid id)
        {
            var employee = _employee.GetEmployee(id);
            if(employee != null)
            {
                _employee.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"employee with id: {id} not found");
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult UpdateEmployee(Employee employee)
        {
        
            
            if (_employee.GetEmployee(employee.Id) != null)
            {
                return Ok(_employee.EditEmployee(employee));
            }
            return NotFound($"employee not found");
        }
    }
}

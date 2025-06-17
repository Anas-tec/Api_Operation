using Api_Test.Models;
using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Api_Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IEmailService emailService;
        public EmployeesController(ApplicationDbContext dbContext/*, IEmailService emailService*/)
        {
            this.dbContext = dbContext;
            //this.emailService = emailService;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) 
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        //public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            { 
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

           /* var emailRequest = new EmailRequest
            {
                ToEmail = addEmployeeDto.Email,
                Subject = "Welcome to the Company!",
                Body = $"<h3>Hello {addEmployeeDto.Name},</h3><p>Your profile has been created successfully.</p>"
            };*/

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name=updateEmployeeDto.Name;
            employee.Email=updateEmployeeDto.Email;
            employee.Phone=updateEmployeeDto.Phone;
            employee.Salary=updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            dbContext.Remove(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }
    }
}

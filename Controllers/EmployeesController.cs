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
        [Route("GetAllEmployee")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }





        /*
         // this method return single emplyee with id(primary key)
        [HttpGet]
        [Route("GetEmployeeById")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }*/

        /* 
        // this can generate all employe even the user did not giv the id,user gives an id it return the specific employee
        [HttpGet]
        [Route("GetEmployeeById")]
        public IActionResult GetEmployeeById(Guid? id) 
        {
            if (id.HasValue)
            {
                var employee = dbContext.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
        var employees = dbContext.Employees.ToList();
        return Ok(employees);
        }*/



        //fethiching data with given details 
        [HttpGet]
        [Route("GetEmployeesByvalue")]
        public IActionResult GetEmployeesByvalue(Guid? id,string? name,string? phone,string? email,decimal? salary)
        {
            var query = dbContext.Employees.AsQueryable();
            if (id.HasValue) 
            {
                query = query.Where(e=>e.Id==id.Value);
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                query=query.Where(e=>e.Name.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query=query.Where(e=>e.Phone.Contains(phone));
            }
            if (!string.IsNullOrWhiteSpace(email)) 
            {
                query = query.Where(e => e.Email.Contains(email));
            }
            if (salary.HasValue) 
            {
                query=query.Where(e=>e.Salary==salary.Value);
            }

            var total=query.ToList();

            if (total.Count == 0) 
            {
                return NotFound("there is no data to fetch");
            }
            return Ok(total);
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

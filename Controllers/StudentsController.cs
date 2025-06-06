using Api_Test.Models;
using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Api_Test.Models.StudentsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetStudents() 
        {
            var stu = dbContext.Students.ToList();
            return Ok(stu);
        }

        [HttpPost]
        public IActionResult AddStudents(AddStudentDto addStudentDto) 
        {
            var stu = new Student()
            {
                Name=addStudentDto.Name,
                Age=addStudentDto.Age,
                FatherName=addStudentDto.FatherName
            };
            dbContext.Students.Add(stu);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStudents(int id, UpdateStudent updateStudent) 
        {
            var stu = dbContext.Students.Find(id);
            if (stu == null) 
            {
                return NotFound();
            }
            stu.Name=updateStudent.Name;
            stu.Age=updateStudent.Age;
            stu.FatherName=updateStudent.FatherName;
            dbContext.SaveChanges();
            return Ok(stu);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id) 
        {
            var stu = dbContext.Students.Find(id);
            if (stu == null)
            {
                return NotFound();
            }
            dbContext.Remove(stu);
            dbContext.SaveChanges();
            return Ok(stu);
        }
    }
}

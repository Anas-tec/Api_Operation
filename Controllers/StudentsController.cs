using Api_Test.Models;
using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Api_Test.Models.StudentsDto;
using Api_Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;
        private object studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

           

            [HttpPost]
            public IActionResult AddStudents(AddStudentDto addStudentDto) 
            {
                _studentService.AddStudents(addStudentDto);

            return Ok(addStudentDto);
            }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudent updateStudent)
        {
            var updated = _studentService.UpdateStudent(id, updateStudent);
            if (!updated)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var deleted = _studentService.DeleteStudent(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }



        /*         [HttpDelete]
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
                }*/
    }
}

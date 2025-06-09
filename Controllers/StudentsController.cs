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
        private readonly IStudent _studentService;
        private object studentService;

        public StudentsController(IStudent studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex) 
            {
                return NotFound(new { message = "An error occurred while fetching students." });
            }
        }

           

            [HttpPost]
            public IActionResult AddStudents(AddStudentDto addStudentDto) 
            {
            try
            {
                _studentService.AddStudents(addStudentDto);

                return Ok(addStudentDto);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occurred while fetching students." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudent updateStudent)
        {
            try
            {
                var updated = _studentService.UpdateStudent(id, updateStudent);
                if (!updated)
                {
                    return NotFound();
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occurred while fetching students." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var deleted = _studentService.DeleteStudent(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occurred while fetching students." });
            }
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

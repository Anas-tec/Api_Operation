using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Api_Test.Models.StudentsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentService()
        {
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }
        public void AddStudents(AddStudentDto addStudentDto)
        {
            var stu = new Student()
            {
                Name = addStudentDto.Name,
                Age = addStudentDto.Age,
                FatherName = addStudentDto.FatherName
            };
            _dbContext.Students.Add(stu);
            _dbContext.SaveChanges();
        }
        public bool UpdateStudent(int id, UpdateStudent dto)
        {
            var student = _dbContext.Students.Find(id);
            if (student == null) return false;

            student.Name = dto.Name;
            student.Age = dto.Age;
            student.FatherName = dto.FatherName;

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = _dbContext.Students.Find(id);
            if (student == null) return false;

            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

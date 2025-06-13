using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Api_Test.Models.StudentsDto;
using Api_Test.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Services
{
    public class StudentService : IStudent, IStudentUD
    {
        private readonly StudentRepository _repository;
        public StudentService(StudentRepository repository)
        {
            _repository = repository;
        }
        public StudentService()
        {
        }
        public List<Student> GetStudents()
        {
            return _repository.GetStudents();
        }
        public void AddStudents(AddStudentDto addStudentDto)
        {
            _repository.AddStudents(addStudentDto);
        }
        public bool UpdateStudent(int id, UpdateStudent dto)
        {
            return _repository.UpdateStudent(id, dto);
        }
        public bool DeleteStudent(int id)
        {
            return _repository.DeleteStudent(id);
        }
    }
}
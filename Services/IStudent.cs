﻿using Api_Test.Models.Entities;
using Api_Test.Models.StudentsDto;

namespace Api_Test.Services
{
    public interface IStudent
    {
        public List<Student> GetStudents();
        public void AddStudents(AddStudentDto addStudentDto);
    }
}

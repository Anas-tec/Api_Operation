using Api_Test.Models.Data;
using Api_Test.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Test.Services
{
    public class ser
    {
        private readonly ApplicationDbContext _dbContext;
        public ser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }

    }
}

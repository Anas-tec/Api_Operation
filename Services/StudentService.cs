using Api_Test.Models.Data;
using Api_Test.Models.Entities;

namespace Api_Test.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }
    }
}

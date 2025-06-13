using Api_Test.Models.StudentsDto;

namespace Api_Test.Services
{
    public interface IStudentUD
    {
        public bool UpdateStudent(int id, UpdateStudent dto);
        public bool DeleteStudent(int id);
    }
}

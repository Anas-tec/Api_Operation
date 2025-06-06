namespace Api_Test.Models
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
    }
}

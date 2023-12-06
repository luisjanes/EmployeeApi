using EmployeeApi.Models.Enums;

namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DepartmentEnum Department { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string? PhotoFile { get; set; }
    }
}

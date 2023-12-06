using Dapper;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            var connection = new MySqlConnection("Server=localhost; User ID=root; Password=123456; Database=todoappServer");
            var employee = connection.Query<Employee>("""
                    SELECT *
                	FROM todoappServer.Employee
                """);
            return employee;
        }

        [HttpPost]

        public void PostEmployee(Employee employee)
        {
            var connection = new MySqlConnection("Server=localhost; User ID=root; Password=123456; Database=todoappServer");
            connection.Execute("""INSERT into todoappServer.Employee values(id = 0, name = @name, department = @department, dateOfJoining = @dateOfJoining, photoFile = @photoFile)""",
                new
                {
                    name = employee.Name,
                    department = employee.Department,
                    dateOfJoining = employee.DateOfJoining,
                    photoFile = employee.PhotoFile,
                });
        }

        [HttpPut]
        public void PutEmployee(Employee employee)
        {
            var connection = new MySqlConnection("Server=localhost; User ID=root; Password=123456; Database=todoappServer");
            connection.Execute("""UPDATE todoappServer.Employee set Name = @name, Department = @department, DateOfJoining = @dateOfJoining, PhotoFile = @photoFile where Id = @id""",
            new
            {
                id = employee.Id,
                name = employee.Name,
                department = employee.Department,
                dateOfJoining = employee.DateOfJoining,
                photoFile = employee.PhotoFile,
            });
        }

        [HttpDelete]

        public void DeleteEmployee(int id)
        {
            var connection = new MySqlConnection("Server=localhost; User ID=root; Password=123456; Database=todoappServer");
            connection.Execute("""DELETE FROM todoappServer.Employee WHERE Id = @id""",
                new
                {
                    id = id
                });
        }

        [Route("SaveFile")]
        [HttpPost]

        public string SaveFile()
        {
            try
            {
                var httpResquest = Request.Form;
                var postedFile = httpResquest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath +  "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return fileName;
            }

            catch (Exception)
            {

                return ("anonymous.png");
            }
        }
    }
}


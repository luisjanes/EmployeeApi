using Dapper;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Department> GetAllDepartaments()
        {
            using var connection = new MySqlConnection("Server=localhost; User ID=root; Password=123456; Database=todoappServer");
            var department = connection.Query<Department>("""
                    SELECT *
                	FROM todoappServer.Department
                """);
            return department;
        }
    }
}

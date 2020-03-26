using System;
using Microsoft.AspNetCore.Mvc;
using Task3.DAL;
using Task3.Models;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if(id == 1)
            {
                return Ok("Kowalski");
            }else if(id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Cannot find the student");

        }
        
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";
            return Ok(student);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMethod(int id)
        {
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult PutMethod(int id)
        {
            return Ok("updated");
        }
    }
}
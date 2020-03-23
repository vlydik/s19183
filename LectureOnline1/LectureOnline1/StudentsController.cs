using System;
using LectureOnline1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LectureOnline1
{ 
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getStudents(int id)
        {
            if (id == 1)
            {
                return Ok("Jan");
            }else if (id == 2)
            {
                return Ok("Katarzyna");
            }

            return NotFound("Student not found.");
        }

        public string getStudent(string orderBy = "firstName")
        {
            return $"Jan, Katarzyna, Anna sortby ={orderBy}";
            }
        [HttpPost]
        public IActionResult createStudent(Student student)
        {

            //student.indexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        
    }
}
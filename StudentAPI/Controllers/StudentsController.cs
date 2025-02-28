using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Nguyen Van A", Age = 20, Class = "IT01", Photo = "https://via.placeholder.com/100" },
            new Student { Id = 2, Name = "Tran Thi B", Age = 21, Class = "IT02", Photo = "https://via.placeholder.com/100" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        [HttpPut("UpdatePhoto/{id}")]
        public ActionResult UpdatePhoto(int id, [FromBody] string newPhoto)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Photo = newPhoto;
            return Ok(student);
        }
    }
}

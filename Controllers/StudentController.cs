using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using System.Text.RegularExpressions;
namespace SchoolSystem.Controller
{
    [ApiController] //controller file
    [Route("api/[Controller]")] // Base route: api/students
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // Constructor: ApplicationDbContext is injected via Dependency Injection (DI)
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        // Returns all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            try
            {
                return Ok(await _context.Students.ToListAsync());
            }
            // Catch unexpected errors and return HTTP 500
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/students/{id}
        // Returns a single student by ID

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentById(int id)
        {

            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound("not exsist");
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/students
        // Creates a new student

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Student>>> AddNewStudent([FromBody] Student NewStudent)
        {

            try
            {   // Validation: Age must be between 5 and 18
                if (NewStudent.Age < 5 || NewStudent.Age > 18)
                {
                    return BadRequest("the age must be between 5 -> 18 ");
                }
                // Validation: Grade level must be valid
                if (!Regex.IsMatch(NewStudent.GradeLevel, @"^(1st|2nd|3rd|[4-6]th)$"))
                {
                    return BadRequest("GradeLevel must be between 1st and 6th");
                }



                _context.Students.Add(NewStudent);
                await _context.SaveChangesAsync();
                return Ok("Student added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
        // PUT: api/students/{id}
        // Updates an existing student
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> UpdateStudent(int id, [FromBody] Student UpdateStudent)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound("this student is not found");
                }
                // Validation: Age must be between 5 and 18
                if (UpdateStudent.Age < 5 || UpdateStudent.Age > 18)
                {
                    return BadRequest("the age must be between 5 -> 18 ");
                }
                // Validation: Grade level must be valid
                if (!Regex.IsMatch(UpdateStudent.GradeLevel, @"^(1st|2nd|3rd|[4-6]th)$"))
                {
                    return BadRequest("GradeLevel must be between 1st and 6th");
                }

                student.FullName = UpdateStudent.FullName;
                student.GradeLevel = UpdateStudent.GradeLevel;
                student.Age = UpdateStudent.Age;
                await _context.SaveChangesAsync();
                return Ok("student updated sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // DELETE: api/students/{id}
        // Deletes a student by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound("this student is not found");
                }
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return Ok("student deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using System.Text.RegularExpressions;

namespace SchoolSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")] // Base route: api/courses
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor: DbContext injected via DI
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            try
            {
                return Ok(await _context.Courses.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // GET: api/courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseById(int id)
        {
            try
            {
                var result = await _context.Courses.FindAsync(id);
                if (result == null)
                {
                    return NotFound("this course id not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Course>>> AddNewCourse([FromBody] Course newcourse)
        {
            try
            { // Validation: RoomNumber must contain letters and numbers
                if (!Regex.IsMatch(newcourse.RoomNumber, @"[A-Za-z]+\d+"))
                {
                    return BadRequest("RoomNumber must be oneletter and three digit number");
                }
                // Validation: MaxCapacity between 10 and 30
                if (newcourse.MaxCapacity < 10 || newcourse.MaxCapacity > 30)
                {
                    return BadRequest("invalid capacity must be in range 10 -> 30");
                }
                _context.Courses.Add(newcourse);
                await _context.SaveChangesAsync();
                return Ok("course added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Course>>> UpdateCourse(int id, [FromBody] Course UpdatedCourse)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound("this course is not found");
                }
                if (!Regex.IsMatch(UpdatedCourse.RoomNumber, @"[A-Za-z]+\d+"))
                {
                    return BadRequest("RoomNumber must be oneletter and three digit number");
                }
                if (UpdatedCourse.MaxCapacity < 10 || UpdatedCourse.MaxCapacity > 30)
                {
                    return BadRequest("invalid capacity must be in range 10 -> 30");
                }
                course.CourseName = UpdatedCourse.CourseName;

                course.RoomNumber = UpdatedCourse.RoomNumber;
                course.MaxCapacity = UpdatedCourse.MaxCapacity;
                _context.SaveChangesAsync();
                return Ok("updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // DELETE: api/courses/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Course>>> DeleteCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound("not exsist");
                }
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return Ok("Course deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}

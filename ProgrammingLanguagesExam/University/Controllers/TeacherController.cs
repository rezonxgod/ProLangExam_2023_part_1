using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace University.Controllers
{
    [Route("Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly UniversityDbContext _dbContext;

        public TeacherController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET /Teacher/All
        [HttpGet("All")]
        public IActionResult GetAllTeachers()
        {
            var teachers = _dbContext.Teachers.Select(t => new
            {
                t.Id,
                t.Name
            }).ToList();

            return Ok(teachers);
        }

        // GET /Teacher/{id}
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _dbContext.Teachers
                .Include(t => t.Skills)
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }
    }
}

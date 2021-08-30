using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Persistence.Models;
using StudentsApp.Services.Interfaces;

namespace StudentsApp.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await Task.Run(() => _studentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await Task.Run(() => _studentService.GetById(id));

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            try
            {
                await Task.Run(() => _studentService.Update(student));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await Task.Run(() => _studentService.Add(student));

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await Task.Run(() => _studentService.Delete(id));

            return NoContent();
        }

        private bool StudentExists(long id)
        {
            return false;
        }
    }
}

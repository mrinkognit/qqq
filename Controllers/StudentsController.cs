using Microsoft.AspNetCore.Mvc;
using Project.DataBase;
using Project.Filters.StudentFilters;
using Project.Interfaces.StudenstInterfaces;
using Project.Models;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        StudentDbCotext db;
		public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbCotext cotext)
        {
            _logger = logger;
            _studentService = studentService;
            db = cotext;
            
        }
        [HttpPost("AddNewStudent")]
		public async Task<ActionResult<Stud>> Post(Stud stud)
		{
			if (stud == null)
			{
				return BadRequest();
			}

            db.students.Add(new Student
            {
                FirstName = stud.FirstName,
                LastName = stud.LastName,
                MiddleName = stud.MiddleName,
                GroupId = stud.GroupId,
                IsDeleted = false,
            });
            await db.SaveChangesAsync();
			return Ok(stud);
		}
        [HttpPost("StudentUpdate")]
		public async Task<IActionResult> StudentUpdate(StudentUpdateFilter filter, CancellationToken cancellationToken = default)
		{
            var students = await _studentService.StudentUpdate(filter, cancellationToken);

            students.FirstName = filter.FirstName;
            students.LastName = filter.LastName;
            students.MiddleName = filter.MiddleName;
            students.GroupId = filter.GroupId;
            students.IsDeleted = filter.IsDeleted;

            db.students.Update(students);
			await db.SaveChangesAsync();
			return Ok(students);

		}

		[HttpPost("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

		[HttpPost("GetStudentsByGroupId")]
		public async Task<IActionResult> GetStudentsByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken = default)
		{
			var students = await _studentService.GetStudentByGroupIdAsync(filter, cancellationToken);

			return Ok(students);
		}

		[HttpPost("GetStudentsByName")]
        public async Task<IActionResult> GetStudentsByName(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByNameAsync(filter, cancellationToken);

            return Ok(students);
        }

        
        [HttpPost("GetStudentFIOFilter")]
        public async Task<IActionResult> GetStudentFIOFilters(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentFIOFiltersAsync(filter, cancellationToken);

            return Ok(students);
        }
        [HttpPost("GetDeletedStudent")]
        public async Task<IActionResult> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetDeletedStudentsAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("DeleteStudent")]
        public async Task<IActionResult> StudentDelete(StudentIdFilter filter, CancellationToken cancellationToken = default)
        {
            var student = await _studentService.StudentDelete(filter, cancellationToken);

            db.students.Remove(student);
			await db.SaveChangesAsync();

            return Ok(student);
		}
    }
}

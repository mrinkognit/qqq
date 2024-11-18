using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using Project.DataBase;
using Project.Filters.StudentFilters;
using Project.Models;

namespace Project.Interfaces.StudenstInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);

        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);

        public Task<Student[]> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken);
        
        public Task<Student> StudentUpdate(StudentUpdateFilter filter, CancellationToken cancellationToken);

        public Task<Student> StudentDelete(StudentIdFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentFIOFiltersAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbCotext _dbContext;
        public StudentService(StudentDbCotext dbContext)
        {
            _dbContext = dbContext;
        }

		public Task<Student[]> GetStudentByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken)
        {
			var students = _dbContext.Set<Student>().Where(w => w.Group.GroupId == filter.GroupId).ToArrayAsync(cancellationToken);

            return students;
		}

		public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.LastName == filter.Name).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken)
        {
            var students = _dbContext.Set<Student>().Where(w => w.IsDeleted == filter.IsDelete).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentFIOFiltersAsync(StudentFIOFilter filter, CancellationToken cancellationToken)
        {
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.FirstName &&
                                                             w.MiddleName == filter.MiddleName &&
                                                             w.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student> StudentUpdate(StudentUpdateFilter filter, CancellationToken cancellationToken = default)
		{
			var student = _dbContext.Set<Student>().Where(w => w.StudentId == filter.StudentId).FirstAsync();

			//_dbContext.Update(student);

			return student;
		}

        public Task<Student> StudentDelete(StudentIdFilter filter, CancellationToken cancellationToken = default)
        {
            var student = _dbContext.Set<Student>().Where(w=>w.StudentId == filter.StudentId).FirstAsync();

            return student;
        }

        public Task GetStudentFIOFilterAsync(StudentFIOFilter filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

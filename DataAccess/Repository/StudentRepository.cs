using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid id)
        {
            var result = _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return await result != null;
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
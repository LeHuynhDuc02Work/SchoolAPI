using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid id)
        {
            var result = _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            return await result != null;
        }

        public async Task<Subject> GetSubjectById(Guid id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
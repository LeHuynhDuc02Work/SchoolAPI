using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid id)
        {
            var result = _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            return await result != null;
        }

        public async Task<Class> GetClassById(Guid id)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
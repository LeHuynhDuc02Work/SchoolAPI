using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
            => _context.Set<T>();

        public async Task Create(T entity)
            => await _db.AddAsync(entity);

        public void Update(T entity)
           => _db.Update(entity);

        public void Delete(T entity)
            => _db.Remove(entity);

        public async Task<bool> SaveChange()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
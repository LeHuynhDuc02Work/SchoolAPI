namespace DataAccess.Repository.Common
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        public Task Create(T entity);

        public void Delete(T entity);

        public void Update(T entity);

        Task<bool> SaveChange();
    }
}
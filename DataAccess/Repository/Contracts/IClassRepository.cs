using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        Task<Class> GetClassById(Guid id);
        Task<bool> Exists(Guid id);
    }
}
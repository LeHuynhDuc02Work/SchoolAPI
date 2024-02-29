using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<Subject> GetSubjectById(Guid id);

        Task<bool> Exists(Guid id);
    }
}
using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetStudentById(Guid id);
        Task<bool> Exists(Guid id);
    }
}
using DataAccess.Repository.Contracts;

namespace Application.Contracts
{
    public interface IUnitOfWork
    {
        IClassRepository ClassRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IStudentRepository StudentRepository { get; }
        IResultRepository ResultRepository { get; }
    }
}
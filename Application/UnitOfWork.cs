using Application.Contracts;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Contracts;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IResultRepository _resultRepository;
        private IClassRepository _classRepository;
        private ISubjectRepository _subjectRepository;
        private IStudentRepository _studentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IClassRepository ClassRepository => _classRepository ??= new ClassRepository(_context);

        public ISubjectRepository SubjectRepository => _subjectRepository ??= new SubjectRepository(_context);

        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);

        public IResultRepository ResultRepository => _resultRepository ??= new ResultRepository(_context);
    }
}
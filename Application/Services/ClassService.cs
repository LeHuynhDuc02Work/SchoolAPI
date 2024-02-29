using Application.Contracts;
using Application.Dtos;
using Application.Exceptions;
using Application.Helpers;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClassViewDto> Create(ClassDto classCreate)
        {
            if (classCreate == null)
                throw new ApplicationException("NoContent");

            var _class = _mapper.Map<Class>(classCreate);
            await _unitOfWork.ClassRepository.Create(_class);
            await _unitOfWork.ClassRepository.SaveChange();

            return _mapper.Map<ClassViewDto>(_class);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.ClassRepository.Exists(id))
                throw new CustomException("NotFound");

            var _class = await _unitOfWork.ClassRepository.GetClassById(id);
            _unitOfWork.ClassRepository.Delete(_class);

            return await _unitOfWork.ClassRepository.SaveChange();
        }

        public async Task<List<StudentViewDto>> GetStudents(Guid id, InputSearchDto inputSearch)
        {
            var students = _unitOfWork.StudentRepository.GetAll()
             .Include(s => s.Class)
             .Include(s => s.Results)
                 .ThenInclude(r => r.Subject)
             .Where(s => s.ClassId == id);
            var studentsSearch = students.Where(x => x.FullName.Contains(inputSearch.search) ||
                                                x.Results.Any(y => y.Subject.Name.Contains(inputSearch.search)));
            var pagination = new PaginationHelper<Student>();
            var studentsPagin = pagination.Paginate(studentsSearch, inputSearch.page, inputSearch.pageSize);
            var studentsMap = _mapper.Map<List<StudentViewDto>>(studentsPagin);
            return studentsMap;
        }

        public async Task<StudentViewDto> GetStudenHighestPointInClass(string className)
        {
            var student = await _unitOfWork.StudentRepository.GetAll()
            .Include(s => s.Class)
            .Include(s => s.Results)
                .ThenInclude(r => r.Subject)
            .Where(s => s.Class.Name == className)
            .OrderByDescending(s => s.Results.Max(r => r.Point))
            .FirstOrDefaultAsync();

            var studentsMap = _mapper.Map<StudentViewDto>(student);
            return studentsMap;
        }

        public async Task<double> GetAveragePointOfClass(string className)
        {
            var averagePoint = await _unitOfWork.ResultRepository.GetAll()
                .Include(r => r.Class)
            .Where(r => r.Class.Name == className)
            .AverageAsync(r => r.Point);

            return averagePoint;
        }

        public async Task<ClassViewDto> Update(Guid id, ClassDto classUpdate)
        {
            if (!await _unitOfWork.ClassRepository.Exists(id) || classUpdate == null)
                throw new ApplicationException("NotFound or NoContent");

            var _class = await _unitOfWork.ClassRepository.GetClassById(id);
            _class.Name = classUpdate.Name;
            _class.HomeroomTeacher = classUpdate.HomeroomTeacher;
            _class.FacultyId = classUpdate.FacultyId;
            _unitOfWork.ClassRepository.Update(_class);
            await _unitOfWork.ClassRepository.SaveChange();

            return _mapper.Map<ClassViewDto>(_class);
        }
    }
}
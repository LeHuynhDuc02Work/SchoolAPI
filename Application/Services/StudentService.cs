using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentViewDto> Create(StudentDto studentCreate)
        {
            if (studentCreate == null)
                throw new ApplicationException("NoContent");

            var _student = _mapper.Map<Student>(studentCreate);
            await _unitOfWork.StudentRepository.Create(_student);
            await _unitOfWork.StudentRepository.SaveChange();

            return _mapper.Map<StudentViewDto>(_student);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.StudentRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _student = await _unitOfWork.StudentRepository.GetStudentById(id);
            _unitOfWork.StudentRepository.Delete(_student);

            return await _unitOfWork.StudentRepository.SaveChange();
        }

        public async Task<List<StudentViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var students = _unitOfWork.StudentRepository.GetAll()
                .Include(x => x.Class)
                .Where(x => x.FullName.Contains(inputSearch.search) && x.Class.Name.Contains(inputSearch.search));
            var studentsMap = _mapper.Map<List<StudentViewDto>>(students);
            var pagination = new PaginationHelper<StudentViewDto>();
            var studentPagination = pagination.Paginate(studentsMap, inputSearch.page, inputSearch.pageSize);
            return studentPagination.ToList();
        }

        public async Task<StudentViewDto> Update(Guid id, StudentDto studentUpdate)
        {
            if (!await _unitOfWork.StudentRepository.Exists(id) || studentUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _student = await _unitOfWork.StudentRepository.GetStudentById(id);
            _student.FullName = studentUpdate.FullName;
            _student.Address = studentUpdate.Address;
            _student.Gender = studentUpdate.Gender;
            _student.Email = studentUpdate.Email;
            _student.ClassId = studentUpdate.ClassId;
            _unitOfWork.StudentRepository.Update(_student);
            await _unitOfWork.StudentRepository.SaveChange();

            return _mapper.Map<StudentViewDto>(_student);
        }
    }
}
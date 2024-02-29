using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectViewDto> Create(SubjectDto subjectCreate)
        {
            if (subjectCreate == null)
                throw new ApplicationException("NoContent");

            var _subject = _mapper.Map<Subject>(subjectCreate);
            await _unitOfWork.SubjectRepository.Create(_subject);
            await _unitOfWork.SubjectRepository.SaveChange();

            return _mapper.Map<SubjectViewDto>(_subject);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.SubjectRepository.Exists(id))
                throw new ApplicationException("Notfound");

            var _subject = await _unitOfWork.SubjectRepository.GetSubjectById(id);
            _unitOfWork.SubjectRepository.Delete(_subject);

            return await _unitOfWork.SubjectRepository.SaveChange();
        }

        public async Task<List<StudentViewDto>> GetStudentsBySubject(string subjectName, string gender)
        {
            var students = await _unitOfWork.StudentRepository.GetAll()
                .Include(x => x.Results)
                    .ThenInclude(tx => tx.Subject)
                .Where(q => q.Gender == gender && q.Results.Any(x => x.Subject.Name.Contains(subjectName)))
                .ToListAsync();
            return _mapper.Map<List<StudentViewDto>>(students);
        }

        public async Task<List<SubjectViewDto>> GetSubjects(int subjectNumber)
        {
            if (subjectNumber == 0)
                return _mapper.Map<List<SubjectViewDto>>(_unitOfWork.SubjectRepository.GetAll().Include(x => x.Results).OrderBy(s => s.Results.Count));
            var ostEnrolledSubject = await _unitOfWork.SubjectRepository.GetAll()
                .Include(x => x.Results)
                .OrderByDescending(s => s.Results.Count)
                .Take(subjectNumber)
                .ToListAsync();
            return _mapper.Map<List<SubjectViewDto>>(ostEnrolledSubject);
        }

        public async Task<SubjectViewDto> Update(Guid id, SubjectDto subjectUpdate)
        {
            if (!await _unitOfWork.SubjectRepository.Exists(id) || subjectUpdate == null)
                throw new ApplicationException("NoConten or NotFound");

            var _subject = await _unitOfWork.SubjectRepository.GetSubjectById(id);

            _subject.Name = subjectUpdate.Name;
            _subject.NumberOfCredits = subjectUpdate.NumberOfCredits;
            _unitOfWork.SubjectRepository.Update(_subject);

            await _unitOfWork.SubjectRepository.SaveChange();

            return _mapper.Map<SubjectViewDto>(_subject);
        }
    }
}
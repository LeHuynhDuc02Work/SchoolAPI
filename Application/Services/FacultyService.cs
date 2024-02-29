using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SubjectViewDto>> GetSubjectsOfFaculty(string facultyName)
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAll()
                .Include(x => x.Results)
                    .ThenInclude(tx => tx.Class)
                        .ThenInclude(x => x.Faculty)
                .Where(q => q.Results.Any(a => a.Class.Faculty.Name.Contains(facultyName)))
                .ToListAsync();
            return _mapper.Map<List<SubjectViewDto>>(subjects);
        }
    }
}
using Application.Dtos;
using Core;

namespace Application.Contracts
{
    public interface IFacultyService
    {
        Task<List<SubjectViewDto>> GetSubjectsOfFaculty(string facultyName);
    }
}
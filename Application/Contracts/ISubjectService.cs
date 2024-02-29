using Application.Dtos;
using Core;

namespace Application.Contracts
{
    public interface ISubjectService
    {
        Task<List<SubjectViewDto>> GetSubjects(int SubjectNumber);
        Task<List<StudentViewDto>> GetStudentsBySubject(string subjectName, string gender);
        Task<SubjectViewDto> Create(SubjectDto classCreate);

        Task<SubjectViewDto> Update(Guid id, SubjectDto classUpdate);

        Task<bool> Delete(Guid id);
    }
}
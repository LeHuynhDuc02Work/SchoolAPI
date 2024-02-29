using Application.Dtos;

namespace Application.Contracts
{
    public interface IClassService
    {
        Task<List<StudentViewDto>> GetStudents(Guid id, InputSearchDto inputSearch);
        Task<StudentViewDto> GetStudenHighestPointInClass(string className);
        Task<double> GetAveragePointOfClass(string className);
        Task<ClassViewDto> Create(ClassDto classCreate);
        Task<ClassViewDto> Update(Guid id,ClassDto classUpdate);
        Task<bool> Delete(Guid id);
    }
}
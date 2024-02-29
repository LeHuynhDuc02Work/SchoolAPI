using Application.Dtos;

namespace Application.Contracts
{
    public interface IStudentService
    {
        Task<List<StudentViewDto>> GetAll(InputSearchDto inputSearch);
        Task<StudentViewDto> Create(StudentDto studentCreate);

        Task<StudentViewDto> Update(Guid id, StudentDto studentUpdate);

        Task<bool> Delete(Guid id);
    }
}
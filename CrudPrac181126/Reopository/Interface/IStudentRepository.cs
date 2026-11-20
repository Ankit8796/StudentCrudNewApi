using CrudPrac181126.Dtos;

namespace CrudPrac181126.Reopository.Interface
{
    public interface IStudentRepository
    {
        Task<List<StudentDetailsDto>> GetAllStudentsAsync();

        Task<ReturnMessageDto> CreateStudentAsync(StudentCreateDto studentCreateDto);

        Task<ReturnMessageDto> UpdateStudentAsync(StudentUpdateDto dto);


        Task<ReturnMessageDto> DeleteStudentAsync(int studentId);
    }
}

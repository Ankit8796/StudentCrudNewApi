using CrudPrac181126.Data;
using CrudPrac181126.Dtos;
using CrudPrac181126.Entity;
using CrudPrac181126.Reopository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudPrac181126.Reopository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<ReturnMessageDto> CreateStudentAsync(StudentCreateDto studentCreateDto)
        {
            try
            {
                bool emailExists = await _dbContext.Students
                                   .AnyAsync(s => s.Email == studentCreateDto.Email);

                if (emailExists)
                {
                    return new ReturnMessageDto
                    {
                        Success = false,
                        Message = "Email already exists."
                    };
                }

                var student = new Student
                {
                    FirstName = studentCreateDto.FirstName,
                    LastName = studentCreateDto.LastName,
                    Email = studentCreateDto.Email,
                    PhoneNumber = studentCreateDto.PhoneNumber,
                    Gender = studentCreateDto.Gender,
                    DateOfBirth = studentCreateDto.DateOfBirth,
                    IsActive = true
                };

                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return new ReturnMessageDto
                {
                    Success = true,
                    Message = "Student created successfully."
                };
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public async Task<ReturnMessageDto> DeleteStudentAsync(int studentId)
        {
           var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId && s.IsActive==true&&s.IsDeleted==false);
            if (existingStudent == null)
            {
                return new ReturnMessageDto
                {
                    Success = false,
                    Message = "Student not found."
                };
            }
             existingStudent.IsDeleted = true;
            existingStudent.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return new ReturnMessageDto
            {
                Success = true,
                Message = "Student deleted successfully."
            };
        }

        public async Task<PagedResult<StudentDetailsDto>> GetAllStudentsAsync(FilterStudentDto filter)
        {
            var studentData =  _dbContext.Students.Where(s => s.IsActive == true && s.IsDeleted == false).Select(s => new StudentDetailsDto
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth
            });

            var pageSize = 10;
            var totalCount = await studentData.CountAsync();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var pageNumber = filter.PageNumber <= 0 ? 1 : filter.PageNumber;

            if (pageNumber > totalPages)
            {
                if (totalPages == 0)
                {
                    pageNumber = 1;
                }
                else
                {
                    pageNumber = totalPages;
                }
            }

            var pagedData = await studentData.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<StudentDetailsDto>
            {
                Data = pagedData,
                TotalRecords = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

        }

        public async Task<ReturnMessageDto> UpdateStudentAsync(StudentUpdateDto dto)
        {
            var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == dto.StudentId && s.IsDeleted==false);
            if (existingStudent == null)
            {
                return new ReturnMessageDto
                {
                    Success = false,
                    Message = "Student not found."
                };
            }

            existingStudent.FirstName = dto.FirstName;
            existingStudent.LastName = dto.LastName;
            existingStudent.Email = dto.Email;
            existingStudent.PhoneNumber = dto.PhoneNumber;
            existingStudent.Gender = dto.Gender;
            existingStudent.DateOfBirth = dto.DateOfBirth;

            await _dbContext.SaveChangesAsync();
            return new ReturnMessageDto
            {
                Success = true,
                Message = "Student updated successfully."
            };
        }
    }
}

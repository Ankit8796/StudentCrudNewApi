using CrudPrac181126.Dtos;
using CrudPrac181126.Reopository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudPrac181126.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("GetStudentDetails")]

        public async Task<IActionResult> GetStudentDetails()
        {
            var studentDetails = await _studentRepository.GetAllStudentsAsync();
            return Ok(studentDetails);
        }

        [HttpPost("CreateStudent")]

        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto studentCreateDto)
        {
            var result = await _studentRepository.CreateStudentAsync(studentCreateDto);
            if (result.Success)
            {
                return Ok(new { success=true,message=result.Message });
            }
            return BadRequest(new { 
            success=false,message=result.Message
            });
        }

        [HttpPut("UpdateStudent")]

        public async Task<IActionResult> UpdateStudent([FromBody] StudentUpdateDto studentUpdateDto)
        {
            var result = await _studentRepository.UpdateStudentAsync(studentUpdateDto);
            if (result.Success)
            {
                return Ok(new { success=true,message=result.Message });
            }
            return BadRequest(new { 
            success=false,message=result.Message
            });
        }

        [HttpDelete("DeleteStudent/{studentId}")]

        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var result = await _studentRepository.DeleteStudentAsync(studentId);
            if (result.Success)
            {
                return Ok(new { success=true,message=result.Message });
            }
            return BadRequest(new { 
            success=false,message=result.Message
            });
        }


    }
}

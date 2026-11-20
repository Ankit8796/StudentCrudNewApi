using System.ComponentModel.DataAnnotations;
using static CrudPrac181126.Enums.Enum;

namespace CrudPrac181126.Dtos
{
    public class StudentDetailsDto
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public Gender Gender { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }


    }

    public class StudentCreateDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        [EmailAddress]
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
    }

    public class StudentUpdateDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
    }

    public class ReturnMessageDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; } 
    }
}

using static CrudPrac181126.Enums.Enum;

namespace CrudPrac181126.Entity
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public Gender Gender { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        //public string Course { get; set; } = default!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}

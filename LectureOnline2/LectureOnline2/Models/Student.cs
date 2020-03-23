using System.ComponentModel.DataAnnotations;

namespace LectureOnline2.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        [Required(ErrorMessage = "You should specify the First Name")]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
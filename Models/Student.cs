using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký dự")]
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime Birthday { get; set; }

        public string? Major {get; set;}
    }
}

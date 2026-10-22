using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoMVC.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        public string StudentId { get; set; }


        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký dự")]
        public string? FullName { get; set; }
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Năm nhập học")]
        public int EnrollmentYear { get;set;} = DateTime.Now.Year;

        [Display(Name = "Hệ đào tạo")]
        public string TrainingType { get;set;} = "21";

        [Required(ErrorMessage = "Vui lòng chọn Khoa")]
        [Display(Name = "Khoa/Ngành")]
        public string FacultyId {get;set;} = string.Empty;

        [ForeignKey("FacultyId")]
        public Faculty? Faculty { get; set;}
    }
}


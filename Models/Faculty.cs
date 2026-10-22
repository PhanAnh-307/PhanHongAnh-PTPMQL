using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;

namespace DemoMVC.Models
{
    public class Faculty
    {
    [Key]
    [Display(Name = "Mã Khoa/Ngành")]
    [StringLength(10)]
    public string FacultyId {get;set;} = string.Empty;

    [Display(Name = "Tên Khoa/Ngành")]
    public string FacultyName {get;set;} = string.Empty;

    public ICollection<Student>? Students {get;set;}
    }

}

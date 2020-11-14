
using System;
using System.ComponentModel.DataAnnotations;

namespace Day09_Validation.Models
{
    public class Employee
    {
        public Guid? Id { get; set; }
        [Display(Name = "Mã nhân viên")]
        public string EmployeeId { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "*")]
        [MaxLength(150, ErrorMessage = "Tối đa 150 kí tự")]
        public string FullName { get; set; }

        [EmailAddress]        
        public string Email { get; set; }
        
        [Url]
        public string Website { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Lương")]
        public double Salary { get; set; }
    }
}

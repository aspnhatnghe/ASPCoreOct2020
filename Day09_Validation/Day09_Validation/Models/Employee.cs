
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Day09_Validation.Models
{
    public enum Gender
    {
        //Male, Female
        //M, F
        Nam, Nữ, Khác
    }

    public class Employee
    {
        [Display(Name ="Giới tính")]
        public Gender Gender { get; set; }

        public Guid? Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Remote(action:"KiemTraMaNhanVien", controller:"Demo", ErrorMessage ="Mã này đã có")]
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
        [KiemTraNgaySinhNhanVien]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lương")]
        [Range(0, double.MaxValue, ErrorMessage = "Lương không âm")]
        public double Salary { get; set; }

        [Display(Name = "Nhân viên bán thời gian")]
        public bool IsPartTime { get; set; }

        //[Phone]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [MaxLength(255, ErrorMessage = "Tối đa 255 kí tự")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}

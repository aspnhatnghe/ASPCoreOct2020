using System;
using System.ComponentModel.DataAnnotations;

namespace Day09_Validation.Models
{
    public class KiemTraNgaySinhNhanVienAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var ngaySinh = (DateTime)value;

                if (DateTime.Now.Year - ngaySinh.Year < 10)
                {
                    return new ValidationResult("Chưa đủ tuổi để đăng ký");
                }
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Dữ liệu không hợp lệ");
            }
        }
    }
}
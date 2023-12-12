using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Input {0} should not empty")]
        public string ProfileImage { get; set; }
        [Required]
        public string Department { get; set; }
        [Required(ErrorMessage = "Input {0} should not empty")]
        public string Gender { get; set; }
        [Required]
        public long Salary { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}

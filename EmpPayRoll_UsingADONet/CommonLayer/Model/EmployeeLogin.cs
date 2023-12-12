using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage = "Input {0} should not empty")]
        public int EmpLoginId { get; set; }

        [Required(ErrorMessage = "Input {0} should not empty")]
        [DataType(DataType.Password)]
        public string EmpLoginName { get; set; }
    }
}

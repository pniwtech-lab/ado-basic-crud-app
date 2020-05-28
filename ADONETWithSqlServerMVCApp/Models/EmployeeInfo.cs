using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADONETWithSqlServerMVCApp.Models
{
    public class EmployeeInfo
    {
        public int Emp_id { get; set; }

        [Display(Name = "Employee Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        // Here is used Indian Zip code format regex which is of 6-digits.
        [Display(Name = "Pin Code")]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Please enter valid 6 digit pin code.")]
        [Required]
        public int Pin_code { get; set; }

        [Display(Name = "Designation")]
        [Required]
        public string Designation { get; set; }
    }
}
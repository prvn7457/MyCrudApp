using MyCrudApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrudApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Please enter email address!")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please choose department")]
        public Dept Department { get; set; }
        [Required(ErrorMessage = "Please choose gender")]
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }

    }
}

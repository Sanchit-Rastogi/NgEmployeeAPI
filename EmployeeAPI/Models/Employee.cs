using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Office { get; set; }

        public string SkypeId { get; set; }
    }
}

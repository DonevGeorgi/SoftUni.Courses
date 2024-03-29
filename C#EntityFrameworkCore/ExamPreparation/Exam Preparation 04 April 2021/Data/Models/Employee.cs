﻿using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee() 
        {
            EmployeesTasks = new List<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone {  get; set; }
        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set;}
    }
}

//•	Id – integer, Primary Key
//•	Username – text with length [3, 40].Should contain only lower or upper case letters and/or digits. (required) ^[A-Za-z\d]+$
//•	Email – text (required). Validate it! There is attribute for this job.
//•	Phone – text. Consists only of three groups (separated by '-'),
//the first two consist of three digits and the last one – of 4 digits. (required) ^\d{3}\-\d{3}\-\d{4}$
//•	EmployeesTasks – collection of type EmployeeTask


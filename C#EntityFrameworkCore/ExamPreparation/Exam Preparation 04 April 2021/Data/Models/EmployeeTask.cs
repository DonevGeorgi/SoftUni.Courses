using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        [Required]
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }
    }
}

//•	EmployeeId – integer, Primary Key, foreign key (required)
//•	Employee – Employee
//•	TaskId – integer, Primary Key, foreign key (required)
//•	Task – Task

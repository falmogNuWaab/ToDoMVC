using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage ="Name Cannot be longer than 20 characters")]
        public string FullName { get; set; }
        [Range(0,40, ErrorMessage ="Hours cannot exceed 40")]
        public float Hours { get; set; }
        [MaxLength(40,ErrorMessage ="Title cannot be longer than 40 characters")]
        public string Title { get; set; }
        [Range(0, 40, ErrorMessage = "Assigned hours from tasks cannot exceed 40")]
        public float AvailHours { get; set; } = 40;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string TName { get; set; }
        [MaxLength(100)]
        public string TDescription { get; set; }
        //Foreign Key that will refer to the employee table
        public int AssignedTo { get; set; }
        public float HoursNeeded { get; set; }
        public bool IsCompleted { get; set; }
        public List<Employee> AllEmployees { get; set; }
    }
}

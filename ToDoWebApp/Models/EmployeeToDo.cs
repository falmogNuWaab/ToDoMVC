using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class EmployeeToDo
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ToDoItemId { get; set; }
        //Foreign Keys follow
        public Employee Employee { get; set; }
        public ToDoItem ToDo { get; set; }

    }
}

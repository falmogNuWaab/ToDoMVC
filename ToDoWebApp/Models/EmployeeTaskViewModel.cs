using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class EmployeeTaskViewModel
    {
        //A View Model is created to only exist on views
        //Commonly they are used to show up multiple model classes at once
        //Or to move around small pieces of data
        public List<ToDoItem> ToDos { get; set; }
        public List<Employee> Employees { get; set; }

        public EmployeeTaskViewModel()
        {
            ToDoDAL todoDB = new ToDoDAL();
            EmployeeDAL EmployeeDB = new EmployeeDAL();
            ToDos = todoDB.GetToDoItems();
            Employees = EmployeeDB.GetEmployees();
        }
    }
}

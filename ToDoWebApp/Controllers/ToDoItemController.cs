using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class ToDoItemController : Controller
    {
        ToDoDAL db = new ToDoDAL();
        EmployeeDAL eDB = new EmployeeDAL();
        EmployeeToDoDAL etDB = new EmployeeToDoDAL();
        public IActionResult Index()
        {
            List<ToDoItem> tds = db.GetToDoItems();
            return View(tds);
        }
        public IActionResult Create()
        {
            ToDoItem t = new ToDoItem();
            t.AllEmployees = eDB.GetEmployees();
            return View(t);           
        }
        [HttpPost]
        public IActionResult Create(ToDoItem t)
        {
            Employee e = eDB.GetEmployee(t.AssignedTo);
            if (ModelState.IsValid && e.AvailHours>=t.HoursNeeded)
            {                
                db.CreateToDoItem(t);
                e.AvailHours -= t.HoursNeeded;
                eDB.UpdateEmployee(e);
                return RedirectToAction("Index", "ToDoItem");
            }
            else
            {
                return View(t);
            }
        }
        public IActionResult Update(int id)
        {
            ToDoItem toUpdate = db.GetToDoItemByItemId(id);
            toUpdate.AllEmployees = eDB.GetEmployees();
            return View(toUpdate);
        }
        [HttpPost]
        public IActionResult Update(ToDoItem td)
        {
            db.UpdateToDoItem(td);
            return RedirectToAction("Index", "ToDoItem");
        }

        public IActionResult AssignTask()
        {
            EmployeeTaskViewModel evtm = new EmployeeTaskViewModel();
            return View(evtm);
        }

        [HttpPost]
        public IActionResult AssignTask(int toDoId, int employeeId)
        {
            EmployeeToDo a = new EmployeeToDo();
            a.EmployeeId = employeeId;
            a.ToDoItemId = toDoId;
            Employee e = eDB.GetEmployee(employeeId);
            ToDoItem t = db.GetToDoItemByItemId(toDoId);
            if (e.AvailHours >= t.HoursNeeded)
            {
                e.AvailHours -= t.HoursNeeded;
                etDB.AssignToDoItems(a);
                eDB.UpdateEmployee(e);
                return RedirectToAction("Index", "ToDoItem");
            }
            else
            {
                return View();
            }
        }
        public IActionResult MarkComplete(int id)
        {
            ToDoItem t = db.GetToDoItemByItemId(id);
            return View(t);
        }

        public IActionResult CompletionConfirmed(int id)
        {
            db.MarkToDoItemCompleted(id);
            return RedirectToAction("Index", "ToDoItem");
        }
    }
}

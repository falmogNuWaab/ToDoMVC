using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL db = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> allEmployees = db.GetEmployees();
            return View(allEmployees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.CreateEmployee(e);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(e);
            }
        }
        public IActionResult Update(int id)
        {
            Employee e = db.GetEmployee(id);
            return View(e);
        }
        [HttpPost]
        public IActionResult Update(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.UpdateEmployee(e);
                return RedirectToAction("Index", "Employee");
            }
            else
            { 
                return View(e);
            }
        }        
        public IActionResult Delete(int id)
        {
            Employee e = db.GetEmployee(id);
            return View(e);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            db.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}

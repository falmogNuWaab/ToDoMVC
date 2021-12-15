using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class EmployeeDAL
    {
        //CREATE
        public void CreateEmployee(Employee e)
        {
            string insertString = $"insert into employees values(0,'{e.FullName}',{e.Hours},'{e.Title}',40)";
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                connect.Query<Employee>(insertString);
                connect.Close();
            }
        }
        //READ
        public Employee GetEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from employees where id={id}";
                connect.Open();
                Employee e = connect.Query<Employee>(sql).First();
                connect.Close();

                return e;

            }
        }
        public List<Employee> GetEmployees()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from employees";
                connect.Open();
                List<Employee> eList = connect.Query<Employee>(sql).ToList();
                connect.Close();

                return eList;
            }
        }

        //UPDATE
        public void UpdateEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string updateString = $"update employees set fullname='{e.FullName}', hours={e.Hours}, title='{e.Title}', availhours={e.AvailHours} where id={e.Id}";
                connect.Open();
                connect.Query<Employee>(updateString);
                connect.Close();
            }

        }

        //DESTROY
        public void DeleteEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string deleteString = $"delete from employees where id={id}";
                connect.Open();
                connect.Query<Employee>(deleteString);
                connect.Close();
            }
        }
    }
}

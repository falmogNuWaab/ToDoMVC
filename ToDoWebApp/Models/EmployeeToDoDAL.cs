using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class EmployeeToDoDAL
    {
        public void AssignToDoItems(EmployeeToDo e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into employeetodoitems values(0,{e.EmployeeId},{e.ToDoItemId})";
                string updateToDoRecord = $"update todos set assignedto={e.EmployeeId} where id={e.ToDoItemId}";
                connect.Open();
                connect.Query<EmployeeToDo>(sql);
                connect.Query<ToDoItem>(updateToDoRecord);
                connect.Close();
            }
        }
    }
}

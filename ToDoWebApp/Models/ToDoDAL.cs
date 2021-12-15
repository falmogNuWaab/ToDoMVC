using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ToDoWebApp.Models
{
    public class ToDoDAL
    {
        //CREATE

        public void CreateToDoItem(ToDoItem t)
        {
            string insertString = $"insert into todos values(0,'{t.TName}','{t.TDescription}',{t.AssignedTo},{t.HoursNeeded},{t.IsCompleted})";
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                connect.Query<ToDoItem>(insertString);
                connect.Close();
            }
            
        }
        //READ
        public List<ToDoItem> GetToDoItems()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todos";
                connect.Open();
                List<ToDoItem> tdl = connect.Query<ToDoItem>(sql).ToList();
                connect.Close();

                return tdl;
            }
        }
        public List<ToDoItem> GetToDoItemsByEmployeeId(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todos where assignedto=" + id;
                connect.Open();
                List<ToDoItem> tds = connect.Query<ToDoItem>(sql).ToList();
                connect.Close();

                return tds;
            }
        }
        public ToDoItem GetToDoItemByItemId(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todos where id=" + id;
                connect.Open();
                ToDoItem td = connect.Query<ToDoItem>(sql).First();
                connect.Close();

                return td;
            }
        }

        //UPDATE
        public void UpdateToDoItem(ToDoItem t)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string updateString = $"update todos set tname='{t.TName}',tdescription='{t.TDescription}',hoursneeded={t.HoursNeeded},iscompleted={t.IsCompleted}";
                connect.Open();
                connect.Query<ToDoItem>(updateString);
                connect.Close();

            }   
        }


        //DESTROY
        //Not actually destroying the data here, just completing tasks. Build specs do not ask for a way to delete info from todo table.
        public void MarkToDoItemCompleted(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update todos set iscompleted=1 where id={id}";
                connect.Open();
                connect.Query<ToDoItem>(sql);
                connect.Close();
            }
        }

    }
}

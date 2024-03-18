using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using TodoApp.src.Models;

namespace TodoApp.src.Utils
{
    public static class TodoUtil
    {
        static string connectionString = "Server=192.168.10.10;Database=TodoDb;User Id=developer2;Password=Developer@2;";

        public static void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public static List<Todo> GetAllTodos() 
        {
            List<Todo> todos = new List<Todo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllTodos", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Todo todo = new Todo();
                    todo.title = Convert.ToString(reader["title"]);
                    todo.description = Convert.ToString(reader["description"]);
                    todo.isCompleted = Convert.ToBoolean(reader["isCompleted"]);
                    todo.dateTime = Convert.ToDateTime(reader["dateTime"]);

                    todos.Add(todo);
                }
            }
            return todos;
        }
        public static void InsertTodo(Todo todo)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@title", todo.title),
                new SqlParameter("@description", todo.description),
                new SqlParameter("@isCompleted", todo.isCompleted),
                new SqlParameter("@dateTime", todo.dateTime)
            };
            ExecuteStoredProcedure("InsertTodo", parameters);
            Console.WriteLine("Todo inserted successfully.");
        }

    }
}


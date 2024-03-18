using System;
using System.Collections.Generic;
using System.Windows;
using TodoApp.src.Utils;
using TodoApp.src.Models;
using System.Windows.Controls;

namespace TodoApp.src.Views
{
    public partial class TodoView : Page
    {
        public List<Todo> Todos { get; set; }
        public TodoView()
        {
            InitializeComponent();
            DataContext = this;
            FetchAllTodos();
        }

        public void FetchAllTodos() {
            Todos = TodoUtil.GetAllTodos();
            foreach (Todo todo in Todos)
            {
                Console.WriteLine($"Title: {todo.title}, Description: {todo.description}  Completed: {todo.isCompleted}  Time: {todo.dateTime}");
            }
        }

        public void OpenAddTodo(object sender, RoutedEventArgs e) 
        {
            //AddTodoClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}

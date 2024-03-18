using System;
using System.Windows;
using System.Windows.Controls;
using TodoApp.src.Models;
using TodoApp.src.Utils;

namespace TodoApp.src.Views
{
    public partial class AddTodoView : Page
    {
        private string enteredTitle = string.Empty;
        private string enteredDescription = string.Empty;
        public AddTodoView()
        {
            InitializeComponent();
        }

        private void todo_title_TextChanged(object sender, TextChangedEventArgs e)
        {
            enteredTitle = todo_title.Text;
        }

        private void todo_description_TextChanged(object sender, TextChangedEventArgs e)
        {
            enteredDescription = todo_description.Text;
        }

        private void AddTodoToDb(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"{enteredTitle} {enteredDescription}");
            Todo newTodo = new Todo();
            newTodo.title = enteredTitle;
            newTodo.description = enteredDescription;
            newTodo.dateTime = DateTime.Now;
            TodoUtil.InsertTodo(newTodo);
        }
    }
}

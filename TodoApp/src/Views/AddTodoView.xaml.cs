using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

using System.Windows;
using TodoApp.src.Views;

namespace TodoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowFrame.Content = new TodoView();
        }

        private void ShowAddTodoPage(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new AddTodoView();
        }

        private void ShowAllTodoPage(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new TodoView();
        }
    }
}

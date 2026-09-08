using System.Windows;
using TODOApp.ViewModels;

namespace TODOApp;

public partial class MainWindow : Window
{
    MainViewModel viewModel = new MainViewModel();

    public MainWindow()
    {
        InitializeComponent();

        TodoList.ItemsSource = viewModel.Todos;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        viewModel.AddTodo(TodoText.Text);

        TodoText.Clear();
    }
}
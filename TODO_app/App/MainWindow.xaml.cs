using System.Windows;
using System.Windows.Controls;
using TODOApp.Models;
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

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;

        TodoItem todo = (TodoItem)button.DataContext;

        viewModel.RemoveTodo(todo);
    }
}
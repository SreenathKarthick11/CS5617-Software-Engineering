using System.Collections.ObjectModel;
using TODOApp.Models;

namespace TODOApp.ViewModels;

public class MainViewModel
{
    public ObservableCollection<TodoItem> Todos { get; set; }

    public MainViewModel()
    {
        Todos = new ObservableCollection<TodoItem>();
    }

    public void AddTodo(string text)
    {
        Todos.Add(new TodoItem(text));
    }

    public void RemoveTodo(TodoItem todo)
    {
        Todos.Remove(todo);
    }
}
namespace Todo_App.Models;

public class TodoItem
{
    public string Text { get; set; }

    public TodoItem(string text)
    {
        Text = text;
    }
}
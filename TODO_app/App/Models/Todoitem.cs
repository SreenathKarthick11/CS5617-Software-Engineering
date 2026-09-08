namespace TODOApp.Models;

public class TodoItem
{
    public string Text { get; set; }

    public TodoItem(string text)
    {
        Text = text;
    }
}
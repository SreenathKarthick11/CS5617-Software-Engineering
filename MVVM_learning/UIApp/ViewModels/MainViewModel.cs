using System.ComponentModel;
using System.Windows.Input;

namespace UIApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private int greetingCount = 0;
    private string greeting = string.Empty;
    private string name = string.Empty;

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public string Greeting
    {
        get => greeting;
        private set
        {
            greeting = value;
            OnPropertyChanged(nameof(Greeting));
        }
    }

    public ICommand SayHelloCommand { get; }

    public ICommand ClearCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        SayHelloCommand = new SimpleCommand(SayHello);
        ClearCommand = new SimpleCommand(Clear);
    }

    public void SayHello()
    {
        greetingCount++;

        Greeting =
            $"Hello! {Name} " +
            $"You have greeted {greetingCount} times.";
    }

    public void Clear()
    {
        greetingCount = 0;
        Name = string.Empty;
        Greeting = string.Empty;
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}
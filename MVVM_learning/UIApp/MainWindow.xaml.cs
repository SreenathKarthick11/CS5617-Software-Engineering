using Microsoft.UI.Xaml;
using UIApp.ViewModels;

namespace UIApp;

public sealed partial class MainWindow : Window
{
    private MainViewModel ViewModel { get; } = new();

    public MainWindow()
    {
        InitializeComponent();

        RootPanel.DataContext = ViewModel;
    }
}
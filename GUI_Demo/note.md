# GUI Demo

A simple Windows Presentation Foundation (WPF) application demonstrating basic UI controls and event handling in C#.

## Goal

Get familiar with **WPF**, XAML layout, and event-driven programming by building a simple GUI application.

The application demonstrates:
- **UI Layout**: Using `Grid` and `StackPanel` containers
- **Controls**: `TextBlock`, `Button`, and `Label`
- **Event Handling**: Button click events that modify UI elements
- **Basic Interactivity**: Responding to user input

## Folder Structure

```text
GUI_Demo
├── Gui_app
│   ├── App.xaml                 # Application entry point (XAML)
│   ├── App.xaml.cs              # Application code-behind
│   ├── AssemblyInfo.cs          # Assembly metadata
│   ├── Gui_app.csproj           # Project file
│   ├── MainWindow.xaml          # Main window UI (XAML)
│   └── MainWindow.xaml.cs       # Main window logic
└── gui_demo.sln                 # Solution file
```

---

## Controllers and Containers

### Containers
Containers are UI elements that **hold and arrange** other controls. They define the layout structure of your application.

Common WPF containers include:
- **Grid**: Arranges content in rows and columns (most flexible)
- **StackPanel**: Stacks children vertically or horizontally
- **WrapPanel**: Wraps content to the next line when space runs out
- **DockPanel**: Docks children to edges (top, bottom, left, right)

**Example from this project**:
```xml
<Grid>
    <StackPanel Width="200" Background="Blue" Height="100">
        <TextBlock Name="name_text_box" Text="hello" />
        <Button Content="Click me" Click="Button_Click" />
    </StackPanel>
    <StackPanel HorizontalAlignment="Left" Background="Green">
        <Label Content="" />
    </StackPanel>
</Grid>
```
Here, `Grid` is the **root container**, and two `StackPanel` containers are nested inside it to arrange child controls.

### Controllers
In WPF, **controllers** are the **code-behind** files (`.xaml.cs`) that handle user interactions and application logic. They:

- **Respond to events** (e.g., button clicks)
- **Update UI elements** programmatically
- **Manage application state**

**Example**: `MainWindow.xaml.cs` contains:
```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    name_text_box.Text = "Button was clicked!";
}
```
This controller method changes the `TextBlock` content when the button is clicked, demonstrating **event-driven behavior**.

---

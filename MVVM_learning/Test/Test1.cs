using Microsoft.VisualStudio.TestTools.UnitTesting;
using UIApp.ViewModels;

namespace UIApp.Tests;

[TestClass]
public class MainViewModelTests
{
    [TestMethod]
    public void SayHello_UpdatesGreeting()
    {
        // Arrange
        var viewModel = new MainViewModel();
        viewModel.Name = "Sreenath";

        // Act
        viewModel.SayHello();

        // Assert
        Assert.AreEqual(
            "Hello! Sreenath You have greeted 1 times.",
            viewModel.Greeting);
    }
}
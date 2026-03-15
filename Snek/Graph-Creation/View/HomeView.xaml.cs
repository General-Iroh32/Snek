using Snek.Presentation;
using System.Windows;
using System.Windows.Controls;

namespace Snek.Graph_Creation;

public partial class HomeView : UserControl
{
    public HomeView() => InitializeComponent();

    private void CreateGraphButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is { } window)
        {
            GraphNavigation.CreateGraph(window);
        }
    }

    private void OpenGraphButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is { } window)
        {
            GraphNavigation.OpenGraph(window);
        }
    }

    private void SnakeButton_Click(object sender, RoutedEventArgs e) =>
        new Window1 { Owner = Window.GetWindow(this) }.Show();
}

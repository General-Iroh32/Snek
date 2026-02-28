using Snek.Graph_Creation.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Create_Graph : Window
{
    public Create_Graph(Create_Graph_ViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void closeApp(object sender, MouseButtonEventArgs e) => Close();

    private void minimizeApp(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;
}

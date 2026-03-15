using Snek.Graph_Creation.ViewModel;
using Snek.Presentation;
using System.Windows;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Create_Graph : VsWindow
{
    public Create_Graph(Create_Graph_ViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        PreviewKeyDown += OnPreviewKeyDown;
    }

    private void OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
        {
            GraphNavigation.CreateGraph(this);
            e.Handled = true;
        }
        else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
        {
            GraphNavigation.OpenGraph(this);
            e.Handled = true;
        }
    }
}

using Snek.Core.Graphs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Create_Graph_Type : Window
{
    public Create_Graph_Type() => InitializeComponent();

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void closeApp(object sender, MouseButtonEventArgs e) => Close();

    private void minimizeApp(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (lst.SelectedItem is not ListBoxItem { Content: Button { Content: string displayName } }
            || !GraphTypeExtensions.TryParseDisplayName(displayName, out var type))
        {
            MessageBox.Show("Bitte einen unterstützten Graphentyp auswählen.");
            return;
        }

        new Graph_Input(type).Show();
        Close();
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
        Buttond.IsEnabled = lst.SelectedItem is ListBoxItem { Content: Button };
}

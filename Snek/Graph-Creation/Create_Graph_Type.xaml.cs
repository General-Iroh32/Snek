using Snek.Core.Graphs;
using Snek.Presentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Create_Graph_Type : VsWindow
{
    public Create_Graph_Type() => InitializeComponent();

    private void GraphTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
        ContinueButton.IsEnabled = GraphTypeList.SelectedItem is ListBoxItem;

    private void GraphTypeList_MouseDoubleClick(object sender, MouseButtonEventArgs e) => OpenSelectedType();

    private void ContinueButton_Click(object sender, RoutedEventArgs e) => OpenSelectedType();

    private void BackButton_Click(object sender, RoutedEventArgs e) => GraphNavigation.ShowMain(this);

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            OpenSelectedType();
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            GraphNavigation.ShowMain(this);
            e.Handled = true;
        }
    }

    private void OpenSelectedType()
    {
        if (GraphTypeList.SelectedItem is not ListBoxItem { Tag: string displayName }
            || !GraphTypeExtensions.TryParseDisplayName(displayName, out var type))
        {
            return;
        }

        new Graph_Input(type).Show();
        Close();
    }
}

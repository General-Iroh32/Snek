using Snek.Core.Graphs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Graph_Input : Window
{
    private readonly GraphType _type;
    private readonly GraphValueParser _valueParser;

    public Graph_Input(GraphType type)
    {
        _type = type;
        _valueParser = App.GetRequiredService<GraphValueParser>();
        InitializeComponent();
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

    private void Buttone_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var inputs = new[]
            {
                TB1.Text, TB2.Text, TB3.Text, TB4.Text,
                TB5.Text, TB6.Text, TB7.Text, TB8.Text,
                TB9.Text, TB10.Text, TB11.Text, TB12.Text,
                TB13.Text, TB14.Text, TB15.Text, TB16.Text
            };
            var document = new GraphDocument(_type, _valueParser.Parse(inputs));
            new Graph_Creator(document).Show();
            Close();
        }
        catch (FormatException exception)
        {
            MessageBox.Show(exception.Message, "Ungültige Werte", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void Buttonb_Click(object sender, RoutedEventArgs e)
    {
        new Create_Graph_Type().Show();
        Close();
    }
}

using Microsoft.Win32;
using Snek.Core.Graphs;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Snek.Graph_Creation;

public partial class HomeView : UserControl
{
    private readonly GraphDocumentSerializer _serializer = App.GetRequiredService<GraphDocumentSerializer>();

    public HomeView() => InitializeComponent();

    private void Button_Click(object sender, RoutedEventArgs e) => Window.GetWindow(this)?.Close();

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        new Create_Graph_Type().Show();
        Window.GetWindow(this)?.Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Snek-Dateien (*.snek)|*.snek" };
        if (dialog.ShowDialog() != true)
        {
            return;
        }

        try
        {
            var document = _serializer.Deserialize(File.ReadAllText(dialog.FileName));
            new Graph_Creator(document).Show();
            Window.GetWindow(this)?.Close();
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or FormatException)
        {
            MessageBox.Show(exception.Message, "Datei konnte nicht geöffnet werden", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void Button_Click_3(object sender, RoutedEventArgs e) => new Window1().Show();
}

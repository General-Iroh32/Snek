using Microsoft.Win32;
using Snek.Core.Graphs;
using Snek.Graph_Creation;
using System.IO;
using System.Windows;

namespace Snek.Presentation;

internal static class GraphNavigation
{
    public static void CreateGraph(Window currentWindow)
    {
        new Create_Graph_Type().Show();
        currentWindow.Close();
    }

    public static void OpenGraph(Window currentWindow)
    {
        var dialog = new OpenFileDialog
        {
            Title = "Snek-Graph öffnen",
            Filter = "Snek-Dateien (*.snek)|*.snek",
            CheckFileExists = true,
            Multiselect = false
        };

        if (dialog.ShowDialog(currentWindow) != true)
        {
            return;
        }

        try
        {
            var serializer = App.GetRequiredService<GraphDocumentSerializer>();
            var document = serializer.Deserialize(File.ReadAllText(dialog.FileName));
            new Graph_Creator(document).Show();
            currentWindow.Close();
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or FormatException)
        {
            MessageBox.Show(
                currentWindow,
                exception.Message,
                "Graph konnte nicht geöffnet werden",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }

    public static void ShowMain(Window currentWindow)
    {
        App.GetRequiredService<Create_Graph>().Show();
        currentWindow.Close();
    }
}

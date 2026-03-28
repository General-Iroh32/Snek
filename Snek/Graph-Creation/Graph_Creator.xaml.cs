using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Win32;
using SkiaSharp;
using Snek.Core.Graphs;
using Snek.Presentation;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snek.Graph_Creation;

public partial class Graph_Creator : VsWindow
{
    private static readonly SKColor AccentColor = new(0, 122, 204);
    private readonly GraphDocument _document;
    private readonly GraphDocumentSerializer _serializer;

    public Graph_Creator(GraphDocument document)
    {
        _document = document;
        _serializer = App.GetRequiredService<GraphDocumentSerializer>();

        InitializeComponent();
        GraphTitleText.Text = document.Type.ToDisplayName();
        GraphSummaryText.Text = document.Values.Count == 1 ? "1 Datenpunkt" : $"{document.Values.Count} Datenpunkte";
        ConfigureChart();
    }

    private void ConfigureChart()
    {
        var stroke = new SolidColorPaint(AccentColor, 3);
        var fill = new SolidColorPaint(AccentColor.WithAlpha(105));

        switch (_document.Type)
        {
            case GraphType.Line:
            case GraphType.VerticalLine:
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new LineSeries<double>
                {
                    Values = _document.Values,
                    Stroke = stroke,
                    Fill = fill,
                    GeometryFill = new SolidColorPaint(AccentColor),
                    GeometryStroke = new SolidColorPaint(SKColors.White, 1),
                    Name = "Werte"
                }];
                break;
            case GraphType.Column:
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new ColumnSeries<double>
                {
                    Values = _document.Values,
                    Stroke = stroke,
                    Fill = fill,
                    Name = "Werte"
                }];
                break;
            case GraphType.Row:
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new RowSeries<double>
                {
                    Values = _document.Values,
                    Stroke = stroke,
                    Fill = fill,
                    Name = "Werte"
                }];
                break;
            case GraphType.Pie:
            case GraphType.Doughnut:
                Chart2.Visibility = Visibility.Visible;
                Chart2.Series = CreatePieSeries(_document.Values, _document.Type == GraphType.Doughnut);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static IEnumerable<ISeries> CreatePieSeries(IEnumerable<double> values, bool isDoughnut)
    {
        var palette = new[]
        {
            new SKColor(0, 122, 204),
            new SKColor(78, 201, 176),
            new SKColor(220, 220, 170),
            new SKColor(197, 134, 192),
            new SKColor(206, 145, 120),
            new SKColor(86, 156, 214)
        };

        return values.Select((value, index) => (ISeries)new PieSeries<double>
        {
            Values = [value],
            Fill = new SolidColorPaint(palette[index % palette.Length].WithAlpha(220)),
            Stroke = new SolidColorPaint(new SKColor(30, 30, 30), 2),
            InnerRadius = isDoughnut ? 120 : 0,
            Name = $"Wert {index + 1}"
        }).ToArray();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var input = new Graph_Input(_document.Type, _document.Values);
        input.Show();
        Close();
    }

    private void NewButton_Click(object sender, RoutedEventArgs e) => GraphNavigation.CreateGraph(this);

    private void HomeButton_Click(object sender, RoutedEventArgs e) => GraphNavigation.ShowMain(this);

    private void ExportButton_Click(object sender, RoutedEventArgs e) => ExportChart();

    private void SaveButton_Click(object sender, RoutedEventArgs e) => SaveDocument();

    private void ExportChart()
    {
        var saveDialog = new SaveFileDialog
        {
            Title = "Graph als Bild exportieren",
            Filter = "PNG-Bild (*.png)|*.png",
            FileName = "snek-graph.png",
            DefaultExt = ".png",
            AddExtension = true
        };

        if (saveDialog.ShowDialog() != true)
        {
            return;
        }

        try
        {
            FrameworkElement chart = _document.Type is GraphType.Pie or GraphType.Doughnut ? Chart2 : Chart1;
            SaveToPng(chart, saveDialog.FileName);
            StatusText.Text = $"PNG exportiert: {Path.GetFileName(saveDialog.FileName)}";
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
        {
            ShowFileError(exception, "Bild konnte nicht exportiert werden");
        }
    }

    private static void SaveToPng(FrameworkElement visual, string fileName)
    {
        var width = Math.Max(1, (int)visual.ActualWidth);
        var height = Math.Max(1, (int)visual.ActualHeight);
        var bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(visual);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using var stream = File.Create(fileName);
        encoder.Save(stream);
    }

    private void SaveDocument()
    {
        var saveDialog = new SaveFileDialog
        {
            Title = "Snek-Datei speichern",
            Filter = "Snek-Dateien (*.snek)|*.snek",
            FileName = "graph.snek",
            DefaultExt = ".snek",
            AddExtension = true
        };

        if (saveDialog.ShowDialog() != true)
        {
            return;
        }

        try
        {
            File.WriteAllText(saveDialog.FileName, _serializer.Serialize(_document));
            StatusText.Text = $"Gespeichert: {Path.GetFileName(saveDialog.FileName)}";
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
        {
            ShowFileError(exception, "Datei konnte nicht gespeichert werden");
        }
    }

    private static void ShowFileError(Exception exception, string title) =>
        MessageBox.Show(exception.Message, title, MessageBoxButton.OK, MessageBoxImage.Warning);

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
        {
            SaveDocument();
            e.Handled = true;
        }
        else if (e.Key == Key.S && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
        {
            ExportChart();
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            GraphNavigation.ShowMain(this);
            e.Handled = true;
        }
    }
}

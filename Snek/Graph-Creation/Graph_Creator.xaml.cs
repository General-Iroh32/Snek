using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Win32;
using SkiaSharp;
using Snek.Core.Graphs;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snek.Graph_Creation;

public partial class Graph_Creator : Window
{
    private static readonly SKColor AccentColor = new(50, 205, 50);
    private readonly GraphDocument _document;
    private readonly GraphDocumentSerializer _serializer;

    public Graph_Creator(GraphDocument document)
    {
        _document = document;
        _serializer = App.GetRequiredService<GraphDocumentSerializer>();

        InitializeComponent();
        ConfigureChart();
    }

    private void ConfigureChart()
    {
        var stroke = new SolidColorPaint(AccentColor, 3);
        var fill = new SolidColorPaint(AccentColor.WithAlpha(178));

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
                    Name = string.Empty
                }];
                break;
            case GraphType.Column:
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new ColumnSeries<double>
                {
                    Values = _document.Values,
                    Stroke = stroke,
                    Fill = fill,
                    Name = string.Empty
                }];
                break;
            case GraphType.Row:
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new RowSeries<double>
                {
                    Values = _document.Values,
                    Stroke = stroke,
                    Fill = fill,
                    Name = string.Empty
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
            new SKColor(50, 205, 50),
            new SKColor(45, 156, 219),
            new SKColor(255, 193, 7),
            new SKColor(236, 70, 70),
            new SKColor(156, 89, 182)
        };

        return values.Select((value, index) => (ISeries)new PieSeries<double>
        {
            Values = [value],
            Fill = new SolidColorPaint(palette[index % palette.Length].WithAlpha(210)),
            Stroke = new SolidColorPaint(AccentColor, 2),
            InnerRadius = isDoughnut ? 120 : 0,
            Name = $"Wert {index + 1}"
        }).ToArray();
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        new Graph_Input(_document.Type).Show();
        Close();
    }

    private void TakeTheChart()
    {
        var saveDialog = new SaveFileDialog
        {
            Title = "Bild exportieren",
            Filter = "PNG-Bild (*.png)|*.png",
            DefaultExt = ".png",
            AddExtension = true
        };

        if (saveDialog.ShowDialog() == true)
        {
            SaveToPng(_document.Type is GraphType.Pie or GraphType.Doughnut ? Chart2 : Chart1, saveDialog.FileName);
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

    private void Button_Click_1(object sender, RoutedEventArgs e) => TakeTheChart();

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var saveDialog = new SaveFileDialog
        {
            Title = "Snek-Datei speichern",
            Filter = "Snek-Dateien (*.snek)|*.snek",
            DefaultExt = ".snek",
            AddExtension = true
        };

        if (saveDialog.ShowDialog() != true)
        {
            return;
        }

        File.WriteAllText(saveDialog.FileName, _serializer.Serialize(_document));
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        App.GetRequiredService<Create_Graph>().Show();
        Close();
    }
}

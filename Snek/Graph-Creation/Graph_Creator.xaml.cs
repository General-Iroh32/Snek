using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Win32;
using SkiaSharp;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snek.Graph_Creation;

public partial class Graph_Creator : Window
{
    private static readonly SKColor AccentColor = new(50, 205, 50);
    private readonly IReadOnlyList<double> _principalValues;
    private readonly string _type;

    public Graph_Creator(string type, IEnumerable<double> principalValues)
    {
        _type = type.Trim();
        _principalValues = principalValues.ToArray();

        InitializeComponent();
        ConfigureChart();
    }

    private void ConfigureChart()
    {
        var stroke = new SolidColorPaint(AccentColor, 3);
        var fill = new SolidColorPaint(AccentColor.WithAlpha(178));

        switch (_type)
        {
            case "Line Series":
            case "Vertical Line Series":
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new LineSeries<double>
                {
                    Values = _principalValues,
                    Stroke = stroke,
                    Fill = fill,
                    Name = string.Empty
                }];
                break;
            case "Column Series":
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new ColumnSeries<double>
                {
                    Values = _principalValues,
                    Stroke = stroke,
                    Fill = fill,
                    Name = string.Empty
                }];
                break;
            case "Row Series":
                Chart1.Visibility = Visibility.Visible;
                Chart1.Series = [new RowSeries<double>
                {
                    Values = _principalValues,
                    Stroke = stroke,
                    Fill = fill,
                    Name = string.Empty
                }];
                break;
            case "Pie Chart":
            case "Doughnut":
                Chart2.Visibility = Visibility.Visible;
                Chart2.Series = CreatePieSeries(_principalValues, _type == "Doughnut");
                break;
            default:
                test.Text = $"Unbekannter Graphentyp: {_type}";
                break;
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
        new Graph_Input(_type).Show();
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
            SaveToPng(_type is "Pie Chart" or "Doughnut" ? Chart2 : Chart1, saveDialog.FileName);
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

        using var writer = File.CreateText(saveDialog.FileName);
        writer.WriteLine(_type);
        foreach (var value in _principalValues)
        {
            writer.WriteLine(value);
        }
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        new Create_Graph().Show();
        Close();
    }
}

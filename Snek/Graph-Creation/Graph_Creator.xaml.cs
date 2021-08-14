using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snek.Graph_Creation
{
    /// <summary>
    /// Interaction logic for Graph_Creator.xaml
    /// </summary>
    public partial class Graph_Creator : Window
    {
        string type = "";
        ChartValues<double> PrincipalValues = new ChartValues<double>();

        public Graph_Creator(string t, List<double> Principal)
        {
            type = t.Trim();

            PrincipalValues.AddRange(Principal);
            InitializeComponent();
            switch (type)
            {
                case "Line Series":
                    Chart1.Visibility = Visibility.Visible;
                    Chart1.Series.Add(new LineSeries
                    {
                        Values = PrincipalValues,
                        Stroke = Brushes.LightGreen,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(50, 205, 50),
                            Opacity = 0.7
                        },
                        Title = ""
                    });
                    break;
                case "Column Series":
                    Chart1.Visibility = Visibility.Visible;
                    Chart1.Series.Add(new ColumnSeries
                    {
                        Values = PrincipalValues,
                        Stroke = Brushes.LightGreen,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(50, 205, 50),
                            Opacity = 0.7
                        },
                        Title = ""
                    });
                    break;
                case "Vertical Line Series":
                    Chart1.Visibility = Visibility.Visible;
                    Chart1.Series.Add(new VerticalLineSeries
                    {
                        Values = PrincipalValues,
                        Stroke = Brushes.LightGreen,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(50, 205, 50),
                            Opacity = 0.7
                        },
                        Title = ""
                    });
                    break;
                case "Row Series":
                    Chart1.Visibility = Visibility.Visible;
                    Chart1.Series.Add(new RowSeries
                    {
                        Values = PrincipalValues,
                        Stroke = Brushes.LightGreen,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(50, 205, 50),
                            Opacity = 0.7
                        },
                        Title = ""
                    });
                    break;

                case "Pie Chart":
                    Chart2.Visibility = Visibility.Visible;
                    Random ran = new Random();
                    foreach (double i in Principal)
                    {
                        byte b1 = (byte)ran.Next(1, 255);
                        byte b2 = (byte)ran.Next(1, 255);
                        byte b3 = (byte)ran.Next(1, 255);

                        int xx = (int)i;

                        Chart2.Series.Add(new PieSeries
                        {
                            Values = new ChartValues<ObservableValue> { new ObservableValue(xx) },
                            Stroke = Brushes.LightGreen,
                            Fill = new SolidColorBrush


                            {

                                Color = System.Windows.Media.Color.FromRgb(b1, b2, b3),
                                Opacity = 0.7
                            },

                        });
                    }

                    break;
                case "Doughnut":
                    Chart2.Visibility = Visibility.Visible;
                    Chart2.InnerRadius = 120;
                    Random ran1 = new Random();
                    foreach (double i in Principal)
                    {
                        byte b1 = (byte)ran1.Next(1, 255);
                        byte b2 = (byte)ran1.Next(1, 255);
                        byte b3 = (byte)ran1.Next(1, 255);

                        int xx = (int)i;

                        Chart2.Series.Add(new PieSeries
                        {
                            Values = new ChartValues<ObservableValue> { new ObservableValue(xx) },
                            Stroke = Brushes.LightGreen,
                            Fill = new SolidColorBrush


                            {

                                Color = System.Windows.Media.Color.FromRgb(b1, b2, b3),
                                Opacity = 0.7
                            },

                        });
                    }

                    break;
                default:
                    test.Text = type;
                    break;

            }



        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Graph_Input graph_Creator = new Graph_Input(type);
            graph_Creator.Show();
            this.Close();
        }
        public void TakeTheChart(string type)
        {
            if (type == "Pie Chart" || type == "Doughnut")
            {

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save";
                saveDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
                if (saveDialog.ShowDialog() == true)
                {
                    string file = saveDialog.FileName;
                    SaveToPng(Chart2, file);
                }

            }
            else
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save";
                saveDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
                if (saveDialog.ShowDialog() == true)
                {
                    string file = saveDialog.FileName;
                    SaveToPng(Chart1, file);
                }

            }

        }

        public void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight + 100, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TakeTheChart(type);
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Snek Files (*.snek)|*.snek";
            if (saveDialog.ShowDialog() == true)
            {
                string file = saveDialog.FileName;

                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine(type);
                    foreach (double d in PrincipalValues)
                    {


                        sw.WriteLine(d);

                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Create_Graph graph_Creator = new Create_Graph();
            graph_Creator.Show();
            this.Close();
        }
    }
}



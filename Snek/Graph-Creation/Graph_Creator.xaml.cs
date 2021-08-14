using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Input;

namespace Snek.Graph_Creation
{
    /// <summary>
    /// Interaction logic for Graph_Creator.xaml
    /// </summary>
    public partial class Graph_Creator : Window
    {
        string type = "";


        public Graph_Creator(string t)
        {
            type = t;
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }



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
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
    }
}

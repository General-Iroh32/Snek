using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Snek.Graph_Creation
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Create_Graph_Type main = new Create_Graph_Type();
            main.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            string s = "";
            string t = "";
            List<double> f = new List<double>();

            openFileDlg.Filter = "Snek Files (*.snek)|*.snek";
            if (openFileDlg.ShowDialog() == true)
            {
                string file = openFileDlg.FileName;
                using (StreamReader sr = File.OpenText(file))
                {

                    t = sr.ReadLine();
                    while ((s = sr.ReadLine()) != null)
                    {
                        f.Add(double.Parse(s));
                    }
                }
                Graph_Creator graph_Creator = new Graph_Creator(t, f);
                graph_Creator.Show();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 graph_Creator = new Window1();
            graph_Creator.Show();

        }
    }
}

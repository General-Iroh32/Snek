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
    }
}

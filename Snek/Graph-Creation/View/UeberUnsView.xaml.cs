using System.Windows;
using System.Windows.Controls;

namespace Snek.Graph_Creation.View
{
    /// <summary>
    /// Interaction logic for UeberUnsView.xaml
    /// </summary>
    public partial class UeberUnsView : UserControl
    {
        public UeberUnsView()
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
    }
}

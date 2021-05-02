using System;
using System.Windows;
using System.Windows.Input;

namespace Snek.Graph_Creation
{
    /// <summary>
    /// Interaction logic for Create_Graph_Type.xaml
    /// </summary>
    public partial class Create_Graph_Type : Window
    {
        public Create_Graph_Type()
        {
            InitializeComponent();
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


    }
}

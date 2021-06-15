using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snek.Graph_Creation
{
    /// <summary>
    /// Interaction logic for Graph_Input.xaml
    /// </summary>
    public partial class Graph_Input : Window
    {
        string t = "";
        List<double> PrincipalValues = new List<double>();
        public Graph_Input(string text)
        {
            t = text;
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
        public static string ExtractNumbersOnly(string s)
        {
            Match match = Regex.Match(s, "^[0-9]+$");

            return match.Value;
        }
        private void Buttone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var boxes = new TextBox[,]
{
     { TB1, TB2, TB3,TB4,TB5, TB6, TB7,TB8,TB9, TB10, TB11,TB12,TB13, TB14, TB15,TB16 } };
                foreach (TextBox x in boxes)
                {
                    if (x.Text != "0")
                    {
                        PrincipalValues.Add(double.Parse(ExtractNumbersOnly(x.Text)));

                    }
                }
                Graph_Creator graph_Creator = new Graph_Creator(t, PrincipalValues);
                graph_Creator.Show();
                this.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show("Werte falsch");
            }

        }

        private void Buttonb_Click(object sender, RoutedEventArgs e)
        {
            Create_Graph_Type graph_Creator = new Create_Graph_Type();
            graph_Creator.Show();
            this.Close();
        }
    }
}

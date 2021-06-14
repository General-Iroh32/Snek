using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
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
                if (TB1.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB1.Text))); }
                if (TB2.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB2.Text))); }
                if (TB3.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB3.Text))); }
                if (TB4.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB4.Text))); }
                if (TB5.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB5.Text))); }
                if (TB6.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB6.Text))); }
                if (TB7.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB7.Text))); }
                if (TB8.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB8.Text))); }
                if (TB9.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB9.Text))); }
                if (TB10.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB10.Text))); }
                if (TB11.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB11.Text))); }
                if (TB12.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB12.Text))); }
                if (TB13.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB13.Text))); }
                if (TB14.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB14.Text))); }
                if (TB15.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB15.Text))); }
                if (TB16.Text == "0") { }
                else { PrincipalValues.Add(double.Parse(ExtractNumbersOnly(TB16.Text))); }
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

using System;
using System.Windows;
using System.Windows.Input;

namespace Snek
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Vorname.Text != "" && Vorname.Text != "Vorname")
            {
                if (Nachname.Text != "" && Nachname.Text != "Nachname")
                {
                    if (Datum.SelectedDate.HasValue && Datum.SelectedDate.Value <= DateTime.UtcNow)
                    {
                        if (Email.Text != "" && Email.Text != "E-Mail" && Email.Text.Contains("@") && Email.Text.Contains("."))
                        {
                            if (Telefonnummer.Text != "" && Telefonnummer.Text != "Telefonnummer" && Telefonnummer.Text.Length <= 15)
                            {
                                Register2 register = new Register2(Vorname.Text, Nachname.Text, Datum.SelectedDate.Value, Email.Text, Telefonnummer.Text);
                                register.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Telefonnummer ist ungültig");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email ist ungültig");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datum ist ungültig");
                    }
                }
                else
                {
                    MessageBox.Show("Nachname ist ungültig");
                }
            }
            else
            {
                MessageBox.Show("Vorname ist ungültig");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow register = new MainWindow();
            register.Show();
            this.Close();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Snek
{
    /// <summary>
    /// Interaction logic for Register2.xaml
    /// </summary>
    public partial class Register2 : Window
    {
        private string Vorname = "";
        private string Nachname = "";
        private string Email = "";
        private string Telefonnummer = "";
        private string Datum = "";
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dzova\Desktop\Snek\Snek\Database\Register_Database.mdf;Integrated Security=True;Password=Snek");
        public Register2()
        {
            InitializeComponent();
        }
        public Register2(string Vorname, string Nachname, DateTime Datum, string Email, string Telefonnummer)
        {
            InitializeComponent();
            this.Vorname = Vorname;
            this.Nachname = Nachname;
            this.Datum = Datum.ToString();
            this.Email = Email;
            this.Telefonnummer = Telefonnummer;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Adresse.Text != "" && Adresse.Text != "Adresse")
            {
                if (Geschlecht.SelectedItem != null && Geschlecht.Text != "")
                {
                    if (Username.Text != "" && Username.Text != "Username")
                    {
                        string selectString =
                    "SELECT User_Name " +
                    "FROM [User] " +
                    "WHERE User_Name = '" + Username.Text + "'";

                        SqlCommand mySqlCommand = new SqlCommand(selectString, sqlCon);
                        sqlCon.Open();
                        String strResult = "";
                        strResult = (String)mySqlCommand.ExecuteScalar();
                        sqlCon.Close();

                        if (strResult == null)
                        {

                            if (Passwort.Text != "" && Passwort.Text != "Passwort")
                            {
                                if (ConPasswort.Text != "" && ConPasswort.Text != "Passwort wiederholen" && ConPasswort.Text.Equals(Passwort.Text))
                                {

                                    if (sqlCon.State == ConnectionState.Closed)
                                        sqlCon.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Vorname, Nachname, GebDatum, Email, Telefonnummer, Passwort, User_Name, Adresse, Geschlecht) VALUES (@Vorname, @Nachname, @GebDatum, @Email, @Telefonnummer, @Passwort, @User_Name, @Adresse, @Geschlecht)", sqlCon);

                                    cmd.Parameters.Add("@Vorname", SqlDbType.NVarChar).Value = Vorname;
                                    cmd.Parameters.Add("@Nachname", SqlDbType.NVarChar).Value = Nachname;
                                    cmd.Parameters.Add("@GebDatum", SqlDbType.NVarChar).Value = Datum;
                                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                                    cmd.Parameters.Add("@Telefonnummer", SqlDbType.NVarChar).Value = Telefonnummer;
                                    cmd.Parameters.Add("@Passwort", SqlDbType.NVarChar).Value = Passwort.Text;
                                    cmd.Parameters.Add("@User_Name", SqlDbType.NVarChar).Value = Username.Text;
                                    cmd.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = Adresse.Text;
                                    cmd.Parameters.Add("@Geschlecht", SqlDbType.NVarChar).Value = Geschlecht.Text;

                                    cmd.ExecuteNonQuery();

                                    sqlCon.Close();
                                    MessageBox.Show("Erfolgreich Account erstellt");
                                    MainWindow register = new MainWindow();
                                    register.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Passwort ist nicht gleich");
                                }
                            }

                            else
                            {
                                MessageBox.Show("Passwort ist ungültig");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username ist schon vorhanden");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Username ist ungültig");
                    }
                }

                else
                {
                    MessageBox.Show("Geschlecht ist ungültig");
                }
            }
            else
            {
                MessageBox.Show("Adresse ist ungültig");
            }


        }
    }
}

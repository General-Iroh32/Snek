using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
        private string[] Datum;
        MySqlConnection sqlCon = new MySqlConnection("Data Source=139.177.178.173;Database=snek;Uid=root;Pwd=;");

        public Register2()
        {
            InitializeComponent();
        }
        public Register2(string Vorname, string Nachname, DateTime Datum, string Email, string Telefonnummer)
        {
            InitializeComponent();
            this.Vorname = Vorname;
            this.Nachname = Nachname;
            this.Datum = Datum.ToString().Split(" ");
            this.Email = Email;
            this.Telefonnummer = Telefonnummer;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        public static string EncryptString(string plainInput)
        {
            string key = "b14ca5898a4e4133bbce2ea2315a1916";
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);

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
                    "FROM User " +
                    "WHERE User_Name = '" + Username.Text + "'";

                        MySqlCommand mySqlCommand = new MySqlCommand(selectString, sqlCon);
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


                                    MySqlCommand cmd = new MySqlCommand(@"INSERT INTO User 
                                                                        (Vorname, Nachname, GebDatum, Email, Telefonnummer, Passwort, User_Name, Adresse, Geschlecht) 
                                                                        VALUES (@Vorname, @Nachname, @GebDatum, @Email, @Telefonnummer, @Passwort, @User_Name, @Adresse, @Geschlecht)", sqlCon);
                                    sqlCon.Open();

                                    cmd.Parameters.AddWithValue("@Vorname", Vorname);
                                    cmd.Parameters.AddWithValue("@Nachname", Nachname);
                                    cmd.Parameters.AddWithValue("@GebDatum", Datum[0]);
                                    cmd.Parameters.AddWithValue("@Email", Email);
                                    cmd.Parameters.AddWithValue("@Telefonnummer", Telefonnummer);
                                    cmd.Parameters.AddWithValue("@Passwort", EncryptString(Passwort.Text));
                                    cmd.Parameters.AddWithValue("@User_Name", Username.Text);
                                    cmd.Parameters.AddWithValue("@Adresse", Adresse.Text);
                                    cmd.Parameters.AddWithValue("@Geschlecht", Geschlecht.Text);

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

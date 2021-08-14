using MySql.Data.MySqlClient;
using Snek.Graph_Creation;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Snek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection sqlCon = new MySqlConnection("Data Source=139.177.178.173;Database=snek;Uid=root;Pwd=;");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM User WHERE User_Name=@User_Name AND Passwort=@Passwort";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@User_Name", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Passwort", EncryptString(txtPassword.Password));
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Create_Graph register = new Create_Graph();
                    register.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
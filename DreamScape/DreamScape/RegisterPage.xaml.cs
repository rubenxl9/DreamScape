using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using DreamScape.Data;


namespace DreamScape
{
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();            
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                string Username = UserNameTextBox.Text;
                string email = mailTextBox.Text;
                string password = PasswordTextBox.Password;
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    ErrorTextBlock.Text = "Please fill in all fields";
                    return;
                }
                string hashedPassword = HashPassword(password);

                
                var user = db.Players.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    ErrorTextBlock.Text = "This email is already in use";
                    return;
                }
                else if (db.Players.FirstOrDefault(u => u.Username == Username) != null)
                {
                    ErrorTextBlock.Text = "This username is already in use";
                    return;
                }
                else if (db.Players.FirstOrDefault(u => u.Password == hashedPassword) != null)
                {
                    ErrorTextBlock.Text = "This password is already in use";
                    return;
                }

                Player newUser = new Player
                {
                    Username = Username,
                    Email = email,
                    Password = hashedPassword,
                    role_id = 1
                };

                db.Players.Add(newUser);
                db.SaveChanges();

            }
            Frame.GoBack();

        }
    }
}

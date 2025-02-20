using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using DreamScape.Data;
using DreamScape.Functions;

namespace DreamScape
{
    public sealed partial class LoginWindow : Window
    {
        private int _userId { get; set; }
        public LoginWindow()
        {
            this.InitializeComponent();
            this.Title = "Login Page";
            Fullscreen fullscreenService = new Fullscreen();
            fullscreenService.SetFullscreen(this);
        }
        
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                string email = mailTextBox.Text;
                string password = PasswordTextBox.Password;
                string hashedPassword = HashPassword(password); // Hash the entered password

                // Compare the hashed password with the stored hashed password
                var user = db.Players.FirstOrDefault(u => u.Email == email && u.Password == hashedPassword);

                if (user != null)
                {
                    int roleId = user.role_id;
                    int userId = user.Id;
                    _userId = userId;
                    Player.LoggedInUser = user;

                    switch (roleId)
                    {
                        case 1:
                            //Player
                            break;
                        case 2:
                        //Admin

                        default:
                            ErrorTextBlock.Text = "There is no Role connected with this user. Contact Staff to get this issue solved.";
                            return;
                    }
                }
                else
                {
                    ErrorTextBlock.Text = "E-mail or Password Is incorrect";
                }
                if (Player.LoggedInUser != null && Player.LoggedInUser.role_id == 1)
                {
                    var baseWindow = new PlayerMainWindow();

                    baseWindow.Activate();
                    DispatcherQueue.TryEnqueue(() =>
                    {
                        this.Close();
                    });
                }
                else if (Player.LoggedInUser != null && Player.LoggedInUser.role_id == 2)
                {
                    var baseWindow = new AdminMainWindow();

                    baseWindow.Activate();
                    DispatcherQueue.TryEnqueue(() =>
                    {
                        this.Close();
                    });
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(RegisterPage));

        }
    }
}

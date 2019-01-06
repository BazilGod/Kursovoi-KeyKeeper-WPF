using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace KeyKeeper
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void onRegisterBtnClicked(object sender, RoutedEventArgs e)
        {
            Boolean inputCorrect = this.isInputCorrect(usernameField.Text, passwordField.Password, confirmPasswordField.Password);
            if (inputCorrect)
            {
               bool k = ExistAccount(usernameField.Text);
                if (k)
                {
                    MessageBox.Show("User already exist. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    this.saveData(usernameField.Text, passwordField.Password);
                    this.Close();
                }
            }
            else
            {          
                MessageBox.Show("Incorrect information. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.clearFields(usernameField, passwordField, confirmPasswordField);
            }
        }

        private Boolean isInputCorrect(String username, String password, String confirmPassword)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmPassword))
            {
                return false;
            }
            else if (password != confirmPassword)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void saveData(String username, String password)
        {
            Database Database = Database.getInstance();
            byte[] salt = Crypto.generateSalt();
            byte[] hash = Crypto.HashPassword(password, salt);
            Database.insertUser(username, hash, salt);
        }
        private bool ExistAccount(String username)
        {
            Database Database = Database.getInstance();
            bool result = Database.isExistAccount(username);
            return result;
        }
        private void clearFields(TextBox usernameTextBox, PasswordBox passwordBox, PasswordBox confirmPasswordBox)
        {
            usernameTextBox.Text = "";
            passwordBox.Password = "";
            confirmPasswordBox.Password = "";
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace KeyKeeper
{
    public partial class LoginWindow : Window
    {
        private long userId;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void onLoginClicked(object sender, RoutedEventArgs e)
        {
            String username = usernameTextBox.Text;
            String password = passwordBox.Password;
            Boolean isValid = this.authenticateUser(username, password);
            if (isValid)
            {
                AccountListWindow accountListWindow = new AccountListWindow(this.userId);
                accountListWindow.Show();
                this.Close();
            }
            else
            {
                MessageBoxResult msgBoxResult = MessageBox.Show("Incorrect information. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.clearFields(usernameTextBox, passwordBox);
            }
        }

        private void onRegisterClicked(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private void clearFields(TextBox usernameTextBox, PasswordBox passwordBox)
        {
            usernameTextBox.Text = "";
            passwordBox.Password = "";
        }

        private Boolean authenticateUser(String username, String password)
        {
            Database Database = Database.getInstance();
            List<User> selectedUsers = Database.selectUser(username);
            foreach (User user in selectedUsers)
            {
                if (Crypto.ValidatePassword(password, user.Hash, user.Salt))
                {
                    this.userId = user.Id;
                    return true;
                }
            }
            return false;
        }
    }
}

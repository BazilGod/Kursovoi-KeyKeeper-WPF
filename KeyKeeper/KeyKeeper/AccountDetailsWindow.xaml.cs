using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace KeyKeeper
{
    /// <summary>
    /// Interaction logic for AccountDetailsWindow.xaml
    /// </summary>
    public partial class AccountDetailsWindow : Window
    {
        State currentState;
        public enum State { Add, Edit };
        public AccountDetails accountDetails;
        long userId;
        String hash;

        public AccountDetailsWindow(State state, long userId)
        {
            InitializeComponent();
            this.currentState = state;
            this.userId = userId;
            Database Database = Database.getInstance();
            this.hash = Database.getUserHash(this.userId);
        }

        public AccountDetailsWindow(State state, long accountId, long userId)
        {
            InitializeComponent();
            this.currentState = state;
            this.userId = userId;
            if (this.currentState == State.Edit)
            {
                Database Database = Database.getInstance();
                this.accountDetails = Database.selectWithId(accountId, userId);
                this.hash = Database.getUserHash(this.userId);
                this.fillFields(accountDetails);
            }
        }

        public void onCancelBtnClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void onSaveBtnClicked(object sender, RoutedEventArgs e)
        {
            Database Database = Database.getInstance();
            String passwordText = this.getPasswordFieldText();
            byte[] salt = Crypto.generateSalt();
            String saltString = Convert.ToBase64String(salt);
            String encryptedPassword = Crypto.EncryptStringAES(passwordText, hash, salt);
            Boolean Correct = this.isCorrect(titleField.Text, usernameField.Text, passwordField.Password);
            if (Correct)
            {
                if (this.currentState == State.Add)
                {
                    Database.insert(this.userId, titleField.Text, usernameField.Text, encryptedPassword, saltString);
                }
                if (this.currentState == State.Edit)
                {
                    if (Correct)
                    {
                        AccountDetails updatedAccountDetails = new AccountDetails(this.accountDetails.Id, titleField.Text, usernameField.Text, encryptedPassword, saltString);
                        Database.update(updatedAccountDetails, this.userId);
                    }
                    else
                    {
                        MessageBoxResult msgBoxResult3 = MessageBox.Show("Not inaf information. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                this.Close();
            }
            else
            {
                MessageBoxResult msgBoxResult2 = MessageBox.Show("Not inaf information. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private Boolean isCorrect(String title, String username, String password)
        {
            if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void fillFields(AccountDetails accountDetails)
        {
            titleField.Text = accountDetails.Title;
            usernameField.Text = accountDetails.Username;
            accountDetails.decryptPassword(this.hash);
            passwordField.Password = accountDetails.Password;
        }

        public void onCheckBoxClicked(object sender, RoutedEventArgs e)
        {
            if (passwordCheckBox.IsChecked.HasValue)
            {
                if ((bool)passwordCheckBox.IsChecked)
                {
                    textPasswordField.Text = passwordField.Password;
                    passwordField.Visibility = Visibility.Hidden;
                    textPasswordField.Visibility = Visibility.Visible;
                }
                else
                {
                    passwordField.Password = textPasswordField.Text;
                    textPasswordField.Visibility = Visibility.Hidden;
                    passwordField.Visibility = Visibility.Visible;
                }
            }
        }

        public String getPasswordFieldText()
        {
            if (passwordCheckBox.IsChecked.HasValue && (bool)passwordCheckBox.IsChecked)
            {
                return textPasswordField.Text;
            }
            else
            {
                return passwordField.Password;
            }
        }

        private void OpenWeb(object sender, RoutedEventArgs e)
        {
            string url = titleField.Text;
            if (!(url.StartsWith("http://")) || url.StartsWith("https://"))
                url = "http://" + (url);
            Process.Start(url);
        }

        
    }
}

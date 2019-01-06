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

namespace KeyKeeper
{
    /// <summary>
    /// Interaction logic for AccountListWindow.xaml
    /// </summary>
    public partial class AccountListWindow : Window
    {
        Database Database;
        long userId;

        public AccountListWindow(long userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Database = Database.getInstance();
            this.showAllAccounts();
        }

        private void onAddAccountBtnClicked(object sender, RoutedEventArgs e)
        {
            AccountDetailsWindow accountDetailsWindow = new AccountDetailsWindow(AccountDetailsWindow.State.Add, this.userId);
            accountDetailsWindow.Closed += this.onAccountDetailsWindowClosed;
            accountDetailsWindow.Show();

        }

        private void onAccountDetailsWindowClosed(object sender, EventArgs e)
        {
            this.showAllAccounts();
        }

        public void showAllAccounts()
        {
            List<AccountTitle> accountTitles = this.Database.selectTitles(this.userId);
            if (accountTitles.Count > 0)
            {
                NoAccountsTextField.Visibility = Visibility.Hidden;
                accountListView.Visibility = Visibility.Visible;
                accountListView.ItemsSource = accountTitles;
            }
            else
            {
                NoAccountsTextField.Visibility = Visibility.Visible;
                accountListView.Visibility = Visibility.Hidden;
            }
        }

        public void onEditBtnClicked(object sender, RoutedEventArgs e)
        {
            Button editBtn = (Button)sender;
            AccountTitle accountTitle = (AccountTitle)editBtn.DataContext;
            AccountDetailsWindow accountDetailsWindow = new AccountDetailsWindow(AccountDetailsWindow.State.Edit, accountTitle.id, this.userId);
            accountDetailsWindow.Closed += this.onAccountDetailsWindowClosed;
            accountDetailsWindow.Show();
        }

        public void onDeleteBtnClicked(object sender, RoutedEventArgs e)
        {
            Button deleteBtn = (Button)sender;
            AccountTitle accountTitle = (AccountTitle)deleteBtn.DataContext;
            this.Database.delete(accountTitle.id, this.userId);
            this.showAllAccounts();
        }
    }
}

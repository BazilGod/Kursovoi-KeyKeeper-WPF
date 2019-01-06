using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace KeyKeeper
{
    class Database
    {
        
        SQLiteConnection dbConnection;
       
        String create_accounts_table = "CREATE TABLE accounts (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, user_id INTEGER NOT NULL, title VARCHAR(20), username VARCHAR(20), encrypted_password TEXT, salt TEXT)";
        String insert_account_into_table = "INSERT INTO accounts (user_id, title, username, encrypted_password, salt) VALUES(@user_id, @title, @username, @encrypted_password, @salt)";
        String select_titles = "SELECT id, title FROM accounts WHERE user_id=@user_id";
        String select_account_with_id = "SELECT * FROM accounts WHERE id=@id AND user_id=@user_id";
        String update_account = "UPDATE accounts SET title=@title, username=@username, encrypted_password=@encrypted_password, salt=@salt WHERE id=@id AND user_id=@user_id";
        String delete_account = "DELETE FROM accounts WHERE id=@id AND user_id=@user_id";

        
        String create_users_table = "CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username VARCHAR(20), hash TEXT, salt TEXT)";
        String insert_user = "INSERT INTO users (username, hash, salt) VALUES(@username, @hash, @salt)";
        String select_user = "SELECT * FROM users WHERE username=@username";
        String select_hash = "SELECT hash FROM users WHERE id=@id";
        String select_number = "SELECT COUNT(*) FROM users WHERE username = @username";

        private static Database instance = null;

        public static Database getInstance()
        {
            if (Database.instance == null)
            {
                Database.instance = new Database();
            }
            return Database.instance;
        }

        private Database()
        {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                this.dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                this.dbConnection.Open();

                SQLiteCommand command = new SQLiteCommand(create_accounts_table, dbConnection);
                command.ExecuteNonQuery();

                command = new SQLiteCommand(create_users_table, dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                this.dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                this.dbConnection.Open();
            }

            this.dbConnection.Close();
        }

        public void insert(long userId, String title, String username, String encryptedPassword, String salt)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.insert_account_into_table, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@user_id", userId));
            command.Parameters.Add(new SQLiteParameter("@title", title));
            command.Parameters.Add(new SQLiteParameter("@username", username));
            command.Parameters.Add(new SQLiteParameter("@encrypted_password", encryptedPassword));
            command.Parameters.Add(new SQLiteParameter("@salt", salt));
            command.ExecuteNonQuery();

            this.dbConnection.Close();
        }

        public List<AccountTitle> selectTitles(long userId)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.select_titles, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@user_id", userId));
            SQLiteDataReader reader = command.ExecuteReader();
            List<AccountTitle> accountTitles = new List<AccountTitle>();
            while (reader.Read())
            {
                AccountTitle accountTitle = new AccountTitle((long)reader["id"], (String)reader["title"]);
                accountTitles.Add(accountTitle);
            }
            this.dbConnection.Close();
            return accountTitles;
        }

        public AccountDetails selectWithId(long id, long userId)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.select_account_with_id, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@user_id", userId));
            SQLiteDataReader reader = command.ExecuteReader();
            AccountDetails accountDetails = new AccountDetails();
            while (reader.Read())
            {
                accountDetails.Id = (long)reader["id"];
                accountDetails.Title = (String)reader["title"];
                accountDetails.Username = (String)reader["username"];
                accountDetails.EncryptedPassword = (String)reader["encrypted_password"];
                accountDetails.Salt = (String)reader["salt"];
            }
            this.dbConnection.Close();
            return accountDetails;
        }

        public void update(AccountDetails accountDetails, long userId)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.update_account, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@title", accountDetails.Title));
            command.Parameters.Add(new SQLiteParameter("@username", accountDetails.Username));
            command.Parameters.Add(new SQLiteParameter("@encrypted_password", accountDetails.EncryptedPassword));
            command.Parameters.Add(new SQLiteParameter("@salt", accountDetails.Salt));
            command.Parameters.Add(new SQLiteParameter("@id", accountDetails.Id));
            command.Parameters.Add(new SQLiteParameter("@user_id", userId));
            command.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        public void delete(long id, long userId)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.delete_account, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@user_id", userId));
            command.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        public void insertUser(String username, byte[] hash, byte[] salt)
        {
            this.dbConnection.Open();

            String hashString = Convert.ToBase64String(hash);
            String saltString = Convert.ToBase64String(salt);

            SQLiteCommand command = new SQLiteCommand(this.insert_user, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@username", username));
            command.Parameters.Add(new SQLiteParameter("@hash", hashString));
            command.Parameters.Add(new SQLiteParameter("@salt", saltString));
            command.ExecuteNonQuery();

            this.dbConnection.Close();
        }

        public List<User> selectUser(String username)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.select_user, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@username", username));
            SQLiteDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.Id = (long)reader["id"];
                user.Username = (String)reader["username"];
                user.Hash = (String)reader["hash"];
                user.Salt = (String)reader["salt"];
                users.Add(user);
            }
            this.dbConnection.Close();
            return users;
        }

        public String getUserHash(long id)
        {
            this.dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(this.select_hash, dbConnection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            SQLiteDataReader reader = command.ExecuteReader();
            String hash = "";
            while (reader.Read())
            {
                hash = (String)reader["hash"];
            }
            this.dbConnection.Close();
            return hash;
        }
        public bool isExistAccount(string username)
        {
            this.dbConnection.Open();
            SQLiteCommand checkCommand = new SQLiteCommand(select_number, dbConnection);
            checkCommand.Parameters.AddWithValue("username", username);
            int result;
              result = Convert.ToInt32(checkCommand.ExecuteScalar());
               this.dbConnection.Close();
             
          
           if (result > 0)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyKeeper
{
    public class AccountDetails
    {
        long id;
        String title;
        String username;
        String password;
        String encryptedPassword;
        String salt;

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string EncryptedPassword
        {
            get
            {
                return encryptedPassword;
            }

            set
            {
                encryptedPassword = value;
            }
        }

        public string Salt
        {
            get
            {
                return salt;
            }
            set
            {
                salt = value;
            }
        }

        public AccountDetails() { }

        public AccountDetails(long id, String title, String username, String encryptedPassword, String salt)
        {
            this.id = id;
            this.title = title;
            this.username = username;
            this.encryptedPassword = encryptedPassword;
            this.salt = salt;
        }
        public void decryptPassword(String hash)
        {
            this.Password = Crypto.DecryptStringAES(this.EncryptedPassword, hash, Convert.FromBase64String(this.Salt));
        }
    }
}

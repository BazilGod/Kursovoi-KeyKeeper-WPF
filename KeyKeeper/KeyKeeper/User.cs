using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyKeeper
{
    class User
    {
        long id;
        String username;
        String hash;
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

        public string Hash
        {
            get
            {
                return hash;
            }

            set
            {
                hash = value;
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

        public User()
        {

        }

        public User(long id, String username, String hash)
        {
            Id = id;
            Username = username;
            Hash = hash;
        }
    }
}

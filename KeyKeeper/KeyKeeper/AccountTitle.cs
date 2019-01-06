using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyKeeper
{
    public class AccountTitle
    {
        public long id
        {
            get; set;
        }
        public String title
        {
            get; set;
        }

        public AccountTitle(long id, String title)
        {
            this.id = id;
            this.title = title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeyKeeper
{
    class Program : Application
    {
        [STAThread]
        static void Main()
        {
            System.Threading.Mutex mut;
            bool createdNew;
            string mutName = "KeyKeeper";
            mut = new System.Threading.Mutex(true, mutName, out createdNew);
            if (createdNew)
            {
                new Program();
            }
        }
        public Program()
        {
            StartupUri = new System.Uri("LoginWindow.xaml", UriKind.Relative);
            Run();
        }
    }
}


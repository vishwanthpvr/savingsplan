using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            MainWindow win = new MainWindow();
            //MainForm form = new MainForm();
            win.Show();
            Application.Run(win);
        }
    }
}

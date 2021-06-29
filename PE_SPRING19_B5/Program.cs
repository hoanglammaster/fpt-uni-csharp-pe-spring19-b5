using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Q1
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Form1 Form1s;
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1s = new Form1();
            Application.Run(Form1s);
        }
    }
}

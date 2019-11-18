using System;
using System.Windows.Forms;
using ShopList.View;

namespace ShopList
{
    static class Program
    {
        
        /// The main entry point for the application.
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }
    }
}

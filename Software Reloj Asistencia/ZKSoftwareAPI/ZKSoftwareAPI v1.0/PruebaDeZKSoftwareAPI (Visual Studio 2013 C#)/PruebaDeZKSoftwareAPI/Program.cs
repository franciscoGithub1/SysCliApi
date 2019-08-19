using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PruebaDeZKSoftwareAPI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new AgregarUsuarios());
            Application.Run(new AgregarUsuarios());

        }
    }
}

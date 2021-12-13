using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Opcion.MenuEnsayos;
using Presentation.Opcion.MenuEnsayos.Pruebas;
using Presentation.Opcion;
using Presentation.Informe;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

    }
}

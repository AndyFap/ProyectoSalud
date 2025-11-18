using ProyectoSalud.ProyectoSalud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSalud
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var db = new Database();
            if (!db.TestConnection(out var err))
            {
                MessageBox.Show("No se pudo conectar a la base de datos.\nError: " + err, "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Si quieres detener la app cuando falla la conexión, descomenta la siguiente línea:
                // return;
            }
            else
            {
                // Mensaje de confirmación solo mientras pruebas; eliminar en producción
                MessageBox.Show("Conexión a la base de datos: OK", "Prueba conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application.Run(new Form1());
        }
    }
}

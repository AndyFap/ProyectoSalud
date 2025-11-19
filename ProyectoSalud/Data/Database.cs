using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;

namespace ProyectoSalud.ProyectoSalud.Data
{
    internal class Database
    {
        private readonly string conexion;

        public Database()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["ConexionBD"];
            
            if (connectionStringSettings == null)
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la cadena de conexión 'ConexionBD' en App.config. " +
                    "Asegúrese de que el archivo App.config contiene la sección <connectionStrings> " +
                    "con un elemento llamado 'ConexionBD'.");
            }
            
            conexion = connectionStringSettings.ConnectionString;
            
            if (string.IsNullOrWhiteSpace(conexion))
            {
                throw new ConfigurationErrorsException(
                    "La cadena de conexión 'ConexionBD' está vacía en App.config.");
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(conexion);
        }

        public bool TestConnection(out string error)
        {
            error = null;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}

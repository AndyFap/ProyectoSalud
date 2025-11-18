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
            conexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
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

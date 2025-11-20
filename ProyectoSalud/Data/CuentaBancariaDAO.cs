using System;
using System.Data;
using System.Data.SqlClient;
using ProyectoSalud.ProyectoSalud.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSalud.ProyectoSalud.Data
{
    internal class CuentaBancariaDAO
    {
        private readonly Database db = new Database();

        public CuentaBancariaDAO(Database database)
        {
            db = database;
        }

        public bool InsertarCuenta(CuentaBancaria cuenta)
        {
            using (SqlConnection conexion = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("spInsertarCuentaBancaria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@banco", cuenta.banco);
                cmd.Parameters.AddWithValue("@numeroCuenta", cuenta.numeroCuenta);
                cmd.Parameters.AddWithValue("@tipoCuenta", cuenta.tipoCuenta);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ObtenerCuentas()
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM CuentasBancarias", conn))
            {
                conn.Open();
                DataTable tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());
                return tabla;
            }
        }
    }
}

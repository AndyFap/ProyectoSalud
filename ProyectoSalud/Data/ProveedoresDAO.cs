using ProyectoSalud.ProyectoSalud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSalud.ProyectoSalud.Data
{
    internal class ProveedoresDAO
    {
        private readonly Database db;

        public ProveedoresDAO(Database database)
        {
            db = database;
        }

        // Inserta nuevo proveedor
        public bool InsertarProveedor(Proveedor proveedor)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spInsertarProveedor", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", proveedor.nombre);
                    cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                    cmd.Parameters.AddWithValue("@saldo", proveedor.saldo);
                    cmd.Parameters.AddWithValue("@limiteCredito", proveedor.limiteCredito);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Modificar proveedor existente
        public bool ModificarProveedor(Proveedor proveedor)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spActualizarProveedor", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@proveedorID", proveedor.proveedorID);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.nombre);
                    cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                    cmd.Parameters.AddWithValue("@limiteCredito", proveedor.limiteCredito);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        public bool EliminarProveedor(int proveedorID)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spEliminarProveedor", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@proveedorID", proveedorID);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        // Mostrar Clientes
        public DataTable ObtenerProveedor()
        {
            DataTable tablaProveedores = new DataTable();

            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spListarProveedores", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tablaProveedores);
                    }
                }
            }

            return tablaProveedores;
        }

    }
}

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using ProyectoSalud.ProyectoSalud.Models;

namespace ProyectoSalud.ProyectoSalud.Data
{
    internal class ClientesDAO
    {
        private readonly Database db;

        public ClientesDAO(Database database)
        {
            db = database;
        }

        // Inserta nuevo cliente
        public bool InsertarCliente(Cliente cliente)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spInsertarCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@tipoCliente", cliente.tipoCliente);
                    cmd.Parameters.AddWithValue("@limiteCredito", cliente.limiteCredito);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Modificar cliente existente
        public bool ModificarCliente(Cliente cliente)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spActualizarCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@clienteID", cliente.clienteID);
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@tipoCliente", cliente.tipoCliente);
                    cmd.Parameters.AddWithValue("@limiteCredito", cliente.limiteCredito);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        public bool EliminarCliente(int clienteID)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();
                
                using (var cmd = new SqlCommand("spEliminarCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clienteID", clienteID);
                    
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        // Mostrar Clientes
        public DataTable ObtenerClientes()
        {
            DataTable tablaClientes = new DataTable();

            using (var conexion =  db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spListarClientes", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tablaClientes);
                    }                
                }
            }

            return tablaClientes;
        }

    }
}

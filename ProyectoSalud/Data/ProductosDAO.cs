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
    internal class ProductosDAO
    {
        private readonly Database db;

        public ProductosDAO(Database database)
        {
            db = database;
        }

        // Inserta nuevo producto
        public bool InsertarProducto(Productos productos)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spInsertarProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", productos.nombre);
                    cmd.Parameters.AddWithValue("@tipoProducto", productos.tipoProducto);
                    cmd.Parameters.AddWithValue("@stock", productos.stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", productos.stockMinimo);
                    cmd.Parameters.AddWithValue("@unidadMedida", productos.unidadMedida);
                    cmd.Parameters.AddWithValue("@precio", productos.precio);
                    cmd.Parameters.AddWithValue("@fechaVencimiento", productos.fechaVencimiento);
                    cmd.Parameters.AddWithValue("@bodega", productos.bodega);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Modificar producto existente
        public bool ModificarProveedor(Productos productos)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spActualizarProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@productoID", productos.productoID);
                    cmd.Parameters.AddWithValue("@nombre", productos.nombre);
                    cmd.Parameters.AddWithValue("@stock", productos.precio);
                    cmd.Parameters.AddWithValue("@bodega", productos.bodega);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        // Eliminar producto
        public bool EliminarProducto(int productoID)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spEliminarProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productoID", productoID);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        // Mostrar Productos
        public DataTable ObtenerProducto()
        {
            DataTable tablaProductos = new DataTable();

            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spListarProductos", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tablaProductos);
                    }
                }
            }

            return tablaProductos;
        }
    }
}


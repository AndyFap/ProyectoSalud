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
    /// <summary>
    /// Data Access Object para la gestión de productos
    /// Maneja todas las operaciones CRUD con la base de datos
    /// utilizando procedimientos almacenados
    /// </summary>
    internal class ProductosDAO
    {
        private readonly Database db;

        /// <summary>
        /// Constructor que recibe una instancia de Database para manejar la conexión
        /// </summary>
        public ProductosDAO(Database database)
        {
            db = database;
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos
        /// </summary>
        /// <param name="producto">Objeto Producto con los datos a insertar</param>
        /// <returns>True si se insertó correctamente, False en caso contrario</returns>
        public bool InsertarProducto(Producto producto)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spInsertarProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros según el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@tipoProducto", (object)producto.tipoProducto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", (object)producto.stock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stockMinimo", (object)producto.stockMinimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@unidadMedida", (object)producto.unidadMedida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@fechaVencimiento", (object)producto.fechaVencimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@bodega", (object)producto.bodega ?? DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        /// <summary>
        /// Actualiza un producto existente en la base de datos
        /// </summary>
        /// <param name="producto">Objeto Producto con los datos actualizados</param>
        /// <returns>True si se actualizó correctamente, False en caso contrario</returns>
        public bool ModificarProducto(Producto producto)
        {
            using (var conexion = db.GetConnection())
            {
                conexion.Open();

                using (var cmd = new SqlCommand("spActualizarProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros según spActualizarProducto
                    cmd.Parameters.AddWithValue("@productoID", producto.productoID);
                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@tipoProducto", (object)producto.tipoProducto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", (object)producto.stock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stockMinimo", (object)producto.stockMinimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@unidadMedida", (object)producto.unidadMedida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@fechaVencimiento", (object)producto.fechaVencimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@bodega", (object)producto.bodega ?? DBNull.Value);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        /// <param name="productoID">ID del producto a eliminar</param>
        /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
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

        /// <summary>
        /// Obtiene todos los productos de la base de datos
        /// </summary>
        /// <returns>DataTable con todos los productos</returns>
        public DataTable ObtenerProductos()
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

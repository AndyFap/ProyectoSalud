using System;

namespace ProyectoSalud.ProyectoSalud.Models
{
    /// <summary>
    /// Modelo que representa un producto médico en el sistema
    /// Mapea la tabla Productos de la base de datos
    /// </summary>
    public class Producto
    {
        // ID único del producto (Primary Key, generado automáticamente)
        public int productoID { get; set; }

        // Nombre del producto médico
        public string nombre { get; set; }

        // Tipo o categoría del producto (ej: "Medicamento", "Equipo", "Suministro")
        public string tipoProducto { get; set; }

        // Cantidad actual en inventario
        public int stock { get; set; }

        // Stock mínimo permitido antes de reorden
        public int stockMinimo { get; set; }

        // Unidad de medida (ej: "unidad", "caja", "frasco")
        public string unidadMedida { get; set; }

        // Precio unitario del producto
        public decimal precio { get; set; }

        // Fecha de vencimiento del producto (puede ser null si no aplica)
        public DateTime? fechaVencimiento { get; set; }

        // Ubicación o bodega donde se almacena
        public string bodega { get; set; }
    }
}

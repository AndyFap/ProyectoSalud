using System;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public class Productos
    {
        public int productoID { get; set; }
        public string nombre { get; set; }
        public string tipoProducto { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public string unidadMedida { get; set; }
        public decimal precio { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string bodega { get; set; }
    }
}

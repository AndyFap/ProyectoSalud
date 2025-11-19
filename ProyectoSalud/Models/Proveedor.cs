namespace ProyectoSalud.ProyectoSalud.Models
{
    public class Proveedor
    {
        public int proveedorID { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; }
        public decimal saldo { get; set; }
        public decimal limiteCredito { get; set; }
        public decimal creditoDisponible { get; set; }
    }
}

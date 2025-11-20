using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public class CuentaBancaria
    {
        public int cuentaID { get; set; }
        public string banco { get; set; }
        public string numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public decimal saldo { get; set; }
    }
}

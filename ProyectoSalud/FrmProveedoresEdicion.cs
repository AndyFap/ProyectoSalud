using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public partial class FrmProveedoresEdicion : Form
    {
        private TextBox txtNombre, txtContacto, txtSaldo, txtLimiteCredito, txtCreditoDisponible;
        private Button btnGuardar;

        public Proveedor ProveedorInfo { get; private set; }

        public FrmProveedoresEdicion()
        {
            ProveedorInfo = new Proveedor();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmProveedoresEdicion
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmProveedoresEdicion";
            this.Load += new System.EventHandler(this.FrmProveedoresEdicion_Load_3);
            this.ResumeLayout(false);

        }

        private void FrmProveedoresEdicion_Load_2(object sender, EventArgs e)
        {

        }

        private void FrmProveedoresEdicion_Load_3(object sender, EventArgs e)
        {

        }

        public FrmProveedoresEdicion(Proveedor proveedor) : this()
        {
            ProveedorInfo = proveedor;

            // Ahora los TextBoxes ya existen porque InitializeComponent los crea
            txtNombre.Text = proveedor.nombre;
            txtContacto.Text = proveedor.contacto;
            txtSaldo.Text = proveedor.saldo.ToString();
            txtLimiteCredito.Text = proveedor.limiteCredito.ToString();
            txtCreditoDisponible.Text = proveedor.creditoDisponible.ToString();
        }

        private void FrmProveedoresEdicion_Load(object sender, EventArgs e)
        {

        }

        private void FrmProveedoresEdicion_Load_1(object sender, EventArgs e)
        {

        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorInfo.nombre = txtNombre.Text;
            ProveedorInfo.contacto = txtContacto.Text;
            ProveedorInfo.saldo = decimal.TryParse(txtSaldo.Text, out var saldo) ? saldo : 0m;
            ProveedorInfo.limiteCredito = decimal.TryParse(txtLimiteCredito.Text, out var limiteCredito) ? limiteCredito : 0m;
            ProveedorInfo.creditoDisponible = decimal.TryParse(txtCreditoDisponible.Text, out var creditoDisponible) ? creditoDisponible : 0m;

            this.DialogResult = DialogResult.OK;
        }
    }
}

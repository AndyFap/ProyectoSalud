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

            // TextBoxes
            txtNombre = new TextBox { Left = 140, Top = 20, Width = 200 };
            txtContacto = new TextBox { Left = 140, Top = 55, Width = 200 };
            txtSaldo = new TextBox { Left = 140, Top = 90, Width = 200 };
            txtLimiteCredito = new TextBox { Left = 140, Top = 125, Width = 200 };
            txtCreditoDisponible = new TextBox { Left = 140, Top = 160, Width = 200 };

            // Labels
            var lblNombre = new Label { Left = 20, Top = 23, Text = "Nombre:", AutoSize = true };
            var lblContacto = new Label { Left = 20, Top = 58, Text = "Contacto:", AutoSize = true };
            var lblSaldo = new Label { Left = 20, Top = 93, Text = "Saldo:", AutoSize = true };
            var lblLimite = new Label { Left = 20, Top = 128, Text = "Límite crédito:", AutoSize = true };
            var lblDisponible = new Label { Left = 20, Top = 163, Text = "Crédito disponible:", AutoSize = true };

            // Botón Guardar
            btnGuardar = new Button { Left = 140, Top = 200, Width = 100, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Form
            this.ClientSize = new Size(370, 250);
            this.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblContacto, txtContacto,
                lblSaldo, txtSaldo,
                lblLimite, txtLimiteCredito,
                lblDisponible, txtCreditoDisponible,
                btnGuardar
            });
            this.Name = "FrmProveedoresEdicion";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }

        private void FrmProveedoresEdicion_Load_2(object sender, EventArgs e)
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

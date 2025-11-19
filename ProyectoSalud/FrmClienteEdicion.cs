using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public partial class FrmClienteEdicion : Form
    {
        private TextBox txtNombre, txtTipoCliente, txtLimiteCredito;
        private Button btnGuardar;

        public Cliente ClienteInfo { get; private set; }

        public FrmClienteEdicion()
        {
            ClienteInfo = new Cliente();
            InitializeComponent();
        }

        public FrmClienteEdicion(Cliente cliente) : this()
        {
            ClienteInfo = cliente;

            txtNombre.Text = cliente.nombre;
            txtTipoCliente.Text = cliente.tipoCliente;
            txtLimiteCredito.Text = cliente.limiteCredito;
        }

        private void FrmClienteEdicion_Load(object sender, EventArgs e)
        {

        }

        private void FrmClienteEdicion_Load_1(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // TextBoxes
            txtNombre = new TextBox { Left = 130, Top = 20, Width = 200 };
            txtTipoCliente = new TextBox { Left = 130, Top = 55, Width = 200 };
            txtLimiteCredito = new TextBox { Left = 130, Top = 90, Width = 200 };

            // Labels
            var lblNombre = new Label { Left = 20, Top = 23, Text = "Nombre:", AutoSize = true };
            var lblTipo = new Label { Left = 20, Top = 58, Text = "Tipo cliente:", AutoSize = true };
            var lblLimite = new Label { Left = 20, Top = 93, Text = "Límite crédito:", AutoSize = true };

            // Botón Guardar
            btnGuardar = new Button { Left = 130, Top = 130, Width = 100, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Form
            this.ClientSize = new Size(360, 180);
            this.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblTipo, txtTipoCliente,
                lblLimite, txtLimiteCredito,
                btnGuardar
            });
            this.Name = "FrmClienteEdicion";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClienteInfo.nombre = txtNombre.Text;
            ClienteInfo.tipoCliente = txtTipoCliente.Text;
            ClienteInfo.limiteCredito = txtLimiteCredito.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}

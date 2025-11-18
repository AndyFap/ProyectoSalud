using ProyectoSalud.ProyectoSalud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public partial class FrmClienteEdicion : Form
    {
        private TextBox txtNombre, txtTipoCliente, txtLimiteCredito;

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

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // TextBox Nombre
            txtNombre = new TextBox { Top = 20, Left = 120, Width = 140 };
            Label lblNombre = new Label { Text = "Nombre:", Top = 20, Left = 20, Width = 100 };

            // TextBox TipoCliente
            txtTipoCliente = new TextBox { Top = 60, Left = 120, Width = 140 };
            Label lblTipo = new Label { Text = "Tipo Cliente:", Top = 60, Left = 20, Width = 100 };

            // TextBox LimiteCredito
            txtLimiteCredito = new TextBox { Top = 100, Left = 120, Width = 140 };
            Label lblLimite = new Label { Text = "Límite Crédito:", Top = 100, Left = 20, Width = 100 };

            // Botón Guardar
            Button btnGuardar = new Button { Text = "Guardar", Top = 150, Left = 50 };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            Button btnCancelar = new Button { Text = "Cancelar", Top = 150, Left = 150 };
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
            lblNombre, txtNombre,
            lblTipo, txtTipoCliente,
            lblLimite, txtLimiteCredito,
            btnGuardar, btnCancelar
            });

            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Name = "FrmClienteEdicion";
            this.Text = "Edición de Cliente";

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

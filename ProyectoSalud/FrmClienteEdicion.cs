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
        public Cliente ClienteInfo { get; private set; }

        private TextBox txtNombre, txtTipoCliente, txtLimiteCredito;

        private bool esEdicion = false;

        public FrmClienteEdicion()
        {
            ClienteInfo = new Cliente();
            InitializeComponent();
        }

        public FrmClienteEdicion(Cliente cliente) : this()
        {
            esEdicion = true;
            ClienteInfo = cliente;

            txtNombre.Text = cliente.nombre;
            txtTipoCliente.Text = cliente.tipoCliente;
            txtLimiteCredito.Text = cliente.limiteCredito;
        }

        private void InitializeComponent()
        {
            this.Text = "Cliente";
            this.Width = 350;
            this.Height = 230;

            Label lbl1 = new Label { Text = "Nombre", Top = 20, Left = 10 };
            txtNombre = new TextBox { Top = 20, Left = 120, Width = 200 };

            Label lbl2 = new Label { Text = "TipoCliente", Top = 60, Left = 10 };
            txtTipoCliente = new TextBox { Top = 60, Left = 120, Width = 200 };

            Label lbl3 = new Label { Text = "LimiteCredito", Top = 100, Left = 10 };
            txtLimiteCredito = new TextBox { Top = 100, Left = 120, Width = 200 };

            Button btnGuardar = new Button { Text = "Guardar", Top = 140, Left = 120 };
            Button btnCancelar = new Button { Text = "Cancelar", Top = 140, Left = 220 };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lbl1, txtNombre, lbl2, txtTipoCliente, lbl3, txtLimiteCredito, btnGuardar, btnCancelar });
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

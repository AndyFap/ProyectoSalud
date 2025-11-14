using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Asignar eventos de menú
            gestionarProveedoresToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmProveedores());
            productosToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmProductos());
            gestionarClientesToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmClientes());
            cuentasBancariasToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmCuentasBancarias());
            salirToolStripMenuItem.Click += (s, e) => this.Close();
            // se puede agregar mas eventos
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            this.panelPrincipal.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(formulario);
            formulario.Show();
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

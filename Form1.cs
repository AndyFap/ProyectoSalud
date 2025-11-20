using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoSalud.UI;

namespace ProyectoSalud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PersonalizarInterfaz();
            MostrarPantallaBienvenida();
            
            // Asignar eventos de menú
            gestionarProveedoresToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmProveedores());
            productosToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmProductos());
            gestionarClientesToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmClientes());
            cuentasBancariasToolStripMenuItem.Click += (s, e) => AbrirFormularioEnPanel(new FrmCuentasBancarias());
            salirToolStripMenuItem.Click += (s, e) => this.Close();
            // se puede agregar mas eventos
        }

        private void PersonalizarInterfaz()
        {
            // Personalizar el formulario principal
            this.BackColor = ModernUIHelper.ColorFondo;
            
            // Personalizar el MenuStrip
            menuStrip1.BackColor = ModernUIHelper.ColorMenuOscuro;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
            
            // Aplicar color blanco a todos los items del menú
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                AplicarColorSubItems(item);
            }
            
            // Personalizar el panel principal
            panelPrincipal.BackColor = Color.White;
            
            // Personalizar el botón SALIR
            salirToolStripMenuItem.BackColor = Color.FromArgb(239, 68, 68); // Rojo moderno
            salirToolStripMenuItem.ForeColor = Color.White;
            salirToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salirToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
        }

        private void AplicarColorSubItems(ToolStripMenuItem item)
        {
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                subItem.ForeColor = Color.White;
                if (subItem is ToolStripMenuItem menuItem)
                {
                    AplicarColorSubItems(menuItem);
                }
            }
        }

        private void MostrarPantallaBienvenida()
        {
            panelPrincipal.Controls.Clear();
            
            Panel panelBienvenida = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            
            // Panel central con contenido
            Panel panelCentro = new Panel
            {
                Size = new Size(600, 300),
                BackColor = Color.White
            };
            
            // Título principal
            Label lblTitulo = new Label
            {
                Text = "Comercializadora de Productos Médicos",
                Font = new Font("Segoe UI Light", 28F, FontStyle.Bold),
                ForeColor = ModernUIHelper.ColorPrimario,
                AutoSize = true,
                Location = new Point(50, 80)
            };
            
            // Mensaje de bienvenida
            Label lblMensaje = new Label
            {
                Text = "Seleccione una opción del menú superior para comenzar",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new Point(50, 140)
            };
            
            panelCentro.Controls.AddRange(new Control[] { lblTitulo, lblMensaje });
            
            // Centrar el panel
            panelCentro.Location = new Point(
                (panelPrincipal.Width - panelCentro.Width) / 2,
                (panelPrincipal.Height - panelCentro.Height) / 2
            );
            
            panelBienvenida.Controls.Add(panelCentro);
            panelPrincipal.Controls.Add(panelBienvenida);
            
            // Reposicionar cuando cambia el tamaño
            panelPrincipal.Resize += (s, e) =>
            {
                if (panelBienvenida.Parent != null)
                {
                    panelCentro.Location = new Point(
                        (panelPrincipal.Width - panelCentro.Width) / 2,
                        (panelPrincipal.Height - panelCentro.Height) / 2
                    );
                }
            };
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
            //prueba
        }

        private void gestionarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

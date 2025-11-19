using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmProductos : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;

        public FrmProductos()
        {
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        private void ConfigurarInterfazModerna()
        {
            // Configurar el formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Crear panel de título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Gestión de Productos", 60);

            // Crear botones modernos
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nuevo Producto", 170);
            btnEditar = ModernUIHelper.CrearBotonExito("Editar", 140);
            btnEliminar = ModernUIHelper.CrearBotonPeligro("Eliminar", 140);
            btnRefrescar = ModernUIHelper.CrearBotonInfo("Refrescar", 140);

            // Crear panel de botones
            panelBotones = ModernUIHelper.CrearPanelBotones(btnNuevo, btnEditar, btnEliminar, btnRefrescar);

            // Crear y configurar DataGridView
            dgv = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            ModernUIHelper.AplicarEstiloDataGrid(dgv);

            // Agregar controles en orden
            this.Controls.Add(dgv);
            this.Controls.Add(panelBotones);
            this.Controls.Add(panelTitulo);

            // Conectar eventos
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarProductos();
            
            // Cargar datos al iniciar
            this.Load += (s, e) => CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                // TODO: Implementar carga de productos desde la base de datos
                // dgv.DataSource = productosDAO.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "La funcionalidad de agregar productos está en desarrollo.\n\n" +
                "Próximamente podrás agregar nuevos productos al inventario.",
                "Función en Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            // TODO: Implementar formulario de edición de productos
            // using (var frm = new FrmProductoEdicion())
            // {
            //     if (frm.ShowDialog() == DialogResult.OK)
            //     {
            //         CargarProductos();
            //     }
            // }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un producto para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            MessageBox.Show(
                "La funcionalidad de editar productos está en desarrollo.\n\n" +
                "Próximamente podrás modificar la información de los productos.",
                "Función en Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            // TODO: Implementar edición de productos
            // using (var frm = new FrmProductoEdicion(productoSeleccionado))
            // {
            //     if (frm.ShowDialog() == DialogResult.OK)
            //     {
            //         CargarProductos();
            //     }
            // }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un producto para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // TODO: Implementar eliminación de productos
                    ModernUIHelper.MostrarNotificacion(this, "Producto eliminado exitosamente",
                        ModernUIHelper.ColorPeligro);
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

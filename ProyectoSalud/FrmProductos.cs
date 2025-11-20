using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
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
        private ProductosDAO productosDAO;

        public FrmProductos()
        {
            productosDAO = new ProductosDAO(new Database());
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
                dgv.DataSource = productosDAO.ObtenerProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load_1(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProductoEdicion())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        productosDAO.InsertarProducto(frm.ProductoInfo);
                        ModernUIHelper.MostrarNotificacion(this, "Producto agregado exitosamente",
                            ModernUIHelper.ColorExito);
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar proveedor: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un producto para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgv.SelectedRows[0];

            Productos p = new Productos
            {
                productoID = Convert.ToInt32(row.Cells["productoID"].Value),
                nombre = row.Cells["nombre"].Value.ToString(),
                tipoProducto = row.Cells["tipoProducto"].Value.ToString(),
                stock = Convert.ToInt32(row.Cells["stock"].Value),
                stockMinimo = Convert.ToInt32(row.Cells["stockMinimo"].Value),
                unidadMedida = row.Cells["unidadMedida"].Value.ToString(),
                precio = Convert.ToDecimal(row.Cells["precio"].Value),
                fechaVencimiento = row.Cells["fechaVencimiento"].Value == DBNull.Value 
                    ? default(DateTime) 
                    : Convert.ToDateTime(row.Cells["fechaVencimiento"].Value),
                bodega = row.Cells["bodega"].Value.ToString()
            };

            using (var frm = new FrmProductoEdicion(p))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        productosDAO.ModificarProveedor(frm.ProductoInfo);
                        ModernUIHelper.MostrarNotificacion(this, "Producto actualizado exitosamente",
                            ModernUIHelper.ColorExito);
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar prodcuto: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un producto para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cellVal = dgv.SelectedRows[0].Cells["productoID"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;

            int id = Convert.ToInt32(cellVal);

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    productosDAO.EliminarProducto(id);
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
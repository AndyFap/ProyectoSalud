using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    /// <summary>
    /// Formulario principal para la gestión de productos
    /// Permite listar, crear, editar y eliminar productos del inventario
    /// Sigue el mismo patrón que FrmProveedores
    /// </summary>
    public partial class FrmProductos : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;
        private ProductosDAO productosDao;

        public FrmProductos()
        {
            // Inicializar DAO con conexión a la base de datos
            productosDao = new ProductosDAO(new Database());
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        /// <summary>
        /// Configura la interfaz moderna del formulario
        /// </summary>
        private void ConfigurarInterfazModerna()
        {
            // Configurar el formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Crear panel de título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Gestión de Productos", 70);

            // Crear botones modernos
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nuevo Producto", 180);
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

        /// <summary>
        /// Carga todos los productos desde la base de datos al DataGridView
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                dgv.DataSource = productosDao.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón Nuevo
        /// Abre el formulario de edición para crear un nuevo producto
        /// </summary>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
                    using (var frm = new FrmProductosEdicion())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                bool exito = productosDao.InsertarProducto(frm.ProductoInfo);
                                if (exito)
                                {
                                    ModernUIHelper.MostrarNotificacion(this, "Producto agregado exitosamente",
                                        ModernUIHelper.ColorExito);
                                    CargarProductos();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar el producto. Verifique los datos e intente nuevamente.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al insertar producto: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
        }

        /// <summary>
        /// Maneja el evento Click del botón Editar
        /// Abre el formulario de edición con los datos del producto seleccionado
        /// </summary>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un producto para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgv.SelectedRows[0];

            // Crear objeto Producto con los datos de la fila seleccionada
            Producto p = new Producto
            {
                productoID = Convert.ToInt32(row.Cells["productoID"].Value),
                nombre = row.Cells["nombre"].Value.ToString(),
                tipoProducto = row.Cells["tipoProducto"].Value?.ToString(),
                stock = row.Cells["stock"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["stock"].Value) : 0,
                stockMinimo = row.Cells["stockMinimo"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["stockMinimo"].Value) : 0,
                unidadMedida = row.Cells["unidadMedida"].Value?.ToString(),
                precio = Convert.ToDecimal(row.Cells["precio"].Value),
                fechaVencimiento = row.Cells["fechaVencimiento"].Value != DBNull.Value 
                    ? Convert.ToDateTime(row.Cells["fechaVencimiento"].Value) 
                    : (DateTime?)null,
                bodega = row.Cells["bodega"].Value?.ToString()
            };

            using (var frm = new FrmProductosEdicion(p))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bool exito = productosDao.ModificarProducto(frm.ProductoInfo);
                        if (exito)
                        {
                            ModernUIHelper.MostrarNotificacion(this, "Producto actualizado exitosamente",
                                ModernUIHelper.ColorExito);
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el producto. Verifique los datos e intente nuevamente.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar producto: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón Eliminar
        /// Elimina el producto seleccionado previa confirmación
        /// </summary>
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
            string nombreProducto = dgv.SelectedRows[0].Cells["nombre"].Value?.ToString() ?? "este producto";

            if (MessageBox.Show($"¿Está seguro de eliminar '{nombreProducto}'?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    bool exito = productosDao.EliminarProducto(id);
                    if (exito)
                    {
                        ModernUIHelper.MostrarNotificacion(this, "Producto eliminado exitosamente",
                            ModernUIHelper.ColorPeligro);
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto. Es posible que ya no exista o tenga registros relacionados.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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


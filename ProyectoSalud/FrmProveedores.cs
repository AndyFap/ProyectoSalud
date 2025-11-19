using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmProveedores : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;
        private ProveedoresDAO proveedorDao;

        public FrmProveedores()
        {
            proveedorDao = new ProveedoresDAO(new Database());
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        private void ConfigurarInterfazModerna()
        {
            // Configurar el formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Crear panel de título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Gestión de Proveedores", 70);

            // Crear botones modernos
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nuevo Proveedor", 180);
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
            btnRefrescar.Click += (s, e) => CargarProveedores();
            
            // Cargar datos al iniciar
            this.Load += (s, e) => CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                dgv.DataSource = proveedorDao.ObtenerProveedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProveedoresEdicion())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        proveedorDao.InsertarProveedor(frm.ProveedorInfo);
                        ModernUIHelper.MostrarNotificacion(this, "Proveedor agregado exitosamente",
                            ModernUIHelper.ColorExito);
                        CargarProveedores();
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
                MessageBox.Show("Por favor seleccione un proveedor para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgv.SelectedRows[0];

            Proveedor p = new Proveedor
            {
                proveedorID = Convert.ToInt32(row.Cells["proveedorID"].Value),
                nombre = row.Cells["nombre"].Value.ToString(),
                contacto = row.Cells["contacto"].Value.ToString(),
                saldo = Convert.ToDecimal(row.Cells["saldo"].Value),
                limiteCredito = Convert.ToDecimal(row.Cells["limiteCredito"].Value),
                creditoDisponible = Convert.ToDecimal(row.Cells["creditoDisponible"].Value)
            };

            using (var frm = new FrmProveedoresEdicion(p))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        proveedorDao.ModificarProveedor(frm.ProveedorInfo);
                        ModernUIHelper.MostrarNotificacion(this, "Proveedor actualizado exitosamente",
                            ModernUIHelper.ColorExito);
                        CargarProveedores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar proveedor: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un proveedor para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cellVal = dgv.SelectedRows[0].Cells["proveedorID"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;

            int id = Convert.ToInt32(cellVal);

            if (MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    proveedorDao.EliminarProveedor(id);
                    ModernUIHelper.MostrarNotificacion(this, "Proveedor eliminado exitosamente",
                        ModernUIHelper.ColorPeligro);
                    CargarProveedores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar proveedor: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

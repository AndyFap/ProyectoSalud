using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmClientes : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;

        private ClientesDAO clienteDao;

        public FrmClientes()
        {
            clienteDao = new ClientesDAO(new Database());
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        private void ConfigurarInterfazModerna()
        {
            // Configurar el formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Crear panel de título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Gestión de Clientes", 60);

            // Crear botones modernos
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nuevo Cliente", 160);
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

            // Agregar controles en orden (el último agregado queda arriba en el Z-order)
            this.Controls.Add(dgv);
            this.Controls.Add(panelBotones);
            this.Controls.Add(panelTitulo);

            // Conectar eventos
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarClientes();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dgv.DataSource = clienteDao.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClienteEdicion())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clienteDao.InsertarCliente(frm.ClienteInfo);
                        CargarClientes();
                        ModernUIHelper.MostrarNotificacion(this, "Cliente creado exitosamente", 
                            ModernUIHelper.ColorExito);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar cliente: " + ex.Message, "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgv.SelectedRows[0];
            Cliente cliente = new Cliente
            {
                clienteID = Convert.ToInt32(row.Cells["clienteID"].Value),
                nombre = row.Cells["nombre"].Value.ToString(),
                tipoCliente = row.Cells["tipoCliente"].Value.ToString(),
                limiteCredito = row.Cells["limiteCredito"].Value.ToString()
            };

            using (var frm = new FrmClienteEdicion(cliente))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clienteDao.ModificarCliente(frm.ClienteInfo);
                        CargarClientes();
                        ModernUIHelper.MostrarNotificacion(this, "Cliente actualizado exitosamente", 
                            ModernUIHelper.ColorExito);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar cliente: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cellVal = dgv.SelectedRows[0].Cells["clienteID"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;
            int id = Convert.ToInt32(cellVal);

            if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar eliminación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    clienteDao.EliminarCliente(id);
                    CargarClientes();
                    ModernUIHelper.MostrarNotificacion(this, "Cliente eliminado exitosamente", 
                        ModernUIHelper.ColorPeligro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

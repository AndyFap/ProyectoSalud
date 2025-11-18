using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmClientes : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        private ClientesDAO clienteDao;

        public FrmClientes()
        {
            clienteDao = new ClientesDAO(new Database());
            InitializeComponent();

            dgv = new DataGridView { Top = 10, Left = 10, Width = 700, Height = 300, ReadOnly = true };
            btnNuevo = new Button { Text = "Nuevo", Top = 320, Left = 10 };
            btnEditar = new Button { Text = "Editar", Top = 320, Left = 100 };
            btnEliminar = new Button { Text = "Eliminar", Top = 320, Left = 190 };
            btnRefrescar = new Button { Text = "Refrescar", Top = 320, Left = 280 };

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] { dgv, btnNuevo, btnEditar, btnEliminar, btnRefrescar });

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
            dgv.DataSource = clienteDao.ObtenerClientes();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar cliente: {ex.Message}");
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var cellVal = dgv.SelectedRows[0].Cells["clienteID"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;
            int id = Convert.ToInt32(cellVal);

            if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    clienteDao.EliminarCliente(id);
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
                }
            }
        }
    }
}

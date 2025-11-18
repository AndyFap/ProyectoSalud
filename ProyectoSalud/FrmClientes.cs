using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public class FrmClientes : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        private ClientesDAO clienteDao;

        public FrmClientes()
        {
            clienteDao = new ClientesDAO(new Database());
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Clientes";
            this.Width = 600;
            this.Height = 400;

            dgv = new DataGridView
            {
                Top = 10,
                Left = 10,
                Width = 560,
                Height = 250,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnNuevo = new Button { Text = "Nuevo", Top = 270, Left = 10 };
            btnEditar = new Button { Text = "Editar", Top = 270, Left = 100 };
            btnEliminar = new Button { Text = "Eliminar", Top = 270, Left = 190 };
            btnRefrescar = new Button { Text = "Refrescar", Top = 270, Left = 280 };

            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarClientes();

            this.Controls.AddRange(new Control[] { dgv, btnNuevo, btnEditar, btnEliminar, btnRefrescar });

            this.Load += FrmClientes_Load;
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
                    clienteDao.InsertarCliente(frm.ClienteInfo);
                    CargarClientes();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgv.SelectedRows[0];

            Cliente cliente = new Cliente
            {
                clienteID = Convert.ToInt32(row.Cells["clienteID"].Value),
                nombre = row.Cells["nombre"].Value.ToString(),
                tipoCliente = row.Cells["tipoCliente"].Value.ToString(),
                limiteCredito = row.Cells["limiteCredito"].Value.ToString(),
            };

            using (var frm = new FrmClienteEdicion(cliente))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clienteDao.ModificarCliente(frm.ClienteInfo);
                    CargarClientes();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var id = Convert.ToInt32(dgv.SelectedRows[0].Cells["clienteID"].Value);

            if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clienteDao.EliminarCliente(id);
                CargarClientes();
            }
        }
    }
}

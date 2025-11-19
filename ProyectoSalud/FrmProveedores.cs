using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.ProyectoSalud.Models;
using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmProveedores : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        private ProveedoresDAO proveedorDao;

        public FrmProveedores()
        {
            proveedorDao = new ProveedoresDAO(new Database());
            InitializeComponent();

            // Crear controles manualmente igual que el FrmClientes
            dgv = new DataGridView
            {
                Top = 10,
                Left = 10,
                Width = 700,
                Height = 300,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnNuevo = new Button { Text = "Nuevo", Top = 320, Left = 10 };
            btnEditar = new Button { Text = "Editar", Top = 320, Left = 100 };
            btnEliminar = new Button { Text = "Eliminar", Top = 320, Left = 190 };
            btnRefrescar = new Button { Text = "Refrescar", Top = 320, Left = 280 };

            // Agregar controles
            this.Controls.AddRange(new Control[]
            {
                dgv, btnNuevo, btnEditar, btnEliminar, btnRefrescar
            });

            // Asignar eventos
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarProveedores();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            dgv.DataSource = proveedorDao.ObtenerProveedor();
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
            if (dgv.SelectedRows.Count == 0) return;

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
                        CargarProveedores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar proveedor: {ex.Message}");
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var cellVal = dgv.SelectedRows[0].Cells["proveedorID"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;

            int id = Convert.ToInt32(cellVal);

            if (MessageBox.Show("¿Eliminar proveedor?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    proveedorDao.EliminarProveedor(id);
                    CargarProveedores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar proveedor: {ex.Message}");
                }
            }
        }
    }
}

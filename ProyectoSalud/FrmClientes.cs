using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public class FrmClientes : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestionar Clientes";
            this.Dock = DockStyle.Fill;

            this.dgv = new DataGridView { Dock = DockStyle.Top, Height = 300, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            this.btnNuevo = new Button { Text = "Nuevo", Width = 100, Left = 10 };
            this.btnEditar = new Button { Text = "Editar", Width = 100, Left = 120 };
            this.btnEliminar = new Button { Text = "Eliminar", Width = 100, Left = 230 };
            this.btnRefrescar = new Button { Text = "Refrescar", Width = 100, Left = 340 };

            var panel = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            panel.Controls.Add(btnNuevo);
            panel.Controls.Add(btnEditar);
            panel.Controls.Add(btnEliminar);
            panel.Controls.Add(btnRefrescar);

            this.Controls.Add(panel);
            this.Controls.Add(dgv);

            // Eventos UI - sin lógica de datos
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => { /* Refrescar interfaz - implementar por otro desarrollador */ };
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClienteEdicion())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar vista - implementar en integración con DB
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0];
            using (var frm = new FrmClienteEdicion())
            {
                frm.SetValuesFromRow(row);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar vista - implementar en integración con DB
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Llamada a eliminación implementada por otro desarrollador en la capa de datos
            }
        }
    }

    // Formulario de edición/alta de cliente (solo UI)
    public class FrmClienteEdicion : Form
    {
        private TextBox txtNombre, txtEstadoCuenta;
        private Button btnGuardar, btnCancelar;

        public FrmClienteEdicion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Cliente";
            this.Width = 350;
            this.Height = 200;
            Label lbl1 = new Label { Text = "Nombre", Top = 20, Left = 10 };
            txtNombre = new TextBox { Top = 20, Left = 120, Width = 200 };
            Label lbl2 = new Label { Text = "Estado Cuenta", Top = 60, Left = 10 };
            txtEstadoCuenta = new TextBox { Top = 60, Left = 120, Width = 200 };
            btnGuardar = new Button { Text = "Guardar", Top = 100, Left = 120 };
            btnCancelar = new Button { Text = "Cancelar", Top = 100, Left = 220 };
            btnGuardar.Click += (s, e) => { this.DialogResult = DialogResult.OK; }; // Solo UI
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.AddRange(new Control[] { lbl1, txtNombre, lbl2, txtEstadoCuenta, btnGuardar, btnCancelar });
        }

        public void SetValuesFromRow(DataGridViewRow row)
        {
            if (row == null) return;
            txtNombre.Text = row.Cells.Count > 1 && row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
            txtEstadoCuenta.Text = row.Cells.Count > 2 && row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
        }
    }
}

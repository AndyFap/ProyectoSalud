using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public class FrmProveedores : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmProveedores
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmProveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.ResumeLayout(false);

        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProveedorEdicion())
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
            // Extraer valores visuales si existen y pasarlos al formulario de edición
            object idObj = row.Cells[0].Value; // hay que mapear columnas correctamente
            string nombre = row.Cells.Count > 1 && row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
            string contacto = row.Cells.Count > 2 && row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
            string saldo = row.Cells.Count > 3 && row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;

            using (var frm = new FrmProveedorEdicion())
            {
                // Opcional: el integrador puede exponer un constructor con parámetros o propiedades públicas
                frm.SetValues(nombre, contacto, saldo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar vista - implementar en integración con DB
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¿Eliminar proveedor?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Llamar a eliminación
            }
        }
    }

    // Formulario de edición/alta de proveedor (solo UI)
    public class FrmProveedorEdicion : Form
    {
        private TextBox txtNombre, txtContacto, txtSaldo;
        private Button btnGuardar, btnCancelar;

        public FrmProveedorEdicion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Proveedor";
            this.Width = 350;
            this.Height = 220;
            Label lbl1 = new Label { Text = "Nombre", Top = 20, Left = 10 };
            txtNombre = new TextBox { Top = 20, Left = 100, Width = 200 };
            Label lbl2 = new Label { Text = "Contacto", Top = 60, Left = 10 };
            txtContacto = new TextBox { Top = 60, Left = 100, Width = 200 };
            Label lbl3 = new Label { Text = "Saldo", Top = 100, Left = 10 };
            txtSaldo = new TextBox { Top = 100, Left = 100, Width = 200 };
            btnGuardar = new Button { Text = "Guardar", Top = 140, Left = 100 };
            btnCancelar = new Button { Text = "Cancelar", Top = 140, Left = 200 };
            btnGuardar.Click += (s, e) => { this.DialogResult = DialogResult.OK; }; // Solo UI
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.AddRange(new Control[] { lbl1, txtNombre, lbl2, txtContacto, lbl3, txtSaldo, btnGuardar, btnCancelar });
        }

        // Método para que el integrador pueble los controles desde la capa de datos
        public void SetValues(string nombre, string contacto, string saldo)
        {
            txtNombre.Text = nombre;
            txtContacto.Text = contacto;
            txtSaldo.Text = saldo;
        }
    }
}

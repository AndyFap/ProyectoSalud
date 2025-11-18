using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public class FrmProductos : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmProductos
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmProductos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.ResumeLayout(false);

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProductoEdicion())
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
            using (var frm = new FrmProductoEdicion())
            {
                // el integrador puede llenar el formulario mediante SetValues
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
            if (MessageBox.Show("¿Eliminar producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Llamadar a eliminación
            }
        }
    }

    // Formulario de edición/alta de producto (solo UI)
    public class FrmProductoEdicion : Form
    {
        private TextBox txtNombre, txtStock, txtPrecio, txtBodega;
        private DateTimePicker dtpFechaVenc;
        private Button btnGuardar, btnCancelar;

        public FrmProductoEdicion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Producto";
            this.Width = 420;
            this.Height = 320;

            Label lbl1 = new Label { Text = "Nombre", Top = 20, Left = 10 };
            txtNombre = new TextBox { Top = 20, Left = 140, Width = 240 };

            Label lbl2 = new Label { Text = "Stock", Top = 60, Left = 10 };
            txtStock = new TextBox { Top = 60, Left = 140, Width = 100 };

            Label lbl3 = new Label { Text = "Precio", Top = 100, Left = 10 };
            txtPrecio = new TextBox { Top = 100, Left = 140, Width = 100 };

            Label lbl4 = new Label { Text = "Fecha Venc.", Top = 140, Left = 10 };
            dtpFechaVenc = new DateTimePicker { Top = 140, Left = 140, Width = 160, Format = DateTimePickerFormat.Short, ShowCheckBox = true };

            Label lbl5 = new Label { Text = "Bodega", Top = 180, Left = 10 };
            txtBodega = new TextBox { Top = 180, Left = 140, Width = 200 };

            btnGuardar = new Button { Text = "Guardar", Top = 220, Left = 140 };
            btnCancelar = new Button { Text = "Cancelar", Top = 220, Left = 240 };
            btnGuardar.Click += (s, e) => { this.DialogResult = DialogResult.OK; }; // Solo UI
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lbl1, txtNombre, lbl2, txtStock, lbl3, txtPrecio, lbl4, dtpFechaVenc, lbl5, txtBodega, btnGuardar, btnCancelar });
        }

        // Método para que el integrador pueble los controles desde la capa de datos
        public void SetValuesFromRow(DataGridViewRow row)
        {
            if (row == null) return;
            txtNombre.Text = row.Cells.Count > 1 && row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
            txtStock.Text = row.Cells.Count > 2 && row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
            txtPrecio.Text = row.Cells.Count > 3 && row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
            if (row.Cells.Count > 4 && row.Cells[4].Value != null && DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime dt))
            {
                dtpFechaVenc.Value = dt;
                dtpFechaVenc.Checked = true;
            }
            else
                dtpFechaVenc.Checked = false;
            txtBodega.Text = row.Cells.Count > 5 && row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : string.Empty;
        }
    }
}

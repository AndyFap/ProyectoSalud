using System;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public class FrmCuentasBancarias : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;

        public FrmCuentasBancarias()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmCuentasBancarias
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmCuentasBancarias";
            this.Load += new System.EventHandler(this.FrmCuentasBancarias_Load);
            this.ResumeLayout(false);

        }

        private void FrmCuentasBancarias_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCuentaEdicion())
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
            using (var frm = new FrmCuentaEdicion())
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
            if (MessageBox.Show("¿Eliminar cuenta?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Implementar
            }
        }
    }

    // Formulario de edición/alta de cuenta bancaria (solo UI)
    public class FrmCuentaEdicion : Form
    {
        private TextBox txtBanco, txtSaldo;
        private Button btnGuardar, btnCancelar;

        public FrmCuentaEdicion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Cuenta Bancaria";
            this.Width = 350;
            this.Height = 200;
            Label lbl1 = new Label { Text = "Banco", Top = 20, Left = 10 };
            txtBanco = new TextBox { Top = 20, Left = 120, Width = 200 };
            Label lbl2 = new Label { Text = "Saldo", Top = 60, Left = 10 };
            txtSaldo = new TextBox { Top = 60, Left = 120, Width = 200 };
            btnGuardar = new Button { Text = "Guardar", Top = 100, Left = 120 };
            btnCancelar = new Button { Text = "Cancelar", Top = 100, Left = 220 };
            btnGuardar.Click += (s, e) => { this.DialogResult = DialogResult.OK; }; // Solo UI
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.AddRange(new Control[] { lbl1, txtBanco, lbl2, txtSaldo, btnGuardar, btnCancelar });
        }

        public void SetValuesFromRow(DataGridViewRow row)
        {
            if (row == null) return;
            txtBanco.Text = row.Cells.Count > 1 && row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
            txtSaldo.Text = row.Cells.Count > 2 && row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
        }
    }
}

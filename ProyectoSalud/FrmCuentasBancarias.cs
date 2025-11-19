using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmCuentasBancarias : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnEditar, btnEliminar, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;

        public FrmCuentasBancarias()
        {
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        private void ConfigurarInterfazModerna()
        {
            // Configurar el formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Crear panel de título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Gestión de Cuentas Bancarias", 60);

            // Crear botones modernos
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nueva Cuenta", 170);
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
            btnRefrescar.Click += (s, e) => CargarCuentas();
            
            // Cargar datos al iniciar
            this.Load += (s, e) => CargarCuentas();
        }

        private void CargarCuentas()
        {
            try
            {
                // TODO: Implementar carga de cuentas desde la base de datos
                // dgv.DataSource = cuentasDAO.ObtenerCuentas();
                
                // Formatear columna de saldo como moneda
                if (dgv.Columns["Saldo"] != null)
                {
                    dgv.Columns["Saldo"].DefaultCellStyle.Format = "C2";
                    dgv.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cuentas bancarias: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "La funcionalidad de agregar cuentas bancarias está en desarrollo.\n\n" +
                "Próximamente podrás agregar nuevas cuentas al sistema.",
                "Función en Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            // TODO: Implementar formulario de edición de cuentas
            // using (var frm = new FrmCuentaEdicion())
            // {
            //     if (frm.ShowDialog() == DialogResult.OK)
            //     {
            //         CargarCuentas();
            //     }
            // }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una cuenta para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            MessageBox.Show(
                "La funcionalidad de editar cuentas bancarias está en desarrollo.\n\n" +
                "Próximamente podrás modificar la información de las cuentas.",
                "Función en Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            // TODO: Implementar edición de cuentas
            // using (var frm = new FrmCuentaEdicion(cuentaSeleccionada))
            // {
            //     if (frm.ShowDialog() == DialogResult.OK)
            //     {
            //         CargarCuentas();
            //     }
            // }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una cuenta para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta cuenta bancaria?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // TODO: Implementar eliminación de cuentas
                    ModernUIHelper.MostrarNotificacion(this, "Cuenta eliminada exitosamente",
                        ModernUIHelper.ColorPeligro);
                    CargarCuentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cuenta: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

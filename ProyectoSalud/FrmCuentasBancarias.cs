using ProyectoSalud.ProyectoSalud.Models;
using ProyectoSalud.ProyectoSalud.Data;
using ProyectoSalud.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud
{
    public partial class FrmCuentasBancarias : Form
    {
        private DataGridView dgv;
        private Button btnNuevo, btnRefrescar;
        private Panel panelTitulo;
        private Panel panelBotones;

        private CuentaBancariaDAO cuentaDao;

        public FrmCuentasBancarias()
        {
            cuentaDao = new CuentaBancariaDAO(new Database());
            InitializeComponent();
            ConfigurarInterfazModerna();
        }

        private void ConfigurarInterfazModerna()
        {
            // Fondo del formulario
            this.BackColor = ModernUIHelper.ColorFondo;

            // Título
            panelTitulo = ModernUIHelper.CrearPanelTitulo("Cuentas Bancarias", 70);

            // Botón para agregar cuentas
            btnNuevo = ModernUIHelper.CrearBotonPrimario("Nueva Cuenta", 180);
            btnNuevo.Click += BtnNuevo_Click;

            // Botón para refrescar
            btnRefrescar = ModernUIHelper.CrearBotonInfo("Refrescar", 140);
            btnRefrescar.Click += (s, e) => CargarCuentas();

            // Panel de botones
            panelBotones = ModernUIHelper.CrearPanelBotones(btnNuevo, btnRefrescar);

            // DataGridView
            dgv = new DataGridView { Dock = DockStyle.Fill };
            ModernUIHelper.AplicarEstiloDataGrid(dgv);

            // Agregar controles
            this.Controls.Add(dgv);
            this.Controls.Add(panelBotones);
            this.Controls.Add(panelTitulo);

            // Cargar datos al abrir
            this.Load += (s, e) => CargarCuentas();
        }

        private void CargarCuentas()
        {
            try
            {
                dgv.DataSource = cuentaDao.ObtenerCuentas();    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCuentasBancarias_Load(object sender, EventArgs e)
        {
            CargarCuentas();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCuentaBancariaEdicion())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cuentaDao.InsertarCuenta(frm.CuentaInfo);
                        ModernUIHelper.MostrarNotificacion(this,
                            "Cuenta agregada exitosamente",
                            ModernUIHelper.ColorExito);

                        CargarCuentas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar cuenta: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public partial class FrmCuentaBancariaEdicion : Form
    {
        private TextBox txtBanco, txtNumeroCuenta;
        private ComboBox cbTipoCuenta;
        private Button btnGuardar;

        public CuentaBancaria CuentaInfo { get; private set; }
        public FrmCuentaBancariaEdicion()
        {
            CuentaInfo = new CuentaBancaria();
            InitializeComponent();
        }

        public FrmCuentaBancariaEdicion(CuentaBancaria cuenta) : this()
        {
            CuentaInfo = cuenta;

            txtBanco.Text = cuenta.banco;
            txtNumeroCuenta.Text = cuenta.numeroCuenta;
            cbTipoCuenta.Text = cuenta.tipoCuenta;
        }

        private void InitializeComponent()
        {
            this.Text = "Cuenta Bancaria";
            this.ClientSize = new Size(360, 200);

            txtBanco = new TextBox { Left = 140, Top = 20, Width = 180 };
            txtNumeroCuenta = new TextBox { Left = 140, Top = 60, Width = 180 };
            cbTipoCuenta = new ComboBox
            {
                Left = 140,
                Top = 100,
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cbTipoCuenta.Items.Add("Corriente");
            cbTipoCuenta.Items.Add("Ahorro");

            var lblBanco = new Label { Text = "Banco:", Left = 20, Top = 23, AutoSize = true };
            var lblNumero = new Label { Text = "Número Cuenta:", Left = 20, Top = 63, AutoSize = true };
            var lblTipo = new Label { Text = "Tipo Cuenta:", Left = 20, Top = 103, AutoSize = true };

            btnGuardar = new Button
            {
                Text = "Guardar",
                Left = 140,
                Top = 140,
                Width = 100
            };
            btnGuardar.Click += BtnGuardar_Click;

            this.Controls.AddRange(new Control[]
            {
                lblBanco, txtBanco,
                lblNumero, txtNumeroCuenta,
                lblTipo, cbTipoCuenta,
                btnGuardar
            });

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmCuentaBancariaEdicion_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CuentaInfo.banco = txtBanco.Text;
            CuentaInfo.numeroCuenta = txtNumeroCuenta.Text;
            CuentaInfo.tipoCuenta = cbTipoCuenta.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}

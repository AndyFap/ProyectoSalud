using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    public partial class FrmProductoEdicion : Form
    {
        private TextBox txtNombre, txtTipoProducto, txtStock, txtStockMinimo, txtUnidadMedida, txtPrecio, txtFechaVencimiento, txtBodega;
        private Button btnGuardar;

        public Productos ProductoInfo { get; private set; }

        public FrmProductoEdicion()
        {
            ProductoInfo = new Productos();
            InitializeComponent();
        }

        public FrmProductoEdicion(Productos productos) : this()
        {
            ProductoInfo = productos;

            txtNombre.Text = productos.nombre;
            txtTipoProducto.Text = productos.tipoProducto;
            txtStock.Text = productos.stock.ToString();
            txtStockMinimo.Text = productos.stockMinimo.ToString();
            txtUnidadMedida.Text = productos.unidadMedida;
            txtPrecio.Text = productos.precio.ToString();
            txtFechaVencimiento.Text = productos.fechaVencimiento.ToString("yyyy-MM-dd");
            txtBodega.Text = productos.bodega;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            int leftLabel = 20;
            int leftText = 180;
            int top = 20;
            int spacing = 35;

            // Crear controles
            txtNombre = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblNombre = new Label { Left = leftLabel, Top = top + 3, Text = "Nombre:", AutoSize = true };
            top += spacing;

            txtTipoProducto = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblTipo = new Label { Left = leftLabel, Top = top + 3, Text = "Tipo Producto:", AutoSize = true };
            top += spacing;

            txtStock = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblStock = new Label { Left = leftLabel, Top = top + 3, Text = "Stock:", AutoSize = true };
            top += spacing;

            txtStockMinimo = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblStockMin = new Label { Left = leftLabel, Top = top + 3, Text = "Stock Mínimo:", AutoSize = true };
            top += spacing;

            txtUnidadMedida = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblUnidad = new Label { Left = leftLabel, Top = top + 3, Text = "Unidad Medida:", AutoSize = true };
            top += spacing;

            txtPrecio = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblPrecio = new Label { Left = leftLabel, Top = top + 3, Text = "Precio:", AutoSize = true };
            top += spacing;

            txtFechaVencimiento = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblFecha = new Label { Left = leftLabel, Top = top + 3, Text = "Fecha Vencimiento (YYYY-MM-DD):", AutoSize = true };
            top += spacing;

            txtBodega = new TextBox { Left = leftText, Top = top, Width = 300 };
            var lblBodega = new Label { Left = leftLabel, Top = top + 3, Text = "Bodega:", AutoSize = true };
            top += spacing;

            // Botón Guardar
            btnGuardar = new Button
            {
                Left = leftText,
                Top = top + 10,
                Width = 120,
                Text = "Guardar"
            };
            btnGuardar.Click += BtnGuardar_Click;

            // Tamaño del formulario
            this.ClientSize = new Size(520, top + 60);

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblTipo, txtTipoProducto,
                lblStock, txtStock,
                lblStockMin, txtStockMinimo,
                lblUnidad, txtUnidadMedida,
                lblPrecio, txtPrecio,
                lblFecha, txtFechaVencimiento,
                lblBodega, txtBodega,
                btnGuardar
            });

            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "FrmProductoEdicion";

            this.ResumeLayout(false);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ProductoInfo.nombre = txtNombre.Text;
            ProductoInfo.tipoProducto = txtTipoProducto.Text;
            ProductoInfo.stock = int.TryParse(txtStock.Text, out var stock) ? stock : 0;
            ProductoInfo.stockMinimo = int.TryParse(txtStockMinimo.Text, out var stockMinimo) ? stockMinimo : 0;
            ProductoInfo.unidadMedida = txtUnidadMedida.Text;
            ProductoInfo.precio = decimal.TryParse(txtPrecio.Text, out var precio) ? precio : 0m;
            ProductoInfo.fechaVencimiento = DateTime.TryParse(txtFechaVencimiento.Text, out var fechaVencimiento)
                ? fechaVencimiento : DateTime.MinValue;
            ProductoInfo.bodega = txtBodega.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}

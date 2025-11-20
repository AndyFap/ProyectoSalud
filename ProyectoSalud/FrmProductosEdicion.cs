using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.ProyectoSalud.Models
{
    /// <summary>
    /// Formulario para crear o editar productos
    /// Sigue el mismo patrón que FrmProveedoresEdicion
    /// </summary>
    public partial class FrmProductosEdicion : Form
    {
        // Controles del formulario
        private TextBox txtNombre, txtTipoProducto, txtStock, txtStockMinimo;
        private TextBox txtUnidadMedida, txtPrecio, txtBodega;
        private DateTimePicker dtpFechaVencimiento;
        private CheckBox chkTieneFechaVencimiento;
        private Button btnGuardar, btnCancelar;

        // Propiedad pública que contiene la información del producto
        public Producto ProductoInfo { get; private set; }

        /// <summary>
        /// Constructor para crear un nuevo producto
        /// </summary>
        public FrmProductosEdicion()
        {
            ProductoInfo = new Producto();
            InitializeComponent();
        }

        /// <summary>
        /// Constructor para editar un producto existente
        /// </summary>
        /// <param name="producto">Producto a editar</param>
        public FrmProductosEdicion(Producto producto) : this()
        {
            ProductoInfo = producto;

            // Cargar datos en los controles
            txtNombre.Text = producto.nombre;
            txtTipoProducto.Text = producto.tipoProducto;
            txtStock.Text = producto.stock.ToString();
            txtStockMinimo.Text = producto.stockMinimo.ToString();
            txtUnidadMedida.Text = producto.unidadMedida;
            txtPrecio.Text = producto.precio.ToString("F2");
            txtBodega.Text = producto.bodega;

            // Manejar fecha de vencimiento (puede ser null)
            if (producto.fechaVencimiento.HasValue)
            {
                chkTieneFechaVencimiento.Checked = true;
                dtpFechaVencimiento.Value = producto.fechaVencimiento.Value;
                dtpFechaVencimiento.Enabled = true;
            }
            else
            {
                chkTieneFechaVencimiento.Checked = false;
                dtpFechaVencimiento.Enabled = false;
            }
        }

        /// <summary>
        /// Inicializa todos los componentes del formulario
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            int labelWidth = 130;
            int labelLeft = 20;
            int controlLeft = labelLeft + labelWidth + 10;
            int controlWidth = 250;
            int rowHeight = 35;
            int currentTop = 20;

            // ===== NOMBRE =====
            var lblNombre = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Nombre:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtNombre = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = controlWidth,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== TIPO DE PRODUCTO =====
            var lblTipo = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Tipo de Producto:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtTipoProducto = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = controlWidth,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== STOCK =====
            var lblStock = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Stock Actual:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtStock = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = 120,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== STOCK MÍNIMO =====
            var lblStockMin = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Stock Mínimo:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtStockMinimo = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = 120,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== UNIDAD DE MEDIDA =====
            var lblUnidad = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Unidad de Medida:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtUnidadMedida = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = 150,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== PRECIO =====
            var lblPrecio = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Precio Unitario:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtPrecio = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = 120,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight;

            // ===== FECHA DE VENCIMIENTO =====
            var lblFecha = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Fecha Vencimiento:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            chkTieneFechaVencimiento = new CheckBox
            {
                Left = controlLeft,
                Top = currentTop,
                Width = 80,
                Text = "Aplica",
                Font = new Font("Segoe UI", 9F)
            };
            dtpFechaVencimiento = new DateTimePicker 
            { 
                Left = controlLeft + 85, 
                Top = currentTop, 
                Width = 165,
                Font = new Font("Segoe UI", 9F),
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };
            
            // Evento para habilitar/deshabilitar DateTimePicker
            chkTieneFechaVencimiento.CheckedChanged += (s, e) =>
            {
                dtpFechaVencimiento.Enabled = chkTieneFechaVencimiento.Checked;
            };
            currentTop += rowHeight;

            // ===== BODEGA =====
            var lblBodega = new Label 
            { 
                Left = labelLeft, 
                Top = currentTop + 3, 
                Width = labelWidth,
                Text = "Bodega:", 
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtBodega = new TextBox 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = controlWidth,
                Font = new Font("Segoe UI", 9F)
            };
            currentTop += rowHeight + 10;

            // ===== BOTONES =====
            btnGuardar = new Button 
            { 
                Left = controlLeft, 
                Top = currentTop, 
                Width = 120, 
                Height = 35,
                Text = "Guardar",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button 
            { 
                Left = controlLeft + 130, 
                Top = currentTop, 
                Width = 120, 
                Height = 35,
                Text = "Cancelar",
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // ===== CONFIGURACIÓN DEL FORM =====
            this.ClientSize = new Size(450, currentTop + 60);
            this.Controls.AddRange(new Control[] 
            {
                lblNombre, txtNombre,
                lblTipo, txtTipoProducto,
                lblStock, txtStock,
                lblStockMin, txtStockMinimo,
                lblUnidad, txtUnidadMedida,
                lblPrecio, txtPrecio,
                lblFecha, chkTieneFechaVencimiento, dtpFechaVencimiento,
                lblBodega, txtBodega,
                btnGuardar, btnCancelar
            });

            this.Text = ProductoInfo.productoID == 0 ? "Nuevo Producto" : "Editar Producto";
            this.Name = "FrmProductosEdicion";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            this.ResumeLayout(false);
        }

        /// <summary>
        /// Maneja el evento Click del botón Guardar
        /// Valida y guarda los datos del producto
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return;
            }

            // Asignar valores al objeto ProductoInfo
            ProductoInfo.nombre = txtNombre.Text.Trim();
            ProductoInfo.tipoProducto = txtTipoProducto.Text.Trim();
            ProductoInfo.stock = int.TryParse(txtStock.Text, out var stock) ? stock : 0;
            ProductoInfo.stockMinimo = int.TryParse(txtStockMinimo.Text, out var stockMin) ? stockMin : 0;
            ProductoInfo.unidadMedida = txtUnidadMedida.Text.Trim();
            ProductoInfo.precio = precio;
            ProductoInfo.bodega = txtBodega.Text.Trim();

            // Manejar fecha de vencimiento opcional
            if (chkTieneFechaVencimiento.Checked)
            {
                ProductoInfo.fechaVencimiento = dtpFechaVencimiento.Value;
            }
            else
            {
                ProductoInfo.fechaVencimiento = null;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}

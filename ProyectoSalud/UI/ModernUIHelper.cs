using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.UI
{
    /// <summary>
    /// Clase helper para crear componentes de UI modernos y consistentes
    /// </summary>
    public static class ModernUIHelper
    {
        // Paleta de colores moderna y sobria (Estilo Corporativo/Minimalista)
        public static readonly Color ColorPrimario = Color.FromArgb(44, 62, 80);      // Azul marino profundo (Midnight Blue)
        public static readonly Color ColorSecundario = Color.FromArgb(149, 165, 166); // Gris concreto
        public static readonly Color ColorExito = Color.FromArgb(39, 174, 96);        // Verde esmeralda (más elegante)
        public static readonly Color ColorPeligro = Color.FromArgb(192, 57, 43);      // Rojo ladrillo (menos agresivo)
        public static readonly Color ColorAdvertencia = Color.FromArgb(243, 156, 18); // Naranja suave
        public static readonly Color ColorInfo = Color.FromArgb(52, 152, 219);        // Azul claro (Peter River)
        
        public static readonly Color ColorFondo = Color.FromArgb(248, 249, 250);      // Gris muy claro (casi blanco)
        public static readonly Color ColorMenuOscuro = Color.FromArgb(33, 37, 41);    // Gris casi negro
        public static readonly Color ColorHeaderGrid = Color.FromArgb(44, 62, 80);    // Coincide con Primario para consistencia
        
        /// <summary>
        /// Crea un botón moderno con estilo flat sólido
        /// </summary>
        public static Button CrearBotonModerno(string texto, Color colorFondo, int ancho = 150, int alto = 40)
        {
            Button btn = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = colorFondo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), // Fuente regular para menos agresividad
                Size = new Size(ancho, alto),
                Margin = new Padding(5),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AjustarBrillo(colorFondo, 15);
            btn.FlatAppearance.MouseDownBackColor = AjustarBrillo(colorFondo, -15);
            
            return btn;
        }

        /// <summary>
        /// Crea un botón con estilo "Outline" (borde de color, fondo blanco) para acciones secundarias
        /// </summary>
        public static Button CrearBotonOutline(string texto, Color colorBorde, int ancho = 150, int alto = 40)
        {
            Button btn = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = colorBorde,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                Size = new Size(ancho, alto),
                Margin = new Padding(5),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = colorBorde;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            
            return btn;
        }
        
        /// <summary>
        /// Crea un botón primario (Sólido, para la acción principal)
        /// </summary>
        public static Button CrearBotonPrimario(string texto, int ancho = 150, int alto = 40)
        {
            return CrearBotonModerno(texto, ColorPrimario, ancho, alto);
        }
        
        /// <summary>
        /// Crea un botón de éxito (Outline, para acciones positivas secundarias)
        /// </summary>
        public static Button CrearBotonExito(string texto, int ancho = 150, int alto = 40)
        {
            // Usamos estilo Outline para no saturar
            return CrearBotonOutline(texto, ColorExito, ancho, alto);
        }
        
        /// <summary>
        /// Crea un botón de peligro (Outline, para acciones destructivas)
        /// </summary>
        public static Button CrearBotonPeligro(string texto, int ancho = 150, int alto = 40)
        {
             // Usamos estilo Outline para no saturar
            return CrearBotonOutline(texto, ColorPeligro, ancho, alto);
        }
        
        /// <summary>
        /// Crea un botón de información/neutro (Outline)
        /// </summary>
        public static Button CrearBotonInfo(string texto, int ancho = 150, int alto = 40)
        {
             // Usamos estilo Outline para no saturar
            return CrearBotonOutline(texto, Color.Gray, ancho, alto);
        }
        
        /// <summary>
        /// Aplica estilo moderno a un DataGridView
        /// </summary>
        public static void AplicarEstiloDataGrid(DataGridView dgv)
        {
            // Configuración general
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Estilo de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // Fondo blanco para encabezados (más limpio)
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Texto gris oscuro
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 45; // Un poco más alto
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single; // Borde sutil
            
            // Estilo de filas
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254); // Azul muy claro (estilo Google/Modern)
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en selección para legibilidad
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding = new Padding(8); // Más padding
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgv.RowTemplate.Height = 40; // Filas más altas
            
            // Alternar colores de filas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // Gris muy sutil
            
            // Grid lines
            dgv.GridColor = Color.FromArgb(240, 240, 240); // Líneas de cuadrícula muy sutiles
        }
        
        /// <summary>
        /// Crea un panel de título moderno y limpio (Fondo blanco, texto oscuro)
        /// </summary>
        public static Panel CrearPanelTitulo(string titulo, int altura = 70)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = altura,
                BackColor = Color.White, // Fondo blanco
                Padding = new Padding(0, 0, 0, 1) // Padding para el borde inferior
            };
            
            // Línea separadora inferior
            Panel linea = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(230, 230, 230) // Gris claro
            };
            
            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 18F, FontStyle.Regular), // Fuente más grande y ligera
                ForeColor = ColorPrimario, // Color del tema
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            
            panel.Controls.Add(linea);
            panel.Controls.Add(lblTitulo);
            return panel;
        }
        
        /// <summary>
        /// Crea un panel de botones con FlowLayout
        /// </summary>
        /// <summary>
        /// Crea un panel de botones con FlowLayout responsivo
        /// </summary>
        public static Panel CrearPanelBotones(params Button[] botones)
        {
            Panel panelBotones = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80, // Aumentado para dar más aire
                BackColor = Color.White,
                Padding = new Padding(10, 10, 10, 10) // Padding uniforme
            };
            
            FlowLayoutPanel flowBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5),
                AutoSize = false, // Cambiado a false para controlar mejor el layout dentro del panel
                WrapContents = false, // Evitar salto de línea prematuro, mejor usar scroll si es necesario o ajustar tamaño
                AutoScroll = true // Permitir scroll si la ventana es muy pequeña
            };
            
            // Ajustar márgenes de los botones para que no se peguen
            foreach (var btn in botones)
            {
                btn.Margin = new Padding(0, 0, 15, 0); // Margen derecho de 15px entre botones
            }
            
            flowBotones.Controls.AddRange(botones);
            panelBotones.Controls.Add(flowBotones);
            
            // Línea separadora inferior sutil
            Panel linea = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(240, 240, 240)
            };
            panelBotones.Controls.Add(linea);
            
            return panelBotones;
        }
        
        /// <summary>
        /// Ajusta el brillo de un color
        /// </summary>
        public static Color AjustarBrillo(Color color, int cantidad)
        {
            int r = Math.Max(0, Math.Min(255, color.R + cantidad));
            int g = Math.Max(0, Math.Min(255, color.G + cantidad));
            int b = Math.Max(0, Math.Min(255, color.B + cantidad));
            return Color.FromArgb(color.A, r, g, b);
        }
        
        /// <summary>
        /// Muestra un mensaje de notificación tipo toast
        /// </summary>
        public static void MostrarNotificacion(Form parent, string mensaje, Color color, int duracionMs = 3000)
        {
            Panel panelNotif = new Panel
            {
                BackColor = color,
                Size = new Size(300, 60),
                Location = new Point(parent.Width - 320, parent.Height - 80)
            };
            
            Label lblMensaje = new Label
            {
                Text = mensaje,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            
            panelNotif.Controls.Add(lblMensaje);
            parent.Controls.Add(panelNotif);
            panelNotif.BringToFront();
            
            // Timer para ocultar la notificación
            Timer timer = new Timer { Interval = duracionMs };
            timer.Tick += (s, e) =>
            {
                parent.Controls.Remove(panelNotif);
                panelNotif.Dispose();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        
        /// <summary>
        /// Crea un TextBox moderno con placeholder
        /// </summary>
        public static TextBox CrearTextBoxModerno(string placeholder = "")
        {
            TextBox txt = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 30
            };
            
            if (!string.IsNullOrEmpty(placeholder))
            {
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;
                
                txt.Enter += (s, e) =>
                {
                    if (txt.Text == placeholder)
                    {
                        txt.Text = "";
                        txt.ForeColor = Color.Black;
                    }
                };
                
                txt.Leave += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        txt.Text = placeholder;
                        txt.ForeColor = Color.Gray;
                    }
                };
            }
            
            return txt;
        }
    }
}

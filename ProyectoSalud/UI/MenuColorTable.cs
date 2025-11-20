using System.Drawing;
using System.Windows.Forms;

namespace ProyectoSalud.UI
{
    /// <summary>
    /// Tabla de colores personalizada para el MenuStrip moderno
    /// </summary>
    public class MenuColorTable : ProfessionalColorTable
    {
        // Color de fondo del menú
        public override Color MenuStripGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color MenuStripGradientEnd => Color.FromArgb(45, 45, 48);
        
        // Color cuando el mouse está sobre un item
        public override Color MenuItemSelected => Color.FromArgb(62, 62, 66);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(62, 62, 66);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(62, 62, 66);
        
        // Color del borde cuando está seleccionado
        public override Color MenuItemBorder => Color.FromArgb(0, 122, 204);
        
        // Color cuando se presiona un item
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(0, 122, 204);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(0, 122, 204);
        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(0, 122, 204);
        
        // Color de fondo del dropdown
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);
        
        // Color del borde del dropdown
        public override Color MenuBorder => Color.FromArgb(62, 62, 66);
        
        // Color de los separadores
        public override Color SeparatorDark => Color.FromArgb(62, 62, 66);
        public override Color SeparatorLight => Color.FromArgb(62, 62, 66);
        
        // Color del item cuando está presionado y el menú está abierto
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);
    }
}

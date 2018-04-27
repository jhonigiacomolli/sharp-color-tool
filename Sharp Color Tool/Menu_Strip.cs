
using System.Windows.Forms;
using System.Drawing;

namespace Sharp_Color_Tool
{
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
           
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
                e.Item.BackColor = Color.FromArgb(40,40,40);
            }
            else
            {
                e.Item.BackColor = Color.White ;
            }
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            if (!e.Item.Selected)
            {
                e.Item.ForeColor = Color.Silver;
            }
            else
            {
                e.Item.ForeColor = Color.Black;
            }
        }
        
    }
    public class MenuStripAllowsCustomHighlight : MenuStrip
    {
        public MenuStripAllowsCustomHighlight()
        {
            this.Renderer = new MyRenderer();
        }
    }
}

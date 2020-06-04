using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Project
{
    class GradientPanel : Panel
    {

        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }
        public float angular { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                LinearGradientBrush LGB = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, angular);
                Graphics g = e.Graphics;
                g.FillRectangle(LGB, this.ClientRectangle);
                base.OnPaint(e);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }

}

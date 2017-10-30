using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WorldEditor
{
    public static class CustomPens
    {
        static CustomPens()
        {
            dashPen = new Pen(Color.Magenta);
            dashPen.DashStyle = DashStyle.Dash;
        }

        private static Pen dashPen;

        public static Pen DashPen
        {
            get
            {
                return dashPen;
            }
        }
    }
}

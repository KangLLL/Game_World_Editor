using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WorldEditor
{
    public static class CustomBrushes
    {
        static CustomBrushes()
        {
            transparentBrush = new TextureBrush(global::WorldEditor.Properties.Resources.BackgroundTransparent);
        }

        public static Brush TransparentBrush
        {
            get
            {
                return transparentBrush;
            }
        }

        private static TextureBrush transparentBrush;

    }
}

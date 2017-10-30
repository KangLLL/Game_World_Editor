using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;

namespace WorldEditor
{
    public class StaticTileSetData
    {
        public StaticTileSetData()
        {
            this.name = "未命名" + this.GetHashCode().ToString();
            this.filename = string.Empty;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string filename;

        public string Filename
        {
            get { return filename; }
            set 
            { 
                filename = value;
                this.bitmap = new Bitmap(Application.StartupPath + filename);
                this.CreateSurface();
                
                //int width = bitmap.Width / 16;
                //int height = bitmap.Height / 16;
                //this.propertyTable = new byte[width, height];
                //for(int i=0;i<width;i++)
                //{
                //    for(int j = 0;j<height;j++)
                //    {
                //        this.propertyTable[i, j] = 0x01;
                //    }
                //}
            }
        }

        //private int width;

        //public int Width
        //{
        //    get
        //    {
        //        return this.width;
        //    }
        //}

        //private int height;

        //public int Height
        //{
        //    get
        //    {
        //        return this.height;
        //    }
        //}

        private Surface surfaceHalf;

        public Surface SurfaceHalf
        {
            get
            {
                if (this.surfaceHalf != null)
                {
                    if (!this.surfaceHalf.IsLost)
                        this.CreateSurface();
                }
                return this.surfaceHalf;
            }
        }

        private Surface surfaceTwo;

        public Surface SurfaceTwo
        {
            get
            {
                if (this.surfaceTwo != null)
                {
                    if (!this.surfaceTwo.IsLost)
                        this.CreateSurface();
                }
                return this.surfaceTwo;
            }
        }

        private Surface surfaceFour;

        public Surface SurfaceFour
        {
            get
            {
                if (this.surfaceFour != null)
                {
                    if (!this.surfaceFour.IsLost)
                        this.CreateSurface();
                }
                return this.surfaceFour;
            }
        }

        private Surface surface;

        public Surface Surface
        {
            get
            {
                if (this.surface != null)
                {
                    if (!this.surface.IsLost)
                        this.CreateSurface();
                }
                return this.surface;
            }
        }



        private Bitmap bitmap;

        public Bitmap Bitmap
        {
            get
            {
                return this.bitmap;
            }
        }

        //private byte[,] propertyTable;

        //public byte[,] PropertyTable
        //{
        //    get
        //    {
        //        return this.propertyTable;
        //    }
        //}

        public override string ToString()
        {
            return this.name;
        }

        private void CreateSurface()
        {
            if (this.surface != null)
            {
                this.surface.Dispose();
            }

            SurfaceDescription surfaceDescription = new SurfaceDescription();

            ColorKey colorKey = new ColorKey();
            colorKey.ColorSpaceLowValue = colorKey.ColorSpaceHighValue = 0xd3;
            surfaceDescription.SourceDraw = colorKey;
            surfaceDescription.SurfaceCaps.VideoMemory = true;

            this.bitmap= new Bitmap(this.bitmap, this.bitmap.Width, this.bitmap.Height);

            Bitmap bitmapHalf = new Bitmap(this.bitmap, this.bitmap.Width / 2, this.bitmap.Height / 2);
            Bitmap bitmapTwo = new Bitmap(this.bitmap, this.bitmap.Width * 2, this.bitmap.Height * 2);
            Bitmap bitmapFour = new Bitmap(this.bitmap, this.bitmap.Width * 4, this.bitmap.Height * 4);
            
           
            this.surface = new Surface(this.bitmap, surfaceDescription, MainForm.Device);
            surfaceDescription.Width = bitmapTwo.Width;
            surfaceDescription.Height = bitmapTwo.Height;
            this.surfaceTwo = new Surface(bitmapTwo, surfaceDescription, MainForm.Device);
            surfaceDescription.Width = bitmapFour.Width;
            surfaceDescription.Height = bitmapFour.Height;
            this.surfaceFour = new Surface(bitmapFour, surfaceDescription, MainForm.Device);
            surfaceDescription.Width = bitmapHalf.Width;
            surfaceDescription.Height = bitmapHalf.Height;
            this.surfaceHalf = new Surface(bitmapHalf, surfaceDescription, MainForm.Device);

            bitmapHalf.Dispose();
            bitmapTwo.Dispose();
            bitmapFour.Dispose();
        }
    }
}

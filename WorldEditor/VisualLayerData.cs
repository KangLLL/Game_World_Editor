using System;
using System.Drawing;

namespace WorldEditor
{
    public class VisualLayerData
    {

        public VisualLayerData(int width,int height, int staticBitmapID,int dynamicBitmapID,string name)
        {
            this.staticBitmapID = staticBitmapID;
            this.dynamicBitmapID = dynamicBitmapID;
            this.visualLayerTable = new byte[width, height];
            this.visualPropertyTable = new byte[width, height];
            this.name = name;
        }

        private bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int staticBitmapID;

        public int StaticBitmapID
        {
            get { return staticBitmapID; }
            set { staticBitmapID = value; }
        }


        private int dynamicBitmapID;

        public int DynamicBitmapID
        {
            get { return dynamicBitmapID; }
            set { dynamicBitmapID = value; }
        }


        private byte[,] visualLayerTable;

        public byte[,] VisualLayerTable
        {
            get
            {
                return visualLayerTable;
            }
        }

        private byte[,] visualPropertyTable;

        public byte[,] VisualPropertyTable
        {
            get 
            { 
                return visualPropertyTable; 
            }
        }


        public int VerticalTileCount
        {
            get { return this.visualLayerTable.GetLength(1); }
            set 
            {
                ResizeLayerTable(0, 0, 0, 0, HorizontalTileCount, value); 
            }
        }


        public int HorizontalTileCount
        {
            get { return this.visualLayerTable.GetLength(0); }
            set
            {
                ResizeLayerTable(0, 0, 0, 0, value, VerticalTileCount); 
            }
        }

        public void ResizeLayerTable(int srcStartX, int srcStartY, int destStartX, int destStartY, int width, int height)
        {
            int oldWidth = this.visualLayerTable.GetLength(0);
            int oldHeight = this.visualLayerTable.GetLength(1);


            byte[,] newVisualLayerTable = new byte[width, height];
            byte[,] newVisualPropertyTable = new byte[width, height];

            int xLenth = (oldWidth - srcStartX < width) ? oldWidth - srcStartX : width;

            int yLenth = (oldHeight - srcStartY < height) ? oldHeight - srcStartY : height;

            xLenth = (destStartX + xLenth < width) ? xLenth : width - destStartX;

            yLenth = (destStartY + yLenth < height) ? yLenth : height - destStartY;

            for (int x = 0; x < xLenth; x++)
            {
                for (int y = 0; y < yLenth; y++)
                {
                    newVisualLayerTable[destStartX + x, destStartY + y] = this.visualLayerTable[srcStartX + x, srcStartY + y];
                    newVisualPropertyTable[destStartX + x, destStartY + y] = this.visualPropertyTable[srcStartX + x, srcStartY + y];
                }
            }

            this.visualLayerTable = newVisualLayerTable;
            this.visualPropertyTable = newVisualPropertyTable;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}

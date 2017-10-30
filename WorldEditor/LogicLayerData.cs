using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WorldEditor
{
    class LogicLayerData
    {
        public LogicLayerData(int width,int height)
        {
            this.logicLayerTable = new byte[width, height];
            this.eventRegionList = new List<EventRegion>();
        }

        private byte[,] logicLayerTable;

        public byte[,] LogicLayerTable
        {
            get { return logicLayerTable; }
            set { logicLayerTable = value; }
        }

        public int HorizontalTileCount
        {
            get
            {
                return this.logicLayerTable.GetLength(0);
            }
            set
            {
                ResizeLayerTable(0, 0, 0, 0, value, VerticalTileCount);
            }
        }

        public int VerticalTileCount
        {
            get
            {
                return this.logicLayerTable.GetLength(1);
            }
            set
            {
                ResizeLayerTable(0, 0, 0, 0, HorizontalTileCount, value);
            }
        }

        private List<EventRegion> eventRegionList;

        public List<EventRegion> EventRegionList
        {
            get { return eventRegionList; }
            set { eventRegionList = value; }
        }

        public bool CheckRegionName(string name)
        {
            for (int i = 0; i < this.eventRegionList.Count; i++)
            {
                if (this.eventRegionList[i].Name == name)
                {
                    return false;
                }
            }
            return true;
        }

        public void CheckRegionValid()
        {
            int maxX = this.HorizontalTileCount * 16;
            int maxY = this.VerticalTileCount * 16;
            List<EventRegion> tempEventRegionList = new List<EventRegion>();

            for (int i = 0; i < this.EventRegionList.Count; i++)
            {
                EventRegion eventRegion = this.EventRegionList[i];
                Rectangle regionRect = eventRegion.RegionRect;
                if (regionRect.Left <= maxX && regionRect.Top <= maxY)
                {
                    int left = regionRect.Left;
                    int right = regionRect.Right;
                    int top = regionRect.Top;
                    int bottom = regionRect.Bottom;
                    if (regionRect.Right > maxX)
                    {
                        right = maxX;
                        eventRegion.RegionRect = new Rectangle(left, top, right - left, bottom - top);
                    }
                    if (regionRect.Bottom > maxY)
                    {
                        bottom = maxY;
                        eventRegion.RegionRect = new Rectangle(left, top, right - left, bottom - top);
                    }
                    tempEventRegionList.Add(eventRegion);
                }
            }

            this.EventRegionList.Clear();
            for (int i = 0; i < tempEventRegionList.Count; i++)
            {
                this.EventRegionList.Add(tempEventRegionList[i]);
            }

        }

        public int TraveRegionList(Point position)
        {
            for (int i = 0; i < this.EventRegionList.Count; i++)
            {
                if (this.EventRegionList[i].RegionRect.Contains(position))
                {
                    return i;
                }
            }
            return -1;
        }

        public void ResizeLayerTable(int srcStartX, int srcStartY, int destStartX, int destStartY, int width, int height)
        {
            int oldWidth = this.HorizontalTileCount;
            int oldHeight = this.VerticalTileCount;


            byte[,] newLogicLayerTable = new byte[width, height];

            int xLenth = (oldWidth - srcStartX < width) ? oldWidth - srcStartX : width;

            int yLenth = (oldHeight - srcStartY < height) ? oldHeight - srcStartY : height;

            xLenth = (destStartX + xLenth < width) ? xLenth : width - destStartX;

            yLenth = (destStartY + yLenth < height) ? yLenth : height - destStartY;

            for (int x = 0; x < xLenth; x++)
            {
                for (int y = 0; y < yLenth; y++)
                {
                    newLogicLayerTable[destStartX + x, destStartY + y] = this.logicLayerTable[srcStartX + x, srcStartY + y];
                }
            }

            this.logicLayerTable = newLogicLayerTable;
        }

    }
}

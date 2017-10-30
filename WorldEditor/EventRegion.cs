using System;
using System.Text;
using System.Drawing;

namespace WorldEditor
{
    public class EventRegion
    {

        public EventRegion(string name,Rectangle regionRect)
        {
            this.name = name;
            this.regionRect = regionRect;
        }
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private Rectangle regionRect;
        public Rectangle RegionRect
        {
            get
            {
                return this.regionRect;
            }
            set
            {
                this.regionRect = value;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WorldEditor
{
    public class DynamicTileData
    {
        public DynamicTileData()
        {
            this.slowRegenerationRate = 1;
            this.frameList = new List<Byte>();
            //listBoxAnimationFrame = new ListBox();
            //listBoxAnimationFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            //listBoxAnimationFrame.Location = new System.Drawing.Point(246, 295);
            //listBoxAnimationFrame.Name = "listBox动态图块帧";
            //listBoxAnimationFrame.Size = new System.Drawing.Size(258, 40);

            //listBoxAnimationFrame.DrawItem += new DrawItemEventHandler(listBoxAnimationFrame_DrawItem);
            //listBoxAnimationFrame.SelectedIndexChanged += new EventHandler(listBoxAnimationFrame_SelectedIndexChanged);


        }

        //void listBoxAnimationFrame_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //void listBoxAnimationFrame_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        private int slowRegenerationRate;

        public int SlowRegenerationRate
        {
            get { return slowRegenerationRate; }
            set { slowRegenerationRate = value; }
        }

        //private ListBox listBoxAnimationFrame;

        //public ListBox Listbox
        //{
        //    get
        //    {
        //        return listBoxAnimationFrame;
        //    }
        //}


        private List<Byte> frameList;

        public List<Byte> FrameList
        {
            get
            {
                return frameList;
            }
        }

        //private Byte property = 0x02;

        //public Byte Property
        //{
        //    get { return property; }
        //    set { property = value; }
        //}


    }
}

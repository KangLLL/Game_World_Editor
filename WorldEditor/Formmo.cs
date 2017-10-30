using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form地图 : Form
    {
        public Form地图(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            this.pictureBox地图窗口.ClientSize = new Size(this.mainForm.ScreenWidth, this.mainForm.ScreenHeight);

            this.mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;

            this.velocity = new float[this.mapData.VisualLayerDataList.Count, 2];

            this.numericUpDown宽度.Value = mainForm.ScreenWidth;
            this.numericUpDown高度.Value = mainForm.ScreenHeight;

        }

        private MainForm mainForm;
        private MapData mapData;
        private float[,] velocity;
        private int widthOfLogicLayer;
        private int heightOfLogicLayer;
        private int timerCount;


        private void setVelocityX()
        {
            if (this.widthOfLogicLayer * 16 == this.pictureBox地图窗口.ClientSize.Width)
            {
                for (int i = 0; i < this.mapData.VisualLayerDataList.Count; i++)
                {
                    this.velocity[i, 0] = 0;
                }
            }
            else
            {
                for (int i = 0; i < this.mapData.VisualLayerDataList.Count; i++)
                {
                    VisualLayerData layerData = this.ChangeToLayer(i);
                    if (layerData.HorizontalTileCount * 16 < this.pictureBox地图窗口.ClientSize.Width)
                    {
                        this.velocity[i, 0] = 0;
                    }
                    else
                    {
                        this.velocity[i, 0] = (float)(layerData.HorizontalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Width) / (this.widthOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Width);
                    }
                }
                //this.velocity[1, 0] = 1;
                //VisualLayerData layerData = this.ChangeToLayer(1);
                //this.velocity[0, 0] = (float)(layerData.HorizontalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Width) / (this.widthOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Width);
                //layerData = this.ChangeToLayer(3);
                //this.velocity[2, 0] = (float)(layerData.HorizontalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Width) / (this.widthOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Width);
            }
        }

        private void setVelocityY()
        {
            if (this.heightOfLogicLayer * 16 == this.pictureBox地图窗口.ClientSize.Height)
            {
                for (int i = 0; i < this.mapData.VisualLayerDataList.Count; i++)
                {
                    this.velocity[i, 1] = 0;
                }
            }
            else
            {
                for (int i = 0; i < this.mapData.VisualLayerDataList.Count; i++)
                {
                    VisualLayerData layerData = this.ChangeToLayer(i);
                    if (layerData.VerticalTileCount * 16 < this.pictureBox地图窗口.ClientSize.Height)
                    {
                        this.velocity[i, 1] = 0;
                    }
                    else
                    {
                        this.velocity[i, 1] = (float)(layerData.VerticalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Height) / (this.heightOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Height);
                    }
                }
                //this.velocity[1, 1] = 1;
                //VisualLayerData layerData = this.ChangeToLayer(1);
                //this.velocity[0, 1] = (float)(layerData.VerticalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Height) / (this.heightOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Height);
                //layerData = this.ChangeToLayer(3);
                //this.velocity[2, 1] = (float)(layerData.VerticalTileCount * 16 - this.pictureBox地图窗口.ClientSize.Height) / (this.heightOfLogicLayer * 16 - this.pictureBox地图窗口.ClientSize.Height);
            }
        }

        private void pictureBox地图窗口_Paint(object sender, PaintEventArgs e)
        {
            if (this.mapData.IsFillBackColor)
            {
                SolidBrush backColorBrush = new SolidBrush(mapData.BackColor);
                e.Graphics.FillRectangle(backColorBrush, this.pictureBox地图窗口.ClientRectangle);
                backColorBrush.Dispose();
            }
            else
            {
                e.Graphics.FillRectangle(CustomBrushes.TransparentBrush, this.pictureBox地图窗口.ClientRectangle);
            }
            for (int i = 0; i < this.mapData.VisualLayerDataList.Count; i++)
            {
                this.PaintLayer(i, e.Graphics);
            }
        }

        private void Form地图_Load(object sender, EventArgs e)
        {
            this.widthOfLogicLayer = this.mapData.LogicLayer.HorizontalTileCount;
            this.heightOfLogicLayer = this.mapData.LogicLayer.VerticalTileCount;

            this.setVelocityX();
            this.setVelocityY();

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        System.Console.WriteLine(this.velocity[i, j]);
            //    }
            //}
            this.Text = mapData.Name;

            this.hScrollBar1.Value = 0;
            this.hScrollBar1.Maximum = this.widthOfLogicLayer * 16 - 1;
            this.hScrollBar1.LargeChange = this.mainForm.ScreenWidth;

            this.vScrollBar1.Value = 0;
            this.vScrollBar1.Maximum = this.heightOfLogicLayer * 16 - 1;
            this.vScrollBar1.LargeChange = this.mainForm.ScreenHeight;
        }

        private void PaintLayer(int i, Graphics graphics)
        {
            VisualLayerData operationLayerData = this.ChangeToLayer(i);
            StaticTileSetData staticTileSetData = this.LoadStaticTileSetData(operationLayerData);
            DynamicTileSetData dynamicTileSetData = this.LoadDynamicTileSetData(operationLayerData);
            Bitmap bitmap = null;

            float startX = this.hScrollBar1.Value * this.velocity[i, 0];
            float startY = this.vScrollBar1.Value * this.velocity[i, 1];
            float endX = this.hScrollBar1.Value * this.velocity[i, 0] + this.pictureBox地图窗口.ClientSize.Width;
            float endY = this.vScrollBar1.Value * this.velocity[i, 1] + this.pictureBox地图窗口.ClientSize.Height;

            int startTileX = (int)startX >> 4;
            int startTileY = (int)startY >> 4;
            int endTileX = ((endX % 16) != 0) ? (int)endX >> 4 : ((int)endX >> 4) - 1;
            int endTileY = ((endY % 16) != 0) ? (int)endY >> 4 : ((int)endY >> 4) - 1;

            byte positionXY;
            byte positionX=0;
            byte positionY=0;
            int dynamicTileID;

            int xlenth = endTileX - startTileX + 1;
            int ylenth = endTileY - startTileY + 1;

            xlenth = xlenth > operationLayerData.HorizontalTileCount ? operationLayerData.HorizontalTileCount : xlenth;
            ylenth = ylenth > operationLayerData.VerticalTileCount ? operationLayerData.VerticalTileCount : ylenth;

            for (int j = 0; j < xlenth; j++)
            {
                for (int k = 0; k < ylenth; k++)
                {
                    Rectangle srcRect = new Rectangle();
                    Rectangle destRect = new Rectangle();
                    byte property = operationLayerData.VisualPropertyTable[startTileX + j, startTileY + k];
                    byte visualProperty = (byte)(property & 0x03);
                    switch (visualProperty)
                    {
                        case 0:
                            {
                                bitmap = null;
                            }
                            break;
                        case 1:
                            {
                                if (staticTileSetData != null)
                                {
                                    bitmap = staticTileSetData.Bitmap;
                                    positionXY = operationLayerData.VisualLayerTable[startTileX + j, startTileY + k];
                                    positionX = (byte)(positionXY & 0x0F);
                                    positionY = (byte)(positionXY >> 4);
                                }
                            }
                            break;
                        case 2:
                            {

                                if (dynamicTileSetData != null)
                                {
                                    bitmap = dynamicTileSetData.Bitmap;
                                    dynamicTileID = operationLayerData.VisualLayerTable[startTileX + j, startTileY + k];
                                    positionXY = this.playDynamicTile(dynamicTileSetData.DynamicTileDataList[dynamicTileID]);
                                    positionX = (byte)(positionXY & 0x0F);
                                    positionY = (byte)(positionXY >> 4);
                                }
                            }
                            break;
                        default:
                            break;
                    }


                    if (bitmap != null)
                    {
                        destRect = new Rectangle((int)((float)(-this.hScrollBar1.Value * this.velocity[i, 0])) % 16 + j * 16, (int)((float)(-this.vScrollBar1.Value * this.velocity[i, 1])) % 16 + k * 16, 16, 16);


                        srcRect = new Rectangle(positionX * 16, positionY * 16, 16, 16);
                        byte flipMode = (byte)((property>>2) & 0x03);

                        switch (flipMode)
                        {
                            case 1:
                                {
                                    srcRect = new Rectangle((positionX + 1) * 16, positionY * 16, -16, 16);
                                }
                                break;
                            case 2:
                                {
                                    srcRect = new Rectangle(positionX * 16, (positionY + 1) * 16, 16, -16);
                                }
                                break;
                            case 3:
                                {
                                    srcRect = new Rectangle((positionX + 1) * 16, (positionY + 1) * 16, -16, -16);
                                }
                                break;
                            default:
                                break;
                        }
                        graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                }
            }
        }

        private StaticTileSetData LoadStaticTileSetData(VisualLayerData layerData)
        {
            int staticBitmapID = layerData.StaticBitmapID;
            if (staticBitmapID == -1)
            {
                return null;
            }
            StaticTileSetData staticTileSetData = this.mainForm.Form元数据.ListBox静态图块集.Items[staticBitmapID] as StaticTileSetData;
            return staticTileSetData;
        }

        private DynamicTileSetData LoadDynamicTileSetData(VisualLayerData layerData)
        {
            int dynamicBitmapID = layerData.DynamicBitmapID;
            if (dynamicBitmapID == -1)
            {
                return null;
            }
            DynamicTileSetData dynamicTileSetData = this.mainForm.Form元数据.ListBox动态图块集.Items[dynamicBitmapID] as DynamicTileSetData;
            return dynamicTileSetData;
        }

        private VisualLayerData ChangeToLayer(int i)
        {
            return this.mapData.VisualLayerDataList[i]; 
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel地图信息.Text = "X=" + this.hScrollBar1.Value + "  " + "Y=" + this.vScrollBar1.Value;
            this.pictureBox地图窗口.Invalidate();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel地图信息.Text = "X=" + this.hScrollBar1.Value + "  " + "Y=" + this.vScrollBar1.Value;
            this.pictureBox地图窗口.Invalidate();
        }

        private byte playDynamicTile(DynamicTileData dynamicTileData)
        {
            int k = (this.timerCount / dynamicTileData.SlowRegenerationRate) % dynamicTileData.FrameList.Count;
            return dynamicTileData.FrameList[k];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timerCount++;
            this.pictureBox地图窗口.Invalidate();
        }

        private void ResizeScrollBar()
        {
            this.hScrollBar1.LargeChange = this.pictureBox地图窗口.ClientSize.Width;
            this.vScrollBar1.LargeChange = this.pictureBox地图窗口.ClientSize.Height;
        }

        private void numericUpDown宽度_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox地图窗口.ClientSize = new Size((int)this.numericUpDown宽度.Value, (int)this.numericUpDown高度.Value);
            this.ResizeScrollBar();
            this.setVelocityX();
            this.pictureBox地图窗口.Invalidate();
        }

        private void numericUpDown高度_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox地图窗口.ClientSize = new Size((int)this.numericUpDown宽度.Value, (int)this.numericUpDown高度.Value);
            this.ResizeScrollBar();
            this.setVelocityY();
            this.pictureBox地图窗口.Invalidate();
        }

        public NumericUpDown NumericUpDown宽度
        {
            get
            {
                return this.numericUpDown宽度;
            }
        }

        public NumericUpDown NumericUpDown高度
        {
            get
            {
                return this.numericUpDown高度;
            }
        }
        
    }
}
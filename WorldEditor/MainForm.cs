using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectDraw;
using JavaIOHelper;

namespace WorldEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.form元数据 = new Form元数据(this);
            this.form配置触发器 = new Form配置触发器(this);
            InitializeComponent();

            this.toolStripStatusLabel选择信息.Text = string.Empty;
        }

        #region Managed DirectX

        private static Device device;

        public static Device Device
        {
            get
            {
                return device;
            }
        }

        private Surface surface地图;
        private Surface transparentSurface;
        private DrawEffects drawEffects;

        private void CreateDevice()
        {
            device = new Device();
            device.SetCooperativeLevel(this, CooperativeLevelFlags.Normal);
            drawEffects = new DrawEffects();

        }

        private void CreateSurface()
        {
            SurfaceDescription surfaceDescription = new SurfaceDescription();
            surfaceDescription.Width = this.pictureBox地图.ClientSize.Width;
            surfaceDescription.Height = this.pictureBox地图.ClientSize.Height;
            surfaceDescription.SurfaceCaps.OffScreenPlain = true;
            surfaceDescription.SurfaceCaps.VideoMemory = true;
            surfaceDescription.SourceDraw = new ColorKey();
            surface地图 = new Surface(surfaceDescription, device);

            surfaceDescription.Clear();
            surfaceDescription.SurfaceCaps.VideoMemory = true;
            transparentSurface = new Surface(global::WorldEditor.Properties.Resources.BackgroundTransparent, surfaceDescription, device);
        }

        #endregion

        private int staticSelectedTileStartX;
        private int staticSelectedTileStartY;
        //private int dynamicSelectedTileStartX;
        //private int dynamicSelectedTileStartY;
        private int staticSelectedTileEndX;
        private int staticSelectedTileEndY;
        //private int dynamicSelectedTileEndX;
        //private int dynamicSelectedTileEndY;
        private int dynamicSelectedID;
        private float magnification = 1;
        private int mapStartTileX;
        private int mapStartTileY;
        private int mapEndTileX;
        private int mapEndTileY;
        private int mapMoveTileX;
        private int mapMoveTileY;
        //private Rectangle mapClipRect;
        //private Rectangle tempMapClipRect;
        private EditMode editMode = EditMode.Draw;
        private int clipRectStartTileX;
        private int clipRectStartTileY;
        private int clipRectEndTileX;
        private int clipRectEndTileY;
        private byte[,] copyData;
        private byte[,] copyPropertyData;
        private int clipRectStartX1;
        private int clipRectStartY1;
        private int regionRectStartX;
        private int regionRectStartY;
        private int regionRectEndX;
        private int regionRectEndY;
        //private Color backColor;
        private int regionSelectID = -1;
        private int regionDisplayTimerCount;
        private bool regionDisplayMode;
        private RegionEditMode regionEditMode;
        private bool isRegionSelected;
        private Point regionStartPosition;
        private Rectangle regionOrgRect;
        private int stretchRegionDirection;
        //private Point moveRegionEndPosition;
        //private Rectangle tempRegionRect;
        private bool isCreateRegion;
        private bool isLogicColorful;

        private int logicNum;

        public int LogicNum
        {
            get
            {
                return this.logicNum;
            }
        }


        private int timerCount;

        private VisualLayerData currentOperationLayerData;

        private int screenWidth = 240;

        public int ScreenWidth
        {
            get { return screenWidth; }
            set
            {
                screenWidth = value;
                this.ResizeScrollBar();
            }
        }

        private int screenHeight = 320;

        public int ScreenHeight
        {
            get { return screenHeight; }
            set
            {
                screenHeight = value;
                this.ResizeScrollBar();
            }
        }


        private void ChangeToPreviousLayerLayer()
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            VisualLayerData visualLayerData = mapData.VisualLayerDataList[--this.listBox可视层.SelectedIndex];
            this.SetCurrentOperationLayer(visualLayerData);
        }

        private void ChangeToNextLayer()
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            VisualLayerData visualLayerData = mapData.VisualLayerDataList[++this.listBox可视层.SelectedIndex];
            this.SetCurrentOperationLayer(visualLayerData);
        }

        private void OpenLogicLayer()
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (mapData != null)
            {
                //this.ResizeScrollBar();
                this.toolStripButton逻辑层.Checked = true;
                this.toolStripMenuItem逻辑层.Checked = true;
                //this.toolStripButton逻辑刷.Enabled = true;
            }
        }

        private void CloseLogicLayer()
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (mapData != null)
            {
                //this.ResizeScrollBar();
                this.toolStripButton逻辑层.Checked = false;
                this.toolStripMenuItem逻辑层.Checked = false;
            }
        }

        //private void ChangeToFirstLayer()
        //{
        //    this.toolStripMenuItem第一层.Checked = true;
        //    this.toolStripMenuItem第二层.Checked = false;
        //    this.toolStripMenuItem第三层.Checked = false;
        //    this.toolStripMenuItem事件层.Checked = false;
        //    this.toolStripButton第一层.Checked = true;
        //    this.toolStripButton第二层.Checked = false;
        //    this.toolStripButton第三层.Checked = false;
        //    this.toolStripButton事件层.Checked = false;
        //    MapData mapData = this.listBox关卡.SelectedItem as MapData;
        //    if (mapData != null)
        //    {
        //        this.SetCurrentOperationLayer(mapData.Layer1);
        //        this.ResizePictureBox静态图();
        //        this.ResizePictureBox动态图();
        //        this.ResizeScrollBar();
        //        this.RepaintAllPictureBox();

        //        this.toolStripStatusLabel选择信息.Text = string.Empty;
        //    }
        //    if (this.toolStripButton区域选择.Checked == true || this.toolStripButton逻辑属性.Checked == true)
        //    {
        //        this.ChangeToDrawMode();
        //    }
        //}

        //private void ChangeToSecondLayer()
        //{
        //    this.toolStripMenuItem第一层.Checked = false;
        //    this.toolStripMenuItem第二层.Checked = true;
        //    this.toolStripMenuItem第三层.Checked = false;
        //    this.toolStripMenuItem事件层.Checked = false;
        //    this.toolStripButton第一层.Checked = false;
        //    this.toolStripButton第二层.Checked = true;
        //    this.toolStripButton第三层.Checked = false;
        //    this.toolStripButton事件层.Checked = false;
        //    MapData mapData = this.listBox关卡.SelectedItem as MapData;
        //    if (mapData != null)
        //    {
        //        this.SetCurrentOperationLayer(mapData.Layer2);
        //        this.ResizePictureBox静态图();
        //        this.ResizePictureBox动态图();
        //        this.ResizeScrollBar();
        //        this.RepaintAllPictureBox();

        //        this.toolStripStatusLabel选择信息.Text = string.Empty;
        //    }
        //}

        //private void ChangeToThirdLayer()
        //{
        //    this.toolStripMenuItem第一层.Checked = false;
        //    this.toolStripMenuItem第二层.Checked = false;
        //    this.toolStripMenuItem第三层.Checked = true;
        //    this.toolStripMenuItem事件层.Checked = false;
        //    this.toolStripButton第一层.Checked = false;
        //    this.toolStripButton第二层.Checked = false;
        //    this.toolStripButton第三层.Checked = true;
        //    this.toolStripButton事件层.Checked = false;
        //    MapData mapData = this.listBox关卡.SelectedItem as MapData;
        //    if (mapData != null)
        //    {
        //        this.SetCurrentOperationLayer(mapData.Layer3);
        //        this.ResizePictureBox静态图();
        //        this.ResizePictureBox动态图();
        //        this.ResizeScrollBar();
        //        this.RepaintAllPictureBox();

        //        this.toolStripStatusLabel选择信息.Text = string.Empty;
        //    }
        //    if (this.toolStripButton区域选择.Checked == true || this.toolStripButton逻辑属性.Checked == true)
        //    {
        //        this.ChangeToDrawMode();
        //    }
        //}

        private void DisableEdit()
        {
            this.toolStripButton水平翻转.Enabled = false;
            this.toolStripButton垂直翻转.Enabled = false;
            this.toolStripButton复制.Enabled = false;
            this.toolStripButton删除.Enabled = false;
            this.toolStripButton粘贴.Enabled = false;

            this.toolStripMenuItem水平翻转.Enabled = false;
            this.toolStripMenuItem垂直翻转.Enabled = false;
            this.toolStripMenuItem复制.Enabled = false;
            this.toolStripMenuItem擦除.Enabled = false;
            this.toolStripMenuItem粘贴.Enabled = false;

            this.clipRectEndTileX = this.clipRectStartTileX = this.clipRectStartX1 = 0;
            this.clipRectEndTileY = this.clipRectStartTileY = this.clipRectStartY1 = 0;

            this.copyData = null;
            this.copyPropertyData = null;
        }

        private void DisableBackGroundColor()
        {
            this.toolStripButton填充.Enabled = false;
            this.toolStripButton填充.Checked = false;
            this.toolStripMenuItem填充.Enabled = false;
            this.toolStripMenuItem填充.Checked = false;
            this.toolStripButton颜色.Enabled = false;
            this.toolStripMenuItem背景颜色.Enabled = false;
        }

        private void ChangeToDrawMode()
        {
            this.toolStripButton逻辑刷.Enabled = false;

            this.toolStripButton框选.Checked = false;
            this.toolStripButton画笔.Checked = true;
            this.toolStripButton逻辑属性.Checked = false;
            this.toolStripButton区域选择.Checked = false;

            this.toolStripMenuItem框选.Checked = false;
            this.toolStripMenuItem画笔.Checked = true;
            this.toolStripMenuItem逻辑属性.Checked = false;
            this.toolStripMenuItem区域选择.Checked = false;

            this.DisableEdit();
            this.editMode = EditMode.Draw;


        }

        private void ChangeToSelectMode()
        {
            this.toolStripButton逻辑刷.Enabled = false;

            this.toolStripButton框选.Checked = true;
            this.toolStripButton画笔.Checked = false;
            this.toolStripButton逻辑属性.Checked = false;
            this.toolStripButton区域选择.Checked = false;

            this.toolStripMenuItem框选.Checked = true;
            this.toolStripMenuItem画笔.Checked = false;
            this.toolStripMenuItem逻辑属性.Checked = false;
            this.toolStripMenuItem区域选择.Checked = false;


            this.editMode = EditMode.Select;
        }

        private void ChangeToLogicPropertyMode()
        {
            this.OpenLogicLayer();

            this.toolStripButton逻辑刷.Enabled = true;

            this.toolStripButton框选.Checked = false;
            this.toolStripButton画笔.Checked = false;
            this.toolStripButton逻辑属性.Checked = true;
            this.toolStripButton区域选择.Checked = false;

            this.toolStripMenuItem框选.Checked = false;
            this.toolStripMenuItem画笔.Checked = false;
            this.toolStripMenuItem逻辑属性.Checked = true;
            this.toolStripMenuItem区域选择.Checked = false;

            this.DisableEdit();
            this.editMode = EditMode.LogicProperty;

        }

        private void ChangeToRegionSelectMode()
        {
            this.OpenLogicLayer();

            this.toolStripButton逻辑刷.Enabled = false;

            this.toolStripButton框选.Checked = false;
            this.toolStripButton画笔.Checked = false;
            this.toolStripButton逻辑属性.Checked = false;
            this.toolStripButton区域选择.Checked = true;

            this.toolStripMenuItem框选.Checked = false;
            this.toolStripMenuItem画笔.Checked = false;
            this.toolStripMenuItem逻辑属性.Checked = false;
            this.toolStripMenuItem区域选择.Checked = true;

            this.DisableEdit();
            this.editMode = EditMode.RegionSelect;

        }

        private void ZoomToHalf()
        {
            this.toolStripButton缩放二分之一.Checked = true;
            this.toolStripButton缩放一分之一.Checked = false;
            this.toolStripButton缩放两倍.Checked = false;
            this.toolStripButton缩放四倍.Checked = false;

            this.toolStripMenuItem缩放二分之一.Checked = true;
            this.toolStripMenuItem缩放一分之一.Checked = false;
            this.toolStripMenuItem缩放两倍.Checked = false;
            this.toolStripMenuItem缩放四倍.Checked = false;
            this.magnification = 0.5f;
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
            //this.ResizeScrollBar();
            this.RepaintAllPictureBox();
        }

        private void ZoomToOneTimes()
        {
            this.toolStripButton缩放二分之一.Checked = false;
            this.toolStripButton缩放一分之一.Checked = true;
            this.toolStripButton缩放两倍.Checked = false;
            this.toolStripButton缩放四倍.Checked = false;

            this.toolStripMenuItem缩放二分之一.Checked = false;
            this.toolStripMenuItem缩放一分之一.Checked = true;
            this.toolStripMenuItem缩放两倍.Checked = false;
            this.toolStripMenuItem缩放四倍.Checked = false;
            this.magnification = 1f;
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
            //this.ResizeScrollBar();
            this.RepaintAllPictureBox();
        }

        private void ZoomToTwoTimes()
        {
            this.toolStripButton缩放二分之一.Checked = false;
            this.toolStripButton缩放一分之一.Checked = false;
            this.toolStripButton缩放两倍.Checked = true;
            this.toolStripButton缩放四倍.Checked = false;

            this.toolStripMenuItem缩放二分之一.Checked = false;
            this.toolStripMenuItem缩放一分之一.Checked = false;
            this.toolStripMenuItem缩放两倍.Checked = true;
            this.toolStripMenuItem缩放四倍.Checked = false;
            this.magnification = 2f;
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
            //this.ResizeScrollBar();
            this.RepaintAllPictureBox();
        }

        private void ZoomToFourTimes()
        {
            this.toolStripButton缩放二分之一.Checked = false;
            this.toolStripButton缩放一分之一.Checked = false;
            this.toolStripButton缩放两倍.Checked = false;
            this.toolStripButton缩放四倍.Checked = true;

            this.toolStripMenuItem缩放二分之一.Checked = false;
            this.toolStripMenuItem缩放一分之一.Checked = false;
            this.toolStripMenuItem缩放两倍.Checked = false;
            this.toolStripMenuItem缩放四倍.Checked = true;
            this.magnification = 4f;
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
            //this.ResizeScrollBar();
            this.RepaintAllPictureBox();
        }

        public void RecycleData()
        {
            this.form元数据.ListBox静态图块集.Items.Clear();
            this.form元数据.ListBox动态图块集.Items.Clear();
            this.form元数据.ListBox动态图块.Items.Clear();
            this.form元数据.ListBox动态图块帧.Items.Clear();
            this.form元数据.ListBox音乐.Items.Clear();
            this.form元数据.ListBox音效.Items.Clear();
            this.form元数据.ListBox变量.Items.Clear();

            this.form配置触发器.ListBox触发器.Items.Clear();
            this.form配置触发器.ListBox命令.Items.Clear();
            this.form配置触发器.ListBox条件.Items.Clear();

            this.ListBox关卡.Items.Clear();
            this.listBox可视层.Items.Clear();
            this.copyData = null;
            this.copyPropertyData = null;

            this.SetCurrentOperationLayer(null);
        }

        public void DelClipData()
        {

            int xlenth = this.clipRectEndTileX - this.clipRectStartTileX;
            int ylenth = this.clipRectEndTileY - this.clipRectStartTileY;
            for (int i = 0; i < xlenth; i++)
            {
                for (int j = 0; j < ylenth; j++)
                {

                    this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = 0;
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = 0;
                }
            }
        }

        public void CopyClipData()
        {
            int xlenth = this.clipRectEndTileX - this.clipRectStartTileX;
            int ylenth = this.clipRectEndTileY - this.clipRectStartTileY;
            this.copyData = null;
            this.copyPropertyData = null;
            this.copyData = new byte[xlenth, ylenth];
            this.copyPropertyData = new byte[xlenth, ylenth];
            for (int i = 0; i < xlenth; i++)
            {
                for (int j = 0; j < ylenth; j++)
                {

                    this.copyData[i, j] = this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                    this.copyPropertyData[i, j] = this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                }
            }
        }

        public void PasteClipData()
        {
            int xlenth = Math.Min(this.copyData.GetLength(0), this.currentOperationLayerData.HorizontalTileCount - this.clipRectStartTileX);
            int ylenth = Math.Min(this.copyData.GetLength(1), this.currentOperationLayerData.VerticalTileCount - this.clipRectStartTileY);
            for (int i = 0; i < xlenth; i++)
            {
                for (int j = 0; j < ylenth; j++)
                {
                    this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.copyData[i, j];
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.copyPropertyData[i, j];
                }
            }
        }

        public void SetCurrentOperationLayer(VisualLayerData layerData)
        {
            this.currentOperationLayerData = layerData;
            //this.ResizeScrollBar();

            if (this.currentOperationLayerData != null)
            {
                this.ResizePictureBox动态图();
                this.PictureBox动态图.Invalidate();
                this.ResizePictureBox静态图();
                this.pictureBox静态图.Invalidate();
                //this.pictureBox地图.Visible = true;
                this.pictureBox动态图.Visible = true;
                this.pictureBox静态图.Visible = true;
                //this.hScrollBar地图.Visible = true;
                //this.vScrollBar地图.Visible = true;
                if (this.currentOperationLayerData.StaticBitmapID < 0)
                {
                    this.pictureBox静态图.Visible = false;
                }
                if (this.currentOperationLayerData.DynamicBitmapID < 0)
                {
                    this.pictureBox动态图.Visible = false;
                }
            }
            else
            {
                //this.pictureBox地图.Visible = false;
                this.pictureBox动态图.Visible = false;
                this.pictureBox静态图.Visible = false;
                //this.hScrollBar地图.Visible = false;
                //this.vScrollBar地图.Visible = false;
            }

            this.mapStartTileX = 0;
            this.mapStartTileY = 0;
            this.mapMoveTileX = 0;
            this.mapMoveTileY = 0;
            this.mapEndTileX = 0;
            this.mapEndTileY = 0;

            this.clipRectStartTileX = 0;
            this.clipRectStartTileY = 0;
            this.clipRectEndTileX = 0;
            this.clipRectEndTileY = 0;
        }

        private void ResizeScrollBar()
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;


            int hScrollBarMaximum = mapData.LogicLayer.HorizontalTileCount * 16;
            int vScrollBarMaximum = mapData.LogicLayer.VerticalTileCount * 16;
            this.hScrollBar地图.LargeChange = this.screenWidth + 1;
            this.vScrollBar地图.LargeChange = this.screenHeight + 1;
            this.hScrollBar地图.Maximum = hScrollBarMaximum;
            this.vScrollBar地图.Maximum = vScrollBarMaximum;
            this.hScrollBar地图.Value = 0;
            this.vScrollBar地图.Value = 0;

        }

        public void RepaintAllPictureBox()
        {
            this.pictureBox静态图.Invalidate();
            this.pictureBox动态图.Invalidate();
            this.pictureBox地图.Invalidate();
        }

        public void ResizePictureBox静态图()
        {
            int staticWidth = 256;
            int staticHeight = 256;
            StaticTileSetData staticTileSetData = null;
            if (this.listBox关卡.SelectedIndex != -1 && this.listBox可视层.SelectedIndex != -1)
            {
                MapData mapData = this.listBox关卡.SelectedItem as MapData;

                if (this.currentOperationLayerData.StaticBitmapID >= 0)
                {
                    this.pictureBox静态图.Visible = true;
                    staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;
                }
                else
                {
                    this.pictureBox静态图.Visible = false;
                }


            }
            if (staticTileSetData != null)
            {
                Bitmap bitmap = staticTileSetData.Bitmap;
                if (bitmap != null)
                {
                    staticWidth = bitmap.Width;
                    staticHeight = bitmap.Height;
                }
            }
            this.PictureBox静态图.ClientSize = new Size(staticWidth, staticHeight);
            this.staticSelectedTileStartX = this.staticSelectedTileEndX = 0;
            this.staticSelectedTileStartY = this.staticSelectedTileEndY = 0;

        }

        public void ResizePictureBox动态图()
        {
            int dynamicWidth = 256;
            int dynamicHeight = 256;
            DynamicTileSetData dynamicTileSetData = null;
            if (this.listBox关卡.SelectedIndex != -1 && this.listBox可视层.SelectedIndex != -1)
            {
                MapData mapData = this.listBox关卡.SelectedItem as MapData;

                if (this.currentOperationLayerData.DynamicBitmapID >= 0)
                {
                    this.pictureBox动态图.Visible = true;
                    dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;
                }
                else
                {
                    this.pictureBox动态图.Visible = false;
                }
            }
            if (dynamicTileSetData != null && dynamicTileSetData.DynamicTileDataList.Count > 0)
            {
                if (dynamicTileSetData.DynamicTileDataList.Count < 16)
                {
                    dynamicWidth = dynamicTileSetData.DynamicTileDataList.Count * 16;
                    dynamicHeight = 16;
                }
                dynamicHeight = (dynamicTileSetData.DynamicTileDataList.Count / 16 + 1) * 16;
            }

            this.pictureBox动态图.ClientSize = new Size(dynamicWidth, dynamicHeight);
            this.dynamicSelectedID = 0;
        }

        public void FlipHorizontal()
        {

            int xlenth = this.clipRectEndTileX - this.clipRectStartTileX;
            int ylenth = this.clipRectEndTileY - this.clipRectStartTileY;
            System.Console.WriteLine(this.clipRectEndTileX);
            System.Console.WriteLine(this.clipRectStartTileX);
            //xlenth = xlenth % 2 == 0 ? xlenth : xlenth + 2;
            for (int i = 0; i < (xlenth + 1) / 2; i++)
            {
                for (int j = 0; j < ylenth; j++)
                {
                    byte tempPosition;
                    byte tempProperty;

                    tempPosition = this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.currentOperationLayerData.VisualLayerTable[this.clipRectEndTileX - 1 - i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualLayerTable[this.clipRectEndTileX - 1 - i, this.clipRectStartTileY + j] = tempPosition;

                    tempProperty = this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.currentOperationLayerData.VisualPropertyTable[this.clipRectEndTileX - 1 - i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectEndTileX - 1 - i, this.clipRectStartTileY + j] = tempProperty;

                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] ^= (0x04);
                    if (this.clipRectStartTileX + i != this.clipRectEndTileX - 1 - i)
                    {
                        this.currentOperationLayerData.VisualPropertyTable[this.clipRectEndTileX - 1 - i, this.clipRectStartTileY + j] ^= (0x04);
                    }
                }
            }
        }

        public void FlipVertical()
        {
            int xlenth = this.clipRectEndTileX - this.clipRectStartTileX;
            int ylenth = this.clipRectEndTileY - this.clipRectStartTileY;
            for (int i = 0; i < xlenth; i++)
            {
                for (int j = 0; j < (ylenth + 1) / 2; j++)
                {
                    byte tempPosition;
                    byte tempProperty;
                    tempPosition = this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectEndTileY - 1 - j];
                    this.currentOperationLayerData.VisualLayerTable[this.clipRectStartTileX + i, this.clipRectEndTileY - 1 - j] = tempPosition;

                    tempProperty = this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j];
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] = this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectEndTileY - 1 - j];
                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectEndTileY - 1 - j] = tempProperty;

                    this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectStartTileY + j] ^= (0x08);
                    if (this.clipRectStartTileY + j != this.clipRectEndTileY - 1 - j)
                    {
                        this.currentOperationLayerData.VisualPropertyTable[this.clipRectStartTileX + i, this.clipRectEndTileY - 1 - j] ^= (0x08);
                    }
                }
            }
        }
        //public void resizePictureBox地图()
        //{
        //    int mapWidth = 40;
        //    int mapHeight = 20;

        //    if (this.listBox关卡.SelectedIndex != -1)
        //    {
        //        MapData mapData = this.listBox关卡.SelectedItem as MapData;
        //        switch (selectedLayer)
        //        {
        //            case 1:
        //                {
        //                    mapWidth = mapData.Layer1.Width;
        //                    mapHeight = mapData.Layer1.Height;
        //                }
        //                break;
        //            case 2:
        //                {
        //                    mapWidth = mapData.Layer2.Width;
        //                    mapHeight = mapData.Layer2.Height;
        //                }
        //                break;
        //            case 3:
        //                {
        //                    mapWidth = mapData.Layer3.Width;
        //                    mapHeight = mapData.Layer3.Height;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    this.pictureBox地图.ClientSize = new Size((int)(mapWidth * 16 * this.magnification), (int)(mapHeight * 16 * this.magnification));
        //}

        private Form元数据 form元数据;

        public Form元数据 Form元数据
        {
            get { return form元数据; }
            set { form元数据 = value; }
        }

        private Form配置触发器 form配置触发器;

        public Form配置触发器 Form配置触发器
        {
            get { return form配置触发器; }
            set { form配置触发器 = value; }
        }


        public ListBox ListBox关卡
        {
            get
            {
                return this.listBox关卡;
            }
        }

        public ListBox ListBox可见层
        {
            get
            {
                return this.listBox可视层;
            }
        }

        public PictureBox PictureBox静态图
        {
            get
            {
                return this.pictureBox静态图;
            }

        }

        public PictureBox PictureBox动态图
        {
            get
            {
                return this.pictureBox动态图;
            }

        }


        //private void toolStripMenuItem数据库_Click(object sender, EventArgs e)
        //{
        //    this.form元数据.ShowDialog();
        //    this.ResizePictureBox静态图();
        //    this.ResizePictureBox动态图();
        //}


        private void listBox关卡_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.listBox关卡.SelectedIndex == -1)
                {
                    this.toolStripMenuItem地图设置.Enabled = false;
                    this.toolStripMenuItem删除地图.Enabled = false;
                    this.toolStripMenuItem上移地图.Enabled = false;
                    this.toolStripMenuItem下移地图.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem地图设置.Enabled = true;
                    this.toolStripMenuItem删除地图.Enabled = true;
                    this.toolStripMenuItem上移地图.Enabled = true;
                    this.toolStripMenuItem下移地图.Enabled = true;
                }

                if (this.listBox关卡.SelectedIndex == 0)
                {
                    this.toolStripMenuItem上移地图.Enabled = false;
                }

                if (this.listBox关卡.SelectedIndex == this.listBox关卡.Items.Count - 1)
                {
                    this.toolStripMenuItem下移地图.Enabled = false;
                }

                this.contextMenuStrip关卡.Show(this.listBox关卡.PointToScreen(e.Location));
            }
        }

        private void toolStripMenuItem新建地图_Click(object sender, EventArgs e)
        {
            Form新建地图 form = new Form新建地图(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MapData mapData = new MapData(form.MapName, form.LogicLayerWidth, form.LogicLayerHeight);
                //MapData mapData = new MapData(form.MapName, form.Layer1HorizontalTileCount, form.Layer1VericalTileCount, form.StaticBitmap1ID, form.DynamicBitmap1ID,
                //    form.Layer2HorizontalTileCount, form.Layer2VericalTileCount, form.StaticBitmap2ID, form.DynamicBitmap2ID, form.Layer3HorizontalTileCount, form.Layer3VericalTileCount,
                //    form.StaticBitmap3ID, form.DynamicBitmap3ID, form.BgmID);
                this.listBox关卡.Items.Add(mapData);
                this.listBox关卡.Invalidate();
            }
            form.Dispose();
            //this.ResizeScrollBar();
            //this.RepaintAllPictureBox();
        }

        private void listBox关卡_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            int num = e.Index + 1;
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            MapData mapData = this.listBox关卡.Items[e.Index] as MapData;
            graphics.DrawString("<" + num.ToString() + ">" + mapData.Name, e.Font, Brushes.Black, e.Bounds);

        }

        private void toolStripMenuItem地图设置_Click(object sender, EventArgs e)
        {
            Form设置地图 form = new Form设置地图(this);
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            form.MapName = mapData.Name;
            //form.BgmID = mapData.BgmID;

            form.LogicLayerWidth = mapData.LogicLayer.HorizontalTileCount;
            form.LogicLayerHeight = mapData.LogicLayer.VerticalTileCount;

            if (form.ShowDialog() == DialogResult.OK)
            {
                mapData.Name = form.MapName;
                //mapData.BgmID = form.BgmID;
                //mapData.ClipLayer(form.ClipMode, form.Layer1HorizontalTileCount, form.Layer1VericalTileCount, 1);
                mapData.ClipLogicLayer(form.ClipMode, form.LogicLayerWidth, form.LogicLayerHeight);
                mapData.LogicLayer.HorizontalTileCount = form.LogicLayerWidth;
                mapData.LogicLayer.VerticalTileCount = form.LogicLayerHeight;
            }


            form.Dispose();
            this.listBox关卡.Invalidate();
            //this.ResizePictureBox静态图();
            //this.ResizePictureBox动态图();
            //this.RepaintAllPictureBox();
            this.ResizeScrollBar();
        }

        private void toolStripMenuItem删除地图_Click(object sender, EventArgs e)
        {
            this.listBox关卡.Items.Remove(this.listBox关卡.SelectedItem);
            this.listBox关卡.Invalidate();
        }

        private void toolStripMenuItem上移地图_Click(object sender, EventArgs e)
        {
            MapData mapData1 = this.listBox关卡.SelectedItem as MapData;
            MapData mapData2 = this.listBox关卡.Items[this.listBox关卡.SelectedIndex - 1] as MapData;

            this.listBox关卡.Items[this.listBox关卡.SelectedIndex - 1] = mapData1;
            this.listBox关卡.Items[this.listBox关卡.SelectedIndex] = mapData2;

            this.listBox关卡.Invalidate();
        }

        private void toolStripMenuItem下移地图_Click(object sender, EventArgs e)
        {
            MapData mapData1 = this.listBox关卡.SelectedItem as MapData;
            MapData mapData2 = this.listBox关卡.Items[this.listBox关卡.SelectedIndex + 1] as MapData;

            this.listBox关卡.Items[this.listBox关卡.SelectedIndex + 1] = mapData1;
            this.listBox关卡.Items[this.listBox关卡.SelectedIndex] = mapData2;

            this.listBox关卡.Invalidate();
        }

        private void pictureBox静态图_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(CustomBrushes.TransparentBrush, 0, 0, this.pictureBox静态图.ClientSize.Width, this.pictureBox静态图.ClientSize.Height);

            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (mapData != null)
            {
                StaticTileSetData staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;


                if (staticTileSetData != null)
                {
                    Bitmap bitmap = staticTileSetData.Bitmap;
                    if (bitmap != null)
                    {
                        graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                        graphics.DrawRectangle(Pens.Red, this.staticSelectedTileStartX * 16, this.staticSelectedTileStartY * 16,
                           (this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1) * 16 - 1, (this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1) * 16 - 1);
                    }
                }


            }
        }

        private void pictureBox动态图_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(CustomBrushes.TransparentBrush, 0, 0, this.pictureBox动态图.ClientSize.Width, this.pictureBox动态图.ClientSize.Height);

            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (mapData != null)
            {
                DynamicTileSetData dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;



                if (dynamicTileSetData != null)
                {
                    Bitmap bitmap = dynamicTileSetData.Bitmap;
                    if (bitmap != null)
                    {
                        int numberOfDynamicTile = dynamicTileSetData.DynamicTileDataList.Count;
                        for (int i = 0; i < numberOfDynamicTile; i++)
                        {
                            int j = i / 16;
                            int k = i % 16;
                            Rectangle destRectangle = new Rectangle(k * 16, j * 16, 16, 16);
                            if (dynamicTileSetData.DynamicTileDataList[i].FrameList.Count > 0)
                            {
                                byte position = dynamicTileSetData.DynamicTileDataList[i].FrameList[0];
                                byte positionX = (byte)(position & 0x0F);

                                byte positionY = (byte)((position & 0xF0) >> 4);

                                Rectangle srcRectangle = new Rectangle(positionX * 16, positionY * 16, 16, 16);
                                graphics.DrawImage(bitmap, destRectangle, srcRectangle, GraphicsUnit.Pixel);
                                graphics.DrawRectangle(Pens.Red, dynamicSelectedID % 16 * 16, (dynamicSelectedID / 16) * 16, 15, 15);
                            }


                        }
                    }
                }


            }
        }

        private void pictureBox静态图_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.editMode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.staticSelectedTileStartX = e.X / 16;
                    this.staticSelectedTileStartY = e.Y / 16;
                }
            }
        }

        private void pictureBox静态图_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.editMode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {

                    if (this.staticSelectedTileEndX != e.X / 16)
                    {
                        this.staticSelectedTileEndX = e.X / 16;
                        this.staticSelectedTileEndX = this.staticSelectedTileEndX < this.staticSelectedTileStartX ? this.staticSelectedTileStartX : this.staticSelectedTileEndX;
                        this.staticSelectedTileEndX = this.staticSelectedTileEndX > this.pictureBox静态图.ClientSize.Width / 16 - 1 ? this.pictureBox静态图.ClientSize.Width / 16 - 1 : this.staticSelectedTileEndX;
                    }
                    if (this.staticSelectedTileEndY != e.Y / 16)
                    {
                        this.staticSelectedTileEndY = e.Y / 16;
                        this.staticSelectedTileEndY = this.staticSelectedTileEndY < this.staticSelectedTileStartY ? this.staticSelectedTileStartY : this.staticSelectedTileEndY;
                        this.staticSelectedTileEndY = this.staticSelectedTileEndY > this.pictureBox静态图.ClientSize.Height / 16 - 1 ? this.pictureBox静态图.ClientSize.Height / 16 - 1 : this.staticSelectedTileEndY;
                    }

                    this.pictureBox静态图.Invalidate();
                }
            }
        }

        private void pictureBox静态图_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.editMode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {

                    if (this.staticSelectedTileEndX != e.X / 16)
                    {
                        this.staticSelectedTileEndX = e.X / 16;
                        this.staticSelectedTileEndX = this.staticSelectedTileEndX < this.staticSelectedTileStartX ? this.staticSelectedTileStartX : this.staticSelectedTileEndX;
                        this.staticSelectedTileEndX = this.staticSelectedTileEndX > this.pictureBox静态图.ClientSize.Width / 16 - 1 ? this.pictureBox静态图.ClientSize.Width / 16 - 1 : this.staticSelectedTileEndX;
                    }
                    if (this.staticSelectedTileEndY != e.Y / 16)
                    {
                        this.staticSelectedTileEndY = e.Y / 16;
                        this.staticSelectedTileEndY = this.staticSelectedTileEndY < this.staticSelectedTileStartY ? this.staticSelectedTileStartY : this.staticSelectedTileEndY;
                        this.staticSelectedTileEndY = this.staticSelectedTileEndY > this.pictureBox静态图.ClientSize.Height / 16 - 1 ? this.pictureBox静态图.ClientSize.Height / 16 - 1 : this.staticSelectedTileEndY;
                    }

                    this.pictureBox静态图.Invalidate();
                }
            }
        }

        private void listBox关卡_SelectedIndexChanged(object sender, EventArgs e)
        {
            //VisualLayerData layerData = null;
            if (this.listBox关卡.SelectedIndex != -1)
            {
                this.ResizeScrollBar();
                this.hScrollBar地图.Visible = true;
                this.vScrollBar地图.Visible = true;
                this.pictureBox地图.Visible = true;

                MapData mapData = this.listBox关卡.SelectedItem as MapData;
                int num = mapData.VisualLayerDataList.Count;
                this.listBox可视层.Items.Clear();
                for (int i = 0; i < num; i++)
                {
                    this.listBox可视层.Items.Add(mapData.VisualLayerDataList[i]);
                }
                this.listBox可视层.Invalidate();
                //if (this.toolStripButton第一层.Checked)
                //{
                //    layerData = mapData.Layer1;
                //}
                //if (this.toolStripButton第二层.Checked)
                //{
                //    layerData = mapData.Layer2;
                //}
                //if (this.toolStripButton第三层.Checked)
                //{
                //    layerData = mapData.Layer3;
                //}

                this.toolStripButton地图查看.Enabled = true;
                this.toolStripMenuItem地图查看.Enabled = true;
                //this.toolStripButton画笔.Enabled = true;
                //this.toolStripMenuItem画笔.Enabled = true;
                //this.toolStripButton框选.Enabled = true;
                //this.toolStripMenuItem框选.Enabled = true;
                //this.toolStripButton逻辑属性.Enabled = true;
                //this.toolStripMenuItem逻辑属性.Enabled = true;
                //this.toolStripButton区域选择.Enabled = true;
                //this.toolStripMenuItem区域选择.Enabled = true;

                this.toolStripButton填充.Enabled = true;
                this.toolStripMenuItem填充.Enabled = true;
                this.toolStripButton颜色.Enabled = true;
                this.toolStripMenuItem背景颜色.Enabled = true;
                this.toolStripButton填充.Checked = mapData.IsFillBackColor;
                this.toolStripMenuItem填充.Checked = this.toolStripButton填充.Checked;

                this.toolStripButton事件层.Enabled = true;
                this.toolStripMenuItem事件层.Enabled = true;

                this.toolStripMenuItem导出地图.Enabled = true;
            }
            else
            {
                this.hScrollBar地图.Visible = false;
                this.vScrollBar地图.Visible = false;
                this.pictureBox地图.Visible = false;
                this.listBox可视层.Items.Clear();
                this.listBox可视层.Invalidate();
                this.toolStripButton地图查看.Enabled = false;
                this.toolStripMenuItem地图查看.Enabled = false;
                //this.toolStripButton画笔.Enabled = false;
                //this.toolStripMenuItem画笔.Enabled = false;
                //this.toolStripButton框选.Enabled = false;
                //this.toolStripMenuItem框选.Enabled = false;
                //this.toolStripButton逻辑属性.Enabled = false;
                //this.toolStripMenuItem逻辑属性.Enabled = false;
                //this.toolStripButton区域选择.Enabled = false;
                //this.toolStripMenuItem区域选择.Enabled = false;

                //this.toolStripButton填充.Enabled = false;
                //this.toolStripMenuItem填充.Enabled = false;
                //this.toolStripButton颜色.Enabled = false;
                //this.toolStripMenuItem背景颜色.Enabled = false;
                this.DisableBackGroundColor();

                this.toolStripButton事件层.Enabled = false;
                this.toolStripMenuItem事件层.Enabled = false;

                this.toolStripMenuItem导出地图.Enabled = false;
            }
            this.SetCurrentOperationLayer(null);
            this.DisableEdit();
            //this.clipRectEndX = this.clipRectStartX = this.clipRectStartX1 = 0;
            //this.clipRectEndY = this.clipRectStartY = this.clipRectStartY1 = 0;

            //this.toolStripButton水平翻转.Enabled = false;
            //this.toolStripMenuItem水平翻转.Enabled = false;
            //this.toolStripButton垂直翻转.Enabled = false;
            //this.toolStripMenuItem垂直翻转.Enabled = false;
            //this.toolStripButton复制.Enabled = false;
            //this.toolStripMenuItem复制.Enabled = false;
            //this.toolStripButton删除.Enabled = false;
            //this.toolStripMenuItem擦除.Enabled = false;
            //this.toolStripButton粘贴.Enabled = false;
            //this.toolStripMenuItem粘贴.Enabled = false;
            this.regionSelectID = -1;
            this.listBox可视层.SelectedIndex = -1;

            this.toolStripButton上一层.Enabled = false;
            this.toolStripMenuItem上一层.Enabled = false;
            this.toolStripButton下一层.Enabled = false;
            this.toolStripMenuItem下一层.Enabled = false;

            this.toolStripMenuItem编辑可视层.Enabled = false;
            this.toolStripMenuItem删除可视层.Enabled = false;
            this.toolStripMenuItem上移可视层.Enabled = false;
            this.toolStripMenuItem下移可视层.Enabled = false;
            //this.regionEditMode = RegionEditMode.Bulid;
            //this.pictureBox地图.Invalidate();
        }

        private void pictureBox动态图_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.editMode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    dynamicSelectedID = (e.Y / 16) * 16 + e.X / 16;
                    this.pictureBox动态图.Invalidate();
                }
            }
        }

        private void pictureBox地图_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;
            if (this.listBox关卡.SelectedIndex >= 0)
            {



                MapData mapData = this.listBox关卡.SelectedItem as MapData;

                StaticTileSetData staticTileSetData = null;
                DynamicTileSetData dynamicTileSetData = null;


                //if (this.currentOperationLayerData.StaticBitmapID >= 0)
                //{
                //    staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;
                //}
                //if (this.currentOperationLayerData.DynamicBitmapID >= 0)
                //{
                //    dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;
                //}


                int logicLayerCameraX = this.hScrollBar地图.Value;
                int logicLayerCameraY = this.vScrollBar地图.Value;



                //if (mapData.IsFillBackColor)
                //{
                //    SolidBrush backColorBrush = new SolidBrush(mapData.BackColor);
                //    e.Graphics.FillRectangle(backColorBrush, this.pictureBox地图.ClientRectangle);
                //    backColorBrush.Dispose();
                //}
                //else
                //{
                //    e.Graphics.FillRectangle(CustomBrushes.TransparentBrush, this.pictureBox地图.ClientRectangle);
                //}
                //int h1 = this.pictureBox地图.ClientSize.Width / (int)(16 * this.magnification);
                //int h2 = this.currentOperationLayerData.HorizontalTileCount - cameraX;
                //int h3 = mapData.LogicLayer.Width - cameraX;
                //int v1 = this.pictureBox地图.ClientSize.Height / (int)(16 * this.magnification);
                //int v2 = this.currentOperationLayerData.VerticalTileCount - cameraY;
                //int v3 = mapData.LogicLayer.Height - cameraY;
                //int hTileCount = Math.Min(h1, h2);
                //int vTileCount = Math.Min(v1, v2);

                try
                {
                    IntPtr hdc = IntPtr.Zero;


                    hdc = e.Graphics.GetHdc();

                    this.surface地图.FillStyle = 1;
                    if (mapData.IsFillBackColor)
                    {
                        this.surface地图.ColorFill(mapData.BackColor);
                    }
                    else
                    {
                        this.surface地图.ColorFill(Color.CornflowerBlue);
                    }



                    for (int i = 0; i < mapData.VisualLayerDataList.Count; i++)
                    {
                        VisualLayerData visualLayerData = mapData.VisualLayerDataList[i];

                        if (visualLayerData.StaticBitmapID != -1)
                        {
                            staticTileSetData = this.form元数据.ListBox静态图块集.Items[visualLayerData.StaticBitmapID] as StaticTileSetData;
                        }
                        if (visualLayerData.DynamicBitmapID != -1)
                        {
                            dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[visualLayerData.DynamicBitmapID] as DynamicTileSetData;
                        }

                        if (visualLayerData.Visible)
                        {
                            int visualLayerCameraX = 0;
                            int visualLayerCameraY = 0;
                            if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && visualLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                            {
                                visualLayerCameraX = (int)((visualLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                            }
                            if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && visualLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                            {
                                visualLayerCameraY = (int)((visualLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                            }

                            int visualLayerCameraTileX = visualLayerCameraX / 16;
                            int visualLayerCameraTileY = visualLayerCameraY / 16;

                            int h1 = this.pictureBox地图.ClientSize.Width / (int)(16 * this.magnification);
                            int h2 = visualLayerData.HorizontalTileCount - visualLayerCameraTileX;
                            int v1 = this.pictureBox地图.ClientSize.Height / (int)(16 * this.magnification);
                            int v2 = visualLayerData.VerticalTileCount - visualLayerCameraTileY;
                            int hTileCount = Math.Min(h1, h2);
                            int vTileCount = Math.Min(v1, v2);

                            for (int y = 0; y < vTileCount; y++)
                            {
                                for (int x = 0; x < hTileCount; x++)
                                {
                                    byte property = visualLayerData.VisualPropertyTable[visualLayerCameraTileX + x, visualLayerCameraTileY + y];
                                    byte positionXY;
                                    byte positionX = 0;
                                    byte positionY = 0;
                                    byte dynamicTileID;
                                    byte visualProperty = (byte)(property & 0x03);
                                    Bitmap bitmap = null;
                                    Surface bitmapSurface = null;

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
                                                    if (this.toolStripButton缩放二分之一.Checked)
                                                    {
                                                        bitmapSurface = staticTileSetData.SurfaceHalf;
                                                    }
                                                    else if (this.toolStripButton缩放一分之一.Checked)
                                                    {
                                                        bitmapSurface = staticTileSetData.Surface;
                                                    }
                                                    else if (this.toolStripButton缩放两倍.Checked)
                                                    {
                                                        bitmapSurface = staticTileSetData.SurfaceTwo;
                                                    }
                                                    else
                                                    {
                                                        bitmapSurface = staticTileSetData.SurfaceFour;
                                                    }
                                                    positionXY = visualLayerData.VisualLayerTable[visualLayerCameraTileX + x, visualLayerCameraTileY + y];
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
                                                    if (this.toolStripButton缩放二分之一.Checked)
                                                    {
                                                        bitmapSurface = dynamicTileSetData.SurfaceHalf;
                                                    }
                                                    else if (this.toolStripButton缩放一分之一.Checked)
                                                    {
                                                        bitmapSurface = dynamicTileSetData.Surface;
                                                    }
                                                    else if (this.toolStripButton缩放两倍.Checked)
                                                    {
                                                        bitmapSurface = dynamicTileSetData.SurfaceTwo;
                                                    }
                                                    else
                                                    {
                                                        bitmapSurface = dynamicTileSetData.SurfaceFour;
                                                    }
                                                    dynamicTileID = visualLayerData.VisualLayerTable[visualLayerCameraTileX + x, visualLayerCameraTileY + y];
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
                                        int clipDistanceX = visualLayerCameraX % 16;
                                        int clipDistanceY = visualLayerCameraY % 16;
                                        Rectangle destRectangle = new Rectangle((int)((x * 16 - clipDistanceX) * this.magnification), (int)((y * 16-clipDistanceY) * this.magnification), (int)(16 * this.magnification), (int)(16 * this.magnification));
                                        Rectangle srcRectangle = new Rectangle((int)(positionX * 16 * this.magnification), (int)(positionY * 16 * this.magnification), (int)(16 * this.magnification), (int)(16 * this.magnification));
                                        if (destRectangle.X < 0)
                                        {
                                            destRectangle.X = 0;
                                            destRectangle.Width = (int)((16 - clipDistanceX) * this.magnification);
                                            srcRectangle = new Rectangle((int)((positionX * 16 + clipDistanceX) * this.magnification), (int)(positionY * 16 * this.magnification), (int)((16 - clipDistanceX) * this.magnification), (int)(16 * this.magnification));
                                        }
                                        if (destRectangle.Y < 0)
                                        {
                                            destRectangle.Y = 0;
                                            destRectangle.Height = (int)((16 - clipDistanceY) * this.magnification);
                                            srcRectangle = new Rectangle((int)(positionX * 16 * this.magnification), (int)((positionY * 16 + clipDistanceY) * this.magnification), (int)(16 * this.magnification), (int)((16 - clipDistanceY) * this.magnification));
                                        }
                                        if (destRectangle.Width == 0)
                                        {
                                            destRectangle.Width = 1;
                                        }
                                        if (destRectangle.Height == 0)
                                        {
                                            destRectangle.Height = 1;
                                        }
                                        if (srcRectangle.Width == 0)
                                        {
                                            srcRectangle.Width = 1;
                                        }
                                        if (srcRectangle.Height == 0)
                                        {
                                            srcRectangle.Height = 1;
                                        }


                                        byte flipMode = (byte)((property >> 2) & 0x03);





                                        drawEffects.EffectOperationMirrorLeftRight = false;
                                        drawEffects.EffectOperationMirrorUpDown = false;
                                        switch (flipMode)
                                        {
                                            case 1:
                                                {
                                                    drawEffects.EffectOperationMirrorLeftRight = true;
                                                }
                                                break;
                                            case 2:
                                                {
                                                    drawEffects.EffectOperationMirrorUpDown = true;
                                                }
                                                break;
                                            case 3:
                                                {
                                                    drawEffects.EffectOperationMirrorLeftRight = true;
                                                    drawEffects.EffectOperationMirrorUpDown = true;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        surface地图.Draw(destRectangle, bitmapSurface, srcRectangle, DrawFlags.Wait | DrawFlags.KeySource | DrawFlags.Effects, drawEffects);


                                    }

                                }

                            }
                        }
                    }

                    int hLogicTileCount = Math.Min(this.pictureBox地图.ClientSize.Width / (int)(16 * this.magnification), mapData.LogicLayer.HorizontalTileCount - (logicLayerCameraX / 16));
                    int vLogicTileCount = Math.Min(this.pictureBox地图.ClientSize.Height / (int)(16 * this.magnification), mapData.LogicLayer.VerticalTileCount - (logicLayerCameraY / 16));

                    if (this.toolStripButton逻辑层.Checked)
                    {
                        this.surface地图.ForeColor = Color.Black;
                        int clipDistanceX = logicLayerCameraX % 16;
                        int clipDistanceY = logicLayerCameraY % 16;
                        for (int i = 0; i < hLogicTileCount; i++)
                        {
                            this.surface地图.DrawLine((int)((i * 16 - clipDistanceX) * this.magnification), 0, (int)((i * 16 - clipDistanceX) * this.magnification), (int)(vLogicTileCount * 16 * this.magnification));
                        }

                        for (int i = 0; i < vLogicTileCount; i++)
                        {
                            this.surface地图.DrawLine(0, (int)((i * 16 - clipDistanceY) * this.magnification), (int)(hLogicTileCount * 16 * this.magnification), (int)((i * 16 - clipDistanceY) * this.magnification));
                        }
                    }

                    if (this.toolStripMenuItem屏幕栅格.Checked)
                    {
                        int startX = (int)(this.screenWidth * this.magnification) - ((int)(logicLayerCameraX * this.magnification) % (int)(this.screenWidth * this.magnification));
                        int startY = (int)(this.screenHeight * this.magnification) - ((int)(logicLayerCameraY * this.magnification) % (int)(this.screenHeight * this.magnification));

                        int hLenth = (int)(hLogicTileCount * 16 * this.magnification);
                        int vLenth = (int)(vLogicTileCount * 16 * this.magnification);

                        int hLenthCount = hLenth / (int)(this.screenWidth * this.magnification);
                        int vLenthCount = vLenth / (int)(this.screenHeight * this.magnification);

                        this.surface地图.ForeColor = Color.Green;

                        for (int i = 0; i < hLenthCount; i++)
                        {
                            this.surface地图.DrawLine((int)(startX + i * this.screenWidth * this.magnification), 0, (int)(startX + i * this.screenWidth * this.magnification), vLenth);
                        }
                        for (int i = 0; i < vLenthCount; i++)
                        {
                            this.surface地图.DrawLine(0, (int)(startY + i * this.screenHeight * this.magnification), hLenth, (int)(startY + i * this.screenHeight * this.magnification));
                        }

                        this.surface地图.ForeColor = Color.Yellow;
                        this.surface地图.DrawLine(0, (int)(this.screenHeight * this.magnification), (int)(this.screenWidth * this.magnification), (int)(this.screenHeight * this.magnification));
                        this.surface地图.DrawLine((int)(this.screenWidth * this.magnification), 0, (int)(this.screenWidth * this.magnification), (int)(this.screenHeight * this.magnification));
                    }


                    switch (this.editMode)
                    {
                        case EditMode.Draw:
                            {
                                if (this.currentOperationLayerData != null)
                                {
                                    int visualLayerCameraX = 0;
                                    int visualLayerCameraY = 0;
                                    if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                    {
                                        visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                    }
                                    if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                    {
                                        visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                    }

                                    int clipDistanceX = visualLayerCameraX % 16;
                                    int clipDistanceY = visualLayerCameraY % 16;

                                    if ((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification < this.pictureBox地图.ClientSize.Height)
                                    {
                                        this.surface地图.ForeColor = Color.Pink;
                                        int x2 = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                        this.surface地图.DrawLine(0, (int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), x2, (int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification));
                                    }

                                    if ((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification < this.pictureBox地图.ClientSize.Width)
                                    {
                                        this.surface地图.ForeColor = Color.Pink;
                                        int y2 = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                        this.surface地图.DrawLine((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), 0, (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), y2);
                                    }

                                    this.surface地图.FillStyle = 1;

                                    Rectangle mapVisibleRect = new Rectangle(0, 0, (int)(this.currentOperationLayerData.HorizontalTileCount * 16 * this.magnification), (int)(this.currentOperationLayerData.VerticalTileCount * 16 * this.magnification));
                                    Point mouseLocation = this.pictureBox地图.PointToClient(Cursor.Position);
                                    if (mapVisibleRect.Contains(mouseLocation))
                                    {
                                        int mouseTileX = (int)(mouseLocation.X / this.magnification + clipDistanceX) / 16;
                                        int mouseTileY = (int)(mouseLocation.Y / this.magnification + clipDistanceY) / 16;
                                        this.surface地图.ForeColor = Color.Magenta;
                                        if (tabControl1.SelectedIndex == 0)
                                        {
                                            int x1 = (int)(float)((mouseTileX * 16 - clipDistanceX) * this.magnification);
                                            int y1 = (int)(float)((mouseTileY * 16 - clipDistanceY) * this.magnification);
                                            int x2 = (int)(((this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1) * 16) * this.magnification) + x1;
                                            int y2 = (int)(((this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1) * 16) * this.magnification) + y1;
                                            this.surface地图.DrawBox(x1, y1, x2 + 1, y2 + 1);
                                        }
                                        if (tabControl1.SelectedIndex == 1)
                                        {

                                            int x1 = (int)(float)((mouseTileX * 16 - clipDistanceX) * this.magnification);
                                            int y1 = (int)(float)((mouseTileY * 16 - clipDistanceY) * this.magnification);
                                            int x2 = (int)(16 * this.magnification) + x1;
                                            int y2 = (int)(16 * this.magnification) + y1;
                                            this.surface地图.DrawBox(x1, y1, x2, y2);
                                        }
                                    }
                                }
                            }
                            break;
                        case EditMode.Select:
                            {
                                if (this.currentOperationLayerData != null)
                                {
                                    int visualLayerCameraX = 0;
                                    int visualLayerCameraY = 0;
                                    if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                    {
                                        visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                    }
                                    if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                    {
                                        visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                    }

                                    if ((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification < this.pictureBox地图.ClientSize.Height)
                                    {
                                        this.surface地图.ForeColor = Color.Pink;
                                        int x2 = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                        this.surface地图.DrawLine(0, (int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), x2, (int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification));
                                    }

                                    if ((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification < this.pictureBox地图.ClientSize.Width)
                                    {
                                        this.surface地图.ForeColor = Color.Pink;
                                        int y2 = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                        this.surface地图.DrawLine((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), 0, (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), y2);
                                    }

                                    this.surface地图.FillStyle = 1;

                                    if (this.clipRectStartTileX != this.clipRectEndTileX && this.clipRectStartTileY != this.clipRectEndTileY)
                                    {
                                        int clipDistanceX = visualLayerCameraX % 16;
                                        int clipDistanceY = visualLayerCameraY % 16;

                                        int x1 = (int)((this.clipRectStartTileX * 16 - visualLayerCameraX) * this.magnification);
                                        int y1 = (int)((this.clipRectStartTileY * 16 - visualLayerCameraY) * this.magnification);
                                        int x2 = (int)((this.clipRectEndTileX - this.clipRectStartTileX) * 16 * this.magnification) + x1;
                                        int y2 = (int)((this.clipRectEndTileY - this.clipRectStartTileY) * 16 * this.magnification) + y1;
                                        this.surface地图.ForeColor = Color.Magenta;
                                        this.surface地图.DrawBox(x1, y1, x2 + 1, y2 + 1);
                                    }
                                }
                            }
                            break;

                        case EditMode.LogicProperty:
                            {
                                this.surface地图.FillStyle = 1;

                                this.surface地图.ForeColor = Color.Black;
                                int clipDistanceX = logicLayerCameraX % 16;
                                int clipDistanceY = logicLayerCameraY % 16;
                                //for (int i = 0; i < hLogicTileCount; i++)
                                //{
                                //    this.surface地图.DrawLine((int)((i * 16 - clipDistanceX) * this.magnification), 0, (int)((i * 16 - clipDistanceX) * this.magnification), (int)(vLogicTileCount * 16 * this.magnification));
                                //}

                                //for (int i = 0; i < vLogicTileCount; i++)
                                //{
                                //    this.surface地图.DrawLine(0, (int)((i * 16 - clipDistanceY) * this.magnification), (int)(hLogicTileCount * 16 * this.magnification), (int)((i * 16 - clipDistanceY) * this.magnification));
                                //}

                                for (int i = 0; i < hLogicTileCount; i++)
                                {
                                    for (int j = 0; j < vLogicTileCount; j++)
                                    {
                                        byte property = mapData.LogicLayer.LogicLayerTable[(logicLayerCameraX / 16) + i, (logicLayerCameraY / 16) + j];
                                        //byte property = this.currentOperationLayerData.VisualPropertyTable[cameraTileX + i, cameraTileY + j];
                                        //byte logicProperty = (byte)(property & 0x0F);

                                        //Font font = new Font("Default", 8 * this.magnification, FontStyle.Regular);
                                        if (this.isLogicColorful)
                                        {

                                            this.setLogicTextColor(property);
                                        }
                                        else
                                        {
                                            this.surface地图.ForeColor = Color.Magenta;
                                        }
                                        this.surface地图.DrawText((int)((i * 16 - clipDistanceX) * this.magnification + 2 * this.magnification), (int)((j * 16 - clipDistanceY) * this.magnification + 2 * this.magnification), property.ToString(), false);
                                        //graphics.DrawString(logicProperty.ToString(), font, Brushes.Magenta, i * 16 * this.magnification + 2 * this.magnification, j * 16 * this.magnification + 2 * this.magnification);
                                        //font.Dispose();
                                    }
                                }
                            }
                            break;
                        case EditMode.RegionSelect:
                            {
                                this.surface地图.ForeColor = Color.Black;
                                this.surface地图.FillStyle = 1;
                                this.surface地图.FillStyle = 1;

                                //this.surface地图.ForeColor = Color.Black;
                                int clipDistanceX = logicLayerCameraX % 16;
                                int clipDistanceY = logicLayerCameraY % 16;

                                int logicLayerCameraEndX = logicLayerCameraX + (int)(this.pictureBox地图.ClientSize.Width / this.magnification);
                                int logicLayerCameraEndY = logicLayerCameraY + (int)(this.pictureBox地图.ClientSize.Height / this.magnification);
                                //for (int i = 0; i < hLogicTileCount; i++)
                                //{
                                //    this.surface地图.DrawLine((int)((i * 16 - clipDistanceX) * this.magnification), 0, (int)((i * 16 - clipDistanceX) * this.magnification), (int)(vLogicTileCount * 16 * this.magnification));
                                //}

                                //for (int i = 0; i < vLogicTileCount; i++)
                                //{
                                //    this.surface地图.DrawLine(0, (int)((i * 16 - clipDistanceY) * this.magnification), (int)(hLogicTileCount * 16 * this.magnification), (int)((i * 16 - clipDistanceY) * this.magnification));
                                //}
                                this.surface地图.ForeColor = Color.Magenta;
                                this.surface地图.FillColor = Color.Magenta;
                                this.surface地图.FillStyle = 7;

                                for (int i = 0; i < mapData.LogicLayer.EventRegionList.Count; i++)
                                {
                                    EventRegion eventRegion = mapData.LogicLayer.EventRegionList[i];
                                    Rectangle visibleRect = new Rectangle(logicLayerCameraX, logicLayerCameraY, logicLayerCameraEndX - logicLayerCameraX, logicLayerCameraEndY - logicLayerCameraY);
                                    if (visibleRect.IntersectsWith(eventRegion.RegionRect))
                                    {

                                        if (i != this.regionSelectID)
                                        {
                                            this.surface地图.DrawBox((int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification),
                                                (int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Right * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Bottom * this.magnification) - (int)(logicLayerCameraY * this.magnification));
                                            this.surface地图.DrawText((int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[i].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification),
                                                mapData.LogicLayer.EventRegionList[i].Name, false);
                                        }
                                    }
                                }
                                int left = Math.Min(this.regionRectEndX, this.regionRectStartX);// ? (int)(this.regionRectStartX * this.magnification) : (int)(this.regionRectEndX * this.magnification);
                                int right = Math.Max(this.regionRectEndX, this.regionRectStartX);// ? (int)(this.regionRectEndX * this.magnification) : (int)(this.regionRectStartX * this.magnification);
                                int top = Math.Min(this.regionRectEndY, this.regionRectStartY);// ? (int)(this.regionRectStartY * this.magnification) : (int)(this.regionRectEndY * this.magnification);
                                int bottom = Math.Max(this.regionRectEndY, this.regionRectStartY);// ? (int)(this.regionRectEndY * this.magnification) : (int)(this.regionRectStartY * this.magnification);
                                left = (int)((left - logicLayerCameraX) * this.magnification);
                                right = (int)((right - logicLayerCameraX) * this.magnification);
                                top = (int)((top - logicLayerCameraY) * this.magnification);
                                bottom = (int)((bottom - logicLayerCameraY) * this.magnification);
                                this.surface地图.DrawBox(left, top, right, bottom);

                                if (this.regionSelectID != -1)
                                {
                                    if (this.regionDisplayMode == true)
                                    {
                                        this.surface地图.DrawBox((int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification),
                                            (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Right * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Bottom * this.magnification) - (int)(logicLayerCameraY * this.magnification));
                                    }
                                    else
                                    {
                                        this.surface地图.FillStyle = 1;
                                        this.surface地图.DrawBox((int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification),
                                            (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Right * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Bottom * this.magnification) - (int)(logicLayerCameraY * this.magnification));
                                    }
                                    if (this.regionEditMode == RegionEditMode.Stretch)
                                    {
                                        this.surface地图.ForeColor = Color.Gold;
                                        int rleft = (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification);
                                        int rtop = (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification);
                                        int rright = (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Right * this.magnification) - (int)(logicLayerCameraX * this.magnification) - 1;
                                        int rbottom = (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Bottom * this.magnification) - (int)(logicLayerCameraY * this.magnification) - 1;
                                        this.surface地图.DrawLine(rleft, rtop, rleft + (int)(16 * this.magnification), rtop);
                                        this.surface地图.DrawLine(rleft, rtop, rleft, rtop + (int)(16 * this.magnification));
                                        this.surface地图.DrawLine(rright - (int)(16 * this.magnification), rtop, rright, rtop);
                                        this.surface地图.DrawLine(rright, rtop, rright, rtop + (int)(16 * this.magnification));
                                        this.surface地图.DrawLine(rright - (int)(16 * this.magnification), rbottom, rright, rbottom);
                                        this.surface地图.DrawLine(rright, rbottom - (int)(16 * this.magnification), rright, rbottom);
                                        this.surface地图.DrawLine(rleft, rbottom, rleft + (int)(16 * this.magnification), rbottom);
                                        this.surface地图.DrawLine(rleft, rbottom - (int)(16 * this.magnification), rleft, rbottom);

                                        this.surface地图.ForeColor = Color.Magenta;
                                    }
                                    this.surface地图.DrawText((int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left * this.magnification) - (int)(logicLayerCameraX * this.magnification), (int)(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top * this.magnification) - (int)(logicLayerCameraY * this.magnification),
                                            mapData.LogicLayer.EventRegionList[this.regionSelectID].Name, false);
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    surface地图.DrawToDc(hdc, this.pictureBox地图.ClientRectangle, this.pictureBox地图.ClientRectangle);
                }
                catch (SurfaceLostException)
                {
                    if (device.TestCooperativeLevel())
                    {
                        this.CreateSurface();
                    }
                }
                finally
                {
                    e.Graphics.ReleaseHdc();
                }

               

            }
        }

        private void pictureBox地图_MouseDown(object sender, MouseEventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;

            int logicLayerCameraX = this.hScrollBar地图.Value;
            int logicLayerCameraY = this.vScrollBar地图.Value;

            if (mapData != null)
            {
                

                switch (this.editMode)
                {
                    case EditMode.Draw:
                        {
                            if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                            {
                                int visualLayerCameraX = 0;
                                int visualLayerCameraY = 0;
                                if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                {
                                    visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                }
                                if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                {
                                    visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                }
                                int validWidth = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                int validHeight = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                Rectangle validRect = new Rectangle(0, 0, validWidth, validHeight);

                                if (e.Button == MouseButtons.Left && validRect.Contains(e.Location))
                                {


                                    this.mapStartTileX = (int)(visualLayerCameraX * this.magnification + e.X) / (int)(16 * this.magnification);
                                    this.mapStartTileY = (int)(visualLayerCameraY * this.magnification + e.Y) / (int)(16 * this.magnification);

                                    //MapData mapData = this.listBox关卡.SelectedItem as MapData;
                                    this.toolStripStatusLabel选择信息.Text = "X=" + this.mapStartTileX + "  " + "Y=" + this.mapStartTileY;

                                    StaticTileSetData staticTileSetData = null;
                                    DynamicTileSetData dynamicTileSetData = null;

                                    int hTileCount = this.currentOperationLayerData.HorizontalTileCount;
                                    int vTileCount = this.currentOperationLayerData.VerticalTileCount;

                                    if (this.currentOperationLayerData.StaticBitmapID >= 0)
                                    {
                                        staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;
                                    }
                                    if (this.currentOperationLayerData.DynamicBitmapID >= 0)
                                    {
                                        dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;
                                    }



                                    if (tabControl1.SelectedIndex == 0 && staticTileSetData != null && staticTileSetData.Bitmap != null)
                                    {
                                        int xLenth = this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1 < hTileCount - mapStartTileX ? this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1 : hTileCount - mapStartTileX;
                                        int yLenth = this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1 < vTileCount - mapStartTileY ? this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1 : vTileCount - mapStartTileY;
                                        byte positionXY;
                                        byte positionX;
                                        byte positionY;
                                        for (int x = 0; x < xLenth; x++)
                                        {
                                            for (int y = 0; y < yLenth; y++)
                                            {
                                                positionX = (byte)(this.staticSelectedTileStartX + x);
                                                positionY = (byte)(this.staticSelectedTileStartY + y);
                                                positionXY = (byte)((positionY << 4) + positionX);
                                                this.currentOperationLayerData.VisualLayerTable[this.mapStartTileX + x, this.mapStartTileY + y] = positionXY;
                                                this.currentOperationLayerData.VisualPropertyTable[this.mapStartTileX + x, this.mapStartTileY + y] = 1;
                                            }

                                        }
                                    }

                                    if (tabControl1.SelectedIndex == 1 && dynamicTileSetData != null && dynamicTileSetData.DynamicTileDataList.Count > 0)
                                    {

                                        if (dynamicTileSetData.DynamicTileDataList[this.dynamicSelectedID].FrameList.Count >= 0)
                                        {

                                            this.currentOperationLayerData.VisualLayerTable[mapStartTileX, mapStartTileY] = (byte)this.dynamicSelectedID;
                                            this.currentOperationLayerData.VisualPropertyTable[mapStartTileX, mapStartTileY] = 2;
                                        }
                                    }

                                }


                                if (e.Button == MouseButtons.Middle && validRect.Contains(e.Location))
                                {
                                    StaticTileSetData staticTileSetData = null;
                                    DynamicTileSetData dynamicTileSetData = null;

                                    if (this.currentOperationLayerData.StaticBitmapID >= 0)
                                    {
                                        staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;
                                    }
                                    if (this.currentOperationLayerData.DynamicBitmapID >= 0)
                                    {
                                        dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;
                                    }

                                    byte position = this.currentOperationLayerData.VisualLayerTable[(e.X + (int)(visualLayerCameraX * this.magnification)) / (int)(16 * this.magnification), (e.Y + (int)(visualLayerCameraY * this.magnification)) / (int)(16 * this.magnification)];
                                    byte property = this.currentOperationLayerData.VisualPropertyTable[(e.X + (int)(visualLayerCameraX * this.magnification)) / (int)(16 * this.magnification), (e.Y + (int)(visualLayerCameraY * this.magnification)) / (int)(16 * this.magnification)];

                                    property = (byte)(property & 0x03);

                                    if (property == 1 && staticTileSetData != null && staticTileSetData.Bitmap != null)
                                    {
                                        this.tabControl1.SelectedIndex = 0;


                                        this.staticSelectedTileStartX = this.staticSelectedTileEndX = position & 0x0F;
                                        this.staticSelectedTileStartY = this.staticSelectedTileEndY = position >> 4;

                                        this.pictureBox静态图.Invalidate();
                                    }

                                    if (property == 2 && dynamicTileSetData != null && dynamicTileSetData.DynamicTileDataList.Count > 0)
                                    {
                                        this.tabControl1.SelectedIndex = 1;
                                        this.dynamicSelectedID = position;

                                        this.PictureBox动态图.Invalidate();
                                    }
                                }

                                if (e.Button == MouseButtons.Right && validRect.Contains(e.Location))
                                {
                                    this.currentOperationLayerData.VisualPropertyTable[(e.X + (int)(visualLayerCameraX * this.magnification)) / (int)(16 * this.magnification), (e.Y + (int)(visualLayerCameraY * this.magnification)) / (int)(16 * this.magnification)] = 0;
                                }
                            }
                        }
                        break;
                    case EditMode.Select:
                        {
                            if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                            {

                                int visualLayerCameraX = 0;
                                int visualLayerCameraY = 0;
                                if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                {
                                    visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                }
                                if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                {
                                    visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                }
                                int validWidth = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                int validHeight = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                Rectangle validRect = new Rectangle(0, 0, validWidth, validHeight);
                                int clipDistanceX = visualLayerCameraX % 16;
                                int clipDistanceY = visualLayerCameraY % 16;

                                if (e.Button == MouseButtons.Left && validRect.Contains(e.Location))
                                {
                                    this.clipRectStartTileX = (visualLayerCameraX + (int)(e.X / this.magnification)) / 16;
                                    this.clipRectStartTileY = (visualLayerCameraY + (int)(e.Y / this.magnification)) / 16;
                                    this.clipRectStartX1 = (visualLayerCameraX + 8 + (int)(e.X / this.magnification)) / 16;
                                    this.clipRectStartY1 = (visualLayerCameraY + 8 + (int)(e.Y / this.magnification)) / 16;
                                    this.clipRectEndTileX = this.clipRectStartTileX;
                                    this.clipRectEndTileY = this.clipRectStartTileY;

                                    this.toolStripStatusLabel选择信息.Text = "StartX=" + this.clipRectStartTileX + "  " + "StartY=" + this.clipRectStartTileY + "  " + "EndX=" + this.clipRectEndTileX + "  " + "EndY=" + this.clipRectEndTileY;
                                }
                            }
                        }
                        break;
                    case EditMode.LogicProperty:
                        {
                            int validLogicWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                            int validLogicHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                            Rectangle validLogicRect = new Rectangle(0, 0, validLogicWidth, validLogicHeight);
                            if (validLogicRect.Contains(e.Location))
                            {
                                byte logicProperty = (byte)(mapData.LogicLayer.LogicLayerTable[((int)(e.X / this.magnification) + logicLayerCameraX) / 16, ((int)(e.Y / this.magnification) + logicLayerCameraY) / 16]);
                                this.toolStripStatusLabel选择信息.Text = "X=" + (e.X / (int)(16 * this.magnification) + logicLayerCameraX) + "  " + "Y=" + (e.Y / (int)(16 * this.magnification) + logicLayerCameraY);
                                if (e.Button == MouseButtons.Left)
                                {
                                    if (logicProperty == 63)
                                    {
                                        logicProperty = 0;
                                    }
                                    else
                                    {
                                        logicProperty++;
                                    }

                                }
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (logicProperty == 0)
                                    {
                                        logicProperty = 63;
                                    }
                                    else
                                    {
                                        logicProperty--;
                                    }
                                }
                                if (e.Button == MouseButtons.Middle && this.toolStripButton逻辑刷.Checked == true)
                                {
                                    logicProperty = (byte)this.logicNum;
                                }
                                mapData.LogicLayer.LogicLayerTable[((int)(e.X / this.magnification) + logicLayerCameraX) / 16, ((int)(e.Y / this.magnification) + logicLayerCameraY) / 16] = logicProperty;
                                this.pictureBox地图.Invalidate();
                            }
                        }
                        break;
                    case EditMode.RegionSelect:
                        {
                            int validLogicWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                            int validLogicHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                            Rectangle validLogicRect = new Rectangle(0, 0, validLogicWidth, validLogicHeight);

                            if (e.Button == MouseButtons.Left)
                            {
                                Point position;
                                int positionX = (int)(e.X / this.magnification) + logicLayerCameraX;
                                int positionY = (int)(e.Y / this.magnification) + logicLayerCameraY;
                                position = new Point(positionX, positionY);
                                switch (this.regionEditMode)
                                {
                                    case RegionEditMode.Bulid:
                                        {
                                            if (validLogicRect.Contains(e.Location))
                                            {
                                                this.isCreateRegion = true;
                                                this.regionRectStartX = (int)(e.X / this.magnification) + logicLayerCameraX;
                                                this.regionRectStartY = (int)(e.Y / this.magnification) + logicLayerCameraY;
                                                this.regionRectEndX = this.regionRectStartX;
                                                this.regionRectEndY = this.regionRectStartY;
                                            }
                                        }
                                        break;
                                    case RegionEditMode.Move:
                                        {
                                            if (this.isRegionSelected == false && validLogicRect.Contains(e.Location))
                                            {
                                                this.regionSelectID = mapData.LogicLayer.TraveRegionList(position);
                                                if (this.regionSelectID != -1)
                                                {
                                                    this.regionStartPosition = position;
                                                    this.regionOrgRect = mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect;
                                                    this.isRegionSelected = true;

                                                }
                                            }
                                            else if (this.isRegionSelected == true)
                                            {
                                                this.regionSelectID = -1;
                                                this.isRegionSelected = false;
                                            }
                                        }
                                        break;
                                    case RegionEditMode.Stretch:
                                        {
                                            if (this.isRegionSelected == false)
                                            {
                                                this.regionSelectID = mapData.LogicLayer.TraveRegionList(position);
                                                if (this.regionSelectID != -1)
                                                {
                                                    this.regionStartPosition = position;
                                                    this.regionOrgRect = mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect;
                                                    this.isRegionSelected = true;
                                                    Rectangle rect1, rect2, rect3, rect4;
                                                    rect1 = new Rectangle(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top,
                                                        mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2);
                                                    rect2 = new Rectangle(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left + mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top,
                                                        mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width - mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2);
                                                    rect3 = new Rectangle(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top + mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2,
                                                        mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height - mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2);
                                                    rect4 = new Rectangle(mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Left + mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Top + mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2,
                                                        mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width - mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Width / 2, mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height - mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect.Height / 2);
                                                    if (rect1.Contains(position))
                                                    {
                                                        this.stretchRegionDirection = 1;
                                                    }
                                                    else if (rect2.Contains(position))
                                                    {
                                                        this.stretchRegionDirection = 2;
                                                    }
                                                    else if (rect3.Contains(position))
                                                    {
                                                        this.stretchRegionDirection = 3;
                                                    }
                                                    else
                                                    {
                                                        this.stretchRegionDirection = 4;
                                                    }
                                                }
                                            }
                                            else if (this.isRegionSelected == true)
                                            {
                                                this.regionSelectID = -1;
                                                this.isRegionSelected = false;
                                            }
                                        }
                                        break;
                                    case RegionEditMode.Del:
                                        {

                                            int i = mapData.LogicLayer.TraveRegionList(position);
                                            if (i != -1)
                                            {
                                                mapData.LogicLayer.EventRegionList.RemoveAt(i);
                                            }
                                        }
                                        break;
                                    case RegionEditMode.Rename:
                                        {
                                            this.regionSelectID = mapData.LogicLayer.TraveRegionList(position);
                                            if (this.regionSelectID != -1)
                                            {
                                                Form区域名称修改 form = new Form区域名称修改(this, mapData.LogicLayer.EventRegionList[this.regionSelectID].Name);
                                                if (form.ShowDialog() == DialogResult.OK)
                                                {
                                                    mapData.LogicLayer.EventRegionList[this.regionSelectID].Name = form.RegionName;
                                                }
                                                form.Dispose();
                                                this.regionSelectID = -1;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }

                            if (e.Button == MouseButtons.Right)
                            {
                                //Point position;
                                //int positionX = (int)(e.X / this.magnification) + logicCameraX;
                                //int positionY = (int)(e.Y / this.magnification) + logicCameraY;
                                //position = new Point(positionX, positionY);
                                //this.regionSelectID = this.TraveRegionList(position);
                                //if (this.regionSelectID != -1)
                                this.contextMenuStrip区域.Show(this.pictureBox地图.PointToScreen(e.Location));
                            }
                            this.toolStripStatusLabel选择信息.Text = "X=" + (e.X / (int)(16 * this.magnification) + logicLayerCameraX) + "  " + "Y=" + (e.Y / (int)(16 * this.magnification) + logicLayerCameraY);
                            //}
                        }
                        break;
                    default:
                        break;
                }
                //}
            }
            //if (!this.timer1.Enabled)
            //{
            //    this.pictureBox地图.Invalidate();
            //}
        }

        private void pictureBox地图_MouseUp(object sender, MouseEventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (mapData == null)
                return;
            int logicLayerCameraX = this.hScrollBar地图.Value;
            int logicLayerCameraY = this.vScrollBar地图.Value;



            switch (this.editMode)
            {
                case EditMode.Draw:
                    {
                        if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                        {
                            int visualLayerCameraX = 0;
                            int visualLayerCameraY = 0;
                            if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                            {
                                visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                            }
                            if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                            {
                                visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                            }
                            if (e.Button == MouseButtons.Left)
                            {

                                this.mapEndTileX = e.X / (int)(16 * this.magnification) + visualLayerCameraX / 16;
                                this.mapEndTileY = e.Y / (int)(16 * this.magnification) + visualLayerCameraY / 16;
                            }
                        }
                    }
                    break;
                case EditMode.Select:
                    {
                        if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                        {

                            int visualLayerCameraX = 0;
                            int visualLayerCameraY = 0;
                            if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                            {
                                visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                            }
                            if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                            {
                                visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                            }


                            int visibleWidth = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                            int visibleHeight = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);

                            int clipDistanceX = visualLayerCameraX % 16;
                            int clipDistanceY = visualLayerCameraY % 16;

                            if (e.Button == MouseButtons.Left)
                            {
                                if (e.X >= 0 && e.X < visibleWidth)
                                {
                                    this.clipRectEndTileX = (visualLayerCameraX + 8 + (int)(e.X / this.magnification)) / 16;
                                }
                                else if (e.X < 0)
                                {
                                    this.clipRectEndTileX = visualLayerCameraX / 16;
                                }
                                else
                                {
                                    this.clipRectEndTileX = (visualLayerCameraX + 8 + (int)(visibleWidth / this.magnification)) / 16;
                                }

                                if (e.Y >= 0 && e.Y < visibleHeight)
                                {
                                    this.clipRectEndTileY = (visualLayerCameraY + 8 + (int)(e.Y / this.magnification)) / 16;
                                }
                                else if (e.Y < 0)
                                {
                                    this.clipRectEndTileY = visualLayerCameraY / 16;
                                }
                                else
                                {
                                    this.clipRectEndTileY = (visualLayerCameraY + 8 + (int)(visibleHeight / this.magnification)) / 16;
                                }


                                if (this.clipRectEndTileX == this.clipRectStartX1)
                                {
                                    this.clipRectEndTileX = this.clipRectStartTileX;
                                }
                                if (this.clipRectEndTileY == this.clipRectStartY1)
                                {
                                    this.clipRectEndTileY = this.clipRectStartTileY;
                                }

                                if (this.clipRectEndTileX < this.clipRectStartTileX)
                                {
                                    int temp = this.clipRectStartTileX;
                                    this.clipRectStartTileX = this.clipRectEndTileX;
                                    this.clipRectEndTileX = temp;
                                }
                                if (this.clipRectEndTileY < this.clipRectStartTileY)
                                {
                                    int temp = this.clipRectStartTileY;
                                    this.clipRectStartTileY = this.clipRectEndTileY;
                                    this.clipRectEndTileY = temp;
                                }
                                if (this.clipRectEndTileX != this.clipRectStartTileX && this.clipRectEndTileY != this.clipRectStartTileY)
                                {
                                    this.toolStripButton垂直翻转.Enabled = true;
                                    this.toolStripMenuItem垂直翻转.Enabled = true;
                                    this.toolStripButton水平翻转.Enabled = true;
                                    this.toolStripMenuItem水平翻转.Enabled = true;
                                    this.toolStripButton复制.Enabled = true;
                                    this.toolStripMenuItem复制.Enabled = true;
                                    this.toolStripButton删除.Enabled = true;
                                    this.toolStripMenuItem擦除.Enabled = true;
                                    if (this.copyData != null)
                                    {
                                        this.toolStripButton粘贴.Enabled = true;
                                        this.toolStripMenuItem粘贴.Enabled = true;
                                    }
                                }
                                else
                                {
                                    this.toolStripButton垂直翻转.Enabled = false;
                                    this.toolStripMenuItem垂直翻转.Enabled = false;
                                    this.toolStripButton水平翻转.Enabled = false;
                                    this.toolStripMenuItem水平翻转.Enabled = false;
                                    this.toolStripButton复制.Enabled = false;
                                    this.toolStripMenuItem复制.Enabled = false;
                                    this.toolStripButton删除.Enabled = false;
                                    this.toolStripMenuItem擦除.Enabled = false;
                                }

                            }

                        }
                    }
                    break;
                case EditMode.RegionSelect:
                    {
                        int visibleWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                        int visibleHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);

                        if (e.Button == MouseButtons.Left)
                        {
                            if (this.regionEditMode == RegionEditMode.Bulid)
                            {
                                if (this.isCreateRegion)
                                {
                                    if (e.X >= 0 && e.X < visibleWidth)
                                    {
                                        this.regionRectEndX = (int)(e.X / this.magnification) + logicLayerCameraX;
                                    }
                                    else if (e.X < 0)
                                    {
                                        this.regionRectEndX = logicLayerCameraY;
                                    }
                                    else
                                    {
                                        this.regionRectEndX = (int)(visibleWidth / this.magnification) + logicLayerCameraX;
                                    }

                                    if (e.Y >= 0 && e.Y < visibleHeight)
                                    {
                                        this.regionRectEndY = (int)(e.Y / this.magnification) + logicLayerCameraY;
                                    }
                                    else if (e.Y < 0)
                                    {
                                        this.regionRectEndY = logicLayerCameraY;
                                    }
                                    else
                                    {
                                        this.regionRectEndY = (int)(visibleHeight / this.magnification) + logicLayerCameraY;
                                    }

                                    //this.regionRectEndX = e.X < visibleWidth ? (int)(e.X / this.magnification) + logicCameraX * 16 : (int)(visibleWidth / this.magnification) + logicCameraX * 16;
                                    //this.regionRectEndY = e.Y < visibleHeight ? (int)(e.Y / this.magnification) + this.vScrollBar地图.Value * 16 : (int)(visibleHeight / this.magnification) + this.vScrollBar地图.Value * 16;
                                    if (this.regionRectEndX < this.regionRectStartX)
                                    {
                                        int temp = this.regionRectStartX;
                                        this.regionRectStartX = this.regionRectEndX;
                                        this.regionRectEndX = temp;
                                    }
                                    if (this.regionRectEndY < this.regionRectStartY)
                                    {
                                        int temp = this.regionRectStartY;
                                        this.regionRectStartY = this.regionRectEndY;
                                        this.regionRectEndY = temp;
                                    }
                                    if ((this.regionRectEndX - this.regionRectStartX) >= 16 && (this.regionRectEndY - this.regionRectStartY) >= 16)
                                    {
                                        Rectangle regionRect = new Rectangle(this.regionRectStartX, this.regionRectStartY, this.regionRectEndX - this.regionRectStartX, this.regionRectEndY - this.regionRectStartY);
                                        int q = 1;
                                        string name = "region" + (mapData.LogicLayer.EventRegionList.Count + 1).ToString(); ;
                                        while (!mapData.LogicLayer.CheckRegionName(name))
                                        {
                                            name = "region" + (mapData.LogicLayer.EventRegionList.Count + (++q)).ToString();
                                        }
                                        mapData.LogicLayer.EventRegionList.Add(new EventRegion(name, regionRect));
                                    }
                                    this.regionRectStartX = this.regionRectEndX = 0;
                                    this.regionRectStartY = this.regionRectEndY = 0;
                                    this.isCreateRegion = false;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            //if (!this.timer1.Enabled)
            //{
            //    this.pictureBox地图.Invalidate();
            //}
        }

        private void pictureBox地图_MouseMove(object sender, MouseEventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;

            int logicLayerCameraX = this.hScrollBar地图.Value;
            int logicLayerCameraY = this.vScrollBar地图.Value;

            if (mapData != null)
            {


                switch (this.editMode)
                {
                    case EditMode.Draw:
                        {
                            if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                            {
                                int visualLayerCameraX = 0;
                                int visualLayerCameraY = 0;
                                if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                {
                                    visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                }
                                if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                {
                                    visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                }

                                this.mapMoveTileX = (int)(visualLayerCameraX * this.magnification + e.X) / (int)(16 * this.magnification);
                                this.mapMoveTileY = (int)(visualLayerCameraY * this.magnification + e.Y) / (int)(16 * this.magnification);



                                int validWidth = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                int validHeight = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                Rectangle validRect = new Rectangle(0, 0, validWidth, validHeight);



                                this.toolStripStatusLabel选择信息.Text = "X=" + this.mapMoveTileX + "  " + "Y=" + this.mapMoveTileY;

                                if (e.Button == MouseButtons.Left && validRect.Contains(e.Location))
                                {
                                    Console.WriteLine(e.Location);
                                    //this.mapMoveX = this.mapMoveX != e.X / (int)(16 * this.magnification) ? e.X / (int)(16 * this.magnification) : this.mapMoveX;
                                    //this.mapMoveY = this.mapMoveY != e.Y / (int)(16 * this.magnification) ? e.Y / (int)(16 * this.magnification) : this.mapMoveY;

                                    //MapData mapData = this.listBox关卡.SelectedItem as MapData;

                                    //this.mapMoveTileX = e.X / (int)(16 * this.magnification) + cameraTileX;
                                    //this.mapMoveTileY = e.Y / (int)(16 * this.magnification) + cameraTileY;

                                    StaticTileSetData staticTileSetData = null;
                                    DynamicTileSetData dynamicTileSetData = null;

                                    int hTileCount = this.currentOperationLayerData.HorizontalTileCount;
                                    int vTileCount = this.currentOperationLayerData.VerticalTileCount;

                                    if (this.currentOperationLayerData.StaticBitmapID >= 0)
                                    {
                                        staticTileSetData = this.form元数据.ListBox静态图块集.Items[this.currentOperationLayerData.StaticBitmapID] as StaticTileSetData;
                                    }
                                    if (this.currentOperationLayerData.DynamicBitmapID >= 0)
                                    {
                                        dynamicTileSetData = this.form元数据.ListBox动态图块集.Items[this.currentOperationLayerData.DynamicBitmapID] as DynamicTileSetData;
                                    }

                                    if (tabControl1.SelectedIndex == 0 && staticTileSetData != null && staticTileSetData.Bitmap != null)
                                    {
                                        int srcHorizontalCount = this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1;
                                        int srcVericalCount = this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1;
                                        int xLenth = this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1 < hTileCount - mapMoveTileX ? this.staticSelectedTileEndX - this.staticSelectedTileStartX + 1 : hTileCount - mapMoveTileX;
                                        int yLenth = this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1 < vTileCount - mapMoveTileY ? this.staticSelectedTileEndY - this.staticSelectedTileStartY + 1 : vTileCount - mapMoveTileY;
                                        byte positionXY;
                                        byte positionX;
                                        byte positionY;
                                        for (int x = 0; x < xLenth; x++)
                                        {
                                            for (int y = 0; y < yLenth; y++)
                                            {
                                                positionX = (byte)((this.staticSelectedTileStartX + (((this.mapMoveTileX - this.mapStartTileX) % srcHorizontalCount) + x + srcHorizontalCount) % srcHorizontalCount));
                                                positionY = (byte)((this.staticSelectedTileStartY + (((this.mapMoveTileY - this.mapStartTileY) % srcVericalCount) + y + srcVericalCount) % srcVericalCount));
                                                positionXY = (byte)((positionY << 4) + positionX);
                                                this.currentOperationLayerData.VisualLayerTable[this.mapMoveTileX + x, this.mapMoveTileY + y] = positionXY;
                                                this.currentOperationLayerData.VisualPropertyTable[this.mapMoveTileX + x, this.mapMoveTileY + y] = 1;
                                            }

                                        }
                                    }


                                    if (tabControl1.SelectedIndex == 1 && dynamicTileSetData != null && dynamicTileSetData.DynamicTileDataList.Count > 0)
                                    {

                                        if (dynamicTileSetData.DynamicTileDataList[this.dynamicSelectedID].FrameList.Count >= 0)
                                        {

                                            this.currentOperationLayerData.VisualLayerTable[this.mapMoveTileX, this.mapMoveTileY] = (byte)this.dynamicSelectedID;
                                            this.currentOperationLayerData.VisualPropertyTable[this.mapMoveTileX, this.mapMoveTileY] = 2;
                                        }
                                    }
                                }

                                if (e.Button == MouseButtons.Right && validRect.Contains(e.Location))
                                {
                                    this.currentOperationLayerData.VisualPropertyTable[(e.X + (int)(visualLayerCameraX * this.magnification)) / (int)(16 * this.magnification), (e.Y + (int)(visualLayerCameraY * this.magnification)) / (int)(16 * this.magnification)] = 0;
                                }

                            }
                        }
                        break;
                    case EditMode.Select:
                        {
                            if (this.currentOperationLayerData != null && this.currentOperationLayerData.Visible)
                            {
                                //int visibleWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                //int visibleHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                                //System.Console.WriteLine("visibleWidth" + visibleWidth);
                                int visualLayerCameraX = 0;
                                int visualLayerCameraY = 0;
                                if (mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth > 0 && this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth > 0)
                                {
                                    visualLayerCameraX = (int)((this.currentOperationLayerData.HorizontalTileCount * 16 - this.screenWidth) / (float)(mapData.LogicLayer.HorizontalTileCount * 16 - this.screenWidth) * logicLayerCameraX);
                                }
                                if (mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight > 0 && this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight > 0)
                                {
                                    visualLayerCameraY = (int)((this.currentOperationLayerData.VerticalTileCount * 16 - this.screenHeight) / (float)(mapData.LogicLayer.VerticalTileCount * 16 - this.screenHeight) * logicLayerCameraY);
                                }

                                int visibleWidth = Math.Min((int)((this.currentOperationLayerData.HorizontalTileCount * 16 - visualLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                                int visibleHeight = Math.Min((int)((this.currentOperationLayerData.VerticalTileCount * 16 - visualLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);

                                int clipDistanceX = visualLayerCameraX % 16;
                                int clipDistanceY = visualLayerCameraY % 16;

                                if (e.Button == MouseButtons.Left)
                                {

                                    if (e.X >= 0 && e.X < visibleWidth)
                                    {
                                        this.clipRectEndTileX = (visualLayerCameraX + 8 + (int)(e.X / this.magnification)) / 16;
                                    }
                                    else if (e.X < 0)
                                    {
                                        this.clipRectEndTileX = visualLayerCameraX / 16;
                                    }
                                    else
                                    {
                                        this.clipRectEndTileX = (visualLayerCameraX + 8 + (int)(visibleWidth / this.magnification)) / 16;
                                    }

                                    if (e.Y >= 0 && e.Y < visibleHeight)
                                    {
                                        this.clipRectEndTileY = (visualLayerCameraY + 8 + (int)(e.Y / this.magnification)) / 16;
                                    }
                                    else if (e.Y < 0)
                                    {
                                        this.clipRectEndTileY = visualLayerCameraY / 16;
                                    }
                                    else
                                    {
                                        this.clipRectEndTileY = (visualLayerCameraY + 8 + (int)(visibleHeight / this.magnification)) / 16;
                                    }
                                    this.toolStripStatusLabel选择信息.Text = "StartX=" + this.clipRectStartTileX + "  " + "StartY=" + this.clipRectStartTileY + "  " + "EndX=" + this.clipRectEndTileX + "  " + "EndY=" + this.clipRectEndTileY;
                                }
                            }
                        }
                        break;
                    case EditMode.LogicProperty:
                        {
                            int validWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                            int validHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                            Rectangle validRect = new Rectangle(0, 0, validWidth, validHeight);
                            //MapData mapData = this.listBox关卡.SelectedItem as MapData;
                            if (validRect.Contains(e.Location) && mapData != null)
                            {
                                this.toolStripStatusLabel选择信息.Text = "TileX=" + (e.X / (int)(16 * this.magnification) + logicLayerCameraX) + "  " + "TileY=" + (e.Y / (int)(16 * this.magnification) + logicLayerCameraY) + "  " + "X=" + (e.X / this.magnification + logicLayerCameraX) + "  " + "Y=" + (e.Y / this.magnification + logicLayerCameraY);
                                if (e.Button == MouseButtons.Middle && this.toolStripButton逻辑刷.Checked == true)
                                {
                                    mapData.LogicLayer.LogicLayerTable[((int)(e.X / this.magnification) + logicLayerCameraX) / 16, ((int)(e.Y / this.magnification) + logicLayerCameraY) / 16] = (byte)this.logicNum;
                                }
                            }
                        }
                        break;
                    case EditMode.RegionSelect:
                        {
                            //int visibleWidth = (mapData.LogicLayer.HorizontalTileCount - (logicLayerCameraX / 16)) * (int)(16 * this.magnification);
                            int visibleWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
                            //int visibleHeight = (mapData.LogicLayer.VerticalTileCount - (logicLayerCameraY / 16)) * (int)(16 * this.magnification);
                            int visibleHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
                            //System.Console.WriteLine("visibleWidth" + visibleWidth);

                            //visibleWidth = (mapData.LogicLayer.HorizontalTileCount - logicLayerCameraX) * (int)(16 * this.magnification);
                            //visibleHeight = (mapData.LogicLayer.VerticalTileCount - logicLayerCameraY) * (int)(16 * this.magnification);


                            switch (this.regionEditMode)
                            {
                                case RegionEditMode.Bulid:
                                    {
                                        if (e.Button == MouseButtons.Left && this.isCreateRegion)
                                        {
                                            if (e.X >= 0 && e.X < visibleWidth)
                                            {
                                                this.regionRectEndX = (int)(e.X / this.magnification) + logicLayerCameraX;
                                            }
                                            else if (e.X < 0)
                                            {
                                                this.regionRectEndX = logicLayerCameraX;
                                            }
                                            else
                                            {
                                                this.regionRectEndX = (int)(visibleWidth / this.magnification) + logicLayerCameraX;
                                            }

                                            if (e.Y >= 0 && e.Y < visibleHeight)
                                            {
                                                this.regionRectEndY = (int)(e.Y / this.magnification) + logicLayerCameraY;
                                            }
                                            else if (e.Y < 0)
                                            {
                                                this.regionRectEndY = logicLayerCameraY;
                                            }
                                            else
                                            {
                                                this.regionRectEndY = (int)(visibleHeight / this.magnification) + logicLayerCameraY;
                                            }
                                        }
                                    }
                                    break;
                                case RegionEditMode.Move:
                                    {
                                        if (this.isRegionSelected == true && this.regionSelectID != -1)
                                        {
                                            EventRegion eventRegion = mapData.LogicLayer.EventRegionList[this.regionSelectID];
                                            int maxMoveX = mapData.LogicLayer.HorizontalTileCount * 16 - this.regionOrgRect.Right;
                                            int minMoveX = 0 - this.regionOrgRect.Left;
                                            int maxMoveY = mapData.LogicLayer.VerticalTileCount * 16 - this.regionOrgRect.Bottom;
                                            int minMoveY = 0 - this.regionOrgRect.Top;
                                            int moveDistanceX = (int)(e.X / this.magnification) + logicLayerCameraX - this.regionStartPosition.X;
                                            int moveDistanceY = (int)(e.Y / this.magnification) + logicLayerCameraY - this.regionStartPosition.Y;

                                            moveDistanceX = moveDistanceX < minMoveX ? minMoveX : moveDistanceX;
                                            moveDistanceX = moveDistanceX > maxMoveX ? maxMoveX : moveDistanceX;
                                            moveDistanceY = moveDistanceY < minMoveY ? minMoveY : moveDistanceY;
                                            moveDistanceY = moveDistanceY > maxMoveY ? maxMoveY : moveDistanceY;

                                            eventRegion.RegionRect = new Rectangle(this.regionOrgRect.Left + moveDistanceX, this.regionOrgRect.Top + moveDistanceY, this.regionOrgRect.Width, this.regionOrgRect.Height);
                                        }
                                    }
                                    break;
                                case RegionEditMode.Stretch:
                                    {
                                        if (this.isRegionSelected == true && this.regionSelectID != -1)
                                        {
                                            EventRegion eventRegion = mapData.LogicLayer.EventRegionList[this.regionSelectID];
                                            int maxMoveX = mapData.LogicLayer.HorizontalTileCount * 16 - this.regionOrgRect.Right;
                                            int minMoveX = 0 - this.regionOrgRect.Left;
                                            int maxMoveY = mapData.LogicLayer.VerticalTileCount * 16 - this.regionOrgRect.Bottom;
                                            int minMoveY = 0 - this.regionOrgRect.Top;
                                            int moveDistanceX = (int)(e.X / this.magnification) + logicLayerCameraX - this.regionStartPosition.X;
                                            int moveDistanceY = (int)(e.Y / this.magnification) + logicLayerCameraY - this.regionStartPosition.Y;
                                            switch (this.stretchRegionDirection)
                                            {
                                                case 1:
                                                    {
                                                        maxMoveX = this.regionOrgRect.Right - this.regionOrgRect.Left - 16;
                                                        maxMoveY = this.regionOrgRect.Bottom - this.regionOrgRect.Top - 16;
                                                        moveDistanceX = moveDistanceX < minMoveX ? minMoveX : moveDistanceX;
                                                        moveDistanceX = moveDistanceX > maxMoveX ? maxMoveX : moveDistanceX;
                                                        moveDistanceY = moveDistanceY < minMoveY ? minMoveY : moveDistanceY;
                                                        moveDistanceY = moveDistanceY > maxMoveY ? maxMoveY : moveDistanceY;
                                                        eventRegion.RegionRect = new Rectangle(this.regionOrgRect.Left + moveDistanceX, this.regionOrgRect.Top + moveDistanceY, this.regionOrgRect.Width - moveDistanceX, this.regionOrgRect.Height - moveDistanceY);
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        minMoveX = this.regionOrgRect.Left + 16 - this.regionOrgRect.Right;
                                                        maxMoveY = this.regionOrgRect.Bottom - this.regionOrgRect.Top - 16;
                                                        moveDistanceX = moveDistanceX < minMoveX ? minMoveX : moveDistanceX;
                                                        moveDistanceX = moveDistanceX > maxMoveX ? maxMoveX : moveDistanceX;
                                                        moveDistanceY = moveDistanceY < minMoveY ? minMoveY : moveDistanceY;
                                                        moveDistanceY = moveDistanceY > maxMoveY ? maxMoveY : moveDistanceY;
                                                        eventRegion.RegionRect = new Rectangle(this.regionOrgRect.Left, this.regionOrgRect.Top + moveDistanceY, this.regionOrgRect.Width + moveDistanceX, this.regionOrgRect.Height - moveDistanceY);
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        maxMoveX = this.regionOrgRect.Right - this.regionOrgRect.Left - 16;
                                                        minMoveY = this.regionOrgRect.Top + 16 - this.regionOrgRect.Bottom;
                                                        moveDistanceX = moveDistanceX < minMoveX ? minMoveX : moveDistanceX;
                                                        moveDistanceX = moveDistanceX > maxMoveX ? maxMoveX : moveDistanceX;
                                                        moveDistanceY = moveDistanceY < minMoveY ? minMoveY : moveDistanceY;
                                                        moveDistanceY = moveDistanceY > maxMoveY ? maxMoveY : moveDistanceY;
                                                        eventRegion.RegionRect = new Rectangle(this.regionOrgRect.Left + moveDistanceX, this.regionOrgRect.Top, this.regionOrgRect.Width - moveDistanceX, this.regionOrgRect.Height + moveDistanceY);
                                                    }
                                                    break;
                                                case 4:
                                                    {
                                                        minMoveX = this.regionOrgRect.Left + 16 - this.regionOrgRect.Right;
                                                        minMoveY = this.regionOrgRect.Top + 16 - this.regionOrgRect.Bottom;
                                                        moveDistanceX = moveDistanceX < minMoveX ? minMoveX : moveDistanceX;
                                                        moveDistanceX = moveDistanceX > maxMoveX ? maxMoveX : moveDistanceX;
                                                        moveDistanceY = moveDistanceY < minMoveY ? minMoveY : moveDistanceY;
                                                        moveDistanceY = moveDistanceY > maxMoveY ? maxMoveY : moveDistanceY;
                                                        eventRegion.RegionRect = new Rectangle(this.regionOrgRect.Left, this.regionOrgRect.Top, this.regionOrgRect.Width + moveDistanceX, this.regionOrgRect.Height + moveDistanceY);
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case RegionEditMode.Del:
                                    {
                                    }
                                    break;
                                default:
                                    break;
                            }

                            this.toolStripStatusLabel选择信息.Text = "TileX=" + (e.X / (int)(16 * this.magnification) + logicLayerCameraX) + "  " + "TileY=" + (e.Y / (int)(16 * this.magnification) + logicLayerCameraY) + "  " + "X=" + (e.X / this.magnification + logicLayerCameraX) + "  " + "Y=" + (e.Y / this.magnification + logicLayerCameraY);
                            //System.Console.WriteLine("e.X" + e.X);
                            //this.regionRectEndX = e.X < visibleWidth ? (int)(e.X / this.magnification) + logicCameraX * 16 : (int)(visibleWidth / this.magnification) + logicCameraX * 16;
                            //this.regionRectEndY = e.Y < visibleHeight ? (int)(e.Y / this.magnification) + logicCameraY * 16 : (int)(visibleHeight / this.magnification) + logicCameraY * 16;
                        }
                        break;
                    default:
                        break;
                }




                //else
                //{
                //    if (this.editMode != EditMode.Select)
                //    {
                //        this.toolStripStatusLabel选择信息.Text = "X=" + (e.X / (int)(16 * this.magnification) + logicCameraX) + "  " + "Y=" + (e.Y / (int)(16 * this.magnification) + logicCameraY);
                //    }
                //}
                //if (!this.timer1.Enabled)
                //{
                //    this.pictureBox地图.Invalidate();
                //}
            }
        }

        private bool IsMouseInCurrentOperationLayer(Point point)
        {
            //    int validWidth = Math.Min((int)((mapData.LogicLayer.HorizontalTileCount * 16 - logicLayerCameraX) * this.magnification), this.pictureBox地图.ClientSize.Width);
            //    int validHeight = Math.Min((int)((mapData.LogicLayer.VerticalTileCount * 16 - logicLayerCameraY) * this.magnification), this.pictureBox地图.ClientSize.Height);
            //    Rectangle validRect = new Rectangle(0, 0, validWidth, validHeight);
            //    return validRect.Contains(point);

            //    //int gridVisibleSize = (int)(16 * this.magnification);
            //    //int clientSizeX = this.pictureBox地图.ClientSize.Width / gridVisibleSize;
            //    //int clientSizeY = this.pictureBox地图.ClientSize.Height / gridVisibleSize;
            //    //int xLength = Math.Min(clientSizeX, this.currentOperationLayerData.HorizontalTileCount - this.hScrollBar地图.Value / 16);
            //    //int yLength = Math.Min(clientSizeY, this.currentOperationLayerData.VerticalTileCount - this.vScrollBar地图.Value / 16);
            //    //int mouseTileX = point.X / gridVisibleSize;
            //    //int mouseTileY = point.Y / gridVisibleSize;
            //    //if (mouseTileX >= 0 && mouseTileY >= 0 && mouseTileX < xLength && mouseTileY < yLength)
            //    //{
            //    //    return true;
            //    //}
            //    //return false;
            return true;

        }



        //private void toolStripMenuItem第一层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToFirstLayer();
        //}

        //private void toolStripMenuItem第二层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToSecondLayer();
        //}

        //private void toolStripMenuItem第三层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToThirdLayer();
        //}

        private void toolStripButton缩放二分之一_Click(object sender, EventArgs e)
        {
            this.ZoomToHalf();
        }

        private void toolStripButton缩放一分之一_Click(object sender, EventArgs e)
        {
            this.ZoomToOneTimes();
        }

        private void toolStripButton缩放两倍_Click(object sender, EventArgs e)
        {
            this.ZoomToTwoTimes();
        }

        private void toolStripButton缩放四倍_Click(object sender, EventArgs e)
        {
            this.ZoomToFourTimes();
        }




        private void hScrollBar地图_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox地图.Invalidate();
        }

        private void vScrollBar地图_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox地图.Invalidate();
        }

        private void pictureBox地图_Resize(object sender, EventArgs e)
        {
            this.surface地图.Dispose();
            SurfaceDescription surfaceDescription = new SurfaceDescription();
            surfaceDescription.Width = this.pictureBox地图.ClientSize.Width;
            surfaceDescription.Height = this.pictureBox地图.ClientSize.Height;
            surfaceDescription.SurfaceCaps.OffScreenPlain = true;

            this.surface地图 = new Surface(surfaceDescription, device);

            //this.ResizeScrollBar();

            this.pictureBox地图.Invalidate();
        }

        private void SaveStageFile(string filename)
        {
            FileStream fileStream = File.OpenWrite(filename);
            BinaryWriter writer = new BinaryWriter(fileStream);

            //写数据库
            //静态图块集
            writer.Write(this.form元数据.ListBox静态图块集.Items.Count);
            foreach (StaticTileSetData staticTileSetData in this.form元数据.ListBox静态图块集.Items)
            {
                writer.Write(staticTileSetData.Name);
                writer.Write(staticTileSetData.Filename);
                //writer.Write(staticTileSetData.Width);
                //writer.Write(staticTileSetData.Height);
                //for (int i = 0; i < staticTileSetData.Width; i++)
                //{
                //    for (int j = 0; j < staticTileSetData.Height; j++)
                //    {
                //        writer.Write(staticTileSetData.PropertyTable[i, j]);
                //    }
                //}
            }

            //动态图块集
            writer.Write(this.form元数据.ListBox动态图块集.Items.Count);
            foreach (DynamicTileSetData dynamicTileSetData in this.form元数据.ListBox动态图块集.Items)
            {
                writer.Write(dynamicTileSetData.Name);
                writer.Write(dynamicTileSetData.Filename);

                writer.Write(dynamicTileSetData.DynamicTileDataList.Count);
                foreach (DynamicTileData dynamicTileData in dynamicTileSetData.DynamicTileDataList)
                {
                    writer.Write(dynamicTileData.SlowRegenerationRate);
                    //writer.Write(dynamicTileData.Property);

                    writer.Write(dynamicTileData.FrameList.Count);
                    foreach (byte frame in dynamicTileData.FrameList)
                    {
                        writer.Write(frame);
                    }
                }
            }

            //音乐
            writer.Write(this.form元数据.ListBox音乐.Items.Count);
            foreach (string name in this.form元数据.ListBox音乐.Items)
            {
                writer.Write(name);
            }
            writer.Write(this.form元数据.ListBox音效.Items.Count);
            foreach (string name in this.form元数据.ListBox音效.Items)
            {
                writer.Write(name);
            }

            //变量
            writer.Write(this.form元数据.ListBox变量.Items.Count);
            foreach (EventVariable eventVariable in this.form元数据.ListBox变量.Items)
            {
                writer.Write(eventVariable.Name);
                writer.Write(eventVariable.VariableValue);
            }

            //工程
            writer.Write(this.listBox关卡.Items.Count);
            foreach (MapData mapData in this.listBox关卡.Items)
            {
                writer.Write(mapData.Name);
                //writer.Write(mapData.BgmID);
                //逻辑层
                writer.Write(mapData.LogicLayer.HorizontalTileCount);
                writer.Write(mapData.LogicLayer.VerticalTileCount);
                for (int i = 0; i < mapData.LogicLayer.HorizontalTileCount; i++)
                {
                    for (int j = 0; j < mapData.LogicLayer.VerticalTileCount; j++)
                    {
                        writer.Write(mapData.LogicLayer.LogicLayerTable[i, j]);
                    }
                }

                writer.Write(mapData.LogicLayer.EventRegionList.Count);
                for (int i = 0; i < mapData.LogicLayer.EventRegionList.Count; i++)
                {
                    writer.Write(mapData.LogicLayer.EventRegionList[i].Name);
                    writer.Write(mapData.LogicLayer.EventRegionList[i].RegionRect.Left);
                    writer.Write(mapData.LogicLayer.EventRegionList[i].RegionRect.Top);
                    writer.Write(mapData.LogicLayer.EventRegionList[i].RegionRect.Width);
                    writer.Write(mapData.LogicLayer.EventRegionList[i].RegionRect.Height);
                }

                //可见层数据
                writer.Write(mapData.VisualLayerDataList.Count);
                for (int i = 0; i < mapData.VisualLayerDataList.Count; i++)
                {
                    writer.Write(mapData.VisualLayerDataList[i].Name);
                    writer.Write(mapData.VisualLayerDataList[i].StaticBitmapID);
                    writer.Write(mapData.VisualLayerDataList[i].DynamicBitmapID);
                    writer.Write(mapData.VisualLayerDataList[i].HorizontalTileCount);
                    writer.Write(mapData.VisualLayerDataList[i].VerticalTileCount);
                    for (int j = 0; j < mapData.VisualLayerDataList[i].HorizontalTileCount; j++)
                    {
                        for (int k = 0; k < mapData.VisualLayerDataList[i].VerticalTileCount; k++)
                        {
                            writer.Write(mapData.VisualLayerDataList[i].VisualLayerTable[j, k]);
                            writer.Write(mapData.VisualLayerDataList[i].VisualPropertyTable[j, k]);
                        }
                    }
                }

                //游戏单位
                writer.Write(mapData.GameUnitList.Count);
                for (int i = 0; i < mapData.GameUnitList.Count; i++)
                {
                    writer.Write(mapData.GameUnitList[i].GameUnitName);
                    writer.Write((int)mapData.GameUnitList[i].GameUnitType);
                }
                //触发器
                writer.Write(mapData.TriggerList.Count);
                for (int i = 0; i < mapData.TriggerList.Count; i++)
                {
                    writer.Write(mapData.TriggerList[i].Name);
                    writer.Write((int)mapData.TriggerList[i].GameEventType);
                    writer.Write(mapData.TriggerList[i].GameEventConditionList.Count);
                    for (int j = 0; j < mapData.TriggerList[i].GameEventConditionList.Count; j++)
                    {
                        writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionType));
                        switch (mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionType)
                        {
                            case GameEventConditionType.VariableCompareValue:
                                {
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).VariableValue);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[2]));
                                }
                                break;
                            case GameEventConditionType.VariableCompareVariable:
                                {
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).VariableValue);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[1])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[1])).VariableValue);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[2]));
                                }
                                break;
                            case GameEventConditionType.EventRegion:
                                {
                                    //writer.Write(((EventRegion)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).Name);
                                    //writer.Write(((EventRegion)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).RegionRect.Left);
                                    //writer.Write(((EventRegion)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).RegionRect.Top);
                                    //writer.Write(((EventRegion)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).RegionRect.Width);
                                    //writer.Write(((EventRegion)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0])).RegionRect.Height);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0]));
                                }
                                break;
                            case GameEventConditionType.GameUnit:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[0]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventConditionList[j].GameEventConditionArgs[1]));
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    writer.Write(mapData.TriggerList[i].GameEventAction.CommandList.Count);
                    for (int j = 0; j < mapData.TriggerList[i].GameEventAction.CommandList.Count; j++)
                    {
                        writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].TypeID));
                        switch (mapData.TriggerList[i].GameEventAction.CommandList[j].TypeID)
                        {
                            case CommandType.ShowMessage:
                                {
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    //if ((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]))
                                    //{
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1])).Name);
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1])).VariableValue);
                                    //}
                                    //else
                                    //{
                                    //    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    //}
                                    //writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    //if ((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]))
                                    //{
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3])).Name);
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3])).VariableValue);
                                    //}
                                    //else
                                    //{
                                    //    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    //}
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[4]));
                                }
                                break;
                            case CommandType.PauseGameLogic:
                                break;
                            case CommandType.ResumeGameLogic:
                                break;
                            case CommandType.PlayMidi:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.StopMidi:
                                break;
                            case CommandType.PlayWav:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.LoadLevel:
                                {
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.CreateGameUnit:
                                {
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    //if ((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]))
                                    //{
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1])).Name);
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1])).VariableValue);
                                    //}
                                    //else
                                    //{
                                    //    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    //}
                                    //writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    //if ((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]))
                                    //{
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3])).Name);
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3])).VariableValue);
                                    //}
                                    //else
                                    //{
                                    //    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    //}
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[4]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[5]));
                                }
                                break;
                            case CommandType.RemoveGameUnit:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.KillGameUnit:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.SetPlayerInputOn:
                                break;
                            case CommandType.SetPlayerInputOff:
                                break;
                            case CommandType.SetVariable:
                                {
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).VariableValue);
                                    //writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    //if ((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]))
                                    //{
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2])).Name);
                                    //    writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2])).VariableValue);
                                    //}
                                    //else
                                    //{
                                    //    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    //}
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                }
                                break;
                            case CommandType.VariableSelfPlus:
                                {
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).VariableValue);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.VariableSelfSubtract:
                                {
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).Name);
                                    //writer.Write(((EventVariable)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).VariableValue);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.ShowVisualLayer:
                                {
                                    //writer.Write(((VisualLayerData)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).Name);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.HideVisualLayer:
                                {
                                    //writer.Write(((VisualLayerData)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0])).Name);
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.PlayRoleAnimation:
                                {
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[4]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[5]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[6]));

                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[7]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[8]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[9]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[10]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[11]));
                                }
                                break;
                            case CommandType.Wait:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.FixCamera:
                                break;
                            case CommandType.MoveCameraPosition:
                                {
                                   
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[3]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[4]));

                                }
                                break;
                            case CommandType.SetCameraPosition:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.EnableBackgroundColor:
                                {
                                    
                                }
                                break;
                            case CommandType.DisableBackgroundColor:
                                {

                                }
                                break;
                            case CommandType.SetBackgroundColor:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.SetGameUnitLayerNumber:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.SetPlayerPosition:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.SavePlayerStatus:
                                {
                                }
                                break;
                            case CommandType.RecoverPlayerStatus:
                                {
                                }
                                break;
                            case CommandType.CurtainRise:
                                {
                                }
                                break;
                            case CommandType.CurtainDrop:
                                {
                                }
                                break;
                            case CommandType.SetTriggerSwitch:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((bool)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                }
                                break;
                            case CommandType.LoadResource:
                                {
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.CalculateScore:
                                {
                                }
                                break;
                            case CommandType.ShowCredit:
                                {
                                }
                                break;
                            case CommandType.Shake:
                                {
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                }
                                break;
                            case CommandType.Charge:
                                {
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[0]));
                                    writer.Write((string)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[1]));
                                    writer.Write((int)(mapData.TriggerList[i].GameEventAction.CommandList[j].CommandArgs[2]));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    
                }

                //writer.Write(mapData.Layer1.StaticBitmapID);
                //writer.Write(mapData.Layer1.DynamicBitmapID);
                //writer.Write(mapData.Layer1.HorizontalTileCount);
                //writer.Write(mapData.Layer1.VerticalTileCount);
                //for (int i = 0; i < mapData.Layer1.HorizontalTileCount; i++)
                //{
                //    for (int j = 0; j < mapData.Layer1.VerticalTileCount; j++)
                //    {
                //        writer.Write(mapData.Layer1.VisualLayerTable[i, j]);
                //        writer.Write(mapData.Layer1.VisualPropertyTable[i, j]);
                //    }
                //}
                ////第二层
                //writer.Write(mapData.Layer2.StaticBitmapID);
                //writer.Write(mapData.Layer2.DynamicBitmapID);
                //writer.Write(mapData.Layer2.HorizontalTileCount);
                //writer.Write(mapData.Layer2.VerticalTileCount);
                //for (int i = 0; i < mapData.Layer2.HorizontalTileCount; i++)
                //{
                //    for (int j = 0; j < mapData.Layer2.VerticalTileCount; j++)
                //    {
                //        writer.Write(mapData.Layer2.VisualLayerTable[i, j]);
                //        writer.Write(mapData.Layer2.VisualPropertyTable[i, j]);
                //    }
                //}
                ////第三层
                //writer.Write(mapData.Layer3.StaticBitmapID);
                //writer.Write(mapData.Layer3.DynamicBitmapID);
                //writer.Write(mapData.Layer3.HorizontalTileCount);
                //writer.Write(mapData.Layer3.VerticalTileCount);
                //for (int i = 0; i < mapData.Layer3.HorizontalTileCount; i++)
                //{
                //    for (int j = 0; j < mapData.Layer3.VerticalTileCount; j++)
                //    {
                //        writer.Write(mapData.Layer3.VisualLayerTable[i, j]);
                //        writer.Write(mapData.Layer3.VisualPropertyTable[i, j]);
                //    }
                //}

                //writer.Write(mapData.EventRegionList.Count);
                //foreach (EventRegion eventRegion in mapData.EventRegionList)
                //{
                //    writer.Write(eventRegion.Name);
                //    writer.Write(eventRegion.RegionRect.Left);
                //    writer.Write(eventRegion.RegionRect.Top);
                //    writer.Write(eventRegion.RegionRect.Width);
                //    writer.Write(eventRegion.RegionRect.Height);
                //}

                writer.Write(mapData.BackColor.ToArgb());
                writer.Write(mapData.IsFillBackColor);
            }
            writer.Close();

        }

        private void LoadStageFile(string filename)
        {
            this.RecycleData();
            this.DisableEdit();
            this.toolStripButton事件层.Enabled = false;
            this.toolStripMenuItem事件层.Enabled = false;
            this.toolStripButton地图查看.Enabled = false;
            this.toolStripMenuItem地图查看.Enabled = false;

            FileStream fileStream = File.OpenRead(filename);
            BinaryReader reader = new BinaryReader(fileStream);

            int countOfStaticTileSetData = reader.ReadInt32();
            for (int i = 0; i < countOfStaticTileSetData; i++)
            {
                string name = reader.ReadString();
                string fileName = reader.ReadString();
                //int width = reader.ReadInt32();
                //int height = reader.ReadInt32();


                StaticTileSetData staticTileSetData = new StaticTileSetData();
                staticTileSetData.Name = name;
                staticTileSetData.Filename = fileName;
                //for (int j = 0; j < width; j++)
                //{
                //    for (int k = 0; k < height; k++)
                //    {
                //        staticTileSetData.PropertyTable[j, k] = reader.ReadByte();
                //    }
                //}
                this.form元数据.ListBox静态图块集.Items.Add(staticTileSetData);
            }

            int countOfDynamicTileSetData = reader.ReadInt32();
            for (int i = 0; i < countOfDynamicTileSetData; i++)
            {
                string name = reader.ReadString();
                string fileName = reader.ReadString();

                int countOfDynamicTileData = reader.ReadInt32();


                DynamicTileSetData dynamicTileSetData = new DynamicTileSetData();
                dynamicTileSetData.Name = name;
                dynamicTileSetData.Filename = fileName;
                for (int j = 0; j < countOfDynamicTileData; j++)
                {
                    int slowRegenerationRate = reader.ReadInt32();
                    //byte property = reader.ReadByte();

                    int countOfFrame = reader.ReadInt32();

                    DynamicTileData dynamicTileData = new DynamicTileData();
                    dynamicTileData.SlowRegenerationRate = slowRegenerationRate;
                    //dynamicTileData.Property = property;
                    for (int k = 0; k < countOfFrame; k++)
                    {
                        byte frame = reader.ReadByte();
                        dynamicTileData.FrameList.Add(frame);
                    }
                    dynamicTileSetData.DynamicTileDataList.Add(dynamicTileData);
                }
                this.form元数据.ListBox动态图块集.Items.Add(dynamicTileSetData);
            }

            int countOfMusic1 = reader.ReadInt32();
            for (int i = 0; i < countOfMusic1; i++)
            {
                string name = reader.ReadString();
                this.form元数据.ListBox音乐.Items.Add(name);
            }

            int countOfMusic2 = reader.ReadInt32();
            for (int i = 0; i < countOfMusic2; i++)
            {
                string name = reader.ReadString();
                this.form元数据.ListBox音效.Items.Add(name);
            }

            int countOfEventVariable = reader.ReadInt32();
            for (int i = 0; i < countOfEventVariable; i++)
            {
                string name = reader.ReadString();
                int variableValue = reader.ReadInt32();
                EventVariable eventVariable = new EventVariable(name, variableValue);
                this.form元数据.ListBox变量.Items.Add(eventVariable);
            }

            int countOfMapData = reader.ReadInt32();
            for (int i = 0; i < countOfMapData; i++)
            {
                string name = reader.ReadString();
                //int bgmID = reader.ReadInt32();

                int width = reader.ReadInt32();
                int height = reader.ReadInt32();

                MapData mapData = new MapData(name, width, height);

                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        mapData.LogicLayer.LogicLayerTable[j, k] = reader.ReadByte();
                    }
                }

                int countOfEventRegion = reader.ReadInt32();
                for (int j = 0; j < countOfEventRegion; j++)
                {
                    string rname = reader.ReadString();
                    int left = reader.ReadInt32();
                    int top = reader.ReadInt32();
                    int rwidth = reader.ReadInt32();
                    int rheight = reader.ReadInt32();
                    Rectangle rrect = new Rectangle(left, top, rwidth, rheight);
                    EventRegion eventRegion = new EventRegion(rname, rrect);
                    mapData.LogicLayer.EventRegionList.Add(eventRegion);
                }

                int countOfVisualLayerData = reader.ReadInt32();
                for (int j = 0; j < countOfVisualLayerData; j++)
                {
                    string vname = reader.ReadString();
                    int staticBitmapID = reader.ReadInt32();
                    int dynamicBitmapID = reader.ReadInt32();
                    int vWidth = reader.ReadInt32();
                    int vHeight = reader.ReadInt32();
                    VisualLayerData visualLayerData = new VisualLayerData(vWidth, vHeight, staticBitmapID, dynamicBitmapID, vname);

                    for (int k = 0; k < vWidth; k++)
                    {
                        for (int h = 0; h < vHeight; h++)
                        {
                            visualLayerData.VisualLayerTable[k, h] = reader.ReadByte();
                            visualLayerData.VisualPropertyTable[k, h] = reader.ReadByte();
                        }
                    }
                    mapData.VisualLayerDataList.Add(visualLayerData);
                    //this.listBox可视层.Items.Add(visualLayerData);
                }

                int countOfGameUnit = reader.ReadInt32();
                for (int j = 0; j < countOfGameUnit; j++)
                {
                    string gameUnitName = reader.ReadString();
                    int gameUnitType = reader.ReadInt32();
                    GameUnit gameUnit = new GameUnit((GameUnitType)gameUnitType, gameUnitName);
                    mapData.GameUnitList.Add(gameUnit);
                }

                int countOfTrigger = reader.ReadInt32();
                for (int j = 0; j < countOfTrigger; j++)
                {
                    string triggerName = reader.ReadString();
                    Trigger trigger = new Trigger(triggerName);

                    trigger.GameEventType = (GameEventType)(reader.ReadInt32());

                    int countOfCondition = reader.ReadInt32();
                    for (int k = 0; k < countOfCondition; k++)
                    {
                        GameEventConditionType gameEventConditionType = (GameEventConditionType)(reader.ReadInt32());
                        GameEventCondition gameEventCondition = null;
                        switch (gameEventConditionType)
                        {
                            case GameEventConditionType.VariableCompareValue:
                                {
                                    Object[] gameEventConditionArgs = new Object[3];
                                    //string eventVariableName = reader.ReadString();
                                    //int eventVariableValue = reader.ReadInt32();
                                    //EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //gameEventConditionArgs[0] = eventVariable;
                                    gameEventConditionArgs[0] = reader.ReadInt32();
                                    gameEventConditionArgs[1] = reader.ReadInt32();
                                    gameEventConditionArgs[2] = reader.ReadInt32();

                                    gameEventCondition = new GameEventCondition(gameEventConditionType, gameEventConditionArgs);
                                }
                                break;
                            case GameEventConditionType.VariableCompareVariable:
                                {
                                    Object[] gameEventConditionArgs = new Object[3];
                                    //string eventVariableName = reader.ReadString();
                                    //int eventVariableValue = reader.ReadInt32();
                                    //EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //gameEventConditionArgs[0] = eventVariable;
                                    //eventVariableName = reader.ReadString();
                                    //eventVariableValue = reader.ReadInt32();
                                    //eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //gameEventConditionArgs[1] = eventVariable;
                                    gameEventConditionArgs[0] = reader.ReadInt32();
                                    gameEventConditionArgs[1] = reader.ReadInt32();
                                    gameEventConditionArgs[2] = reader.ReadInt32();

                                    gameEventCondition = new GameEventCondition(gameEventConditionType, gameEventConditionArgs);
                                }
                                break;
                            case GameEventConditionType.EventRegion:
                                {
                                    Object[] gameEventConditionArgs = new Object[1];
                                    //string eventRegionName = reader.ReadString();
                                    //int regionRectLeft = reader.ReadInt32();
                                    //int regionRectTop = reader.ReadInt32();
                                    //int regionRectWidth = reader.ReadInt32();
                                    //int regionRectHeight = reader.ReadInt32();
                                    //Rectangle regionRect = new Rectangle(regionRectLeft, regionRectTop, regionRectWidth, regionRectHeight);
                                    //EventRegion eventRegion = new EventRegion(eventRegionName, regionRect);
                                    //gameEventConditionArgs[0] = eventRegion;
                                    gameEventConditionArgs[0] = reader.ReadInt32();

                                    gameEventCondition = new GameEventCondition(gameEventConditionType, gameEventConditionArgs);
                                }
                                break;
                            case GameEventConditionType.GameUnit:
                                {
                                    Object[] gameEventConditionArgs = new Object[2];
                                    gameEventConditionArgs[0] = reader.ReadInt32();
                                    gameEventConditionArgs[1] = reader.ReadString();

                                    gameEventCondition = new GameEventCondition(gameEventConditionType, gameEventConditionArgs);
                                }
                                break;
                            default:
                                break;
                        }
                        trigger.GameEventConditionList.Add(gameEventCondition);
                    }

                    int countOfCommand = reader.ReadInt32();
                    for (int k = 0; k < countOfCommand; k++)
                    {
                        CommandType commandType = (CommandType)(reader.ReadInt32());
                        Command command = null;
                        switch (commandType)
                        {
                            case CommandType.ShowMessage:
                                {
                                    Object[] commandArgs = new Object[5];
                                    //bool isXVariable = reader.ReadBoolean();
                                    //commandArgs[0] = isXVariable;
                                    //if (isXVariable)
                                    //{
                                    //    string eventVariableName = reader.ReadString();
                                    //    int eventVariableValue = reader.ReadInt32();
                                    //    EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //    commandArgs[1] = eventVariable;
                                    //}
                                    //else
                                    //{
                                    //    commandArgs[1] = reader.ReadInt32();
                                    //}
                                    //bool isYVariable = reader.ReadBoolean();
                                    //commandArgs[2] = isYVariable;
                                    //if (isYVariable)
                                    //{
                                    //    string eventVariableName = reader.ReadString();
                                    //    int eventVariableValue = reader.ReadInt32();
                                    //    EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //    commandArgs[3] = eventVariable;
                                    //}
                                    //else
                                    //{
                                    //    commandArgs[3] = reader.ReadInt32();
                                    //}
                                    commandArgs[0] = reader.ReadBoolean();
                                    commandArgs[1] = reader.ReadInt32();
                                    commandArgs[2] = reader.ReadBoolean();
                                    commandArgs[3] = reader.ReadInt32();
                                    commandArgs[4] = reader.ReadString();

                                    command = new Command(commandType, commandArgs); 
                                }
                                break;
                            case CommandType.PauseGameLogic:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.ResumeGameLogic:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.PlayMidi:
                                {
                                    Object[] commandArgs = new Object[2];
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadBoolean();
                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.StopMidi:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.PlayWav:
                                {
                                    Object[] commandArgs = new Object[1];
                                    commandArgs[0] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.LoadLevel:
                                {
                                    Object[] commandArgs = new Object[1];
                                    commandArgs[0] = reader.ReadString();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.CreateGameUnit:
                                {
                                    Object[] commandArgs = new Object[6];
                                    //bool isXVariable = reader.ReadBoolean();
                                    //commandArgs[0] = isXVariable;
                                    //if (isXVariable)
                                    //{
                                    //    string eventVariableName = reader.ReadString();
                                    //    int eventVariableValue = reader.ReadInt32();
                                    //    EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //    commandArgs[1] = eventVariable;
                                    //}
                                    //else
                                    //{
                                    //    commandArgs[1] = reader.ReadInt32();
                                    //}
                                    //bool isYVariable = reader.ReadBoolean();
                                    //commandArgs[2] = isYVariable;
                                    //if (isYVariable)
                                    //{
                                    //    string eventVariableName = reader.ReadString();
                                    //    int eventVariableValue = reader.ReadInt32();
                                    //    EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //    commandArgs[3] = eventVariable;
                                    //}
                                    //else
                                    //{
                                    //    commandArgs[3] = reader.ReadInt32();
                                    //}
                                    commandArgs[0] = reader.ReadBoolean();
                                    commandArgs[1] = reader.ReadInt32();
                                    commandArgs[2] = reader.ReadBoolean();
                                    commandArgs[3] = reader.ReadInt32();
                                    commandArgs[4] = reader.ReadInt32();
                                    commandArgs[5] = reader.ReadString();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.RemoveGameUnit:
                                {
                                    Object[] commandArgs = new Object[2];
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadString();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.KillGameUnit:
                                {
                                    Object[] commandArgs = new Object[2];
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadString();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.SetPlayerInputOn:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.SetPlayerInputOff:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.SetVariable:
                                {
                                    Object[] commandArgs = new Object[3];
                                    //string eventVariableName = reader.ReadString();
                                    //int eventVariableValue = reader.ReadInt32();
                                    //EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //commandArgs[0] = eventVariable;
                                    //bool isOperateVariable = reader.ReadBoolean();
                                    //commandArgs[1] = isOperateVariable;
                                    //if (isOperateVariable)
                                    //{
                                    //    eventVariableName = reader.ReadString();
                                    //    eventVariableValue = reader.ReadInt32();
                                    //    eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //    commandArgs[2] = eventVariable;
                                    //}
                                    //else
                                    //{
                                    //    commandArgs[2] = reader.ReadInt32();
                                    //}
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadBoolean();
                                    commandArgs[2] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.VariableSelfPlus:
                                {
                                    Object[] commandArgs = new Object[2];
                                    //string eventVariableName = reader.ReadString();
                                    //int eventVariableValue = reader.ReadInt32();
                                    //EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //commandArgs[0] = eventVariable;
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.VariableSelfSubtract:
                                {
                                    Object[] commandArgs = new Object[2];
                                    //string eventVariableName = reader.ReadString();
                                    //int eventVariableValue = reader.ReadInt32();
                                    //EventVariable eventVariable = new EventVariable(eventVariableName, eventVariableValue);
                                    //commandArgs[0] = eventVariable;
                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.ShowVisualLayer:
                                {
                                    Object[] commandArgs = new Object[1];
                                    //string visualLayerName = reader.ReadString();
                                    //commandArgs[0] = mapData.SearchVisualLayerData(visualLayerName);
                                    commandArgs[0] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.HideVisualLayer:
                                {
                                    Object[] commandArgs = new Object[1];
                                    //string visualLayerName = reader.ReadString();
                                    //commandArgs[0] = mapData.SearchVisualLayerData(visualLayerName);
                                    commandArgs[0] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.PlayRoleAnimation:
                                {
                                    Object[] commandArgs = new Object[12];
                                    commandArgs[0] = reader.ReadString();
                                    commandArgs[1] = reader.ReadString();
                                    commandArgs[2] = reader.ReadInt32();
                                    commandArgs[3] = reader.ReadInt32();
                                    commandArgs[4] = reader.ReadInt32();
                                    commandArgs[5] = reader.ReadInt32();
                                    commandArgs[6] = reader.ReadBoolean();

                                    commandArgs[7] = reader.ReadInt32();
                                    commandArgs[8] = reader.ReadInt32();
                                    commandArgs[9] = reader.ReadInt32();
                                    commandArgs[10] = reader.ReadInt32();
                                    commandArgs[11] = reader.ReadBoolean();


                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.Wait:
                                {
                                    Object[] commandArgs = new Object[1];
                                    commandArgs[0] = reader.ReadInt32();
                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.FixCamera:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.MoveCameraPosition:
                                {
                                    Object[] commandArgs = new Object[5];

                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadInt32();
                                    commandArgs[2] = reader.ReadInt32();
                                    commandArgs[3] = reader.ReadInt32();
                                    commandArgs[4] = reader.ReadBoolean();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.SetCameraPosition:
                                {
                                    Object[] commandArgs = new Object[2];

                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadInt32();


                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.EnableBackgroundColor:
                                {
                                    command = new Command(commandType, null);

                                }
                                break;
                            case CommandType.DisableBackgroundColor:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.SetBackgroundColor:
                                {
                                    Object[] commandArgs = new Object[1];

                                    commandArgs[0] = reader.ReadInt32();


                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.SetGameUnitLayerNumber:
                                {
                                    Object[] commandArgs = new Object[1];

                                    commandArgs[0] = reader.ReadInt32();


                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.SetPlayerPosition:
                                {
                                    Object[] commandArgs = new Object[2];

                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.SavePlayerStatus:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.RecoverPlayerStatus:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.CurtainRise:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.CurtainDrop:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.SetTriggerSwitch:
                                {
                                    Object[] commandArgs = new Object[2];

                                    commandArgs[0] = reader.ReadInt32();
                                    commandArgs[1] = reader.ReadBoolean();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.LoadResource:
                                {
                                    Object[] commandArgs = new Object[1];

                                    commandArgs[0] = reader.ReadString();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.CalculateScore:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.ShowCredit:
                                {
                                    command = new Command(commandType, null);
                                }
                                break;
                            case CommandType.Shake:
                                {
                                    Object[] commandArgs = new Object[1];

                                    commandArgs[0] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            case CommandType.Charge:
                                {
                                    Object[] commandArgs = new Object[3];

                                    commandArgs[0] = reader.ReadString();
                                    commandArgs[1] = reader.ReadString();
                                    commandArgs[2] = reader.ReadInt32();

                                    command = new Command(commandType, commandArgs);
                                }
                                break;
                            default:
                                break;
                        }
                        trigger.GameEventAction.CommandList.Add(command);
                    }
                    mapData.TriggerList.Add(trigger);
                }
                
                int colorArgb = reader.ReadInt32();
                mapData.BackColor = Color.FromArgb(colorArgb);
                mapData.IsFillBackColor = reader.ReadBoolean();

                this.listBox关卡.Items.Add(mapData);
            }
            reader.Close();

        }

        private void toolStripMenuItem保存_Click(object sender, EventArgs e)
        {
            this.saveFileDialog保存工程.InitialDirectory = Application.StartupPath;
            if (this.saveFileDialog保存工程.ShowDialog() == DialogResult.OK)
            {
                this.SaveStageFile(this.saveFileDialog保存工程.FileName);
            }
        }

        private void toolStripMenuItem打开_Click(object sender, EventArgs e)
        {
            this.openFileDialog打开工程.InitialDirectory = Application.StartupPath;
            this.toolStripStatusLabel选择信息.Text = string.Empty;
            if (this.openFileDialog打开工程.ShowDialog() == DialogResult.OK)
            {
                this.LoadStageFile(this.openFileDialog打开工程.FileName);
            }
        }

        private void toolStripButton水平翻转_Click(object sender, EventArgs e)
        {
            this.FlipHorizontal();
            this.pictureBox地图.Invalidate();
        }

        private void toolStripButton垂直翻转_Click(object sender, EventArgs e)
        {
            this.FlipVertical();
            this.pictureBox地图.Invalidate();
        }

        private void toolStripButton框选_Click(object sender, EventArgs e)
        {
            this.ChangeToSelectMode();

        }

        private void toolStripButton画笔_Click(object sender, EventArgs e)
        {
            this.ChangeToDrawMode();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CreateDevice();
            this.CreateSurface();
        }

        private void toolStripButton复制_Click(object sender, EventArgs e)
        {
            this.CopyClipData();
        }

        private void toolStripButton粘贴_Click(object sender, EventArgs e)
        {
            this.PasteClipData();
            //this.pictureBox地图.Invalidate();
        }

        private void toolStripButton删除_Click(object sender, EventArgs e)
        {
            this.DelClipData();
            //this.pictureBox地图.Invalidate();
        }

        //private void toolStripButton第一层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToFirstLayer();
        //}

        //private void toolStripButton第二层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToSecondLayer();
        //}

        //private void toolStripButton第三层_Click(object sender, EventArgs e)
        //{
        //    this.ChangeToThirdLayer();
        //}

        private void toolStripButton地图查看_Click(object sender, EventArgs e)
        {
            Form地图 form = new Form地图(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.ScreenWidth = (int)form.NumericUpDown宽度.Value;
                this.ScreenHeight = (int)form.NumericUpDown高度.Value;
            }
            form.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.toolStripButton动态播放.Checked)
            {
                this.timerCount++;
            }
            if (this.editMode == EditMode.RegionSelect && this.regionSelectID != -1)
            {
                if (++this.regionDisplayTimerCount == 5)
                {
                    this.regionDisplayMode = !this.regionDisplayMode;
                    this.regionDisplayTimerCount = 0;
                }
            }

            this.pictureBox地图.Invalidate();
            //System.Console.WriteLine(this.timerCount);
        }

        private byte playDynamicTile(DynamicTileData dynamicTileData)
        {
            int k = (this.timerCount / dynamicTileData.SlowRegenerationRate) % dynamicTileData.FrameList.Count;
            return dynamicTileData.FrameList[k];
        }

        private void toolStripButton动态播放_Click(object sender, EventArgs e)
        {
            //this.timer1.Enabled = !this.timer1.Enabled;
            this.toolStripButton动态播放.Checked = !this.toolStripButton动态播放.Checked;
            this.toolStripMenuItem动态播放.Checked = this.toolStripButton动态播放.Checked;
        }


        private void toolStripButton逻辑属性_Click(object sender, EventArgs e)
        {
            this.ChangeToLogicPropertyMode();
        }

        private void toolStripButton区域选择_Click(object sender, EventArgs e)
        {
            this.ChangeToRegionSelectMode();
        }

        private void toolStripButton填充_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            this.toolStripButton填充.Checked = !this.toolStripButton填充.Checked;
            this.toolStripMenuItem填充.Checked = this.toolStripButton填充.Checked;
            mapData.IsFillBackColor = this.toolStripButton填充.Checked;
            this.pictureBox地图.Invalidate();

        }

        private void toolStripButton颜色_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (this.colorDialog填充颜色.ShowDialog() == DialogResult.OK)
            {
                mapData.BackColor = this.colorDialog填充颜色.Color;
            }
            this.pictureBox地图.Invalidate();
        }

        //private void MainForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.C && this.toolStripButton复制.Enabled)
        //    {
        //        this.CopyClipData();
        //    }
        //    if (e.Control && e.KeyCode == Keys.V && this.toolStripButton粘贴.Enabled)
        //    {
        //        this.PasteClipData();
        //    }
        //    if (e.Control && e.KeyCode == Keys.D && this.toolStripButton删除.Enabled)
        //    {
        //        this.DelClipData();
        //    }
        //    if (e.Control && e.KeyCode == Keys.D1 && this.toolStripButton水平翻转.Enabled)
        //    {
        //        this.FlipHorizontal();
        //    }
        //    if (e.Control && e.KeyCode == Keys.D2 && this.toolStripButton垂直翻转.Enabled)
        //    {
        //        this.FlipVertical();
        //    }
        //    if (e.KeyCode == Keys.F5)
        //    {
        //        this.ChangeToFirstLayer();
        //    }
        //    if (e.KeyCode == Keys.F6)
        //    {
        //        this.ChangeToSecondLayer();
        //    }
        //    if (e.KeyCode == Keys.F7)
        //    {
        //        this.ChangeToThirdLayer();
        //    }
        //    if (e.Control && e.KeyCode == Keys.Q && this.toolStripButton画笔.Enabled)
        //    {
        //        this.ChangeToDrawMode();
        //    }
        //    if (e.Control && e.KeyCode == Keys.W && this.toolStripButton框选.Enabled)
        //    {
        //        this.ChangeToSelectMode();
        //    }
        //    if (e.Control && e.KeyCode == Keys.E && this.toolStripButton逻辑属性.Enabled)
        //    {
        //        this.ChangeToLogicPropertyMode();
        //    }
        //    if (e.Control && e.KeyCode == Keys.R && this.toolStripButton区域选择.Enabled)
        //    {
        //        this.ChangeToRegionSelectMode();
        //    }
        //}

        private void toolStripMenuItem画笔_Click(object sender, EventArgs e)
        {
            this.ChangeToDrawMode();
        }

        private void toolStripMenuItem框选_Click(object sender, EventArgs e)
        {
            this.ChangeToSelectMode();
        }

        private void toolStripMenuItem逻辑属性_Click(object sender, EventArgs e)
        {
            this.ChangeToLogicPropertyMode();
        }

        private void toolStripMenuItem区域选择_Click(object sender, EventArgs e)
        {
            this.ChangeToRegionSelectMode();
        }

        private void toolStripMenuItem水平翻转_Click(object sender, EventArgs e)
        {
            this.FlipHorizontal();
        }

        private void toolStripMenuItem垂直翻转_Click(object sender, EventArgs e)
        {
            this.FlipVertical();
        }

        private void toolStripMenuItem复制_Click(object sender, EventArgs e)
        {
            this.CopyClipData();
        }

        private void toolStripMenuItem粘贴_Click(object sender, EventArgs e)
        {
            this.PasteClipData();
        }

        private void toolStripMenuItem擦除_Click(object sender, EventArgs e)
        {
            this.DelClipData();
        }

        private void toolStripMenuItem缩放二分之一_Click(object sender, EventArgs e)
        {
            this.ZoomToHalf();
        }

        private void toolStripMenuItem缩放一分之一_Click(object sender, EventArgs e)
        {
            this.ZoomToOneTimes();
        }

        private void toolStripMenuItem缩放两倍_Click(object sender, EventArgs e)
        {
            this.ZoomToTwoTimes();
        }

        private void toolStripMenuItem缩放四倍_Click(object sender, EventArgs e)
        {
            this.ZoomToFourTimes();
        }

        private void toolStripMenuItem数据库_Click(object sender, EventArgs e)
        {
            this.form元数据.ShowDialog();
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
        }

        private void toolStripMenuItem屏幕栅格_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItem屏幕栅格.Checked = !this.toolStripMenuItem屏幕栅格.Checked;
            this.toolStripButton屏幕栅格.Checked = this.toolStripMenuItem屏幕栅格.Checked;
        }

        private void toolStripMenuItem_Click背景颜色(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            if (this.colorDialog填充颜色.ShowDialog() == DialogResult.OK)
            {
                mapData.BackColor = this.colorDialog填充颜色.Color;
            }
        }

        private void toolStripMenuItem_Click填充(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            this.toolStripButton填充.Checked = !this.toolStripButton填充.Checked;
            this.toolStripMenuItem填充.Checked = this.toolStripButton填充.Checked;
            mapData.IsFillBackColor = this.toolStripButton填充.Checked;
        }

        private void toolStripButton屏幕栅格_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItem屏幕栅格.Checked = !this.toolStripMenuItem屏幕栅格.Checked;
            this.toolStripButton屏幕栅格.Checked = this.toolStripMenuItem屏幕栅格.Checked;
        }

        private void toolStripMenuItem地图查看_Click(object sender, EventArgs e)
        {
            Form地图 form = new Form地图(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.ScreenWidth = (int)form.NumericUpDown宽度.Value;
                this.ScreenHeight = (int)form.NumericUpDown高度.Value;
            }
            form.Dispose();
        }

        private void toolStripMenuItem动态播放_Click(object sender, EventArgs e)
        {
            this.toolStripButton动态播放.Checked = !this.toolStripButton动态播放.Checked;
            this.toolStripMenuItem动态播放.Checked = this.toolStripButton动态播放.Checked;
        }

        private void toolStripMenuItem删除区域_Click(object sender, EventArgs e)
        {
            //MapData mapData = this.listBox关卡.SelectedItem as MapData;
            //mapData.EventRegionList.RemoveAt(this.regionSelectID);
            if (MessageBox.Show("删除区域可能导致触发器出错", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.regionSelectID = -1;
                this.regionEditMode = RegionEditMode.Del;
            }
        }

        private void toolStripMenuItem移动矩形_Click(object sender, EventArgs e)
        {
            this.regionSelectID = -1;
            this.regionEditMode = RegionEditMode.Move;
        }

        private void toolStripMenuItem拉伸矩形_Click(object sender, EventArgs e)
        {
            this.regionSelectID = -1;
            this.regionEditMode = RegionEditMode.Stretch;
        }

        private void toolStripMenuItem新建区域_Click(object sender, EventArgs e)
        {
            this.regionSelectID = -1;
            this.regionEditMode = RegionEditMode.Bulid;
        }

        private void toolStripMenuItem新建_Click(object sender, EventArgs e)
        {
            this.RecycleData();
            this.toolStripButton地图查看.Enabled = false;
            this.toolStripMenuItem地图查看.Enabled = false;

            this.DisableEdit();
            this.DisableBackGroundColor();
        }

        private void toolStripMenuItem退出_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出?", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void toolStripMenuItem更改名称_Click(object sender, EventArgs e)
        {
            this.regionSelectID = -1;
            this.regionEditMode = RegionEditMode.Rename;
        }

        private void toolStripButton逻辑层_Click(object sender, EventArgs e)
        {
            this.toolStripButton逻辑层.Checked = !this.toolStripButton逻辑层.Checked;
            this.toolStripMenuItem逻辑层.Checked = this.toolStripButton逻辑层.Checked;
            if (this.toolStripButton逻辑层.Checked)
            {
                this.OpenLogicLayer();
            }
            else
            {
                this.CloseLogicLayer();
            }
        }

        private void toolStripMenuItem逻辑层_Click(object sender, EventArgs e)
        {
            this.toolStripButton逻辑层.Checked = !this.toolStripButton逻辑层.Checked;
            this.toolStripMenuItem逻辑层.Checked = this.toolStripButton逻辑层.Checked;
            if (this.toolStripButton逻辑层.Checked)
            {
                this.OpenLogicLayer();
            }
            else
            {
                this.CloseLogicLayer();
            }
        }

        private void toolStripMenuItem添加可视层_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            Form新建层 form = new Form新建层(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                VisualLayerData visualLayerData = new VisualLayerData(form.HorizontalTileCount, form.VerticalTileCount, form.StaticBitmapID, form.DynamicBitmapID, form.LayerName);
                this.listBox可视层.Items.Add(visualLayerData);
                mapData.VisualLayerDataList.Add(visualLayerData);
            }
            form.Dispose();
        }

        private void toolStripMenuItem编辑可视层_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            VisualLayerData visualLayerData = this.listBox可视层.SelectedItem as VisualLayerData;
            Form设置层 form = new Form设置层(this);
            form.LayerName = visualLayerData.Name;
            form.HorizontalTileCount = visualLayerData.HorizontalTileCount;
            form.VerticalTileCount = visualLayerData.VerticalTileCount;
            form.StaticBitmapID = visualLayerData.StaticBitmapID;
            form.DynamicBitmapID = visualLayerData.DynamicBitmapID;

            if (form.ShowDialog() == DialogResult.OK)
            {
                visualLayerData.Name = form.LayerName;
                visualLayerData.StaticBitmapID = form.StaticBitmapID;
                visualLayerData.DynamicBitmapID = form.DynamicBitmapID;
                mapData.ClipVisualLayer(form.ClipMode, form.HorizontalTileCount, form.VerticalTileCount, this.listBox可视层.SelectedIndex);
                visualLayerData.HorizontalTileCount = form.HorizontalTileCount;
                visualLayerData.VerticalTileCount = form.VerticalTileCount;
            }

            form.Dispose();
            this.listBox可视层.Invalidate();
            this.ResizePictureBox静态图();
            this.ResizePictureBox动态图();
            this.RepaintAllPictureBox();
            //this.ResizeScrollBar();
        }

        private void toolStripMenuItem删除可视层_Click(object sender, EventArgs e)
        {
            MapData mapData = this.ListBox关卡.SelectedItem as MapData;
            VisualLayerData visualLayerData = this.listBox可视层.SelectedItem as VisualLayerData;
            if (MessageBox.Show("删除可视层可能导致触发器出错", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.listBox可视层.Items.Remove(visualLayerData);
                mapData.VisualLayerDataList.Remove(visualLayerData);
                mapData.FixVisualLayerData(this.listBox可视层.SelectedIndex, -1);

                this.listBox可视层.SelectedIndex = -1;
            }
        }

        private void listBox可视层_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip可视层.Show(this.listBox可视层.PointToScreen(e.Location));

                if (this.listBox关卡.SelectedIndex == -1)
                {
                    this.toolStripMenuItem添加可视层.Enabled = false;
                }

                else
                {
                    this.toolStripMenuItem添加可视层.Enabled = true;
                }
            }
        }

        private void listBox可视层_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualLayerData visualLayerData = this.listBox可视层.SelectedItem as VisualLayerData;
            this.SetCurrentOperationLayer(visualLayerData);
            this.DisableEdit();
            this.toolStripStatusLabel选择信息.Text = string.Empty;
            if (this.listBox可视层.SelectedIndex == -1)
            {
                this.toolStripMenuItem编辑可视层.Enabled = false;
                this.toolStripMenuItem删除可视层.Enabled = false;
                this.toolStripMenuItem上移可视层.Enabled = false;
                this.toolStripMenuItem下移可视层.Enabled = false;
                this.toolStripMenuItem显示.Enabled = false;
                this.toolStripMenuItem显示.Checked = false;
            }
            else
            {

                if (this.listBox可视层.SelectedIndex == 0)
                {
                    this.toolStripMenuItem上移可视层.Enabled = false;
                    this.toolStripButton上一层.Enabled = false;
                    this.toolStripMenuItem上一层.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem上移可视层.Enabled = true;
                    this.toolStripButton上一层.Enabled = true;
                    this.toolStripMenuItem上一层.Enabled = true;
                }
                if (this.listBox可视层.SelectedIndex == this.listBox可视层.Items.Count - 1)
                {
                    this.toolStripMenuItem下移可视层.Enabled = false;
                    this.toolStripButton下一层.Enabled = false;
                    this.toolStripMenuItem下一层.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem下移可视层.Enabled = true;
                    this.toolStripButton下一层.Enabled = true;
                    this.toolStripMenuItem下一层.Enabled = true;
                }
                this.toolStripMenuItem显示.Enabled = true;
                visualLayerData = this.ListBox可见层.SelectedItem as VisualLayerData;
                this.toolStripMenuItem显示.Checked = visualLayerData.Visible;
                this.toolStripMenuItem编辑可视层.Enabled = true;
                this.toolStripMenuItem删除可视层.Enabled = true;
            }

        }

        private void toolStripMenuItem上移可视层_Click(object sender, EventArgs e)
        {
            VisualLayerData visualLayerData1 = this.listBox可视层.SelectedItem as VisualLayerData;
            VisualLayerData visualLayerData2 = this.listBox可视层.Items[this.listBox可视层.SelectedIndex - 1] as VisualLayerData;

            this.listBox可视层.Items[this.listBox可视层.SelectedIndex] = visualLayerData2;
            this.listBox可视层.Items[this.listBox可视层.SelectedIndex - 1] = visualLayerData1;

            MapData mapData = this.ListBox关卡.SelectedItem as MapData;
            mapData.VisualLayerDataList.Insert(this.listBox可视层.SelectedIndex - 1, visualLayerData1);
            mapData.VisualLayerDataList.RemoveAt(this.listBox可视层.SelectedIndex + 1);

            mapData.FixVisualLayerData(this.listBox可视层.SelectedIndex, this.listBox可视层.SelectedIndex - 1);
            this.listBox可视层.SelectedIndex--;
        }

        private void toolStripMenuItem下移可视层_Click(object sender, EventArgs e)
        {
            VisualLayerData visualLayerData1 = this.listBox可视层.SelectedItem as VisualLayerData;
            VisualLayerData visualLayerData2 = this.listBox可视层.Items[this.listBox可视层.SelectedIndex + 1] as VisualLayerData;

            this.listBox可视层.Items[this.listBox可视层.SelectedIndex] = visualLayerData2;
            this.listBox可视层.Items[this.listBox可视层.SelectedIndex + 1] = visualLayerData1;

            MapData mapData = this.ListBox关卡.SelectedItem as MapData;
            mapData.VisualLayerDataList.Insert(this.listBox可视层.SelectedIndex, visualLayerData2);
            mapData.VisualLayerDataList.RemoveAt(this.listBox可视层.SelectedIndex + 2);


            mapData.FixVisualLayerData(this.listBox可视层.SelectedIndex, this.listBox可视层.SelectedIndex + 1);
            this.listBox可视层.SelectedIndex++;
        }

        private void toolStripButton上一层_Click(object sender, EventArgs e)
        {
            this.ChangeToPreviousLayerLayer();
        }

        private void toolStripButton下一层_Click(object sender, EventArgs e)
        {
            this.ChangeToNextLayer();
        }

        private void toolStripMenuItem上一层_Click(object sender, EventArgs e)
        {
            this.ChangeToPreviousLayerLayer();
        }

        private void toolStripMenuItem下一层_Click(object sender, EventArgs e)
        {
            this.ChangeToNextLayer();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && this.isRegionSelected && (this.regionEditMode == RegionEditMode.Move || this.regionEditMode == RegionEditMode.Stretch))
            {
                MapData mapData = this.listBox关卡.SelectedItem as MapData;
                mapData.LogicLayer.EventRegionList[this.regionSelectID].RegionRect = this.regionOrgRect;
                this.regionSelectID = -1;
                this.isRegionSelected = false;
            }
        }

        private void listBox可视层_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            VisualLayerData visualLayerData = this.listBox可视层.Items[e.Index] as VisualLayerData;
            graphics.DrawString(visualLayerData.Name, e.Font, Brushes.Black, e.Bounds);

        }

        private void toolStripMenuItem显示_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItem显示.Checked = !this.toolStripMenuItem显示.Checked;
            VisualLayerData visualLayerData = this.ListBox可见层.SelectedItem as VisualLayerData;
            visualLayerData.Visible = this.toolStripMenuItem显示.Checked;
        }

        private void toolStripButton事件层_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            List<Trigger> triggerList = mapData.TriggerList;
            this.form配置触发器.ListBox触发器.Items.Clear();
            foreach (Trigger trigger in triggerList)
            {
                this.form配置触发器.ListBox触发器.Items.Add(trigger);
            }
            this.form配置触发器.DisableEdit();
            this.form配置触发器.ClearListBox();
            this.form配置触发器.ShowDialog();
            
        }

        private void toolStripMenuItem事件层_Click(object sender, EventArgs e)
        {
            MapData mapData = this.listBox关卡.SelectedItem as MapData;
            List<Trigger> triggerList = mapData.TriggerList;
            this.form配置触发器.ListBox触发器.Items.Clear();
            foreach (Trigger trigger in triggerList)
            {
                this.form配置触发器.ListBox触发器.Items.Add(trigger);
            }
            this.form配置触发器.DisableEdit();
            this.form配置触发器.ClearListBox();
            this.form配置触发器.ShowDialog();
        }

        private void ExportDataBase(string filename)
        {
            FileStream fileStream = File.OpenWrite(filename);
            BinaryWriter writer = new BinaryWriter(fileStream);

            //静态图块
            JavaWriteHelper.Write(writer, this.form元数据.ListBox静态图块集.Items.Count);
            foreach (StaticTileSetData staticTileSetData in this.form元数据.ListBox静态图块集.Items)
            {
                JavaWriteHelper.Write(writer, staticTileSetData.Filename);
            }
            //动态图块
            JavaWriteHelper.Write(writer, this.form元数据.ListBox动态图块集.Items.Count);
            foreach (DynamicTileSetData dynamicTileSetData in this.form元数据.ListBox动态图块集.Items)
            {
                JavaWriteHelper.Write(writer, dynamicTileSetData.Filename);

                JavaWriteHelper.Write(writer, dynamicTileSetData.DynamicTileDataList.Count);
                foreach (DynamicTileData dynamicTileData in dynamicTileSetData.DynamicTileDataList)
                {
                    JavaWriteHelper.Write(writer, dynamicTileData.SlowRegenerationRate);

                    JavaWriteHelper.Write(writer, dynamicTileData.FrameList.Count);
                    foreach (byte frame in dynamicTileData.FrameList)
                    {
                        JavaWriteHelper.Write(writer, frame);
                    }
                }
            }
            //音乐
            JavaWriteHelper.Write(writer, this.form元数据.ListBox音乐.Items.Count);
            foreach (string name in this.form元数据.ListBox音乐.Items)
            {
                JavaWriteHelper.Write(writer, name);
            }

            JavaWriteHelper.Write(writer, this.form元数据.ListBox音效.Items.Count);
            foreach (string name in this.form元数据.ListBox音效.Items)
            {
                JavaWriteHelper.Write(writer, name);
            }
            //变量
            JavaWriteHelper.Write(writer, this.form元数据.ListBox变量.Items.Count);
            foreach (EventVariable eventVariable in this.form元数据.ListBox变量.Items)
            {
                JavaWriteHelper.Write(writer, eventVariable.VariableValue);
            }
            writer.Close();
        }

        private void ExportMapData(string filename, MapData mapData)
        {
            FileStream fileStream = File.OpenWrite(filename);
            BinaryWriter writer = new BinaryWriter(fileStream);
            //逻辑层
            JavaWriteHelper.Write(writer, mapData.LogicLayer.HorizontalTileCount);
            JavaWriteHelper.Write(writer, mapData.LogicLayer.VerticalTileCount);
            for (int i = 0; i < mapData.LogicLayer.HorizontalTileCount; i++)
            {
                for (int j = 0; j < mapData.LogicLayer.VerticalTileCount; j++)
                {
                    JavaWriteHelper.Write(writer, mapData.LogicLayer.LogicLayerTable[i, j]);
                }
            }
            JavaWriteHelper.Write(writer, mapData.LogicLayer.EventRegionList.Count);
            foreach (EventRegion eventRegion in mapData.LogicLayer.EventRegionList)
            {
                JavaWriteHelper.Write(writer, eventRegion.RegionRect.Left);
                JavaWriteHelper.Write(writer, eventRegion.RegionRect.Top);
                JavaWriteHelper.Write(writer, eventRegion.RegionRect.Width);
                JavaWriteHelper.Write(writer, eventRegion.RegionRect.Height);
            }
            //可见层
            JavaWriteHelper.Write(writer, mapData.VisualLayerDataList.Count);
            foreach (VisualLayerData visualLayerData in mapData.VisualLayerDataList)
            {
                JavaWriteHelper.Write(writer, visualLayerData.StaticBitmapID);
                JavaWriteHelper.Write(writer, visualLayerData.DynamicBitmapID);
                JavaWriteHelper.Write(writer, visualLayerData.HorizontalTileCount);
                JavaWriteHelper.Write(writer, visualLayerData.VerticalTileCount);
                for (int i = 0; i < visualLayerData.HorizontalTileCount; i++)
                {
                    for (int j = 0; j < visualLayerData.VerticalTileCount; j++)
                    {
                        JavaWriteHelper.Write(writer, visualLayerData.VisualLayerTable[i, j]);
                        JavaWriteHelper.Write(writer, visualLayerData.VisualPropertyTable[i, j]);
                    }
                }
            }
            //游戏单位
            JavaWriteHelper.Write(writer, mapData.GameUnitList.Count);
            foreach (GameUnit gameUnit in mapData.GameUnitList)
            {
                JavaWriteHelper.Write(writer, gameUnit.GameUnitName);
                JavaWriteHelper.Write(writer, (int)(gameUnit.GameUnitType));
            }
            //触发器
            JavaWriteHelper.Write(writer, mapData.TriggerList.Count);
            foreach (Trigger trigger in mapData.TriggerList)
            {
                //事件类型
                JavaWriteHelper.Write(writer, (int)(trigger.GameEventType));
                //条件
                JavaWriteHelper.Write(writer, trigger.GameEventConditionList.Count);
                foreach (GameEventCondition gameEventCondition in trigger.GameEventConditionList)
                {
                    JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionType));
                    switch (gameEventCondition.GameEventConditionType)
                    {
                        case GameEventConditionType.VariableCompareValue:
                            {
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[2]));
                            }
                            break;
                        case GameEventConditionType.VariableCompareVariable:
                            {
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[2]));
                            }
                            break;
                        case GameEventConditionType.EventRegion:
                            {
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[0]));
                            }
                            break;
                        case GameEventConditionType.GameUnit:
                            {
                                JavaWriteHelper.Write(writer, (int)(gameEventCondition.GameEventConditionArgs[0]));
                                JavaWriteHelper.Write(writer, (string)(gameEventCondition.GameEventConditionArgs[1]));
                            }
                            break;
                        default:
                            break;
                    }
                }
                //动作
                JavaWriteHelper.Write(writer, trigger.GameEventAction.CommandList.Count);
                for(int i=0;i<trigger.GameEventAction.CommandList.Count;i++)
                {
                    Command command = trigger.GameEventAction.CommandList[i];
                    JavaWriteHelper.Write(writer, (int)(command.TypeID));
                    switch (command.TypeID)
                    {
                        case CommandType.ShowMessage:
                            {
                                //JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[0]));
                                //JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                                //JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[2]));
                                //JavaWriteHelper.Write(writer, (int)(command.CommandArgs[3]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[4]));
                            }
                            break;
                        case CommandType.PauseGameLogic:
                            break;
                        case CommandType.ResumeGameLogic:
                            break;
                        case CommandType.PlayMidi:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.StopMidi:
                            break;
                        case CommandType.PlayWav:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.LoadLevel:
                            {
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.CreateGameUnit:
                            {
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[2]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[3]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[4]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[5]));
                            }
                            break;
                        case CommandType.RemoveGameUnit:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.KillGameUnit:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.SetPlayerInputOn:
                            break;
                        case CommandType.SetPlayerInputOff:
                            break;
                        case CommandType.SetVariable:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[2]));
                            }
                            break;
                        case CommandType.VariableSelfPlus:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.VariableSelfSubtract:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.ShowVisualLayer:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.HideVisualLayer:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.PlayRoleAnimation:
                            {
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[2]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[3]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[4]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[5]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[6]));

                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[7]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[8]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[9]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[10]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[11]));

                            }
                            break;
                        case CommandType.Wait:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.FixCamera:
                            break;
                        case CommandType.MoveCameraPosition:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[2]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[3]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[4]));
                            }
                            break;
                        case CommandType.SetCameraPosition:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));

                            }
                            break;
                        case CommandType.EnableBackgroundColor:
                            {


                            }
                            break;
                        case CommandType.DisableBackgroundColor:
                            {

                            }
                            break;
                        case CommandType.SetBackgroundColor:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
 
                            }
                            break;
                        case CommandType.SetGameUnitLayerNumber:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.SetPlayerPosition:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.SavePlayerStatus:
                            {
                            }
                            break;
                        case CommandType.RecoverPlayerStatus:
                            {
                            }
                            break;
                        case CommandType.CurtainRise:
                            {
                            }
                            break;
                        case CommandType.CurtainDrop:
                            {
                            }
                            break;
                        case CommandType.SetTriggerSwitch:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (bool)(command.CommandArgs[1]));
                            }
                            break;
                        case CommandType.LoadResource:
                            {
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.CalculateScore:
                            {
                            }
                            break;
                        case CommandType.ShowCredit:
                            {
                            }
                            break;
                        case CommandType.Shake:
                            {
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[0]));
                            }
                            break;
                        case CommandType.Charge:
                            {
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[0]));
                                JavaWriteHelper.Write(writer, (string)(command.CommandArgs[1]));
                                JavaWriteHelper.Write(writer, (int)(command.CommandArgs[2]));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            writer.Close();
        }

        private void toolStripMenuItem导出数据库_Click(object sender, EventArgs e)
        {
            this.saveFileDialog导出数据库.InitialDirectory = Application.StartupPath;
            if (this.saveFileDialog导出数据库.ShowDialog() == DialogResult.OK)
            {
                this.ExportDataBase(this.saveFileDialog导出数据库.FileName);
            }
        }

        private void toolStripMenuItem导出地图_Click(object sender, EventArgs e)
        {
            this.saveFileDialog导出地图.InitialDirectory = Application.StartupPath;
            if (this.saveFileDialog导出地图.ShowDialog() == DialogResult.OK)
            {
                MapData mapData = this.listBox关卡.SelectedItem as MapData;
                this.ExportMapData(this.saveFileDialog导出地图.FileName,mapData);
            }
        }

        private void 逻辑值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form逻辑值 form逻辑值 = new Form逻辑值(this);
            if (form逻辑值.ShowDialog() == DialogResult.OK)
            {
                this.logicNum = (int)(form逻辑值.NumericUpDown逻辑值.Value);
            }
            form逻辑值.Dispose();
        }

        private void toolStripButton逻辑刷_Click(object sender, EventArgs e)
        {
            this.toolStripButton逻辑刷.Checked = !this.toolStripButton逻辑刷.Checked;
        }

        private void toolStripMenuItem导出全部地图_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog导出全部地图.SelectedPath = Application.StartupPath;
            if (this.folderBrowserDialog导出全部地图.ShowDialog() == DialogResult.OK)
            {
  
                for (int i = 0; i < this.listBox关卡.Items.Count; i++)
                {
                    
                    MapData mapData = this.listBox关卡.Items[i] as MapData;
                    this.ExportMapData(this.folderBrowserDialog导出全部地图.SelectedPath+ "\\" + (i+1) + ".emd", mapData);
                }       
                MessageBox.Show("导出完成");
            }

        }

        private void setLogicTextColor(byte logicProperty)
        {
            //KnownColor k = (KnownColor)logicProperty;
            //Color c = Color.FromKnownColor(k);
            switch (logicProperty)
            {
                case 0:
                    {
                        this.surface地图.ForeColor = Color.Black;
                    }
                    break;
                case 1:
                    {
                        this.surface地图.ForeColor = Color.Red;
                    }
                    break;
                case 2:
                    {
                        this.surface地图.ForeColor = Color.Peru;
                    }
                    break;
                case 3:
                    {
                        this.surface地图.ForeColor = Color.Yellow;
                    }
                    break;
                case 4:
                    {
                        this.surface地图.ForeColor = Color.Blue;
                    }
                    break;
                case 5:
                    {
                        this.surface地图.ForeColor = Color.RoyalBlue;
                    }
                    break;
                case 6:
                    {
                        this.surface地图.ForeColor = Color.Pink;
                    }
                    break;
                case 7:
                    {
                        this.surface地图.ForeColor = Color.Lime;
                    }
                    break;
                case 8:
                    {
                        this.surface地图.ForeColor = Color.Tomato;
                    }
                    break;
                case 9:
                    {
                        this.surface地图.ForeColor = Color.Silver;
                    }
                    break;
                case 10:
                    {
                        this.surface地图.ForeColor = Color.Gold;
                    }
                    break;
                case 11:
                    {
                        this.surface地图.ForeColor = Color.Chocolate;
                    }
                    break;
                case 12:
                    {
                        this.surface地图.ForeColor = Color.DarkMagenta;
                    }
                    break;
                case 13:
                    {
                        this.surface地图.ForeColor = Color.DeepSkyBlue;
                    }
                    break;
                case 14:
                    {
                        this.surface地图.ForeColor = Color.Ivory;
                    }
                    break;
                case 15:
                    {
                        this.surface地图.ForeColor = Color.Green;
                    }
                    break;
                case 16:
                    {
                        this.surface地图.ForeColor = Color.Lime;
                    }
                    break;
                case 17:
                    {
                        this.surface地图.ForeColor = Color.Linen;
                    }
                    break;
                case 18:
                    {
                        this.surface地图.ForeColor = Color.Maroon;
                    }
                    break;
                case 19:
                    {
                        this.surface地图.ForeColor = Color.Navy;
                    }
                    break;
                case 20:
                    {
                        this.surface地图.ForeColor = Color.Peru;
                    }
                    break;
                case 21:
                    {
                        this.surface地图.ForeColor = Color.PapayaWhip;
                    }
                    break;
                case 22:
                    {
                        this.surface地图.ForeColor = Color.PaleGreen;
                    }
                    break;
                case 23:
                    {
                        this.surface地图.ForeColor = Color.SeaShell;
                    }
                    break;
                case 24:
                    {
                        this.surface地图.ForeColor = Color.Olive;
                    }
                    break;
                case 25:
                    {
                        this.surface地图.ForeColor = Color.OldLace;
                    }
                    break;
                case 26:
                    {
                        this.surface地图.ForeColor = Color.Moccasin;
                    }
                    break;
                case 27:
                    {
                        this.surface地图.ForeColor = Color.MintCream;
                    }
                    break;
                case 28:
                    {
                        this.surface地图.ForeColor = Color.Purple;
                    }
                    break;
                case 29:
                    {
                        this.surface地图.ForeColor = Color.RosyBrown;
                    }
                    break;
                case 30:
                    {
                        this.surface地图.ForeColor = Color.SpringGreen;
                    }
                    break;
                case 31:
                    {
                        this.surface地图.ForeColor = Color.YellowGreen;
                    }
                    break;
                case 32:
                    {
                        this.surface地图.ForeColor = Color.Wheat;
                    }
                    break;
                case 33:
                    {
                        this.surface地图.ForeColor = Color.Teal;
                    }
                    break;
                case 34:
                    {
                        this.surface地图.ForeColor = Color.Sienna;
                    }
                    break;
                case 35:
                    {
                        this.surface地图.ForeColor = Color.PaleVioletRed;
                    }
                    break;
                case 36:
                    {
                        this.surface地图.ForeColor = Color.OliveDrab;
                    }
                    break;
                case 37:
                    {
                        this.surface地图.ForeColor = Color.MediumOrchid;
                    }
                    break;
                case 38:
                    {
                        this.surface地图.ForeColor = Color.MediumAquamarine;
                    }
                    break;
                case 39:
                    {
                        this.surface地图.ForeColor = Color.LemonChiffon;
                    }
                    break;
                case 40:
                    {
                        this.surface地图.ForeColor = Color.LightGoldenrodYellow;
                    }
                    break;
                case 41:
                    {
                        this.surface地图.ForeColor = Color.Honeydew;
                    }
                    break;
                case 42:
                    {
                        this.surface地图.ForeColor = Color.FloralWhite;
                    }
                    break;
                case 43:
                    {
                        this.surface地图.ForeColor = Color.MediumTurquoise;
                    }
                    break;
                case 44:
                    {
                        this.surface地图.ForeColor = Color.PeachPuff;
                    }
                    break;
                case 45:
                    {
                        this.surface地图.ForeColor = Color.LightCoral;
                    }
                    break;
                case 46:
                    {
                        this.surface地图.ForeColor = Color.Fuchsia;
                    }
                    break;
                case 47:
                    {
                        this.surface地图.ForeColor = Color.DarkKhaki;
                    }
                    break;
                case 48:
                    {
                        this.surface地图.ForeColor = Color.BurlyWood;
                    }
                    break;
                case 49:
                    {
                        this.surface地图.ForeColor = Color.Aqua;
                    }
                    break;
                case 50:
                    {
                        this.surface地图.ForeColor = Color.Beige;
                    }
                    break;
                case 51:
                    {
                        this.surface地图.ForeColor = Color.ForestGreen;
                    }
                    break;
                case 52:
                    {
                        this.surface地图.ForeColor = Color.Gainsboro;
                    }
                    break;
                case 53:
                    {
                        this.surface地图.ForeColor = Color.Orange;
                    }
                    break;
                case 54:
                    {
                        this.surface地图.ForeColor = Color.PaleGreen;
                    }
                    break;
                case 55:
                    {
                        this.surface地图.ForeColor = Color.MediumTurquoise;
                    }
                    break;
                case 56:
                    {
                        this.surface地图.ForeColor = Color.LightSlateGray;
                    }
                    break;
                case 57:
                    {
                        this.surface地图.ForeColor = Color.LawnGreen;
                    }
                    break;
                case 58:
                    {
                        this.surface地图.ForeColor = Color.IndianRed;
                    }
                    break;
                case 59:
                    {
                        this.surface地图.ForeColor = Color.GhostWhite;
                    }
                    break;
                case 60:
                    {
                        this.surface地图.ForeColor = Color.Chartreuse;
                    }
                    break;
                case 61:
                    {
                        this.surface地图.ForeColor = Color.Cornsilk;
                    }
                    break;
                case 62:
                    {
                        this.surface地图.ForeColor = Color.DimGray;
                    }
                    break;
                case 63:
                    {
                        this.surface地图.ForeColor = Color.Lavender;
                    }
                    break;
                default:
                    break;
            }
        }

        private void toolStripButton分色显示逻辑值_Click(object sender, EventArgs e)
        {
            this.toolStripButton分色显示逻辑值.Checked = !this.toolStripButton分色显示逻辑值.Checked;
            this.isLogicColorful = this.toolStripButton分色显示逻辑值.Checked;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form元数据 : Form
    {
        public Form元数据(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private int dynamicPictureX = 0;
        private int dynamicPictureY = 0;
        private int currectPlayIndex;
        private int slowIndex;

        private MainForm mainForm;

        public ListBox ListBox变量
        {
            get
            {
                return this.listBox变量;
            }
        }

        public ListBox ListBox静态图块集
        {
            get
            {
                return this.listBox静态图块集;
            }
        }

        public ListBox ListBox动态图块集
        {
            get
            {
                return this.listBox动态图块集;
            }
        }

        public ListBox ListBox动态图块
        {
            get
            {
                return this.listBox动态图块;
            }
        }

        public ListBox ListBox动态图块帧
        {
            get
            {
                return this.listBox动态图块帧;
            }
        }

        public ListBox ListBox音乐
        {
            get
            {
                return this.listBox音乐;
            }
        }

        public ListBox ListBox音效
        {
            get
            {
                return this.listBox音效;
            }
        }

        public bool CheckFilePathValid(string filename)
        {

            return filename.Contains(Application.StartupPath);
        }

        public void CopyListBoxToDynamicTileDataList(DynamicTileSetData dynamicTileSetData)
        {
            dynamicTileSetData.DynamicTileDataList.Clear();
            for (int i = 0; i < this.listBox动态图块.Items.Count; i++)
            {
                dynamicTileSetData.DynamicTileDataList.Add(this.listBox动态图块.Items[i] as DynamicTileData);
            }
        }

        public void CopyListBoxToFrameList(DynamicTileData dynamicTileData)
        {
            dynamicTileData.FrameList.Clear();
            for (int i = 0; i < this.listBox动态图块帧.Items.Count; i++)
            {
                dynamicTileData.FrameList.Add((Byte)this.listBox动态图块帧.Items[i]);
            }

        }


        private void button静态图块文件名_Click(object sender, EventArgs e)
        {
            this.openFileDialog静态图块文件名.InitialDirectory = Application.StartupPath;
            if (this.openFileDialog静态图块文件名.ShowDialog() == DialogResult.OK)
            {
                if (CheckFilePathValid(this.openFileDialog静态图块文件名.FileName))
                {
                    this.textBox静态图块文件名.Text = this.openFileDialog静态图块文件名.FileName.Replace(Application.StartupPath, string.Empty).Replace("\\", "/");
                    StaticTileSetData staticTileSetData = this.listBox静态图块集.SelectedItem as StaticTileSetData;
                    staticTileSetData.Filename = this.textBox静态图块文件名.Text;
                    this.pictureBox静态图块.ClientSize = new Size(staticTileSetData.Bitmap.Size.Width * 2, staticTileSetData.Bitmap.Size.Height * 2);
                    this.pictureBox静态图块.Invalidate();

                }
                else
                {
                    MessageBox.Show("必须打开当前应用程序目录下的文件");

                }
            }
        }

        private void button静态图块添加_Click(object sender, EventArgs e)
        {
            StaticTileSetData staticTileSetData = new StaticTileSetData();
            this.listBox静态图块集.Items.Add(staticTileSetData);
        }

        private void listBox静态图块集_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox静态图块集.SelectedIndex >= 0)
            {
                this.button静态图块文件名.Enabled = true;
                StaticTileSetData staticTileSetData = this.listBox静态图块集.SelectedItem as StaticTileSetData;
                this.textBox静态图块名称.Text = staticTileSetData.Name;
                this.textBox静态图块文件名.Text = staticTileSetData.Filename;

                this.button静态图块删除.Enabled = true;
                if (this.listBox静态图块集.SelectedIndex > 0)
                {
                    this.button静态图块上移.Enabled = true;
                }
                else
                {
                    this.button静态图块上移.Enabled = false;
                }
                if (this.listBox静态图块集.SelectedIndex < this.listBox静态图块集.Items.Count - 1)
                {
                    this.button静态图块下移.Enabled = true;
                }
                else
                {
                    this.button静态图块下移.Enabled = false;
                }


                this.textBox静态图块名称.Enabled = true;

                if (staticTileSetData.Bitmap != null)
                {
                    this.pictureBox静态图块.ClientSize = new Size(staticTileSetData.Bitmap.Size.Width * 2, staticTileSetData.Bitmap.Size.Height * 2);
                }
                else
                {
                    this.pictureBox静态图块.ClientSize = new Size(256, 256);
                }

            }
            else
            {
                this.button静态图块文件名.Enabled = false;
                this.textBox静态图块名称.Enabled = false;
            }
            this.pictureBox静态图块.Invalidate();
        }

        private void textBox静态图块名称_TextChanged(object sender, EventArgs e)
        {
            StaticTileSetData staticTileSetData = this.listBox静态图块集.SelectedItem as StaticTileSetData;
            staticTileSetData.Name = this.textBox静态图块名称.Text;
            this.listBox静态图块集.Invalidate();
        }

        private void listBox静态图块集_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            StaticTileSetData staticTileSetData = this.listBox静态图块集.Items[e.Index] as StaticTileSetData;
            e.DrawBackground();
            graphics.DrawString(e.Index.ToString("000") + ":" + staticTileSetData.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void pictureBox静态图块_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(CustomBrushes.TransparentBrush, this.pictureBox静态图块.ClientRectangle);
            StaticTileSetData staticTileSetData = this.listBox静态图块集.SelectedItem as StaticTileSetData;
            if (staticTileSetData != null && staticTileSetData.Bitmap != null)
            {

                graphics.DrawImage(staticTileSetData.Bitmap, 0, 0, staticTileSetData.Bitmap.Width * 2, staticTileSetData.Bitmap.Height * 2);
                for (int i = 0; i < this.pictureBox静态图块.ClientSize.Width / 32; i++)
                {
                    graphics.DrawLine(Pens.Gray, i * 32, 0, i * 32, this.pictureBox静态图块.ClientSize.Height - 1);
                }
                for (int i = 0; i < this.pictureBox静态图块.ClientSize.Height / 32; i++)
                {
                    graphics.DrawLine(Pens.Gray, 0, i * 32, this.pictureBox静态图块.ClientSize.Width - 1, i * 32);
                }
                //for (int y = 0; y < staticTileSetData.PropertyTable.GetLength(1); y++)
                //{
                //    for (int x = 0; x < staticTileSetData.PropertyTable.GetLength(0); x++)
                //    {
                //        if (this.radioButton静态图块默认可视属性.Checked)
                //        {
                //            byte num = staticTileSetData.PropertyTable[x, y];
                //            num >>= 4;
                //            Font font = new Font("Default", 16, FontStyle.Regular);
                //            graphics.DrawString(num.ToString(), font, Brushes.Magenta, x * 32 + 4, y * 32 + 4);
                //            font.Dispose();
                //        }
                //        if (this.radioButton静态图块默认逻辑属性.Checked)
                //        {
                //            byte num = staticTileSetData.PropertyTable[x, y];
                //            num &= 0x0F;
                //            Font font = new Font("Default", 16, FontStyle.Regular);
                //            graphics.DrawString(num.ToString(), font, Brushes.Magenta, x * 32 + 4, y * 32 + 4);
                //            font.Dispose();
                //        }
                //    }
                //}
            }



        }

        private void button静态图块删除_Click(object sender, EventArgs e)
        {

            this.FixStaticBitmapID(this.listBox静态图块集.SelectedIndex, -1);

            this.textBox静态图块名称.Text = string.Empty;
            this.textBox静态图块文件名.Text = string.Empty;
            this.listBox静态图块集.Items.RemoveAt(this.listBox静态图块集.SelectedIndex);

            this.listBox静态图块集.Invalidate();
            this.button静态图块删除.Enabled = false;
            this.button静态图块上移.Enabled = false;
            this.button静态图块下移.Enabled = false;


        }

        private void button静态图块上移_Click(object sender, EventArgs e)
        {
            this.FixStaticBitmapID(this.listBox静态图块集.SelectedIndex, this.listBox静态图块集.SelectedIndex - 1);
            StaticTileSetData staticTileSetData1 = this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex] as StaticTileSetData;
            StaticTileSetData staticTileSetData2 = this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex - 1] as StaticTileSetData;
            this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex] = staticTileSetData2;
            this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex - 1] = staticTileSetData1;
            this.listBox静态图块集.SelectedIndex--;
        }

        private void button静态图块下移_Click(object sender, EventArgs e)
        {
            this.FixStaticBitmapID(this.listBox静态图块集.SelectedIndex, this.listBox静态图块集.SelectedIndex + 1);
            StaticTileSetData staticTileSetData1 = this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex] as StaticTileSetData;
            StaticTileSetData staticTileSetData2 = this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex + 1] as StaticTileSetData;
            this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex] = staticTileSetData2;
            this.listBox静态图块集.Items[this.listBox静态图块集.SelectedIndex + 1] = staticTileSetData1;
            this.listBox静态图块集.SelectedIndex++;
        }

        private void radioButton静态图块默认可视属性_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox静态图块.Invalidate();
        }

        private void radioButton静态图块默认逻辑属性_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox静态图块.Invalidate();
        }



        //private void pictureBox静态图块_MouseDown(object sender, MouseEventArgs e)
        //{

        //    StaticTileSetData staticTileSetData = this.listBox静态图块集.SelectedItem as StaticTileSetData;
        //    if (staticTileSetData != null)
        //    {
        //        int x = e.X / 32;
        //        int y = e.Y / 32;
        //        byte value = staticTileSetData.PropertyTable[x, y];
        //        if (this.radioButton静态图块默认可视属性.Checked)
        //        {
        //            if (e.Button == MouseButtons.Left)
        //            {
        //                value += 0x10;
        //            }
        //            if (e.Button == MouseButtons.Right)
        //            {
        //                value -= 0x10;
        //            }
        //            value &= 0xF0;
        //            staticTileSetData.PropertyTable[x, y] &= 0x0F;
        //            staticTileSetData.PropertyTable[x, y] += value;
        //        }
        //        if (this.radioButton静态图块默认逻辑属性.Checked)
        //        {
        //            if (e.Button == MouseButtons.Left)
        //            {
        //                value += 0x01;
        //            }
        //            if (e.Button == MouseButtons.Right)
        //            {
        //                value -= 0x01;
        //            }
        //            value &= 0x0F;
        //            staticTileSetData.PropertyTable[x, y] &= 0xF0;
        //            staticTileSetData.PropertyTable[x, y] += value;
        //        }

        //    }
        //    this.pictureBox静态图块.Invalidate();
        //}

        private void button动态图块文件名_Click(object sender, EventArgs e)
        {
            this.openFileDialog动态图块文件名.InitialDirectory = Application.StartupPath;
            if (this.openFileDialog动态图块文件名.ShowDialog() == DialogResult.OK)
            {
                if (CheckFilePathValid(this.openFileDialog动态图块文件名.FileName))
                {
                    this.textBox动态图块文件名.Text = this.openFileDialog动态图块文件名.FileName.Replace(Application.StartupPath, string.Empty).Replace("\\", "/");
                    DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
                    dynamicTileSetData.Filename = this.textBox动态图块文件名.Text;
                    this.pictureBox动态图块.ClientSize = new Size(dynamicTileSetData.Bitmap.Size.Width * 2, dynamicTileSetData.Bitmap.Size.Height * 2);
                    this.pictureBox动态图块.Invalidate();

                    this.button动态图块添加.Enabled = true;

                }
                else
                {
                    MessageBox.Show("必须打开当前应用程序目录下的文件");


                }
            }


        }

        private void button动态图块集添加_Click(object sender, EventArgs e)
        {
            DynamicTileSetData dynamicTileSetData = new DynamicTileSetData();
            this.listBox动态图块集.Items.Add(dynamicTileSetData);
        }

        private void listBox动态图块集_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.Items[e.Index] as DynamicTileSetData;
            e.DrawBackground();
            graphics.DrawString(e.Index.ToString("000") + ":" + dynamicTileSetData.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void listBox动态图块集_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.listBox动态图块集.SelectedIndex >= 0)
            {
                this.button动态图块文件名.Enabled = true;
                DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
                this.textBox动态图块名称.Text = dynamicTileSetData.Name;
                this.textBox动态图块文件名.Text = dynamicTileSetData.Filename;

                this.listBox动态图块.SelectedIndex = -1;
                this.listBox动态图块.Items.Clear();

                for (int i = 0; i < dynamicTileSetData.DynamicTileDataList.Count; i++)
                {
                    this.listBox动态图块.Items.Add(dynamicTileSetData.DynamicTileDataList[i]);
                }
                this.listBox动态图块.Invalidate();




                this.button动态图块集删除.Enabled = true;

                if (this.listBox动态图块集.SelectedIndex > 0)
                {
                    this.button动态图块集上移.Enabled = true;
                }
                else
                {
                    this.button动态图块集上移.Enabled = false;
                }
                if (this.listBox动态图块集.SelectedIndex < this.listBox动态图块集.Items.Count - 1)
                {
                    this.button动态图块集下移.Enabled = true;
                }
                else
                {
                    this.button动态图块集下移.Enabled = false;
                }


                this.textBox动态图块名称.Enabled = true;

                if (dynamicTileSetData.Filename != string.Empty)
                {
                    this.button动态图块添加.Enabled = true;
                }
                else
                {
                    this.button动态图块添加.Enabled = false;
                }

                if (dynamicTileSetData.Bitmap != null)
                {
                    this.pictureBox动态图块.ClientSize = new Size(dynamicTileSetData.Bitmap.Width * 2, dynamicTileSetData.Bitmap.Height * 2);
                }
                else
                {
                    this.pictureBox动态图块.ClientSize = new Size(256, 256);
                }

            }

            else
            {
                this.button动态图块文件名.Enabled = false;
                this.textBox动态图块名称.Enabled = false;
                this.button动态图块添加.Enabled = false;

                this.listBox动态图块.SelectedIndex = -1;
                this.listBox动态图块.Items.Clear();
                this.listBox动态图块.Invalidate();
             
            }
            dynamicPictureX = 0;
            dynamicPictureY = 0;
            this.pictureBox动态图块.Invalidate();

        
        }

        private void textBox动态图块名称_TextChanged(object sender, EventArgs e)
        {
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            dynamicTileSetData.Name = this.textBox动态图块名称.Text;
            this.listBox动态图块集.Invalidate();
        }

        private void button动态图块集删除_Click(object sender, EventArgs e)
        {
            this.FixDynamicBitmapID(this.ListBox动态图块集.SelectedIndex, -1);

            this.textBox动态图块名称.Text = string.Empty;
            this.textBox动态图块文件名.Text = string.Empty;
            this.listBox动态图块集.Items.RemoveAt(this.listBox动态图块集.SelectedIndex);

            this.listBox动态图块集.Invalidate();

            this.listBox动态图块.SelectedIndex = -1;
            this.listBox动态图块.Items.Clear();
            this.listBox动态图块.Invalidate();

            this.listBox动态图块帧.SelectedIndex = -1;
            this.listBox动态图块帧.Items.Clear();
            this.listBox动态图块帧.Invalidate();

            this.button动态图块集删除.Enabled = false;
            this.button动态图块集上移.Enabled = false;
            this.button动态图块集下移.Enabled = false;

        }

        private void button动态图块集上移_Click(object sender, EventArgs e)
        {
            this.FixDynamicBitmapID(this.listBox动态图块集.SelectedIndex, this.listBox动态图块集.SelectedIndex - 1);
            DynamicTileSetData dynamicTileSetData1 = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            DynamicTileSetData dynamicTileSetData2 = this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex - 1] as DynamicTileSetData;
            this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex - 1] = dynamicTileSetData1;
            this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex] = dynamicTileSetData2;
            this.listBox动态图块集.SelectedIndex--;

        }

        private void button动态图块集下移_Click(object sender, EventArgs e)
        {
            this.FixDynamicBitmapID(this.listBox动态图块集.SelectedIndex, this.listBox动态图块集.SelectedIndex + 1);
            DynamicTileSetData dynamicTileSetData1 = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            DynamicTileSetData dynamicTileSetData2 = this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex + 1] as DynamicTileSetData;
            this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex + 1] = dynamicTileSetData1;
            this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex] = dynamicTileSetData2;
            this.listBox动态图块集.SelectedIndex++;
        }

        private void listBox动态图块_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            DynamicTileData dynamicTileData = this.listBox动态图块.Items[e.Index] as DynamicTileData;
            e.DrawBackground();
            graphics.DrawString((e.Index + 1).ToString("000"), e.Font, Brushes.Black, e.Bounds);
        }

        private void listBox动态图块_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox动态图块.SelectedIndex >= 0)
            {
                this.button动态图块删除.Enabled = true;

                DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;

                this.listBox动态图块帧.SelectedIndex = -1;
                this.listBox动态图块帧.Items.Clear();
                for (int i = 0; i < dynamicTileData.FrameList.Count; i++)
                {
                    this.listBox动态图块帧.Items.Add(dynamicTileData.FrameList[i]);
                }



                if (this.listBox动态图块.SelectedIndex > 0)
                {
                    this.button动态图块上移.Enabled = true;
                }
                else
                {
                    this.button动态图块上移.Enabled = false;
                }
                if (this.listBox动态图块.SelectedIndex < this.listBox动态图块.Items.Count - 1)
                {
                    this.button动态图块下移.Enabled = true;
                }
                else
                {
                    this.button动态图块下移.Enabled = false;
                }

                this.button动态图块帧添加.Enabled = true;
                this.button动态图块播放.Enabled = true;
                if (this.timer.Enabled)
                {
                    this.timer.Enabled = false;
                    this.button动态图块播放.Image = global::WorldEditor.Properties.Resources.MoveNext;
                }

                this.numericUpDown缓慢参数.Enabled = true;
                this.numericUpDown缓慢参数.Value = dynamicTileData.SlowRegenerationRate;
            }
            else
            {
                this.button动态图块删除.Enabled = false;
                this.button动态图块上移.Enabled = false;
                this.button动态图块下移.Enabled = false;

                this.button动态图块帧添加.Enabled = false;
                this.button动态图块播放.Enabled = false;

                this.listBox动态图块帧.SelectedIndex = -1;
                this.listBox动态图块帧.Items.Clear();
                this.listBox动态图块帧.Invalidate();

                this.pictureBox动态图块.Invalidate();

                this.numericUpDown缓慢参数.Enabled = false;
            }


            this.listBox动态图块帧.SelectedIndex = -1;
            this.currectPlayIndex = 0;
            this.slowIndex = 0;
            this.pictureBox动态图块动画.Invalidate();

        }

        private void button动态图块添加_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = new DynamicTileData();
            this.listBox动态图块.Items.Add(dynamicTileData);
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.Items[this.listBox动态图块集.SelectedIndex] as DynamicTileSetData;
            dynamicTileSetData.DynamicTileDataList.Add(dynamicTileData);

            this.listBox动态图块.Invalidate();


        }

        private void button动态图块删除_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
            this.listBox动态图块.Items.RemoveAt(this.listBox动态图块.SelectedIndex);
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            dynamicTileSetData.DynamicTileDataList.Remove(dynamicTileData);

            this.listBox动态图块.Invalidate();

            this.listBox动态图块帧.SelectedIndex = -1;
            this.listBox动态图块帧.Items.Clear();
            this.listBox动态图块帧.Invalidate();
        }

        private void button动态图块上移_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData1 = this.listBox动态图块.SelectedItem as DynamicTileData;
            DynamicTileData dynamicTileData2 = this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex - 1] as DynamicTileData;

            this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex] = dynamicTileData2;
            this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex - 1] = dynamicTileData1;

            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            dynamicTileSetData.DynamicTileDataList.Insert(this.listBox动态图块.SelectedIndex - 1, dynamicTileData1);
            dynamicTileSetData.DynamicTileDataList.RemoveAt(this.listBox动态图块.SelectedIndex + 1);

            this.listBox动态图块.SelectedIndex--;
        }

        private void button动态图块下移_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData1 = this.listBox动态图块.SelectedItem as DynamicTileData;
            DynamicTileData dynamicTileData2 = this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex + 1] as DynamicTileData;

            this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex] = dynamicTileData2;
            this.listBox动态图块.Items[this.listBox动态图块.SelectedIndex + 1] = dynamicTileData1;

            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            dynamicTileSetData.DynamicTileDataList.Insert(this.listBox动态图块.SelectedIndex, dynamicTileData2);
            dynamicTileSetData.DynamicTileDataList.RemoveAt(this.listBox动态图块.SelectedIndex + 2);

            this.listBox动态图块.SelectedIndex++;
        }

        private void pictureBox动态图块_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(CustomBrushes.TransparentBrush, this.pictureBox动态图块.ClientRectangle);
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            if (dynamicTileSetData != null && dynamicTileSetData.Bitmap != null)
            {
                graphics.DrawImage(dynamicTileSetData.Bitmap, 0, 0, dynamicTileSetData.Bitmap.Width * 2, dynamicTileSetData.Bitmap.Height * 2);
                for (int i = 0; i < this.pictureBox动态图块.ClientSize.Width / 32; i++)
                {
                    graphics.DrawLine(Pens.Gray, i * 32, 0, i * 32, this.pictureBox动态图块.ClientSize.Height - 1);
                }
                for (int i = 0; i < this.pictureBox动态图块.ClientSize.Height / 32; i++)
                {
                    graphics.DrawLine(Pens.Gray, 0, i * 32, this.pictureBox动态图块.ClientSize.Width - 1, i * 32);
                }


                graphics.DrawRectangle(Pens.Red, dynamicPictureX * 32 + 1, dynamicPictureY * 32 + 1, 30, 30);




            }


        }

        private void pictureBox动态图块_MouseDown(object sender, MouseEventArgs e)
        {
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            if (dynamicTileSetData != null && dynamicTileSetData.Bitmap != null)
            {

                dynamicPictureX = e.X / 32;
                dynamicPictureY = e.Y / 32;

                this.pictureBox动态图块.Invalidate();
            }


        }


        private void button动态图块帧添加_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
            Byte x = (Byte)dynamicPictureX;
            Byte y = (Byte)dynamicPictureY;
            Byte xy = (Byte)((y << 4) + x);
            this.listBox动态图块帧.Items.Add(xy);
            dynamicTileData.FrameList.Add(xy);
        }

        private void listBox动态图块帧_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;



            Byte xy = (Byte)this.listBox动态图块帧.Items[e.Index];
            Byte x = (Byte)(xy & 0x0F);
            Byte y = (Byte)((xy & 0xF0) >> 4);
            Rectangle sourceRectangle = new Rectangle(x * 16, y * 16, 16, 16);


            Graphics graphics = e.Graphics;


            Rectangle rect = new Rectangle(e.Bounds.Left, e.Bounds.Top, 32, 32);
            graphics.FillRectangle(CustomBrushes.TransparentBrush, rect);
            graphics.DrawImage(dynamicTileSetData.Bitmap, rect, sourceRectangle, GraphicsUnit.Pixel);

            if (e.Index == this.listBox动态图块帧.SelectedIndex)
            {
                graphics.DrawRectangle(Pens.Blue, rect);
            }

        }

        private void listBox动态图块帧_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox动态图块帧.SelectedIndex >= 0)
            {
                this.button动态图块帧插入.Enabled = true;
                this.button动态图块帧删除.Enabled = true;
                this.button动态图块帧复制.Enabled = true;
            }
            else
            {
                this.button动态图块帧插入.Enabled = false;
                this.button动态图块帧删除.Enabled = false;
                this.button动态图块帧复制.Enabled = false;
            }
            this.listBox动态图块帧.Invalidate();
        }

        private void button动态图块帧删除_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
            dynamicTileData.FrameList.Remove((Byte)this.listBox动态图块帧.SelectedItem);
            this.listBox动态图块帧.Items.RemoveAt(this.listBox动态图块帧.SelectedIndex);


        }

        private void button动态图块帧复制_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
            this.listBox动态图块帧.Items.Insert(this.listBox动态图块帧.SelectedIndex, this.listBox动态图块帧.SelectedItem);
            dynamicTileData.FrameList.Insert(this.listBox动态图块帧.SelectedIndex, (Byte)this.listBox动态图块帧.SelectedItem);

        }

        private void button动态图块帧插入_Click(object sender, EventArgs e)
        {
            DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
            Byte x = (Byte)dynamicPictureX;
            Byte y = (Byte)dynamicPictureY;
            Byte xy = (Byte)((y << 4) + x);
            this.listBox动态图块帧.Items.Insert(this.listBox动态图块帧.SelectedIndex, xy);
            dynamicTileData.FrameList.Insert(this.listBox动态图块帧.SelectedIndex, xy);
        }

        private void button动态图块播放_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = !this.timer.Enabled;
            if (this.timer.Enabled)
            {
                this.button动态图块播放.Image = global::WorldEditor.Properties.Resources.Pause;
                this.currectPlayIndex = 0;
            }
            else
            {
                this.button动态图块播放.Image = global::WorldEditor.Properties.Resources.MoveNext;
            }

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            this.slowIndex++;
            DynamicTileData data = this.listBox动态图块.SelectedItem as DynamicTileData;
            if (slowIndex >= data.SlowRegenerationRate)
            {
                this.slowIndex = 0;
                this.currectPlayIndex++;
                if (this.currectPlayIndex >= data.FrameList.Count)
                {
                    this.currectPlayIndex = 0;
                }
            }
            this.pictureBox动态图块动画.Invalidate();
        }

        private void pictureBox动态图块动画_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Rectangle rect = new Rectangle(0, 0, 32, 32);
            graphics.FillRectangle(CustomBrushes.TransparentBrush, rect);


            if (this.listBox动态图块帧.Items.Count > 0)
            {
                DynamicTileSetData dynamicTileSetData = this.listBox动态图块集.SelectedItem as DynamicTileSetData;
                Byte xy = (Byte)this.listBox动态图块帧.Items[this.currectPlayIndex];
                Byte x = (Byte)(xy & 0x0F);
                Byte y = (Byte)((xy & 0xF0) >> 4);
                Rectangle sourceRectangle = new Rectangle(x * 16, y * 16, 16, 16);

                graphics.DrawImage(dynamicTileSetData.Bitmap, rect, sourceRectangle, GraphicsUnit.Pixel);
            }
        }

        private void numericUpDown缓慢参数_ValueChanged(object sender, EventArgs e)
        {
            DynamicTileData data = this.listBox动态图块.SelectedItem as DynamicTileData;
            data.SlowRegenerationRate = (int)this.numericUpDown缓慢参数.Value;
        }

        //private void numericUpDown默认可视属性_ValueChanged(object sender, EventArgs e)
        //{
        //    DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
        //    Byte value = dynamicTileData.Property;
        //    value &= 0x0F;
        //    Byte temp = (Byte)this.numericUpDown默认可视属性.Value;

        //    dynamicTileData.Property = (Byte)((temp << 4) + value);
        //}

        //private void numericUpDown默认逻辑属性_ValueChanged(object sender, EventArgs e)
        //{
        //    DynamicTileData dynamicTileData = this.listBox动态图块.SelectedItem as DynamicTileData;
        //    Byte value = dynamicTileData.Property;
        //    value &= 0xF0;
        //    Byte temp = (Byte)this.numericUpDown默认逻辑属性.Value;

        //    dynamicTileData.Property = (Byte)(temp + value);
        //}


        private void FixStaticBitmapID(int oldID, int newID)
        {
            foreach (MapData mapData in mainForm.ListBox关卡.Items)
            {
                for (int i = 0; i < mapData.VisualLayerDataList.Count; i++)
                {
                    if (mapData.VisualLayerDataList[i].StaticBitmapID == oldID)
                    {
                        mapData.VisualLayerDataList[i].StaticBitmapID = newID;
                    }
                    else if (mapData.VisualLayerDataList[i].StaticBitmapID == newID)
                    {
                        mapData.VisualLayerDataList[i].StaticBitmapID = oldID;
                    }
                }
                //if (mapData.Layer1.StaticBitmapID == oldID)
                //{
                //    mapData.Layer1.StaticBitmapID = newID;
                //}
            }
            //foreach (MapData mapData in mainForm.ListBox关卡.Items)
            //{
            //    if (mapData.Layer2.StaticBitmapID == oldID)
            //    {
            //        mapData.Layer2.StaticBitmapID = newID;
            //    }
            //}
            //foreach (MapData mapData in mainForm.ListBox关卡.Items)
            //{
            //    if (mapData.Layer3.StaticBitmapID == oldID)
            //    {
            //        mapData.Layer3.StaticBitmapID = newID;
            //    }
            //}
        }

        private void FixDynamicBitmapID(int oldID, int newID)
        {
            foreach (MapData mapData in mainForm.ListBox关卡.Items)
            {
                for (int i = 0; i < mapData.VisualLayerDataList.Count; i++)
                {
                    if (mapData.VisualLayerDataList[i].DynamicBitmapID == oldID)
                    {
                        mapData.VisualLayerDataList[i].DynamicBitmapID = newID;
                    }
                    else if (mapData.VisualLayerDataList[i].DynamicBitmapID == newID)
                    {
                        mapData.VisualLayerDataList[i].DynamicBitmapID = oldID;
                    }
                }
                //if (mapData.Layer1.DynamicBitmapID == oldID)
                //{
                //    mapData.Layer1.DynamicBitmapID = newID;
                //}
            }
            //foreach (MapData mapData in mainForm.ListBox关卡.Items)
            //{
            //    if (mapData.Layer2.DynamicBitmapID == oldID)
            //    {
            //        mapData.Layer2.DynamicBitmapID = newID;
            //    }
            //}
            //foreach (MapData mapData in mainForm.ListBox关卡.Items)
            //{
            //    if (mapData.Layer3.DynamicBitmapID == oldID)
            //    {
            //        mapData.Layer3.DynamicBitmapID = newID;
            //    }
            //}
        }

        private void button音乐添加_Click(object sender, EventArgs e)
        {
            this.openFileDialog音乐.InitialDirectory = Application.StartupPath;
            if (this.openFileDialog音乐.ShowDialog() == DialogResult.OK)
            {
                this.listBox音乐.Items.Add(this.openFileDialog音乐.FileName.Replace(Application.StartupPath, string.Empty).Replace("\\", "/"));
            }
        }

        private void listBox音乐_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox音乐.SelectedIndex != -1)
            {
                this.button音乐播放.Enabled = true;
                this.button音乐停止.Enabled = true;
                this.button音乐删除.Enabled = true;
                this.button音乐上移.Enabled = true;
                this.button音乐下移.Enabled = true;
            }
            else
            {
                this.button音乐播放.Enabled = false;
                this.button音乐停止.Enabled = false;
                this.button音乐删除.Enabled = false;
                this.button音乐上移.Enabled = false;
                this.button音乐下移.Enabled = false;
            }

            if (this.listBox音乐.SelectedIndex == 0)
            {
                this.button音乐上移.Enabled = false;
            }

            if (this.listBox音乐.SelectedIndex == this.listBox音乐.Items.Count - 1)
            {
                this.button音乐下移.Enabled = false;
            }
        }

        private void listBox音效_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox音效.SelectedIndex != -1)
            {
                this.button音效播放.Enabled = true;
                this.button音效停止.Enabled = true;
                this.button音效删除.Enabled = true;
                this.button音效上移.Enabled = true;
                this.button音效下移.Enabled = true;
            }
            else
            {
                this.button音效播放.Enabled = false;
                this.button音效停止.Enabled = false;
                this.button音效删除.Enabled = false;
                this.button音效上移.Enabled = false;
                this.button音效下移.Enabled = false;
            }

            if (this.listBox音效.SelectedIndex == 0)
            {
                this.button音效上移.Enabled = false;
            }

            if (this.listBox音效.SelectedIndex == this.listBox音效.Items.Count - 1)
            {
                this.button音效下移.Enabled = false;
            }
        }

        private void button音乐播放_Click(object sender, EventArgs e)
        {
            AudioPlayer.PlayMidi(Application.StartupPath + this.listBox音乐.SelectedItem);
        }

        private void button音乐停止_Click(object sender, EventArgs e)
        {
            AudioPlayer.CloseMidi();
        }

        private void button音效停止_Click(object sender, EventArgs e)
        {
            AudioPlayer.CloseWave();
        }

        private void button音效播放_Click(object sender, EventArgs e)
        {
            AudioPlayer.PlayWave(Application.StartupPath + this.listBox音效.SelectedItem);
        }

        private void button音效添加_Click(object sender, EventArgs e)
        {
            this.openFileDialog音效.InitialDirectory = Application.StartupPath;
            if (this.openFileDialog音效.ShowDialog() == DialogResult.OK)
            {
                this.listBox音效.Items.Add(this.openFileDialog音效.FileName.Replace(Application.StartupPath, string.Empty).Replace("\\", "/"));
            }
        }

        private void button音乐删除_Click(object sender, EventArgs e)
        {
            this.FixMusicID(this.listBox音乐.SelectedIndex, -1);
            this.listBox音乐.Items.RemoveAt(this.listBox音乐.SelectedIndex);
        }

        private void button音效删除_Click(object sender, EventArgs e)
        {
            this.FixSoundID(this.listBox音效.SelectedIndex, -1);
            this.listBox音效.Items.RemoveAt(this.listBox音效.SelectedIndex);
        }

        private void button音乐上移_Click(object sender, EventArgs e)
        {
            this.FixMusicID(this.listBox音乐.SelectedIndex, this.listBox音乐.SelectedIndex - 1);
            string str1 = this.listBox音乐.Items[this.listBox音乐.SelectedIndex] as string;
            string str2 = this.listBox音乐.Items[this.listBox音乐.SelectedIndex - 1] as string;
            this.listBox音乐.Items[this.listBox音乐.SelectedIndex] = str2;
            this.listBox音乐.Items[this.listBox音乐.SelectedIndex - 1] = str1;
            this.listBox音乐.SelectedIndex--;
        }

        private void button音乐下移_Click(object sender, EventArgs e)
        {
            this.FixMusicID(this.listBox音乐.SelectedIndex, this.listBox音乐.SelectedIndex + 1);
            string str1 = this.listBox音乐.Items[this.listBox音乐.SelectedIndex] as string;
            string str2 = this.listBox音乐.Items[this.listBox音乐.SelectedIndex + 1] as string;
            this.listBox音乐.Items[this.listBox音乐.SelectedIndex] = str2;
            this.listBox音乐.Items[this.listBox音乐.SelectedIndex + 1] = str1;
            this.listBox音乐.SelectedIndex++;
        }

        private void FixMusicID(int oldID, int newID)
        {
            foreach (MapData mapData in mainForm.ListBox关卡.Items)
            {
                foreach (Trigger trigger in mapData.TriggerList)
                {
                    foreach (Command command in trigger.GameEventAction.CommandList)
                    {
                        if (command.TypeID == CommandType.PlayMidi)
                        {
                            if ((int)(command.CommandArgs[0]) == oldID)
                            {
                                command.CommandArgs[0] = newID;
                            }
                            else if ((int)(command.CommandArgs[0]) == newID)
                            {
                                command.CommandArgs[0] = oldID;
                            }
                        }
                    }
                }
            }
        }

        private void button音效上移_Click(object sender, EventArgs e)
        {
            this.FixSoundID(this.listBox音效.SelectedIndex, this.listBox音效.SelectedIndex - 1);
            string str1 = this.listBox音效.Items[this.listBox音效.SelectedIndex] as string;
            string str2 = this.listBox音效.Items[this.listBox音效.SelectedIndex - 1] as string;
            this.listBox音效.Items[this.listBox音效.SelectedIndex] = str2;
            this.listBox音效.Items[this.listBox音效.SelectedIndex - 1] = str1;
            this.listBox音效.SelectedIndex--;
        }

        private void button音效下移_Click(object sender, EventArgs e)
        {
            this.FixSoundID(this.listBox音效.SelectedIndex, this.listBox音效.SelectedIndex + 1);
            string str1 = this.listBox音效.Items[this.listBox音效.SelectedIndex] as string;
            string str2 = this.listBox音效.Items[this.listBox音效.SelectedIndex + 1] as string;
            this.listBox音效.Items[this.listBox音效.SelectedIndex] = str2;
            this.listBox音效.Items[this.listBox音效.SelectedIndex + 1] = str1;
            this.listBox音效.SelectedIndex++;
        }

        private void FixSoundID(int oldID, int newID)
        {
            foreach (MapData mapData in mainForm.ListBox关卡.Items)
            {
                foreach (Trigger trigger in mapData.TriggerList)
                {
                    foreach (Command command in trigger.GameEventAction.CommandList)
                    {
                        if (command.TypeID == CommandType.PlayWav)
                        {
                            if ((int)(command.CommandArgs[0]) == oldID)
                            {
                                command.CommandArgs[0] = newID;
                            }
                            else if ((int)(command.CommandArgs[0]) == newID)
                            {
                                command.CommandArgs[0] = oldID;
                            }
                        }
                    }
                }
            }
        }

        private void listBox变量_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.listBox变量.Items[e.Index] as EventVariable;
            e.DrawBackground();
            graphics.DrawString((e.Index + 1).ToString("000") + "  " + eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void listBox变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox变量.SelectedIndex != -1)
            {
                EventVariable eventVarible = this.listBox变量.SelectedItem as EventVariable;
                this.textBox变量名字.Enabled = true;
                this.textBox变量名字.Text = eventVarible.Name;
                this.numericUpDown变量初始值.Enabled = true;
                this.numericUpDown变量初始值.Value = eventVarible.VariableValue;
                this.button变量删除.Enabled = true;
            }
            else
            {
                this.textBox变量名字.Text = string.Empty;
                this.textBox变量名字.Enabled = false;
                this.numericUpDown变量初始值.Value = 0;
                this.numericUpDown变量初始值.Enabled = false;
                this.button变量删除.Enabled = false;
            }
        }

        private void textBox变量名字_TextChanged(object sender, EventArgs e)
        {
            EventVariable eventVarible = this.listBox变量.SelectedItem as EventVariable;
            if (eventVarible != null && this.textBox变量名字.Text != string.Empty && this.CheckNameValid(this.textBox变量名字.Text))
            {
                eventVarible.Name = this.textBox变量名字.Text;
                this.listBox变量.Invalidate();
                
            }
            //else
            //{
            //    MessageBox.Show("变量名字不能为空");
            //    eventVarible.Name = "varible" + this.listBox变量.SelectedIndex.ToString();
            //    this.textBox变量名字.Text = eventVarible.Name;
            //}
        }

        private void numericUpDown变量初始值_ValueChanged(object sender, EventArgs e)
        {
            EventVariable eventVarible = this.listBox变量.SelectedItem as EventVariable;
            if (eventVarible != null)
            {
                eventVarible.VariableValue = (int)this.numericUpDown变量初始值.Value;
            }
        }

        private void button变量添加_Click(object sender, EventArgs e)
        {
            EventVariable eventVarible = new EventVariable();
            this.listBox变量.Items.Add(eventVarible);
        }

        private void button变量删除_Click(object sender, EventArgs e)
        {
            EventVariable eventVarible = this.listBox变量.SelectedItem as EventVariable;

            if (MessageBox.Show("删除变量可能导致触发器出错", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.listBox变量.Items.Remove(eventVarible);
            }
        }

        private bool CheckNameValid(string name)
        {
            foreach (EventVariable obj in this.ListBox变量.Items)
            {
                if (obj != this.ListBox变量.SelectedItem)
                {
                    if (name == obj.Name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void FixEventVariable(int index)
        {
            
        }
    }
}
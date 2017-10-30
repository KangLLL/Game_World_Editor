using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form触发区域比较 : Form
    {
        public Form触发区域比较(MainForm mainForm)
        {
            InitializeComponent();
            MapData mapData = mainForm.ListBox关卡.SelectedItem as MapData;
            foreach (EventRegion eventRegion in mapData.LogicLayer.EventRegionList)
            {
                this.comboBox触发区域.Items.Add(eventRegion);
            }
        }

        public ComboBox ComboBox触发区域
        {
            get
            {
                return this.comboBox触发区域;
            }
        }

        private void comboBox触发区域_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventRegion eventRegion = this.comboBox触发区域.Items[e.Index] as EventRegion;
            string drawString = eventRegion.Name + " (" + eventRegion.RegionRect.Left + "," + eventRegion.RegionRect.Top + "," + eventRegion.RegionRect.Right + "," + eventRegion.RegionRect.Bottom + ")";
            graphics.DrawString(drawString, e.Font, Brushes.Black, e.Bounds);
        }

        private void comboBox触发区域_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox触发区域.SelectedIndex != -1)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form区域名称修改 : Form
    {
        private string name;
        private MainForm mainform;

        public Form区域名称修改(MainForm mainform,string name)
        {
            InitializeComponent();
            this.name = name;
            this.mainform = mainform;
            this.textBox名字.Text = name;
        }

        public string RegionName
        {
            get
            {
                return this.textBox名字.Text;
            }
        }

        private void textBox名字_TextChanged(object sender, EventArgs e)
        {
            MapData mapData = this.mainform.ListBox关卡.SelectedItem as MapData;
            if (this.textBox名字.Text == string.Empty || !mapData.LogicLayer.CheckRegionName(this.textBox名字.Text))
            {
                this.button确定.Enabled = false;
            }
            else
            {
                this.button确定.Enabled = true;
            }
        }
    }
}
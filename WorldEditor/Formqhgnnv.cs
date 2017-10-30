using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form杀死游戏单位 : Form
    {
        public Form杀死游戏单位(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
        }

        private MainForm mainForm;

        private MapData mapData;

        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public ComboBox ComboBox游戏单位类型
        {
            get
            {
                return this.comboBox游戏单位类型;
            }
        }

        public ComboBox ComboBox名字
        {
            get
            {
                return this.comboBox名字;
            }
        }

        private void comboBox游戏单位类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox游戏单位类型.SelectedIndex != -1)
            {
                this.comboBox名字.Items.Clear();
                foreach (GameUnit gameUnit in this.mapData.GameUnitList)
                {
                    if (gameUnit.GameUnitType == (GameUnitType)(this.comboBox游戏单位类型.SelectedIndex))
                    {
                        this.comboBox名字.Items.Add(gameUnit.GameUnitName);
                    }
                }
                this.comboBox名字.SelectedIndex = -1;
            }
            else
            {
                this.comboBox名字.Items.Clear();
            }
            this.button确定.Enabled = false;
        }

        private void comboBox名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox名字.SelectedIndex != -1)
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
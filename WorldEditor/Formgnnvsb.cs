using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form游戏单位比较 : Form
    {
        public Form游戏单位比较(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            
        }

        private MainForm mainForm;

        public ComboBox ComboBox游戏单位
        {
            get
            {
                return this.comboBox游戏单位;
            }
        }

        public ComboBox ComboBox名字
        {
            get
            {
                return this.comboBox名字;
            }
        }

        private void comboBox游戏单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox游戏单位.SelectedIndex != -1)
            {
                this.comboBox名字.Items.Clear();
                MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
                foreach (GameUnit gameUnit in mapData.GameUnitList)
                {
                    if (gameUnit.GameUnitType == (GameUnitType)(this.comboBox游戏单位.SelectedIndex))
                    {
                        this.comboBox名字.Items.Add(gameUnit.GameUnitName);
                    }
                }
                this.button确定.Enabled = true;
            }
            else
            {
                this.comboBox名字.Items.Clear();
                this.button确定.Enabled = false;
            }
        }
    }
}
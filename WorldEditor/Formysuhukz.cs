using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置触发器开关 : Form
    {

        public Form设置触发器开关(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            foreach (Trigger trigger in mapData.TriggerList)
            {
                this.comboBox操作触发器.Items.Add(trigger);
            }
	
        }

        private MainForm mainForm;

        public ComboBox ComboBox操作触发器
        {
            get
            {
                return this.comboBox操作触发器;
            }
        }

        public RadioButton RadioButton打开
        {
            get
            {
                return this.radioButton打开;
            }
        }

        private void comboBox操作触发器_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox操作触发器.SelectedIndex != -1)
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
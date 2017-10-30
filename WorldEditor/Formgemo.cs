using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form新建地图 : Form
    {
        public Form新建地图(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.textBox名称.Text = "Map" + this.GetHashCode().ToString();
        }

        private MainForm mainForm;

        public string MapName
        {
            get { return this.textBox名称.Text; }
            set { this.textBox名称.Text = value; }
        }

        public int LogicLayerWidth
        {
            get { return (int)this.numericUpDown逻辑层宽.Value; }
            set { this.numericUpDown逻辑层宽.Value = value; }
        }

        public int LogicLayerHeight
        {
            get { return (int)this.numericUpDown逻辑层高.Value; }
            set { this.numericUpDown逻辑层高.Value = value; }
        }

        //public int BgmID
        //{
        //    get { return this.comboBox背景音乐.SelectedIndex; }
        //    set { this.comboBox背景音乐.SelectedIndex = value; }
        //}

        private bool CheckNameValid(string name)
        {
            foreach (MapData obj in this.mainForm.ListBox关卡.Items)
            {

                if (name == obj.Name)
                {
                    return false;
                }

            }
            return true;
        }

        private void button确定_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;

        }

        private void button取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox名称_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox名称.Text == string.Empty || !this.CheckNameValid(this.textBox名称.Text))
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
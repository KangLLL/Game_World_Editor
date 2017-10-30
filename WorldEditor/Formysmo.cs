using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置地图 : Form
    {
        public Form设置地图(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            //this.textBox名称.Text = "Map" + this.GetHashCode().ToString();
        }


        private MainForm mainForm;


        private int clipMode = 0;

        public int ClipMode
        {
            get { return clipMode; }
            set { clipMode = value; }
        }


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

        private void button确定_Click(object sender, EventArgs e)
        {
            //if (this.CheckDataValid())
            //{
                if (this.radioButton剪裁上.Checked && this.radioButton剪裁左.Checked)
                {
                    this.clipMode = 0;
                }
                else if (this.radioButton剪裁上.Checked && this.radioButton剪裁右.Checked)
                {
                    this.clipMode = 1;
                }
                else if (this.radioButton剪裁下.Checked && this.radioButton剪裁左.Checked)
                {
                    this.clipMode = 2;
                }
                else
                {
                    this.clipMode = 3;
                }
                this.DialogResult = DialogResult.OK;
                
            //}
        }

        private bool CheckNameValid(string name)
        {
            foreach (MapData obj in this.mainForm.ListBox关卡.Items)
            {
                if (obj != this.mainForm.ListBox关卡.SelectedItem)
                {
                    if (name == obj.Name)
                    {
                        return false;
                    }
                }
            }
            return true;
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
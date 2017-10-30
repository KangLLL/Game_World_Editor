using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form新建层 : Form
    {
        public Form新建层(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            this.InitializeData();
        }

        private MainForm mainForm;

        private void InitializeData()
        {
            this.textBox名称.Text = "VisualLayer" + this.GetHashCode().ToString();

            foreach (object obj in this.mainForm.Form元数据.ListBox静态图块集.Items)
            {
                this.comboBox静态背景.Items.Add(obj);
            }

            foreach (object obj in this.mainForm.Form元数据.ListBox动态图块集.Items)
            {
                this.comboBox动态背景.Items.Add(obj);
            }
        }

        public string LayerName
        {
            get
            {
                return this.textBox名称.Text;
            }
            set
            {
                this.textBox名称.Text = value;
            }
        }

        public int StaticBitmapID
        {
            get
            {
                return this.comboBox静态背景.SelectedIndex;
            }
            set
            {
                this.comboBox静态背景.SelectedIndex = value;
            }
        }

        public int DynamicBitmapID
        {
            get
            {
                return this.comboBox动态背景.SelectedIndex;
            }
            set
            {
                this.comboBox动态背景.SelectedIndex = value;
            }
        }

        public int HorizontalTileCount
        {
            get
            {
                return (int)(this.numericUpDown可见层宽.Value);
            }
            set
            {
                this.numericUpDown可见层宽.Value = value;
            }
        }

        public int VerticalTileCount
        {
            get
            {
                return (int)(this.numericUpDown可见层高.Value);
            }
            set
            {
                this.numericUpDown可见层高.Value = value;
            }
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

        private bool CheckNameValid(string name)
        {
            foreach (VisualLayerData obj in this.mainForm.ListBox可见层.Items)
            {
                if (name == obj.Name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
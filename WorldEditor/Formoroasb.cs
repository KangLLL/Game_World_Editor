using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form变量与值比较 : Form
    {
        public Form变量与值比较(MainForm mainForm)
        {
            InitializeComponent();
            foreach (EventVariable eventVariable in mainForm.Form元数据.ListBox变量.Items)
            {
                this.comboBox变量.Items.Add(eventVariable);
            }
        }


        public ComboBox ComboBox变量
        {
            get
            {
                return this.comboBox变量;
            }
        }

        public ComboBox ComboBox条件
        {
            get
            {
                return this.comboBox条件;
            }
        }

        public int ConstNum
        {
            get
            {
                return (int)this.numericUpDown常量.Value;
            }
        }

        private void comboBox变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox变量.SelectedIndex != -1 && this.comboBox条件.SelectedIndex != -1)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBox条件_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox变量.SelectedIndex != -1 && this.comboBox条件.SelectedIndex != -1)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBox变量_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.comboBox变量.Items[e.Index] as EventVariable;
            graphics.DrawString(eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form变量与变量比较 : Form
    {
        public Form变量与变量比较(MainForm mainform)
        {
            InitializeComponent();
            foreach (EventVariable eventVariable in mainform.Form元数据.ListBox变量.Items)
            {
                this.comboBox变量一.Items.Add(eventVariable);
            }
            foreach (EventVariable eventVariable in mainform.Form元数据.ListBox变量.Items)
            {
                this.comboBox变量二.Items.Add(eventVariable);
            }
        }

        public ComboBox ComboBox变量一
        {
            get
            {
                return this.comboBox变量一;
            }
        }

        public ComboBox ComboBox变量二
        {
            get
            {
                return this.comboBox变量二;
            }
        }

        public ComboBox ComboBox条件
        {
            get
            {
                return this.comboBox条件;
            }
        }

        private void comboBox变量一_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox变量一.SelectedIndex != -1 && this.comboBox变量二.SelectedIndex != -1 && this.comboBox条件.SelectedIndex != -1)
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
            if (this.comboBox变量一.SelectedIndex != -1 && this.comboBox变量二.SelectedIndex != -1 && this.comboBox条件.SelectedIndex != -1)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBox变量二_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox变量一.SelectedIndex != -1 && this.comboBox变量二.SelectedIndex != -1 && this.comboBox条件.SelectedIndex != -1)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBox变量一_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.comboBox变量一.Items[e.Index] as EventVariable;
            graphics.DrawString(eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void comboBox变量二_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.comboBox变量一.Items[e.Index] as EventVariable;
            graphics.DrawString(eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }

    }
}
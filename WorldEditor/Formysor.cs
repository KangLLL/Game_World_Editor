using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置变量 : Form
    {
        public Form设置变量(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (EventVariable eventVariable in mainForm.Form元数据.ListBox变量.Items)
            {
                this.comboBox操作变量.Items.Add(eventVariable);
                this.comboBox变量.Items.Add(eventVariable);
            }
        }

        private MainForm mainForm;

        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public ComboBox ComboBox操作变量
        {
            get
            {
                return this.comboBox操作变量;
            }
        }

        public ComboBox ComboBox变量
        {
            get
            {
                return this.comboBox变量;
            }
        }

        public NumericUpDown NumericUpDown常量
        {
            get
            {
                return this.numericUpDown常量;
            }
        }

        public RadioButton RadioButton变量
        {
            get
            {
                return this.radioButton变量;
            }
        }

        private void radioButton常量_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton常量.Checked)
            {
                this.comboBox变量.SelectedIndex = -1;
                this.comboBox变量.Enabled = false;
                this.numericUpDown常量.Enabled = true;

                if (this.comboBox操作变量.SelectedIndex != -1)
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.comboBox变量.Enabled = true;
                this.numericUpDown常量.Enabled = false;
                this.button确定.Enabled = false;
            }
        }

        private void comboBox操作变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox操作变量.SelectedIndex != -1 && (this.radioButton常量.Checked || (this.radioButton变量.Checked && this.comboBox变量.SelectedIndex != -1)))
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBox变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox变量.SelectedIndex != -1 && this.comboBox操作变量.SelectedIndex != -1)
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
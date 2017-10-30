using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form变量自加 : Form
    {
        public Form变量自加(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (EventVariable eventVariable in this.mainForm.Form元数据.ListBox变量.Items)
            {
                this.comboBox操作变量.Items.Add(eventVariable);
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

        public NumericUpDown NumericUpDown操作数
        {
            get
            {
                return this.numericUpDown操作数;
            }
        }

        private void comboBox操作变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox操作变量.SelectedIndex != -1)
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
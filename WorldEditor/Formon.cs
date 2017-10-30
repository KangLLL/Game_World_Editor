using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form收费 : Form
    {
        public Form收费()
        {
            InitializeComponent();
        }

        private void textBox信息_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox信息.Text != String.Empty && this.numericUpDown费用.Value != 0 && this.textBox提示.Text != String.Empty)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void numericUpDown费用_ValueChanged(object sender, EventArgs e)
        {
            if (this.textBox信息.Text != String.Empty && this.numericUpDown费用.Value != 0 && this.textBox提示.Text != String.Empty)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }


        private void textBox提示_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox信息.Text != String.Empty && this.numericUpDown费用.Value != 0 && this.textBox提示.Text != String.Empty)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        public TextBox TextBox信息
        {
            get
            {
                return this.textBox信息;
            }
        }

        public TextBox TextBox提示
        {
            get
            {
                return this.textBox提示;
            }
        }

        public NumericUpDown NumericUpDown费用
        {
            get
            {
                return this.numericUpDown费用;
            }
        }

    }
}
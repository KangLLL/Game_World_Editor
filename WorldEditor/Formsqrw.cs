using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form显示文章 : Form
    {
        public Form显示文章(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (EventVariable eventVariable in this.mainForm.Form元数据.ListBox变量.Items)
            {
                this.comboBoxX变量.Items.Add(eventVariable);
                this.comboBoxY变量.Items.Add(eventVariable);
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

        public RadioButton RadioButtonX变量
        {
            get
            {
                return this.radioButtonX变量;
            }
        }

        public RadioButton RadioButtonY变量
        {
            get
            {
                return this.radioButtonY变量;
            }
        }

        public ComboBox ComboBoxX变量
        {
            get
            {
                return this.comboBoxX变量;
            }
        }

        public ComboBox ComboBoxY变量
        {
            get
            {
                return this.comboBoxY变量;
            }
        }

        public NumericUpDown NumericUpDownX常量
        {
            get
            {
                return this.numericUpDownX常量;
            }
        }

        public NumericUpDown NumericUpDownY常量
        {
            get
            {
                return this.numericUpDownY常量;
            }
        }

        public TextBox TextBox文章
        {
            get
            {
                return this.textBox文章;
            }
        }
             
        private void radioButtonY常量_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonY常量.Checked)
            {
                this.numericUpDownY常量.Enabled = true;
                this.comboBoxY变量.Enabled = false;
                this.comboBoxY变量.SelectedIndex = -1;

                if (this.textBox文章.Text != string.Empty && (this.radioButtonX常量.Checked || (this.radioButtonX变量.Checked && this.comboBoxX变量.SelectedIndex != -1)))
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.numericUpDownY常量.Enabled = false;
                this.comboBoxY变量.Enabled = true;

                this.button确定.Enabled = false;
            }
        }

        private void radioButtonX常量_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonX常量.Checked)
            {
                this.numericUpDownX常量.Enabled = true;
                this.comboBoxX变量.Enabled = false;
                this.comboBoxX变量.SelectedIndex = -1;

                if (this.textBox文章.Text != string.Empty && (this.radioButtonY常量.Checked || (this.radioButtonY变量.Checked && this.comboBoxY变量.SelectedIndex != -1)))
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.numericUpDownX常量.Enabled = false;
                this.comboBoxX变量.Enabled = true;

                this.button确定.Enabled = false;
            }
        }

        private void textBox文章_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox文章.Text != string.Empty)
            {
                if (this.radioButtonX变量.Checked && this.comboBoxX变量.SelectedIndex == -1)
                {
                    this.button确定.Enabled = false;
                }
                else if (this.radioButtonY变量.Checked && this.comboBoxY变量.SelectedIndex == -1)
                {
                    this.button确定.Enabled = false;
                }
                else
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBoxX变量_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.comboBoxX变量.Items[e.Index] as EventVariable;
            graphics.DrawString(eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void comboBoxY变量_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            EventVariable eventVariable = this.comboBoxY变量.Items[e.Index] as EventVariable;
            graphics.DrawString(eventVariable.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void comboBoxX变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxX变量.SelectedIndex != -1 && this.textBox文章.Text != string.Empty)
            {
                if (this.radioButtonY变量.Checked && this.comboBoxY变量.SelectedIndex == -1)
                {
                    this.button确定.Enabled = false;
                }
                else
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }

        private void comboBoxY变量_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxY变量.SelectedIndex != -1 && this.textBox文章.Text != string.Empty)
            {
                if (this.radioButtonX变量.Checked && this.comboBoxX变量.SelectedIndex == -1)
                {
                    this.button确定.Enabled = false;
                }
                else
                {
                    this.button确定.Enabled = true;
                }
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }
    }
}
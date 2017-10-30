using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form播放角色动画 : Form
    {
        public Form播放角色动画()
        {
            InitializeComponent();
        }

        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public TextBox TextBox动画文件名
        {
            get
            {
                return this.textBox动画文件名;
            }
        }

        public TextBox TextBox动画序列
        {
            get
            {
                return this.textBox动画序列;
            }
        }

        public NumericUpDown NumericUpDown开始X
        {
            get
            {
                return this.numericUpDown开始X;
            }
        }

        public NumericUpDown NumericUpDown开始Y
        {
            get
            {
                return this.numericUpDown开始Y;
            }
        }

        public NumericUpDown NumericUpDown终止X
        {
            get
            {
                return this.numericUpDown终止X;
            }
        }

        public NumericUpDown NumericUpDown终止Y
        {
            get
            {
                return this.numericUpDown终止Y;
            }
        }

        public CheckBox CheckBox重复播放
        {
            get
            {
                return this.checkBox重复播放;
            }
        }

        public NumericUpDown NumericUpDown水平速度
        {
            get
            {
                return this.numericUpDown水平速度;
            }
        }

        public NumericUpDown NumericUpDown垂直速度
        {
            get
            {
                return this.numericUpDown垂直速度;
            }
        }

        public NumericUpDown NumericUpDown播放帧数
        {
            get
            {
                return this.numericUpDown帧数;
            }
        }

        public NumericUpDown NumericUpDown缓慢系数
        {
            get
            {
                return this.numericUpDown缓慢系数;
            }
        }

        public RadioButton RadioButton同步
        {
            get
            {
                return this.radioButton同步;
            }
        }

        private void comboBox角色类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TextBox动画文件名.Text != string.Empty && this.textBox动画序列.Text != string.Empty)
            {
                this.button确定.Enabled = true;
            }
            else
            {
                this.button确定.Enabled = false;
            }
        }


        private void textBox动画序列_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox动画文件名.Text != string.Empty && this.textBox动画序列.Text != string.Empty)
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
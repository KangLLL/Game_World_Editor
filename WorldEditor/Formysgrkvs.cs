using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置摄像机位置 : Form
    {
        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public NumericUpDown NumericUpDown坐标X
        {
            get
            {
                return this.numericUpDown坐标X;
            }
        }

        public NumericUpDown NumericUpDown坐标Y
        {
            get
            {
                return this.numericUpDown坐标Y;
            }
        }

        public Form设置摄像机位置()
        {
            InitializeComponent();
        }
    }
}
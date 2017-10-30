using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置单位绘制层 : Form
    {
        public Form设置单位绘制层()
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

        public NumericUpDown NumericUpDown层数
        {
            get
            {
                return this.numericUpDown层数;
            }
        }
    }
}
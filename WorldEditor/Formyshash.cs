using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form设置主角坐标 : Form
    {
        public Form设置主角坐标()
        {
            InitializeComponent();
        }

        public NumericUpDown NumericUpDownX
        {
            get
            {
                return this.numericUpDownX;
            }
        }

        public NumericUpDown NumericUpDownY
        {
            get
            {
                return this.numericUpDownY;
            }
        }
                
    }
}
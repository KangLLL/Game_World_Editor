using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form等待 : Form
    {
        public Form等待()
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

        public NumericUpDown NumericUpDown时间
        {
            get
            {
                return this.numericUpDown时间;
            }
        }
    }
}
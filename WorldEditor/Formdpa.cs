using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form逻辑值 : Form
    {
        public Form逻辑值(MainForm mainForm)
        {
            InitializeComponent();
            this.numericUpDown逻辑值.Value = mainForm.LogicNum;
        }

        public NumericUpDown NumericUpDown逻辑值
        {
            get
            {
                return this.numericUpDown逻辑值;
            }
        }
    }
}
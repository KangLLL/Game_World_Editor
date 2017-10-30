using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form移动摄像机 : Form
    {
        public Form移动摄像机(MainForm mainForm)
        {
            this.mainForm = mainForm;

            InitializeComponent();
        }

        private MainForm mainForm;

        public Button Button确定
        {
            get
            {
                return this.button确定;
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

        public NumericUpDown NumericUpDown速度X
        {
            get
            {
                return this.numericUpDown速度X;
            }
        }

        public NumericUpDown NumericUpDown速度Y
        {
            get
            {
                return this.numericUpDown速度Y;
            }
        }

        public CheckBox CheckBox是否同步
        {
            get
            {
                return this.checkBox是否同步;
            }
        }

   

     

     

     

     

     

   

    
     

    




        
    }
}
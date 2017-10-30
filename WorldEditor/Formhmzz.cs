using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form读取关卡 : Form
    {
        public Form读取关卡(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private MainForm mainForm;

        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public TextBox TextBox关卡
        {
            get
            {
                return this.textBox关卡;
            }
        }

        private void textBox关卡_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox关卡.Text != string.Empty)
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
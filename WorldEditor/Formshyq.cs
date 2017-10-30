using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form预读资源 : Form
    {
        public Form预读资源()
        {
            InitializeComponent();
        }

        public TextBox TextBox资源名
        {
            get
            {
                return this.textBox资源名;
            }
        }

        private void textBox资源名_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox资源名.Text != string.Empty)
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
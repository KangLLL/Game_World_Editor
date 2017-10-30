using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form触发器添加 : Form
    {
        public Form触发器添加(Form配置触发器 form配置触发器)
        {
            InitializeComponent();
            this.form配置触发器 = form配置触发器;
        }

        private Form配置触发器 form配置触发器;

        public TextBox TextBox名字
        {
            get
            {
                return this.textBox名字;
            }
        }

        private bool CheckNameValid()
        {
            foreach (Trigger trigger in this.form配置触发器.ListBox触发器.Items)
            {
                if (this.textBox名字.Text == trigger.Name)
                {
                    return false;
                }
            }
            return true;
        }

        private void textBox名字_TextChanged(object sender, EventArgs e)
        {
            if (this.CheckNameValid())
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
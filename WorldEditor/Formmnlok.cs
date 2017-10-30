using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form隐藏可视层 : Form
    {
        public Form隐藏可视层(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (VisualLayerData visualLayerData in this.mainForm.ListBox可见层.Items)
            {
                this.comboBox操作可视层.Items.Add(visualLayerData);
            }
        }

        private MainForm mainForm;

        public Button Button确定
        {
            get
            {
                return this.button确定;
            }
        }

        public ComboBox ComboBox操作可视层
        {
            get
            {
                return this.comboBox操作可视层;
            }
        }

        private void comboBox操作可视层_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox操作可视层.SelectedIndex != -1)
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form播放MIDI : Form
    {
        public Form播放MIDI(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (object obj in this.mainForm.Form元数据.ListBox音乐.Items)
            {
                this.listBox音乐.Items.Add(obj);
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

        public ListBox ListBox音乐
        {
            get
            {
                return this.listBox音乐;
            }
        }

        public CheckBox CheckBox循环播放
        {
            get
            {
                return this.checkBox循环播放;
            }
        }


        private void listBox音乐_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox音乐.SelectedIndex != -1)
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
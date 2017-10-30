using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form命令添加 : Form
    {
        public Form命令添加(Form配置触发器 form配置触发器)
        {
            InitializeComponent();
            this.form配置触发器 = form配置触发器;
        }

        private Form配置触发器 form配置触发器;

        public Form配置触发器 Form配置触发器
        {
            get
            {
                return this.form配置触发器;
            }
        }

        private CommandType commandType;

        private void button显示文章_Click(object sender, EventArgs e)
        {
            Form显示文章 form显示文章 = new Form显示文章(this.form配置触发器.MainForm);
            if (form显示文章.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[5];
                commandArgs[0] = form显示文章.RadioButtonX变量.Checked;
                if ((bool)commandArgs[0])
                {
                    commandArgs[1] = form显示文章.ComboBoxX变量.SelectedIndex;
                }
                else
                {
                    commandArgs[1] = (int)form显示文章.NumericUpDownX常量.Value;
                }
                commandArgs[2] = form显示文章.RadioButtonY变量.Checked;
                if ((bool)commandArgs[2])
                {
                    commandArgs[3] = form显示文章.ComboBoxY变量.SelectedIndex;
                }
                else
                {
                    commandArgs[3] = (int)form显示文章.NumericUpDownY常量.Value;
                }
                commandArgs[4] = form显示文章.TextBox文章.Text;

                this.commandType = CommandType.ShowMessage;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form显示文章.Dispose();
        }

        private void button播放MIDI_Click(object sender, EventArgs e)
        {
            Form播放MIDI form播放MIDI = new Form播放MIDI(this.form配置触发器.MainForm);
            if (form播放MIDI.ShowDialog() == DialogResult.OK)
            {
                Object[] commandaArgs = new Object[2];
                commandaArgs[0] = form播放MIDI.ListBox音乐.SelectedIndex;
                commandaArgs[1] = form播放MIDI.CheckBox循环播放.Checked;

                this.commandType = CommandType.PlayMidi;

                Command command = new Command(this.commandType, commandaArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form播放MIDI.Dispose();
        }

        private void button暂停游戏逻辑_Click(object sender, EventArgs e)
        {
            //Object[] commandArgs = new Object[0];
            this.commandType = CommandType.PauseGameLogic;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button恢复游戏逻辑_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.ResumeGameLogic;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button暂停MIDI_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.StopMidi;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button播放WAV_Click(object sender, EventArgs e)
        {
            Form播放WAV form播放WAV = new Form播放WAV(this.form配置触发器.MainForm);
            if (form播放WAV.ShowDialog() == DialogResult.OK)
            {
                Object[] commandaArgs = new Object[1];
                commandaArgs[0] = form播放WAV.ListBox音乐.SelectedIndex;

                this.commandType = CommandType.PlayWav;

                Command command = new Command(this.commandType, commandaArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form播放WAV.Dispose();
        }

        private void button读取关卡_Click(object sender, EventArgs e)
        {
            Form读取关卡 form读取关卡 = new Form读取关卡(this.form配置触发器.MainForm);
            if (form读取关卡.ShowDialog() == DialogResult.OK)
            {
                Object[] commandaArgs = new Object[1];
                commandaArgs[0] = form读取关卡.TextBox关卡.Text;

                this.commandType = CommandType.LoadLevel;

                Command command = new Command(this.commandType, commandaArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form读取关卡.Dispose();
        }

        private void button创建游戏单位_Click(object sender, EventArgs e)
        {
            Form创建游戏单位 form创建游戏单位 = new Form创建游戏单位(this.form配置触发器.MainForm);
            if (form创建游戏单位.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[6];
                commandArgs[0] = form创建游戏单位.RadioButtonX变量.Checked;
                if ((bool)commandArgs[0])
                {
                    commandArgs[1] = form创建游戏单位.ComboBoxX变量.SelectedIndex;
                }
                else
                {
                    commandArgs[1] = (int)(form创建游戏单位.NumericUpDownX常量.Value);
                }
                commandArgs[2] = form创建游戏单位.RadioButtonY变量.Checked;
                if ((bool)commandArgs[2])
                {
                    commandArgs[3] = form创建游戏单位.ComboBoxY变量.SelectedIndex;
                }
                else
                {
                    commandArgs[3] = (int)(form创建游戏单位.NumericUpDownY常量.Value);
                }
                commandArgs[4] = form创建游戏单位.ComboBox游戏单位类型.SelectedIndex;

                commandArgs[5] = form创建游戏单位.TextBox名字.Text;

                this.commandType = CommandType.CreateGameUnit;

                Command command = new Command(this.commandType, commandArgs);

                GameUnit gameUnit = new GameUnit((GameUnitType)commandArgs[4], (string)commandArgs[5]);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);
                mapData.GameUnitList.Add(gameUnit);

                this.Close();
            }

            form创建游戏单位.Dispose();
        }

        private void button删除游戏单位_Click(object sender, EventArgs e)
        {
            Form删除游戏单位 form删除游戏单位 = new Form删除游戏单位(this.form配置触发器.MainForm);
            if (form删除游戏单位.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = form删除游戏单位.ComboBox游戏单位类型.SelectedIndex;
                commandArgs[1] = form删除游戏单位.ComboBox名字.SelectedItem as string;

                GameUnit gameUnit = new GameUnit((GameUnitType)(form删除游戏单位.ComboBox游戏单位类型.SelectedIndex), form删除游戏单位.ComboBox名字.SelectedItem as string);

                this.commandType = CommandType.RemoveGameUnit;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                mapData.GameUnitList.Remove(gameUnit);

                this.Close();
            }

            form删除游戏单位.Dispose();
        }

        private void button杀死游戏单位_Click(object sender, EventArgs e)
        {
            Form杀死游戏单位 form杀死游戏单位 = new Form杀死游戏单位(this.form配置触发器.MainForm);
            if (form杀死游戏单位.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = form杀死游戏单位.ComboBox游戏单位类型.SelectedIndex;
                commandArgs[1] = form杀死游戏单位.ComboBox名字.SelectedItem as string;

                this.commandType = CommandType.KillGameUnit;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form杀死游戏单位.Dispose();
        }

        private void button打开玩家输入_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.SetPlayerInputOn;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button关闭玩家输入_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.SetPlayerInputOff;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button设置变量_Click(object sender, EventArgs e)
        {
            Form设置变量 form设置变量 = new Form设置变量(this.form配置触发器.MainForm);
            if (form设置变量.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[3];
                commandArgs[0] = form设置变量.ComboBox操作变量.SelectedIndex;
                commandArgs[1] = form设置变量.RadioButton变量.Checked;
                if ((bool)commandArgs[1])
                {
                    commandArgs[2] = form设置变量.ComboBox变量.SelectedIndex;
                }
                else
                {
                    commandArgs[2] = (int)form设置变量.NumericUpDown常量.Value;
                }

                this.commandType = CommandType.SetVariable;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form设置变量.Dispose();
        }

        private void button变量自加_Click(object sender, EventArgs e)
        {
            Form变量自加 form变量自加 = new Form变量自加(this.form配置触发器.MainForm);
            if (form变量自加.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = form变量自加.ComboBox操作变量.SelectedIndex;
                commandArgs[1] = (int)form变量自加.NumericUpDown操作数.Value;

                this.commandType = CommandType.VariableSelfPlus;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form变量自加.Dispose();
        }

        private void button变量自减_Click(object sender, EventArgs e)
        {
            Form变量自减 form变量自减 = new Form变量自减(this.form配置触发器.MainForm);
            if (form变量自减.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = form变量自减.ComboBox操作变量.SelectedIndex;
                commandArgs[1] = (int)form变量自减.NumericUpDown操作数.Value;

                this.commandType = CommandType.VariableSelfSubtract;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form变量自减.Dispose();
        }

        private void button显示可视层_Click(object sender, EventArgs e)
        {
            Form显示可视层 form显示可视层 = new Form显示可视层(this.form配置触发器.MainForm);
            if (form显示可视层.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[1];
                commandArgs[0] = form显示可视层.ComboBox操作可视层.SelectedIndex;

                this.commandType = CommandType.ShowVisualLayer;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form显示可视层.Dispose();
        }

        private void button隐藏可视层_Click(object sender, EventArgs e)
        {
            Form隐藏可视层 form隐藏可视层 = new Form隐藏可视层(this.form配置触发器.MainForm);
            if (form隐藏可视层.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[1];
                commandArgs[0] = form隐藏可视层.ComboBox操作可视层.SelectedIndex;

                this.commandType = CommandType.HideVisualLayer;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form隐藏可视层.Dispose();
        }

        private void button播放角色动画_Click(object sender, EventArgs e)
        {
            Form播放角色动画 form播放角色动画 = new Form播放角色动画();
            if (form播放角色动画.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[12];
                commandArgs[0] = form播放角色动画.TextBox动画文件名.Text;
                commandArgs[1] = form播放角色动画.TextBox动画序列.Text;
                commandArgs[2] = (int)(form播放角色动画.NumericUpDown开始X.Value);
                commandArgs[3] = (int)(form播放角色动画.NumericUpDown开始Y.Value);
                commandArgs[4] = (int)(form播放角色动画.NumericUpDown终止X.Value);
                commandArgs[5] = (int)(form播放角色动画.NumericUpDown终止Y.Value);
                commandArgs[6] = form播放角色动画.CheckBox重复播放.Checked;

                commandArgs[7] = (int)(form播放角色动画.NumericUpDown水平速度.Value);
                commandArgs[8] = (int)(form播放角色动画.NumericUpDown垂直速度.Value);
                commandArgs[9] = (int)(form播放角色动画.NumericUpDown播放帧数.Value);
                commandArgs[10] = (int)form播放角色动画.NumericUpDown缓慢系数.Value;
                commandArgs[11] = form播放角色动画.RadioButton同步.Checked;
                this.commandType = CommandType.PlayRoleAnimation;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form播放角色动画.Dispose();
        }

        private void button等待_Click(object sender, EventArgs e)
        {
            Form等待 form等待 = new Form等待();
            if (form等待.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[1];
                commandArgs[0] = (int)(form等待.NumericUpDown时间.Value);

                this.commandType = CommandType.Wait;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form等待.Dispose();
        }

        private void button固定摄像机_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.FixCamera;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button移动摄像机_Click(object sender, EventArgs e)
        {
            Form移动摄像机 form移动摄像机 = new Form移动摄像机(this.form配置触发器.MainForm);
            if (form移动摄像机.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[5];

                commandArgs[0] = (int)form移动摄像机.NumericUpDown速度X.Value;
                commandArgs[1] = (int)form移动摄像机.NumericUpDown速度Y.Value;
                commandArgs[2] = (int)form移动摄像机.NumericUpDown终止X.Value;
                commandArgs[3] = (int)form移动摄像机.NumericUpDown终止Y.Value;
                commandArgs[4] = form移动摄像机.CheckBox是否同步.Checked;

                this.commandType = CommandType.MoveCameraPosition;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form移动摄像机.Dispose();
        }

        private void button设置摄像机位置_Click(object sender, EventArgs e)
        {
            Form设置摄像机位置 form设置摄像机位置 = new Form设置摄像机位置();
            if (form设置摄像机位置.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];

                commandArgs[0] = (int)form设置摄像机位置.NumericUpDown坐标X.Value;
                commandArgs[1] = (int)form设置摄像机位置.NumericUpDown坐标Y.Value;


                this.commandType = CommandType.SetCameraPosition;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }

            form设置摄像机位置.Dispose();

        }

        private void button打开背景色_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.EnableBackgroundColor;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button关闭背景色_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.DisableBackgroundColor;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button设置背景色_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;

                Object[] commandArgs = new Object[1];
                commandArgs[0] = color.ToArgb();

                this.commandType = CommandType.SetBackgroundColor;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            colorDialog.Dispose();
        }

        private void button设置单位绘制层_Click(object sender, EventArgs e)
        {
            Form设置单位绘制层 form设置单位绘制层 = new Form设置单位绘制层();
            if (form设置单位绘制层.ShowDialog() == DialogResult.OK)
            {


                Object[] commandArgs = new Object[1];
                commandArgs[0] = (int)form设置单位绘制层.NumericUpDown层数.Value;

                this.commandType = CommandType.SetGameUnitLayerNumber;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form设置单位绘制层.Dispose();
        }

        private void button设置主角坐标_Click(object sender, EventArgs e)
        {
            Form设置主角坐标 form设置主角坐标 = new Form设置主角坐标();
            if (form设置主角坐标.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = (int)form设置主角坐标.NumericUpDownX.Value;
                commandArgs[1] = (int)form设置主角坐标.NumericUpDownY.Value;

                this.commandType = CommandType.SetPlayerPosition;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form设置主角坐标.Dispose();
        }

        private void button保存主角状态_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.SavePlayerStatus;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button恢复主角状态_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.RecoverPlayerStatus;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button开幕_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.CurtainRise;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button闭幕_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.CurtainDrop;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button设置触发器开关_Click(object sender, EventArgs e)
        {
            Form设置触发器开关 form设置触发器开关 = new Form设置触发器开关(this.form配置触发器.MainForm);
            if (form设置触发器开关.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[2];
                commandArgs[0] = form设置触发器开关.ComboBox操作触发器.SelectedIndex;
                commandArgs[1] = form设置触发器开关.RadioButton打开.Checked;

                this.commandType = CommandType.SetTriggerSwitch;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form设置触发器开关.Dispose();
        }

        private void button预读资源_Click(object sender, EventArgs e)
        {
            Form预读资源 form预读资源 = new Form预读资源();
            if (form预读资源.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[1];
                commandArgs[0] = form预读资源.TextBox资源名.Text;

                this.commandType = CommandType.LoadResource;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form预读资源.Dispose();

        }

        private void button算分_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.CalculateScore;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button完成游戏_Click(object sender, EventArgs e)
        {
            this.commandType = CommandType.ShowCredit;

            Command command = new Command(this.commandType, null);

            this.form配置触发器.ListBox命令.Items.Add(command);
            MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

            this.Close();
        }

        private void button震动_Click(object sender, EventArgs e)
        {
            Form震动 form震动 = new Form震动();
            if (form震动.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[1];
                commandArgs[0] = (int)form震动.NumericUpDown时间.Value;

                this.commandType = CommandType.Shake;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form震动.Dispose();

        }

        private void button收费_Click(object sender, EventArgs e)
        {
            Form收费 form收费 = new Form收费();
            if (form收费.ShowDialog() == DialogResult.OK)
            {
                Object[] commandArgs = new Object[3];
                commandArgs[0] = form收费.TextBox信息.Text;
                commandArgs[1] = form收费.TextBox提示.Text;
                commandArgs[2] = (int)form收费.NumericUpDown费用.Value;

                this.commandType = CommandType.Charge;

                Command command = new Command(this.commandType, commandArgs);

                this.form配置触发器.ListBox命令.Items.Add(command);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventAction.CommandList.Add(command);

                this.Close();
            }
            form收费.Dispose();
        }

        
    }
}
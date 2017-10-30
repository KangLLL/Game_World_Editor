using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form配置触发器 : Form
    {
        public Form配置触发器(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private MainForm mainForm;

        public MainForm MainForm
        {
            get
            {
                return this.mainForm;
            }
        }

        public ListBox ListBox触发器
        {
            get
            {
                return this.listBox触发器;
            }
        }

        public ListBox ListBox条件
        {
            get
            {
                return this.listBox条件;
            }
        }

        public ListBox ListBox命令
        {
            get
            {
                return this.listBox命令;
            }
        }

        public void DisableEdit()
        {
            this.comboBox事件类型.Enabled = false;
            this.button触发器删除.Enabled = false;
            this.listBox条件.Enabled = false;
            this.button条件添加.Enabled = false;
            this.button条件删除.Enabled = false;
            this.listBox命令.Enabled = false;
            this.button命令添加.Enabled = false;
            this.button命令删除.Enabled = false;
        }

        public void ClearListBox()
        {
            this.listBox命令.Items.Clear();
            this.listBox条件.Items.Clear();
        }

        private void FillListBox()
        {
            Trigger trigger = this.listBox触发器.SelectedItem as Trigger;
            GameEventType gameEventType = trigger.GameEventType;
            this.comboBox事件类型.SelectedIndex = (int)gameEventType;
            List<GameEventCondition> gameEventConditionList = trigger.GameEventConditionList;
            foreach (GameEventCondition gameEventCondition in gameEventConditionList)
            {
                this.listBox条件.Items.Add(gameEventCondition);
            }
            GameEventAction gameEventAction = trigger.GameEventAction;
            List<Command> commandList = gameEventAction.CommandList; 
            foreach (Command command in commandList)
            {
                this.listBox命令.Items.Add(command);
            }
        }


        
        private void button条件添加_Click(object sender, EventArgs e)
        {
            //Trigger trigger = this.listBox触发器.SelectedItem as Trigger;
            Form触发条件添加 form触发条件添加 = new Form触发条件添加(this);
            form触发条件添加.ShowDialog();
        }

        private void button命令添加_Click(object sender, EventArgs e)
        {
            //Trigger trigger = this.listBox触发器.SelectedItem as Trigger;
            Form命令添加 form命令添加 = new Form命令添加(this);
            form命令添加.ShowDialog();
        }

        private void listBox触发器_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox触发器.SelectedIndex != -1)
            {
                this.button触发器删除.Enabled = true;
                this.comboBox事件类型.Enabled = true;
                this.listBox条件.Enabled = true;
                this.button条件添加.Enabled = true;
                this.listBox命令.Enabled = true;
                this.button命令添加.Enabled = true;
                this.ClearListBox();
                this.FillListBox();
            }
            else
            {
                this.button触发器删除.Enabled = false;
                this.comboBox事件类型.Enabled = false;
                this.listBox条件.Enabled = false;
                this.button条件添加.Enabled = false;
                this.listBox命令.Enabled = false;
                this.button命令添加.Enabled = false;
                this.ClearListBox();
            }

            this.button条件删除.Enabled = false;
            this.button命令删除.Enabled = false;
            this.button命令上移.Enabled = false;
            this.button命令下移.Enabled = false;
            this.button编辑.Enabled = false;

        }

        private void listBox触发器_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            Trigger trigger = this.listBox触发器.Items[e.Index] as Trigger;
            graphics.DrawString(trigger.Name, e.Font, Brushes.Black, e.Bounds);
        }

        private void comboBox事件类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trigger trigger = this.listBox触发器.SelectedItem as Trigger;
            //switch (this.comboBox事件类型.SelectedIndex)
            //{
            //    case 0:
            //        {
            //            trigger.GameEventType = GameEventType.LevelInitialization;
            //        }
            //        break;
            //    case 1:
            //        {
            //            trigger.GameEventType = GameEventType.GameUnitEnterLogicRegion;
            //        }
            //        break;
            //    case 2:
            //        {
            //            trigger.GameEventType = GameEventType.GameUnitLeaveLogicRegion;
            //        }
            //        break;
            //    case 3:
            //        {
            //            trigger.GameEventType = GameEventType.GameUnitDie;
            //        }
            //        break;
            //    default:
            //        break;
            //}
            trigger.GameEventType = (GameEventType)(this.comboBox事件类型.SelectedIndex);
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            mapData.TriggerList[this.listBox触发器.SelectedIndex].GameEventType = (GameEventType)(this.comboBox事件类型.SelectedIndex); 
        }

        private void listBox条件_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            GameEventCondition gameEventCondition = this.listBox条件.Items[e.Index] as GameEventCondition;
            string drawString = string.Empty;
            switch (gameEventCondition.GameEventConditionType)
            {
                case GameEventConditionType.VariableCompareValue:
                    {
                        string function = string.Empty;
                        switch ((CompareFunction)(gameEventCondition.GameEventConditionArgs[2]))
                        {
                            case CompareFunction.Equal:
                                {
                                    function = " = ";
                                }
                                break;
                            case CompareFunction.NotEqual:
                                {
                                    function = " != ";
                                }
                                break;
                            case CompareFunction.Greater:
                                {
                                    function = " > ";
                                }
                                break;
                            case CompareFunction.GreaterEqual:
                                {
                                    function = " >= ";
                                }
                                break;
                            case CompareFunction.Less:
                                {
                                    function = " < ";
                                }
                                break;
                            case CompareFunction.LessEqual:
                                {
                                    function = " <= ";
                                }
                                break;
                            default:
                                break;
                        }
                        string name;
                        if ((int)(gameEventCondition.GameEventConditionArgs[0]) != -1)
                        {
                            EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(gameEventCondition.GameEventConditionArgs[0])] as EventVariable;
                            name = eventVariable.Name;
                        }
                        else
                        {
                            name = "已删除的变量 ";
                        }
                        drawString = name + function + gameEventCondition.GameEventConditionArgs[1];
                    }
                    break;
                case GameEventConditionType.VariableCompareVariable:
                    {
                        string function = string.Empty;
                        switch ((CompareFunction)(gameEventCondition.GameEventConditionArgs[2]))
                        {
                            case CompareFunction.Equal:
                                {
                                    function = " = ";
                                }
                                break;
                            case CompareFunction.NotEqual:
                                {
                                    function = " != ";
                                }
                                break;
                            case CompareFunction.Greater:
                                {
                                    function = " > ";
                                }
                                break;
                            case CompareFunction.GreaterEqual:
                                {
                                    function = " >= ";
                                }
                                break;
                            case CompareFunction.Less:
                                {
                                    function = " < ";
                                }
                                break;
                            case CompareFunction.LessEqual:
                                {
                                    function = " <= ";
                                }
                                break;
                            default:
                                break;
                        }
                        string name1, name2;
                        if ((int)(gameEventCondition.GameEventConditionArgs[0]) != -1)
                        {
                            EventVariable eventVariable1 = this.mainForm.Form元数据.ListBox变量.Items[(int)(gameEventCondition.GameEventConditionArgs[0])] as EventVariable;
                            name1 = eventVariable1.Name;
                        }
                        else
                        {
                            name1 = "已删除的变量 ";
                        }
                        if ((int)(gameEventCondition.GameEventConditionArgs[1]) != -1)
                        {
                            EventVariable eventVariable2 = this.mainForm.Form元数据.ListBox变量.Items[(int)(gameEventCondition.GameEventConditionArgs[1])] as EventVariable;
                            name2 = eventVariable2.Name;
                        }
                        else
                        {
                            name2 = "已删除的变量 ";
                        }
                        drawString = name1 + function + name2;
                        //drawString = ((EventVariable)(gameEventCondition.GameEventConditionArgs[0])).Name + function + ((EventVariable)(gameEventCondition.GameEventConditionArgs[1])).Name;
                    }
                    break;
                case GameEventConditionType.EventRegion:
                    {
                        string name;
                        int left, top, right, bottom;
                        MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
                        if ((int)(gameEventCondition.GameEventConditionArgs[0]) != -1)
                        {
                            EventRegion eventRegion = mapData.LogicLayer.EventRegionList[(int)(gameEventCondition.GameEventConditionArgs[0])];
                            name = eventRegion.Name;
                            left = eventRegion.RegionRect.Left;
                            top = eventRegion.RegionRect.Top;
                            right = eventRegion.RegionRect.Right;
                            bottom = eventRegion.RegionRect.Bottom;
                        }
                        else
                        {
                            name = "已删除的区域";
                            left = top = right = bottom = 0;
                        }
                        drawString = name + " (" + left + "," + top + "," + right + "," + bottom + ")";
                    }
                    break;
                case GameEventConditionType.GameUnit:
                    {
                        switch ((GameUnitType)(gameEventCondition.GameEventConditionArgs[0]))
                        {
                            case GameUnitType.Player:
                                {
                                    drawString = "游戏主角";
                                }
                                break;
                            case GameUnitType.Boss:
                                {
                                    drawString = "大反派";
                                }
                                break;
                            case GameUnitType.Mummy:
                                {
                                    drawString = "木乃伊";
                                }
                                break;
                            case GameUnitType.Bat:
                                {
                                    drawString = "蝙蝠";
                                }
                                break;
                            case GameUnitType.Raven:
                                {
                                    drawString = "大嘴乌鸦";
                                }
                                break;
                            case GameUnitType.Monkey:
                                {
                                    drawString = "呆呆机器猴";
                                }
                                break;
                            case GameUnitType.Mushroom:
                                {
                                    drawString = "蘑菇";
                                }
                                break;
                            case GameUnitType.UFO:
                                {
                                    drawString = "飞碟";
                                }
                                break;
                            case GameUnitType.LaserRobot:
                                {
                                    drawString = "激光机器人";
                                }
                                break;
                            case GameUnitType.BitRobot:
                                {
                                    drawString = "钻头机器人";
                                }
                                break;
                            case GameUnitType.Corpse:
                                {
                                    drawString = "可爱僵尸";
                                }
                                break;
                            case GameUnitType.KingKong:
                                {
                                    drawString = "金刚";
                                }
                                break;
                            case GameUnitType.Crystal:
                                {
                                    drawString = "灵魔水晶";
                                }
                                break;
                            case GameUnitType.FlightVehicle:
                                {
                                    drawString = "飞行器";
                                }
                                break;
                            case GameUnitType.SpiderBomb:
                                {
                                    drawString = "蜘蛛炸弹";
                                }
                                break;
                            case GameUnitType.Ninja:
                                {
                                    drawString = "忍者";
                                }
                                break;
                            case GameUnitType.Clown:
                                {
                                    drawString = "小丑";
                                }
                                break;
                            case GameUnitType.Hunk:
                                {
                                    drawString = "绿巨人";
                                }
                                break;
                            case GameUnitType.Bee:
                                {
                                    drawString ="蜜蜂";
                                }
                                break;
                            case GameUnitType.Heart:
                                {
                                    drawString = "桃心";
                                }  
                                break;                       
                            case GameUnitType.Coin:
                                {
                                    drawString ="铜钱";
                                }
                                break;
                            case GameUnitType.Silver:
                                {
                                    drawString = "银锭";
                                }
                                break;
                            case GameUnitType.Gold:
                                {
                                    drawString="金元宝";
                                }
                                break;










                            default:
                                break;
                        }
                        string name = (string)(gameEventCondition.GameEventConditionArgs[1]);
                        drawString += name;
                    }
                    break;
                default:
                    break;
            }

            //Console.WriteLine(drawString);
            graphics.DrawString(drawString, e.Font, Brushes.Black, e.Bounds);
        }

        private void button触发器添加_Click(object sender, EventArgs e)
        {
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            Form触发器添加 form触发器添加 = new Form触发器添加(this);
            if (form触发器添加.ShowDialog() == DialogResult.OK)
            {
                Trigger trigger = new Trigger(form触发器添加.TextBox名字.Text);
                mapData.TriggerList.Add(trigger);
                this.listBox触发器.Items.Add(trigger);
                this.listBox触发器.Invalidate();
            }
            form触发器添加.Dispose();
        }

        private void button触发器删除_Click(object sender, EventArgs e)
        {
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            if (MessageBox.Show("真的要删除此触发器","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                mapData.TriggerList.RemoveAt(this.listBox触发器.SelectedIndex);
                this.listBox触发器.Items.RemoveAt(this.listBox触发器.SelectedIndex);
                this.ClearListBox();
                this.listBox触发器.Invalidate();
            }
        }

        private void listBox条件_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox条件.SelectedIndex != -1)
            {
                this.button条件删除.Enabled = true;
            }
            else
            {
                this.button条件删除.Enabled = false;
            }
        }

        private void button条件删除_Click(object sender, EventArgs e)
        {
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            Trigger trigger = this.listBox触发器.SelectedItem as Trigger;
            if (MessageBox.Show("真的要删除此条件", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                trigger.GameEventConditionList.RemoveAt(this.listBox条件.SelectedIndex);
                this.listBox条件.Items.RemoveAt(this.listBox条件.SelectedIndex);
            }
        }

        private void listBox命令_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            Graphics graphics = e.Graphics;
            Command command = this.listBox命令.Items[e.Index] as Command;
            string drawString = string.Empty;
            switch (command.TypeID)
            {
                case CommandType.ShowMessage:
                    {
                        drawString = "显示文章";
                    }
                    break;
                case CommandType.PauseGameLogic:
                    {
                        drawString = "暂停游戏逻辑";
                    }
                    break;
                case CommandType.ResumeGameLogic:
                    {
                        drawString = "恢复游戏逻辑";
                    }
                    break;
                case CommandType.PlayMidi:
                    {
                        drawString = "播放MIDI音乐:";
                        Object[] commandArgs = command.CommandArgs;
                        int index = (int)commandArgs[0];
                        drawString += this.mainForm.Form元数据.ListBox音乐.Items[index];
                    }
                    break;
                case CommandType.StopMidi:
                    {
                        drawString = "暂停MIDI音乐";
                    }
                    break;
                case CommandType.PlayWav:
                    {
                        drawString = "播放WAV音乐:";
                        Object[] commandArgs = command.CommandArgs;
                        int index = (int)commandArgs[0];
                        drawString += this.mainForm.Form元数据.ListBox音效.Items[index];
                    }
                    break;
                case CommandType.LoadLevel:
                    {
                        drawString = "读取关卡:";
                        string name = (string)(command.CommandArgs[0]);
                        drawString += name;
                    }
                    break;
                case CommandType.CreateGameUnit:
                    {
                        string positionX;
                        if ((bool)(command.CommandArgs[0]))
                        {
                            EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[1])] as EventVariable;
                            positionX = eventVariable.Name;
                        }
                        else
                        {
                            positionX = ((int)(command.CommandArgs[1])).ToString();
                        }
                        string positionY;
                        if ((bool)(command.CommandArgs[2]))
                        {
                            EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[3])] as EventVariable;
                            positionY = eventVariable.Name;
                        }
                        else
                        {
                            positionY = ((int)(command.CommandArgs[3])).ToString();
                        }
                        string gameUnitName = string.Empty;
                        switch ((GameUnitType)command.CommandArgs[4])
                        {
                            case GameUnitType.Player:
                                {
                                    gameUnitName = "游戏主角";
                                }
                                break;
                            case GameUnitType.Boss:
                                {
                                    gameUnitName = "大反派";
                                }
                                break;
                            case GameUnitType.Mummy:
                                {
                                    gameUnitName = "木乃伊";
                                }
                                break;
                            case GameUnitType.Bat:
                                {
                                    gameUnitName = "蝙蝠";
                                }
                                break;
                            case GameUnitType.Raven:
                                {
                                    gameUnitName = "大嘴乌鸦";
                                }
                                break;
                            case GameUnitType.Monkey:
                                {
                                    gameUnitName = "呆呆机器猴";
                                }
                                break;
                            case GameUnitType.Mushroom:
                                {
                                    gameUnitName = "蘑菇";
                                }
                                break;
                            case GameUnitType.UFO:
                                {
                                    gameUnitName = "飞碟";
                                }
                                break;
                            case GameUnitType.LaserRobot:
                                {
                                    gameUnitName = "激光机器人";
                                }
                                break;
                            case GameUnitType.BitRobot:
                                {
                                    gameUnitName = "钻头机器人";
                                }
                                break;
                            case GameUnitType.Corpse:
                                {
                                    gameUnitName = "可爱僵尸";
                                }
                                break;
                            case GameUnitType.KingKong:
                                {
                                    gameUnitName = "金刚";
                                }
                                break;
                            case GameUnitType.Crystal:
                                {
                                    gameUnitName = "灵魔水晶";
                                }
                                break;
                            case GameUnitType.FlightVehicle:
                                {
                                    gameUnitName = "飞行器";
                                }
                                break;
                            case GameUnitType.SpiderBomb:
                                {
                                    gameUnitName = "蜘蛛炸弹";
                                }
                                break;
                            case GameUnitType.Ninja:
                                {
                                    gameUnitName = "忍者";
                                }
                                break;
                            case GameUnitType.Clown:
                                {
                                    gameUnitName = "小丑";
                                }
                                break;
                            case GameUnitType.Hunk:
                                {
                                    gameUnitName = "绿巨人";
                                }
                                break;
                            case GameUnitType.Bee:
                                {
                                    gameUnitName = "蜜蜂";
                                }
                                break;
                            case GameUnitType.Heart:
                                {
                                    gameUnitName = "桃心";
                                }
                                break;
                            case GameUnitType.Coin:
                                {
                                    gameUnitName = "铜钱";
                                }
                                break;
                            case GameUnitType.Silver:
                                {
                                    gameUnitName = "银锭";
                                }
                                break;
                            case GameUnitType.Gold:
                                {
                                    gameUnitName = "金元宝";
                                }
                                break;
                            default:
                                break;
                        }
                        drawString = "在(" + positionX + "," + positionY + ")创建一个名为" + (string)(command.CommandArgs[5]) + "的" + gameUnitName;

                    }
                    break;
                case CommandType.RemoveGameUnit:
                    {
                        string gameUnitName = string.Empty;
                        switch ((GameUnitType)command.CommandArgs[0])
                        {
                            case GameUnitType.Player:
                                {
                                    gameUnitName = "游戏主角";
                                }
                                break;
                            case GameUnitType.Boss:
                                {
                                    gameUnitName = "大反派";
                                }
                                break;
                            case GameUnitType.Mummy:
                                {
                                    gameUnitName = "木乃伊";
                                }
                                break;
                            case GameUnitType.Bat:
                                {
                                    gameUnitName = "蝙蝠";
                                }
                                break;
                            case GameUnitType.Raven:
                                {
                                    gameUnitName = "大嘴乌鸦";
                                }
                                break;
                            case GameUnitType.Monkey:
                                {
                                    gameUnitName = "呆呆机器猴";
                                }
                                break;
                            case GameUnitType.Mushroom:
                                {
                                    gameUnitName = "蘑菇";
                                }
                                break;
                            case GameUnitType.UFO:
                                {
                                    gameUnitName = "飞碟";
                                }
                                break;
                            case GameUnitType.LaserRobot:
                                {
                                    gameUnitName = "激光机器人";
                                }
                                break;
                            case GameUnitType.BitRobot:
                                {
                                    gameUnitName = "钻头机器人";
                                }
                                break;
                            case GameUnitType.Corpse:
                                {
                                    gameUnitName = "可爱僵尸";
                                }
                                break;
                            case GameUnitType.KingKong:
                                {
                                    gameUnitName = "金刚";
                                }
                                break;
                            case GameUnitType.Crystal:
                                {
                                    gameUnitName = "灵魔水晶";
                                }
                                break;
                            case GameUnitType.FlightVehicle:
                                {
                                    gameUnitName = "飞行器";
                                }
                                break;
                            case GameUnitType.SpiderBomb:
                                {
                                    gameUnitName = "蜘蛛炸弹";
                                }
                                break;
                            case GameUnitType.Ninja:
                                {
                                    gameUnitName = "忍者";
                                }
                                break;
                            case GameUnitType.Clown:
                                {
                                    gameUnitName = "小丑";
                                }
                                break;
                            case GameUnitType.Hunk:
                                {
                                    gameUnitName = "绿巨人";
                                }
                                break;
                            case GameUnitType.Bee:
                                {
                                    gameUnitName = "蜜蜂";
                                }
                                break;
                            case GameUnitType.Heart:
                                {
                                    gameUnitName = "桃心";
                                }
                                break;
                            case GameUnitType.Coin:
                                {
                                    gameUnitName = "铜钱";
                                }
                                break;
                            case GameUnitType.Silver:
                                {
                                    gameUnitName = "银锭";
                                }
                                break;
                            case GameUnitType.Gold:
                                {
                                    gameUnitName = "金元宝";
                                }
                                break;
                            default:
                                break;
                        }
                        drawString = "删除一个名为" + (string)(command.CommandArgs[1]) + "的" + gameUnitName;
                    }
                    break;
                case CommandType.KillGameUnit:
                    {
                        string gameUnitName = string.Empty;
                        switch ((GameUnitType)command.CommandArgs[0])
                        {
                            case GameUnitType.Player:
                                {
                                    gameUnitName = "游戏主角";
                                }
                                break;
                            case GameUnitType.Boss:
                                {
                                    gameUnitName = "大反派";
                                }
                                break;
                            case GameUnitType.Mummy:
                                {
                                    gameUnitName = "木乃伊";
                                }
                                break;
                            case GameUnitType.Bat:
                                {
                                    gameUnitName = "蝙蝠";
                                }
                                break;
                            case GameUnitType.Raven:
                                {
                                    gameUnitName = "大嘴乌鸦";
                                }
                                break;
                            case GameUnitType.Monkey:
                                {
                                    gameUnitName = "呆呆机器猴";
                                }
                                break;
                            case GameUnitType.Mushroom:
                                {
                                    gameUnitName = "蘑菇";
                                }
                                break;
                            case GameUnitType.UFO:
                                {
                                    gameUnitName = "飞碟";
                                }
                                break;
                            case GameUnitType.LaserRobot:
                                {
                                    gameUnitName = "激光机器人";
                                }
                                break;
                            case GameUnitType.BitRobot:
                                {
                                    gameUnitName = "钻头机器人";
                                }
                                break;
                            case GameUnitType.Corpse:
                                {
                                    gameUnitName = "可爱僵尸";
                                }
                                break;
                            case GameUnitType.KingKong:
                                {
                                    gameUnitName = "金刚";
                                }
                                break;
                            case GameUnitType.Crystal:
                                {
                                    gameUnitName = "灵魔水晶";
                                }
                                break;
                            case GameUnitType.FlightVehicle:
                                {
                                    gameUnitName = "飞行器";
                                }
                                break;
                            case GameUnitType.SpiderBomb:
                                {
                                    gameUnitName = "蜘蛛炸弹";
                                }
                                break;
                            case GameUnitType.Ninja:
                                {
                                    gameUnitName = "忍者";
                                }
                                break;
                            case GameUnitType.Clown:
                                {
                                    gameUnitName = "小丑";
                                }
                                break;
                            case GameUnitType.Hunk:
                                {
                                    gameUnitName = "绿巨人";
                                }
                                break;
                            case GameUnitType.Bee:
                                {
                                    gameUnitName = "蜜蜂";
                                }
                                break;
                            case GameUnitType.Heart:
                                {
                                    gameUnitName = "桃心";
                                }
                                break;
                            default:
                                break;
                        }
                        drawString = "杀死一个名为" + (string)(command.CommandArgs[1]) + "的" + gameUnitName;
                    }
                    break;
                case CommandType.SetPlayerInputOn:
                    {
                        drawString = "打开玩家输入";
                    }
                    break;
                case CommandType.SetPlayerInputOff:
                    {
                        drawString = "关闭玩家输入";
                    }
                    break;
                case CommandType.SetVariable:
                    {
                        EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[0])] as EventVariable;
                        drawString = "设置变量" + eventVariable.Name + " = ";
                        if ((bool)(command.CommandArgs[1]))
                        {
                            eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[2])] as EventVariable;
                            drawString += eventVariable.Name;
                        }
                        else
                        {
                            drawString += (int)(command.CommandArgs[2]);
                        }
                    }
                    break;
                case CommandType.VariableSelfPlus:
                    {
                        EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[0])] as EventVariable;
                        drawString = "变量" + eventVariable.Name + "自加" + (int)(command.CommandArgs[1]);
                    }
                    break;
                case CommandType.VariableSelfSubtract:
                    {
                        EventVariable eventVariable = this.mainForm.Form元数据.ListBox变量.Items[(int)(command.CommandArgs[0])] as EventVariable;
                        drawString = "变量" + eventVariable.Name + "自减" + (int)(command.CommandArgs[1]);
                    }
                    break;
                case CommandType.ShowVisualLayer:
                    {
                        MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
                        VisualLayerData visualLayerData = mapData.VisualLayerDataList[(int)(command.CommandArgs[0])];
                        drawString = "显示可视层" + visualLayerData.Name;
                    }
                    break;
                case CommandType.HideVisualLayer:
                    {
                        MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
                        VisualLayerData visualLayerData = mapData.VisualLayerDataList[(int)(command.CommandArgs[0])];
                        drawString = "隐藏可视层" + visualLayerData.Name;
                    }
                    break;
                case CommandType.PlayRoleAnimation:
                    {
                        string filename = (string)(command.CommandArgs[0]);
                        string animationName = (string)(command.CommandArgs[1]);
                        int startX = (int)(command.CommandArgs[2]);
                        int startY= (int)(command.CommandArgs[3]);
                        int endX = (int)(command.CommandArgs[4]);
                        int endY = (int)(command.CommandArgs[5]);
                        bool loop = (bool)(command.CommandArgs[6]);
                        int speedX= (int)(command.CommandArgs[7]);
                        int speedY = (int)(command.CommandArgs[8]);
                        int frameCount = (int)(command.CommandArgs[9]);
                        int slowTimes = (int)(command.CommandArgs[10]);
                        bool sym = (bool)(command.CommandArgs[11]);
                        if (sym)
                        {
                            drawString = "同步 播放" + filename + " 动画" + animationName + " 起始坐标X(" + startX + ")Y(" + startY + ") 终止坐标X(" + endX + ")Y(" + endY + ") 速度(" + speedX + ")Y(" + speedY + ") 帧数(" + frameCount + ") 缓慢系数(" + slowTimes + ")";
                        }
                        else
                        {
                            drawString = "异步 播放" + filename + " 动画" + animationName + " 起始坐标X(" + startX + ")Y(" + startY + ") 终止坐标X(" + endX + ")Y(" + endY + ") 速度(" + speedX + ")Y(" + speedY + ") 帧数(" + frameCount + ") 缓慢系数(" + slowTimes + ")";
                        }
                    
                    
                    }
                    break;
                case CommandType.Wait:
                    {
                        drawString = "等待" + (int)(command.CommandArgs[0]) + "帧";
                    }
                    break;
                case CommandType.FixCamera:
                    {
                        drawString = "设置摄像机为跟随模式";
                    }
                    break;
                case CommandType.MoveCameraPosition:
                    {
                        bool sym = (bool)(command.CommandArgs[4]);
                        if (sym)
                        {
                            drawString = "同步 以速度X(" + (int)(command.CommandArgs[0]) + ") Y(" + (int)(command.CommandArgs[1]) + ") 移动摄像机到X(" + (int)(command.CommandArgs[2]) + ") Y(" + (int)(command.CommandArgs[3]) + ")的位置";
                        }
                        else
                        {
                            drawString = "异步 以速度X(" + (int)(command.CommandArgs[0]) + ") Y(" + (int)(command.CommandArgs[1]) + ") 移动摄像机到X(" + (int)(command.CommandArgs[2]) + ") Y(" + (int)(command.CommandArgs[3]) + ")的位置";
                        }
                    }
                    break;
                case CommandType.SetCameraPosition:
                    {
                        drawString = "设置摄像机位置到X(" + (int)(command.CommandArgs[0]) + ")Y(" + (int)(command.CommandArgs[1]) +  ")";

                    }
                    break;
                case CommandType.EnableBackgroundColor:
                    {
                        drawString = "使用背景色填充";

                    }
                    break;
                case CommandType.DisableBackgroundColor:
                    {
                        drawString = "关闭背景色填充";
                    }
                    break;
                case CommandType.SetBackgroundColor:
                    {
                        drawString = "设置背景色为0x" + ((int)(command.CommandArgs[0])).ToString("X");

                    }
                    break;
                case CommandType.SetGameUnitLayerNumber:
                    {
                        drawString = "设置单位绘制层为：" + ((int)(command.CommandArgs[0])).ToString();
                    }
                    break;
                case CommandType.SetPlayerPosition:
                    {
                        drawString = "设置主角坐标为: " + "X: " + ((int)(command.CommandArgs[0])).ToString() +" , "+ "Y: " + ((int)(command.CommandArgs[1])).ToString();
                    }
                    break;
                case CommandType.SavePlayerStatus:
                    {
                        drawString = "保存主角状态";
                    }
                    break;
                case CommandType.RecoverPlayerStatus:
                    {
                        drawString = "恢复主角状态";
                    }
                    break;
                case CommandType.CurtainRise:
                    {
                        drawString = "开幕";
                    }
                    break;
                case CommandType.CurtainDrop:
                    {
                        drawString = "闭幕";
                    }
                    break;
                case CommandType.SetTriggerSwitch:
                    {
                        MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
                        Trigger trigger = mapData.TriggerList[(int)(command.CommandArgs[0])];
                        string triggerName = trigger.Name;
                        string action;
                        if ((bool)(command.CommandArgs[1]))
                        {
                            action = "打开";
                        }
                        else
                        {
                            action = "关闭";
                        }
                        drawString = action + "触发器： " + triggerName;
                    }
                    break;
                case CommandType.LoadResource:
                    {
                        string resourceName = (string)command.CommandArgs[0];
                        drawString = "读取" + resourceName + "的资源";
                    }
                    break;
                case CommandType.CalculateScore:
                    {
                        drawString = "记算得分";
                    }
                    break;
                case CommandType.ShowCredit:
                    {
                        drawString = "显示封底";
                    }
                    break;
                case CommandType.Shake:
                    {
                        drawString = "震动" + (int)(command.CommandArgs[0]) + "帧";
                    }
                    break;
                case CommandType.Charge:
                    {
                        drawString = "收取" + (int)(command.CommandArgs[2]) + "元费用";
                    }
                    break;
                default:
                    break;
            }
            graphics.DrawString(drawString, e.Font, Brushes.Black, e.Bounds);
        }

        private void listBox命令_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox命令.SelectedIndex != -1)
            {
                this.button命令删除.Enabled = true;
                Command command = this.listBox命令.SelectedItem as Command;
                CommandType commandType = command.TypeID;
                if (commandType == CommandType.PauseGameLogic || commandType == CommandType.ResumeGameLogic || commandType == CommandType.StopMidi || commandType == CommandType.SetPlayerInputOn || commandType == CommandType.SetPlayerInputOff || commandType == CommandType.FixCamera || commandType == CommandType.EnableBackgroundColor || commandType == CommandType.DisableBackgroundColor || commandType == CommandType.SavePlayerStatus || commandType == CommandType.RecoverPlayerStatus || commandType == CommandType.CurtainRise || commandType == CommandType.CurtainDrop || commandType == CommandType.CalculateScore || commandType == CommandType.ShowCredit)
                {
                    this.button编辑.Enabled = false;
                }
                else
                {
                    this.button编辑.Enabled = true;
                }

                if (this.listBox命令.SelectedIndex == this.listBox命令.Items.Count - 1)
                {
                    this.button命令下移.Enabled = false;
                }
                else
                {
                    this.button命令下移.Enabled = true;
                }
                if (this.listBox命令.SelectedIndex == 0)
                {
                    this.button命令上移.Enabled = false;
                }
                else
                {
                    this.button命令上移.Enabled = true;
                }
            }
            else
            {
                this.button命令删除.Enabled = false;
                this.button编辑.Enabled = false;
                this.button命令上移.Enabled = false;
                this.button命令下移.Enabled = false;
            }
        }

        private void button命令删除_Click(object sender, EventArgs e)
        {
            Command command = this.listBox命令.SelectedItem as Command;
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            if (MessageBox.Show("真的要删除此命令", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.listBox命令.Items.Remove(command);
                if (command.TypeID == CommandType.CreateGameUnit)
                {
                    GameUnitType type = (GameUnitType)command.CommandArgs[4];
                    String name = (String)command.CommandArgs[5];
                    mapData.DelCreatedGameUnit(type, name);
                }
                mapData.TriggerList[this.listBox触发器.SelectedIndex].GameEventAction.CommandList.Remove(command);
            }
        }

        private void button命令上移_Click(object sender, EventArgs e)
        {
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            Trigger trigger = mapData.TriggerList[this.listBox触发器.SelectedIndex];
            Command command1 = this.listBox命令.Items[this.listBox命令.SelectedIndex] as Command;
            Command command2 = this.listBox命令.Items[this.listBox命令.SelectedIndex - 1] as Command;
            this.listBox命令.Items[this.listBox命令.SelectedIndex] = command2;
            this.listBox命令.Items[this.listBox命令.SelectedIndex - 1] = command1;
            
            trigger.GameEventAction.CommandList.Insert(this.ListBox命令.SelectedIndex - 1, command1);
            trigger.GameEventAction.CommandList.RemoveAt(this.ListBox命令.SelectedIndex + 1);

            this.listBox命令.SelectedIndex--;

        }

        private void button命令下移_Click(object sender, EventArgs e)
        {
            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;
            Trigger trigger = mapData.TriggerList[this.listBox触发器.SelectedIndex];
            Command command1 = this.listBox命令.Items[this.listBox命令.SelectedIndex] as Command;
            Command command2 = this.listBox命令.Items[this.listBox命令.SelectedIndex + 1] as Command;
            this.listBox命令.Items[this.listBox命令.SelectedIndex] = command2;
            this.listBox命令.Items[this.listBox命令.SelectedIndex + 1] = command1;
           

            trigger.GameEventAction.CommandList.Insert(this.ListBox命令.SelectedIndex, command2);
            trigger.GameEventAction.CommandList.RemoveAt(this.ListBox命令.SelectedIndex + 2);

            this.listBox命令.SelectedIndex++;
        }

        private void button编辑_Click(object sender, EventArgs e)
        {
            Command command = this.listBox命令.SelectedItem as Command;

            switch (command.TypeID)
            {
                case CommandType.ShowMessage:
                    {
                        Form显示文章 form = new Form显示文章(this.mainForm);
                        form.RadioButtonX变量.Checked = (bool)(command.CommandArgs[0]);
                        if (form.RadioButtonX变量.Checked)
                        {
                            form.ComboBoxX变量.Enabled = true;
                            form.ComboBoxX变量.SelectedItem = (int)(command.CommandArgs[1]);
                            form.NumericUpDownX常量.Enabled = false;
                        }
                        else
                        {
                            form.ComboBoxX变量.Enabled = false;
                            form.NumericUpDownX常量.Enabled = true;
                            form.NumericUpDownX常量.Value = (int)(command.CommandArgs[1]);
                        }
                        form.RadioButtonY变量.Checked = (bool)(command.CommandArgs[2]);
                        if (form.RadioButtonY变量.Checked)
                        {
                            form.ComboBoxY变量.Enabled = true;
                            form.ComboBoxY变量.SelectedItem = (int)(command.CommandArgs[3]);
                            form.NumericUpDownY常量.Enabled = false;
                        }
                        else
                        {
                            form.ComboBoxY变量.Enabled = false;
                            form.NumericUpDownY常量.Enabled = true;
                            form.NumericUpDownY常量.Value = (int)(command.CommandArgs[3]);
                        }
                        form.TextBox文章.Text = (string)(command.CommandArgs[4]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.RadioButtonX变量.Checked;
                            if ((bool)command.CommandArgs[0])
                            {
                                command.CommandArgs[1] = form.ComboBoxX变量.SelectedIndex;
                            }
                            else
                            {
                                command.CommandArgs[1] = (int)form.NumericUpDownX常量.Value;
                            }
                            command.CommandArgs[2] = form.RadioButtonY变量.Checked;
                            if ((bool)command.CommandArgs[2])
                            {
                                command.CommandArgs[3] = form.ComboBoxY变量.SelectedIndex;
                            }
                            else
                            {
                                command.CommandArgs[3] = (int)form.NumericUpDownY常量.Value;
                            }
                            command.CommandArgs[4] = form.TextBox文章.Text;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.PauseGameLogic:
                    break;
                case CommandType.ResumeGameLogic:
                    break;
                case CommandType.PlayMidi:
                    {
                        Form播放MIDI form = new Form播放MIDI(this.mainForm);
                        form.ListBox音乐.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.CheckBox循环播放.Checked = (bool)(command.CommandArgs[1]);
                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ListBox音乐.SelectedIndex;
                            command.CommandArgs[1] = form.CheckBox循环播放.Checked;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.StopMidi:
                    break;
                case CommandType.PlayWav:
                    {
                        Form播放WAV form = new Form播放WAV(this.mainForm);
                        form.ListBox音乐.SelectedIndex = (int)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ListBox音乐.SelectedIndex;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.LoadLevel:
                    {
                        Form读取关卡 form = new Form读取关卡(this.mainForm);
                        form.TextBox关卡.Text = (string)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.TextBox关卡.Text;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.CreateGameUnit:
                    {
                        Form创建游戏单位 form = new Form创建游戏单位(this.mainForm);
                        form.RadioButtonX变量.Checked = (bool)(command.CommandArgs[0]);
                        if (form.RadioButtonX变量.Checked)
                        {
                            form.ComboBoxX变量.Enabled = true;
                            form.ComboBoxX变量.SelectedItem = (int)(command.CommandArgs[1]);
                            form.NumericUpDownX常量.Enabled = false;
                        }
                        else
                        {
                            form.ComboBoxX变量.Enabled = false;
                            form.NumericUpDownX常量.Enabled = true;
                            form.NumericUpDownX常量.Value = (int)(command.CommandArgs[1]);
                        }
                        form.RadioButtonY变量.Checked = (bool)(command.CommandArgs[2]);
                        if (form.RadioButtonY变量.Checked)
                        {
                            form.ComboBoxY变量.Enabled = true;
                            form.ComboBoxY变量.SelectedItem = (int)(command.CommandArgs[3]);
                            form.NumericUpDownY常量.Enabled = false;
                        }
                        else
                        {
                            form.ComboBoxY变量.Enabled = false;
                            form.NumericUpDownY常量.Enabled = true;
                            form.NumericUpDownY常量.Value = (int)(command.CommandArgs[3]);
                        }

                        int oldGameUnitType = (int)(command.CommandArgs[4]);
                        string oldName = (string)(command.CommandArgs[5]);

                        form.ComboBox游戏单位类型.SelectedIndex = oldGameUnitType;
                        form.TextBox名字.Text = oldName;

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.RadioButtonX变量.Checked;
                            if ((bool)command.CommandArgs[0])
                            {
                                command.CommandArgs[1] = form.ComboBoxX变量.SelectedIndex;
                            }
                            else
                            {
                                command.CommandArgs[1] = (int)form.NumericUpDownX常量.Value;
                            }
                            command.CommandArgs[2] = form.RadioButtonY变量.Checked;
                            if ((bool)command.CommandArgs[2])
                            {
                                command.CommandArgs[3] = form.ComboBoxY变量.SelectedIndex;
                            }
                            else
                            {
                                command.CommandArgs[3] = (int)form.NumericUpDownY常量.Value;
                            }

                            int newGameUnitType = form.ComboBox游戏单位类型.SelectedIndex;
                            string newName = form.TextBox名字.Text;

                            command.CommandArgs[4] = newGameUnitType;
                            command.CommandArgs[5] = newName;

                            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;

                            mapData.DelCreatedGameUnit((GameUnitType)oldGameUnitType, oldName);
                            GameUnit gameUnit = new GameUnit((GameUnitType)newGameUnitType, newName);
                            mapData.GameUnitList.Add(gameUnit);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.RemoveGameUnit:
                    {
                        Form删除游戏单位 form = new Form删除游戏单位(this.mainForm);

                        int oldGameUnitType = (int)(command.CommandArgs[0]);
                        string oldName = (string)(command.CommandArgs[1]);
                        form.ComboBox游戏单位类型.SelectedIndex = oldGameUnitType;
                        form.ComboBox名字.SelectedItem = oldName;

                        form.Button确定.Enabled = true;

                        if(form.ShowDialog() == DialogResult.OK)
                        {
                            int newGameUnitType = form.ComboBox游戏单位类型.SelectedIndex;
                            string newName = form.ComboBox名字.SelectedItem as string;
                            command.CommandArgs[0] = newGameUnitType;
                            command.CommandArgs[1] = newName;

                            MapData mapData = this.mainForm.ListBox关卡.SelectedItem as MapData;

                            mapData.DelCreatedGameUnit((GameUnitType)newGameUnitType, newName);
                            GameUnit gameUnit = new GameUnit((GameUnitType)oldGameUnitType, oldName);
                            mapData.GameUnitList.Add(gameUnit);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.KillGameUnit:
                    {
                        Form杀死游戏单位 form = new Form杀死游戏单位(this.mainForm);
                        form.ComboBox游戏单位类型.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.ComboBox名字.SelectedItem = (string)(command.CommandArgs[1]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox游戏单位类型.SelectedIndex;
                            command.CommandArgs[1] = form.ComboBox名字.SelectedItem as string;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.SetPlayerInputOn:
                    break;
                case CommandType.SetPlayerInputOff:
                    break;
                case CommandType.SetVariable:
                    {
                        Form设置变量 form = new Form设置变量(this.mainForm);
                        form.ComboBox操作变量.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.RadioButton变量.Checked = (bool)(command.CommandArgs[1]);
                        if (form.RadioButton变量.Checked)
                        {
                            form.ComboBox变量.Enabled = true;
                            form.ComboBox变量.SelectedIndex = (int)(command.CommandArgs[2]);
                            form.NumericUpDown常量.Enabled = false;
                        }
                        else
                        {
                            form.ComboBox变量.Enabled = false;
                            form.NumericUpDown常量.Enabled = true;
                            form.NumericUpDown常量.Value = (int)(command.CommandArgs[2]);
                        }

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作变量.SelectedIndex;
                            command.CommandArgs[1] = form.RadioButton变量.Checked;
                            if ((bool)(command.CommandArgs[1]))
                            {
                                command.CommandArgs[2] = form.ComboBox变量.SelectedIndex;
                            }
                            else
                            {
                                command.CommandArgs[2] = (int)(form.NumericUpDown常量.Value);
                            }
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.VariableSelfPlus:
                    {
                        Form变量自加 form = new Form变量自加(this.mainForm);
                        form.ComboBox操作变量.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.NumericUpDown操作数.Value = (int)(command.CommandArgs[1]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作变量.SelectedIndex;
                            command.CommandArgs[1] = (int)(form.NumericUpDown操作数.Value);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.VariableSelfSubtract:
                    {
                        Form变量自减 form = new Form变量自减(this.mainForm);
                        form.ComboBox操作变量.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.NumericUpDown操作数.Value = (int)(command.CommandArgs[1]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作变量.SelectedIndex;
                            command.CommandArgs[1] = (int)(form.NumericUpDown操作数.Value);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.ShowVisualLayer:
                    {
                        Form显示可视层 form = new Form显示可视层(this.mainForm);
                        form.ComboBox操作可视层.SelectedIndex = (int)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作可视层.SelectedIndex;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.HideVisualLayer:
                    {
                        Form隐藏可视层 form = new Form隐藏可视层(this.mainForm);
                        form.ComboBox操作可视层.SelectedIndex = (int)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作可视层.SelectedIndex;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.PlayRoleAnimation:
                    {
                        Form播放角色动画 form = new Form播放角色动画();
                        form.TextBox动画文件名.Text = (string)(command.CommandArgs[0]);
                        form.TextBox动画序列.Text = (string)(command.CommandArgs[1]);
                        form.NumericUpDown开始X.Value = (int)(command.CommandArgs[2]);
                        form.NumericUpDown开始Y.Value = (int)(command.CommandArgs[3]);
                        form.NumericUpDown终止X.Value = (int)(command.CommandArgs[4]);
                        form.NumericUpDown终止Y.Value = (int)(command.CommandArgs[5]);
                        form.CheckBox重复播放.Checked = (bool)(command.CommandArgs[6]);
                        form.NumericUpDown水平速度.Value = (int)(command.CommandArgs[7]);
                        form.NumericUpDown垂直速度.Value = (int)(command.CommandArgs[8]);
                        form.NumericUpDown播放帧数.Value = (int)(command.CommandArgs[9]);
                        form.NumericUpDown缓慢系数.Value = (int)(command.CommandArgs[10]);
                        form.RadioButton同步.Checked = (bool)(command.CommandArgs[11]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.TextBox动画文件名.Text;
                            command.CommandArgs[1] = form.TextBox动画序列.Text;
                            command.CommandArgs[2] = (int)(form.NumericUpDown开始X.Value);
                            command.CommandArgs[3] = (int)(form.NumericUpDown开始Y.Value);
                            command.CommandArgs[4] = (int)(form.NumericUpDown终止X.Value);
                            command.CommandArgs[5] = (int)(form.NumericUpDown终止Y.Value);
                            command.CommandArgs[6] = form.CheckBox重复播放.Checked;
                            command.CommandArgs[7] = (int)(form.NumericUpDown水平速度.Value);
                            command.CommandArgs[8] = (int)(form.NumericUpDown垂直速度.Value);
                            command.CommandArgs[9] = (int)(form.NumericUpDown播放帧数.Value);
                            command.CommandArgs[10] = (int)(form.NumericUpDown缓慢系数.Value);
                            command.CommandArgs[11] = form.RadioButton同步.Checked;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.Wait:
                    {
                        Form等待 form = new Form等待();
                        form.NumericUpDown时间.Value = (int)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)form.NumericUpDown时间.Value;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.FixCamera:
                    break;
                case CommandType.MoveCameraPosition:
                    {
                        Form移动摄像机 form = new Form移动摄像机(this.mainForm);
                        form.NumericUpDown速度X.Value = (int)(command.CommandArgs[0]);
                        form.NumericUpDown速度Y.Value = (int)(command.CommandArgs[1]);
                        form.NumericUpDown终止X.Value = (int)(command.CommandArgs[2]);
                        form.NumericUpDown终止Y.Value = (int)(command.CommandArgs[3]);
                        form.CheckBox是否同步.Checked = (bool)(command.CommandArgs[4]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)(form.NumericUpDown速度X.Value);
                            command.CommandArgs[1] = (int)(form.NumericUpDown速度Y.Value);
                            command.CommandArgs[2] = (int)(form.NumericUpDown终止X.Value);
                            command.CommandArgs[3] = (int)(form.NumericUpDown终止Y.Value);
                            command.CommandArgs[4] = form.CheckBox是否同步.Checked;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.SetCameraPosition:
                    {
                        Form设置摄像机位置 form = new Form设置摄像机位置();
                        form.NumericUpDown坐标X.Value = (int)(command.CommandArgs[0]);
                        form.NumericUpDown坐标Y.Value = (int)(command.CommandArgs[1]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)(form.NumericUpDown坐标X.Value);
                            command.CommandArgs[1] = (int)(form.NumericUpDown坐标Y.Value);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.EnableBackgroundColor:
                    break;
                case CommandType.DisableBackgroundColor:
                    break;
                case CommandType.SetBackgroundColor:
                    {
                        ColorDialog colorDialog = new ColorDialog();
                        Color color = Color.FromArgb((int)(command.CommandArgs[0]));
                        colorDialog.Color = color;

                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            color = colorDialog.Color;
                            command.CommandArgs[0] = color.ToArgb();
                        }
                        colorDialog.Dispose();
                    }
                    break;
                case CommandType.SetGameUnitLayerNumber:
                    {
                        Form设置单位绘制层 form = new Form设置单位绘制层();
                        form.NumericUpDown层数.Value = (int)(command.CommandArgs[0]);

                        form.Button确定.Enabled = true;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)(form.NumericUpDown层数.Value);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.SetPlayerPosition:
                    {
                        Form设置主角坐标 form = new Form设置主角坐标();
                        form.NumericUpDownX.Value = (int)(command.CommandArgs[0]);
                        form.NumericUpDownY.Value = (int)(command.CommandArgs[1]);

                        if(form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)(form.NumericUpDownX.Value);
                            command.CommandArgs[1] = (int)(form.NumericUpDownY.Value);
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.SetTriggerSwitch:
                    {
                        Form设置触发器开关 form = new Form设置触发器开关(this.mainForm);
                        form.ComboBox操作触发器.SelectedIndex = (int)(command.CommandArgs[0]);
                        form.RadioButton打开.Checked = (bool)(command.CommandArgs[1]);

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.ComboBox操作触发器.SelectedIndex;
                            command.CommandArgs[1] = form.RadioButton打开.Checked;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.LoadResource:
                    {
                        Form预读资源 form = new Form预读资源();
                        form.TextBox资源名.Text = (string)(command.CommandArgs[0]);

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.TextBox资源名.Text;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.Shake:
                    {
                        Form震动 form = new Form震动();
                        form.NumericUpDown时间.Value = (int)(command.CommandArgs[0]);

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = (int)form.NumericUpDown时间.Value;
                        }
                        form.Dispose();
                    }
                    break;
                case CommandType.Charge:
                    {
                        Form收费 form = new Form收费();
                        form.TextBox信息.Text = (string)command.CommandArgs[0];
                        form.TextBox提示.Text = (string)command.CommandArgs[1];
                        form.NumericUpDown费用.Value = (int)(command.CommandArgs[2]);

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            command.CommandArgs[0] = form.TextBox信息.Text;
                            command.CommandArgs[1] = form.TextBox提示.Text;
                            command.CommandArgs[2] = (int)form.NumericUpDown费用.Value;
                        }
                        form.Dispose();
                    }
                    break;
                default:
                    break;
            }

            this.listBox命令.Invalidate();
        }

    }
}
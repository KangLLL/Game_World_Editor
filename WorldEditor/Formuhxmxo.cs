using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldEditor
{
    public partial class Form触发条件添加 : Form
    {
        public Form触发条件添加(Form配置触发器 form配置触发器)
        {
            InitializeComponent();
            this.form配置触发器 = form配置触发器;
        }

        private Form配置触发器 form配置触发器;

        public Form配置触发器 Form配置触发器
        {
            get 
            { 
                return form配置触发器; 
            }
        }


        private GameEventConditionType addConditionType;

        public GameEventConditionType AddConditionType
        {
            get 
            { 
                return addConditionType; 
            }
        }

        private EventVariable eventVariable1;

        public EventVariable EventVariable1
        {
            get 
            { 
                return eventVariable1; 
            }
            
        }

        private EventVariable eventVariable2;

        public EventVariable EventVariable2
        {
            get 
            { 
                return eventVariable2; 
            }
        }

        private int constNum;

        public int ConstNum
        {
            get
            {
                return constNum;
            }
        }

        private CompareFunction compareType;

        public CompareFunction CompareType
        {
            get 
            { 
                return compareType; 
            }
        }

        private EventRegion selectRegion;

        public EventRegion SelectRegion
        {
            get 
            { 
                return selectRegion; 
            }
        }

        private GameUnitType gameUnit;

        public GameUnitType GameUnit
        {
            get 
            { 
                return gameUnit; 
            }
        }



        private void button变量与值比较_Click(object sender, EventArgs e)
        {
            Form变量与值比较 form变量与值比较 = new Form变量与值比较(this.form配置触发器.MainForm);
            if (form变量与值比较.ShowDialog() == DialogResult.OK)
            {
                this.addConditionType = GameEventConditionType.VariableCompareValue;
                this.eventVariable1 = form变量与值比较.ComboBox变量.SelectedItem as EventVariable;
                this.constNum = form变量与值比较.ConstNum;
                this.compareType = (CompareFunction)form变量与值比较.ComboBox条件.SelectedIndex;

                Object[] gameEventConditionArgs = new Object[3];
                //gameEventConditionArgs[0] = this.eventVariable1;
                gameEventConditionArgs[0] = form变量与值比较.ComboBox变量.SelectedIndex;
                gameEventConditionArgs[1] = this.constNum;
                gameEventConditionArgs[2] = this.compareType;

                GameEventCondition gameEventCondition = new GameEventCondition(this.addConditionType, gameEventConditionArgs);

                this.form配置触发器.ListBox条件.Items.Add(gameEventCondition);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventConditionList.Add(gameEventCondition);

                this.Close();
            }
            form变量与值比较.Dispose();
        }

        private void button变量与变量比较_Click(object sender, EventArgs e)
        {
            Form变量与变量比较 form变量与变量比较 = new Form变量与变量比较(this.form配置触发器.MainForm);
            if (form变量与变量比较.ShowDialog() == DialogResult.OK)
            {
                this.addConditionType = GameEventConditionType.VariableCompareVariable;
                this.eventVariable1 = form变量与变量比较.ComboBox变量一.SelectedItem as EventVariable;
                this.eventVariable2 = form变量与变量比较.ComboBox变量二.SelectedItem as EventVariable;
                this.compareType = (CompareFunction)form变量与变量比较.ComboBox条件.SelectedIndex;

                Object[] gameEventConditionArgs = new Object[3];
                //gameEventConditionArgs[0] = this.eventVariable1;
                //gameEventConditionArgs[1] = this.eventVariable2;
                gameEventConditionArgs[0] = form变量与变量比较.ComboBox变量一.SelectedIndex;
                gameEventConditionArgs[1] = form变量与变量比较.ComboBox变量二.SelectedIndex;
                gameEventConditionArgs[2] = this.compareType;

                GameEventCondition gameEventCondition = new GameEventCondition(this.addConditionType, gameEventConditionArgs);

                this.form配置触发器.ListBox条件.Items.Add(gameEventCondition);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventConditionList.Add(gameEventCondition);

                this.Close();
            }
            form变量与变量比较.Dispose();
        }

        private void button游戏单位比较_Click(object sender, EventArgs e)
        {
            Form游戏单位比较 form游戏单位比较 = new Form游戏单位比较(this.form配置触发器.MainForm);
            if (form游戏单位比较.ShowDialog() == DialogResult.OK)
            {
                this.addConditionType = GameEventConditionType.GameUnit;
                this.gameUnit = (GameUnitType)(form游戏单位比较.ComboBox游戏单位.SelectedIndex);
                Object[] gameEventConditionArgs = new Object[2];
                gameEventConditionArgs[0] = this.gameUnit;
                if (form游戏单位比较.ComboBox名字.SelectedIndex != -1)
                {
                    gameEventConditionArgs[1] = form游戏单位比较.ComboBox名字.SelectedItem as string;
                }
                else
                {
                    gameEventConditionArgs[1] = string.Empty;
                }
                GameEventCondition gameEventCondition = new GameEventCondition(this.addConditionType, gameEventConditionArgs);

                this.form配置触发器.ListBox条件.Items.Add(gameEventCondition);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventConditionList.Add(gameEventCondition);

                this.Close();
            }
            form游戏单位比较.Dispose();
        }

        private void button触发区域比较_Click(object sender, EventArgs e)
        {
            Form触发区域比较 form触发区域比较 = new Form触发区域比较(this.form配置触发器.MainForm);
            if (form触发区域比较.ShowDialog() == DialogResult.OK)
            {
                this.addConditionType = GameEventConditionType.EventRegion;
                this.selectRegion = form触发区域比较.ComboBox触发区域.SelectedItem as EventRegion;
                Object[] gameEventConditionArgs = new Object[1];
                //gameEventConditionArgs[0] = this.selectRegion;
                gameEventConditionArgs[0] = form触发区域比较.ComboBox触发区域.SelectedIndex;

                GameEventCondition gameEventCondition = new GameEventCondition(this.addConditionType,gameEventConditionArgs);

                this.form配置触发器.ListBox条件.Items.Add(gameEventCondition);
                MapData mapData = this.form配置触发器.MainForm.ListBox关卡.SelectedItem as MapData;
                mapData.TriggerList[this.form配置触发器.ListBox触发器.SelectedIndex].GameEventConditionList.Add(gameEventCondition);

                this.Close();
            }
            form触发区域比较.Dispose();
        }

        
    }
}
namespace WorldEditor
{
    partial class Form游戏单位比较
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox游戏单位 = new System.Windows.Forms.ComboBox();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox名字 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏单位类型:";
            // 
            // comboBox游戏单位
            // 
            this.comboBox游戏单位.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox游戏单位.FormattingEnabled = true;
            this.comboBox游戏单位.Items.AddRange(new object[] {
            "游戏主角",
            "大反派",
            "木乃伊",
            "蝙蝠",
            "大嘴乌鸦",
            "呆呆机器猴",
            "蘑菇",
            "飞碟",
            "激光机器人",
            "钻头机器人",
            "可爱僵尸",
            "金刚",
            "灵魔水晶",
            "飞行器",
            "蜘蛛炸弹",
            "忍者",
            "小丑",
            "绿巨人",
            "蜜蜂",
            "桃心",
            "铜钱",
            "银锭",
            "金元宝"});
            this.comboBox游戏单位.Location = new System.Drawing.Point(31, 44);
            this.comboBox游戏单位.Name = "comboBox游戏单位";
            this.comboBox游戏单位.Size = new System.Drawing.Size(117, 20);
            this.comboBox游戏单位.TabIndex = 1;
            this.comboBox游戏单位.SelectedIndexChanged += new System.EventHandler(this.comboBox游戏单位_SelectedIndexChanged);
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(51, 146);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(44, 22);
            this.button确定.TabIndex = 2;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(103, 146);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(44, 22);
            this.button取消.TabIndex = 3;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "名字:";
            // 
            // comboBox名字
            // 
            this.comboBox名字.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox名字.FormattingEnabled = true;
            this.comboBox名字.Location = new System.Drawing.Point(30, 105);
            this.comboBox名字.Name = "comboBox名字";
            this.comboBox名字.Size = new System.Drawing.Size(117, 20);
            this.comboBox名字.TabIndex = 5;
            // 
            // Form游戏单位比较
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 190);
            this.Controls.Add(this.comboBox名字);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox游戏单位);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form游戏单位比较";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏单位比较";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox游戏单位;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox名字;
    }
}
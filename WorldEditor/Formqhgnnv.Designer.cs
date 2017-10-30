namespace WorldEditor
{
    partial class Form杀死游戏单位
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
            this.label4 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.comboBox游戏单位类型 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox名字 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "名字:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(111, 153);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 19;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(44, 153);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 18;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // comboBox游戏单位类型
            // 
            this.comboBox游戏单位类型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox游戏单位类型.FormattingEnabled = true;
            this.comboBox游戏单位类型.Items.AddRange(new object[] {
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
            "桃心"});
            this.comboBox游戏单位类型.Location = new System.Drawing.Point(23, 53);
            this.comboBox游戏单位类型.Name = "comboBox游戏单位类型";
            this.comboBox游戏单位类型.Size = new System.Drawing.Size(149, 20);
            this.comboBox游戏单位类型.TabIndex = 17;
            this.comboBox游戏单位类型.SelectedIndexChanged += new System.EventHandler(this.comboBox游戏单位类型_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "游戏单位类型:";
            // 
            // comboBox名字
            // 
            this.comboBox名字.FormattingEnabled = true;
            this.comboBox名字.Location = new System.Drawing.Point(23, 110);
            this.comboBox名字.Name = "comboBox名字";
            this.comboBox名字.Size = new System.Drawing.Size(149, 20);
            this.comboBox名字.TabIndex = 21;
            this.comboBox名字.SelectedIndexChanged += new System.EventHandler(this.comboBox名字_SelectedIndexChanged);
            // 
            // Form杀死游戏单位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 201);
            this.Controls.Add(this.comboBox名字);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox游戏单位类型);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form杀死游戏单位";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "杀死游戏单位";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.ComboBox comboBox游戏单位类型;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox名字;
    }
}
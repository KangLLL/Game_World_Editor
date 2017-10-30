namespace WorldEditor
{
    partial class Form创建游戏单位
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
            this.comboBox游戏单位类型 = new System.Windows.Forms.ComboBox();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox名字 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxX变量 = new System.Windows.Forms.ComboBox();
            this.numericUpDownX常量 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonX变量 = new System.Windows.Forms.RadioButton();
            this.radioButtonX常量 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxY变量 = new System.Windows.Forms.ComboBox();
            this.numericUpDownY常量 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonY变量 = new System.Windows.Forms.RadioButton();
            this.radioButtonY常量 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX常量)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY常量)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏单位:";
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
            "桃心",
            "铜钱",
            "银锭",
            "金元宝"});
            this.comboBox游戏单位类型.Location = new System.Drawing.Point(21, 150);
            this.comboBox游戏单位类型.Name = "comboBox游戏单位类型";
            this.comboBox游戏单位类型.Size = new System.Drawing.Size(149, 20);
            this.comboBox游戏单位类型.TabIndex = 1;
            this.comboBox游戏单位类型.SelectedIndexChanged += new System.EventHandler(this.comboBox游戏单位类型_SelectedIndexChanged);
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(251, 195);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 2;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(318, 195);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 3;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "X坐标:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y坐标:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "名字:";
            // 
            // textBox名字
            // 
            this.textBox名字.Location = new System.Drawing.Point(222, 149);
            this.textBox名字.Name = "textBox名字";
            this.textBox名字.Size = new System.Drawing.Size(133, 21);
            this.textBox名字.TabIndex = 9;
            this.textBox名字.TextChanged += new System.EventHandler(this.textBox名字_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxX变量);
            this.groupBox1.Controls.Add(this.numericUpDownX常量);
            this.groupBox1.Controls.Add(this.radioButtonX变量);
            this.groupBox1.Controls.Add(this.radioButtonX常量);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 86);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作数";
            // 
            // comboBoxX变量
            // 
            this.comboBoxX变量.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxX变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxX变量.FormattingEnabled = true;
            this.comboBoxX变量.Location = new System.Drawing.Point(72, 49);
            this.comboBoxX变量.Name = "comboBoxX变量";
            this.comboBoxX变量.Size = new System.Drawing.Size(70, 22);
            this.comboBoxX变量.TabIndex = 3;
            this.comboBoxX变量.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxX变量_DrawItem);
            this.comboBoxX变量.SelectedIndexChanged += new System.EventHandler(this.comboBoxX变量_SelectedIndexChanged);
            // 
            // numericUpDownX常量
            // 
            this.numericUpDownX常量.Location = new System.Drawing.Point(72, 20);
            this.numericUpDownX常量.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownX常量.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownX常量.Name = "numericUpDownX常量";
            this.numericUpDownX常量.Size = new System.Drawing.Size(70, 21);
            this.numericUpDownX常量.TabIndex = 3;
            // 
            // radioButtonX变量
            // 
            this.radioButtonX变量.AutoSize = true;
            this.radioButtonX变量.Location = new System.Drawing.Point(6, 53);
            this.radioButtonX变量.Name = "radioButtonX变量";
            this.radioButtonX变量.Size = new System.Drawing.Size(47, 16);
            this.radioButtonX变量.TabIndex = 4;
            this.radioButtonX变量.Text = "变量";
            this.radioButtonX变量.UseVisualStyleBackColor = true;
            // 
            // radioButtonX常量
            // 
            this.radioButtonX常量.AutoSize = true;
            this.radioButtonX常量.Checked = true;
            this.radioButtonX常量.Location = new System.Drawing.Point(6, 22);
            this.radioButtonX常量.Name = "radioButtonX常量";
            this.radioButtonX常量.Size = new System.Drawing.Size(47, 16);
            this.radioButtonX常量.TabIndex = 3;
            this.radioButtonX常量.TabStop = true;
            this.radioButtonX常量.Text = "常量";
            this.radioButtonX常量.UseVisualStyleBackColor = true;
            this.radioButtonX常量.CheckedChanged += new System.EventHandler(this.radioButtonX常量_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxY变量);
            this.groupBox2.Controls.Add(this.numericUpDownY常量);
            this.groupBox2.Controls.Add(this.radioButtonY变量);
            this.groupBox2.Controls.Add(this.radioButtonY常量);
            this.groupBox2.Location = new System.Drawing.Point(222, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 86);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作数";
            // 
            // comboBoxY变量
            // 
            this.comboBoxY变量.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxY变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxY变量.FormattingEnabled = true;
            this.comboBoxY变量.Location = new System.Drawing.Point(72, 49);
            this.comboBoxY变量.Name = "comboBoxY变量";
            this.comboBoxY变量.Size = new System.Drawing.Size(70, 22);
            this.comboBoxY变量.TabIndex = 3;
            this.comboBoxY变量.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxY变量_DrawItem);
            this.comboBoxY变量.SelectedIndexChanged += new System.EventHandler(this.comboBoxY变量_SelectedIndexChanged);
            // 
            // numericUpDownY常量
            // 
            this.numericUpDownY常量.Location = new System.Drawing.Point(72, 20);
            this.numericUpDownY常量.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownY常量.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownY常量.Name = "numericUpDownY常量";
            this.numericUpDownY常量.Size = new System.Drawing.Size(70, 21);
            this.numericUpDownY常量.TabIndex = 3;
            // 
            // radioButtonY变量
            // 
            this.radioButtonY变量.AutoSize = true;
            this.radioButtonY变量.Location = new System.Drawing.Point(6, 53);
            this.radioButtonY变量.Name = "radioButtonY变量";
            this.radioButtonY变量.Size = new System.Drawing.Size(47, 16);
            this.radioButtonY变量.TabIndex = 4;
            this.radioButtonY变量.Text = "变量";
            this.radioButtonY变量.UseVisualStyleBackColor = true;
            // 
            // radioButtonY常量
            // 
            this.radioButtonY常量.AutoSize = true;
            this.radioButtonY常量.Checked = true;
            this.radioButtonY常量.Location = new System.Drawing.Point(6, 22);
            this.radioButtonY常量.Name = "radioButtonY常量";
            this.radioButtonY常量.Size = new System.Drawing.Size(47, 16);
            this.radioButtonY常量.TabIndex = 3;
            this.radioButtonY常量.TabStop = true;
            this.radioButtonY常量.Text = "常量";
            this.radioButtonY常量.UseVisualStyleBackColor = true;
            this.radioButtonY常量.CheckedChanged += new System.EventHandler(this.radioButtonY常量_CheckedChanged);
            // 
            // Form创建游戏单位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 232);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox名字);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox游戏单位类型);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form创建游戏单位";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建游戏单位";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX常量)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY常量)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox游戏单位类型;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox名字;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxX变量;
        private System.Windows.Forms.NumericUpDown numericUpDownX常量;
        private System.Windows.Forms.RadioButton radioButtonX变量;
        private System.Windows.Forms.RadioButton radioButtonX常量;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxY变量;
        private System.Windows.Forms.NumericUpDown numericUpDownY常量;
        private System.Windows.Forms.RadioButton radioButtonY变量;
        private System.Windows.Forms.RadioButton radioButtonY常量;
    }
}
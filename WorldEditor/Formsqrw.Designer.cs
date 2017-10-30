namespace WorldEditor
{
    partial class Form显示文章
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox文章 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxY变量 = new System.Windows.Forms.ComboBox();
            this.numericUpDownY常量 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonY变量 = new System.Windows.Forms.RadioButton();
            this.radioButtonY常量 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxX变量 = new System.Windows.Forms.ComboBox();
            this.numericUpDownX常量 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonX变量 = new System.Windows.Forms.RadioButton();
            this.radioButtonX常量 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY常量)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX常量)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X坐标:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y坐标:";
            // 
            // textBox文章
            // 
            this.textBox文章.Location = new System.Drawing.Point(30, 148);
            this.textBox文章.Multiline = true;
            this.textBox文章.Name = "textBox文章";
            this.textBox文章.Size = new System.Drawing.Size(336, 83);
            this.textBox文章.TabIndex = 4;
            this.textBox文章.TextChanged += new System.EventHandler(this.textBox文章_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "文章:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(305, 248);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 9;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(238, 248);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 8;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxY变量);
            this.groupBox2.Controls.Add(this.numericUpDownY常量);
            this.groupBox2.Controls.Add(this.radioButtonY变量);
            this.groupBox2.Controls.Add(this.radioButtonY常量);
            this.groupBox2.Location = new System.Drawing.Point(209, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 86);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作数";
            // 
            // comboBoxY变量
            // 
            this.comboBoxY变量.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxY变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxY变量.Enabled = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxX变量);
            this.groupBox1.Controls.Add(this.numericUpDownX常量);
            this.groupBox1.Controls.Add(this.radioButtonX变量);
            this.groupBox1.Controls.Add(this.radioButtonX常量);
            this.groupBox1.Location = new System.Drawing.Point(30, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 86);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作数";
            // 
            // comboBoxX变量
            // 
            this.comboBoxX变量.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxX变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxX变量.Enabled = false;
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
            // Form显示文章
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 279);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox文章);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form显示文章";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "显示文章";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY常量)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX常量)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox文章;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxY变量;
        private System.Windows.Forms.NumericUpDown numericUpDownY常量;
        private System.Windows.Forms.RadioButton radioButtonY变量;
        private System.Windows.Forms.RadioButton radioButtonY常量;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxX变量;
        private System.Windows.Forms.NumericUpDown numericUpDownX常量;
        private System.Windows.Forms.RadioButton radioButtonX变量;
        private System.Windows.Forms.RadioButton radioButtonX常量;
    }
}
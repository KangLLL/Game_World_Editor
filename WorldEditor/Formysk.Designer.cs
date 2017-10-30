namespace WorldEditor
{
    partial class Form设置层
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
            this.textBox名称 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox动态背景 = new System.Windows.Forms.ComboBox();
            this.comboBox静态背景 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button确定 = new System.Windows.Forms.Button();
            this.numericUpDown可见层宽 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown可见层高 = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton剪裁右 = new System.Windows.Forms.RadioButton();
            this.radioButton剪裁左 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton剪裁下 = new System.Windows.Forms.RadioButton();
            this.radioButton剪裁上 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层宽)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层高)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox名称
            // 
            this.textBox名称.Location = new System.Drawing.Point(11, 47);
            this.textBox名称.Name = "textBox名称";
            this.textBox名称.Size = new System.Drawing.Size(101, 21);
            this.textBox名称.TabIndex = 71;
            this.textBox名称.TextChanged += new System.EventHandler(this.textBox名称_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 70;
            this.label3.Text = "名称:";
            // 
            // comboBox动态背景
            // 
            this.comboBox动态背景.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox动态背景.DropDownWidth = 64;
            this.comboBox动态背景.FormattingEnabled = true;
            this.comboBox动态背景.Location = new System.Drawing.Point(217, 122);
            this.comboBox动态背景.Name = "comboBox动态背景";
            this.comboBox动态背景.Size = new System.Drawing.Size(57, 20);
            this.comboBox动态背景.TabIndex = 69;
            // 
            // comboBox静态背景
            // 
            this.comboBox静态背景.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox静态背景.DropDownWidth = 64;
            this.comboBox静态背景.FormattingEnabled = true;
            this.comboBox静态背景.Location = new System.Drawing.Point(142, 122);
            this.comboBox静态背景.Name = "comboBox静态背景";
            this.comboBox静态背景.Size = new System.Drawing.Size(57, 20);
            this.comboBox静态背景.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "动态背景:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 66;
            this.label1.Text = "静态背景:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(208, 175);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 23);
            this.button取消.TabIndex = 65;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "高:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "宽:";
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(121, 175);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(75, 23);
            this.button确定.TabIndex = 64;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            this.button确定.Click += new System.EventHandler(this.button确定_Click);
            // 
            // numericUpDown可见层宽
            // 
            this.numericUpDown可见层宽.Location = new System.Drawing.Point(147, 65);
            this.numericUpDown可见层宽.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown可见层宽.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown可见层宽.Name = "numericUpDown可见层宽";
            this.numericUpDown可见层宽.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown可见层宽.TabIndex = 60;
            this.numericUpDown可见层宽.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDown可见层高
            // 
            this.numericUpDown可见层高.Location = new System.Drawing.Point(217, 65);
            this.numericUpDown可见层高.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown可见层高.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown可见层高.Name = "numericUpDown可见层高";
            this.numericUpDown可见层高.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown可见层高.TabIndex = 63;
            this.numericUpDown可见层高.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton剪裁右);
            this.groupBox5.Controls.Add(this.radioButton剪裁左);
            this.groupBox5.Location = new System.Drawing.Point(14, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(90, 43);
            this.groupBox5.TabIndex = 73;
            this.groupBox5.TabStop = false;
            // 
            // radioButton剪裁右
            // 
            this.radioButton剪裁右.AutoSize = true;
            this.radioButton剪裁右.Location = new System.Drawing.Point(47, 20);
            this.radioButton剪裁右.Name = "radioButton剪裁右";
            this.radioButton剪裁右.Size = new System.Drawing.Size(35, 16);
            this.radioButton剪裁右.TabIndex = 1;
            this.radioButton剪裁右.TabStop = true;
            this.radioButton剪裁右.Text = "右";
            this.radioButton剪裁右.UseVisualStyleBackColor = true;
            // 
            // radioButton剪裁左
            // 
            this.radioButton剪裁左.AutoSize = true;
            this.radioButton剪裁左.Checked = true;
            this.radioButton剪裁左.Location = new System.Drawing.Point(6, 20);
            this.radioButton剪裁左.Name = "radioButton剪裁左";
            this.radioButton剪裁左.Size = new System.Drawing.Size(35, 16);
            this.radioButton剪裁左.TabIndex = 0;
            this.radioButton剪裁左.TabStop = true;
            this.radioButton剪裁左.Text = "左";
            this.radioButton剪裁左.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 74;
            this.label15.Text = "剪裁样式:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton剪裁下);
            this.groupBox4.Controls.Add(this.radioButton剪裁上);
            this.groupBox4.Location = new System.Drawing.Point(14, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(90, 43);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            // 
            // radioButton剪裁下
            // 
            this.radioButton剪裁下.AutoSize = true;
            this.radioButton剪裁下.Location = new System.Drawing.Point(47, 20);
            this.radioButton剪裁下.Name = "radioButton剪裁下";
            this.radioButton剪裁下.Size = new System.Drawing.Size(35, 16);
            this.radioButton剪裁下.TabIndex = 1;
            this.radioButton剪裁下.TabStop = true;
            this.radioButton剪裁下.Text = "下";
            this.radioButton剪裁下.UseVisualStyleBackColor = true;
            // 
            // radioButton剪裁上
            // 
            this.radioButton剪裁上.AutoSize = true;
            this.radioButton剪裁上.Checked = true;
            this.radioButton剪裁上.Location = new System.Drawing.Point(6, 20);
            this.radioButton剪裁上.Name = "radioButton剪裁上";
            this.radioButton剪裁上.Size = new System.Drawing.Size(35, 16);
            this.radioButton剪裁上.TabIndex = 0;
            this.radioButton剪裁上.TabStop = true;
            this.radioButton剪裁上.Text = "上";
            this.radioButton剪裁上.UseVisualStyleBackColor = true;
            // 
            // Form设置层
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 224);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox名称);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox动态背景);
            this.Controls.Add(this.comboBox静态背景);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown可见层宽);
            this.Controls.Add(this.numericUpDown可见层高);
            this.Name = "Form设置层";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form设置层";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层宽)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层高)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox名称;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox动态背景;
        private System.Windows.Forms.ComboBox comboBox静态背景;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown可见层宽;
        private System.Windows.Forms.NumericUpDown numericUpDown可见层高;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton剪裁右;
        private System.Windows.Forms.RadioButton radioButton剪裁左;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton剪裁下;
        private System.Windows.Forms.RadioButton radioButton剪裁上;
    }
}
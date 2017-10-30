namespace WorldEditor
{
    partial class Form设置地图
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
            this.textBox名称 = new System.Windows.Forms.TextBox();
            this.numericUpDown逻辑层宽 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown逻辑层高 = new System.Windows.Forms.NumericUpDown();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton剪裁下 = new System.Windows.Forms.RadioButton();
            this.radioButton剪裁上 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton剪裁右 = new System.Windows.Forms.RadioButton();
            this.radioButton剪裁左 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层宽)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层高)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称:";
            // 
            // textBox名称
            // 
            this.textBox名称.Location = new System.Drawing.Point(22, 39);
            this.textBox名称.Name = "textBox名称";
            this.textBox名称.Size = new System.Drawing.Size(94, 21);
            this.textBox名称.TabIndex = 1;
            this.textBox名称.TextChanged += new System.EventHandler(this.textBox名称_TextChanged);
            // 
            // numericUpDown逻辑层宽
            // 
            this.numericUpDown逻辑层宽.Location = new System.Drawing.Point(132, 39);
            this.numericUpDown逻辑层宽.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown逻辑层宽.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown逻辑层宽.Name = "numericUpDown逻辑层宽";
            this.numericUpDown逻辑层宽.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown逻辑层宽.TabIndex = 6;
            this.numericUpDown逻辑层宽.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "宽:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "高:";
            // 
            // numericUpDown逻辑层高
            // 
            this.numericUpDown逻辑层高.Location = new System.Drawing.Point(201, 39);
            this.numericUpDown逻辑层高.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown逻辑层高.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown逻辑层高.Name = "numericUpDown逻辑层高";
            this.numericUpDown逻辑层高.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown逻辑层高.TabIndex = 9;
            this.numericUpDown逻辑层高.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(78, 169);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(75, 23);
            this.button确定.TabIndex = 33;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            this.button确定.Click += new System.EventHandler(this.button确定_Click);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(178, 169);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 23);
            this.button取消.TabIndex = 34;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton剪裁下);
            this.groupBox4.Controls.Add(this.radioButton剪裁上);
            this.groupBox4.Location = new System.Drawing.Point(22, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(90, 43);
            this.groupBox4.TabIndex = 35;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 37;
            this.label15.Text = "剪裁样式:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton剪裁右);
            this.groupBox5.Controls.Add(this.radioButton剪裁左);
            this.groupBox5.Location = new System.Drawing.Point(163, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(90, 43);
            this.groupBox5.TabIndex = 36;
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
            // Form设置地图
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 225);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown逻辑层宽);
            this.Controls.Add(this.numericUpDown逻辑层高);
            this.Controls.Add(this.textBox名称);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form设置地图";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form设置地图";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层宽)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层高)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox名称;
        private System.Windows.Forms.NumericUpDown numericUpDown逻辑层宽;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown逻辑层高;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton剪裁下;
        private System.Windows.Forms.RadioButton radioButton剪裁上;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton剪裁右;
        private System.Windows.Forms.RadioButton radioButton剪裁左;
    }
}
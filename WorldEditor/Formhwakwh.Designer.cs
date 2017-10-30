namespace WorldEditor
{
    partial class Form播放角色动画
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
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.numericUpDown开始X = new System.Windows.Forms.NumericUpDown();
            this.checkBox重复播放 = new System.Windows.Forms.CheckBox();
            this.numericUpDown开始Y = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown终止Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown终止X = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown垂直速度 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown水平速度 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton异步 = new System.Windows.Forms.RadioButton();
            this.radioButton同步 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown帧数 = new System.Windows.Forms.NumericUpDown();
            this.textBox动画序列 = new System.Windows.Forms.TextBox();
            this.textBox动画文件名 = new System.Windows.Forms.TextBox();
            this.numericUpDown缓慢系数 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown开始X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown开始Y)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止X)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown垂直速度)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown水平速度)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown帧数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown缓慢系数)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "动画文件名:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(280, 247);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 15;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(213, 247);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 14;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // numericUpDown开始X
            // 
            this.numericUpDown开始X.Location = new System.Drawing.Point(29, 20);
            this.numericUpDown开始X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown开始X.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown开始X.Name = "numericUpDown开始X";
            this.numericUpDown开始X.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown开始X.TabIndex = 18;
            // 
            // checkBox重复播放
            // 
            this.checkBox重复播放.AutoSize = true;
            this.checkBox重复播放.Location = new System.Drawing.Point(213, 114);
            this.checkBox重复播放.Name = "checkBox重复播放";
            this.checkBox重复播放.Size = new System.Drawing.Size(72, 16);
            this.checkBox重复播放.TabIndex = 19;
            this.checkBox重复播放.Text = "重复播放";
            this.checkBox重复播放.UseVisualStyleBackColor = true;
            // 
            // numericUpDown开始Y
            // 
            this.numericUpDown开始Y.Location = new System.Drawing.Point(110, 20);
            this.numericUpDown开始Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown开始Y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown开始Y.Name = "numericUpDown开始Y";
            this.numericUpDown开始Y.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown开始Y.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "动画序列名:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(211, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "是否重复播放:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown开始Y);
            this.groupBox1.Controls.Add(this.numericUpDown开始X);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(30, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 47);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起始坐标:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown终止Y);
            this.groupBox2.Controls.Add(this.numericUpDown终止X);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(30, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 47);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "终止坐标:";
            // 
            // numericUpDown终止Y
            // 
            this.numericUpDown终止Y.Location = new System.Drawing.Point(110, 20);
            this.numericUpDown终止Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown终止Y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown终止Y.Name = "numericUpDown终止Y";
            this.numericUpDown终止Y.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown终止Y.TabIndex = 20;
            // 
            // numericUpDown终止X
            // 
            this.numericUpDown终止X.Location = new System.Drawing.Point(29, 20);
            this.numericUpDown终止X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown终止X.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown终止X.Name = "numericUpDown终止X";
            this.numericUpDown终止X.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown终止X.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "Y:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown垂直速度);
            this.groupBox3.Controls.Add(this.numericUpDown水平速度);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(30, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 47);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "速度:";
            // 
            // numericUpDown垂直速度
            // 
            this.numericUpDown垂直速度.Location = new System.Drawing.Point(110, 20);
            this.numericUpDown垂直速度.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown垂直速度.Name = "numericUpDown垂直速度";
            this.numericUpDown垂直速度.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown垂直速度.TabIndex = 20;
            // 
            // numericUpDown水平速度
            // 
            this.numericUpDown水平速度.Location = new System.Drawing.Point(29, 20);
            this.numericUpDown水平速度.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown水平速度.Name = "numericUpDown水平速度";
            this.numericUpDown水平速度.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown水平速度.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "是否同步:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton异步);
            this.groupBox4.Controls.Add(this.radioButton同步);
            this.groupBox4.Location = new System.Drawing.Point(213, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(61, 58);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            // 
            // radioButton异步
            // 
            this.radioButton异步.AutoSize = true;
            this.radioButton异步.Location = new System.Drawing.Point(6, 36);
            this.radioButton异步.Name = "radioButton异步";
            this.radioButton异步.Size = new System.Drawing.Size(47, 16);
            this.radioButton异步.TabIndex = 1;
            this.radioButton异步.TabStop = true;
            this.radioButton异步.Text = "异步";
            this.radioButton异步.UseVisualStyleBackColor = true;
            // 
            // radioButton同步
            // 
            this.radioButton同步.AutoSize = true;
            this.radioButton同步.Checked = true;
            this.radioButton同步.Location = new System.Drawing.Point(6, 18);
            this.radioButton同步.Name = "radioButton同步";
            this.radioButton同步.Size = new System.Drawing.Size(47, 16);
            this.radioButton同步.TabIndex = 0;
            this.radioButton同步.TabStop = true;
            this.radioButton同步.Text = "同步";
            this.radioButton同步.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(282, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 35;
            this.label11.Text = "播放帧数:";
            // 
            // numericUpDown帧数
            // 
            this.numericUpDown帧数.Location = new System.Drawing.Point(284, 167);
            this.numericUpDown帧数.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown帧数.Name = "numericUpDown帧数";
            this.numericUpDown帧数.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown帧数.TabIndex = 28;
            // 
            // textBox动画序列
            // 
            this.textBox动画序列.Location = new System.Drawing.Point(213, 54);
            this.textBox动画序列.Name = "textBox动画序列";
            this.textBox动画序列.Size = new System.Drawing.Size(100, 21);
            this.textBox动画序列.TabIndex = 36;
            this.textBox动画序列.TextChanged += new System.EventHandler(this.textBox动画序列_TextChanged);
            // 
            // textBox动画文件名
            // 
            this.textBox动画文件名.Location = new System.Drawing.Point(30, 54);
            this.textBox动画文件名.Name = "textBox动画文件名";
            this.textBox动画文件名.Size = new System.Drawing.Size(100, 21);
            this.textBox动画文件名.TabIndex = 37;
            // 
            // numericUpDown缓慢系数
            // 
            this.numericUpDown缓慢系数.Location = new System.Drawing.Point(284, 218);
            this.numericUpDown缓慢系数.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown缓慢系数.Name = "numericUpDown缓慢系数";
            this.numericUpDown缓慢系数.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown缓慢系数.TabIndex = 38;
            this.numericUpDown缓慢系数.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(282, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "缓慢系数:";
            // 
            // Form播放角色动画
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 282);
            this.Controls.Add(this.numericUpDown缓慢系数);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox动画文件名);
            this.Controls.Add(this.textBox动画序列);
            this.Controls.Add(this.numericUpDown帧数);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox重复播放);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form播放角色动画";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放角色动画";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown开始X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown开始Y)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止X)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown垂直速度)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown水平速度)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown帧数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown缓慢系数)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown开始X;
        private System.Windows.Forms.CheckBox checkBox重复播放;
        private System.Windows.Forms.NumericUpDown numericUpDown开始Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown终止Y;
        private System.Windows.Forms.NumericUpDown numericUpDown终止X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown垂直速度;
        private System.Windows.Forms.NumericUpDown numericUpDown水平速度;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton异步;
        private System.Windows.Forms.RadioButton radioButton同步;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown帧数;
        private System.Windows.Forms.TextBox textBox动画序列;
        private System.Windows.Forms.TextBox textBox动画文件名;
        private System.Windows.Forms.NumericUpDown numericUpDown缓慢系数;
        private System.Windows.Forms.Label label12;
    }
}
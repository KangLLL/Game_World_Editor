namespace WorldEditor
{
    partial class Form移动摄像机
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.numericUpDown终止Y = new System.Windows.Forms.NumericUpDown();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.numericUpDown终止X = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown速度Y = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.numericUpDown速度X = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.checkBox是否同步 = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止Y)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止X)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown速度Y)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown速度X)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Location = new System.Drawing.Point(27, 173);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(315, 121);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "终点坐标:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.numericUpDown终止Y);
            this.groupBox7.Location = new System.Drawing.Point(166, 32);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(143, 74);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "操作数:";
            // 
            // numericUpDown终止Y
            // 
            this.numericUpDown终止Y.Location = new System.Drawing.Point(59, 15);
            this.numericUpDown终止Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown终止Y.Name = "numericUpDown终止Y";
            this.numericUpDown终止Y.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown终止Y.TabIndex = 18;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.numericUpDown终止X);
            this.groupBox8.Location = new System.Drawing.Point(6, 32);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(143, 74);
            this.groupBox8.TabIndex = 36;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "操作数:";
            // 
            // numericUpDown终止X
            // 
            this.numericUpDown终止X.Location = new System.Drawing.Point(59, 15);
            this.numericUpDown终止X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown终止X.Name = "numericUpDown终止X";
            this.numericUpDown终止X.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown终止X.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "Y:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(27, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 121);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "速度:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown速度Y);
            this.groupBox3.Location = new System.Drawing.Point(166, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 74);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作数:";
            // 
            // numericUpDown速度Y
            // 
            this.numericUpDown速度Y.Location = new System.Drawing.Point(59, 15);
            this.numericUpDown速度Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown速度Y.Name = "numericUpDown速度Y";
            this.numericUpDown速度Y.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown速度Y.TabIndex = 18;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.numericUpDown速度X);
            this.groupBox9.Location = new System.Drawing.Point(6, 32);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(143, 74);
            this.groupBox9.TabIndex = 36;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "操作数:";
            // 
            // numericUpDown速度X
            // 
            this.numericUpDown速度X.Location = new System.Drawing.Point(59, 15);
            this.numericUpDown速度X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown速度X.Name = "numericUpDown速度X";
            this.numericUpDown速度X.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown速度X.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "Y:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(281, 311);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 43;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(214, 311);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 42;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // checkBox是否同步
            // 
            this.checkBox是否同步.AutoSize = true;
            this.checkBox是否同步.Checked = true;
            this.checkBox是否同步.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox是否同步.Location = new System.Drawing.Point(35, 313);
            this.checkBox是否同步.Name = "checkBox是否同步";
            this.checkBox是否同步.Size = new System.Drawing.Size(72, 16);
            this.checkBox是否同步.TabIndex = 46;
            this.checkBox是否同步.Text = "是否同步";
            this.checkBox是否同步.UseVisualStyleBackColor = true;
            // 
            // Form移动摄像机
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 348);
            this.Controls.Add(this.checkBox是否同步);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Name = "Form移动摄像机";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移动摄像机";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止Y)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown终止X)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown速度Y)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown速度X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown numericUpDown终止Y;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown numericUpDown终止X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown速度Y;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown numericUpDown速度X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.CheckBox checkBox是否同步;
    }
}
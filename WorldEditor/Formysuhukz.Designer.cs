namespace WorldEditor
{
    partial class Form设置触发器开关
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
            this.comboBox操作触发器 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton关闭 = new System.Windows.Forms.RadioButton();
            this.radioButton打开 = new System.Windows.Forms.RadioButton();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox操作触发器
            // 
            this.comboBox操作触发器.FormattingEnabled = true;
            this.comboBox操作触发器.Location = new System.Drawing.Point(22, 55);
            this.comboBox操作触发器.Name = "comboBox操作触发器";
            this.comboBox操作触发器.Size = new System.Drawing.Size(136, 20);
            this.comboBox操作触发器.TabIndex = 34;
            this.comboBox操作触发器.SelectedIndexChanged += new System.EventHandler(this.comboBox操作触发器_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "操作触发器:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton关闭);
            this.groupBox1.Controls.Add(this.radioButton打开);
            this.groupBox1.Location = new System.Drawing.Point(22, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 52);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // radioButton关闭
            // 
            this.radioButton关闭.AutoSize = true;
            this.radioButton关闭.Location = new System.Drawing.Point(75, 20);
            this.radioButton关闭.Name = "radioButton关闭";
            this.radioButton关闭.Size = new System.Drawing.Size(47, 16);
            this.radioButton关闭.TabIndex = 37;
            this.radioButton关闭.Text = "关闭";
            this.radioButton关闭.UseVisualStyleBackColor = true;
            // 
            // radioButton打开
            // 
            this.radioButton打开.AutoSize = true;
            this.radioButton打开.Checked = true;
            this.radioButton打开.Location = new System.Drawing.Point(6, 20);
            this.radioButton打开.Name = "radioButton打开";
            this.radioButton打开.Size = new System.Drawing.Size(47, 16);
            this.radioButton打开.TabIndex = 0;
            this.radioButton打开.TabStop = true;
            this.radioButton打开.Text = "打开";
            this.radioButton打开.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(97, 174);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 38;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(30, 174);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 37;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // Form设置触发器开关
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 205);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox操作触发器);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form设置触发器开关";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form设置触发器开关";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox操作触发器;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton关闭;
        private System.Windows.Forms.RadioButton radioButton打开;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
    }
}
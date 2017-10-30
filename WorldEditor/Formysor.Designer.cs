namespace WorldEditor
{
    partial class Form设置变量
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
            this.comboBox操作变量 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox变量 = new System.Windows.Forms.ComboBox();
            this.numericUpDown常量 = new System.Windows.Forms.NumericUpDown();
            this.radioButton变量 = new System.Windows.Forms.RadioButton();
            this.radioButton常量 = new System.Windows.Forms.RadioButton();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown常量)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作变量:";
            // 
            // comboBox操作变量
            // 
            this.comboBox操作变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox操作变量.FormattingEnabled = true;
            this.comboBox操作变量.Location = new System.Drawing.Point(33, 57);
            this.comboBox操作变量.Name = "comboBox操作变量";
            this.comboBox操作变量.Size = new System.Drawing.Size(197, 20);
            this.comboBox操作变量.TabIndex = 1;
            this.comboBox操作变量.SelectedIndexChanged += new System.EventHandler(this.comboBox操作变量_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox变量);
            this.groupBox1.Controls.Add(this.numericUpDown常量);
            this.groupBox1.Controls.Add(this.radioButton变量);
            this.groupBox1.Controls.Add(this.radioButton常量);
            this.groupBox1.Location = new System.Drawing.Point(33, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作数";
            // 
            // comboBox变量
            // 
            this.comboBox变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox变量.Enabled = false;
            this.comboBox变量.FormattingEnabled = true;
            this.comboBox变量.Location = new System.Drawing.Point(72, 49);
            this.comboBox变量.Name = "comboBox变量";
            this.comboBox变量.Size = new System.Drawing.Size(109, 20);
            this.comboBox变量.TabIndex = 3;
            this.comboBox变量.SelectedIndexChanged += new System.EventHandler(this.comboBox变量_SelectedIndexChanged);
            // 
            // numericUpDown常量
            // 
            this.numericUpDown常量.Location = new System.Drawing.Point(72, 20);
            this.numericUpDown常量.Name = "numericUpDown常量";
            this.numericUpDown常量.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown常量.TabIndex = 3;
            // 
            // radioButton变量
            // 
            this.radioButton变量.AutoSize = true;
            this.radioButton变量.Location = new System.Drawing.Point(6, 53);
            this.radioButton变量.Name = "radioButton变量";
            this.radioButton变量.Size = new System.Drawing.Size(47, 16);
            this.radioButton变量.TabIndex = 4;
            this.radioButton变量.Text = "变量";
            this.radioButton变量.UseVisualStyleBackColor = true;
            // 
            // radioButton常量
            // 
            this.radioButton常量.AutoSize = true;
            this.radioButton常量.Checked = true;
            this.radioButton常量.Location = new System.Drawing.Point(6, 22);
            this.radioButton常量.Name = "radioButton常量";
            this.radioButton常量.Size = new System.Drawing.Size(47, 16);
            this.radioButton常量.TabIndex = 3;
            this.radioButton常量.TabStop = true;
            this.radioButton常量.Text = "常量";
            this.radioButton常量.UseVisualStyleBackColor = true;
            this.radioButton常量.CheckedChanged += new System.EventHandler(this.radioButton常量_CheckedChanged);
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(169, 215);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 21;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(102, 215);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 20;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // Form设置变量
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 266);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox操作变量);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form设置变量";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置变量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown常量)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox操作变量;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton变量;
        private System.Windows.Forms.RadioButton radioButton常量;
        private System.Windows.Forms.ComboBox comboBox变量;
        private System.Windows.Forms.NumericUpDown numericUpDown常量;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
    }
}
namespace WorldEditor
{
    partial class Form变量自减
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
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown操作数 = new System.Windows.Forms.NumericUpDown();
            this.comboBox操作变量 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown操作数)).BeginInit();
            this.SuspendLayout();
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(185, 165);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 29;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(118, 165);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 28;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "操作数:";
            // 
            // numericUpDown操作数
            // 
            this.numericUpDown操作数.Location = new System.Drawing.Point(33, 129);
            this.numericUpDown操作数.Name = "numericUpDown操作数";
            this.numericUpDown操作数.Size = new System.Drawing.Size(71, 21);
            this.numericUpDown操作数.TabIndex = 26;
            // 
            // comboBox操作变量
            // 
            this.comboBox操作变量.FormattingEnabled = true;
            this.comboBox操作变量.Location = new System.Drawing.Point(33, 67);
            this.comboBox操作变量.Name = "comboBox操作变量";
            this.comboBox操作变量.Size = new System.Drawing.Size(197, 20);
            this.comboBox操作变量.TabIndex = 25;
            this.comboBox操作变量.SelectedIndexChanged += new System.EventHandler(this.comboBox操作变量_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "操作变量:";
            // 
            // Form变量自减
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 225);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown操作数);
            this.Controls.Add(this.comboBox操作变量);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form变量自减";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量自减";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown操作数)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown操作数;
        private System.Windows.Forms.ComboBox comboBox操作变量;
        private System.Windows.Forms.Label label1;
    }
}
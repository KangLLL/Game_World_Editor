namespace WorldEditor
{
    partial class Form震动
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
            this.numericUpDown时间 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown时间)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "震动时间:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(107, 86);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 35;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(40, 86);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 34;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // numericUpDown时间
            // 
            this.numericUpDown时间.Location = new System.Drawing.Point(106, 45);
            this.numericUpDown时间.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown时间.Name = "numericUpDown时间";
            this.numericUpDown时间.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown时间.TabIndex = 33;
            // 
            // Form震动
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 136);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown时间);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form震动";
            this.Text = "Form震动";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown时间)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown时间;
    }
}
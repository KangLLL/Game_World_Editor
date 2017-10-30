namespace WorldEditor
{
    partial class Form设置单位绘制层
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
            this.numericUpDown层数 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown层数)).BeginInit();
            this.SuspendLayout();
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(143, 68);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 23);
            this.button取消.TabIndex = 0;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(62, 68);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(75, 23);
            this.button确定.TabIndex = 1;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // numericUpDown层数
            // 
            this.numericUpDown层数.Location = new System.Drawing.Point(168, 23);
            this.numericUpDown层数.Name = "numericUpDown层数";
            this.numericUpDown层数.Size = new System.Drawing.Size(39, 21);
            this.numericUpDown层数.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设置单位绘制层数为：";
            // 
            // Form设置单位绘制层
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 126);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown层数);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.button取消);
            this.Name = "Form设置单位绘制层";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form设置单位绘制层";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown层数)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown层数;
        private System.Windows.Forms.Label label1;
    }
}
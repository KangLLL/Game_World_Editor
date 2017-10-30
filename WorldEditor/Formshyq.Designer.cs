namespace WorldEditor
{
    partial class Form预读资源
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
            this.textBox资源名 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox资源名
            // 
            this.textBox资源名.Location = new System.Drawing.Point(71, 34);
            this.textBox资源名.Name = "textBox资源名";
            this.textBox资源名.Size = new System.Drawing.Size(160, 21);
            this.textBox资源名.TabIndex = 0;
            this.textBox资源名.TextChanged += new System.EventHandler(this.textBox资源名_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "资源名:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(170, 84);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 25;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(103, 84);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 24;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // Form预读资源
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 123);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox资源名);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form预读资源";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form预读资源";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox资源名;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
    }
}
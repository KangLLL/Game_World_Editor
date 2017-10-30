namespace WorldEditor
{
    partial class Form区域名称修改
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
            this.textBox名字 = new System.Windows.Forms.TextBox();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "区域名称:";
            // 
            // textBox名字
            // 
            this.textBox名字.Location = new System.Drawing.Point(77, 28);
            this.textBox名字.Name = "textBox名字";
            this.textBox名字.Size = new System.Drawing.Size(148, 21);
            this.textBox名字.TabIndex = 1;
            this.textBox名字.TextChanged += new System.EventHandler(this.textBox名字_TextChanged);
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(103, 74);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(53, 23);
            this.button确定.TabIndex = 2;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(172, 74);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(53, 23);
            this.button取消.TabIndex = 3;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // Form区域名称修改
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 129);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.textBox名字);
            this.Controls.Add(this.label1);
            this.Name = "Form区域名称修改";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "改名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox名字;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
    }
}
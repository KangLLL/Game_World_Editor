namespace WorldEditor
{
    partial class Form播放WAV
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
            this.button停止 = new System.Windows.Forms.Button();
            this.button播放 = new System.Windows.Forms.Button();
            this.listBox音乐 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(155, 238);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(53, 21);
            this.button取消.TabIndex = 13;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(96, 238);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(53, 21);
            this.button确定.TabIndex = 12;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button停止
            // 
            this.button停止.Location = new System.Drawing.Point(138, 37);
            this.button停止.Name = "button停止";
            this.button停止.Size = new System.Drawing.Size(53, 21);
            this.button停止.TabIndex = 10;
            this.button停止.Text = "停止";
            this.button停止.UseVisualStyleBackColor = true;
            // 
            // button播放
            // 
            this.button播放.Location = new System.Drawing.Point(138, 10);
            this.button播放.Name = "button播放";
            this.button播放.Size = new System.Drawing.Size(53, 21);
            this.button播放.TabIndex = 9;
            this.button播放.Text = "播放";
            this.button播放.UseVisualStyleBackColor = true;
            // 
            // listBox音乐
            // 
            this.listBox音乐.FormattingEnabled = true;
            this.listBox音乐.ItemHeight = 12;
            this.listBox音乐.Location = new System.Drawing.Point(12, 25);
            this.listBox音乐.Name = "listBox音乐";
            this.listBox音乐.Size = new System.Drawing.Size(90, 184);
            this.listBox音乐.TabIndex = 8;
            this.listBox音乐.SelectedIndexChanged += new System.EventHandler(this.listBox音乐_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "WAV音乐:";
            // 
            // Form播放WAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 268);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.button停止);
            this.Controls.Add(this.button播放);
            this.Controls.Add(this.listBox音乐);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form播放WAV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放WAV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button停止;
        private System.Windows.Forms.Button button播放;
        private System.Windows.Forms.ListBox listBox音乐;
        private System.Windows.Forms.Label label1;
    }
}
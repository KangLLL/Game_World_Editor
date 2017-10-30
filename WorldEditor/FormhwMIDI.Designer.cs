namespace WorldEditor
{
    partial class Form播放MIDI
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
            this.listBox音乐 = new System.Windows.Forms.ListBox();
            this.button播放 = new System.Windows.Forms.Button();
            this.button停止 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.checkBox循环播放 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIDI音乐:";
            // 
            // listBox音乐
            // 
            this.listBox音乐.FormattingEnabled = true;
            this.listBox音乐.ItemHeight = 12;
            this.listBox音乐.Location = new System.Drawing.Point(14, 48);
            this.listBox音乐.Name = "listBox音乐";
            this.listBox音乐.Size = new System.Drawing.Size(90, 184);
            this.listBox音乐.TabIndex = 1;
            this.listBox音乐.SelectedIndexChanged += new System.EventHandler(this.listBox音乐_SelectedIndexChanged);
            // 
            // button播放
            // 
            this.button播放.Location = new System.Drawing.Point(114, 48);
            this.button播放.Name = "button播放";
            this.button播放.Size = new System.Drawing.Size(53, 21);
            this.button播放.TabIndex = 2;
            this.button播放.Text = "播放";
            this.button播放.UseVisualStyleBackColor = true;
            // 
            // button停止
            // 
            this.button停止.Location = new System.Drawing.Point(114, 75);
            this.button停止.Name = "button停止";
            this.button停止.Size = new System.Drawing.Size(53, 21);
            this.button停止.TabIndex = 3;
            this.button停止.Text = "停止";
            this.button停止.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(87, 261);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(53, 21);
            this.button确定.TabIndex = 5;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(157, 261);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(53, 21);
            this.button取消.TabIndex = 6;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // checkBox循环播放
            // 
            this.checkBox循环播放.AutoSize = true;
            this.checkBox循环播放.Location = new System.Drawing.Point(114, 216);
            this.checkBox循环播放.Name = "checkBox循环播放";
            this.checkBox循环播放.Size = new System.Drawing.Size(96, 16);
            this.checkBox循环播放.TabIndex = 7;
            this.checkBox循环播放.Text = "是否循环播放";
            this.checkBox循环播放.UseVisualStyleBackColor = true;
            // 
            // Form播放MIDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 294);
            this.Controls.Add(this.checkBox循环播放);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.button停止);
            this.Controls.Add(this.button播放);
            this.Controls.Add(this.listBox音乐);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form播放MIDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放MIDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox音乐;
        private System.Windows.Forms.Button button播放;
        private System.Windows.Forms.Button button停止;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.CheckBox checkBox循环播放;
    }
}
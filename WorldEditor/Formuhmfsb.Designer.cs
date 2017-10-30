namespace WorldEditor
{
    partial class Form触发区域比较
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
            this.comboBox触发区域 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(166, 117);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(44, 22);
            this.button取消.TabIndex = 7;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(114, 117);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(44, 22);
            this.button确定.TabIndex = 6;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // comboBox触发区域
            // 
            this.comboBox触发区域.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox触发区域.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox触发区域.FormattingEnabled = true;
            this.comboBox触发区域.Location = new System.Drawing.Point(30, 68);
            this.comboBox触发区域.Name = "comboBox触发区域";
            this.comboBox触发区域.Size = new System.Drawing.Size(180, 22);
            this.comboBox触发区域.TabIndex = 5;
            this.comboBox触发区域.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox触发区域_DrawItem);
            this.comboBox触发区域.SelectedIndexChanged += new System.EventHandler(this.comboBox触发区域_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "触发区域:";
            // 
            // Form触发区域比较
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 163);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox触发区域);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form触发区域比较";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "触发区域";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.ComboBox comboBox触发区域;
        private System.Windows.Forms.Label label1;
    }
}
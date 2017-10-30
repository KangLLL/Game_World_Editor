namespace WorldEditor
{
    partial class Form触发条件添加
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
            this.button变量与值比较 = new System.Windows.Forms.Button();
            this.button变量与变量比较 = new System.Windows.Forms.Button();
            this.button游戏单位比较 = new System.Windows.Forms.Button();
            this.button触发区域比较 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "条件类型:";
            // 
            // button变量与值比较
            // 
            this.button变量与值比较.Location = new System.Drawing.Point(14, 54);
            this.button变量与值比较.Name = "button变量与值比较";
            this.button变量与值比较.Size = new System.Drawing.Size(175, 26);
            this.button变量与值比较.TabIndex = 1;
            this.button变量与值比较.Text = "变量与值比较";
            this.button变量与值比较.UseVisualStyleBackColor = true;
            this.button变量与值比较.Click += new System.EventHandler(this.button变量与值比较_Click);
            // 
            // button变量与变量比较
            // 
            this.button变量与变量比较.Location = new System.Drawing.Point(14, 86);
            this.button变量与变量比较.Name = "button变量与变量比较";
            this.button变量与变量比较.Size = new System.Drawing.Size(175, 26);
            this.button变量与变量比较.TabIndex = 2;
            this.button变量与变量比较.Text = "变量与变量比较";
            this.button变量与变量比较.UseVisualStyleBackColor = true;
            this.button变量与变量比较.Click += new System.EventHandler(this.button变量与变量比较_Click);
            // 
            // button游戏单位比较
            // 
            this.button游戏单位比较.Location = new System.Drawing.Point(14, 118);
            this.button游戏单位比较.Name = "button游戏单位比较";
            this.button游戏单位比较.Size = new System.Drawing.Size(175, 26);
            this.button游戏单位比较.TabIndex = 3;
            this.button游戏单位比较.Text = "游戏单位比较";
            this.button游戏单位比较.UseVisualStyleBackColor = true;
            this.button游戏单位比较.Click += new System.EventHandler(this.button游戏单位比较_Click);
            // 
            // button触发区域比较
            // 
            this.button触发区域比较.Location = new System.Drawing.Point(14, 150);
            this.button触发区域比较.Name = "button触发区域比较";
            this.button触发区域比较.Size = new System.Drawing.Size(175, 26);
            this.button触发区域比较.TabIndex = 4;
            this.button触发区域比较.Text = "触发区域比较";
            this.button触发区域比较.UseVisualStyleBackColor = true;
            this.button触发区域比较.Click += new System.EventHandler(this.button触发区域比较_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(131, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form触发条件添加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 229);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button触发区域比较);
            this.Controls.Add(this.button游戏单位比较);
            this.Controls.Add(this.button变量与变量比较);
            this.Controls.Add(this.button变量与值比较);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form触发条件添加";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "触发条件添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button变量与值比较;
        private System.Windows.Forms.Button button变量与变量比较;
        private System.Windows.Forms.Button button游戏单位比较;
        private System.Windows.Forms.Button button触发区域比较;
        private System.Windows.Forms.Button button1;
    }
}
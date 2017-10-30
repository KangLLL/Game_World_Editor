namespace WorldEditor
{
    partial class Form新建地图
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
            this.textBox名称 = new System.Windows.Forms.TextBox();
            this.numericUpDown逻辑层高 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown逻辑层宽 = new System.Windows.Forms.NumericUpDown();
            this.button确定 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button取消 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层高)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层宽)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "名称:";
            // 
            // textBox名称
            // 
            this.textBox名称.Location = new System.Drawing.Point(3, 45);
            this.textBox名称.Name = "textBox名称";
            this.textBox名称.Size = new System.Drawing.Size(94, 21);
            this.textBox名称.TabIndex = 39;
            this.textBox名称.TextChanged += new System.EventHandler(this.textBox名称_TextChanged);
            // 
            // numericUpDown逻辑层高
            // 
            this.numericUpDown逻辑层高.Location = new System.Drawing.Point(218, 45);
            this.numericUpDown逻辑层高.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown逻辑层高.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown逻辑层高.Name = "numericUpDown逻辑层高";
            this.numericUpDown逻辑层高.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown逻辑层高.TabIndex = 43;
            this.numericUpDown逻辑层高.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDown逻辑层宽
            // 
            this.numericUpDown逻辑层宽.Location = new System.Drawing.Point(135, 45);
            this.numericUpDown逻辑层宽.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown逻辑层宽.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown逻辑层宽.Name = "numericUpDown逻辑层宽";
            this.numericUpDown逻辑层宽.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown逻辑层宽.TabIndex = 40;
            this.numericUpDown逻辑层宽.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(112, 96);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(75, 23);
            this.button确定.TabIndex = 46;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            this.button确定.Click += new System.EventHandler(this.button确定_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "宽:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "高:";
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(195, 96);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 23);
            this.button取消.TabIndex = 47;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // Form新建地图
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 138);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown逻辑层宽);
            this.Controls.Add(this.numericUpDown逻辑层高);
            this.Controls.Add(this.textBox名称);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form新建地图";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form新建地图";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层高)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑层宽)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox名称;
        private System.Windows.Forms.NumericUpDown numericUpDown逻辑层高;
        private System.Windows.Forms.NumericUpDown numericUpDown逻辑层宽;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button取消;

    }
}
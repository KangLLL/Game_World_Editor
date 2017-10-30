namespace WorldEditor
{
    partial class Form收费
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
            this.numericUpDown费用 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox信息 = new System.Windows.Forms.TextBox();
            this.textBox提示 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown费用)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "收取费用:";
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(111, 156);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(61, 19);
            this.button取消.TabIndex = 39;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(44, 156);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(61, 19);
            this.button确定.TabIndex = 38;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // numericUpDown费用
            // 
            this.numericUpDown费用.Location = new System.Drawing.Point(87, 107);
            this.numericUpDown费用.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown费用.Name = "numericUpDown费用";
            this.numericUpDown费用.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown费用.TabIndex = 37;
            this.numericUpDown费用.ValueChanged += new System.EventHandler(this.numericUpDown费用_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "显示信息:";
            // 
            // textBox信息
            // 
            this.textBox信息.Location = new System.Drawing.Point(87, 35);
            this.textBox信息.Name = "textBox信息";
            this.textBox信息.Size = new System.Drawing.Size(85, 21);
            this.textBox信息.TabIndex = 43;
            this.textBox信息.TextChanged += new System.EventHandler(this.textBox信息_TextChanged);
            // 
            // textBox提示
            // 
            this.textBox提示.Location = new System.Drawing.Point(87, 71);
            this.textBox提示.Name = "textBox提示";
            this.textBox提示.Size = new System.Drawing.Size(85, 21);
            this.textBox提示.TabIndex = 45;
            this.textBox提示.TextChanged += new System.EventHandler(this.textBox提示_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "提示:";
            // 
            // Form收费
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 201);
            this.Controls.Add(this.textBox提示);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox信息);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown费用);
            this.Name = "Form收费";
            this.Text = "Form收费";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown费用)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown费用;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox信息;
        private System.Windows.Forms.TextBox textBox提示;
        private System.Windows.Forms.Label label4;
    }
}
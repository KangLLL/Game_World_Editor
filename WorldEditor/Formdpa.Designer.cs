﻿namespace WorldEditor
{
    partial class Form逻辑值
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
            this.numericUpDown逻辑值 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑值)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown逻辑值
            // 
            this.numericUpDown逻辑值.Location = new System.Drawing.Point(88, 41);
            this.numericUpDown逻辑值.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericUpDown逻辑值.Name = "numericUpDown逻辑值";
            this.numericUpDown逻辑值.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown逻辑值.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "逻辑值:";
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(48, 93);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(57, 22);
            this.button确定.TabIndex = 2;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(111, 93);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(57, 22);
            this.button取消.TabIndex = 3;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // Form逻辑值
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 141);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown逻辑值);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form逻辑值";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form逻辑值";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown逻辑值)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown逻辑值;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
    }
}
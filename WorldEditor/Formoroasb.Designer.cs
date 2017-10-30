namespace WorldEditor
{
    partial class Form变量与值比较
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
            this.comboBox变量 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown常量 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox条件 = new System.Windows.Forms.ComboBox();
            this.button确定 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown常量)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "变量";
            // 
            // comboBox变量
            // 
            this.comboBox变量.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox变量.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox变量.FormattingEnabled = true;
            this.comboBox变量.Location = new System.Drawing.Point(14, 52);
            this.comboBox变量.Name = "comboBox变量";
            this.comboBox变量.Size = new System.Drawing.Size(108, 22);
            this.comboBox变量.TabIndex = 1;
            this.comboBox变量.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox变量_DrawItem);
            this.comboBox变量.SelectedIndexChanged += new System.EventHandler(this.comboBox变量_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "值";
            // 
            // numericUpDown常量
            // 
            this.numericUpDown常量.Location = new System.Drawing.Point(219, 52);
            this.numericUpDown常量.Name = "numericUpDown常量";
            this.numericUpDown常量.Size = new System.Drawing.Size(78, 21);
            this.numericUpDown常量.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "条件";
            // 
            // comboBox条件
            // 
            this.comboBox条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox条件.FormattingEnabled = true;
            this.comboBox条件.Items.AddRange(new object[] {
            "等于",
            "不等于",
            "大于",
            "大于等于",
            "小于",
            "小于等于"});
            this.comboBox条件.Location = new System.Drawing.Point(140, 52);
            this.comboBox条件.Name = "comboBox条件";
            this.comboBox条件.Size = new System.Drawing.Size(61, 20);
            this.comboBox条件.TabIndex = 5;
            this.comboBox条件.SelectedIndexChanged += new System.EventHandler(this.comboBox条件_SelectedIndexChanged);
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(161, 98);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(62, 24);
            this.button确定.TabIndex = 6;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(235, 98);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(62, 24);
            this.button取消.TabIndex = 7;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // Form变量与值比较
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 147);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox条件);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown常量);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox变量);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form变量与值比较";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form变量与值比较";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown常量)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox变量;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown常量;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox条件;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button取消;
    }
}
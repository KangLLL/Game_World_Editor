namespace WorldEditor
{
    partial class Form变量与变量比较
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
            this.comboBox条件 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox变量一 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox变量二 = new System.Windows.Forms.ComboBox();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.comboBox条件.Location = new System.Drawing.Point(145, 53);
            this.comboBox条件.Name = "comboBox条件";
            this.comboBox条件.Size = new System.Drawing.Size(61, 20);
            this.comboBox条件.TabIndex = 11;
            this.comboBox条件.SelectedIndexChanged += new System.EventHandler(this.comboBox条件_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "变量";
            // 
            // comboBox变量一
            // 
            this.comboBox变量一.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox变量一.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox变量一.FormattingEnabled = true;
            this.comboBox变量一.Location = new System.Drawing.Point(19, 53);
            this.comboBox变量一.Name = "comboBox变量一";
            this.comboBox变量一.Size = new System.Drawing.Size(108, 22);
            this.comboBox变量一.TabIndex = 7;
            this.comboBox变量一.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox变量一_DrawItem);
            this.comboBox变量一.SelectedIndexChanged += new System.EventHandler(this.comboBox变量一_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "变量";
            // 
            // comboBox变量二
            // 
            this.comboBox变量二.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox变量二.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox变量二.FormattingEnabled = true;
            this.comboBox变量二.Location = new System.Drawing.Point(225, 53);
            this.comboBox变量二.Name = "comboBox变量二";
            this.comboBox变量二.Size = new System.Drawing.Size(108, 22);
            this.comboBox变量二.TabIndex = 12;
            this.comboBox变量二.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox变量二_DrawItem);
            this.comboBox变量二.SelectedIndexChanged += new System.EventHandler(this.comboBox变量二_SelectedIndexChanged);
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(271, 99);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(62, 24);
            this.button取消.TabIndex = 14;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Enabled = false;
            this.button确定.Location = new System.Drawing.Point(197, 99);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(62, 24);
            this.button确定.TabIndex = 13;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // Form变量与变量比较
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 135);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.comboBox变量二);
            this.Controls.Add(this.comboBox条件);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox变量一);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form变量与变量比较";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量与变量比较";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox条件;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox变量一;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox变量二;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确定;
    }
}
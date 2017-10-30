namespace WorldEditor
{
    partial class Form新建层
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button确定 = new System.Windows.Forms.Button();
            this.numericUpDown可见层宽 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown可见层高 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox静态背景 = new System.Windows.Forms.ComboBox();
            this.comboBox动态背景 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox名称 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层宽)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层高)).BeginInit();
            this.SuspendLayout();
            // 
            // button取消
            // 
            this.button取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button取消.Location = new System.Drawing.Point(209, 128);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 23);
            this.button取消.TabIndex = 53;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "高:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "宽:";
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(122, 128);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(75, 23);
            this.button确定.TabIndex = 52;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // numericUpDown可见层宽
            // 
            this.numericUpDown可见层宽.Location = new System.Drawing.Point(162, 87);
            this.numericUpDown可见层宽.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown可见层宽.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown可见层宽.Name = "numericUpDown可见层宽";
            this.numericUpDown可见层宽.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown可见层宽.TabIndex = 48;
            this.numericUpDown可见层宽.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDown可见层高
            // 
            this.numericUpDown可见层高.Location = new System.Drawing.Point(232, 87);
            this.numericUpDown可见层高.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown可见层高.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown可见层高.Name = "numericUpDown可见层高";
            this.numericUpDown可见层高.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown可见层高.TabIndex = 51;
            this.numericUpDown可见层高.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "静态背景:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "动态背景:";
            // 
            // comboBox静态背景
            // 
            this.comboBox静态背景.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox静态背景.DropDownWidth = 64;
            this.comboBox静态背景.FormattingEnabled = true;
            this.comboBox静态背景.Location = new System.Drawing.Point(12, 88);
            this.comboBox静态背景.Name = "comboBox静态背景";
            this.comboBox静态背景.Size = new System.Drawing.Size(57, 20);
            this.comboBox静态背景.TabIndex = 56;
            // 
            // comboBox动态背景
            // 
            this.comboBox动态背景.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox动态背景.DropDownWidth = 64;
            this.comboBox动态背景.FormattingEnabled = true;
            this.comboBox动态背景.Location = new System.Drawing.Point(87, 88);
            this.comboBox动态背景.Name = "comboBox动态背景";
            this.comboBox动态背景.Size = new System.Drawing.Size(57, 20);
            this.comboBox动态背景.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "名称:";
            // 
            // textBox名称
            // 
            this.textBox名称.Location = new System.Drawing.Point(12, 36);
            this.textBox名称.Name = "textBox名称";
            this.textBox名称.Size = new System.Drawing.Size(117, 21);
            this.textBox名称.TabIndex = 59;
            this.textBox名称.TextChanged += new System.EventHandler(this.textBox名称_TextChanged);
            // 
            // Form新建层
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 173);
            this.Controls.Add(this.textBox名称);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox动态背景);
            this.Controls.Add(this.comboBox静态背景);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.numericUpDown可见层宽);
            this.Controls.Add(this.numericUpDown可见层高);
            this.Name = "Form新建层";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form新建层";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层宽)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown可见层高)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.NumericUpDown numericUpDown可见层宽;
        private System.Windows.Forms.NumericUpDown numericUpDown可见层高;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox静态背景;
        private System.Windows.Forms.ComboBox comboBox动态背景;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox名称;
    }
}
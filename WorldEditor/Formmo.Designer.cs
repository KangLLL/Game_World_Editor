namespace WorldEditor
{
    partial class Form地图
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
            this.components = new System.ComponentModel.Container();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.pictureBox地图窗口 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel地图信息 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button确定 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown高度 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown宽度 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox地图窗口)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown高度)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown宽度)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(12, 335);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(243, 18);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // pictureBox地图窗口
            // 
            this.pictureBox地图窗口.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox地图窗口.Location = new System.Drawing.Point(12, 12);
            this.pictureBox地图窗口.Name = "pictureBox地图窗口";
            this.pictureBox地图窗口.Size = new System.Drawing.Size(240, 320);
            this.pictureBox地图窗口.TabIndex = 0;
            this.pictureBox地图窗口.TabStop = false;
            this.pictureBox地图窗口.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox地图窗口_Paint);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(255, 12);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 323);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel地图信息});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(374, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel地图信息
            // 
            this.toolStripStatusLabel地图信息.Name = "toolStripStatusLabel地图信息";
            this.toolStripStatusLabel地图信息.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel地图信息.Text = "X=0  Y=0";
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(285, 328);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(67, 25);
            this.button确定.TabIndex = 5;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown高度);
            this.groupBox1.Controls.Add(this.numericUpDown宽度);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(285, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDown高度
            // 
            this.numericUpDown高度.Location = new System.Drawing.Point(16, 109);
            this.numericUpDown高度.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numericUpDown高度.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown高度.Name = "numericUpDown高度";
            this.numericUpDown高度.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown高度.TabIndex = 5;
            this.numericUpDown高度.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numericUpDown高度.ValueChanged += new System.EventHandler(this.numericUpDown高度_ValueChanged);
            // 
            // numericUpDown宽度
            // 
            this.numericUpDown宽度.Location = new System.Drawing.Point(16, 48);
            this.numericUpDown宽度.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numericUpDown宽度.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown宽度.Name = "numericUpDown宽度";
            this.numericUpDown宽度.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown宽度.TabIndex = 4;
            this.numericUpDown宽度.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numericUpDown宽度.ValueChanged += new System.EventHandler(this.numericUpDown宽度_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "高度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form地图
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 379);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.pictureBox地图窗口);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form地图";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form地图";
            this.Load += new System.EventHandler(this.Form地图_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox地图窗口)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown高度)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown宽度)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox地图窗口;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel地图信息;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown高度;
        private System.Windows.Forms.NumericUpDown numericUpDown宽度;
    }
}
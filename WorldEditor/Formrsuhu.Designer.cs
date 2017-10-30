namespace WorldEditor
{
    partial class Form配置触发器
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
            this.listBox触发器 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox事件类型 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox条件 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox命令 = new System.Windows.Forms.ListBox();
            this.button命令删除 = new System.Windows.Forms.Button();
            this.button命令添加 = new System.Windows.Forms.Button();
            this.button条件删除 = new System.Windows.Forms.Button();
            this.button条件添加 = new System.Windows.Forms.Button();
            this.button触发器删除 = new System.Windows.Forms.Button();
            this.button触发器添加 = new System.Windows.Forms.Button();
            this.button确定 = new System.Windows.Forms.Button();
            this.button命令上移 = new System.Windows.Forms.Button();
            this.button命令下移 = new System.Windows.Forms.Button();
            this.button编辑 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "触发器列表:";
            // 
            // listBox触发器
            // 
            this.listBox触发器.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox触发器.FormattingEnabled = true;
            this.listBox触发器.ItemHeight = 12;
            this.listBox触发器.Location = new System.Drawing.Point(31, 62);
            this.listBox触发器.Name = "listBox触发器";
            this.listBox触发器.Size = new System.Drawing.Size(132, 388);
            this.listBox触发器.TabIndex = 1;
            this.listBox触发器.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox触发器_DrawItem);
            this.listBox触发器.SelectedIndexChanged += new System.EventHandler(this.listBox触发器_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "事件类型:";
            // 
            // comboBox事件类型
            // 
            this.comboBox事件类型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox事件类型.Enabled = false;
            this.comboBox事件类型.FormattingEnabled = true;
            this.comboBox事件类型.Items.AddRange(new object[] {
            "关卡初始化",
            "进入区域",
            "离开区域",
            "单位死亡"});
            this.comboBox事件类型.Location = new System.Drawing.Point(277, 62);
            this.comboBox事件类型.Name = "comboBox事件类型";
            this.comboBox事件类型.Size = new System.Drawing.Size(215, 20);
            this.comboBox事件类型.TabIndex = 17;
            this.comboBox事件类型.SelectedIndexChanged += new System.EventHandler(this.comboBox事件类型_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "触发条件:";
            // 
            // listBox条件
            // 
            this.listBox条件.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox条件.Enabled = false;
            this.listBox条件.FormattingEnabled = true;
            this.listBox条件.ItemHeight = 12;
            this.listBox条件.Location = new System.Drawing.Point(275, 136);
            this.listBox条件.Name = "listBox条件";
            this.listBox条件.Size = new System.Drawing.Size(217, 112);
            this.listBox条件.TabIndex = 19;
            this.listBox条件.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox条件_DrawItem);
            this.listBox条件.SelectedIndexChanged += new System.EventHandler(this.listBox条件_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "动作:";
            // 
            // listBox命令
            // 
            this.listBox命令.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listBox命令.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox命令.Enabled = false;
            this.listBox命令.FormattingEnabled = true;
            this.listBox命令.ItemHeight = 12;
            this.listBox命令.Location = new System.Drawing.Point(275, 338);
            this.listBox命令.Name = "listBox命令";
            this.listBox命令.Size = new System.Drawing.Size(870, 112);
            this.listBox命令.TabIndex = 23;
            this.listBox命令.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox命令_DrawItem);
            this.listBox命令.SelectedIndexChanged += new System.EventHandler(this.listBox命令_SelectedIndexChanged);
            // 
            // button命令删除
            // 
            this.button命令删除.Enabled = false;
            this.button命令删除.Image = global::WorldEditor.Properties.Resources.Delete;
            this.button命令删除.Location = new System.Drawing.Point(479, 457);
            this.button命令删除.Name = "button命令删除";
            this.button命令删除.Size = new System.Drawing.Size(28, 28);
            this.button命令删除.TabIndex = 25;
            this.button命令删除.UseVisualStyleBackColor = true;
            this.button命令删除.Click += new System.EventHandler(this.button命令删除_Click);
            // 
            // button命令添加
            // 
            this.button命令添加.Enabled = false;
            this.button命令添加.Image = global::WorldEditor.Properties.Resources.AddNew;
            this.button命令添加.Location = new System.Drawing.Point(275, 457);
            this.button命令添加.Name = "button命令添加";
            this.button命令添加.Size = new System.Drawing.Size(28, 28);
            this.button命令添加.TabIndex = 24;
            this.button命令添加.UseVisualStyleBackColor = true;
            this.button命令添加.Click += new System.EventHandler(this.button命令添加_Click);
            // 
            // button条件删除
            // 
            this.button条件删除.Enabled = false;
            this.button条件删除.Image = global::WorldEditor.Properties.Resources.Delete;
            this.button条件删除.Location = new System.Drawing.Point(326, 271);
            this.button条件删除.Name = "button条件删除";
            this.button条件删除.Size = new System.Drawing.Size(28, 28);
            this.button条件删除.TabIndex = 21;
            this.button条件删除.UseVisualStyleBackColor = true;
            this.button条件删除.Click += new System.EventHandler(this.button条件删除_Click);
            // 
            // button条件添加
            // 
            this.button条件添加.Enabled = false;
            this.button条件添加.Image = global::WorldEditor.Properties.Resources.AddNew;
            this.button条件添加.Location = new System.Drawing.Point(275, 271);
            this.button条件添加.Name = "button条件添加";
            this.button条件添加.Size = new System.Drawing.Size(28, 28);
            this.button条件添加.TabIndex = 20;
            this.button条件添加.UseVisualStyleBackColor = true;
            this.button条件添加.Click += new System.EventHandler(this.button条件添加_Click);
            // 
            // button触发器删除
            // 
            this.button触发器删除.Enabled = false;
            this.button触发器删除.Image = global::WorldEditor.Properties.Resources.Delete;
            this.button触发器删除.Location = new System.Drawing.Point(72, 457);
            this.button触发器删除.Name = "button触发器删除";
            this.button触发器删除.Size = new System.Drawing.Size(28, 28);
            this.button触发器删除.TabIndex = 15;
            this.button触发器删除.UseVisualStyleBackColor = true;
            this.button触发器删除.Click += new System.EventHandler(this.button触发器删除_Click);
            // 
            // button触发器添加
            // 
            this.button触发器添加.Image = global::WorldEditor.Properties.Resources.AddNew;
            this.button触发器添加.Location = new System.Drawing.Point(31, 457);
            this.button触发器添加.Name = "button触发器添加";
            this.button触发器添加.Size = new System.Drawing.Size(28, 28);
            this.button触发器添加.TabIndex = 14;
            this.button触发器添加.UseVisualStyleBackColor = true;
            this.button触发器添加.Click += new System.EventHandler(this.button触发器添加_Click);
            // 
            // button确定
            // 
            this.button确定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button确定.Location = new System.Drawing.Point(1073, 517);
            this.button确定.Name = "button确定";
            this.button确定.Size = new System.Drawing.Size(72, 24);
            this.button确定.TabIndex = 26;
            this.button确定.Text = "确定";
            this.button确定.UseVisualStyleBackColor = true;
            // 
            // button命令上移
            // 
            this.button命令上移.Enabled = false;
            this.button命令上移.Image = global::WorldEditor.Properties.Resources.GoUp;
            this.button命令上移.Location = new System.Drawing.Point(377, 457);
            this.button命令上移.Name = "button命令上移";
            this.button命令上移.Size = new System.Drawing.Size(28, 28);
            this.button命令上移.TabIndex = 27;
            this.button命令上移.UseVisualStyleBackColor = true;
            this.button命令上移.Click += new System.EventHandler(this.button命令上移_Click);
            // 
            // button命令下移
            // 
            this.button命令下移.Enabled = false;
            this.button命令下移.Image = global::WorldEditor.Properties.Resources.GoDown;
            this.button命令下移.Location = new System.Drawing.Point(428, 457);
            this.button命令下移.Name = "button命令下移";
            this.button命令下移.Size = new System.Drawing.Size(28, 28);
            this.button命令下移.TabIndex = 28;
            this.button命令下移.UseVisualStyleBackColor = true;
            this.button命令下移.Click += new System.EventHandler(this.button命令下移_Click);
            // 
            // button编辑
            // 
            this.button编辑.Enabled = false;
            this.button编辑.Image = global::WorldEditor.Properties.Resources.Pen;
            this.button编辑.Location = new System.Drawing.Point(326, 457);
            this.button编辑.Name = "button编辑";
            this.button编辑.Size = new System.Drawing.Size(28, 28);
            this.button编辑.TabIndex = 29;
            this.button编辑.UseVisualStyleBackColor = true;
            this.button编辑.Click += new System.EventHandler(this.button编辑_Click);
            // 
            // Form配置触发器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 553);
            this.Controls.Add(this.button编辑);
            this.Controls.Add(this.button命令下移);
            this.Controls.Add(this.button命令上移);
            this.Controls.Add(this.button确定);
            this.Controls.Add(this.button命令删除);
            this.Controls.Add(this.button命令添加);
            this.Controls.Add(this.listBox命令);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button条件删除);
            this.Controls.Add(this.button条件添加);
            this.Controls.Add(this.listBox条件);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox事件类型);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button触发器删除);
            this.Controls.Add(this.button触发器添加);
            this.Controls.Add(this.listBox触发器);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form配置触发器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置触发器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox触发器;
        private System.Windows.Forms.Button button触发器删除;
        private System.Windows.Forms.Button button触发器添加;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox事件类型;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox条件;
        private System.Windows.Forms.Button button条件删除;
        private System.Windows.Forms.Button button条件添加;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox命令;
        private System.Windows.Forms.Button button命令删除;
        private System.Windows.Forms.Button button命令添加;
        private System.Windows.Forms.Button button确定;
        private System.Windows.Forms.Button button命令上移;
        private System.Windows.Forms.Button button命令下移;
        private System.Windows.Forms.Button button编辑;
    }
}
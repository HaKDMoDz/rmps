namespace Me.Amon.Gtd
{
    partial class AGtd
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
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.SblEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.SbEcho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TbTool
            // 
            this.TbTool.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TbTool.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TbTool.Location = new System.Drawing.Point(0, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(464, 25);
            this.TbTool.TabIndex = 0;
            this.TbTool.Text = "toolStrip1";
            // 
            // SbEcho
            // 
            this.SbEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SblEcho});
            this.SbEcho.Location = new System.Drawing.Point(0, 300);
            this.SbEcho.Name = "SbEcho";
            this.SbEcho.Size = new System.Drawing.Size(464, 22);
            this.SbEcho.TabIndex = 1;
            this.SbEcho.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(440, 269);
            this.dataGridView1.TabIndex = 2;
            // 
            // SblEcho
            // 
            this.SblEcho.Name = "SblEcho";
            this.SblEcho.Size = new System.Drawing.Size(131, 17);
            this.SblEcho.Text = "toolStripStatusLabel1";
            // 
            // AGtd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 322);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SbEcho);
            this.Controls.Add(this.TbTool);
            this.Name = "AGtd";
            this.Text = "AGtd";
            this.Load += new System.EventHandler(this.AGtd_Load);
            this.SbEcho.ResumeLayout(false);
            this.SbEcho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ToolStripStatusLabel SblEcho;
    }
}
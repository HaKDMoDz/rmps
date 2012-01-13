namespace Me.Amon.Pwd.Pro
{
    partial class AttEdit
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GbGroup = new System.Windows.Forms.GroupBox();
            this.BtCopy = new System.Windows.Forms.Button();
            this.BtSave = new System.Windows.Forms.Button();
            this.BtDrop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbGroup
            // 
            this.GbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbGroup.Controls.Add(this.panel1);
            this.GbGroup.Controls.Add(this.BtDrop);
            this.GbGroup.Controls.Add(this.BtSave);
            this.GbGroup.Controls.Add(this.BtCopy);
            this.GbGroup.Location = new System.Drawing.Point(0, 0);
            this.GbGroup.Name = "GbGroup";
            this.GbGroup.Size = new System.Drawing.Size(386, 110);
            this.GbGroup.TabIndex = 0;
            this.GbGroup.TabStop = false;
            this.GbGroup.Text = "groupBox1";
            // 
            // BtCopy
            // 
            this.BtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCopy.Location = new System.Drawing.Point(359, 29);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(21, 21);
            this.BtCopy.TabIndex = 0;
            this.BtCopy.Text = "b";
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // BtSave
            // 
            this.BtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSave.Location = new System.Drawing.Point(359, 56);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(21, 21);
            this.BtSave.TabIndex = 1;
            this.BtSave.Text = "b";
            this.BtSave.UseVisualStyleBackColor = true;
            this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // BtDrop
            // 
            this.BtDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtDrop.Location = new System.Drawing.Point(359, 83);
            this.BtDrop.Name = "BtDrop";
            this.BtDrop.Size = new System.Drawing.Size(21, 21);
            this.BtDrop.TabIndex = 2;
            this.BtDrop.Text = "b";
            this.BtDrop.UseVisualStyleBackColor = true;
            this.BtDrop.Click += new System.EventHandler(this.BtDrop_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 84);
            this.panel1.TabIndex = 3;
            // 
            // RecEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GbGroup);
            this.Name = "RecEdit";
            this.Size = new System.Drawing.Size(386, 110);
            this.GbGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbGroup;
        private System.Windows.Forms.Button BtDrop;
        private System.Windows.Forms.Button BtSave;
        private System.Windows.Forms.Button BtCopy;
        private System.Windows.Forms.Panel panel1;

    }
}

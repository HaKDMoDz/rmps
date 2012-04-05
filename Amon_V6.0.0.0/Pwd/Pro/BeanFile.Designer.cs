﻿namespace Me.Amon.Pwd.Pro
{
    partial class BeanFile
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
            this.components = new System.ComponentModel.Container();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.BtView = new System.Windows.Forms.Button();
            this.BtOpen = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiPwdViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSysViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(56, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 33);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 2;
            this.LbData.Text = "数据(&D)";
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(56, 30);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(307, 21);
            this.TbData.TabIndex = 3;
            // 
            // BtView
            // 
            this.BtView.Location = new System.Drawing.Point(56, 57);
            this.BtView.Name = "BtView";
            this.BtView.Size = new System.Drawing.Size(21, 21);
            this.BtView.TabIndex = 4;
            this.BtView.UseVisualStyleBackColor = true;
            this.BtView.Click += new System.EventHandler(this.BtView_Click);
            // 
            // BtOpen
            // 
            this.BtOpen.Location = new System.Drawing.Point(83, 57);
            this.BtOpen.Name = "BtOpen";
            this.BtOpen.Size = new System.Drawing.Size(21, 21);
            this.BtOpen.TabIndex = 5;
            this.BtOpen.UseVisualStyleBackColor = true;
            this.BtOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiPwdViewer,
            this.MiSysViewer});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // MiPwdViewer
            // 
            this.MiPwdViewer.Name = "MiPwdViewer";
            this.MiPwdViewer.Size = new System.Drawing.Size(152, 22);
            this.MiPwdViewer.Text = "内置查看器";
            this.MiPwdViewer.Click += new System.EventHandler(this.MiPwdViewer_Click);
            // 
            // MiSysViewer
            // 
            this.MiSysViewer.Name = "MiSysViewer";
            this.MiSysViewer.Size = new System.Drawing.Size(152, 22);
            this.MiSysViewer.Text = "系统查看器";
            this.MiSysViewer.Click += new System.EventHandler(this.MiSysViewer_Click);
            // 
            // BeanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpen);
            this.Controls.Add(this.BtView);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanFile";
            this.Size = new System.Drawing.Size(366, 81);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtView;
        private System.Windows.Forms.Button BtOpen;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiPwdViewer;
        private System.Windows.Forms.ToolStripMenuItem MiSysViewer;
    }
}

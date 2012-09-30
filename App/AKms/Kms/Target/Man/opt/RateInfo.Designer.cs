namespace Me.Amon.Kms.Target.Man
{
    partial class RateInfo
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
            this.TsToolBar = new System.Windows.Forms.ToolStrip();
            this.LbInfo = new System.Windows.Forms.ToolStripLabel();
            this.CbVote = new System.Windows.Forms.ToolStripComboBox();
            this.BtVote = new System.Windows.Forms.ToolStripButton();
            this.SsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtPrev = new System.Windows.Forms.ToolStripButton();
            this.BtNext = new System.Windows.Forms.ToolStripButton();
            this.SsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.MiTags = new System.Windows.Forms.ToolStripMenuItem();
            this.Sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiAppendR = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUpdateR = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRemoveR = new System.Windows.Forms.ToolStripMenuItem();
            this.Sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUpdateQ = new System.Windows.Forms.ToolStripMenuItem();
            this.SsSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtExit = new System.Windows.Forms.ToolStripButton();
            this.TsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsToolBar
            // 
            this.TsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbInfo,
            this.CbVote,
            this.BtVote,
            this.SsSep1,
            this.BtPrev,
            this.BtNext,
            this.SsSep2,
            this.BtEdit,
            this.SsSep3,
            this.BtExit});
            this.TsToolBar.Location = new System.Drawing.Point(0, 0);
            this.TsToolBar.Name = "TsToolBar";
            this.TsToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TsToolBar.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.TabIndex = 0;
            this.TsToolBar.Text = "toolStrip1";
            // 
            // LbInfo
            // 
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(44, 22);
            this.LbInfo.Text = "投票：";
            // 
            // CbVote
            // 
            this.CbVote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbVote.Font = new System.Drawing.Font("宋体", 9F);
            this.CbVote.Name = "CbVote";
            this.CbVote.Size = new System.Drawing.Size(75, 25);
            this.CbVote.ToolTipText = "选项";
            // 
            // BtVote
            // 
            this.BtVote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtVote.Image = global::Me.Amon.Properties.Resources.vote;
            this.BtVote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtVote.Name = "BtVote";
            this.BtVote.Size = new System.Drawing.Size(23, 22);
            this.BtVote.Text = "投票";
            this.BtVote.Click += new System.EventHandler(this.BtVote_Click);
            // 
            // SsSep1
            // 
            this.SsSep1.Name = "SsSep1";
            this.SsSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtPrev
            // 
            this.BtPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtPrev.Image = global::Me.Amon.Properties.Resources.al;
            this.BtPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtPrev.Name = "BtPrev";
            this.BtPrev.Size = new System.Drawing.Size(23, 22);
            this.BtPrev.Text = "上一个回答";
            this.BtPrev.Click += new System.EventHandler(this.BtPrev_Click);
            // 
            // BtNext
            // 
            this.BtNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtNext.Image = global::Me.Amon.Properties.Resources.ar;
            this.BtNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtNext.Name = "BtNext";
            this.BtNext.Size = new System.Drawing.Size(23, 22);
            this.BtNext.Text = "下一个回答";
            this.BtNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // SsSep2
            // 
            this.SsSep2.Name = "SsSep2";
            this.SsSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtEdit
            // 
            this.BtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiTags,
            this.Sep1,
            this.MiAppendR,
            this.MiUpdateR,
            this.MiRemoveR,
            this.Sep2,
            this.MiUpdateQ});
            this.BtEdit.Image = global::Me.Amon.Properties.Resources.doc;
            this.BtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtEdit.Name = "BtEdit";
            this.BtEdit.Size = new System.Drawing.Size(29, 22);
            this.BtEdit.Text = "编辑";
            // 
            // MiTags
            // 
            this.MiTags.Name = "MiTags";
            this.MiTags.Size = new System.Drawing.Size(152, 22);
            this.MiTags.Text = "管理标签";
            this.MiTags.Click += new System.EventHandler(this.MiTags_Click);
            // 
            // Sep1
            // 
            this.Sep1.Name = "Sep1";
            this.Sep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiAppendR
            // 
            this.MiAppendR.Name = "MiAppendR";
            this.MiAppendR.Size = new System.Drawing.Size(152, 22);
            this.MiAppendR.Text = "添加新的回答";
            this.MiAppendR.Click += new System.EventHandler(this.MiAppendR_Click);
            // 
            // MiUpdateR
            // 
            this.MiUpdateR.Name = "MiUpdateR";
            this.MiUpdateR.Size = new System.Drawing.Size(152, 22);
            this.MiUpdateR.Text = "更新当前回答";
            this.MiUpdateR.Click += new System.EventHandler(this.MiUpdateR_Click);
            // 
            // MiRemoveR
            // 
            this.MiRemoveR.Name = "MiRemoveR";
            this.MiRemoveR.Size = new System.Drawing.Size(152, 22);
            this.MiRemoveR.Text = "删除当前回答";
            this.MiRemoveR.Click += new System.EventHandler(this.MiRemoveR_Click);
            // 
            // Sep2
            // 
            this.Sep2.Name = "Sep2";
            this.Sep2.Size = new System.Drawing.Size(149, 6);
            // 
            // MiUpdateQ
            // 
            this.MiUpdateQ.Name = "MiUpdateQ";
            this.MiUpdateQ.Size = new System.Drawing.Size(152, 22);
            this.MiUpdateQ.Text = "更新提问";
            this.MiUpdateQ.Click += new System.EventHandler(this.MiUpdateQ_Click);
            // 
            // SsSep3
            // 
            this.SsSep3.Name = "SsSep3";
            this.SsSep3.Size = new System.Drawing.Size(6, 25);
            // 
            // BtExit
            // 
            this.BtExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtExit.Image = global::Me.Amon.Properties.Resources.exit;
            this.BtExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtExit.Name = "BtExit";
            this.BtExit.Size = new System.Drawing.Size(23, 22);
            this.BtExit.Text = "返回";
            this.BtExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // RateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TsToolBar);
            this.Name = "RateInfo";
            this.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.ResumeLayout(false);
            this.TsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TsToolBar;
        private System.Windows.Forms.ToolStripComboBox CbVote;
        private System.Windows.Forms.ToolStripButton BtVote;
        private System.Windows.Forms.ToolStripSeparator SsSep1;
        private System.Windows.Forms.ToolStripButton BtPrev;
        private System.Windows.Forms.ToolStripButton BtNext;
        private System.Windows.Forms.ToolStripSeparator SsSep2;
        private System.Windows.Forms.ToolStripButton BtExit;
        private System.Windows.Forms.ToolStripSeparator SsSep3;
        private System.Windows.Forms.ToolStripLabel LbInfo;
        private System.Windows.Forms.ToolStripDropDownButton BtEdit;
        private System.Windows.Forms.ToolStripMenuItem MiTags;
        private System.Windows.Forms.ToolStripSeparator Sep1;
        private System.Windows.Forms.ToolStripMenuItem MiAppendR;
        private System.Windows.Forms.ToolStripMenuItem MiUpdateR;
        private System.Windows.Forms.ToolStripSeparator Sep2;
        private System.Windows.Forms.ToolStripMenuItem MiUpdateQ;
        private System.Windows.Forms.ToolStripMenuItem MiRemoveR;
    }
}

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    partial class AttViewer
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
            this.aTabControl1 = new System.Windows.Forms.TabControl();
            this.TpGuid = new System.Windows.Forms.TabPage();
            this.TpHead = new System.Windows.Forms.TabPage();
            this.TpBody = new System.Windows.Forms.TabPage();
            this.beanGuid1 = new Me.Amon.Pwd.V.Wiz.Viewer.BeanGuid();
            this.beanHead1 = new Me.Amon.Pwd.V.Wiz.Viewer.BeanHead();
            this.beanBody1 = new Me.Amon.Pwd.V.Wiz.Viewer.BeanBody();
            this.aTabControl1.SuspendLayout();
            this.TpGuid.SuspendLayout();
            this.TpHead.SuspendLayout();
            this.TpBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // aTabControl1
            // 
            this.aTabControl1.Controls.Add(this.TpGuid);
            this.aTabControl1.Controls.Add(this.TpHead);
            this.aTabControl1.Controls.Add(this.TpBody);
            this.aTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTabControl1.Location = new System.Drawing.Point(0, 0);
            this.aTabControl1.Name = "aTabControl1";
            this.aTabControl1.SelectedIndex = 0;
            this.aTabControl1.Size = new System.Drawing.Size(339, 259);
            this.aTabControl1.TabIndex = 0;
            // 
            // TpGuid
            // 
            this.TpGuid.Controls.Add(this.beanGuid1);
            this.TpGuid.Location = new System.Drawing.Point(4, 22);
            this.TpGuid.Name = "TpGuid";
            this.TpGuid.Padding = new System.Windows.Forms.Padding(3);
            this.TpGuid.Size = new System.Drawing.Size(331, 233);
            this.TpGuid.TabIndex = 0;
            this.TpGuid.Text = "操作";
            this.TpGuid.UseVisualStyleBackColor = true;
            // 
            // TpHead
            // 
            this.TpHead.Controls.Add(this.beanHead1);
            this.TpHead.Location = new System.Drawing.Point(4, 22);
            this.TpHead.Name = "TpHead";
            this.TpHead.Padding = new System.Windows.Forms.Padding(3);
            this.TpHead.Size = new System.Drawing.Size(331, 233);
            this.TpHead.TabIndex = 1;
            this.TpHead.Text = "摘要";
            this.TpHead.UseVisualStyleBackColor = true;
            // 
            // TpBody
            // 
            this.TpBody.Controls.Add(this.beanBody1);
            this.TpBody.Location = new System.Drawing.Point(4, 22);
            this.TpBody.Name = "TpBody";
            this.TpBody.Size = new System.Drawing.Size(331, 233);
            this.TpBody.TabIndex = 2;
            this.TpBody.Text = "详细";
            this.TpBody.UseVisualStyleBackColor = true;
            // 
            // beanGuid1
            // 
            this.beanGuid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beanGuid1.Location = new System.Drawing.Point(3, 3);
            this.beanGuid1.Name = "beanGuid1";
            this.beanGuid1.Size = new System.Drawing.Size(325, 227);
            this.beanGuid1.TabIndex = 0;
            // 
            // beanHead1
            // 
            this.beanHead1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beanHead1.Location = new System.Drawing.Point(3, 3);
            this.beanHead1.Name = "beanHead1";
            this.beanHead1.Size = new System.Drawing.Size(325, 227);
            this.beanHead1.TabIndex = 0;
            // 
            // beanBody1
            // 
            this.beanBody1.AutoScroll = true;
            this.beanBody1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beanBody1.EditCtl = null;
            this.beanBody1.Location = new System.Drawing.Point(0, 0);
            this.beanBody1.Name = "beanBody1";
            this.beanBody1.Size = new System.Drawing.Size(331, 233);
            this.beanBody1.TabIndex = 0;
            // 
            // AttViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aTabControl1);
            this.Name = "AttViewer";
            this.Size = new System.Drawing.Size(339, 259);
            this.aTabControl1.ResumeLayout(false);
            this.TpGuid.ResumeLayout(false);
            this.TpHead.ResumeLayout(false);
            this.TpBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl aTabControl1;
        private System.Windows.Forms.TabPage TpGuid;
        private System.Windows.Forms.TabPage TpHead;
        private System.Windows.Forms.TabPage TpBody;
        private BeanGuid beanGuid1;
        private BeanHead beanHead1;
        private BeanBody beanBody1;
    }
}

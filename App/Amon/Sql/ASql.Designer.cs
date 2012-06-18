namespace Me.Amon.Sql
{
    partial class ASql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASql));
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.LblEcho = new System.Windows.Forms.Label();
            this.BnExecute = new System.Windows.Forms.Button();
            this.ScPanel = new System.Windows.Forms.SplitContainer();
            this.TcEditor = new System.Windows.Forms.ATabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TcResult = new System.Windows.Forms.ATabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).BeginInit();
            this.ScPanel.Panel1.SuspendLayout();
            this.ScPanel.Panel2.SuspendLayout();
            this.ScPanel.SuspendLayout();
            this.TcEditor.SuspendLayout();
            this.TcResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbMenu
            // 
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 390);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 2;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // LblEcho
            // 
            this.LblEcho.AutoSize = true;
            this.LblEcho.Location = new System.Drawing.Point(34, 392);
            this.LblEcho.Name = "LblEcho";
            this.LblEcho.Size = new System.Drawing.Size(41, 12);
            this.LblEcho.TabIndex = 3;
            this.LblEcho.Text = "label1";
            // 
            // BnExecute
            // 
            this.BnExecute.Location = new System.Drawing.Point(577, 387);
            this.BnExecute.Name = "BnExecute";
            this.BnExecute.Size = new System.Drawing.Size(75, 23);
            this.BnExecute.TabIndex = 1;
            this.BnExecute.Text = "执行(&R)";
            this.BnExecute.UseVisualStyleBackColor = true;
            this.BnExecute.Click += new System.EventHandler(this.BnExecute_Click);
            // 
            // ScPanel
            // 
            this.ScPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScPanel.Location = new System.Drawing.Point(12, 12);
            this.ScPanel.Name = "ScPanel";
            this.ScPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScPanel.Panel1
            // 
            this.ScPanel.Panel1.Controls.Add(this.TcEditor);
            // 
            // ScPanel.Panel2
            // 
            this.ScPanel.Panel2.Controls.Add(this.TcResult);
            this.ScPanel.Size = new System.Drawing.Size(640, 369);
            this.ScPanel.SplitterDistance = 164;
            this.ScPanel.TabIndex = 0;
            // 
            // TcEditor
            // 
            this.TcEditor.Controls.Add(this.tabPage1);
            this.TcEditor.Controls.Add(this.tabPage2);
            // 
            // 
            // 
            this.TcEditor.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcEditor.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcEditor.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcEditor.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcEditor.DisplayStyleProvider.FocusTrack = true;
            this.TcEditor.DisplayStyleProvider.HotTrack = true;
            this.TcEditor.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcEditor.DisplayStyleProvider.Opacity = 1F;
            this.TcEditor.DisplayStyleProvider.Overlap = 0;
            this.TcEditor.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcEditor.DisplayStyleProvider.Radius = 2;
            this.TcEditor.DisplayStyleProvider.ShowTabCloser = true;
            this.TcEditor.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcEditor.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcEditor.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcEditor.HotTrack = true;
            this.TcEditor.Location = new System.Drawing.Point(0, 0);
            this.TcEditor.Name = "TcEditor";
            this.TcEditor.SelectedIndex = 0;
            this.TcEditor.Size = new System.Drawing.Size(640, 164);
            this.TcEditor.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(632, 137);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(632, 137);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TcResult
            // 
            this.TcResult.Controls.Add(this.tabPage3);
            this.TcResult.Controls.Add(this.tabPage4);
            // 
            // 
            // 
            this.TcResult.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcResult.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcResult.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcResult.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcResult.DisplayStyleProvider.FocusTrack = true;
            this.TcResult.DisplayStyleProvider.HotTrack = true;
            this.TcResult.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcResult.DisplayStyleProvider.Opacity = 1F;
            this.TcResult.DisplayStyleProvider.Overlap = 0;
            this.TcResult.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcResult.DisplayStyleProvider.Radius = 2;
            this.TcResult.DisplayStyleProvider.ShowTabCloser = true;
            this.TcResult.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcResult.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcResult.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcResult.HotTrack = true;
            this.TcResult.Location = new System.Drawing.Point(0, 0);
            this.TcResult.Name = "TcResult";
            this.TcResult.SelectedIndex = 0;
            this.TcResult.Size = new System.Drawing.Size(640, 201);
            this.TcResult.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(632, 174);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(632, 174);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ASql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 422);
            this.Controls.Add(this.ScPanel);
            this.Controls.Add(this.BnExecute);
            this.Controls.Add(this.LblEcho);
            this.Controls.Add(this.PbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ASql";
            this.Text = "数据库管理";
            this.Load += new System.EventHandler(this.ASql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.ScPanel.Panel1.ResumeLayout(false);
            this.ScPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).EndInit();
            this.ScPanel.ResumeLayout(false);
            this.TcEditor.ResumeLayout(false);
            this.TcResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LblEcho;
        private System.Windows.Forms.Button BnExecute;
        private System.Windows.Forms.SplitContainer ScPanel;
        private System.Windows.Forms.ATabControl TcEditor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ATabControl TcResult;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}
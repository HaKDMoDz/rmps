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
            this.TcResult = new System.Windows.Forms.ATabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dbResult1 = new Me.Amon.Sql.V.DbResult();
            this.TcParams = new System.Windows.Forms.ATabControl();
            this.TpPdq = new System.Windows.Forms.TabPage();
            this.UcUdf = new Me.Amon.Sql.Editor.PdqEditor();
            this.TpSql = new System.Windows.Forms.TabPage();
            this.UcSql = new Me.Amon.Sql.Editor.SqlEditor();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.TcResult.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.TcParams.SuspendLayout();
            this.TpPdq.SuspendLayout();
            this.TpSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbMenu
            // 
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 380);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 2;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // LblEcho
            // 
            this.LblEcho.AutoSize = true;
            this.LblEcho.Location = new System.Drawing.Point(34, 382);
            this.LblEcho.Name = "LblEcho";
            this.LblEcho.Size = new System.Drawing.Size(41, 12);
            this.LblEcho.TabIndex = 3;
            this.LblEcho.Text = "label1";
            // 
            // BnExecute
            // 
            this.BnExecute.Location = new System.Drawing.Point(609, 377);
            this.BnExecute.Name = "BnExecute";
            this.BnExecute.Size = new System.Drawing.Size(75, 23);
            this.BnExecute.TabIndex = 4;
            this.BnExecute.Text = "执行(&R)";
            this.BnExecute.UseVisualStyleBackColor = true;
            this.BnExecute.Click += new System.EventHandler(this.BnExecute_Click);
            // 
            // TcResult
            // 
            this.TcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcResult.Controls.Add(this.tabPage3);
            this.TcResult.DisplayStyle = System.Windows.Forms.TabStyle.Amon;
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
            this.TcResult.HotTrack = true;
            this.TcResult.Location = new System.Drawing.Point(12, 181);
            this.TcResult.Name = "TcResult";
            this.TcResult.SelectedIndex = 0;
            this.TcResult.Size = new System.Drawing.Size(672, 190);
            this.TcResult.TabIndex = 1;
            this.TcResult.TabClosing += new System.EventHandler<System.Windows.Forms.TabControlCancelEventArgs>(this.TcResult_TabClosing);
            this.TcResult.SelectedIndexChanged += new System.EventHandler(this.TcResult_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dbResult1);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(664, 163);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "结果";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dbResult1
            // 
            this.dbResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbResult1.Location = new System.Drawing.Point(3, 3);
            this.dbResult1.Name = "dbResult1";
            this.dbResult1.Size = new System.Drawing.Size(658, 157);
            this.dbResult1.TabIndex = 0;
            // 
            // TcParams
            // 
            this.TcParams.Controls.Add(this.TpPdq);
            this.TcParams.Controls.Add(this.TpSql);
            // 
            // 
            // 
            this.TcParams.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcParams.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcParams.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcParams.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcParams.DisplayStyleProvider.FocusTrack = true;
            this.TcParams.DisplayStyleProvider.HotTrack = true;
            this.TcParams.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcParams.DisplayStyleProvider.Opacity = 1F;
            this.TcParams.DisplayStyleProvider.Overlap = 0;
            this.TcParams.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcParams.DisplayStyleProvider.Radius = 2;
            this.TcParams.DisplayStyleProvider.ShowTabCloser = false;
            this.TcParams.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcParams.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcParams.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcParams.HotTrack = true;
            this.TcParams.Location = new System.Drawing.Point(12, 12);
            this.TcParams.Name = "TcParams";
            this.TcParams.SelectedIndex = 0;
            this.TcParams.Size = new System.Drawing.Size(672, 163);
            this.TcParams.TabIndex = 0;
            this.TcParams.SelectedIndexChanged += new System.EventHandler(this.TcParams_SelectedIndexChanged);
            // 
            // TpPdq
            // 
            this.TpPdq.Controls.Add(this.UcUdf);
            this.TpPdq.Location = new System.Drawing.Point(4, 23);
            this.TpPdq.Name = "TpPdq";
            this.TpPdq.Padding = new System.Windows.Forms.Padding(3);
            this.TpPdq.Size = new System.Drawing.Size(664, 136);
            this.TpPdq.TabIndex = 0;
            this.TpPdq.Text = "向导模式";
            this.TpPdq.UseVisualStyleBackColor = true;
            // 
            // UcUdf
            // 
            this.UcUdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcUdf.Location = new System.Drawing.Point(3, 3);
            this.UcUdf.Name = "UcUdf";
            this.UcUdf.Size = new System.Drawing.Size(658, 130);
            this.UcUdf.TabIndex = 0;
            // 
            // TpSql
            // 
            this.TpSql.Controls.Add(this.UcSql);
            this.TpSql.Location = new System.Drawing.Point(4, 23);
            this.TpSql.Name = "TpSql";
            this.TpSql.Padding = new System.Windows.Forms.Padding(3);
            this.TpSql.Size = new System.Drawing.Size(664, 136);
            this.TpSql.TabIndex = 1;
            this.TpSql.Text = "高级模式";
            this.TpSql.UseVisualStyleBackColor = true;
            // 
            // UcSql
            // 
            this.UcSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcSql.Location = new System.Drawing.Point(3, 3);
            this.UcSql.Name = "UcSql";
            this.UcSql.Size = new System.Drawing.Size(658, 126);
            this.UcSql.TabIndex = 0;
            // 
            // ASql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 412);
            this.Controls.Add(this.BnExecute);
            this.Controls.Add(this.LblEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.TcResult);
            this.Controls.Add(this.TcParams);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ASql";
            this.Text = "数据库管理";
            this.Load += new System.EventHandler(this.ASql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.TcResult.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.TcParams.ResumeLayout(false);
            this.TpPdq.ResumeLayout(false);
            this.TpSql.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ATabControl TcParams;
        private System.Windows.Forms.TabPage TpPdq;
        private System.Windows.Forms.TabPage TpSql;
        private System.Windows.Forms.ATabControl TcResult;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LblEcho;
        private System.Windows.Forms.Button BnExecute;
        private Editor.PdqEditor UcUdf;
        private Editor.SqlEditor UcSql;
        private V.DbResult dbResult1;
    }
}
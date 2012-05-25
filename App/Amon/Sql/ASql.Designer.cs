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
            this.TcParams = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TcResult = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.LblEcho = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.UcUdf = new Me.Amon.Sql.Editor.UdfEditor();
            this.UcSql = new Me.Amon.Sql.Editor.SqlEditor();
            this.TcParams.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TcResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // TcParams
            // 
            this.TcParams.Controls.Add(this.tabPage1);
            this.TcParams.Controls.Add(this.tabPage2);
            this.TcParams.Location = new System.Drawing.Point(12, 12);
            this.TcParams.Name = "TcParams";
            this.TcParams.SelectedIndex = 0;
            this.TcParams.Size = new System.Drawing.Size(672, 163);
            this.TcParams.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UcUdf);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(664, 137);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UcSql);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 137);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TcResult
            // 
            this.TcResult.Controls.Add(this.tabPage3);
            this.TcResult.Location = new System.Drawing.Point(12, 181);
            this.TcResult.Name = "TcResult";
            this.TcResult.SelectedIndex = 0;
            this.TcResult.Size = new System.Drawing.Size(672, 167);
            this.TcResult.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(664, 141);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(609, 377);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "执行(&R)";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtSelect_Click);
            // 
            // UcUdf
            // 
            this.UcUdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcUdf.Location = new System.Drawing.Point(3, 3);
            this.UcUdf.Name = "UcUdf";
            this.UcUdf.Size = new System.Drawing.Size(658, 131);
            this.UcUdf.TabIndex = 0;
            // 
            // UcSql
            // 
            this.UcSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcSql.Location = new System.Drawing.Point(3, 3);
            this.UcSql.Name = "UcSql";
            this.UcSql.Size = new System.Drawing.Size(658, 131);
            this.UcSql.TabIndex = 0;
            // 
            // ASql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 412);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.TcResult);
            this.Controls.Add(this.TcParams);
            this.Name = "ASql";
            this.Text = "ASql";
            this.Load += new System.EventHandler(this.ASql_Load);
            this.TcParams.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.TcResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcParams;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl TcResult;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LblEcho;
        private System.Windows.Forms.Button BtnOk;
        private Editor.UdfEditor UcUdf;
        private Editor.SqlEditor UcSql;
    }
}
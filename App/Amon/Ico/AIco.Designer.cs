namespace Me.Amon.Ico
{
    partial class AIco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIco));
            this.TcIco = new System.Windows.Forms.TabControl();
            this.TpIco0 = new System.Windows.Forms.TabPage();
            this.LvIco = new System.Windows.Forms.ListView();
            this.IlIco = new System.Windows.Forms.ImageList(this.components);
            this.TpIco1 = new System.Windows.Forms.TabPage();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.LlEcho = new System.Windows.Forms.Label();
            this.BnSave = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TcIco.SuspendLayout();
            this.TpIco0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // TcIco
            // 
            this.TcIco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcIco.Controls.Add(this.TpIco0);
            this.TcIco.Controls.Add(this.TpIco1);
            this.TcIco.Location = new System.Drawing.Point(12, 12);
            this.TcIco.Name = "TcIco";
            this.TcIco.SelectedIndex = 0;
            this.TcIco.Size = new System.Drawing.Size(621, 331);
            this.TcIco.TabIndex = 0;
            // 
            // TpIco0
            // 
            this.TpIco0.Controls.Add(this.LvIco);
            this.TpIco0.Location = new System.Drawing.Point(4, 22);
            this.TpIco0.Name = "TpIco0";
            this.TpIco0.Padding = new System.Windows.Forms.Padding(3);
            this.TpIco0.Size = new System.Drawing.Size(613, 305);
            this.TpIco0.TabIndex = 0;
            this.TpIco0.Text = "图标列表";
            this.TpIco0.UseVisualStyleBackColor = true;
            // 
            // LvIco
            // 
            this.LvIco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvIco.LargeImageList = this.IlIco;
            this.LvIco.Location = new System.Drawing.Point(3, 3);
            this.LvIco.Name = "LvIco";
            this.LvIco.Size = new System.Drawing.Size(607, 299);
            this.LvIco.TabIndex = 0;
            this.LvIco.UseCompatibleStateImageBehavior = false;
            this.LvIco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvIco_MouseDoubleClick);
            // 
            // IlIco
            // 
            this.IlIco.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlIco.ImageSize = new System.Drawing.Size(32, 32);
            this.IlIco.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TpIco1
            // 
            this.TpIco1.Location = new System.Drawing.Point(4, 22);
            this.TpIco1.Name = "TpIco1";
            this.TpIco1.Padding = new System.Windows.Forms.Padding(3);
            this.TpIco1.Size = new System.Drawing.Size(613, 305);
            this.TpIco1.TabIndex = 1;
            this.TpIco1.Text = "tabPage2";
            this.TpIco1.UseVisualStyleBackColor = true;
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 352);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 1;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // LlEcho
            // 
            this.LlEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlEcho.AutoSize = true;
            this.LlEcho.Location = new System.Drawing.Point(34, 354);
            this.LlEcho.Name = "LlEcho";
            this.LlEcho.Size = new System.Drawing.Size(41, 12);
            this.LlEcho.TabIndex = 2;
            this.LlEcho.Text = "label1";
            // 
            // BnSave
            // 
            this.BnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSave.Location = new System.Drawing.Point(558, 349);
            this.BnSave.Name = "BnSave";
            this.BnSave.Size = new System.Drawing.Size(75, 23);
            this.BnSave.TabIndex = 3;
            this.BnSave.Text = "保存(&S)";
            this.BnSave.UseVisualStyleBackColor = true;
            this.BnSave.Click += new System.EventHandler(this.BnSave_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // AIco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 384);
            this.Controls.Add(this.BnSave);
            this.Controls.Add(this.LlEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.TcIco);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AIco";
            this.Text = "图标编辑";
            this.Load += new System.EventHandler(this.AIco_Load);
            this.TcIco.ResumeLayout(false);
            this.TpIco0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcIco;
        private System.Windows.Forms.TabPage TpIco0;
        private System.Windows.Forms.TabPage TpIco1;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LlEcho;
        private System.Windows.Forms.Button BnSave;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ListView LvIco;
        private System.Windows.Forms.ImageList IlIco;
    }
}
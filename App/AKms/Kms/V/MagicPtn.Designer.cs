namespace Me.Amon.Kms.V
{
    partial class MagicPtn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicPtn));
            this.TpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PbExit = new System.Windows.Forms.PictureBox();
            this.PbHide = new System.Windows.Forms.PictureBox();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PlHead = new System.Windows.Forms.Panel();
            this.LbText = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.TpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.PlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TpPanel
            // 
            this.TpPanel.BackColor = System.Drawing.Color.Transparent;
            this.TpPanel.ColumnCount = 4;
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TpPanel.Controls.Add(this.PbExit, 3, 0);
            this.TpPanel.Controls.Add(this.PbHide, 2, 0);
            this.TpPanel.Controls.Add(this.PbMenu, 1, 0);
            this.TpPanel.Controls.Add(this.PlHead, 0, 0);
            this.TpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpPanel.Location = new System.Drawing.Point(0, 0);
            this.TpPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TpPanel.Name = "TpPanel";
            this.TpPanel.RowCount = 2;
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpPanel.Size = new System.Drawing.Size(300, 300);
            this.TpPanel.TabIndex = 0;
            // 
            // PbExit
            // 
            this.PbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbExit.Location = new System.Drawing.Point(276, 0);
            this.PbExit.Margin = new System.Windows.Forms.Padding(0);
            this.PbExit.Name = "PbExit";
            this.PbExit.Size = new System.Drawing.Size(20, 28);
            this.PbExit.TabIndex = 0;
            this.PbExit.TabStop = false;
            this.TpTips.SetToolTip(this.PbExit, "关闭");
            this.PbExit.MouseLeave += new System.EventHandler(this.PbExit_MouseLeave);
            this.PbExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbExit_MouseDown);
            this.PbExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbExit_MouseUp);
            this.PbExit.MouseEnter += new System.EventHandler(this.PbExit_MouseEnter);
            // 
            // PbHide
            // 
            this.PbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbHide.Location = new System.Drawing.Point(256, 0);
            this.PbHide.Margin = new System.Windows.Forms.Padding(0);
            this.PbHide.Name = "PbHide";
            this.PbHide.Size = new System.Drawing.Size(20, 28);
            this.PbHide.TabIndex = 2;
            this.PbHide.TabStop = false;
            this.TpTips.SetToolTip(this.PbHide, "隐藏");
            this.PbHide.MouseLeave += new System.EventHandler(this.PbHide_MouseLeave);
            this.PbHide.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbHide_MouseDown);
            this.PbHide.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbHide_MouseUp);
            this.PbHide.MouseEnter += new System.EventHandler(this.PbHide_MouseEnter);
            // 
            // PbMenu
            // 
            this.PbMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbMenu.Location = new System.Drawing.Point(236, 0);
            this.PbMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(20, 28);
            this.PbMenu.TabIndex = 1;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "选项");
            this.PbMenu.MouseLeave += new System.EventHandler(this.PbMenu_MouseLeave);
            this.PbMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbMenu_MouseDown);
            this.PbMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbMenu_MouseUp);
            this.PbMenu.MouseEnter += new System.EventHandler(this.PbMenu_MouseEnter);
            // 
            // PlHead
            // 
            this.PlHead.Controls.Add(this.LbText);
            this.PlHead.Controls.Add(this.PbLogo);
            this.PlHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlHead.Location = new System.Drawing.Point(0, 0);
            this.PlHead.Margin = new System.Windows.Forms.Padding(0);
            this.PlHead.Name = "PlHead";
            this.PlHead.Size = new System.Drawing.Size(236, 28);
            this.PlHead.TabIndex = 3;
            this.PlHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinFormMouseMove);
            this.PlHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinFormMouseDown);
            this.PlHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinFormMouseUp);
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(26, 7);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(0, 12);
            this.LbText.TabIndex = 1;
            // 
            // PbLogo
            // 
            this.PbLogo.Image = global::Me.Amon.Properties.Resources.Logo16;
            this.PbLogo.Location = new System.Drawing.Point(7, 5);
            this.PbLogo.Margin = new System.Windows.Forms.Padding(0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(16, 16);
            this.PbLogo.TabIndex = 0;
            this.PbLogo.TabStop = false;
            // 
            // MagicPtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.TpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagicPtn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.MagicPtn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MagicPtn_Paint);
            this.Resize += new System.EventHandler(this.MagicPtn_Resize);
            this.TpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.PlHead.ResumeLayout(false);
            this.PlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TpPanel;
        private System.Windows.Forms.PictureBox PbExit;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.PictureBox PbHide;
        private System.Windows.Forms.Panel PlHead;
        private System.Windows.Forms.Label LbText;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
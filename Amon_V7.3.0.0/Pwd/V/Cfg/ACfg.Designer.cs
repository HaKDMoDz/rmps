namespace Me.Amon.Pwd.V.Cfg
{
    partial class ACfg
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpGeneral = new System.Windows.Forms.TabPage();
            this.TpSecurity = new System.Windows.Forms.TabPage();
            this.TpStorage = new System.Windows.Forms.TabPage();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.ucGeneral1 = new Me.Amon.Pwd.V.Cfg.UcGeneral();
            this.ucSecurity1 = new Me.Amon.Pwd.V.Cfg.UcSecurity();
            this.ucStorage1 = new Me.Amon.Pwd.V.Cfg.UcStorage();
            this.tabControl1.SuspendLayout();
            this.TpGeneral.SuspendLayout();
            this.TpSecurity.SuspendLayout();
            this.TpStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TpGeneral);
            this.tabControl1.Controls.Add(this.TpSecurity);
            this.tabControl1.Controls.Add(this.TpStorage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 189);
            this.tabControl1.TabIndex = 0;
            // 
            // TpGeneral
            // 
            this.TpGeneral.Controls.Add(this.ucGeneral1);
            this.TpGeneral.Location = new System.Drawing.Point(4, 22);
            this.TpGeneral.Name = "TpGeneral";
            this.TpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TpGeneral.Size = new System.Drawing.Size(322, 163);
            this.TpGeneral.TabIndex = 0;
            this.TpGeneral.Text = "常规选项";
            this.TpGeneral.UseVisualStyleBackColor = true;
            // 
            // TpSecurity
            // 
            this.TpSecurity.Controls.Add(this.ucSecurity1);
            this.TpSecurity.Location = new System.Drawing.Point(4, 22);
            this.TpSecurity.Name = "TpSecurity";
            this.TpSecurity.Padding = new System.Windows.Forms.Padding(3);
            this.TpSecurity.Size = new System.Drawing.Size(322, 163);
            this.TpSecurity.TabIndex = 1;
            this.TpSecurity.Text = "安全设置";
            this.TpSecurity.UseVisualStyleBackColor = true;
            // 
            // TpStorage
            // 
            this.TpStorage.Controls.Add(this.ucStorage1);
            this.TpStorage.Location = new System.Drawing.Point(4, 22);
            this.TpStorage.Name = "TpStorage";
            this.TpStorage.Size = new System.Drawing.Size(322, 163);
            this.TpStorage.TabIndex = 2;
            this.TpStorage.Text = "网络存储";
            this.TpStorage.UseVisualStyleBackColor = true;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(186, 207);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(267, 207);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 2;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // ucGeneral1
            // 
            this.ucGeneral1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGeneral1.Location = new System.Drawing.Point(3, 3);
            this.ucGeneral1.Name = "ucGeneral1";
            this.ucGeneral1.Size = new System.Drawing.Size(316, 157);
            this.ucGeneral1.TabIndex = 0;
            // 
            // ucSecurity1
            // 
            this.ucSecurity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSecurity1.Location = new System.Drawing.Point(3, 3);
            this.ucSecurity1.Name = "ucSecurity1";
            this.ucSecurity1.Size = new System.Drawing.Size(316, 157);
            this.ucSecurity1.TabIndex = 0;
            // 
            // ucStorage1
            // 
            this.ucStorage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStorage1.Location = new System.Drawing.Point(0, 0);
            this.ucStorage1.Name = "ucStorage1";
            this.ucStorage1.Size = new System.Drawing.Size(322, 163);
            this.ucStorage1.TabIndex = 0;
            // 
            // ACfg
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(354, 242);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACfg";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.ACfg_Load);
            this.tabControl1.ResumeLayout(false);
            this.TpGeneral.ResumeLayout(false);
            this.TpSecurity.ResumeLayout(false);
            this.TpStorage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpGeneral;
        private System.Windows.Forms.TabPage TpSecurity;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.TabPage TpStorage;
        private UcGeneral ucGeneral1;
        private UcSecurity ucSecurity1;
        private UcStorage ucStorage1;
    }
}
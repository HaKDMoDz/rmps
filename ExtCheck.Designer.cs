namespace com.amonsoft.exts
{
    partial class FM_ExtCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_ExtCheck));
            this.LV_ExtsList = new System.Windows.Forms.ListView();
            this.CH_ExtsName = new System.Windows.Forms.ColumnHeader();
            this.CH_ExtsMime = new System.Windows.Forms.ColumnHeader();
            this.CH_ExtsIcon = new System.Windows.Forms.ColumnHeader();
            this.CH_ExtsDesp = new System.Windows.Forms.ColumnHeader();
            this.IL_ExtsList = new System.Windows.Forms.ImageList(this.components);
            this.BT_SaveExts = new System.Windows.Forms.Button();
            this.BT_FindExts = new System.Windows.Forms.Button();
            this.LB_ExtsInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LV_ExtsList
            // 
            this.LV_ExtsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CH_ExtsName,
            this.CH_ExtsMime,
            this.CH_ExtsIcon,
            this.CH_ExtsDesp});
            this.LV_ExtsList.Location = new System.Drawing.Point(12, 12);
            this.LV_ExtsList.Name = "LV_ExtsList";
            this.LV_ExtsList.Size = new System.Drawing.Size(328, 183);
            this.LV_ExtsList.SmallImageList = this.IL_ExtsList;
            this.LV_ExtsList.TabIndex = 0;
            this.LV_ExtsList.UseCompatibleStateImageBehavior = false;
            this.LV_ExtsList.View = System.Windows.Forms.View.Details;
            this.LV_ExtsList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LV_ExtsList_KeyUp);
            // 
            // CH_ExtsName
            // 
            this.CH_ExtsName.Text = "后缀名称";
            this.CH_ExtsName.Width = 70;
            // 
            // CH_ExtsMime
            // 
            this.CH_ExtsMime.Text = "MIME类型";
            this.CH_ExtsMime.Width = 70;
            // 
            // CH_ExtsIcon
            // 
            this.CH_ExtsIcon.Text = "图标路径";
            this.CH_ExtsIcon.Width = 80;
            // 
            // CH_ExtsDesp
            // 
            this.CH_ExtsDesp.Text = "后缀描述";
            this.CH_ExtsDesp.Width = 80;
            // 
            // IL_ExtsList
            // 
            this.IL_ExtsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IL_ExtsList.ImageSize = new System.Drawing.Size(16, 16);
            this.IL_ExtsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BT_SaveExts
            // 
            this.BT_SaveExts.Enabled = false;
            this.BT_SaveExts.Location = new System.Drawing.Point(265, 201);
            this.BT_SaveExts.Name = "BT_SaveExts";
            this.BT_SaveExts.Size = new System.Drawing.Size(75, 23);
            this.BT_SaveExts.TabIndex = 1;
            this.BT_SaveExts.Text = "上传(&U)";
            this.BT_SaveExts.UseVisualStyleBackColor = true;
            this.BT_SaveExts.Click += new System.EventHandler(this.BT_SaveExts_Click);
            // 
            // BT_FindExts
            // 
            this.BT_FindExts.Location = new System.Drawing.Point(184, 201);
            this.BT_FindExts.Name = "BT_FindExts";
            this.BT_FindExts.Size = new System.Drawing.Size(75, 23);
            this.BT_FindExts.TabIndex = 1;
            this.BT_FindExts.Text = "检测(&F)";
            this.BT_FindExts.UseVisualStyleBackColor = true;
            this.BT_FindExts.Click += new System.EventHandler(this.BT_FindExts_Click);
            // 
            // LB_ExtsInfo
            // 
            this.LB_ExtsInfo.AutoSize = true;
            this.LB_ExtsInfo.Location = new System.Drawing.Point(12, 209);
            this.LB_ExtsInfo.Name = "LB_ExtsInfo";
            this.LB_ExtsInfo.Size = new System.Drawing.Size(137, 12);
            this.LB_ExtsInfo.TabIndex = 2;
            this.LB_ExtsInfo.Text = "用于检测不同后缀数据！";
            // 
            // FM_ExtCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 236);
            this.Controls.Add(this.LB_ExtsInfo);
            this.Controls.Add(this.BT_FindExts);
            this.Controls.Add(this.BT_SaveExts);
            this.Controls.Add(this.LV_ExtsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FM_ExtCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "后缀检测";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_ExtsList;
        private System.Windows.Forms.Button BT_SaveExts;
        private System.Windows.Forms.Button BT_FindExts;
        private System.Windows.Forms.Label LB_ExtsInfo;
        private System.Windows.Forms.ImageList IL_ExtsList;
        private System.Windows.Forms.ColumnHeader CH_ExtsName;
        private System.Windows.Forms.ColumnHeader CH_ExtsMime;
        private System.Windows.Forms.ColumnHeader CH_ExtsIcon;
        private System.Windows.Forms.ColumnHeader CH_ExtsDesp;
    }
}
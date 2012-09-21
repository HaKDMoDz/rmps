namespace Me.Amon.Kms.V.Cfg
{
    partial class UserCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCfg));
            this.BtSaveAll = new System.Windows.Forms.Button();
            this.BtSaveCur = new System.Windows.Forms.Button();
            this.LsItem = new System.Windows.Forms.ListBox();
            this.BtCancel = new System.Windows.Forms.Button();
            this.GbItem = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // BtSaveAll
            // 
            this.BtSaveAll.Location = new System.Drawing.Point(145, 231);
            this.BtSaveAll.Name = "BtSaveAll";
            this.BtSaveAll.Size = new System.Drawing.Size(75, 23);
            this.BtSaveAll.TabIndex = 2;
            this.BtSaveAll.Text = "确定(&O)";
            this.BtSaveAll.UseVisualStyleBackColor = true;
            this.BtSaveAll.Click += new System.EventHandler(this.BtSaveAll_Click);
            // 
            // BtSaveCur
            // 
            this.BtSaveCur.Location = new System.Drawing.Point(226, 231);
            this.BtSaveCur.Name = "BtSaveCur";
            this.BtSaveCur.Size = new System.Drawing.Size(75, 23);
            this.BtSaveCur.TabIndex = 3;
            this.BtSaveCur.Text = "应用(&A)";
            this.BtSaveCur.UseVisualStyleBackColor = true;
            this.BtSaveCur.Click += new System.EventHandler(this.BtSaveCur_Click);
            // 
            // LsItem
            // 
            this.LsItem.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LsItem.FormattingEnabled = true;
            this.LsItem.ItemHeight = 19;
            this.LsItem.Location = new System.Drawing.Point(12, 12);
            this.LsItem.Name = "LsItem";
            this.LsItem.Size = new System.Drawing.Size(120, 213);
            this.LsItem.TabIndex = 0;
            this.LsItem.SelectedIndexChanged += new System.EventHandler(this.LsItem_SelectedIndexChanged);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(307, 231);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 4;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // GbItem
            // 
            this.GbItem.Location = new System.Drawing.Point(145, 12);
            this.GbItem.Name = "GbItem";
            this.GbItem.Size = new System.Drawing.Size(237, 213);
            this.GbItem.TabIndex = 5;
            this.GbItem.TabStop = false;
            // 
            // UserCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 266);
            this.Controls.Add(this.GbItem);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.LsItem);
            this.Controls.Add(this.BtSaveCur);
            this.Controls.Add(this.BtSaveAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.UserOpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtSaveAll;
        private System.Windows.Forms.Button BtSaveCur;
        private System.Windows.Forms.ListBox LsItem;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.GroupBox GbItem;
    }
}
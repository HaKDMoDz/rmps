namespace Me.Amon.Target.App
{
    partial class AppWindow
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
            this.LbCmpLoc = new System.Windows.Forms.Label();
            this.TbCmpLoc = new System.Windows.Forms.TextBox();
            this.LbCmpDim = new System.Windows.Forms.Label();
            this.TbCmpDim = new System.Windows.Forms.TextBox();
            this.LbCmpClass = new System.Windows.Forms.Label();
            this.TbCmpClass = new System.Windows.Forms.TextBox();
            this.LbCmpTitle = new System.Windows.Forms.Label();
            this.TbCmpTitle = new System.Windows.Forms.TextBox();
            this.PbApp = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // LbCmpLoc
            // 
            this.LbCmpLoc.AutoSize = true;
            this.LbCmpLoc.Location = new System.Drawing.Point(48, 13);
            this.LbCmpLoc.Name = "LbCmpLoc";
            this.LbCmpLoc.Size = new System.Drawing.Size(47, 12);
            this.LbCmpLoc.TabIndex = 2;
            this.LbCmpLoc.Text = "坐标(&L)";
            // 
            // TbCmpLoc
            // 
            this.TbCmpLoc.Location = new System.Drawing.Point(101, 10);
            this.TbCmpLoc.Name = "TbCmpLoc";
            this.TbCmpLoc.ReadOnly = true;
            this.TbCmpLoc.Size = new System.Drawing.Size(129, 21);
            this.TbCmpLoc.TabIndex = 3;
            this.TbCmpLoc.TabStop = false;
            // 
            // LbCmpDim
            // 
            this.LbCmpDim.AutoSize = true;
            this.LbCmpDim.Location = new System.Drawing.Point(48, 40);
            this.LbCmpDim.Name = "LbCmpDim";
            this.LbCmpDim.Size = new System.Drawing.Size(47, 12);
            this.LbCmpDim.TabIndex = 4;
            this.LbCmpDim.Text = "大小(&S)";
            // 
            // TbCmpDim
            // 
            this.TbCmpDim.Location = new System.Drawing.Point(101, 37);
            this.TbCmpDim.Name = "TbCmpDim";
            this.TbCmpDim.ReadOnly = true;
            this.TbCmpDim.Size = new System.Drawing.Size(129, 21);
            this.TbCmpDim.TabIndex = 5;
            this.TbCmpDim.TabStop = false;
            // 
            // LbCmpClass
            // 
            this.LbCmpClass.AutoSize = true;
            this.LbCmpClass.Location = new System.Drawing.Point(10, 67);
            this.LbCmpClass.Name = "LbCmpClass";
            this.LbCmpClass.Size = new System.Drawing.Size(47, 12);
            this.LbCmpClass.TabIndex = 6;
            this.LbCmpClass.Text = "类型(&C)";
            // 
            // TbCmpClass
            // 
            this.TbCmpClass.Location = new System.Drawing.Point(63, 64);
            this.TbCmpClass.Name = "TbCmpClass";
            this.TbCmpClass.ReadOnly = true;
            this.TbCmpClass.Size = new System.Drawing.Size(167, 21);
            this.TbCmpClass.TabIndex = 7;
            this.TbCmpClass.TabStop = false;
            // 
            // LbCmpTitle
            // 
            this.LbCmpTitle.AutoSize = true;
            this.LbCmpTitle.Location = new System.Drawing.Point(10, 94);
            this.LbCmpTitle.Name = "LbCmpTitle";
            this.LbCmpTitle.Size = new System.Drawing.Size(47, 12);
            this.LbCmpTitle.TabIndex = 8;
            this.LbCmpTitle.Text = "标题(&T)";
            // 
            // TbCmpTitle
            // 
            this.TbCmpTitle.Location = new System.Drawing.Point(63, 91);
            this.TbCmpTitle.Name = "TbCmpTitle";
            this.TbCmpTitle.ReadOnly = true;
            this.TbCmpTitle.Size = new System.Drawing.Size(167, 21);
            this.TbCmpTitle.TabIndex = 9;
            this.TbCmpTitle.TabStop = false;
            // 
            // PbApp
            // 
            this.PbApp.Location = new System.Drawing.Point(10, 16);
            this.PbApp.Name = "PbApp";
            this.PbApp.Size = new System.Drawing.Size(32, 32);
            this.PbApp.TabIndex = 0;
            this.PbApp.TabStop = false;
            this.PbApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseDown);
            this.PbApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseMove);
            this.PbApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseUp);
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbCmpTitle);
            this.Controls.Add(this.LbCmpTitle);
            this.Controls.Add(this.TbCmpClass);
            this.Controls.Add(this.LbCmpClass);
            this.Controls.Add(this.TbCmpDim);
            this.Controls.Add(this.LbCmpDim);
            this.Controls.Add(this.TbCmpLoc);
            this.Controls.Add(this.LbCmpLoc);
            this.Controls.Add(this.PbApp);
            this.Name = "AppWindow";
            this.Size = new System.Drawing.Size(240, 122);
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbApp;
        private System.Windows.Forms.Label LbCmpLoc;
        private System.Windows.Forms.TextBox TbCmpLoc;
        private System.Windows.Forms.Label LbCmpDim;
        private System.Windows.Forms.TextBox TbCmpDim;
        private System.Windows.Forms.Label LbCmpClass;
        private System.Windows.Forms.TextBox TbCmpClass;
        private System.Windows.Forms.Label LbCmpTitle;
        private System.Windows.Forms.TextBox TbCmpTitle;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
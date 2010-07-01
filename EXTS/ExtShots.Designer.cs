namespace com.amonsoft.exts
{
    partial class FM_ExtShots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_ExtShots));
            this.LB_LocX = new System.Windows.Forms.Label();
            this.TB_LocX = new System.Windows.Forms.TextBox();
            this.LB_LocY = new System.Windows.Forms.Label();
            this.TB_LocY = new System.Windows.Forms.TextBox();
            this.LB_DimW = new System.Windows.Forms.Label();
            this.TB_DimW = new System.Windows.Forms.TextBox();
            this.LB_DimH = new System.Windows.Forms.Label();
            this.TB_DimH = new System.Windows.Forms.TextBox();
            this.LB_Time = new System.Windows.Forms.Label();
            this.TB_Time = new System.Windows.Forms.TextBox();
            this.CK_Scale = new System.Windows.Forms.CheckBox();
            this.CK_Ratio = new System.Windows.Forms.CheckBox();
            this.BT_Save = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LB_LocX
            // 
            this.LB_LocX.AutoSize = true;
            this.LB_LocX.Location = new System.Drawing.Point(12, 15);
            this.LB_LocX.Name = "LB_LocX";
            this.LB_LocX.Size = new System.Drawing.Size(95, 12);
            this.LB_LocX.TabIndex = 0;
            this.LB_LocX.Text = "窗口坐标（&X）：";
            // 
            // TB_LocX
            // 
            this.TB_LocX.Location = new System.Drawing.Point(113, 12);
            this.TB_LocX.Name = "TB_LocX";
            this.TB_LocX.Size = new System.Drawing.Size(50, 21);
            this.TB_LocX.TabIndex = 1;
            // 
            // LB_LocY
            // 
            this.LB_LocY.AutoSize = true;
            this.LB_LocY.Location = new System.Drawing.Point(169, 15);
            this.LB_LocY.Name = "LB_LocY";
            this.LB_LocY.Size = new System.Drawing.Size(95, 12);
            this.LB_LocY.TabIndex = 2;
            this.LB_LocY.Text = "窗口坐标（&Y）：";
            // 
            // TB_LocY
            // 
            this.TB_LocY.Location = new System.Drawing.Point(270, 12);
            this.TB_LocY.Name = "TB_LocY";
            this.TB_LocY.Size = new System.Drawing.Size(50, 21);
            this.TB_LocY.TabIndex = 3;
            // 
            // LB_DimW
            // 
            this.LB_DimW.AutoSize = true;
            this.LB_DimW.Location = new System.Drawing.Point(12, 42);
            this.LB_DimW.Name = "LB_DimW";
            this.LB_DimW.Size = new System.Drawing.Size(95, 12);
            this.LB_DimW.TabIndex = 4;
            this.LB_DimW.Text = "窗口宽度（&W）：";
            // 
            // TB_DimW
            // 
            this.TB_DimW.Location = new System.Drawing.Point(113, 39);
            this.TB_DimW.Name = "TB_DimW";
            this.TB_DimW.Size = new System.Drawing.Size(50, 21);
            this.TB_DimW.TabIndex = 5;
            // 
            // LB_DimH
            // 
            this.LB_DimH.AutoSize = true;
            this.LB_DimH.Location = new System.Drawing.Point(169, 42);
            this.LB_DimH.Name = "LB_DimH";
            this.LB_DimH.Size = new System.Drawing.Size(95, 12);
            this.LB_DimH.TabIndex = 6;
            this.LB_DimH.Text = "窗口高度（&H）：";
            // 
            // TB_DimH
            // 
            this.TB_DimH.Location = new System.Drawing.Point(270, 39);
            this.TB_DimH.Name = "TB_DimH";
            this.TB_DimH.Size = new System.Drawing.Size(50, 21);
            this.TB_DimH.TabIndex = 7;
            // 
            // LB_Time
            // 
            this.LB_Time.AutoSize = true;
            this.LB_Time.Location = new System.Drawing.Point(12, 72);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(95, 12);
            this.LB_Time.TabIndex = 8;
            this.LB_Time.Text = "截图延时（&T）：";
            // 
            // TB_Time
            // 
            this.TB_Time.Location = new System.Drawing.Point(113, 69);
            this.TB_Time.Name = "TB_Time";
            this.TB_Time.Size = new System.Drawing.Size(50, 21);
            this.TB_Time.TabIndex = 9;
            // 
            // CK_Scale
            // 
            this.CK_Scale.AutoSize = true;
            this.CK_Scale.Location = new System.Drawing.Point(12, 126);
            this.CK_Scale.Name = "CK_Scale";
            this.CK_Scale.Size = new System.Drawing.Size(126, 16);
            this.CK_Scale.TabIndex = 11;
            this.CK_Scale.Text = "调整窗口大小（&S）";
            this.CK_Scale.UseVisualStyleBackColor = true;
            this.CK_Scale.CheckedChanged += new System.EventHandler(this.CK_Scale_CheckedChanged);
            // 
            // CK_Ratio
            // 
            this.CK_Ratio.AutoSize = true;
            this.CK_Ratio.Location = new System.Drawing.Point(144, 126);
            this.CK_Ratio.Name = "CK_Ratio";
            this.CK_Ratio.Size = new System.Drawing.Size(126, 16);
            this.CK_Ratio.TabIndex = 12;
            this.CK_Ratio.Text = "保持窗口比例（&R）";
            this.CK_Ratio.UseVisualStyleBackColor = true;
            // 
            // BT_Save
            // 
            this.BT_Save.Location = new System.Drawing.Point(247, 148);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(75, 23);
            this.BT_Save.TabIndex = 13;
            this.BT_Save.Text = "确定(&O)";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "移动窗口位置（&L）";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FM_ExtShots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 184);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.CK_Ratio);
            this.Controls.Add(this.CK_Scale);
            this.Controls.Add(this.TB_Time);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.TB_DimH);
            this.Controls.Add(this.LB_DimH);
            this.Controls.Add(this.TB_LocY);
            this.Controls.Add(this.TB_DimW);
            this.Controls.Add(this.LB_LocY);
            this.Controls.Add(this.LB_DimW);
            this.Controls.Add(this.TB_LocX);
            this.Controls.Add(this.LB_LocX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FM_ExtShots";
            this.Text = "截图选项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_LocX;
        private System.Windows.Forms.TextBox TB_LocX;
        private System.Windows.Forms.Label LB_LocY;
        private System.Windows.Forms.TextBox TB_LocY;
        private System.Windows.Forms.Label LB_DimW;
        private System.Windows.Forms.TextBox TB_DimW;
        private System.Windows.Forms.Label LB_DimH;
        private System.Windows.Forms.TextBox TB_DimH;
        private System.Windows.Forms.Label LB_Time;
        private System.Windows.Forms.TextBox TB_Time;
        private System.Windows.Forms.CheckBox CK_Scale;
        private System.Windows.Forms.CheckBox CK_Ratio;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
namespace Me.Amon.Pwd._Key
{
    partial class IcoView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LvIco = new System.Windows.Forms.ListView();
            this.IlIco = new System.Windows.Forms.ImageList(this.components);
            this.BtCancel = new System.Windows.Forms.Button();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LvIco
            // 
            this.LvIco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvIco.LargeImageList = this.IlIco;
            this.LvIco.Location = new System.Drawing.Point(0, 0);
            this.LvIco.Name = "LvIco";
            this.LvIco.Size = new System.Drawing.Size(244, 220);
            this.LvIco.TabIndex = 0;
            this.LvIco.UseCompatibleStateImageBehavior = false;
            // 
            // IlIco
            // 
            this.IlIco.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlIco.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.Location = new System.Drawing.Point(169, 226);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 3;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // BtAppend
            // 
            this.BtAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAppend.Location = new System.Drawing.Point(88, 226);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 2;
            this.BtAppend.Text = "追加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtChoose
            // 
            this.BtChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtChoose.Location = new System.Drawing.Point(7, 226);
            this.BtChoose.Name = "BtChoose";
            this.BtChoose.Size = new System.Drawing.Size(75, 23);
            this.BtChoose.TabIndex = 1;
            this.BtChoose.Text = "选择(&S)";
            this.BtChoose.UseVisualStyleBackColor = true;
            this.BtChoose.Click += new System.EventHandler(this.BtChoose_Click);
            // 
            // IcoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LvIco);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtChoose);
            this.Name = "IcoView";
            this.Size = new System.Drawing.Size(244, 249);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvIco;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtChoose;
        private System.Windows.Forms.ImageList IlIco;
    }
}

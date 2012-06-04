namespace Me.Amon.Img.V.Small
{
    partial class ASmall
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
            this.BtCancel = new System.Windows.Forms.Button();
            this.IlPng = new System.Windows.Forms.ImageList(this.components);
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtSelect = new System.Windows.Forms.Button();
            this.LvPng = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // BtCancel
            // 
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(222, 234);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 7;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // IlPng
            // 
            this.IlPng.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlPng.ImageSize = new System.Drawing.Size(16, 16);
            this.IlPng.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BtAppend
            // 
            this.BtAppend.Location = new System.Drawing.Point(141, 234);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 6;
            this.BtAppend.Text = "追加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            // 
            // BtSelect
            // 
            this.BtSelect.Location = new System.Drawing.Point(60, 234);
            this.BtSelect.Name = "BtSelect";
            this.BtSelect.Size = new System.Drawing.Size(75, 23);
            this.BtSelect.TabIndex = 5;
            this.BtSelect.Text = "选择(&S)";
            this.BtSelect.UseVisualStyleBackColor = true;
            // 
            // LvPng
            // 
            this.LvPng.LargeImageList = this.IlPng;
            this.LvPng.Location = new System.Drawing.Point(3, 3);
            this.LvPng.Name = "LvPng";
            this.LvPng.Size = new System.Drawing.Size(294, 225);
            this.LvPng.TabIndex = 4;
            this.LvPng.UseCompatibleStateImageBehavior = false;
            // 
            // ASmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtSelect);
            this.Controls.Add(this.LvPng);
            this.Name = "ASmall";
            this.Size = new System.Drawing.Size(300, 260);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.ImageList IlPng;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtSelect;
        private System.Windows.Forms.ListView LvPng;
    }
}

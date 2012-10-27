using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
namespace Me.Amon.Pwd.V.Wiz
{
    partial class AWiz
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
            this.PlMain = new System.Windows.Forms.Panel();
            this.BtPrevStep = new System.Windows.Forms.Button();
            this.BtNextStep = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlMain
            // 
            this.PlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlMain.AutoScroll = true;
            this.PlMain.Location = new System.Drawing.Point(3, 3);
            this.PlMain.Name = "PlMain";
            this.PlMain.Size = new System.Drawing.Size(376, 247);
            this.PlMain.TabIndex = 0;
            // 
            // BtPrevStep
            // 
            this.BtPrevStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtPrevStep.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtPrevStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPrevStep.Location = new System.Drawing.Point(142, 256);
            this.BtPrevStep.Name = "BtPrevStep";
            this.BtPrevStep.Size = new System.Drawing.Size(75, 23);
            this.BtPrevStep.TabIndex = 1;
            this.BtPrevStep.Text = "上一步(&P)";
            this.BtPrevStep.UseVisualStyleBackColor = true;
            // 
            // BtNextStep
            // 
            this.BtNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNextStep.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNextStep.Location = new System.Drawing.Point(223, 256);
            this.BtNextStep.Name = "BtNextStep";
            this.BtNextStep.Size = new System.Drawing.Size(75, 23);
            this.BtNextStep.TabIndex = 2;
            this.BtNextStep.Text = "下一步(&N)";
            this.BtNextStep.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCancel.Location = new System.Drawing.Point(304, 256);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 3;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtNextStep);
            this.Controls.Add(this.BtPrevStep);
            this.Controls.Add(this.PlMain);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(382, 282);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlMain;
        private System.Windows.Forms.Button BtPrevStep;
        private System.Windows.Forms.Button BtNextStep;
        private System.Windows.Forms.Button BtCancel;
    }
}

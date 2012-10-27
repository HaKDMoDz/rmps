namespace Me.Amon.Pwd.V
{
    partial class KeyInfo
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
            this.LbName = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbName.Location = new System.Drawing.Point(0, 0);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(350, 23);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "提示";
            this.LbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbData
            // 
            this.TbData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbData.Location = new System.Drawing.Point(0, 23);
            this.TbData.Multiline = true;
            this.TbData.Name = "TbData";
            this.TbData.ReadOnly = true;
            this.TbData.Size = new System.Drawing.Size(350, 177);
            this.TbData.TabIndex = 1;
            this.TbData.TabStop = false;
            this.TbData.Text = "欢迎使用《阿木密码箱》！";
            // 
            // BeanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbName);
            this.Name = "BeanInfo";
            this.Size = new System.Drawing.Size(350, 200);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BeanInfo_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbData;
    }
}

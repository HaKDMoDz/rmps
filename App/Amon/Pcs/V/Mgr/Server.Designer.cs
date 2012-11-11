namespace Me.Amon.Pcs.V.Mgr
{
    partial class Server
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
            this.LlNote = new System.Windows.Forms.Label();
            this.LlServer = new System.Windows.Forms.Label();
            this.CbServer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LlNote
            // 
            this.LlNote.AutoSize = true;
            this.LlNote.Location = new System.Drawing.Point(3, 0);
            this.LlNote.Name = "LlNote";
            this.LlNote.Size = new System.Drawing.Size(149, 12);
            this.LlNote.TabIndex = 0;
            this.LlNote.Text = "选择您要使用的服务类型：";
            // 
            // LlServer
            // 
            this.LlServer.AutoSize = true;
            this.LlServer.Location = new System.Drawing.Point(17, 34);
            this.LlServer.Name = "LlServer";
            this.LlServer.Size = new System.Drawing.Size(83, 12);
            this.LlServer.TabIndex = 1;
            this.LlServer.Text = "服务提供商(&S)";
            // 
            // CbServer
            // 
            this.CbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbServer.FormattingEnabled = true;
            this.CbServer.Location = new System.Drawing.Point(106, 31);
            this.CbServer.Name = "CbServer";
            this.CbServer.Size = new System.Drawing.Size(121, 20);
            this.CbServer.TabIndex = 2;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbServer);
            this.Controls.Add(this.LlServer);
            this.Controls.Add(this.LlNote);
            this.Name = "Server";
            this.Size = new System.Drawing.Size(282, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlNote;
        private System.Windows.Forms.Label LlServer;
        private System.Windows.Forms.ComboBox CbServer;
    }
}

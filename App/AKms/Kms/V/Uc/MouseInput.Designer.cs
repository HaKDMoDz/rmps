namespace Me.Amon.Kms.V.Uc
{
    partial class MouseInput
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
            this.LbMouse = new System.Windows.Forms.Label();
            this.TbMouse = new System.Windows.Forms.TextBox();
            this.PbMouse = new System.Windows.Forms.PictureBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiLocRef = new System.Windows.Forms.ToolStripMenuItem();
            this.SpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MiLButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAction = new System.Windows.Forms.ToolStripMenuItem();
            this.MiClick = new System.Windows.Forms.ToolStripMenuItem();
            this.SpSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMove = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUp = new System.Windows.Forms.ToolStripMenuItem();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbMouse)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbMouse
            // 
            this.LbMouse.AutoSize = true;
            this.LbMouse.Location = new System.Drawing.Point(3, 7);
            this.LbMouse.Name = "LbMouse";
            this.LbMouse.Size = new System.Drawing.Size(47, 12);
            this.LbMouse.TabIndex = 0;
            this.LbMouse.Text = "动作(&M)";
            // 
            // TbMouse
            // 
            this.TbMouse.Location = new System.Drawing.Point(56, 3);
            this.TbMouse.Name = "TbMouse";
            this.TbMouse.Size = new System.Drawing.Size(181, 21);
            this.TbMouse.TabIndex = 1;
            this.TpTips.SetToolTip(this.TbMouse, "格式：[x,y](Button,Event)");
            // 
            // PbMouse
            // 
            this.PbMouse.Image = global::Me.Amon.Properties.Resources.Find;
            this.PbMouse.Location = new System.Drawing.Point(243, 5);
            this.PbMouse.Margin = new System.Windows.Forms.Padding(0);
            this.PbMouse.Name = "PbMouse";
            this.PbMouse.Size = new System.Drawing.Size(16, 16);
            this.PbMouse.TabIndex = 2;
            this.PbMouse.TabStop = false;
            this.TpTips.SetToolTip(this.PbMouse, "拖动以查找位置");
            this.PbMouse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbMouse_MouseMove);
            this.PbMouse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbMouse_MouseDown);
            this.PbMouse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbMouse_MouseUp);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiLocRef,
            this.SpSep1,
            this.MiButton,
            this.MiAction});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(139, 76);
            // 
            // MiLocRef
            // 
            this.MiLocRef.Checked = true;
            this.MiLocRef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiLocRef.Name = "MiLocRef";
            this.MiLocRef.Size = new System.Drawing.Size(138, 22);
            this.MiLocRef.Text = "相对位置(&L)";
            this.MiLocRef.Click += new System.EventHandler(this.MiLocRef_Click);
            // 
            // SpSep1
            // 
            this.SpSep1.Name = "SpSep1";
            this.SpSep1.Size = new System.Drawing.Size(135, 6);
            // 
            // MiButton
            // 
            this.MiButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiLButton,
            this.MiMButton,
            this.MiRButton});
            this.MiButton.Name = "MiButton";
            this.MiButton.Size = new System.Drawing.Size(138, 22);
            this.MiButton.Text = "按键";
            // 
            // MiLButton
            // 
            this.MiLButton.Checked = true;
            this.MiLButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiLButton.Name = "MiLButton";
            this.MiLButton.Size = new System.Drawing.Size(100, 22);
            this.MiLButton.Text = "左键";
            this.MiLButton.Click += new System.EventHandler(this.MiLButton_Click);
            // 
            // MiMButton
            // 
            this.MiMButton.Name = "MiMButton";
            this.MiMButton.Size = new System.Drawing.Size(100, 22);
            this.MiMButton.Text = "中键";
            this.MiMButton.Click += new System.EventHandler(this.MiMButton_Click);
            // 
            // MiRButton
            // 
            this.MiRButton.Name = "MiRButton";
            this.MiRButton.Size = new System.Drawing.Size(100, 22);
            this.MiRButton.Text = "右键";
            this.MiRButton.Click += new System.EventHandler(this.MiRButton_Click);
            // 
            // MiAction
            // 
            this.MiAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiClick,
            this.SpSep2,
            this.MiDown,
            this.MiMove,
            this.MiUp});
            this.MiAction.Name = "MiAction";
            this.MiAction.Size = new System.Drawing.Size(138, 22);
            this.MiAction.Text = "事件";
            // 
            // MiClick
            // 
            this.MiClick.Checked = true;
            this.MiClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiClick.Name = "MiClick";
            this.MiClick.Size = new System.Drawing.Size(100, 22);
            this.MiClick.Text = "点击";
            this.MiClick.Click += new System.EventHandler(this.MiClick_Click);
            // 
            // SpSep2
            // 
            this.SpSep2.Name = "SpSep2";
            this.SpSep2.Size = new System.Drawing.Size(97, 6);
            // 
            // MiDown
            // 
            this.MiDown.Name = "MiDown";
            this.MiDown.Size = new System.Drawing.Size(100, 22);
            this.MiDown.Text = "压下";
            this.MiDown.Click += new System.EventHandler(this.MiDown_Click);
            // 
            // MiMove
            // 
            this.MiMove.Name = "MiMove";
            this.MiMove.Size = new System.Drawing.Size(100, 22);
            this.MiMove.Text = "移动";
            this.MiMove.Click += new System.EventHandler(this.MiMove_Click);
            // 
            // MiUp
            // 
            this.MiUp.Name = "MiUp";
            this.MiUp.Size = new System.Drawing.Size(100, 22);
            this.MiUp.Text = "松开";
            this.MiUp.Click += new System.EventHandler(this.MiUp_Click);
            // 
            // MouseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbMouse);
            this.Controls.Add(this.TbMouse);
            this.Controls.Add(this.LbMouse);
            this.Name = "MouseInput";
            this.Size = new System.Drawing.Size(262, 27);
            ((System.ComponentModel.ISupportInitialize)(this.PbMouse)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbMouse;
        private System.Windows.Forms.TextBox TbMouse;
        private System.Windows.Forms.PictureBox PbMouse;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiButton;
        private System.Windows.Forms.ToolStripMenuItem MiLButton;
        private System.Windows.Forms.ToolStripMenuItem MiMButton;
        private System.Windows.Forms.ToolStripMenuItem MiRButton;
        private System.Windows.Forms.ToolStripMenuItem MiAction;
        private System.Windows.Forms.ToolStripMenuItem MiDown;
        private System.Windows.Forms.ToolStripMenuItem MiMove;
        private System.Windows.Forms.ToolStripMenuItem MiUp;
        private System.Windows.Forms.ToolStripMenuItem MiClick;
        private System.Windows.Forms.ToolStripSeparator SpSep2;
        private System.Windows.Forms.ToolStripMenuItem MiLocRef;
        private System.Windows.Forms.ToolStripSeparator SpSep1;
        private System.Windows.Forms.ToolTip TpTips;
    }
}

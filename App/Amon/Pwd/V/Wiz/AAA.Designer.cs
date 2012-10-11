using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
namespace Me.Amon.Pwd.V.Wiz
{
    partial class AAA
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.catTree1 = new Me.Amon.Pwd._Cat.CatTree();
            this.keyList1 = new Me.Amon.Pwd._Key.KeyList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.catTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(402, 268);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.keyList1);
            this.splitContainer2.Size = new System.Drawing.Size(264, 268);
            this.splitContainer2.SplitterDistance = 88;
            this.splitContainer2.TabIndex = 0;
            // 
            // catTree1
            // 
            this.catTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catTree1.KeyList = null;
            this.catTree1.Location = new System.Drawing.Point(0, 0);
            this.catTree1.Name = "catTree1";
            this.catTree1.PopMenu = null;
            this.catTree1.Size = new System.Drawing.Size(134, 268);
            this.catTree1.TabIndex = 0;
            // 
            // keyList1
            // 
            this.keyList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyList1.Location = new System.Drawing.Point(0, 0);
            this.keyList1.Name = "keyList1";
            this.keyList1.PopupMenu = null;
            this.keyList1.Size = new System.Drawing.Size(264, 88);
            this.keyList1.TabIndex = 0;
            // 
            // AAA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AAA";
            this.Size = new System.Drawing.Size(402, 268);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CatTree catTree1;
        private KeyList keyList1;
    }
}

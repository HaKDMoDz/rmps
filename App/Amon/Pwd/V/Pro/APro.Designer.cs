using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
namespace Me.Amon.Pwd.V.Pro
{
    partial class APro
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
            this.HSplit = new System.Windows.Forms.SplitContainer();
            this.VSplit = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GbGroup = new System.Windows.Forms.GroupBox();
            this.BtOpt2 = new System.Windows.Forms.Button();
            this.BtOpt1 = new System.Windows.Forms.Button();
            this.GvAttList = new System.Windows.Forms.DataGridView();
            this.findBar1 = new Me.Amon.Pwd.Bean.FindBar();
            this.OrderCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).BeginInit();
            this.HSplit.Panel1.SuspendLayout();
            this.HSplit.Panel2.SuspendLayout();
            this.HSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).BeginInit();
            this.VSplit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).BeginInit();
            this.SuspendLayout();
            // 
            // HSplit
            // 
            this.HSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HSplit.Location = new System.Drawing.Point(0, 0);
            this.HSplit.Name = "HSplit";
            // 
            // HSplit.Panel1
            // 
            this.HSplit.Panel1.Controls.Add(this.VSplit);
            // 
            // HSplit.Panel2
            // 
            this.HSplit.Panel2.Controls.Add(this.panel1);
            this.HSplit.Panel2.Controls.Add(this.findBar1);
            this.HSplit.Size = new System.Drawing.Size(458, 303);
            this.HSplit.SplitterDistance = 152;
            this.HSplit.TabIndex = 0;
            // 
            // VSplit
            // 
            this.VSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSplit.Location = new System.Drawing.Point(0, 0);
            this.VSplit.Name = "VSplit";
            this.VSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.VSplit.Size = new System.Drawing.Size(152, 303);
            this.VSplit.SplitterDistance = 151;
            this.VSplit.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GbGroup);
            this.panel1.Controls.Add(this.GvAttList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 274);
            this.panel1.TabIndex = 1;
            // 
            // GbGroup
            // 
            this.GbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GbGroup.Controls.Add(this.BtOpt2);
            this.GbGroup.Controls.Add(this.BtOpt1);
            this.GbGroup.Location = new System.Drawing.Point(3, 161);
            this.GbGroup.Name = "GbGroup";
            this.GbGroup.Size = new System.Drawing.Size(296, 110);
            this.GbGroup.TabIndex = 1;
            this.GbGroup.TabStop = false;
            this.GbGroup.Text = "属性";
            // 
            // BtOpt2
            // 
            this.BtOpt2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtOpt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt2.Location = new System.Drawing.Point(274, 88);
            this.BtOpt2.Name = "BtOpt2";
            this.BtOpt2.Size = new System.Drawing.Size(16, 16);
            this.BtOpt2.TabIndex = 1;
            this.BtOpt2.UseVisualStyleBackColor = true;
            this.BtOpt2.Click += new System.EventHandler(this.BtOpt2_Click);
            // 
            // BtOpt1
            // 
            this.BtOpt1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtOpt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt1.Location = new System.Drawing.Point(274, 66);
            this.BtOpt1.Name = "BtOpt1";
            this.BtOpt1.Size = new System.Drawing.Size(16, 16);
            this.BtOpt1.TabIndex = 0;
            this.BtOpt1.UseVisualStyleBackColor = true;
            this.BtOpt1.Click += new System.EventHandler(this.BtOpt1_Click);
            // 
            // GvAttList
            // 
            this.GvAttList.AllowUserToAddRows = false;
            this.GvAttList.AllowUserToDeleteRows = false;
            this.GvAttList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvAttList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvAttList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvAttList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderCol,
            this.ValueCol});
            this.GvAttList.Location = new System.Drawing.Point(3, 3);
            this.GvAttList.MultiSelect = false;
            this.GvAttList.Name = "GvAttList";
            this.GvAttList.ReadOnly = true;
            this.GvAttList.RowHeadersVisible = false;
            this.GvAttList.RowTemplate.Height = 23;
            this.GvAttList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvAttList.Size = new System.Drawing.Size(296, 152);
            this.GvAttList.TabIndex = 0;
            // 
            // findBar1
            // 
            this.findBar1.APwd = null;
            this.findBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.findBar1.Location = new System.Drawing.Point(0, 0);
            this.findBar1.Name = "findBar1";
            this.findBar1.Size = new System.Drawing.Size(302, 29);
            this.findBar1.TabIndex = 0;
            // 
            // OrderCol
            // 
            this.OrderCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OrderCol.HeaderText = "排序";
            this.OrderCol.Name = "OrderCol";
            this.OrderCol.ReadOnly = true;
            this.OrderCol.Width = 54;
            // 
            // ValueCol
            // 
            this.ValueCol.HeaderText = "属性";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.ReadOnly = true;
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HSplit);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(458, 303);
            this.HSplit.Panel1.ResumeLayout(false);
            this.HSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).EndInit();
            this.HSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).EndInit();
            this.VSplit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GbGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer HSplit;
        private System.Windows.Forms.SplitContainer VSplit;
        private System.Windows.Forms.Panel panel1;
        private Bean.FindBar findBar1;
        private System.Windows.Forms.DataGridView GvAttList;
        private System.Windows.Forms.GroupBox GbGroup;
        private System.Windows.Forms.Button BtOpt2;
        private System.Windows.Forms.Button BtOpt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;

    }
}

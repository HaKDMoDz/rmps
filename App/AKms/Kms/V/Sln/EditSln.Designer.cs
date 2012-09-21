using Me.Amon._uc;

namespace Me.Amon.Kms.V.Sln
{
    partial class EditSln
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSln));
            this.LsSolution = new System.Windows.Forms.ListBox();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.TtTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbAdd1 = new System.Windows.Forms.PictureBox();
            this.PbTop1 = new System.Windows.Forms.PictureBox();
            this.PbNew1 = new System.Windows.Forms.PictureBox();
            this.PbDel1 = new System.Windows.Forms.PictureBox();
            this.PbBot1 = new System.Windows.Forms.PictureBox();
            this.PbAdd3 = new System.Windows.Forms.PictureBox();
            this.PbTop3 = new System.Windows.Forms.PictureBox();
            this.PbNew3 = new System.Windows.Forms.PictureBox();
            this.PbDel3 = new System.Windows.Forms.PictureBox();
            this.PbBot3 = new System.Windows.Forms.PictureBox();
            this.TcSln = new System.Windows.Forms.TabControl();
            this.TpSln = new System.Windows.Forms.TabPage();
            this.LsCategory = new System.Windows.Forms.ListBox();
            this.LbCategory = new System.Windows.Forms.Label();
            this.CbLanguage = new System.Windows.Forms.ComboBox();
            this.LbLanguage = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.TpPre = new System.Windows.Forms.TabPage();
            this.PlPre = new System.Windows.Forms.Panel();
            this.LsPre = new System.Windows.Forms.ListBox();
            this.TpFun = new System.Windows.Forms.TabPage();
            this.PaPost = new Me.Amon._uc.PostAction();
            this.LbPost = new System.Windows.Forms.Label();
            this.LbInit = new System.Windows.Forms.Label();
            this.CbOutput = new System.Windows.Forms.ComboBox();
            this.LbOutput = new System.Windows.Forms.Label();
            this.CbMethod = new System.Windows.Forms.ComboBox();
            this.SpIntval = new System.Windows.Forms.NumericUpDown();
            this.LbIntval = new System.Windows.Forms.Label();
            this.CbTarget = new System.Windows.Forms.ComboBox();
            this.LbMethod = new System.Windows.Forms.Label();
            this.LbTarget = new System.Windows.Forms.Label();
            this.PaInit = new Me.Amon._uc.PostAction();
            this.TpSuf = new System.Windows.Forms.TabPage();
            this.PlSuf = new System.Windows.Forms.Panel();
            this.LsSuf = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HkStop = new Me.Amon.Kms.V.Sln.HotKeys();
            this.LbStop = new System.Windows.Forms.Label();
            this.HkNext = new Me.Amon.Kms.V.Sln.HotKeys();
            this.LbNext = new System.Windows.Forms.Label();
            this.HkHalt = new Me.Amon.Kms.V.Sln.HotKeys();
            this.LbHalt = new System.Windows.Forms.Label();
            this.HkWork = new Me.Amon.Kms.V.Sln.HotKeys();
            this.LbWork = new System.Windows.Forms.Label();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiThreadWait = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.MiExecuteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHideWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MiGetControl = new System.Windows.Forms.ToolStripMenuItem();
            this.MiKeybdInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMouseInput = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbAdd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbNew1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAdd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbNew3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBot3)).BeginInit();
            this.TcSln.SuspendLayout();
            this.TpSln.SuspendLayout();
            this.TpPre.SuspendLayout();
            this.TpFun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpIntval)).BeginInit();
            this.TpSuf.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LsSolution
            // 
            this.LsSolution.FormattingEnabled = true;
            this.LsSolution.ItemHeight = 12;
            this.LsSolution.Location = new System.Drawing.Point(12, 12);
            this.LsSolution.Name = "LsSolution";
            this.LsSolution.Size = new System.Drawing.Size(120, 220);
            this.LsSolution.TabIndex = 0;
            this.LsSolution.SelectedIndexChanged += new System.EventHandler(this.LsSlns_SelectedIndexChanged);
            // 
            // BtAppend
            // 
            this.BtAppend.Location = new System.Drawing.Point(205, 237);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 2;
            this.BtAppend.Text = "新增(&N)";
            this.TtTips.SetToolTip(this.BtAppend, "新增会话方案");
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.Location = new System.Drawing.Point(286, 237);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 3;
            this.BtUpdate.Text = "保存(&S)";
            this.TtTips.SetToolTip(this.BtUpdate, "保存会话方案的变更");
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(367, 237);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 4;
            this.BtCancel.Text = "取消(&C)";
            this.TtTips.SetToolTip(this.BtCancel, "取消");
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // PbAdd1
            // 
            this.PbAdd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbAdd1.Image = global::Me.Amon.Properties.Resources._add;
            this.PbAdd1.Location = new System.Drawing.Point(274, 171);
            this.PbAdd1.Name = "PbAdd1";
            this.PbAdd1.Size = new System.Drawing.Size(16, 16);
            this.PbAdd1.TabIndex = 6;
            this.PbAdd1.TabStop = false;
            this.TtTips.SetToolTip(this.PbAdd1, "保存当前操作");
            this.PbAdd1.Click += new System.EventHandler(this.PbAdd1_Click);
            // 
            // PbTop1
            // 
            this.PbTop1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbTop1.Image = global::Me.Amon.Properties.Resources.au;
            this.PbTop1.Location = new System.Drawing.Point(274, 83);
            this.PbTop1.Name = "PbTop1";
            this.PbTop1.Size = new System.Drawing.Size(16, 16);
            this.PbTop1.TabIndex = 5;
            this.PbTop1.TabStop = false;
            this.TtTips.SetToolTip(this.PbTop1, "上移一行");
            this.PbTop1.Click += new System.EventHandler(this.PbTop1_Click);
            // 
            // PbNew1
            // 
            this.PbNew1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbNew1.Image = global::Me.Amon.Properties.Resources._new;
            this.PbNew1.Location = new System.Drawing.Point(274, 149);
            this.PbNew1.Name = "PbNew1";
            this.PbNew1.Size = new System.Drawing.Size(16, 16);
            this.PbNew1.TabIndex = 4;
            this.PbNew1.TabStop = false;
            this.TtTips.SetToolTip(this.PbNew1, "新增操作");
            this.PbNew1.Click += new System.EventHandler(this.PbNew1_Click);
            // 
            // PbDel1
            // 
            this.PbDel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDel1.Image = global::Me.Amon.Properties.Resources._sub;
            this.PbDel1.Location = new System.Drawing.Point(274, 127);
            this.PbDel1.Name = "PbDel1";
            this.PbDel1.Size = new System.Drawing.Size(16, 16);
            this.PbDel1.TabIndex = 3;
            this.PbDel1.TabStop = false;
            this.TtTips.SetToolTip(this.PbDel1, "删除当前操作");
            this.PbDel1.Click += new System.EventHandler(this.PbDel1_Click);
            // 
            // PbBot1
            // 
            this.PbBot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbBot1.Image = global::Me.Amon.Properties.Resources.ad;
            this.PbBot1.Location = new System.Drawing.Point(274, 105);
            this.PbBot1.Name = "PbBot1";
            this.PbBot1.Size = new System.Drawing.Size(16, 16);
            this.PbBot1.TabIndex = 2;
            this.PbBot1.TabStop = false;
            this.TtTips.SetToolTip(this.PbBot1, "下移一行");
            this.PbBot1.Click += new System.EventHandler(this.PbBot1_Click);
            // 
            // PbAdd3
            // 
            this.PbAdd3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbAdd3.Image = global::Me.Amon.Properties.Resources._add;
            this.PbAdd3.Location = new System.Drawing.Point(274, 171);
            this.PbAdd3.Name = "PbAdd3";
            this.PbAdd3.Size = new System.Drawing.Size(16, 16);
            this.PbAdd3.TabIndex = 9;
            this.PbAdd3.TabStop = false;
            this.TtTips.SetToolTip(this.PbAdd3, "保存当前操作");
            this.PbAdd3.Click += new System.EventHandler(this.PbAdd3_Click);
            // 
            // PbTop3
            // 
            this.PbTop3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbTop3.Image = global::Me.Amon.Properties.Resources.au;
            this.PbTop3.Location = new System.Drawing.Point(274, 83);
            this.PbTop3.Name = "PbTop3";
            this.PbTop3.Size = new System.Drawing.Size(16, 16);
            this.PbTop3.TabIndex = 8;
            this.PbTop3.TabStop = false;
            this.TtTips.SetToolTip(this.PbTop3, "上移一行");
            this.PbTop3.Click += new System.EventHandler(this.PbTop3_Click);
            // 
            // PbNew3
            // 
            this.PbNew3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbNew3.Image = global::Me.Amon.Properties.Resources._new;
            this.PbNew3.Location = new System.Drawing.Point(274, 149);
            this.PbNew3.Name = "PbNew3";
            this.PbNew3.Size = new System.Drawing.Size(16, 16);
            this.PbNew3.TabIndex = 7;
            this.PbNew3.TabStop = false;
            this.TtTips.SetToolTip(this.PbNew3, "新增操作");
            this.PbNew3.Click += new System.EventHandler(this.PbNew3_Click);
            // 
            // PbDel3
            // 
            this.PbDel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDel3.Image = global::Me.Amon.Properties.Resources._sub;
            this.PbDel3.Location = new System.Drawing.Point(274, 127);
            this.PbDel3.Name = "PbDel3";
            this.PbDel3.Size = new System.Drawing.Size(16, 16);
            this.PbDel3.TabIndex = 6;
            this.PbDel3.TabStop = false;
            this.TtTips.SetToolTip(this.PbDel3, "删除当行操作");
            this.PbDel3.Click += new System.EventHandler(this.PbDel3_Click);
            // 
            // PbBot3
            // 
            this.PbBot3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbBot3.Image = global::Me.Amon.Properties.Resources.ad;
            this.PbBot3.Location = new System.Drawing.Point(274, 105);
            this.PbBot3.Name = "PbBot3";
            this.PbBot3.Size = new System.Drawing.Size(16, 16);
            this.PbBot3.TabIndex = 5;
            this.PbBot3.TabStop = false;
            this.TtTips.SetToolTip(this.PbBot3, "下移一行");
            this.PbBot3.Click += new System.EventHandler(this.PbBot3_Click);
            // 
            // TcSln
            // 
            this.TcSln.Controls.Add(this.TpSln);
            this.TcSln.Controls.Add(this.TpPre);
            this.TcSln.Controls.Add(this.TpFun);
            this.TcSln.Controls.Add(this.TpSuf);
            this.TcSln.Controls.Add(this.tabPage1);
            this.TcSln.Location = new System.Drawing.Point(138, 12);
            this.TcSln.Name = "TcSln";
            this.TcSln.SelectedIndex = 0;
            this.TcSln.Size = new System.Drawing.Size(304, 219);
            this.TcSln.TabIndex = 1;
            // 
            // TpSln
            // 
            this.TpSln.Controls.Add(this.LsCategory);
            this.TpSln.Controls.Add(this.LbCategory);
            this.TpSln.Controls.Add(this.CbLanguage);
            this.TpSln.Controls.Add(this.LbLanguage);
            this.TpSln.Controls.Add(this.TbName);
            this.TpSln.Controls.Add(this.LbName);
            this.TpSln.Location = new System.Drawing.Point(4, 22);
            this.TpSln.Name = "TpSln";
            this.TpSln.Padding = new System.Windows.Forms.Padding(3);
            this.TpSln.Size = new System.Drawing.Size(296, 193);
            this.TpSln.TabIndex = 3;
            this.TpSln.Text = "会话方案";
            this.TpSln.UseVisualStyleBackColor = true;
            // 
            // LsCategory
            // 
            this.LsCategory.FormattingEnabled = true;
            this.LsCategory.ItemHeight = 12;
            this.LsCategory.Location = new System.Drawing.Point(83, 60);
            this.LsCategory.Name = "LsCategory";
            this.LsCategory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LsCategory.Size = new System.Drawing.Size(207, 124);
            this.LsCategory.TabIndex = 7;
            // 
            // LbCategory
            // 
            this.LbCategory.AutoSize = true;
            this.LbCategory.Location = new System.Drawing.Point(6, 63);
            this.LbCategory.Name = "LbCategory";
            this.LbCategory.Size = new System.Drawing.Size(71, 12);
            this.LbCategory.TabIndex = 6;
            this.LbCategory.Text = "语言资源(&R)";
            // 
            // CbLanguage
            // 
            this.CbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLanguage.FormattingEnabled = true;
            this.CbLanguage.Location = new System.Drawing.Point(83, 33);
            this.CbLanguage.Name = "CbLanguage";
            this.CbLanguage.Size = new System.Drawing.Size(108, 20);
            this.CbLanguage.TabIndex = 3;
            // 
            // LbLanguage
            // 
            this.LbLanguage.AutoSize = true;
            this.LbLanguage.Location = new System.Drawing.Point(6, 36);
            this.LbLanguage.Name = "LbLanguage";
            this.LbLanguage.Size = new System.Drawing.Size(71, 12);
            this.LbLanguage.TabIndex = 2;
            this.LbLanguage.Text = "输出语言(&L)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(83, 6);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(207, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(6, 9);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "方案名称(&N)";
            // 
            // TpPre
            // 
            this.TpPre.Controls.Add(this.PlPre);
            this.TpPre.Controls.Add(this.PbAdd1);
            this.TpPre.Controls.Add(this.PbTop1);
            this.TpPre.Controls.Add(this.PbNew1);
            this.TpPre.Controls.Add(this.PbDel1);
            this.TpPre.Controls.Add(this.PbBot1);
            this.TpPre.Controls.Add(this.LsPre);
            this.TpPre.Location = new System.Drawing.Point(4, 22);
            this.TpPre.Name = "TpPre";
            this.TpPre.Padding = new System.Windows.Forms.Padding(3);
            this.TpPre.Size = new System.Drawing.Size(296, 193);
            this.TpPre.TabIndex = 0;
            this.TpPre.Text = "前置操作";
            this.TpPre.UseVisualStyleBackColor = true;
            // 
            // PlPre
            // 
            this.PlPre.Location = new System.Drawing.Point(6, 160);
            this.PlPre.Name = "PlPre";
            this.PlPre.Size = new System.Drawing.Size(262, 27);
            this.PlPre.TabIndex = 1;
            // 
            // LsPre
            // 
            this.LsPre.FormattingEnabled = true;
            this.LsPre.ItemHeight = 12;
            this.LsPre.Location = new System.Drawing.Point(6, 6);
            this.LsPre.Name = "LsPre";
            this.LsPre.Size = new System.Drawing.Size(262, 148);
            this.LsPre.TabIndex = 0;
            this.LsPre.SelectedIndexChanged += new System.EventHandler(this.LsPre_SelectedIndexChanged);
            // 
            // TpFun
            // 
            this.TpFun.Controls.Add(this.PaPost);
            this.TpFun.Controls.Add(this.LbPost);
            this.TpFun.Controls.Add(this.LbInit);
            this.TpFun.Controls.Add(this.CbOutput);
            this.TpFun.Controls.Add(this.LbOutput);
            this.TpFun.Controls.Add(this.CbMethod);
            this.TpFun.Controls.Add(this.SpIntval);
            this.TpFun.Controls.Add(this.LbIntval);
            this.TpFun.Controls.Add(this.CbTarget);
            this.TpFun.Controls.Add(this.LbMethod);
            this.TpFun.Controls.Add(this.LbTarget);
            this.TpFun.Controls.Add(this.PaInit);
            this.TpFun.Location = new System.Drawing.Point(4, 22);
            this.TpFun.Name = "TpFun";
            this.TpFun.Padding = new System.Windows.Forms.Padding(3);
            this.TpFun.Size = new System.Drawing.Size(296, 193);
            this.TpFun.TabIndex = 1;
            this.TpFun.Text = "响应方式";
            this.TpFun.UseVisualStyleBackColor = true;
            // 
            // PaPost
            // 
            this.PaPost.Location = new System.Drawing.Point(83, 138);
            this.PaPost.Name = "PaPost";
            this.PaPost.Size = new System.Drawing.Size(207, 21);
            this.PaPost.TabIndex = 11;
            this.PaPost.UserAction = "";
            // 
            // LbPost
            // 
            this.LbPost.AutoSize = true;
            this.LbPost.Location = new System.Drawing.Point(6, 142);
            this.LbPost.Name = "LbPost";
            this.LbPost.Size = new System.Drawing.Size(71, 12);
            this.LbPost.TabIndex = 10;
            this.LbPost.Text = "输入确认(&S)";
            // 
            // LbInit
            // 
            this.LbInit.AutoSize = true;
            this.LbInit.Location = new System.Drawing.Point(6, 115);
            this.LbInit.Name = "LbInit";
            this.LbInit.Size = new System.Drawing.Size(71, 12);
            this.LbInit.TabIndex = 8;
            this.LbInit.Text = "准备输入(&P)";
            // 
            // CbOutput
            // 
            this.CbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOutput.FormattingEnabled = true;
            this.CbOutput.Location = new System.Drawing.Point(83, 58);
            this.CbOutput.Name = "CbOutput";
            this.CbOutput.Size = new System.Drawing.Size(121, 20);
            this.CbOutput.TabIndex = 5;
            // 
            // LbOutput
            // 
            this.LbOutput.AutoSize = true;
            this.LbOutput.Location = new System.Drawing.Point(6, 63);
            this.LbOutput.Name = "LbOutput";
            this.LbOutput.Size = new System.Drawing.Size(71, 12);
            this.LbOutput.TabIndex = 4;
            this.LbOutput.Text = "输入方式(&O)";
            // 
            // CbMethod
            // 
            this.CbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMethod.FormattingEnabled = true;
            this.CbMethod.Location = new System.Drawing.Point(83, 6);
            this.CbMethod.Name = "CbMethod";
            this.CbMethod.Size = new System.Drawing.Size(121, 20);
            this.CbMethod.TabIndex = 1;
            // 
            // SpIntval
            // 
            this.SpIntval.Location = new System.Drawing.Point(83, 84);
            this.SpIntval.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpIntval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpIntval.Name = "SpIntval";
            this.SpIntval.Size = new System.Drawing.Size(61, 21);
            this.SpIntval.TabIndex = 7;
            this.SpIntval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LbIntval
            // 
            this.LbIntval.AutoSize = true;
            this.LbIntval.Location = new System.Drawing.Point(6, 89);
            this.LbIntval.Name = "LbIntval";
            this.LbIntval.Size = new System.Drawing.Size(71, 12);
            this.LbIntval.TabIndex = 6;
            this.LbIntval.Text = "响应间隔(&I)";
            // 
            // CbTarget
            // 
            this.CbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTarget.FormattingEnabled = true;
            this.CbTarget.Location = new System.Drawing.Point(83, 32);
            this.CbTarget.Name = "CbTarget";
            this.CbTarget.Size = new System.Drawing.Size(121, 20);
            this.CbTarget.TabIndex = 3;
            this.CbTarget.SelectedIndexChanged += new System.EventHandler(this.CbTarget_SelectedIndexChanged);
            // 
            // LbMethod
            // 
            this.LbMethod.AutoSize = true;
            this.LbMethod.Location = new System.Drawing.Point(6, 10);
            this.LbMethod.Name = "LbMethod";
            this.LbMethod.Size = new System.Drawing.Size(71, 12);
            this.LbMethod.TabIndex = 0;
            this.LbMethod.Text = "交互方式(&M)";
            // 
            // LbTarget
            // 
            this.LbTarget.AutoSize = true;
            this.LbTarget.Location = new System.Drawing.Point(6, 36);
            this.LbTarget.Name = "LbTarget";
            this.LbTarget.Size = new System.Drawing.Size(71, 12);
            this.LbTarget.TabIndex = 2;
            this.LbTarget.Text = "交互目标(&T)";
            // 
            // PaInit
            // 
            this.PaInit.Location = new System.Drawing.Point(83, 111);
            this.PaInit.Name = "PaInit";
            this.PaInit.Size = new System.Drawing.Size(207, 21);
            this.PaInit.TabIndex = 9;
            this.PaInit.UserAction = "";
            // 
            // TpSuf
            // 
            this.TpSuf.Controls.Add(this.PlSuf);
            this.TpSuf.Controls.Add(this.PbAdd3);
            this.TpSuf.Controls.Add(this.PbTop3);
            this.TpSuf.Controls.Add(this.PbNew3);
            this.TpSuf.Controls.Add(this.PbDel3);
            this.TpSuf.Controls.Add(this.PbBot3);
            this.TpSuf.Controls.Add(this.LsSuf);
            this.TpSuf.Location = new System.Drawing.Point(4, 22);
            this.TpSuf.Name = "TpSuf";
            this.TpSuf.Padding = new System.Windows.Forms.Padding(3);
            this.TpSuf.Size = new System.Drawing.Size(296, 193);
            this.TpSuf.TabIndex = 2;
            this.TpSuf.Text = "后置操作";
            this.TpSuf.UseVisualStyleBackColor = true;
            // 
            // PlSuf
            // 
            this.PlSuf.Location = new System.Drawing.Point(6, 160);
            this.PlSuf.Name = "PlSuf";
            this.PlSuf.Size = new System.Drawing.Size(262, 27);
            this.PlSuf.TabIndex = 1;
            // 
            // LsSuf
            // 
            this.LsSuf.FormattingEnabled = true;
            this.LsSuf.ItemHeight = 12;
            this.LsSuf.Location = new System.Drawing.Point(6, 6);
            this.LsSuf.Name = "LsSuf";
            this.LsSuf.Size = new System.Drawing.Size(262, 148);
            this.LsSuf.TabIndex = 0;
            this.LsSuf.SelectedIndexChanged += new System.EventHandler(this.LsSuf_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HkStop);
            this.tabPage1.Controls.Add(this.LbStop);
            this.tabPage1.Controls.Add(this.HkNext);
            this.tabPage1.Controls.Add(this.LbNext);
            this.tabPage1.Controls.Add(this.HkHalt);
            this.tabPage1.Controls.Add(this.LbHalt);
            this.tabPage1.Controls.Add(this.HkWork);
            this.tabPage1.Controls.Add(this.LbWork);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(296, 193);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "快捷键";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HkStop
            // 
            this.HkStop.HotKey = "";
            this.HkStop.Location = new System.Drawing.Point(83, 87);
            this.HkStop.Name = "HkStop";
            this.HkStop.Size = new System.Drawing.Size(207, 21);
            this.HkStop.TabIndex = 7;
            // 
            // LbStop
            // 
            this.LbStop.AutoSize = true;
            this.LbStop.Location = new System.Drawing.Point(6, 91);
            this.LbStop.Name = "LbStop";
            this.LbStop.Size = new System.Drawing.Size(71, 12);
            this.LbStop.TabIndex = 6;
            this.LbStop.Text = "终止会话(D)";
            // 
            // HkNext
            // 
            this.HkNext.HotKey = "";
            this.HkNext.Location = new System.Drawing.Point(83, 60);
            this.HkNext.Name = "HkNext";
            this.HkNext.Size = new System.Drawing.Size(207, 21);
            this.HkNext.TabIndex = 5;
            // 
            // LbNext
            // 
            this.LbNext.AutoSize = true;
            this.LbNext.Location = new System.Drawing.Point(6, 64);
            this.LbNext.Name = "LbNext";
            this.LbNext.Size = new System.Drawing.Size(71, 12);
            this.LbNext.TabIndex = 4;
            this.LbNext.Text = "继续会话(&E)";
            // 
            // HkHalt
            // 
            this.HkHalt.HotKey = "";
            this.HkHalt.Location = new System.Drawing.Point(83, 33);
            this.HkHalt.Name = "HkHalt";
            this.HkHalt.Size = new System.Drawing.Size(207, 21);
            this.HkHalt.TabIndex = 3;
            // 
            // LbHalt
            // 
            this.LbHalt.AutoSize = true;
            this.LbHalt.Location = new System.Drawing.Point(6, 37);
            this.LbHalt.Name = "LbHalt";
            this.LbHalt.Size = new System.Drawing.Size(71, 12);
            this.LbHalt.TabIndex = 2;
            this.LbHalt.Text = "暂停会话(&D)";
            // 
            // HkWork
            // 
            this.HkWork.HotKey = "";
            this.HkWork.Location = new System.Drawing.Point(83, 6);
            this.HkWork.Name = "HkWork";
            this.HkWork.Size = new System.Drawing.Size(207, 21);
            this.HkWork.TabIndex = 1;
            // 
            // LbWork
            // 
            this.LbWork.AutoSize = true;
            this.LbWork.Location = new System.Drawing.Point(6, 10);
            this.LbWork.Name = "LbWork";
            this.LbWork.Size = new System.Drawing.Size(71, 12);
            this.LbWork.TabIndex = 0;
            this.LbWork.Text = "开始会话(&J)";
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiThreadWait,
            this.MiSeperator,
            this.MiExecuteApp,
            this.MiShowWindow,
            this.MiHideWindow,
            this.MiGetControl,
            this.MiKeybdInput,
            this.MiMouseInput});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(140, 164);
            // 
            // MiThreadWait
            // 
            this.MiThreadWait.Name = "MiThreadWait";
            this.MiThreadWait.Size = new System.Drawing.Size(139, 22);
            this.MiThreadWait.Text = "执行等待(&0)";
            this.MiThreadWait.Click += new System.EventHandler(this.MiThreadWait_Click);
            // 
            // MiSeperator
            // 
            this.MiSeperator.Name = "MiSeperator";
            this.MiSeperator.Size = new System.Drawing.Size(136, 6);
            // 
            // MiExecuteApp
            // 
            this.MiExecuteApp.Name = "MiExecuteApp";
            this.MiExecuteApp.Size = new System.Drawing.Size(139, 22);
            this.MiExecuteApp.Text = "执行程序(&1)";
            this.MiExecuteApp.Click += new System.EventHandler(this.MiExecuteApp_Click);
            // 
            // MiShowWindow
            // 
            this.MiShowWindow.Name = "MiShowWindow";
            this.MiShowWindow.Size = new System.Drawing.Size(139, 22);
            this.MiShowWindow.Text = "激活窗口(&2)";
            this.MiShowWindow.Click += new System.EventHandler(this.MiShowWindow_Click);
            // 
            // MiHideWindow
            // 
            this.MiHideWindow.Name = "MiHideWindow";
            this.MiHideWindow.Size = new System.Drawing.Size(139, 22);
            this.MiHideWindow.Text = "隐藏窗口(&3)";
            this.MiHideWindow.Click += new System.EventHandler(this.MiHideWindow_Click);
            // 
            // MiGetControl
            // 
            this.MiGetControl.Name = "MiGetControl";
            this.MiGetControl.Size = new System.Drawing.Size(139, 22);
            this.MiGetControl.Text = "查找组件(&4)";
            this.MiGetControl.Click += new System.EventHandler(this.MiGetControl_Click);
            // 
            // MiKeybdInput
            // 
            this.MiKeybdInput.Name = "MiKeybdInput";
            this.MiKeybdInput.Size = new System.Drawing.Size(139, 22);
            this.MiKeybdInput.Text = "键盘输入(&5)";
            this.MiKeybdInput.Click += new System.EventHandler(this.MiKeybdInput_Click);
            // 
            // MiMouseInput
            // 
            this.MiMouseInput.Name = "MiMouseInput";
            this.MiMouseInput.Size = new System.Drawing.Size(139, 22);
            this.MiMouseInput.Text = "鼠标点击(&6)";
            this.MiMouseInput.Click += new System.EventHandler(this.MiMouseInput_Click);
            // 
            // EditSln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 272);
            this.Controls.Add(this.TcSln);
            this.Controls.Add(this.LsSolution);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSln";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "方案";
            this.Load += new System.EventHandler(this.EditSln_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditSln_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.PbAdd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbNew1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAdd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbNew3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBot3)).EndInit();
            this.TcSln.ResumeLayout(false);
            this.TpSln.ResumeLayout(false);
            this.TpSln.PerformLayout();
            this.TpPre.ResumeLayout(false);
            this.TpFun.ResumeLayout(false);
            this.TpFun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpIntval)).EndInit();
            this.TpSuf.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsSolution;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.ToolTip TtTips;
        private System.Windows.Forms.TabControl TcSln;
        private System.Windows.Forms.TabPage TpPre;
        private System.Windows.Forms.TabPage TpFun;
        private System.Windows.Forms.TabPage TpSuf;
        private System.Windows.Forms.ListBox LsPre;
        private System.Windows.Forms.PictureBox PbNew1;
        private System.Windows.Forms.PictureBox PbDel1;
        private System.Windows.Forms.PictureBox PbBot1;
        private System.Windows.Forms.ListBox LsSuf;
        private System.Windows.Forms.PictureBox PbNew3;
        private System.Windows.Forms.PictureBox PbDel3;
        private System.Windows.Forms.PictureBox PbBot3;
        private System.Windows.Forms.Label LbMethod;
        private System.Windows.Forms.Label LbTarget;
        private System.Windows.Forms.ComboBox CbTarget;
        private System.Windows.Forms.Label LbIntval;
        private System.Windows.Forms.NumericUpDown SpIntval;
        private System.Windows.Forms.PictureBox PbTop1;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.PictureBox PbTop3;
        private System.Windows.Forms.ToolStripMenuItem MiShowWindow;
        private System.Windows.Forms.ToolStripMenuItem MiGetControl;
        private System.Windows.Forms.ToolStripMenuItem MiKeybdInput;
        private System.Windows.Forms.ToolStripMenuItem MiMouseInput;
        private System.Windows.Forms.PictureBox PbAdd1;
        private System.Windows.Forms.PictureBox PbAdd3;
        private System.Windows.Forms.TabPage TpSln;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.ComboBox CbLanguage;
        private System.Windows.Forms.Label LbLanguage;
        private System.Windows.Forms.Label LbCategory;
        private System.Windows.Forms.ListBox LsCategory;
        private System.Windows.Forms.ToolStripMenuItem MiExecuteApp;
        private System.Windows.Forms.ToolStripMenuItem MiHideWindow;
        private System.Windows.Forms.ComboBox CbMethod;
        private System.Windows.Forms.ToolStripMenuItem MiThreadWait;
        private System.Windows.Forms.ToolStripSeparator MiSeperator;
        private System.Windows.Forms.Panel PlPre;
        private System.Windows.Forms.Panel PlSuf;
        private System.Windows.Forms.ComboBox CbOutput;
        private System.Windows.Forms.Label LbOutput;
        private System.Windows.Forms.Label LbInit;
        private PostAction PaInit;
        private PostAction PaPost;
        private System.Windows.Forms.Label LbPost;
        private System.Windows.Forms.TabPage tabPage1;
        private HotKeys HkWork;
        private System.Windows.Forms.Label LbWork;
        private HotKeys HkStop;
        private System.Windows.Forms.Label LbStop;
        private HotKeys HkNext;
        private System.Windows.Forms.Label LbNext;
        private HotKeys HkHalt;
        private System.Windows.Forms.Label LbHalt;
    }
}
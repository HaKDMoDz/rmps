using com.magickms._uc;

namespace com.magickms.od
{
    partial class UserOpt
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
            this.LbSlns = new System.Windows.Forms.ListBox();
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
            this.TcSlns = new System.Windows.Forms.TabControl();
            this.TpPre = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbOpt1 = new System.Windows.Forms.ListBox();
            this.TpFun = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TpSuf = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LbOpt3 = new System.Windows.Forms.ListBox();
            this.TpSln = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MiGetControl = new System.Windows.Forms.ToolStripMenuItem();
            this.MiKeybdInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMouseInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHideWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExecuteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.findCmp1 = new com.magickms._uc.FindCmp();
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
            this.TcSlns.SuspendLayout();
            this.TpPre.SuspendLayout();
            this.TpFun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.TpSuf.SuspendLayout();
            this.TpSln.SuspendLayout();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbSlns
            // 
            this.LbSlns.FormattingEnabled = true;
            this.LbSlns.ItemHeight = 12;
            this.LbSlns.Location = new System.Drawing.Point(12, 12);
            this.LbSlns.Name = "LbSlns";
            this.LbSlns.Size = new System.Drawing.Size(120, 220);
            this.LbSlns.TabIndex = 0;
            // 
            // BtAppend
            // 
            this.BtAppend.Location = new System.Drawing.Point(165, 237);
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
            this.BtUpdate.Location = new System.Drawing.Point(246, 237);
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
            this.BtCancel.Location = new System.Drawing.Point(327, 237);
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
            this.PbAdd1.Image = global::com.magickms.Properties.Resources._add;
            this.PbAdd1.Location = new System.Drawing.Point(234, 171);
            this.PbAdd1.Name = "PbAdd1";
            this.PbAdd1.Size = new System.Drawing.Size(16, 16);
            this.PbAdd1.TabIndex = 6;
            this.PbAdd1.TabStop = false;
            this.TtTips.SetToolTip(this.PbAdd1, "保存动作");
            // 
            // PbTop1
            // 
            this.PbTop1.Image = global::com.magickms.Properties.Resources._top;
            this.PbTop1.Location = new System.Drawing.Point(234, 83);
            this.PbTop1.Name = "PbTop1";
            this.PbTop1.Size = new System.Drawing.Size(16, 16);
            this.PbTop1.TabIndex = 5;
            this.PbTop1.TabStop = false;
            this.TtTips.SetToolTip(this.PbTop1, "上移一行");
            this.PbTop1.Click += new System.EventHandler(this.PbTop1_Click);
            // 
            // PbNew1
            // 
            this.PbNew1.Image = global::com.magickms.Properties.Resources._new;
            this.PbNew1.Location = new System.Drawing.Point(234, 149);
            this.PbNew1.Name = "PbNew1";
            this.PbNew1.Size = new System.Drawing.Size(16, 16);
            this.PbNew1.TabIndex = 4;
            this.PbNew1.TabStop = false;
            this.TtTips.SetToolTip(this.PbNew1, "新增动作");
            this.PbNew1.Click += new System.EventHandler(this.PbAdd1_Click);
            // 
            // PbDel1
            // 
            this.PbDel1.Image = global::com.magickms.Properties.Resources._del;
            this.PbDel1.Location = new System.Drawing.Point(234, 127);
            this.PbDel1.Name = "PbDel1";
            this.PbDel1.Size = new System.Drawing.Size(16, 16);
            this.PbDel1.TabIndex = 3;
            this.PbDel1.TabStop = false;
            this.TtTips.SetToolTip(this.PbDel1, "删除当前动作");
            this.PbDel1.Click += new System.EventHandler(this.PbDel1_Click);
            // 
            // PbBot1
            // 
            this.PbBot1.Image = global::com.magickms.Properties.Resources._bot;
            this.PbBot1.Location = new System.Drawing.Point(234, 105);
            this.PbBot1.Name = "PbBot1";
            this.PbBot1.Size = new System.Drawing.Size(16, 16);
            this.PbBot1.TabIndex = 2;
            this.PbBot1.TabStop = false;
            this.TtTips.SetToolTip(this.PbBot1, "下移一行");
            this.PbBot1.Click += new System.EventHandler(this.PbBot1_Click);
            // 
            // PbAdd3
            // 
            this.PbAdd3.Image = global::com.magickms.Properties.Resources._add;
            this.PbAdd3.Location = new System.Drawing.Point(234, 171);
            this.PbAdd3.Name = "PbAdd3";
            this.PbAdd3.Size = new System.Drawing.Size(16, 16);
            this.PbAdd3.TabIndex = 9;
            this.PbAdd3.TabStop = false;
            this.TtTips.SetToolTip(this.PbAdd3, "保存动作");
            // 
            // PbTop3
            // 
            this.PbTop3.Image = global::com.magickms.Properties.Resources._top;
            this.PbTop3.Location = new System.Drawing.Point(234, 83);
            this.PbTop3.Name = "PbTop3";
            this.PbTop3.Size = new System.Drawing.Size(16, 16);
            this.PbTop3.TabIndex = 8;
            this.PbTop3.TabStop = false;
            this.TtTips.SetToolTip(this.PbTop3, "上移一行");
            this.PbTop3.Click += new System.EventHandler(this.PbTop3_Click);
            // 
            // PbNew3
            // 
            this.PbNew3.Image = global::com.magickms.Properties.Resources._new;
            this.PbNew3.Location = new System.Drawing.Point(234, 149);
            this.PbNew3.Name = "PbNew3";
            this.PbNew3.Size = new System.Drawing.Size(16, 16);
            this.PbNew3.TabIndex = 7;
            this.PbNew3.TabStop = false;
            this.TtTips.SetToolTip(this.PbNew3, "添加动作");
            this.PbNew3.Click += new System.EventHandler(this.PbAdd3_Click);
            // 
            // PbDel3
            // 
            this.PbDel3.Image = global::com.magickms.Properties.Resources._del;
            this.PbDel3.Location = new System.Drawing.Point(234, 127);
            this.PbDel3.Name = "PbDel3";
            this.PbDel3.Size = new System.Drawing.Size(16, 16);
            this.PbDel3.TabIndex = 6;
            this.PbDel3.TabStop = false;
            this.TtTips.SetToolTip(this.PbDel3, "删除当行动作");
            this.PbDel3.Click += new System.EventHandler(this.PbDel3_Click);
            // 
            // PbBot3
            // 
            this.PbBot3.Image = global::com.magickms.Properties.Resources._bot;
            this.PbBot3.Location = new System.Drawing.Point(234, 105);
            this.PbBot3.Name = "PbBot3";
            this.PbBot3.Size = new System.Drawing.Size(16, 16);
            this.PbBot3.TabIndex = 5;
            this.PbBot3.TabStop = false;
            this.TtTips.SetToolTip(this.PbBot3, "下移一行");
            this.PbBot3.Click += new System.EventHandler(this.PbBot3_Click);
            // 
            // TcSlns
            // 
            this.TcSlns.Controls.Add(this.TpSln);
            this.TcSlns.Controls.Add(this.TpPre);
            this.TcSlns.Controls.Add(this.TpFun);
            this.TcSlns.Controls.Add(this.TpSuf);
            this.TcSlns.Location = new System.Drawing.Point(138, 12);
            this.TcSlns.Name = "TcSlns";
            this.TcSlns.SelectedIndex = 0;
            this.TcSlns.Size = new System.Drawing.Size(264, 219);
            this.TcSlns.TabIndex = 1;
            // 
            // TpPre
            // 
            this.TpPre.Controls.Add(this.PbAdd1);
            this.TpPre.Controls.Add(this.PbTop1);
            this.TpPre.Controls.Add(this.PbNew1);
            this.TpPre.Controls.Add(this.PbDel1);
            this.TpPre.Controls.Add(this.PbBot1);
            this.TpPre.Controls.Add(this.panel1);
            this.TpPre.Controls.Add(this.LbOpt1);
            this.TpPre.Location = new System.Drawing.Point(4, 22);
            this.TpPre.Name = "TpPre";
            this.TpPre.Padding = new System.Windows.Forms.Padding(3);
            this.TpPre.Size = new System.Drawing.Size(256, 193);
            this.TpPre.TabIndex = 0;
            this.TpPre.Text = "前置操作";
            this.TpPre.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 32);
            this.panel1.TabIndex = 1;
            // 
            // LbOpt1
            // 
            this.LbOpt1.FormattingEnabled = true;
            this.LbOpt1.ItemHeight = 12;
            this.LbOpt1.Location = new System.Drawing.Point(6, 6);
            this.LbOpt1.Name = "LbOpt1";
            this.LbOpt1.Size = new System.Drawing.Size(222, 148);
            this.LbOpt1.TabIndex = 0;
            // 
            // TpFun
            // 
            this.TpFun.Controls.Add(this.findCmp1);
            this.TpFun.Controls.Add(this.numericUpDown1);
            this.TpFun.Controls.Add(this.label3);
            this.TpFun.Controls.Add(this.comboBox2);
            this.TpFun.Controls.Add(this.label4);
            this.TpFun.Controls.Add(this.label2);
            this.TpFun.Controls.Add(this.comboBox1);
            this.TpFun.Controls.Add(this.label1);
            this.TpFun.Location = new System.Drawing.Point(4, 22);
            this.TpFun.Name = "TpFun";
            this.TpFun.Padding = new System.Windows.Forms.Padding(3);
            this.TpFun.Size = new System.Drawing.Size(256, 193);
            this.TpFun.TabIndex = 1;
            this.TpFun.Text = "会话方式";
            this.TpFun.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(83, 58);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "会话间隔(&I)";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "模拟输入",
            "发送消息"});
            this.comboBox2.Location = new System.Drawing.Point(83, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "输入对象(&T)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "模拟方式(&K)";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "自动应答",
            "手动应答",
            "主动发话"});
            this.comboBox1.Location = new System.Drawing.Point(83, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会话模式(&M)";
            // 
            // TpSuf
            // 
            this.TpSuf.Controls.Add(this.PbAdd3);
            this.TpSuf.Controls.Add(this.PbTop3);
            this.TpSuf.Controls.Add(this.PbNew3);
            this.TpSuf.Controls.Add(this.PbDel3);
            this.TpSuf.Controls.Add(this.PbBot3);
            this.TpSuf.Controls.Add(this.panel2);
            this.TpSuf.Controls.Add(this.LbOpt3);
            this.TpSuf.Location = new System.Drawing.Point(4, 22);
            this.TpSuf.Name = "TpSuf";
            this.TpSuf.Padding = new System.Windows.Forms.Padding(3);
            this.TpSuf.Size = new System.Drawing.Size(256, 193);
            this.TpSuf.TabIndex = 2;
            this.TpSuf.Text = "后置操作";
            this.TpSuf.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(6, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 32);
            this.panel2.TabIndex = 1;
            // 
            // LbOpt3
            // 
            this.LbOpt3.FormattingEnabled = true;
            this.LbOpt3.ItemHeight = 12;
            this.LbOpt3.Location = new System.Drawing.Point(6, 6);
            this.LbOpt3.Name = "LbOpt3";
            this.LbOpt3.Size = new System.Drawing.Size(222, 148);
            this.LbOpt3.TabIndex = 0;
            // 
            // TpSln
            // 
            this.TpSln.Controls.Add(this.listBox1);
            this.TpSln.Controls.Add(this.label8);
            this.TpSln.Controls.Add(this.comboBox4);
            this.TpSln.Controls.Add(this.label7);
            this.TpSln.Controls.Add(this.comboBox3);
            this.TpSln.Controls.Add(this.label6);
            this.TpSln.Controls.Add(this.textBox1);
            this.TpSln.Controls.Add(this.label5);
            this.TpSln.Location = new System.Drawing.Point(4, 22);
            this.TpSln.Name = "TpSln";
            this.TpSln.Padding = new System.Windows.Forms.Padding(3);
            this.TpSln.Size = new System.Drawing.Size(256, 193);
            this.TpSln.TabIndex = 3;
            this.TpSln.Text = "会议方案";
            this.TpSln.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(83, 87);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(167, 100);
            this.listBox1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "语言资源(&L)";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(83, 60);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(108, 20);
            this.comboBox4.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "交互方式(&M)";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(83, 33);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(108, 20);
            this.comboBox3.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "交互目标(&T)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "方案名称(&N)";
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiExecuteApp,
            this.MiShowWindow,
            this.MiHideWindow,
            this.MiGetControl,
            this.MiKeybdInput,
            this.MiMouseInput});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(140, 136);
            // 
            // MiShowWindow
            // 
            this.MiShowWindow.Name = "MiShowWindow";
            this.MiShowWindow.Size = new System.Drawing.Size(139, 22);
            this.MiShowWindow.Text = "激活窗口(&2)";
            // 
            // MiGetControl
            // 
            this.MiGetControl.Name = "MiGetControl";
            this.MiGetControl.Size = new System.Drawing.Size(139, 22);
            this.MiGetControl.Text = "查找组件(&4)";
            // 
            // MiKeybdInput
            // 
            this.MiKeybdInput.Name = "MiKeybdInput";
            this.MiKeybdInput.Size = new System.Drawing.Size(139, 22);
            this.MiKeybdInput.Text = "键盘输入(&5)";
            // 
            // MiMouseInput
            // 
            this.MiMouseInput.Name = "MiMouseInput";
            this.MiMouseInput.Size = new System.Drawing.Size(139, 22);
            this.MiMouseInput.Text = "鼠标点击(&6)";
            // 
            // MiHideWindow
            // 
            this.MiHideWindow.Name = "MiHideWindow";
            this.MiHideWindow.Size = new System.Drawing.Size(139, 22);
            this.MiHideWindow.Text = "隐藏窗口(&3)";
            // 
            // MiExecuteApp
            // 
            this.MiExecuteApp.Name = "MiExecuteApp";
            this.MiExecuteApp.Size = new System.Drawing.Size(139, 22);
            this.MiExecuteApp.Text = "执行程序(&1)";
            // 
            // findCmp1
            // 
            this.findCmp1.Location = new System.Drawing.Point(84, 85);
            this.findCmp1.Name = "findCmp1";
            // TODO: “this.findCmp1.SelectWindow”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            this.findCmp1.Size = new System.Drawing.Size(146, 32);
            this.findCmp1.TabIndex = 8;
            // 
            // UserOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 272);
            this.Controls.Add(this.TcSlns);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.LbSlns);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAppend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserOpt";
            this.Text = "选项";
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
            this.TcSlns.ResumeLayout(false);
            this.TpPre.ResumeLayout(false);
            this.TpFun.ResumeLayout(false);
            this.TpFun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.TpSuf.ResumeLayout(false);
            this.TpSln.ResumeLayout(false);
            this.TpSln.PerformLayout();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbSlns;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.ToolTip TtTips;
        private System.Windows.Forms.TabControl TcSlns;
        private System.Windows.Forms.TabPage TpPre;
        private System.Windows.Forms.TabPage TpFun;
        private System.Windows.Forms.TabPage TpSuf;
        private System.Windows.Forms.ListBox LbOpt1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PbNew1;
        private System.Windows.Forms.PictureBox PbDel1;
        private System.Windows.Forms.PictureBox PbBot1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox LbOpt3;
        private System.Windows.Forms.PictureBox PbNew3;
        private System.Windows.Forms.PictureBox PbDel3;
        private System.Windows.Forms.PictureBox PbBot3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox PbTop1;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.PictureBox PbTop3;
        private System.Windows.Forms.ToolStripMenuItem MiShowWindow;
        private System.Windows.Forms.ToolStripMenuItem MiGetControl;
        private System.Windows.Forms.ToolStripMenuItem MiKeybdInput;
        private System.Windows.Forms.ToolStripMenuItem MiMouseInput;
        private System.Windows.Forms.PictureBox PbAdd1;
        private System.Windows.Forms.PictureBox PbAdd3;
        private FindCmp findCmp1;
        private System.Windows.Forms.TabPage TpSln;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem MiExecuteApp;
        private System.Windows.Forms.ToolStripMenuItem MiHideWindow;
    }
}
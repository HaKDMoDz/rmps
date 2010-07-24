using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using com.amonsoft.exts.exts0001;
using com.amonsoft.exts.Properties;
using Microsoft.Win32;

namespace com.amonsoft.exts
{
    public partial class FM_ExtParse : Form
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        private const int PAGESIZE = 9;
        /// <summary>
        /// 结果记录数量
        /// </summary>
        private static int cnt = 1;
        /// <summary>
        /// 上一次访问索引
        /// </summary>
        private static int idx;
        /// <summary>
        /// 导航链接数组
        /// </summary>
        private static LinkLabel[] lls;
        /// <summary>
        /// 页面偏移记录
        /// </summary>
        private static int off;
        /// <summary>
        /// XML文档对象
        /// </summary>
        private static XmlDocument xml;
        /// <summary>
        /// 状态栏句柄
        /// </summary>
        private static IntPtr bar;

        #region 界面初始化

        public FM_ExtParse()
        {
            InitializeComponent();

            LC_ExtsUpdt.Text = DateTime.Now.ToString();
            LL_NextPage.Location = new Point(87, 274);

            // 窗口透明度设置
            SetFormOpacity(Settings.Default.form_top_first, false);

            lls = new LinkLabel[11];
            lls[idx++] = LL_LastPage;
            lls[idx++] = LL_PageIdx1;
            lls[idx++] = LL_PageIdx2;
            lls[idx++] = LL_PageIdx3;
            lls[idx++] = LL_PageIdx4;
            lls[idx++] = LL_PageIdx5;
            lls[idx++] = LL_PageIdx6;
            lls[idx++] = LL_PageIdx7;
            lls[idx++] = LL_PageIdx8;
            lls[idx++] = LL_PageIdx9;
            lls[idx++] = LL_NextPage;
            idx = 1;
        }

        #endregion

        #region 界面组件事件处理

        #region 徽标按钮事件处理

        /// <summary>
        /// 徽标事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Logo_Click(object sender, EventArgs e)
        {
            Process.Start(Cons.WEB_SITE + "/soft/soft0001.aspx?sid=13010000");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Logo_MouseEnter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Logo_MouseLeave(object sender, EventArgs e)
        {
        }

        #endregion

        #region 退出按钮事件处理

        /// <summary>
        /// 窗口关闭按钮事件处理：系统退出事件处理，用于退出当前系统。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Exit_Click(object sender, EventArgs e)
        {
            Visible = false;
            if (Settings.Default.form_run_first)
            {
                FindExts("user");
                Settings cfg = Settings.Default;
                cfg.form_run_first = false;
                cfg.Save();
            }
            Application.Exit();
        }

        /// <summary>
        /// 窗口关闭按钮事件处理：鼠标进入当前构件时，显示改变的图像，以响应用户的操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Exit_MouseEnter(object sender, EventArgs e)
        {
            PB_Exit.Image = Resources.ExitP;
        }

        /// <summary>
        /// 窗口关闭按钮事件处理：鼠标移出当前构件时，显示默认的图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Exit_MouseLeave(object sender, EventArgs e)
        {
            PB_Exit.Image = Resources.ExitD;
        }

        #endregion

        #region 隐藏按钮事件处理

        /// <summary>
        /// 窗口隐藏按钮事件处理：窗口最小化事件处理，用于隐藏当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 窗口隐藏按钮事件处理：鼠标进入当前构件时，显示改变的图像，以响应用户的操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Hide_MouseEnter(object sender, EventArgs e)
        {
            PB_Hide.Image = Resources.HideP;
        }

        /// <summary>
        /// 窗口隐藏按钮事件处理：鼠标移出当前构件时，显示默认的图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Hide_MouseLeave(object sender, EventArgs e)
        {
            PB_Hide.Image = Resources.HideD;
        }

        #endregion

        #region 系统菜单事件处理

        /// <summary>
        /// 窗口菜单按钮事件处理：系统下拉菜单事件处理，用于显示系统常规菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Menu_Click(object sender, EventArgs e)
        {
            Point menuPnt = PB_Menu.Location;
            menuPnt.X += 1;
            menuPnt.Y += PB_Menu.Height;
            PM_MenuList.Show(this, menuPnt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Menu_MouseEnter(object sender, EventArgs e)
        {
            PB_Menu.Image = Resources.MenuP;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Menu_MouseLeave(object sender, EventArgs e)
        {
            PB_Menu.Image = Resources.MenuD;
        }

        #endregion

        #region 窗口移动事件处理

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);

        /// <summary>
        /// 窗口拖动事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left) //按下的是鼠标左键            
            {
                Capture = false; //释放鼠标，使能够手动操作                
                SendMessage(Handle, 0x00A1, 2, 0); //拖动窗体            
            }
        }

        /// <summary>
        /// 重写事件分发器
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0201) //鼠标左键按下去的消息
            {
                m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                m.LParam = IntPtr.Zero; //默认值
                m.WParam = new IntPtr(2); //鼠标放在标题栏内
            }
            base.WndProc(ref m);
        }

        #endregion

        #region 窗口拖拽事件处理

        /// <summary>
        /// 拖拽完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FM_ExtParse_DragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (array.Length > 0)
            {
                TF_ExtsName.Text = Path.GetExtension(array.GetValue(0).ToString());
                ReadExtsData();
            }
        }

        /// <summary>
        /// 拖拽进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FM_ExtParse_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        #endregion

        #region 系统菜单事件处理

        /// <summary>
        /// 关于软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SoftInfo_Click(object sender, EventArgs e)
        {
            Process.Start(Cons.WEB_SITE + "/soft/soft0001.aspx?sid=13010000");
        }

        /// <summary>
        /// 网站首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_HomePage_Click(object sender, EventArgs e)
        {
            Process.Start(Cons.WEB_SITE);
        }

        /// <summary>
        /// 项目首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SoftCode_Click(object sender, EventArgs e)
        {
            Process.Start("http://code.google.com/p/extparse/");
        }

        /// <summary>
        /// 窗口置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_TopFirst_Click(object sender, EventArgs e)
        {
            bool top = !TopMost;
            MI_TopFirst.Checked = top;
            TopMost = top;
        }

        /// <summary>
        /// 透明度100%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP10_Click(object sender, EventArgs e)
        {
            SetFormOpacity(100, true);
        }

        /// <summary>
        /// 透明度90%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP09_Click(object sender, EventArgs e)
        {
            SetFormOpacity(90, true);
        }

        /// <summary>
        /// 透明度80%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP08_Click(object sender, EventArgs e)
        {
            SetFormOpacity(80, true);
        }

        /// <summary>
        /// 透明度70%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP07_Click(object sender, EventArgs e)
        {
            SetFormOpacity(70, true);
        }

        /// <summary>
        /// 透明度60%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP06_Click(object sender, EventArgs e)
        {
            SetFormOpacity(60, true);
        }

        /// <summary>
        /// 透明度50%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP05_Click(object sender, EventArgs e)
        {
            SetFormOpacity(50, true);
        }

        /// <summary>
        /// 透明度40%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP04_Click(object sender, EventArgs e)
        {
            SetFormOpacity(40, true);
        }

        /// <summary>
        /// 透明度30%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP03_Click(object sender, EventArgs e)
        {
            SetFormOpacity(30, true);
        }

        /// <summary>
        /// 透明度20%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP02_Click(object sender, EventArgs e)
        {
            SetFormOpacity(20, true);
        }

        /// <summary>
        /// 透明度10%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_FormOP01_Click(object sender, EventArgs e)
        {
            SetFormOpacity(10, true);
        }

        /// <summary>
        /// 导出为网页文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_ExptHtml_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 导出为文本文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_ExptText_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 谷歌搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SearchGG_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            Process.Start(String.Format("http://www.google.com/search?q={0}", TF_ExtsName.Text));
        }

        /// <summary>
        /// 雅虎搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SearchYH_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            Process.Start(String.Format("http://one.cn.yahoo.com/s?p={0}", TF_ExtsName.Text));
        }

        /// <summary>
        /// 有道搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SearchYD_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            Process.Start(String.Format("http://www.youdao.com/search?q={0}", TF_ExtsName.Text));
        }

        /// <summary>
        /// 百度搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_SearchBD_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            Process.Start(String.Format("http://www.baidu.com/s?cl=3&wd={0}", TF_ExtsName.Text));
        }

        /// <summary>
        /// 贡献后缀信息处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_VoteExts_Click(object sender, EventArgs e)
        {
            FM_ExtCheck fmec = new FM_ExtCheck();
            fmec.Show(this);
        }

        /// <summary>
        /// 屏幕截图事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_ShotSoft_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Thread.Sleep(1000 * Settings.Default.screenshot_t + 300);
            Settings settings = Settings.Default;
            RECT rect = ResizeWin(settings.screenshot_m, settings.screenshot_s, settings.screenshot_r, settings.screenshot_x, settings.screenshot_y, settings.screenshot_w, settings.screenshot_h);

            CaptureImage(new Point(rect.left, rect.top), new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top));

            this.Visible = true;
        }

        /// <summary>
        /// 截图选项事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_ShotOpts_Click(object sender, EventArgs e)
        {
            FM_ExtShots es = new FM_ExtShots();
            es.ShowDialog();
        }

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_HideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_ExitForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region 界面按钮事件处理

        /// <summary>
        /// 按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Query_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            ReadExtsData();
        }

        /// <summary>
        /// 文件查看事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_FileView_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "所有(*.*)|*.*";
            ofd.ShowDialog();

            String fileName = ofd.FileName;
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            TF_ExtsName.Text = Path.GetExtension(fileName);
            ReadExtsData();
        }

        /// <summary>
        /// 报错按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_HoldBugs_Click(object sender, EventArgs e)
        {
            Process.Start(Cons.WEB_SITE + "/idea/idea0001.aspx?sid=13010000");
        }

        /// <summary>
        /// 快捷地址点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_ExtsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(LC_ExtsLink.Text);
        }

        #endregion

        #region 导航链接事件处理

        /// <summary>
        /// 上一页按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_LastPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            off -= PAGESIZE;
            LL_LastPage.Enabled = off > 0;
            LL_NextPage.Enabled = (cnt - off - 1) / PAGESIZE > 0;

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(1);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第1页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 1 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(1);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第2页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 2 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(2);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第3页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 3 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(3);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第4页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 4 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(4);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第5页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 5 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(5);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第6页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 6 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(6);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第7页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 7 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(7);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第8页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 8 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(8);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 第9页导航链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_PageIdx9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (idx == 9 || xml == null)
            {
                return;
            }

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(9);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        /// <summary>
        /// 下一页按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LL_NextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            off += PAGESIZE;
            LL_LastPage.Enabled = off > 0;
            LL_NextPage.Enabled = (cnt - off - 1) / PAGESIZE > 0;

            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            ReLocated(1);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            ReadExtsInfo(xml.SelectSingleNode(String.Format("/P3010000/exts[{0}]", off + idx)));
        }

        #endregion

        #endregion

        #region 公共方法

        /// <summary>
        /// 检查用户输入数据的合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            // 用户输入数据为空判断
            String text = TF_ExtsName.Text;
            if (String.IsNullOrEmpty(text))
            {
                MessageBox.Show(this, "请输入后缀名称！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TF_ExtsName.Focus();
                return false;
            }
            text = text.Trim();
            // 当前用户仅输入一个点号时不进行任何操作
            if (text.Length < 1 || text == ".")
            {
                MessageBox.Show(this, "请输入有效的后缀名称！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TF_ExtsName.Focus();
                return false;
            }

            // 保证用户输入数据总是以指定格式显示：“.后缀名称”
            if (!text.StartsWith("."))
            {
                text = "." + text;
            }
            TF_ExtsName.Text = text;

            return true;
        }

        /// <summary>
        /// 设置窗口透明度
        /// </summary>
        /// <param name="opacity">透明值，0～100之间</param>
        /// <param name="saveDate">是否保存当前数据到配置文件，true:保存；false:不保存，此属性要用于系统启动时使用</param>
        private void SetFormOpacity(byte opacity, bool saveDate)
        {
            Opacity = (double)opacity / 100;

            MI_FormOP10.Checked = (100 == opacity);
            MI_FormOP09.Checked = (90 == opacity);
            MI_FormOP08.Checked = (80 == opacity);
            MI_FormOP07.Checked = (70 == opacity);
            MI_FormOP06.Checked = (60 == opacity);
            MI_FormOP05.Checked = (50 == opacity);
            MI_FormOP04.Checked = (40 == opacity);
            MI_FormOP03.Checked = (30 == opacity);
            MI_FormOP02.Checked = (20 == opacity);
            MI_FormOP01.Checked = (10 == opacity);

            if (saveDate)
            {
                Settings set = Settings.Default;
                set.form_top_first = opacity;
                set.Save();
            }
        }

        /// <summary>
        /// 读取后缀数据并显示
        /// </summary>
        private void ReadExtsData()
        {
            // 界面初始化
            off = 0;
            LL_LastPage.Enabled = false;
            LL_NextPage.Enabled = false;

            // 加载XML文档
            if (xml == null)
            {
                xml = new XmlDocument();
            }
            xml.Load(String.Format(Cons.WEB_SITE + "/exts/exts0001.ashx?type=list&exts={0}", TF_ExtsName.Text.ToUpper()));

            // 读取记录个数
            XmlNodeList list = xml.SelectNodes("/P3010000/exts");
            if (list == null || list.Count < 1)
            {
                cnt = 1;
                MessageBox.Show(this, "您查询的后缀信息不存在！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cnt = list.Count;
            if (cnt > PAGESIZE)
            {
                LL_NextPage.Enabled = true;
            }

            // 设置导航可见性
            lls[idx].LinkColor = Color.Blue;
            lls[idx].Text = idx.ToString();
            idx = 2;
            while (idx <= cnt)
            {
                lls[idx++].Visible = true;
            }
            while (idx <= PAGESIZE)
            {
                lls[idx++].Visible = false;
            }

            // 显示第1页数据
            ReLocated(1);
            ReadExtsInfo(list[0]);
            lls[idx].LinkColor = Color.Red;
            lls[idx].Text = "[" + idx + "]";

            // 显示提示信息
            int t = cnt > PAGESIZE ? PAGESIZE : cnt;
            while (--t >= 0)
            {
                TP_ToolTips.SetToolTip(lls[t + 1], list[t].SelectSingleNode("base/ExtsSoft").InnerText);
            }
        }

        /// <summary>
        /// 显示具体的后缀信息
        /// </summary>
        /// <param name="node"></param>
        private void ReadExtsInfo(XmlNode node)
        {
            if (node == null)
            {
                return;
            }

            // 软件名称
            ShowInnerText(node, LC_ExtsSoft, "base/ExtsSoft");
            // 所属类别
            ShowInnerText(node, LC_ExtsType, "base/ExtsType");
            // 应用平台
            ShowInnerText(node, LC_ExtsPlat, "base/PlatForm");
            // CPU 构架
            ShowInnerText(node, LC_ExtsArch, "base/ArchBits");
            // 最后更新
            ShowInnerText(node, LC_ExtsUpdt, "base/LastUpdt");
            // 查询统计
            ShowInnerText(node, LC_ExtsFreq, "base/QueryFeq");
            // 快捷地址
            ShowInnerText(node, LC_ExtsLink, "base/QuickUrl");

            // 中文说明
            ShowInnerText(node, TB_ExtsDesp, "desp/DespInfo");

            // 公司图标
            XmlNode temp = node.SelectSingleNode("corp/CorpLogo");
            PB_CorpIcon.ImageLocation = temp != null ? Cons.WEB_SITE + temp.InnerText : null;
            temp = node.SelectSingleNode("corp/NameCN");
            TP_ToolTips.SetToolTip(PB_CorpIcon, "公司名称：" + (temp != null ? temp.InnerText : ""));

            // 软件图标
            temp = node.SelectSingleNode("soft/SoftIcon");
            PB_SoftIcon.ImageLocation = temp != null ? Cons.WEB_SITE + temp.InnerText : null;
            temp = node.SelectSingleNode("soft/NameCN");
            TP_ToolTips.SetToolTip(PB_SoftIcon, "应用程序：" + (temp != null ? temp.InnerText : ""));

            // 文件图标
            temp = node.SelectSingleNode("file/FileIcon");
            PB_FileIcon.ImageLocation = temp != null ? Cons.WEB_SITE + temp.InnerText : null;
            temp = node.SelectSingleNode("file/SignCode");
            TP_ToolTips.SetToolTip(PB_FileIcon, "文件签名：" + (temp != null ? temp.InnerText : ""));

            // 特别致谢
            temp = node.SelectSingleNode("idio/IdioLogo");
            PB_IdioIcon.ImageLocation = temp != null ? Cons.WEB_SITE + temp.InnerText : null;
            temp = node.SelectSingleNode("idio/NickName");
            TP_ToolTips.SetToolTip(PB_IdioIcon, "特别致谢：" + (temp != null ? temp.InnerText : ""));

            IL_IconList.Images.Clear();
            LV_ExtsAsoc.Items.Clear();
            XmlNodeList list = node.SelectNodes("asoc/list/item");
            if (list == null)
            {
                return;
            }
            for (int i = 0; i < list.Count; i += 1)
            {
                temp = list[i];
                if (temp != null)
                {
                    Stream stream = WebRequest.Create(Cons.WEB_SITE + temp.Attributes["icon"].Value + "&d=0010").GetResponse().GetResponseStream();
                    IL_IconList.Images.Add(Image.FromStream(stream));
                    stream.Close();
                    LV_ExtsAsoc.Items.Add(temp.Attributes["name"].Value, i);
                }
            }
        }

        /// <summary>
        /// 显示节点文本信息
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        /// <param name="p"></param>
        private static void ShowInnerText(XmlNode n, Control c, String p)
        {
            n = n.SelectSingleNode(p);
            c.Text = n != null ? n.InnerText : "";
        }

        /// <summary>
        /// 显示节点属性信息
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        /// <param name="p"></param>
        private static void ShowAttribute(XmlNode n, Control c, String p)
        {
            c.Text = n != null ? n.Attributes[p].Value : "";
        }

        /// <summary>
        /// 导航链接重新加载
        /// </summary>
        /// <param name="n"></param>
        private static void ReLocated(int n)
        {
            idx = n;

            int x = lls[1].Location.X;
            int i = 2;
            Point p;
            while (i <= idx)
            {
                x += 17;
                p = lls[i].Location;
                p.X = x;
                lls[i].Location = p;
                i += 1;
            }
            x += 12;
            while (i <= cnt)
            {
                x += 17;
                p = lls[i].Location;
                p.X = x;
                lls[i].Location = p;
                i += 1;
            }

            x += 17;
            p = lls[10].Location;
            p.X = x;
            lls[10].Location = p;
        }

        /// <summary>
        /// 查找系统后缀信息
        /// </summary>
        public static int FindExts(String user)
        {

            Exts0001SoapClient inet = new Exts0001SoapClient();
            int size = 0;

            // HKEY_CLASSES_ROOT
            RegistryKey key1 = Registry.ClassesRoot;
            foreach (String key in key1.GetSubKeyNames())
            {
                // 键为空
                if (String.IsNullOrEmpty(key) || key == "*" || (key[0] != '.'))
                {
                    continue;
                }

                // 当前后缀键值
                RegistryKey key2 = key1.OpenSubKey(key);
                if (key2 == null)
                {
                    continue;
                }

                // 后缀名称
                String exts = key;
                // MIME类型
                String mime = ((String)key2.GetValue("Content Type") ?? "").ToLower();
                // 后缀描述
                String desp = "";
                // 文件图标
                ArrayOfBase64Binary file = null;
                String temp = (String)key2.GetValue("");
                if (!String.IsNullOrEmpty(temp))
                {
                    key2 = key1.OpenSubKey(temp);
                    if (key2 != null)
                    {
                        desp = ((String)key2.GetValue("") ?? "").TrimEnd(' ', ',');
                        if (!desp.EndsWith("。"))
                        {
                            desp += '。';
                        }
                        key2 = key2.OpenSubKey("DefaultIcon");
                        if (key2 != null)
                        {
                            file = ReadByte(ReadIcon((String)key2.GetValue("")));
                        }
                    }
                }

                // 检测后缀是否存在
                temp = exts;
                if (NeedExts(temp, mime))
                {
                    if (inet.exts(user, "5p39mfkCZQ6oKtK9fQfHtIaxydVdz7JU", temp, mime, desp, file))
                    {
                        size += 1;
                    }
                }
                // 大写
                temp = exts.ToUpper();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        if (inet.exts(user, "5p39mfkCZQ6oKtK9fQfHtIaxydVdz7JU", temp, mime, "参见：" + exts, file))
                        {
                            size += 1;
                        }
                    }
                }
                // 小写
                temp = exts.ToLower();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        if (inet.exts(user, "5p39mfkCZQ6oKtK9fQfHtIaxydVdz7JU", temp, mime, "参见：" + exts, file))
                        {
                            size += 1;
                        }
                    }
                }
            }

            return size;
        }

        /// <summary>
        /// 序列化图像
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private static ArrayOfBase64Binary ReadByte(Image[] img)
        {
            if (img == null)
            {
                return null;
            }
            ArrayOfBase64Binary b = new ArrayOfBase64Binary();
            for (int i = 0; i < img.Length; i += 1)
            {
                Image g = img[i];
                MemoryStream ms = new MemoryStream(g.Width * g.Height * 4);
                g.Save(ms, ImageFormat.Png);
                b.Add(ms.GetBuffer());
                ms.Close();
            }
            return b;
        }

        /// <summary>
        /// 读取图像信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Image[] ReadIcon(String path)
        {
            // 参数为空判断
            if (String.IsNullOrEmpty(path))
            {
                return null;
            }
            // 取图标文件路径
            int i = 0;
            int j = path.LastIndexOf(',');
            if (j > 0)
            {
                try
                {
                    i = int.Parse(path.Substring(j + 1));
                }
                catch (Exception)
                {
                    i = 0;
                }
                path = path.Substring(0, j).Trim(' ', '\'', '"');
            }
            // 判断图标文件是否存在
            if (!File.Exists(path))
            {
                return null;
            }
            // 取合适的图标
            if (i < 0)
            {
                i = 0;
            }

            try
            {
                // 提取图标信息
                MultiIcon mi = new MultiIcon();
                mi.Load(path);
                if (i >= mi.Count)
                {
                    i = 0;
                }
                SingleIcon si = mi[i];

                // 取解析度最高的图像
                List<Image> img = new List<Image>();
                PixelFormat lpf = PixelFormat.Format1bppIndexed;
                j = si.Count;
                IconImage icon;
                while (j > 0)
                {
                    icon = si[--j];
                    if (icon.PixelFormat < lpf)
                    {
                        continue;
                    }
                    if (icon.PixelFormat > lpf)
                    {
                        img.Clear();
                        lpf = icon.PixelFormat;
                    }
                    img.Add(icon.Icon.ToBitmap());
                }
                return img.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 检测对应的后缀数据是否存在
        /// </summary>
        /// <param name="exts"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        private static bool NeedExts(string exts, string mime)
        {
            if (xml == null)
            {
                xml = new XmlDocument();
            }
            xml.Load(Cons.WEB_SITE + "/exts/exts0001.ashx?type=list&exts=" + exts);
            XmlNodeList list1 = xml.SelectNodes("/P3010000/exts");
            // 找不到对应的数据，则添加
            if (list1 == null || list1.Count < 1)
            {
                return true;
            }
            // MIME类型为空，则不需要添加
            if (String.IsNullOrEmpty(mime))
            {
                return false;
            }

            // 循环查找每一个后缀的MIME信息
            foreach (XmlNode node1 in list1)
            {
                XmlNodeList list2 = node1.SelectNodes("mime/list/item");
                // 当前后缀没有MIME信息，则继续下一个后缀
                if (list2 == null || list2.Count < 1)
                {
                    continue;
                }

                // 循环比较每一个MIME信息
                foreach (XmlNode node2 in list2)
                {
                    XmlAttribute tmp = node2.Attributes["name"];
                    if (tmp == null)
                    {
                        continue;
                    }

                    // 若存在相同的MIME信息，则表示对应的数据已存在
                    if ((tmp.Value ?? "").ToLower() == mime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 调整目标窗口的位置及大小
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="ratio"></param>
        /// <param name="remove"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        private RECT ResizeWin(bool remove, bool scale, bool ratio, int x, int y, int w, int h)
        {
            RECT rect = new RECT();

            IntPtr p_Handle = GetForegroundWindow();

            if (p_Handle != bar)
            {
                GetWindowRect(p_Handle, ref rect);
                int fw = rect.right - rect.left;
                int fh = rect.bottom - rect.top;
                if (scale)
                {
                    if (ratio)
                    {
                        double rw = w / (double)fw;
                        double rh = h / (double)fh;
                        double r = rw < rh ? rw : rh;
                        fw = (int)(fw * r);
                        fh = (int)(fh * r);
                    }
                    else
                    {
                        fw = w;
                        fh = h;
                    }
                }

                int fx = rect.left;
                int fy = rect.top;
                if (remove)
                {
                    fx = x;
                    fy = y;

                    Rectangle size = Screen.PrimaryScreen.WorkingArea;

                    if (fx < 0)
                    {
                        fx = (size.Width - fw) >> 1;
                    }
                    if (fy < 0)
                    {
                        fy = (size.Height - fh) >> 1;
                    }
                }
                MoveWindow(p_Handle, fx, fy, fw, fh, true);
                // 部分窗口并不会立即调整完毕并正确显示
                Thread.Sleep(500);
                GetWindowRect(p_Handle, ref rect);
            }
            return rect;
        }

        /// <summary>
        /// 截取目标窗口图像
        /// </summary>
        /// <param name="SourcePoint"></param>
        /// <param name="SelectionRectangle"></param>
        public void CaptureImage(Point SourcePoint, Rectangle SelectionRectangle)
        {
            int w = Settings.Default.screenshot_w;
            int h = Settings.Default.screenshot_h;
            bool t = false;
            if (SelectionRectangle.Width > w || SelectionRectangle.Height > h)
            {
                w = SelectionRectangle.Width;
                h = SelectionRectangle.Height;
                t = true;
            }

            Bitmap bitmap = new Bitmap(w, h);
            if (t)
            {
                using (Graphics g1 = Graphics.FromImage(bitmap))
                {
                    // g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                    g1.CopyFromScreen(SourcePoint.X, SourcePoint.Y, 0, 0, SelectionRectangle.Size);
                }

                int tw = Settings.Default.screenshot_w;
                int th = Settings.Default.screenshot_h;
                Bitmap tmp = new Bitmap(tw, th);
                Graphics g2 = Graphics.FromImage(tmp);
                
                double rw = tw / (double)w;
                double rh = th / (double)h;
                double r = rw <= rh ? rw : rh;
                tw = (int)(w * r);
                th = (int)(h * r);

                g2.DrawImage(bitmap, (Settings.Default.screenshot_w - tw) >> 1, (Settings.Default.screenshot_h - th) >> 1, tw, th);
                g2.Save();
                bitmap = tmp;
            }
            else
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                    g.CopyFromScreen(SourcePoint.X, SourcePoint.Y, (bitmap.Width - SelectionRectangle.Width) >> 1, (bitmap.Height - SelectionRectangle.Height) >> 1, SelectionRectangle.Size);
                }
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG格式|*.PNG";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                bitmap.Save(dialog.FileName, ImageFormat.Png);
            }
            bitmap.Dispose();
        }

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        #endregion
    }
}
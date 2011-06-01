using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using com.magickms.od;
using com.magickms._uc;

namespace com.magickms
{
    public partial class TrayPtn : Form
    {
        private FormPtn _formPtn;
        private UserOpt _userOpt;
        private FindCmp _findCmp;

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public TrayPtn()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗口特效
        /// <summary>
        /// 窗口重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_Paint(object sender, PaintEventArgs e)
        {
            ReShape(this, 24, 24);
        }

        /// <summary>
        /// 窗口调整大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_Resize(object sender, EventArgs e)
        {
            ReShape(this, 24, 24);
        }

        /// <summary>
        /// 重新绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void ReShape(Control sender, int width, int height)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddRectangle(new Rectangle(0, 0, width, height));
            sender.Region = new Region(oPath);
        }
        #endregion

        #region 窗口移动
        private Point _mouseOffset;
        private bool _isMouseDown;
        /// <summary>
        /// 窗口移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseDown)
            {
                return;
            }

            var mousePos = MousePosition;
            mousePos.Offset(_mouseOffset);
            Location = mousePos;
        }

        /// <summary>
        /// 鼠标放松事件，用于窗口最后定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _mouseOffset = new Point(-e.X, -e.Y);
            _isMouseDown = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }
        #endregion

        #region 右键菜单事件
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiInfo_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSend_Click(object sender, EventArgs e)
        {
            new Robots().Deal(Demo.GetDemo());
        }

        /// <summary>
        /// 对话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiTalk_Click(object sender, EventArgs e)
        {
            if (_formPtn == null)
            {
                _formPtn = new FormPtn();
            }
            _formPtn.Show();
        }

        /// <summary>
        /// 管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiUser_Click(object sender, EventArgs e)
        {
            if (_userOpt == null)
            {
                _userOpt = new UserOpt();
            }
            _userOpt.Show();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 系统托盘事件
        /// <summary>
        /// 托盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NiTray_DoubleClick(object sender, System.EventArgs e)
        {
            ShowLogo();
        }
        #endregion

        #region 系统徽标事件
        /// <summary>
        /// 徽标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbLogo_DoubleClick(object sender, EventArgs e)
        {
            ShowDrag();
        }
        #endregion

        private void ShowLogo()
        {
            this.SuspendLayout();
            this.Controls.Remove(_findCmp);
            this.Controls.Add(PbLogo);
            this.ResumeLayout();

            Size size = new Size(150, 32);
            ReShape(this, size.Width, size.Height);
            this.Size = size;
            this.ResumeLayout(false);
        }

        private void ShowDrag()
        {
            if (_findCmp == null)
            {
                _findCmp = new FindCmp();
                _findCmp.Dock = System.Windows.Forms.DockStyle.Fill;
                _findCmp.Location = new System.Drawing.Point(0, 0);
                _findCmp.Margin = new System.Windows.Forms.Padding(0);
                _findCmp.Name = "FindCmp";
                _findCmp.Size = new System.Drawing.Size(150, 32);
                _findCmp.TabIndex = 2;
                _findCmp.TabStop = false;
            }

            this.SuspendLayout();
            this.Controls.Remove(PbLogo);
            this.Controls.Add(_findCmp);

            Size size = new Size(150, 32);
            ReShape(this, size.Width, size.Height);
            this.Size = size;
            this.ResumeLayout(false);
        }
    }
}

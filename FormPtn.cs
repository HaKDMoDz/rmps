using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace com.magickms
{
    public partial class FormPtn : Form
    {
        #region 构造函数
        public FormPtn()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗口殊效
        /// <summary>
        /// 窗口重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPtn_Paint(object sender, PaintEventArgs e)
        {
            ReShape(this, 0, 0, Width, Height, 10);
        }

        /// <summary>
        /// 窗口调整大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPtn_Resize(object sender, System.EventArgs e)
        {
            ReShape(this, 0, 0, Width, Height, 10);
        }

        /// <summary>
        /// 重绘窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        private void ReShape(Control sender, int x, int y, int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // 右上角
            path.AddLine(x + radius, y, x + width - radius, y);
            path.AddArc(x + width - radius, y, radius, radius, -90, 90);

            // 右下角
            path.AddLine(x + width, y + radius, x + width, y + height - radius);
            path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);

            // 左下角
            path.AddLine(x + width - radius, y + height, x + radius, y + height);
            path.AddArc(x, y + height - radius, radius, radius, 90, 90);

            // 左上角
            path.AddLine(x, y + height - radius, x, y + radius);
            path.AddArc(x, y, radius, radius, 180, 90);

            path.CloseFigure();

            sender.Region = new Region(path);
        }
        #endregion

        #region 窗口移动事件
        private Point _mouseOffset;
        private bool _isMouseDown;
        /// <summary>
        /// 窗口移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormMouseMove(object sender, MouseEventArgs e)
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
        private void WinFormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _mouseOffset = new Point(-e.X, -e.Y);
            _isMouseDown = true;
        }

        /// <summary>
        /// 鼠标压下事件，用于窗口移动判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormMouseUp(object sender, MouseEventArgs e)
        {
            //修改鼠标状态isMouseDown的值
            //确保只有鼠标左键按下并移动时，才移动窗体
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }
        #endregion
    }
}

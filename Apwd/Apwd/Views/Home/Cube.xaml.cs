using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Me.Amon.Apwd.Views.Home
{
    public partial class Cube : UserControl
    {
        private Point _UserPoint;
        private double _CubeEdges = 128;
        private double _CubeSpeed = 5;
        private double _DefAngle = 0.05;
        private double _CenterX = 0;
        private double _CenterY = 0;
        private bool _UserAction;

        public Cube()
        {
            InitializeComponent();
        }

        #region 魔方参数
        /// <summary>
        /// 边长
        /// </summary>
        public double CubeEdges
        {
            get
            {
                return _CubeEdges;
            }
            set
            {
                _CubeEdges = value < 1 ? 1 : value;
            }
        }

        /// <summary>
        /// 中心X坐标
        /// </summary>
        public double CenterX
        {
            get
            {
                return _CenterX;
            }
            set
            {
                _CenterX = value;
            }
        }

        /// <summary>
        /// 中文Y坐标
        /// </summary>
        public double CenterY
        {
            get
            {
                return _CenterX;
            }
            set
            {
                _CenterX = value;
            }
        }

        /// <summary>
        /// 旋转速度
        /// </summary>
        public double CubeSpeed
        {
            get
            {
                return _CubeSpeed;
            }
            set
            {
                _CubeSpeed = value;
            }
        }

        public string CubeImage
        {
            get;
            set;
        }
        #endregion

        #region 魔方事件
        /// <summary>
        /// 加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Begin()
        {
            double t = _CubeEdges / -2;

            BitmapImage image = new BitmapImage(new Uri(CubeImage, UriKind.Relative));

            Image1.Width = CubeEdges;
            Image1.Height = CubeEdges;
            Image1.Source = image;
            Image1Projection.CenterOfRotationZ = t;

            Image2.Width = CubeEdges;
            Image2.Height = CubeEdges;
            Image2.Source = image;
            Image2Projection.CenterOfRotationZ = t;

            Image3.Width = CubeEdges;
            Image3.Height = CubeEdges;
            Image3.Source = image;
            Image3Projection.CenterOfRotationZ = t;

            Image4.Width = CubeEdges;
            Image4.Height = CubeEdges;
            Image4.Source = image;
            Image4Projection.CenterOfRotationZ = t;

            Grid5.Width = CubeEdges;
            Grid5.Height = CubeEdges;
            Image5.Source = image;
            Image5Projection.CenterOfRotationZ = t;

            Grid6.Width = CubeEdges;
            Grid6.Height = CubeEdges;
            Image6.Source = image;
            Image6Projection.CenterOfRotationZ = t;

            LayoutRoot.MouseMove += new MouseEventHandler(LayoutRoot_MouseMove);
            LayoutRoot.MouseEnter += new MouseEventHandler(LayoutRoot_MouseEnter);
            LayoutRoot.MouseLeave += new MouseEventHandler(LayoutRoot_MouseLeave);
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
        }

        /// <summary>
        /// 旋转事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            double y = _UserAction ? ((_UserPoint.X - CenterX) / Width) * CubeSpeed : _DefAngle;
            Image1Projection.RotationY += y;
            Image2Projection.RotationY += y;
            Image3Projection.RotationY += y;
            Image4Projection.RotationY += y;
            Image5Projection.RotationY += y;
            Image6Projection.RotationY += y;

            double x = _UserAction ? ((_UserPoint.Y - CenterY) / Height) * CubeSpeed : _DefAngle;
            Image1Projection.RotationX += x;
            Image2Projection.RotationX += x;
            Image3Projection.RotationX += x;
            Image4Projection.RotationX += x;
            //Image5Projection.RotationX += x;
            //Image6Projection.RotationX += x;
            Image5Rotation.Angle -= x;
            Image6Rotation.Angle += x;
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            _UserAction = true;
        }

        /// <summary>
        /// 鼠标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            _UserPoint = e.GetPosition(LayoutRoot);
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            _UserAction = false;
        }
        #endregion
    }
}

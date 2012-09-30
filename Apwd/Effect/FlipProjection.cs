using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Me.Amon.Apwd.Effect
{
    public class FlipProjection
    {
        #region 全局对象

        #region 来源对象
        /// <summary>
        /// 来源对象平移距离
        /// </summary>
        private double _OffsetZSrc;
        /// <summary>
        /// 
        /// </summary>
        private PlaneProjection _PlaneSrc;
        /// <summary>
        /// 
        /// </summary>
        private Storyboard _StorySrc;
        /// <summary>
        /// 来源对象是否移动中
        /// </summary>
        private bool _FlipingSrc;
        /// <summary>
        /// 来源对象翻转结束角度
        /// </summary>
        private int _EndAngleSrc;
        #endregion

        #region 目标对象
        /// <summary>
        /// 目标对象平衡距离
        /// </summary>
        private double _OffsetZDst;
        /// <summary>
        /// 
        /// </summary>
        private PlaneProjection _PlaneDst;
        /// <summary>
        /// 
        /// </summary>
        private Storyboard _StoryDst;
        /// <summary>
        /// 目标对象是否移动中
        /// </summary>
        private bool _FlipingDst;
        /// <summary>
        /// 目标对象翻转结束角度
        /// </summary>
        private int _EndAngleDst;
        #endregion

        #region 公共变量
        /// <summary>
        /// 用户设置翻转角度
        /// </summary>
        private int _FlipAngle;
        /// <summary>
        /// 用户设置翻转速度
        /// </summary>
        private int _FlipSpeed;
        /// <summary>
        /// 用户设置翻转方向
        /// </summary>
        private FlipDirection _Direction;
        #endregion

        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public FlipProjection()
        {
            _FlipAngle = 3;
            _FlipSpeed = 3;

            _StorySrc = new Storyboard();
            _StoryDst = new Storyboard();
            _StorySrc.Completed += new EventHandler(StorySrc_Completed);
            _StoryDst.Completed += new EventHandler(StoryDst_Completed);
        }
        #endregion

        #region
        public int FlipAngle
        {
            get
            {
                return _FlipAngle;
            }
            set
            {
                _FlipAngle = value < 1 ? 1 : value;
            }
        }

        public int FlipSpeed
        {
            get
            {
                return _FlipSpeed;
            }
            set
            {
                _FlipSpeed = value < 1 ? 1 : value;
            }
        }

        public bool IsFliping
        {
            get
            {
                return _FlipingDst && _FlipingSrc;
            }
        }
        #endregion

        #region 翻转控制
        /// <summary>
        /// 开始
        /// </summary>
        public void Begin()
        {
            //_FlipingSrc = true;
            //_FlipingDst = true;

            _StorySrc.Begin();
            _StoryDst.Begin();
        }

        /// <summary>
        /// 中断
        /// </summary>
        public void Pause()
        {
            _StorySrc.Pause();
            _StoryDst.Pause();
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Resume()
        {
            _StorySrc.Resume();
            _StoryDst.Resume();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            _StorySrc.Stop();
            _StoryDst.Stop();
        }
        #endregion

        #region 翻转参数
        /// <summary>
        /// 设置进入和离开对象
        /// </summary>
        /// <param name="flipSrc">转出对象</param>
        /// <param name="flipDst">转入对象</param>
        /// <param name="flipDir">翻转方向</param>
        public void FlipTo(Grid flipSrc, Grid flipDst, FlipDirection flipDir)
        {
            _PlaneSrc = new PlaneProjection();
            _PlaneDst = new PlaneProjection();

            flipSrc.Projection = _PlaneSrc;
            if (flipDst.Visibility != Visibility.Visible)
            {
                flipDst.Width = flipSrc.ActualWidth;
                flipDst.Height = flipSrc.ActualHeight;
                flipDst.Visibility = Visibility.Visible;
            }
            flipDst.Projection = _PlaneDst;

            if (flipDir == FlipDirection.Left || flipDir == FlipDirection.Right)
            {
                _OffsetZSrc = flipSrc.ActualWidth / 2;
                _OffsetZDst = flipDst.ActualWidth / 2;
            }
            else
            {
                _OffsetZSrc = flipSrc.ActualHeight / 2;
                _OffsetZDst = flipDst.ActualHeight / 2;
            }

            _Direction = flipDir;

            InitFlipData();
        }

        /// <summary>
        /// 设置进入和离开对象
        /// </summary>
        /// <param name="flipSrc">转出对象</param>
        /// <param name="flipDst">转入对象</param>
        /// <param name="flipDir">翻转方向</param>
        public void FlipTo(Control flipSrc, Control flipDst, FlipDirection flipDir)
        {
            _PlaneSrc = new PlaneProjection();
            _PlaneDst = new PlaneProjection();

            flipSrc.Projection = _PlaneSrc;
            if (flipDst.Visibility != Visibility.Visible)
            {
                flipDst.Width = flipSrc.ActualWidth;
                flipDst.Height = flipSrc.ActualHeight;
                flipDst.Visibility = Visibility.Visible;
            }
            flipDst.Projection = _PlaneDst;

            if (flipDir == FlipDirection.Left || flipDir == FlipDirection.Right)
            {
                _OffsetZSrc = flipSrc.ActualWidth / 2;
                _OffsetZDst = flipDst.ActualWidth / 2;
            }
            else
            {
                _OffsetZSrc = flipSrc.ActualHeight / 2;
                _OffsetZDst = flipDst.ActualHeight / 2;
            }

            _Direction = flipDir;

            InitFlipData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitFlipData()
        {
            //_PlaneDst.RotationX = 0;
            //_PlaneDst.RotationY = 0;
            //_PlaneDst.RotationZ = 0;
            //_PlaneDst.CenterOfRotationX = 0.5;
            //_PlaneDst.CenterOfRotationY = 0.5;
            //_PlaneDst.CenterOfRotationZ = 0;

            //_PlaneSrc.RotationX = 0;
            //_PlaneSrc.RotationY = 0;
            //_PlaneSrc.RotationZ = 0;
            //_PlaneSrc.CenterOfRotationX = 0.5;
            //_PlaneSrc.CenterOfRotationY = 0.5;
            //_PlaneSrc.CenterOfRotationZ = 0;

            _PlaneSrc.LocalOffsetZ = _OffsetZSrc;
            _PlaneSrc.GlobalOffsetZ = -_OffsetZSrc;

            _PlaneDst.LocalOffsetZ = _OffsetZDst;
            _PlaneDst.GlobalOffsetZ = -_OffsetZDst;
            switch (_Direction)
            {
                case FlipDirection.Left:
                    _PlaneSrc.RotationY = 0;
                    _EndAngleSrc = -90;

                    _PlaneDst.RotationY = 90;
                    _EndAngleDst = 0;
                    break;

                case FlipDirection.Right:
                    _PlaneSrc.RotationY = 0;
                    _EndAngleSrc = 90;

                    _PlaneDst.RotationY = -90;
                    _EndAngleDst = 0;
                    break;

                case FlipDirection.Up:
                    _PlaneSrc.RotationX = 0;
                    _EndAngleSrc = 90;

                    _PlaneDst.RotationX = -90;
                    _EndAngleDst = 0;
                    break;

                case FlipDirection.Down:
                    _PlaneSrc.RotationX = 0;
                    _EndAngleSrc = -90;

                    _PlaneDst.RotationX = 90;
                    _EndAngleDst = 0;
                    break;
            }

            _StorySrc.Duration = new Duration(TimeSpan.FromMilliseconds(_FlipSpeed));
            _StoryDst.Duration = new Duration(TimeSpan.FromMilliseconds(_FlipSpeed));
        }
        #endregion

        #region 翻转事件
        /// <summary>
        /// 离开对象的动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StorySrc_Completed(object sender, EventArgs e)
        {
            switch (_Direction)
            {
                case FlipDirection.Left:
                    _PlaneSrc.RotationY -= _FlipAngle;
                    _FlipingSrc = (_PlaneSrc.RotationY > _EndAngleSrc);
                    if (_FlipingSrc)
                    {
                        _StorySrc.Begin();
                    }
                    else
                    {
                        _PlaneSrc.RotationY = _EndAngleSrc;
                        _PlaneSrc.LocalOffsetZ = 0;
                        _PlaneSrc.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Right:
                    _PlaneSrc.RotationY += _FlipAngle;
                    _FlipingSrc = (_PlaneSrc.RotationY < _EndAngleSrc);
                    if (_FlipingSrc)
                    {
                        _StorySrc.Begin();
                    }
                    else
                    {
                        _PlaneSrc.RotationY = _EndAngleSrc;
                        _PlaneSrc.LocalOffsetZ = 0;
                        _PlaneSrc.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Up:
                    _PlaneSrc.RotationX += _FlipAngle;
                    _FlipingSrc = (_PlaneSrc.RotationX < _EndAngleSrc);
                    if (_FlipingSrc)
                    {
                        _StorySrc.Begin();
                    }
                    else
                    {
                        _PlaneSrc.RotationX = _EndAngleSrc;
                        _PlaneSrc.LocalOffsetZ = 0;
                        _PlaneSrc.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Down:
                    _PlaneSrc.RotationX -= _FlipAngle;
                    _FlipingSrc = (_PlaneSrc.RotationX > _EndAngleSrc);
                    if (_FlipingSrc)
                    {
                        _StorySrc.Begin();
                    }
                    else
                    {
                        _PlaneSrc.RotationX = _EndAngleSrc;
                        _PlaneSrc.LocalOffsetZ = 0;
                        _PlaneSrc.GlobalOffsetZ = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 进入对象的动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoryDst_Completed(object sender, EventArgs e)
        {
            switch (_Direction)
            {
                case FlipDirection.Left:
                    _PlaneDst.RotationY -= _FlipAngle;
                    _FlipingDst = (_PlaneDst.RotationY > _EndAngleDst);
                    if (_FlipingDst)
                    {
                        _StoryDst.Begin();
                    }
                    else
                    {
                        _PlaneDst.RotationY = _EndAngleDst;
                        _PlaneDst.LocalOffsetZ = 0;
                        _PlaneDst.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Right:
                    _PlaneDst.RotationY += _FlipAngle;
                    _FlipingDst = (_PlaneDst.RotationY < _EndAngleDst);
                    if (_FlipingDst)
                    {
                        _StoryDst.Begin();
                    }
                    else
                    {
                        _PlaneDst.RotationY = _EndAngleDst;
                        _PlaneDst.LocalOffsetZ = 0;
                        _PlaneDst.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Up:
                    _PlaneDst.RotationX += _FlipAngle;
                    _FlipingDst = (_PlaneDst.RotationX < _EndAngleDst);
                    if (_FlipingDst)
                    {
                        _StoryDst.Begin();
                    }
                    else
                    {
                        _PlaneDst.RotationX = _EndAngleDst;
                        _PlaneDst.LocalOffsetZ = 0;
                        _PlaneDst.GlobalOffsetZ = 0;
                    }
                    break;
                case FlipDirection.Down:
                    _PlaneDst.RotationX -= _FlipAngle;
                    _FlipingDst = (_PlaneDst.RotationX > _EndAngleDst);
                    if (_FlipingDst)
                    {
                        _StoryDst.Begin();
                    }
                    else
                    {
                        _PlaneDst.RotationX = _EndAngleDst;
                        _PlaneDst.LocalOffsetZ = 0;
                        _PlaneDst.GlobalOffsetZ = 0;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

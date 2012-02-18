using System.IO;
using System.Net;
using System.Windows.Controls;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Utils;

namespace Me.Amon.Win.Wiz
{
    public partial class Awiz : UserControl, IAttEdit
    {
        private Awin _Mpwd;
        private SafeModel _SafeModel;

        #region 显示页面
        private int _CurStep = -1;
        private const int STEP_INFO = 0;
        private const int STEP_HEAD = 1;
        private const int STEP_BODY = 2;
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public Awiz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mpwd"></param>
        /// <param name="safeModel"></param>
        public Awiz(Awin mpwd, SafeModel safeModel)
        {
            _Mpwd = mpwd;
            _SafeModel = safeModel;

            InitializeComponent();
        }
        #endregion

        #region IAttEdit 接口实现
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public void InitView(Grid grid)
        {
            grid.Children.Add(this);
            SetValue(Grid.RowProperty, 1);
            SetValue(Grid.ColumnProperty, 3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public void HideView(Grid grid)
        {
            grid.Children.Remove(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void ShowData(Key key)
        {
            if (key != null && CharUtil.isValidateHash(key.Id))
            {
                _Mpwd.Post("&o=att&m=0&d=" + key.Id, new UploadStringCompletedEventHandler(AttDownloadStringCompleted));
            }
            else
            {
                ShowInfo();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Append()
        {
            if (_SafeModel.Key == null)
            {
                _SafeModel.Key = new Key();
            }
            else
            {
                if (_SafeModel.Key.Modified)
                {
                    BeanUtil.ShowAlert("数据已修改，请保存！");
                    return;
                }
                _SafeModel.Key.SetDefault();
            }

            _SafeModel.Clear();
            _SafeModel.InitGuid();
            _SafeModel.InitMeta();
            _SafeModel.InitLogo();
            _SafeModel.InitHint();
            ShowHead();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catId"></param>
        public void Update()
        {
            if (_LastCmp == null || !_LastCmp.SaveData())
            {
                return;
            }

            _SafeModel.Encode();
            _Mpwd.Post("&o=att&m=3&d=" + _SafeModel.Key.ToXml(), new UploadStringCompletedEventHandler(UpdateDownloadStringCompleted));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete()
        {
        }

        public void CopyAtt()
        {
            if (_LastCmp != null)
            {
                _LastCmp.CopyData();
            }
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            _Mpwd.InitKey(e.Result);
            ShowInfo();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttDownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    BeanUtil.HideLoading();
                    reader.ReadToFollowing("error");
                    BeanUtil.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.ReadToFollowing("att"))
                {
                    _SafeModel.Decode(reader.ReadElementContentAsString());
                }
            }

            ShowHead();
            BeanUtil.HideLoading();
        }

        #region 信息提示
        private InfoCmp _InfoCmp;
        /// <summary>
        /// 
        /// </summary>
        public void ShowInfo()
        {
            if (_InfoCmp == null)
            {
                _InfoCmp = new InfoCmp(this, _SafeModel);
            }

            if (_CurStep != STEP_INFO)
            {
                if (_LastCmp != null)
                {
                    _LastCmp.HideView(null);
                }
                _InfoCmp.InitView(null);
                SvCardCtl.Content = _InfoCmp;
                _LastCmp = _InfoCmp;

                _CurStep = STEP_INFO;
            }
            _InfoCmp.ShowData();
            PrevBtn.Visibility = System.Windows.Visibility.Collapsed;
            NextBtn.Visibility = System.Windows.Visibility.Collapsed;
            CopyBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        private HeadCmp _HeadCmp;
        /// <summary>
        /// 
        /// </summary>
        public void ShowHead()
        {
            if (_HeadCmp == null)
            {
                _HeadCmp = new HeadCmp(this, _SafeModel);
            }

            if (_CurStep != STEP_HEAD)
            {
                if (_LastCmp != null)
                {
                    _LastCmp.HideView(null);
                }
                _HeadCmp.InitView(null);
                SvCardCtl.Content = _HeadCmp;
                _LastCmp = _HeadCmp;

                _CurStep = STEP_HEAD;
            }
            _HeadCmp.ShowData();
            PrevBtn.Visibility = System.Windows.Visibility.Collapsed;
            NextBtn.Visibility = System.Windows.Visibility.Visible;
            CopyBtn.Visibility = System.Windows.Visibility.Visible;
        }

        private BodyCmp _BodyCmp;
        /// <summary>
        /// 
        /// </summary>
        public void ShowBody()
        {
            if (_BodyCmp == null)
            {
                _BodyCmp = new BodyCmp(this, _SafeModel);
            }

            if (_CurStep != STEP_BODY)
            {
                if (_LastCmp != null)
                {
                    _LastCmp.HideView(null);
                }
                _BodyCmp.InitView(null);
                SvCardCtl.Content = _BodyCmp;
                _LastCmp = _BodyCmp;

                _CurStep = STEP_BODY;
            }
            _BodyCmp.ShowData();
            PrevBtn.Visibility = System.Windows.Visibility.Visible;
            NextBtn.Visibility = System.Windows.Visibility.Collapsed;
            CopyBtn.Visibility = System.Windows.Visibility.Visible;
        }
        private ICardCtl _LastCmp;
        #endregion

        #region 按钮事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CopyAtt();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_LastCmp == null || !_LastCmp.SaveData())
            {
                return;
            }

            if (_CurStep == STEP_HEAD)
            {
                ShowBody();
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_LastCmp == null || !_LastCmp.SaveData())
            {
                return;
            }

            if (_CurStep == STEP_BODY)
            {
                ShowHead();
                return;
            }
        }
        #endregion
    }
}

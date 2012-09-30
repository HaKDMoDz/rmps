using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Controls;
using System.Xml;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Win.Pro
{
    public partial class Apro : UserControl, IAttEdit
    {
        private Awin _Mpwd;
        private SafeModel _SafeModel;

        #region 构造函数
        public Apro()
            : this(null, null)
        {
        }

        public Apro(Awin mpwd, SafeModel safeModel)
        {
            _Mpwd = mpwd;
            _SafeModel = safeModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
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
        /// 新增
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
            _SafeModel.InitGuid(AttGrid);
            AttGrid.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (_SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            _SafeModel.Encode(AttGrid);
            _Mpwd.Post("&o=att&m=3&d=" + _SafeModel.Key.ToXml(), new UploadStringCompletedEventHandler(UpdateDownloadStringCompleted));
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            BeanUtil.ShowAlert("暂不支持删除操作！");
        }

        public void CopyAtt()
        {
            if (_CmpLast != null)
            {
                _CmpLast.Copy();
            }
        }

        public void SaveAtt()
        {
            if (_CmpLast != null)
            {
                _CmpLast.Save();
            }
        }

        public void DropAtt()
        {
            if (_CmpLast != null)
            {
                _CmpLast.Drop();
            }
        }

        private void UpdateDownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            _Mpwd.InitKey(e.Result);
            ShowInfo();
        }
        #endregion

        #region 属性
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
                    _SafeModel.Decode(reader.ReadElementContentAsString(), AttGrid);
                }
            }

            BeanUtil.HideLoading();
        }

        /// <summary>
        /// 属性选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AttGrid.SelectedIndex < 0)
            {
                return;
            }
            _CmpLast = ShowEdit(_SafeModel.GetAtt(AttGrid.SelectedIndex));
        }

        public void SelectPrev()
        {
            _SafeModel.ReBind(AttGrid, -1);
        }

        public void SelectNext()
        {
            _SafeModel.ReBind(AttGrid, 1);
        }
        #endregion

        #region 界面切换
        /// <summary>
        /// 显示提示
        /// </summary>
        public void ShowInfo()
        {
            if (_InfoCmp == null)
            {
                _InfoCmp = new InfoCmp(this, _SafeModel);
                _CmpList[Att.TYPE_INFO] = _InfoCmp;
            }

            _InfoCmp.InitView(AttEdit);
            _InfoCmp.ShowData(null);
        }
        private InfoCmp _InfoCmp;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="attType"></param>
        public IPropCmp ShowEdit(Att att)
        {
            int attType = att.Type;
            IPropCmp propCmp;
            if (!_CmpList.ContainsKey(attType))
            {
                switch (attType)
                {
                    case Att.TYPE_GUID:
                        propCmp = new GuidCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_META:
                        propCmp = new MetaCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_LOGO:
                        propCmp = new LogoCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_HINT:
                        propCmp = new HintCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_TEXT:
                        propCmp = new TextCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_PASS:
                        propCmp = new PassCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_LINK:
                        propCmp = new LinkCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_MAIL:
                        propCmp = new MailCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_DATE:
                        propCmp = new DateCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_AREA:
                        propCmp = new AreaCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_FILE:
                        propCmp = new FileCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_DATA:
                        propCmp = new DataCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_LIST:
                        propCmp = new ListCmp(this, _SafeModel);
                        break;
                    case Att.TYPE_SIGN:
                        propCmp = new SignCmp(this, _SafeModel);
                        break;
                    default:
                        propCmp = new InfoCmp();
                        break;
                }
                _CmpList[attType] = propCmp;
            }
            else
            {
                propCmp = _CmpList[attType];
            }

            propCmp.InitView(AttEdit);
            propCmp.ShowData(att);

            return propCmp;
        }
        private Dictionary<int, IPropCmp> _CmpList = new Dictionary<int, IPropCmp>(12);
        private IPropCmp _CmpLast;
        #endregion
    }
}

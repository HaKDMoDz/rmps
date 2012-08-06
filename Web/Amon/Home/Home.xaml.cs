using System.Windows;
using System.Windows.Controls;
using Me.Amon.Views.User;

namespace Me.Amon.Home
{
    public partial class Home : UserControl, IView
    {
        private MainPage _Main;

        #region 构造函数
        public Home()
        {
            InitializeComponent();
        }

        public Home(MainPage main)
        {
            _Main = main;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public string ViewName
        {
            get
            {
                return "Home";
            }
        }

        public bool InitView(MainPage main)
        {
            _Main = main;
            _Main.Show(this);
            return true;
        }

        public void InitData()
        {
            //            HomeTxt.Text = @"　　魔方密码是一款开放源代码的跨平台密码管理软件，其主要目标是在充分保障用户数据安全的基础上，做到同一数据能够方便的在多种操作平台上使用。软件采用目前国际上通用的标准商用加密算法保证您的数据机密性，支持用户自定义数据、支持随机密码生成、支持基于云存储的数据备份与恢复、支持邮件检测及记事提醒等功能。
            //
            //　　1、完全跨平台运行；
            //　　2、实行代码开源机制，用户可以免费使用及传播；
            //　　3、采用SHA-512算法进行身份认证，及AES算法进行数据加密；
            //　　4、采用系统操作日志、退出备份、用户手动本地及远程备份机制，充分保障用户数据安全；
            //　　5、用户完全自定义密码类别及模板，可根据需要添加或删除属性，且不限属性个数及数据长度；
            //　　6、支持邮件检测及记事提醒等功能。";

            CubeCmp.CubeEdges = 160;
            CubeCmp.CenterX = 130;
            CubeCmp.CenterY = 130;
            CubeCmp.CubeImage = "/img/cube.png";
            CubeCmp.Begin();
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn view = new SignIn();
            view.InitView(_Main);
            view.InitData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp view = new SignUp();
            view.InitView(_Main);
            view.InitData();
        }
        #endregion
    }
}

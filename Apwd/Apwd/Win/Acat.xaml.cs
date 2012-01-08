using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Views.Bean;

namespace Me.Amon.Apwd.Win
{
    public partial class Acat : ChildWindow
    {
        private TreeViewItem _CatRoot;

        public Acat()
        {
            InitializeComponent();
        }

        public void Init(List<Cat> list)
        {
            _CatRoot = new TreeViewItem();
            _CatRoot.Header = new CatItem { Cat = new Cat { Id = "130f0000magicpwd", Text = "魔方密码", Icon = "130f0000magicpwd" } };
            CatTree.Items.Add(_CatRoot);

            CatTree.Items.Add(_CatRoot);

            InitCat(null, "0", list);
        }

        /// <summary>
        /// 添加节点到目录
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="root"></param>
        private void InitCat(TreeViewItem root, string pKey, List<Cat> list)
        {
            foreach (Cat cat in list)
            {
                if (cat.Parent != pKey)
                {
                    continue;
                }

                TreeViewItem node = new TreeViewItem();
                node.Header = new CatItem { Cat = cat };

                root.Items.Add(node);
                InitCat(node, cat.Id, list);
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}


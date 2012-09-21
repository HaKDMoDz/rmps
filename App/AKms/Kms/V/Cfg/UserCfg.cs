using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Kms.V.Cfg
{
    public partial class UserCfg : Form
    {
        private Dictionary<string, IConfig> _itemList;
        public UserCfg()
        {
            InitializeComponent();
        }

        private void UserOpt_Load(object sender, EventArgs e)
        {
            _itemList = new Dictionary<string, IConfig>();

            LsItem.Items.Add(new Items { K = "system", V = "系统配置" });
            LsItem.Items.Add(new Items { K = "taglist", V = "标签管理" });
            LsItem.Items.Add(new Items { K = "about", V = "关于软件" });

            LsItem.SelectedIndex = 0;
        }

        private void LsItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = LsItem.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            ShowConfig(item);
        }

        private void ShowConfig(Items item)
        {
            if (!_itemList.ContainsKey(item.K))
            {
                switch (item.K)
                {
                    case "system":
                        var robot = new Robot();
                        robot.Init();
                        _itemList[item.K] = robot;
                        break;
                    case "taglist":
                        var tagList = new TagList();
                        tagList.Init();
                        _itemList[item.K] = tagList;
                        break;
                    case "about":
                        var about = new About();
                        about.Init();
                        _itemList[item.K] = about;
                        break;
                    default:
                        return;
                }
            }

            UserControl uc = _itemList[item.K].UserControl;
            uc.Location = new System.Drawing.Point(6, 20);
            uc.Name = "Config";
            uc.Size = new System.Drawing.Size(225, 187);
            uc.TabIndex = 0;
            GbItem.Controls.Clear();
            GbItem.Controls.Add(_itemList[item.K].UserControl);
            GbItem.Text = item.V;
        }

        private void BtSaveAll_Click(object sender, EventArgs e)
        {
            IConfig cfg;
            foreach (Items item in LsItem.Items)
            {
                cfg = _itemList.ContainsKey(item.K) ? _itemList[item.K] : null;
                if (cfg == null)
                {
                    continue;
                }
                if (!cfg.Save())
                {
                    break;
                }
            }
        }

        private void BtSaveCur_Click(object sender, EventArgs e)
        {
            var item = LsItem.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            IConfig cfg = _itemList.ContainsKey(item.K) ? _itemList[item.K] : null;
            if (cfg == null)
            {
                return;
            }
            cfg.Save();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

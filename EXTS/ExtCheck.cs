using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using com.amonsoft.exts.exts0001;

namespace com.amonsoft.exts
{
    public partial class FM_ExtCheck : Form
    {
        /// <summary>
        /// 是否正在后缀数据检测中
        /// </summary>
        private bool isInFind;

        /// <summary>
        /// 是否正在后缀数据上传中
        /// </summary>
        private bool isInSave;

        public FM_ExtCheck()
        {
            InitializeComponent();
            BT_SaveExts.Enabled = true;
        }

        /// <summary>
        /// 后缀检测按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_FindExts_Click(object sender, EventArgs e)
        {
            // 上传过程中
            if (isInSave)
            {
                MessageBox.Show(this, "后缀数据正在上传中，请稍后！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 取消检测事件
            if (isInFind)
            {
                isInFind = false;
                return;
            }

            // 清除已有结果数据
            if (LV_ExtsList.Items.Count > 0)
            {
                LV_ExtsList.Items.Clear();
            }

            // 进行数据检测
            isInFind = true;
            BT_FindExts.Text = "取消(&C)";
            BT_SaveExts.Enabled = false;
            new Thread(FindExts).Start();
        }

        /// <summary>
        /// 后缀上传按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_SaveExts_Click(object sender, EventArgs e)
        {
            // 检测过程中
            if (isInFind)
            {
                MessageBox.Show(this, "后缀数据正在检测中，请稍后！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 取消上传事件
            if (isInSave)
            {
                isInSave = false;
                return;
            }

            // 判断已有结果数据
            if (LV_ExtsList.Items.Count < 1)
            {
                return;
            }

            // 进行数据上传
            isInSave = true;
            BT_SaveExts.Text = "取消(&C)";
            BT_FindExts.Enabled = false;
            new Thread(SaveExts).Start(LV_ExtsList.Items);
        }

        /// <summary>
        /// 后缀数据检测
        /// </summary>
        /// <returns></returns>
        private void FindExts()
        {
            int size = 0;

            // HKEY_CLASSES_ROOT
            RegistryKey key1 = Registry.ClassesRoot;
            foreach (String key in key1.GetSubKeyNames())
            {
                // 退出查找
                if (!isInFind)
                {
                    break;
                }

                // 键为空
                if (String.IsNullOrEmpty(key) || key == "*" || (key[0] != '.'))
                {
                    continue;
                }

                // 显示检测信息
                LB_ExtsInfo.BeginInvoke(new EventHandler(ShowInfo), "正在检测后缀 " + key);

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
                // 图标路径
                String file = "";
                String temp = (String)key2.GetValue("");
                if (!String.IsNullOrEmpty(temp))
                {
                    key2 = key1.OpenSubKey(temp);
                    if (key2 != null)
                    {
                        desp = ((String)key2.GetValue("") ?? "").Trim(' ', '.', '。');
                        if (!String.IsNullOrEmpty(desp))
                        {
                            desp += '。';
                        }
                        key2 = key2.OpenSubKey("DefaultIcon");
                        if (key2 != null)
                        {
                            file = (String)key2.GetValue("");
                        }
                    }
                }

                Image icon = null;
                // 检测后缀是否存在
                temp = exts;
                if (NeedExts(temp, mime))
                {
                    // 显示图标
                    ReadIcon(file, out icon);
                    IL_ExtsList.Images.Add(icon);

                    // 显示内容
                    LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                    desp = "参见：" + exts;
                    size += 1;
                }
                // 大写
                temp = exts.ToUpper();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        // 显示图标
                        if (icon == null)
                        {
                            ReadIcon(file, out icon);
                        }
                        IL_ExtsList.Images.Add(icon);

                        // 显示内容
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                        desp = "参见：" + exts;
                        size += 1;
                    }
                }
                // 小写
                temp = exts.ToLower();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        // 显示图标
                        if (icon == null)
                        {
                            ReadIcon(file, out icon);
                        }
                        IL_ExtsList.Images.Add(icon);

                        // 显示内容
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                        size += 1;
                    }
                }
            }

            // 显示处理结果
            LB_ExtsInfo.BeginInvoke(new EventHandler(ViewFind), String.Format("共检测到 {0} 个数据！", size));
        }
        /// <summary>
        /// 检测对应的后缀数据是否存在
        /// </summary>
        /// <param name="exts"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        private static bool NeedExts(string exts, string mime)
        {
            XmlDocument xml = new XmlDocument();
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
        /// 后缀数据上传
        /// </summary>
        /// <returns></returns>
        private void SaveExts(Object obj)
        {
            const string user = "user";
            const string pwds = "5p39mfkCZQ6oKtK9fQfHtIaxydVdz7JU";

            int size = 0;
            if (obj != null)
            {
                ListView.ListViewItemCollection items = (ListView.ListViewItemCollection)obj;
                Exts0001SoapClient inet = new Exts0001SoapClient();

                Image icon;
                foreach (ListViewItem item in items)
                {
                    if (!isInSave)
                    {
                        break;
                    }

                    // 显示上传信息
                    LB_ExtsInfo.BeginInvoke(new EventHandler(ShowInfo), "正在上传后缀 " + item.SubItems[0].Text);

                    // 上传后缀数据
                    if (inet.exts(user, pwds, item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[3].Text, ReadByte(ReadIcon(item.SubItems[2].Text, out icon))))
                    {
                        size += 1;
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowSave), item);
                    }
                }
            }

            // 显示处理结果
            LB_ExtsInfo.BeginInvoke(new EventHandler(ViewSave), String.Format("共上传了 {0} 个数据！", size));
        }

        /// <summary>
        /// 显示处理信息
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ShowInfo(object o, EventArgs e)
        {
            if (o is string)
            {
                LB_ExtsInfo.Text = (string)o;
            }
        }

        /// <summary>
        /// 显示检测过程
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ShowFind(object o, EventArgs e)
        {
            if (o is ListViewItem)
            {
                LV_ExtsList.Items.Add((ListViewItem)o);
                LB_ExtsInfo.Text = String.Format("已检测到 {0} 个不同数据！", LV_ExtsList.Items.Count);
            }
        }

        /// <summary>
        /// 显示检测结果
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ViewFind(object o, EventArgs e)
        {
            isInFind = false;
            LB_ExtsInfo.Text = o + "";
            BT_FindExts.Text = "检测(&F)";
            BT_SaveExts.Enabled = LV_ExtsList.Items.Count > 0;
        }

        /// <summary>
        /// 显示上传过程
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ShowSave(object o, EventArgs e)
        {
            if (o is ListViewItem)
            {
                LV_ExtsList.Items.Remove((ListViewItem)o);
            }
        }

        /// <summary>
        /// 显示上传结果
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ViewSave(object o, EventArgs e)
        {
            isInSave = false;
            LB_ExtsInfo.Text = o + "";
            BT_SaveExts.Text = "上传(&U)";
            BT_FindExts.Enabled = true;
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
        /// <param name="icon"></param>
        /// <returns></returns>
        private static Image[] ReadIcon(String path, out Image icon)
        {
            icon = Properties.Resources.None;

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
                IconImage ico;
                while (j > 0)
                {
                    ico = si[--j];
                    if (ico.PixelFormat < lpf)
                    {
                        continue;
                    }
                    if (ico.PixelFormat > lpf)
                    {
                        img.Clear();
                        lpf = ico.PixelFormat;
                    }
                    Bitmap bmp = ico.Icon.ToBitmap();
                    img.Add(bmp);
                    if (bmp.Width == 16)
                    {
                        icon = bmp;
                    }
                }
                return img.ToArray();
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        private void LV_ExtsList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (LV_ExtsList.SelectedItems != null)
                {
                    ListView.SelectedListViewItemCollection lv = LV_ExtsList.SelectedItems;
                    if (lv.Count > 0)
                    {
                        ListViewItem li = lv[0];
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < li.SubItems.Count; i += 1)
                        {
                            sb.Append(li.SubItems[i].Text).Append('\t');
                        }
                        Clipboard.SetDataObject(sb.ToString());
                    }
                }
            }
        }
    }
}
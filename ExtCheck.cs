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
        /// �Ƿ����ں�׺���ݼ����
        /// </summary>
        private bool isInFind;

        /// <summary>
        /// �Ƿ����ں�׺�����ϴ���
        /// </summary>
        private bool isInSave;

        public FM_ExtCheck()
        {
            InitializeComponent();
            BT_SaveExts.Enabled = true;
        }

        /// <summary>
        /// ��׺��ⰴť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_FindExts_Click(object sender, EventArgs e)
        {
            // �ϴ�������
            if (isInSave)
            {
                MessageBox.Show(this, "��׺���������ϴ��У����Ժ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ȡ������¼�
            if (isInFind)
            {
                isInFind = false;
                return;
            }

            // ������н������
            if (LV_ExtsList.Items.Count > 0)
            {
                LV_ExtsList.Items.Clear();
            }

            // �������ݼ��
            isInFind = true;
            BT_FindExts.Text = "ȡ��(&C)";
            BT_SaveExts.Enabled = false;
            new Thread(FindExts).Start();
        }

        /// <summary>
        /// ��׺�ϴ���ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_SaveExts_Click(object sender, EventArgs e)
        {
            // ��������
            if (isInFind)
            {
                MessageBox.Show(this, "��׺�������ڼ���У����Ժ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ȡ���ϴ��¼�
            if (isInSave)
            {
                isInSave = false;
                return;
            }

            // �ж����н������
            if (LV_ExtsList.Items.Count < 1)
            {
                return;
            }

            // ���������ϴ�
            isInSave = true;
            BT_SaveExts.Text = "ȡ��(&C)";
            BT_FindExts.Enabled = false;
            new Thread(SaveExts).Start(LV_ExtsList.Items);
        }

        /// <summary>
        /// ��׺���ݼ��
        /// </summary>
        /// <returns></returns>
        private void FindExts()
        {
            int size = 0;

            // HKEY_CLASSES_ROOT
            RegistryKey key1 = Registry.ClassesRoot;
            foreach (String key in key1.GetSubKeyNames())
            {
                // �˳�����
                if (!isInFind)
                {
                    break;
                }

                // ��Ϊ��
                if (String.IsNullOrEmpty(key) || key == "*" || (key[0] != '.'))
                {
                    continue;
                }

                // ��ʾ�����Ϣ
                LB_ExtsInfo.BeginInvoke(new EventHandler(ShowInfo), "���ڼ���׺ " + key);

                // ��ǰ��׺��ֵ
                RegistryKey key2 = key1.OpenSubKey(key);
                if (key2 == null)
                {
                    continue;
                }

                // ��׺����
                String exts = key;
                // MIME����
                String mime = ((String)key2.GetValue("Content Type") ?? "").ToLower();
                // ��׺����
                String desp = "";
                // ͼ��·��
                String file = "";
                String temp = (String)key2.GetValue("");
                if (!String.IsNullOrEmpty(temp))
                {
                    key2 = key1.OpenSubKey(temp);
                    if (key2 != null)
                    {
                        desp = ((String)key2.GetValue("") ?? "").Trim(' ', '.', '��');
                        if (!String.IsNullOrEmpty(desp))
                        {
                            desp += '��';
                        }
                        key2 = key2.OpenSubKey("DefaultIcon");
                        if (key2 != null)
                        {
                            file = (String)key2.GetValue("");
                        }
                    }
                }

                Image icon = null;
                // ����׺�Ƿ����
                temp = exts;
                if (NeedExts(temp, mime))
                {
                    // ��ʾͼ��
                    ReadIcon(file, out icon);
                    IL_ExtsList.Images.Add(icon);

                    // ��ʾ����
                    LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                    desp = "�μ���" + exts;
                    size += 1;
                }
                // ��д
                temp = exts.ToUpper();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        // ��ʾͼ��
                        if (icon == null)
                        {
                            ReadIcon(file, out icon);
                        }
                        IL_ExtsList.Images.Add(icon);

                        // ��ʾ����
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                        desp = "�μ���" + exts;
                        size += 1;
                    }
                }
                // Сд
                temp = exts.ToLower();
                if (exts != temp)
                {
                    if (NeedExts(temp, mime))
                    {
                        // ��ʾͼ��
                        if (icon == null)
                        {
                            ReadIcon(file, out icon);
                        }
                        IL_ExtsList.Images.Add(icon);

                        // ��ʾ����
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowFind), new ListViewItem(new string[] { temp, mime, file, desp }, size));
                        size += 1;
                    }
                }
            }

            // ��ʾ������
            LB_ExtsInfo.BeginInvoke(new EventHandler(ViewFind), String.Format("����⵽ {0} �����ݣ�", size));
        }
        /// <summary>
        /// ����Ӧ�ĺ�׺�����Ƿ����
        /// </summary>
        /// <param name="exts"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        private static bool NeedExts(string exts, string mime)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Cons.WEB_SITE + "/exts/exts0001.ashx?type=list&exts=" + exts);
            XmlNodeList list1 = xml.SelectNodes("/P3010000/exts");
            // �Ҳ�����Ӧ�����ݣ������
            if (list1 == null || list1.Count < 1)
            {
                return true;
            }
            // MIME����Ϊ�գ�����Ҫ���
            if (String.IsNullOrEmpty(mime))
            {
                return false;
            }

            // ѭ������ÿһ����׺��MIME��Ϣ
            foreach (XmlNode node1 in list1)
            {
                XmlNodeList list2 = node1.SelectNodes("mime/list/item");
                // ��ǰ��׺û��MIME��Ϣ���������һ����׺
                if (list2 == null || list2.Count < 1)
                {
                    continue;
                }

                // ѭ���Ƚ�ÿһ��MIME��Ϣ
                foreach (XmlNode node2 in list2)
                {
                    XmlAttribute tmp = node2.Attributes["name"];
                    if (tmp == null)
                    {
                        continue;
                    }

                    // ��������ͬ��MIME��Ϣ�����ʾ��Ӧ�������Ѵ���
                    if ((tmp.Value ?? "").ToLower() == mime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��׺�����ϴ�
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

                    // ��ʾ�ϴ���Ϣ
                    LB_ExtsInfo.BeginInvoke(new EventHandler(ShowInfo), "�����ϴ���׺ " + item.SubItems[0].Text);

                    // �ϴ���׺����
                    if (inet.exts(user, pwds, item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[3].Text, ReadByte(ReadIcon(item.SubItems[2].Text, out icon))))
                    {
                        size += 1;
                        LV_ExtsList.BeginInvoke(new EventHandler(ShowSave), item);
                    }
                }
            }

            // ��ʾ������
            LB_ExtsInfo.BeginInvoke(new EventHandler(ViewSave), String.Format("���ϴ��� {0} �����ݣ�", size));
        }

        /// <summary>
        /// ��ʾ������Ϣ
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
        /// ��ʾ������
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ShowFind(object o, EventArgs e)
        {
            if (o is ListViewItem)
            {
                LV_ExtsList.Items.Add((ListViewItem)o);
                LB_ExtsInfo.Text = String.Format("�Ѽ�⵽ {0} ����ͬ���ݣ�", LV_ExtsList.Items.Count);
            }
        }

        /// <summary>
        /// ��ʾ�����
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ViewFind(object o, EventArgs e)
        {
            isInFind = false;
            LB_ExtsInfo.Text = o + "";
            BT_FindExts.Text = "���(&F)";
            BT_SaveExts.Enabled = LV_ExtsList.Items.Count > 0;
        }

        /// <summary>
        /// ��ʾ�ϴ�����
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
        /// ��ʾ�ϴ����
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ViewSave(object o, EventArgs e)
        {
            isInSave = false;
            LB_ExtsInfo.Text = o + "";
            BT_SaveExts.Text = "�ϴ�(&U)";
            BT_FindExts.Enabled = true;
        }

        /// <summary>
        /// ���л�ͼ��
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
        /// ��ȡͼ����Ϣ
        /// </summary>
        /// <param name="path"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        private static Image[] ReadIcon(String path, out Image icon)
        {
            icon = Properties.Resources.None;

            // ����Ϊ���ж�
            if (String.IsNullOrEmpty(path))
            {
                return null;
            }
            // ȡͼ���ļ�·��
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
            // �ж�ͼ���ļ��Ƿ����
            if (!File.Exists(path))
            {
                return null;
            }
            // ȡ���ʵ�ͼ��
            if (i < 0)
            {
                i = 0;
            }

            try
            {
                // ��ȡͼ����Ϣ
                MultiIcon mi = new MultiIcon();
                mi.Load(path);
                if (i >= mi.Count)
                {
                    i = 0;
                }
                SingleIcon si = mi[i];

                // ȡ��������ߵ�ͼ��
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
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Bms.Chrome;
using Me.Amon.Util;
using Newtonsoft.Json;

namespace Me.Amon.Bms
{
    public partial class WBms : Form
    {
        private HashAlgorithm md5;
        private StringBuilder Buffer;

        public WBms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            md5 = HashAlgorithm.Create("MD5");
            Buffer = new StringBuilder();

            var file = @"C:\Users\Aven\AppData\Local\Google\Chrome\User Data\Default\Bookmarks";
            var text = File.ReadAllText(file);
            Chrome.ChromeObj chrome = JsonConvert.DeserializeObject<Chrome.ChromeObj>(text);
            var roots = chrome.roots;
            var bar = roots.bookmark_bar;
            var root = new TreeNode();
            treeView1.Nodes.Add(root);
            foreach (var res in bar.children)
            {
                Digest(res);

                if (res.type == "folder")
                {
                    var node = new TreeNode();
                    node.Text = res.name;
                    root.Nodes.Add(node);
                    ListChildren(res, node);
                }
                if (res.type == "url")
                {
                    var node = new TreeNode();
                    node.Text = res.name;
                    root.Nodes.Add(node);
                    continue;
                }
            }

            byte[] buf = Encoding.UTF8.GetBytes(Buffer.ToString());
            buf = md5.ComputeHash(buf);
            var t = CharUtil.EncodeString(buf);
            MessageBox.Show(t);
        }

        private void ListChildren(ChromeItem folder, TreeNode root)
        {
            if (folder == null)
            {
                return;
            }
            foreach (var res in folder.children)
            {
                Digest(res);

                if (res.type == "folder")
                {
                    var node = new TreeNode();
                    node.Text = res.name;
                    root.Nodes.Add(node);
                    ListChildren(res, node);
                    continue;
                }
                if (res.type == "url")
                {
                    var node = new TreeNode();
                    node.Text = res.name;
                    root.Nodes.Add(node);
                    continue;
                }
            }
        }

        private void Digest(ChromeItem item)
        {
            Buffer.Append(item.date_added).Append(item.id).Append(item.name).Append(item.type).Append(item.url);
        }
    }
}

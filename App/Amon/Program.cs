using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("Skin"))
            {
                BeanUtil.UnZip("Amon.res", ".\\");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            //Application.Run(new Gtd.V.GtdEditor());
        }
    }
}

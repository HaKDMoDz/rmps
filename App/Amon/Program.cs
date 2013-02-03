using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            //Application.Run(new Bms.WBms());
            //Application.Run(new Gtd.V.GtdEditor());
            //Application.Run(new Demo());
            //Application.Run(new WSpy());
        }
    }
}

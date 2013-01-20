namespace Me.Amon.Pwd.V.Wiz
{
    public interface IKeyEditer
    {
        string Name { get; set; }

        /// <summary>
        /// 显示组件
        /// </summary>
        /// <param name="panel"></param>
        void InitView(System.Windows.Forms.Panel panel);

        /// <summary>
        /// 隐藏组件
        /// </summary>
        /// <param name="panel"></param>
        void HideView(System.Windows.Forms.Panel panel);

        bool Focus();

        void ShowData();

        bool SaveData();

        void CutData();

        void CopyData(CopyType type);

        void PasteData();

        void ClearData();
    }
}

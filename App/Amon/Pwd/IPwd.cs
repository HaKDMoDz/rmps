using System.Windows.Forms;

namespace Me.Amon.Pwd
{
    public interface IPwd
    {
        string Model { get; }

        #region 界面控制
        void InitView(Panel panel);

        void HideView(Panel panel);

        bool Focus();
        #endregion

        void ShowKey();

        #region 记录操作
        void AppendKey();

        bool UpdateKey();

        void DeleteKey();
        #endregion

        #region 属性操作
        void AppendAtt(int type);

        void ChangeAtt(int type);

        void SelectPrevAtt();

        void SelectNextAtt();

        void MoveUpSelectedAtt();

        void MoveDownSelectedAtt();

        void CutAtt();

        void CopyAtt(CopyType type);

        void PasteAtt();

        void ClearAtt();

        void SaveAtt();

        void DropAtt();
        #endregion
    }
}

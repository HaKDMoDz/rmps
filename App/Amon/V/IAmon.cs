using System.Collections.Generic;

namespace Me.Amon
{
    public interface IAmon
    {
        void InitData();

        void LoadMenu(List<TApp> apps);

        void SaveView();

        void DeInit();

        bool WillExit();

        void Close();

        //void ChangeEmotion(int i);

        //void ChangeAppVisible(bool b);

        void ShowBubbleTips(string tips);

        void ShowFlicker();

        void HideFlicker();
    }
}

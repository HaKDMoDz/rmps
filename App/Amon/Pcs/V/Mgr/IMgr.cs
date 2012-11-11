using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Mgr
{
    public interface IMgr
    {
        string Name { get; }

        void ShowData(MPcs mPcs);

        bool SaveData(MPcs mPcs);
    }
}

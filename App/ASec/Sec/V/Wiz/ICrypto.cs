using Me.Amon.Sec.M;
namespace Me.Amon.Sec.V.Wiz
{
    interface ICrypto
    {
        void Init(MSec msec);

        bool IsText { get; set; }

        bool DoCrypto(string pass);
    }
}


namespace Me.Amon.Sec.V.Wiz
{
    class Acrypto : ICrypto
    {
        public void Init(M.MSec msec)
        {
        }

        public bool IsText
        {
            get;
            set;
        }

        public bool DoCrypto(string pass)
        {
            return true;
        }
    }
}

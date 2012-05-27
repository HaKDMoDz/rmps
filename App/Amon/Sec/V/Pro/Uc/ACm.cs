using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc
{
    public abstract class ACm
    {
        public static Item _NameDef = new Item { K = "0", V = "请选择" };
        public static Item _ModeDef = new Item { K = "0", V = "默认" };
        public static Item _SizeDef = new Item { K = "0", V = "默认" };
        protected int _KeySize;
        protected int _IVSize;
        protected APro _APro;
        protected Cm _Cm;

        public ACm(APro apro, Cm cm)
        {
            _APro = apro;
            _Cm = cm;
        }

        public abstract void InitOpt();

        public abstract void InitKey(string key);

        public abstract void ChangeName(string name);

        public abstract void ChangeMode(string mode);

        public abstract void ChangePads(string pads);

        public int KeySize { get { return _KeySize; } }
        public int IVSize { get { return _IVSize; } }
    }
}
using Me.Amon.Uc;

namespace Me.Amon.Sec.Pro.Uc
{
    public abstract class ACm
    {
        public static Item _NameDef = new Item { K = "0", V = "请选择" };
        public static Item _ModeDef = new Item { K = "0", V = "默认" };
        public static Item _SizeDef = new Item { K = "0", V = "默认" };
        protected int _KeySize;
        protected int _IVSize;
        protected ASec _ASec;
        protected Cm _Cm;

        public ACm(ASec asec, Cm cm)
        {
            _ASec = asec;
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
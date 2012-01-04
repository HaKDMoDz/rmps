namespace Msec
{
    public interface IView
    {
        void Init();

        void InitOpt(string opt);

        void InitKey(string key);

        void FocusIn();

        bool Check();
    }
}

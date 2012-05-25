
namespace Me.Amon.Sec.Pro
{
    public delegate void CallBackHandler<T>(T obj);

    public interface IForm<T>
    {
        CallBackHandler<T> CallBack { get; set; }

        void Show(ASec asec, T data);
    }
}

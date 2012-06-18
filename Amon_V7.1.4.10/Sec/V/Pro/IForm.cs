
namespace Me.Amon.Sec.V.Pro
{
    public delegate void CallBackHandler<T>(T obj);

    public interface IForm<T>
    {
        CallBackHandler<T> CallBack { get; set; }

        void Show(ASec asec, T data);
    }
}

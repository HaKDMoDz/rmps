
namespace Msec
{
    public delegate void CallBackHandler<T>(T obj);

    public interface IForm<T>
    {
        CallBackHandler<T> CallBack { get; set; }

        void Show(Main main, T data);
    }
}

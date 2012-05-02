using Me.Amon.Model;

namespace Me.Amon.Pwd.E
{
    public interface IPwdAction : IAction
    {
        APwd APwd { get; set; }

        ViewModel ViewModel { get; set; }
    }
}

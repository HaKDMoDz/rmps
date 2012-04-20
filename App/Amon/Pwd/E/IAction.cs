using Me.Amon.Model;

namespace Me.Amon.Pwd.E
{
    public interface IAction
    {
        APwd APwd { get; set; }

        ViewModel ViewModel { get; set; }

        void EventHandler(object sender, System.EventArgs e);
    }
}

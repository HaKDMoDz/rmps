using Me.Amon.Model;

namespace Me.Amon.Pwd.E
{
    public abstract class AAction : IAction
    {
        public APwd APwd { get; set; }

        public ViewModel ViewModel { get; set; }

        public abstract void EventHandler(object sender, System.EventArgs e);
    }
}


namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteKeyAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DeleteKey();
            }
        }
    }
}

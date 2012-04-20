
namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteKeyAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.DeleteKey();
            }
        }
    }
}

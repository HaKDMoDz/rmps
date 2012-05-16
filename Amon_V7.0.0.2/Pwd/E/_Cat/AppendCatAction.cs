using Me.Amon.Event;
using Me.Amon.Pwd._Cat;

namespace Me.Amon.Pwd.E._Cat
{
    public class AppendCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                CatEdit catEdit = new CatEdit();
                catEdit.CallBackHandler = new AmonHandler<Cat>(IApp.AppendCat);
                catEdit.Show(IApp.Form, new Cat());
            }
        }
    }
}

using Me.Amon.C;
using Me.Amon.M;
using Me.Amon.Pwd._Cat;

namespace Me.Amon.Pwd.E._Cat
{
    public class UpdateCatAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                CatEditer catEdit = new CatEditer();
                catEdit.CallBackHandler = new AmonHandler<Cat>(IApp.UpdateCat);
                catEdit.Show(IApp.Form, IApp.SelectedCat);
            }
        }
    }
}

using Me.Amon.C;
using Me.Amon.Pwd._Cat;

namespace Me.Amon.Pwd.E._Cat
{
    public class UpdateCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                CatEdit catEdit = new CatEdit();
                catEdit.CallBackHandler = new AmonHandler<Cat>(IApp.UpdateCat);
                catEdit.Show(IApp.Form, IApp.SelectedCat);
            }
        }
    }
}

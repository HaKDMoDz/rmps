using Me.Amon.C;
using Me.Amon.M;
using Me.Amon.Pwd._Cat;

namespace Me.Amon.Pwd.E._Cat
{
    public class UpdateCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }
            var cat = IApp.SelectedCat;
            if (cat == null || cat.Id == CPwd.DEF_CAT_ID)
            {
                return;
            }

            CatEditer catEdit = new CatEditer();
            catEdit.CallBackHandler = new AmonHandler<Cat>(IApp.UpdateCat);
            catEdit.Show(IApp.Form, cat);
        }
    }
}

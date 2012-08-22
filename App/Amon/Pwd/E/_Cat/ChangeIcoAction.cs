namespace Me.Amon.Pwd.E._Cat
{
    public class ChangeIcoAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                Cat cat = IApp.SelectedCat;
                if (cat == null || cat.Id == CPwd.DEF_CAT_ID)
                {
                    return;
                }
                IApp.ChangeCatIcon();
            }
        }
    }
}

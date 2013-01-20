namespace Me.Amon.Pwd.E._Cat
{
    public class DeleteCatAction : APwdAction
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

            IApp.DeleteCat();
        }
    }
}

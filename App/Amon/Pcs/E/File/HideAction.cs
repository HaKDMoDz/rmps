namespace Me.Amon.Pcs.E.File
{
    public class HideAction : APcsAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.HideForm();
            }
        }
    }
}

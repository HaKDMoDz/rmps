namespace Me.Amon.Ico.E
{
    public class RemoveIcoAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.RemoveIco();
            }
        }
    }
}

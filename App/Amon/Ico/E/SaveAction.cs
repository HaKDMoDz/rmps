namespace Me.Amon.Ico.E
{
    public class SaveAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            IApp.Save();
        }
    }
}

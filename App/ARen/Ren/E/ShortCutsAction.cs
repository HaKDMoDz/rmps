namespace Me.Amon.Ren.E
{
    public class ShortCutsAction : ARenAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowShortCuts();
            }
        }
    }
}

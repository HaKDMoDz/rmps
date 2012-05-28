namespace Me.Amon.Ico.E
{
    public class AppendImgAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AppendImg(32);
            }
        }
    }
}

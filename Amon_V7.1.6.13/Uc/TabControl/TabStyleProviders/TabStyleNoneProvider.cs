namespace System.Windows.Forms
{
    [System.ComponentModel.ToolboxItem(false)]
    public class TabStyleNoneProvider : TabStyleProvider
    {
        public TabStyleNoneProvider(ATabControl tabControl)
            : base(tabControl)
        {
        }

        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds)
        {
        }
    }
}

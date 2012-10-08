using Me.Amon.Api.Enums;

namespace Me.Amon.Api.Input
{
    internal static class MouseButtonExtensions
    {
        internal static MouseEvent ToMouseButtonDownFlag(this MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return MouseEvent.LeftDown;

                case MouseButton.Middle:
                    return MouseEvent.MiddleDown;

                case MouseButton.Right:
                    return MouseEvent.RightDown;

                default:
                    return MouseEvent.LeftDown;
            }
        }

        internal static MouseEvent ToMouseButtonUpFlag(this MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return MouseEvent.LeftUp;

                case MouseButton.Middle:
                    return MouseEvent.MiddleUp;

                case MouseButton.Right:
                    return MouseEvent.RightUp;

                default:
                    return MouseEvent.LeftUp;
            }
        }
    }
}
using System;

namespace Me.Amon.Api.Delegates
{
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
}

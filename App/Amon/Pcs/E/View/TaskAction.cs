﻿using System;

namespace Me.Amon.Pcs.E.View
{
    public class TaskAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ChangeTaskVisible();
            }
        }
    }
}

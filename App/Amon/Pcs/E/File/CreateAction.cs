﻿using System;

namespace Me.Amon.Pcs.E.File
{
    public class CreateAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.CreatePcs();
            }
        }
    }
}

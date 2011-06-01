using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.magickms
{
    public class Demo
    {
        public static MSolution GetDemo()
        {
            MSolution sol = new MSolution();

            MFunction preFun = new MFunction();
            preFun.Order = 1;
            preFun.Action = EAction.ShowWindow;
            preFun.Param = "无标题 - 记事本";
            sol.PreFunction = new List<MFunction> { preFun };

            preFun = new MFunction();
            preFun.Order = 1;
            preFun.Action = EAction.GetControl;
            preFun.Param = "1,Edit";
            sol.PreFunction.Add(preFun);

            MFunction sufFun = new MFunction();
            sufFun.Order = 1;
            sufFun.Action = EAction.KeybdInput;
            sufFun.Param = "enter";
            sol.SufFunction = new List<MFunction> { sufFun };

            List<string> text = new List<string>();
            text.Add("Hello!");
            text.Add("Hi~~");
            text.Add("您好！");
            sol.TxtList = text;

            return sol;
        }
    }
}

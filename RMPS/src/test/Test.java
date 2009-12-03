/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Test
{
    public static void main(String[] args)
    {
        Pattern p = Pattern.compile("'(.*?)'");
        Matcher m = p.matcher("['200000','021','上海','上海','上海']");
        while (m.find())
        {
            System.out.println(m.group().replaceAll("^'|'$", ""));
        }
    }

    public static void aa()
    {
//        Context cx = Context.enter();
//        Scriptable scope = cx.initStandardObjects();
//        Object result = cx.evaluateString(scope, "var I_SUCCESS = 1;var pc_data = ['200000','021','上海','上海','上海'];var pc_data1 = [['101600','0316','三河','河北','三河'],['054100','0319','沙河','河北','沙河'],['152000','0458','绥化','黑龙江','绥化'],['211900','0527','泗洪','江苏','泗洪'],['251600','0531','商河','山东','商河'],['364200','0597','上杭','福建','上杭'],['526200','0758','四会','广东','四会'],['629200','0825','射洪','四川','射洪']];", null, 1, null);
//        Scriptable obj = (Scriptable) scope.get("pc_data", scope);
//        System.out.println(obj);
    }
}

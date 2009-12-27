/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;

import rmp.irp.m.I7010000.I7010000;
import test.irp.Message;
import test.irp.Session;

import com.amonsoft.rmps.irp.m.IService;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Test
{
    /**
     * @param args
     */
    public static void main(String[] args)
    {
        String t = "<ul onmouseup=\"javascript:callclip(cresult);\"><li>・<font color=\"blue\">本站主数据</font>:www.123cha.com</li>"
                + "<li>・<font color=\"blue\">本站辅数据</font>:还没人提交数据</li><li>・<font color=\"blue\">参考数据一</font>:上海市有线通</li>" + "<li>・<font color=\"blue\">参考数据二</font>:上海市有线通</li>"
                + "<li>[查询提供] www.123cha.com</li>"

                + "        </ul>";
        try
        {
            Document doc = DocumentHelper.parseText(t);
            for (Object obj : doc.selectNodes("/ul/li"))
            {
                System.out.println(((Element) obj).getText());
            }
        }
        catch (DocumentException e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public static void test()
    {
        Session session = new Session();
        Message message = new Message("118.132.166.12");
        IService s = new I7010000();
        s.doInit(session, message);
        s.doDeal(session, message);
    }
}

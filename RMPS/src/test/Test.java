/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import com.amonsoft.bean.WForm;
import javax.swing.JFrame;
import javax.swing.SwingConstants;

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
        WForm form = new WForm();
        form.wInit(true);
        form.setSize(400, 300);
        form.setUndecorated(true);
        form.setVisible(true);
        form.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//        new JFrame().setSize(400, 200);//.setVisible(true);
    }
}

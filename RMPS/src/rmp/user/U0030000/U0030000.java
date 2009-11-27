/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.user.U0030000;

import java.awt.image.BufferedImage;

import javax.swing.JMenu;
import javax.swing.JPanel;

import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.ui.form.AForm;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 修改配置
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class U0030000 extends AForm implements IPrpPlus
{
    @Override
    public boolean wClosing()
    {
        return true;
    }

    @Override
    public String wGetBaseFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetDescription()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetHomepage()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public int wCode()
    {
        // TODO Auto-generated method stub
        return 0;
    }

    @Override
    public BufferedImage wGetIconImage(int type)
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetName()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetPlusFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetTitle()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public String wGetVersion()
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public boolean wShowMenu(JMenu menu)
    {
        // TODO Auto-generated method stub
        return false;
    }

    @Override
    public boolean wShowTail(JPanel view)
    {
        // TODO Auto-generated method stub
        return false;
    }

    @Override
    public void wSetBaseFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    @Override
    public void wSetPlusFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    @Override
    public void wShowHelp()
    {
        // TODO Auto-generated method stub
    }

    @Override
    public void wShowInfo()
    {
        // TODO Auto-generated method stub
    }

    @Override
    public JPanel wShowView(int modelIdx)
    {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public boolean wIconified()
    {
        return true;
    }

    @Override
    public boolean wDeiconified()
    {
        return true;
    }
    /**  */
    private static final long serialVersionUID = 888962056649493365L;
}

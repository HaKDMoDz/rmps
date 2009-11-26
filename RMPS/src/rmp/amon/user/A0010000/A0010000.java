/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.user.A0010000;

import java.awt.image.BufferedImage;

import javax.swing.JMenu;
import javax.swing.JPanel;

import com.amonsoft.rmps.prp.ISoft;
import rmp.ui.form.AForm;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 用户管理
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class A0010000 extends AForm implements ISoft
{
    /**
     * 
     */
    public A0010000()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wClosing()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetDescription()
     */
    @Override
    public String wGetDescription()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wCode()
     */
    @Override
    public int wCode()
    {
        // TODO Auto-generated method stub
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetName()
     */
    @Override
    public String wGetName()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetVersion()
     */
    @Override
    public String wGetVersion()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowView(int)
     */
    @Override
    public javax.swing.JPanel wShowView(int modelIdx)
    {
        switch (modelIdx)
        {
            // 显示内嵌模式
            case VIEW_TAIL:
                return showTail();

            // 显示迷你模式
            case VIEW_MINI:
                return showMini();

            // 显示正常模式
            case VIEW_NORM:
                return showNorm();

            // 显示高级模式
            case VIEW_MAIN:
                return showMain();

            // 显示向导模式
            case VIEW_STEP:
                return showStep();

            default:
                return null;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wIconified()
     */
    @Override
    public boolean wIconified()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wDeiconified()
     */
    @Override
    public boolean wDeiconified()
    {
        return true;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showMain()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showMini()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showNorm()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showStep()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showTail()
    {
        return null;
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // TODO Auto-generated method stub
    }
    /** serialVersionUID */
    private static final long serialVersionUID = -1999861570345515854L;
}

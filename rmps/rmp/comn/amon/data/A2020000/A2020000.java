/*
 * FileName:       A2020000.java
 * CreateDate:     2008-1-10 下午12:56:46
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */
package rmp.comn.amon.data.A2020000;

import java.awt.image.BufferedImage;

import javax.swing.JMenu;
import javax.swing.JPanel;

import com.amonsoft.bean.WForm;
import com.amonsoft.rmps.prp.IPrpPlus;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-1-10 下午12:56:46
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class A2020000 extends WForm implements IPrpPlus
{
    /**
     * 
     */
    public A2020000()
    {
    }

    @Override
    public boolean wInitView()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean wInitLang()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean wInitData()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wClosing()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetDescription()
     */
    @Override
    public String wGetDescription()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wCode()
     */
    @Override
    public int wCode()
    {
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetIcon()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetName()
     */
    @Override
    public String wGetName()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetVersion()
     */
    @Override
    public String wGetVersion()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wSetBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowView(int)
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
     * @see rmp.face.IPrpPlus#wIconified()
     */
    @Override
    public boolean wIconified()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wDeiconified()
     */
    @Override
    public boolean wDeiconified()
    {
        return true;
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
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
}

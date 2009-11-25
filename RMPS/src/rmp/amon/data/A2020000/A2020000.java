/*
 * FileName:       A2020000.java
 * CreateDate:     2008-1-10 下午12:56:46
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.amon.data.A2020000;

import java.awt.image.BufferedImage;

import javax.swing.JMenu;
import javax.swing.JPanel;

import com.amonsoft.rmps.prp.ISoft;
import rmp.ui.form.AForm;

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
public class A2020000 extends AForm implements ISoft
{
    /**
     * 
     */
    public A2020000()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @ Override
    public boolean wInit()
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wDispose()
     */
    @ Override
    public void wDispose()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetBaseFolder()
     */
    @ Override
    public String wGetBaseFolder()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetDescription()
     */
    @ Override
    public String wGetDescription()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetHomepage()
     */
    @ Override
    public String wGetHomepage()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wCode()
     */
    @ Override
    public int wCode()
    {
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetIcon()
     */
    @ Override
    public BufferedImage wGetIconImage(int type)
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetName()
     */
    @ Override
    public String wGetName()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetPlusFolder()
     */
    @ Override
    public String wGetPlusFolder()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetTitle()
     */
    @ Override
    public String wGetTitle()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetVersion()
     */
    @ Override
    public String wGetVersion()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitMenu(javax.swing.JMenu)
     */
    @ Override
    public boolean wInitMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitTail(javax.swing.JPanel)
     */
    @ Override
    public boolean wInitTail(JPanel view)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetBaseFolder(java.lang.String)
     */
    @ Override
    public void wSetBaseFolder(String folder)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetPlusFolder(java.lang.String)
     */
    @ Override
    public void wSetPlusFolder(String folder)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowHelp()
     */
    @ Override
    public void wShowHelp()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
     */
    @ Override
    public void wShowInfo()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowView(int)
     */
    @ Override
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
     * @see rmp.face.ISoft#wStart()
     */
    @ Override
    public boolean wStart()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStop()
     */
    @ Override
    public boolean wStop()
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

    /**  */
    private static final long serialVersionUID = 465580527845582157L;
}

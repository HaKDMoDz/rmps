/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.form;

import java.awt.Container;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

import javax.swing.JApplet;
import javax.swing.JMenuBar;

import rmp.face.WBean;
import com.amonsoft.rmps.prp.ISoft;
import com.amonsoft.skin.ISkin;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class AForm extends JApplet implements WBean
{
    /** 标准插件 */
    private ISoft ms_MainSoft;
    /** 用户菜单 */
    private JMenuBar mb_UserMenu;

    public AForm()
    {
        getContentPane().setLayout(new java.awt.BorderLayout());
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.Container#removeAll()
     */
    @Override
    public void removeAll()
    {
        getContentPane().removeAll();
        if (mb_UserMenu != null)
        {
            getContentPane().add(mb_UserMenu, java.awt.BorderLayout.NORTH);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JApplet#setContentPane(java.awt.Container)
     */
    @Override
    public void setContentPane(Container contentPane)
    {
        // 不是定制风格时，不进行下面的处理
        if (true)
        {
            super.setContentPane(contentPane);
            return;
        }

        contentPane.setName(ISkin.PANEL_BASE);
        getContentPane().add(contentPane, java.awt.BorderLayout.CENTER);
    }

    /**
     * @return
     */
    public ISoft getSoft()
    {
        return ms_MainSoft;
    }

    /**
     * @param soft
     */
    public void setSoft(ISoft soft)
    {
        this.ms_MainSoft = soft;
    }

    /**
     * @param filterPrefix
     * @throws IllegalAccessException
     * @throws IllegalArgumentException
     */
    public void readParam(String filterPrefix) throws IllegalArgumentException, IllegalAccessException
    {
        Field[] fields = this.getClass().getFields();
        String param;
        Class<?> fieldType;

        for (Field field : fields)
        {
            param = getParameter(field.getName());

            if (param == null || Modifier.isFinal(field.getModifiers()) || ((filterPrefix != null) && !field.getName().startsWith(filterPrefix)))
            {
                continue;
            }

            fieldType = field.getType();
            if (fieldType.equals(boolean.class))
            {
                field.setBoolean(this, Boolean.valueOf(param).booleanValue());
                continue;
            }
            if (fieldType.equals(byte.class))
            {
                field.setByte(this, Byte.valueOf(param).byteValue());
                continue;
            }
            if (fieldType.equals(char.class))
            {
                field.setChar(this, param.charAt(0));
                continue;
            }
            if (fieldType.equals(double.class))
            {
                field.setDouble(this, Double.valueOf(param).doubleValue());
                continue;
            }
            if (fieldType.equals(float.class))
            {
                field.setFloat(this, Float.valueOf(param).floatValue());
                continue;
            }
            if (fieldType.equals(int.class))
            {
                field.setInt(this, Integer.valueOf(param).intValue());
                continue;
            }
            if (fieldType.equals(long.class))
            {
                field.setLong(this, Long.valueOf(param).longValue());
                continue;
            }
            if (fieldType.equals(short.class))
            {
                field.setShort(this, Short.valueOf(param).shortValue());
                continue;
            }
            if (fieldType.equals(String.class))
            {
                field.set(this, param);
                continue;
            }
        }
    }

    /**
     * @param view
     */
    public void showView(int view)
    {
        if (ms_MainSoft != null)
        {
            setContentPane(ms_MainSoft.wShowView(view));
        }
    }
}

/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import java.util.regex.Pattern;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IProcess;

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
public class Process implements IProcess
{
    private Pattern keyReg;
    private String func;
    private String item;
    private int step;
    private int type;
    private int most;

    Process()
    {
        func = FUNC_DEFAULT;
        item = ITEM_DEFAULT;
        step = STEP_DEFAULT;
        type = TYPE_DEFAULT;

        keyReg = Pattern.compile("^([\\.。]{2})?([/／]{1})?([\\.。]{2}[/／]{1})*[\\d０１２３４５６７８９]*$");
    }

    /**
     * @return the func
     */
    @Override
    public String getFunc()
    {
        return func;
    }

    /**
     * @param func
     *            the func to set
     */
    @Override
    public boolean setFunc(String func)
    {
        // 判断参数是否为空
        if (func == null)
        {
            return false;
        }

        if (FUNC_DEFAULT.equals(func))
        {
            this.func = func;
            return true;
        }

        // 判断是否为功能代码
        if (!keyReg.matcher(func).matches())
        {
            return false;
        }

        func = func.replace('。', '.').replace('／', '/');
        StringBuffer tmp = new StringBuffer();

        // 是否基于当前路径
        if (func.charAt(0) != '/')
        {
            tmp.append(this.func);
        }
        
        // 上级切换事件
        int l = tmp.length();
        if ("..".equals(func))
        {
            this.func = l > 0 ? tmp.substring(0, l - 1) : FUNC_DEFAULT;
            return true;
        }

        // 向上切换
        int i = 0;
        while (l > 0)
        {
            i = func.indexOf("../", i) + 3;
            if (i < 3)
            {
                break;
            }
            tmp.deleteCharAt(--l);
        }

        // 去除斜杠
        i = func.lastIndexOf('/');
        if (i >= 0)
        {
            func = func.substring(i + 1);
        }

        // 向下切换
        for (char c : func.toCharArray())
        {
            tmp.append(c);
            if (Control.getService(tmp.toString()) == null)
            {
                tmp.deleteCharAt(tmp.length() - 1);
                break;
            }
        }
        this.func = tmp.toString();
        return true;
    }

    @Override
    public String getItem()
    {
        return item;
    }

    @Override
    public boolean setItem(String item)
    {
        this.item = item;
        return true;
    }

    /**
     * @return the step
     */
    @Override
    public int getStep()
    {
        return step;
    }

    /**
     * @param step
     *            the step to set
     */
    @Override
    public void setStep(int step)
    {
        this.step = step;
    }

    /**
     * @return the type
     */
    @Override
    public int getType()
    {
        return type;
    }

    /**
     * @param type
     *            the type to set
     */
    @Override
    public void setType(int type)
    {
        this.type = type;
    }

    /**
     * 
     * @return
     */
    @Override
    public int getMost()
    {
        return most;
    }

    /**
     * 
     * @param most
     */
    @Override
    public void setMost(int most)
    {
        this.most = most;
    }
}

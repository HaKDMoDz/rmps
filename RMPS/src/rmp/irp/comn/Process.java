/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import com.amonsoft.rmps.irp.b.IProcess;
import java.util.regex.Pattern;
import rmp.util.CheckUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Process implements IProcess
{
    private Pattern keyReg;
    private StringBuffer func;
    private int step;
    private int type;
    private int most;

    Process()
    {
        func = new StringBuffer(FUNC_DEFAULT);
        step = STEP_DEFAULT;
        type = TYPE_DEFAULT;

        keyReg = Pattern.compile("^(..)?/?(../)*\\d*$");
    }

    /**
     * @return the func
     */
    @Override
    public String getFunc()
    {
        return func.toString();
    }

    /**
     * @param func the func to set
     */
    @Override
    public boolean setFunc(String func)
    {
        if (!keyReg.matcher(func).matches())
        {
            return false;
        }

        if (!CheckUtil.isValidate(func))
        {
            return true;
        }

        char c = func.charAt(0);

        // 以/开始，表示使用绝对路径
        int l = this.func.length();
        if (c == '/')
        {
            this.func.delete(0, l).append(func.substring(1));
            return true;
        }

        // 以数字开始，表示向下加载
        if (c != '.')
        {
            this.func.append(func);
            return true;
        }

        // 以.开始，表示相对路径
        int i = 0;
        while (l > 0)
        {
            i = func.indexOf("..", i);
            if (i >= 0)
            {
                l -= 1;
                this.func.deleteCharAt(l);
            }
        }
        this.func.append(func.substring(i + 2));
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
     * @param step the step to set
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
     * @param type the type to set
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

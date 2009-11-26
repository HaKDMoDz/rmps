/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp._comn;

import com.amonsoft.rmps.imp.b.IProcess;


/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Step implements IProcess
{
    private int func;
    private int step;
    private int type;

    /**
     * @return the func
     */
    @Override
    public int getFunc()
    {
        return func;
    }

    /**
     * @param func the func to set
     */
    @Override
    public void setFunc(int func)
    {
        this.func = func;
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
}

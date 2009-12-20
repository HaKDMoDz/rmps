/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.b;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface IProcess
{
    int FUNC_DEFAULT = 0x50000000;

    /**
     * 获取当前功能标记
     * @return
     */
    int getFunc();

    void setFunc(int func);
    int STEP_DEFAULT = 0;

    /**
     * 获取当前操作标记
     * @return
     */
    int getStep();

    void setStep(int step);
    /**
     * 默认
     */
    int TYPE_DEFAULT = 0;
    /**
     * 功能切换关键字
     */
    int TYPE_KEYCODE = 1;
    /**
     * 命令执行文本
     */
    int TYPE_COMMAND = 2;
    /**
     * 用户内容文本
     */
    int TYPE_CONTENT = 4;

    int getType();

    void setType(int type);

    /**
     * 最大操作步数
     * @return
     */
    int getMost();

    void setMost(int most);
}

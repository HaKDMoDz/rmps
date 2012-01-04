/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统的项层接口类，用于提供统一的对象管理机制，及代码规范化。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface IRmps
{
    /**
     * 此方法用于RMPS系统中类的初始化处理。
     * <ul>
     * 规定：
     * <li>RMPS系统在类的构造函数中应包含尽可能少的代码，实现尽可能的功能，以保证类的正常初始化；
     * <li>所有类的初始化都尽可能在init()方法中完成。
     * </ul>
     * 外部调用程序可以根据此方法执行后返回的结果状态来判断是否需要进行下一步的操作，以确保系统的正常运行。
     * 
     * @return 返回初始化是否正常进行：true表示初始化成功，false表示初始化失败。
     */
    boolean wInit();

    /**
     * 返回RMPS应用的唯一代码，其中包括当前系统所属的应用、模块，及当前系统的系统ID，其值参见SysCons中定义。
     * 
     * @return 当前系统的唯一标记ID，{@link cons.SysCons}
     */
    int wCode();
}

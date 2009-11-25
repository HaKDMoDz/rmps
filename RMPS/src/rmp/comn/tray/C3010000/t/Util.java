/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.tray.C3010000.t;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public final class Util
{
    /** 系统是否支持系统托盘 */
    private static boolean traySupport = java.awt.SystemTray.isSupported();

    /**
     * @return
     */
    public static boolean isTraySupport()
    {
        return traySupport;
    }
}

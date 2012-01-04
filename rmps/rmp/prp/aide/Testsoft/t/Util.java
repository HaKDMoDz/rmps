/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.Testsoft.t;

import java.util.HashMap;

import rmp.face.WBackCall;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 系统共用数据模型或方法
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 调用此模型并且需要回馈的对象 */
    private static HashMap<String, WBackCall> hm_PropList;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    private Util()
    {
    }

    /**
     * 注册回馈对象引用
     * 
     * @param key
     * @param backCall
     */
    public static void register(String key, WBackCall backCall)
    {
        if (hm_PropList == null)
        {
            hm_PropList = new HashMap<String, WBackCall>();
        }
        hm_PropList.put(key, backCall);
    }

    /**
     * 指定回馈对象信息回馈
     * 
     * @param key
     */
    public static void firePropertyChanged(String key, String value)
    {
        if (hm_PropList != null)
        {
            WBackCall backCall = hm_PropList.get(key);
            if (backCall != null)
            {
                backCall.wAction(null, value, null);
            }
        }
    }
}

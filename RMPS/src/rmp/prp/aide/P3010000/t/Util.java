/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.t;

import java.awt.Component;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.List;

import javax.swing.JPopupMenu;

import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.m.BaseData;
import rmp.prp.aide.P3010000.m.ExtsBaseData;
import rmp.prp.aide.P3010000.v.SysMenu;
import rmp.util.LogUtil;

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
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 调用此模型并且需要回馈的对象 */
    private static HashMap<String, WBackCall> hm_PropList;
    // ----------------------------------------------------
    // 子窗口对象区域
    // ----------------------------------------------------
    /** 系统菜单 */
    private static SysMenu mm_MainMenu;

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

    /**
     * @param extsName
     * @return
     */
    public static List<ExtsBaseData> query(String extsName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, extsName);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            return null;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param dba
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static List<ExtsBaseData> query(DBAccess dba, String extsName) throws SQLException
    {
        return null;
        // return DA8000.selectExtsMeta(dba, extsName);
    }

    /**
     * @param extsName
     * @param softHash
     * @return
     */
    public static ExtsBaseData query(BaseData baseMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, baseMeta);
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            return null;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param dba
     * @param extsName
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData query(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        return null;
        // return DA8000.selectExtsMeta(dba, baseMeta);
    }

    /**
     * @return
     */
    public static SysMenu showMainMenu(Component invoker)
    {
        if (mm_MainMenu == null)
        {
            mm_MainMenu = new SysMenu(null);
            mm_MainMenu.wInit();
        }

        JPopupMenu pm = mm_MainMenu.getPopupMenu();
        pm.show(invoker, 0, 0);
        mm_MainMenu.getPopupMenu().show(invoker, 0, 0 - pm.getHeight());
        return mm_MainMenu;
    }
}

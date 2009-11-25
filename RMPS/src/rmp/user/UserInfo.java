/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.user;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Properties;

import com.amonsoft.rmps.IRmps;
import com.amonsoft.rmps.prp.ISoft;
import rmp.util.LogUtil;
import cons.CfgCons;
import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 系统当前登录用户信息类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public final class UserInfo implements IRmps
{
    /** 用户唯一标记ID */
    private int uid;
    /** 用户登录名称 */
    private String unm;
    /** 用户登录口令 */
    private String pwd;
    /** 安全权值 */
    private String slt;
    /** 用户配置对象 */
    private Properties ucp;

    /**
     * @param name
     * @param pwds
     */
    public UserInfo(String name, String pwds)
    {
        this.unm = name;
        this.pwd = pwds;
        ucp = new Properties();
    }

    public UserInfo(String name, String pwds, String salt)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#init()
     */
    @Override
    public boolean wInit()
    {
        // 用户名称检测

        // 用户口令检测
        if (pwd == null || pwd.length() < 1)
        {
            return false;
        }
        // 设置用户口令为空
        pwd = "";

        // 用户配置信息读取
        setDefault();// AMON:

        return true;
    }

    @Override
    public int wCode()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    /**
     * 获得当前用户的唯一标记ID
     * 
     * @return
     */
    public int getUserID()
    {
        return uid;
    }

    /**
     * 获得用户名称
     * 
     * @return
     */
    public String getUserName()
    {
        return unm;
    }

    /**
     * 加载用户配置数据
     * 
     * @return
     */
    public boolean loadCfg(String baseFolder, int appMode)
    {
        if (appMode == ISoft.MODE_APPLICATION)
        {
            StringBuffer ucf = new StringBuffer(baseFolder).append(uid).append(EnvCons.COMN_SP_FILE).append("rmp.wsc");
            FileInputStream fis = null;
            try
            {
                fis = new FileInputStream(ucf.toString());
                ucp.load(fis);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                setDefault();
            }
            finally
            {
                if (fis != null)
                {
                    try
                    {
                        fis.close();
                    }
                    catch (IOException exp)
                    {
                        LogUtil.exception(exp);
                    }
                }
            }
        }
        else
        {
            setDefault();
        }
        return true;
    }

    /**
     * 获取用户配置数据项数据
     * 
     * @param key
     * @return
     */
    public String getCfg(String key)
    {
        return ucp.getProperty(key);
    }

    /**
     * 获取用户配置数据项数据
     * 
     * @param key
     * @param defaultValue
     * @return
     */
    public String getCfg(String key, String defaultValue)
    {
        return ucp.getProperty(key, defaultValue);
    }

    /**
     * 保存用户配置数据
     * 
     * @return
     */
    public boolean saveCfg()
    {
        LogUtil.log("用户配置数据保存！");

        File ucf = new File(uid + EnvCons.COMN_SP_FILE + "rmp.wsc");
        try
        {
            ucp.store(new FileOutputStream(ucf), "User:" + uid);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return true;
    }

    /**
     * 更新用户配置文件
     * 
     * @param key
     * @param value
     */
    public void setCfg(String key, String value)
    {
        ucp.put(key, value);
    }

    /**
     * 设置默认用户信息
     */
    public void setDefault()
    {
        uid = 1000000;
        ucp.clear();
        ucp.setProperty(CfgCons.CFG_LANG_NAME, "中国");
        ucp.setProperty(CfgCons.CFG_LANG_ID, "zh_CN");
    }

    /**
     * 设置用户配置皮肤信息
     * 
     * @param type 风格类型
     * @param name 风格名称
     * @return
     */
    public void setUserSkin(String type, String name)
    {
        ucp.setProperty(CfgCons.CFG_LNF_TYPE, type);
        ucp.setProperty(CfgCons.CFG_LNF_NAME, name);
    }

    /**
     * @param unm the unm to set
     */
    public void setUserName(String unm)
    {
        this.unm = unm;
    }

    /**
     * @param pwd the pwd to set
     */
    public void setUserPwds(String pwd)
    {
        this.pwd = pwd;
    }

    /**
     * @param slt the slt to set
     */
    public void setSlt(String slt)
    {
        this.slt = slt;
    }
}

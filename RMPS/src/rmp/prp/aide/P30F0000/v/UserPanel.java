/*
 * FileName:       UserPanel.java
 * CreateDate:     2008-3-27 下午07:17:47
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.v;

import java.util.EventObject;

import rmp.bean.K1SV1S;
import rmp.face.WBackCall;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.user.UserInfo;
import rmp.user.U0000000.U0000000;
import rmp.user.U0010000.U0010000;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-3-27 下午07:17:47
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class UserPanel implements WBackCall
{
    private boolean validate;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        // 用户配置信息检测
        UserInfo ui = RmpsUtil.getUserInfo();

        // 已存在用户注册信息的情况下,显示用户登录界面
        if (ui.getCfg(cons.prp.aide.P30F0000.ConstUI.CFG_USER) != null)
        {
            U0000000 u000 = new U0000000((javax.swing.JFrame)P30F0000.getForm());
            u000.wInit();
            u000.register(CfgCons.SIGN_IN, this);
            u000.wShowView(ISoft.VIEW_MINI);
        }
        // 不存在用户注册信息的情况下,显示用户注册界面
        else
        {
            U0010000 u001 = new U0010000((javax.swing.JFrame)P30F0000.getForm());
            u001.wInit();
            u001.register(CfgCons.SIGN_UP, this);
            u001.wShowView(ISoft.VIEW_MINI);
        }

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object,
     *      java.lang.String)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {
        // 取消登录
        if (CfgCons.SIGN_OUT.equals(property))
        {
            return;
        }
        // 登录失败
        if (CfgCons.SIGN_ERR.equals(property))
        {
            return;
        }

        if (!(object instanceof K1SV1S))
        {
            return;
        }
        K1SV1S kv = (K1SV1S)object;
        // 用户登录
        if (CfgCons.SIGN_IN.equals(property))
        {
            try
            {
                validate = Util.getUserData().signIn(kv.getK(), kv.getV());
            }
            catch(Exception exp)
            {
                MesgUtil.showMessageDialog(null, exp.getMessage());
                validate = false;
            }
            return;
        }
        // 用户注册
        if (CfgCons.SIGN_UP.equals(property))
        {
            try
            {
                validate = Util.getUserData().signUp(kv.getK(), kv.getV());
            }
            catch(Exception exp)
            {
                MesgUtil.showMessageDialog(null, exp.getMessage());
                validate = false;
            }
            return;
        }
        // 修改口令
        if (CfgCons.SIGN_PWD.equals(property))
        {
            try
            {
                validate = Util.getUserData().signPwd(kv.getK(), kv.getV());
            }
            catch(Exception exp)
            {
                MesgUtil.showMessageDialog(null, exp.getMessage());
                validate = false;
            }
            return;
        }
    }

    /**
     * @return the validate
     */
    public boolean isValidate()
    {
        return validate;
    }
}

/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.v.qq;

import com.amonsoft.rmps.irp.b.IPresence;

import edu.tsinghua.lumaqq.qq.QQ;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class Presence implements IPresence
{
    private byte imc;

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getAsc()
     */
    @Override
    public int getAsc()
    {
        switch (this.imc)
        {
            case QQ.QQ_STATUS_QME:
                return IPresence.IDLE;
            case QQ.QQ_STATUS_ONLINE:
                return IPresence.LINE;
            case QQ.QQ_STATUS_OFFLINE:
                return IPresence.DOWN;
            case QQ.QQ_STATUS_AWAY:
                return IPresence.AWAY;
            case QQ.QQ_STATUS_BUSY:
                return IPresence.BUSY;
            case QQ.QQ_STATUS_QUIET:
                return 4;
            case QQ.QQ_STATUS_HIDDEN:
                return IPresence.HIDE;
            default:
                return 9;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getImc()
     */
    @Override
    public String getImc()
    {
        return imc + "";
    }

    public byte getQQS()
    {
        return imc;
    }

    public void setQQS(byte qqs)
    {
        this.imc = qqs;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getMessage()
     */
    @Override
    public String getMessage()
    {
        switch (imc)
        {
            case QQ.QQ_STATUS_ONLINE:
                return "在线";
            case QQ.QQ_STATUS_OFFLINE:
                return "离线";
            case QQ.QQ_STATUS_AWAY:
                return "离开";
            case QQ.QQ_STATUS_BUSY:
                return "忙碌";
            case QQ.QQ_STATUS_QME:
                return "Q我吧";
            case QQ.QQ_STATUS_QUIET:
                return "请勿打扰";
            case QQ.QQ_STATUS_HIDDEN:
                return "隐身";
        }
        return "";
    }

}

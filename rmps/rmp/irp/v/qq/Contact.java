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

import java.util.ArrayList;
import java.util.List;

import rmp.irp.comn.AContact;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.util.CharUtil;

import edu.tsinghua.lumaqq.qq.beans.ContactInfo;
import edu.tsinghua.lumaqq.qq.beans.FriendRemark;
import edu.tsinghua.lumaqq.qq.beans.QQFriend;

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
 * @author Amon
 * 
 */
public class Contact extends AContact
{
    protected QQFriend friend;
    protected FriendRemark remark;
    protected ContactInfo contact;
    protected Presence presence;
    protected List<ICatalog> catalogs;

    Contact()
    {
        catalogs = new ArrayList<ICatalog>();
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getCatalogs()
     */
    @Override
    public List<ICatalog> getCatalogs()
    {
        return null;
    }

    public void addCatalog(ICatalog catalog)
    {
        catalogs.add(catalog);
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getDisplayName()
     */
    @Override
    public String getDisplayName()
    {
        return friend.nick;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getEmail()
     */
    @Override
    public String getEmail()
    {
        return remark != null ? remark.email : "";
    }

    public void setEmail(String email)
    {
        remark.email = email;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getId()
     */
    @Override
    public String getId()
    {
        return Integer.toString(friend.qqNum);
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getName()
     */
    @Override
    public String getUser()
    {
        return Integer.toString(friend.qqNum);
    }

    @Override
    public String getName()
    {
        return remark.name;
    }

    public void setName(String name)
    {
        remark.name = name;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getPersonalMessage()
     */
    @Override
    public String getPersonalMessage()
    {
        return contact.intro;
    }

    /**
     * @param personalMessage
     */
    public void setPersonalMessage(String personalMessage)
    {
        contact.intro = personalMessage;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getPresence()
     */
    @Override
    public IPresence getPresence()
    {
        return presence;
    }

    @Override
    public String toString()
    {
        if (CharUtil.isValidate(getDisplayName()))
        {
            return getDisplayName();
        }
        if (CharUtil.isValidate(getUser()))
        {
            return getUser();
        }
        return "" + getQQ();
    }

    /**
     * @return
     */
    public int getQQ()
    {
        return friend.qqNum;
    }

    /**
     * @param qq
     */
    public void setQQ(int qq)
    {
        friend.qqNum = qq;
    }

    /**
     * @param friend
     */
    public void setFriendInfo(QQFriend friend)
    {
        this.friend = friend;
    }

    /**
     * @param friendRemark
     */
    public void setFriendRemark(FriendRemark friendRemark)
    {
        this.remark = friendRemark;
    }

    /**
     * @param contactInfo
     */
    public void setContactInfo(ContactInfo contactInfo)
    {
        this.contact = contactInfo;
    }
}

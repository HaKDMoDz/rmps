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

import edu.tsinghua.lumaqq.qq.beans.Member;
import edu.tsinghua.lumaqq.qq.beans.QQFriend;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public class QQGroupMember extends Contact
{
    private Member member;

    public QQGroupMember()
    {
    }

    public void setMemberInfo(QQFriend friend)
    {
        this.friend = friend;
    }

    public Member getMember()
    {
        return member;
    }

    public void setMember(Member member)
    {
        this.member = member;
    }
}

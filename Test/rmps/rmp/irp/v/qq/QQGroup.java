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

import java.util.List;
import java.util.Map;

import edu.tsinghua.lumaqq.qq.beans.ClusterInfo;
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
public class QQGroup
{
    private int clusterId;
    // 如果是固定群，这个表示外部ID，如果是临时群，这个表示父群ID
    public int externalId;
    // type字段表示固定群或者临时群的群类型
    public byte type;
    public int creator;
    public byte authType;
    // 2004的群分类
    public int oldCategory;
    // 2005采用的分类
    public int category;
    public int versionId;
    public String name;
    public String description;
    public String notice;
    public String unknownId;
    private List<QQGroupMember> members;
    private Map<Integer, QQGroupMember> memberMap;

    public QQGroup(int clusterId)
    {
        this.clusterId = clusterId;
    }

    public void setClusterInfo(ClusterInfo info)
    {
        this.externalId = info.externalId;
        this.type = info.type;
        this.creator = info.creator;
        this.authType = info.authType;
        this.category = info.category;
        this.versionId = info.versionId;
        this.name = info.name;
        this.description = info.description;
        this.notice = info.notice;
        this.unknownId = info.unknownId;
    }

    public int getClusterId()
    {
        return clusterId;
    }

    public void setClusterId(int clusterId)
    {
        this.clusterId = clusterId;
    }

    public int getExternalId()
    {
        return externalId;
    }

    public void setExternalId(int externalId)
    {
        this.externalId = externalId;
    }

    public byte getType()
    {
        return type;
    }

    public void setType(byte type)
    {
        this.type = type;
    }

    public int getCreator()
    {
        return creator;
    }

    public void setCreator(int creator)
    {
        this.creator = creator;
    }

    public byte getAuthType()
    {
        return authType;
    }

    public void setAuthType(byte authType)
    {
        this.authType = authType;
    }

    public int getOldCategory()
    {
        return oldCategory;
    }

    public void setOldCategory(int oldCategory)
    {
        this.oldCategory = oldCategory;
    }

    public int getCategory()
    {
        return category;
    }

    public void setCategory(int category)
    {
        this.category = category;
    }

    public int getVersionId()
    {
        return versionId;
    }

    public void setVersionId(int versionId)
    {
        this.versionId = versionId;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public String getNotice()
    {
        return notice;
    }

    public void setNotice(String notice)
    {
        this.notice = notice;
    }

    public String getUnknownId()
    {
        return unknownId;
    }

    public void setUnknownId(String unknownId)
    {
        this.unknownId = unknownId;
    }

    public void initMembers(List<Member> members)
    {
        // if (this.members == null)
        // {
        // this.members = new SortList<QQGroupMember>();
        // this.memberMap = new HashMap<Integer, QQGroupMember>();
        // }
        // for (int i = 0; i < members.size(); i++)
        // {
        // QQGroupMember member = new QQGroupMember(members.get(i));
        // this.members.add(member);
        // this.memberMap.put(member.getQQ(), member);
        // }
    }

    public void sortMembers()
    {
    }

    public void setMemberInfos(List<QQFriend> memberInfos)
    {
        for (int i = 0; i < members.size(); i++)
        {
            for (int j = 0; j < memberInfos.size(); j++)
            {
                if (members.get(i).getQQ() == memberInfos.get(j).qqNum)
                {
                    members.get(i).setMemberInfo(memberInfos.get(j));
                    break;
                }
            }
        }
    }

    public List<QQGroupMember> getMembers()
    {
        return members;
    }

    public QQGroupMember getMember(int qq)
    {
        if (memberMap != null)
        {
            return memberMap.get(qq);
        }
        return null;
    }
}

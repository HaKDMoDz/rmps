/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.qq;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;

import edu.tsinghua.lumaqq.qq.QQClient;
import edu.tsinghua.lumaqq.qq.beans.CardStub;
import edu.tsinghua.lumaqq.qq.beans.ContactInfo;
import edu.tsinghua.lumaqq.qq.beans.IMMessage;
import edu.tsinghua.lumaqq.qq.beans.QQFriend;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.events.IQQListener;
import edu.tsinghua.lumaqq.qq.events.QQEvent;
import edu.tsinghua.lumaqq.qq.net.PortGateFactory;
import edu.tsinghua.lumaqq.qq.packets.in.ClusterCommandReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GetFriendListReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GetUserInfoReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GroupDataOpReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.ReceiveIMPacket;
import edu.tsinghua.lumaqq.qq.packets.in.SystemNotificationPacket;
import edu.tsinghua.lumaqq.qq.packets.in._09.LoginGetListReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.out.AddFriendAuthResponsePacket;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class QQ implements IAccount, IQQListener
{
    private Connect connect;
    private List<Session> sessions;
    private QQUser user;
    private QQClient messenger;
    private int loginGetListPosition;
    private List<Catalog> catalogs = new ArrayList<Catalog>();;
    private List<QQGroup> qqGroups;
    private Map<Integer, IContact> contacts = new HashMap<Integer, IContact>(); // 好友QQ号与名称对应Map

    /**
     * 是否获得群信息
     */
    private boolean receiveGroupIm = false;

    public QQ()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IPresence.INIT:
                sessions = new ArrayList<Session>();
                connect = new Connect();
                connect.load();
                user = new QQUser(Integer.parseInt(connect.getUser()), connect.getPwds());
                break;
            case IPresence.SIGN:
                try
                {
                    user.setLoginMode(edu.tsinghua.lumaqq.qq.QQ.QQ_LOGIN_MODE_NORMAL);
                    user.setStatus(edu.tsinghua.lumaqq.qq.QQ.QQ_STATUS_ONLINE);
                    user.setUdp(true);

                    messenger = new QQClient();
                    messenger.setUser(user);
                    messenger.setConnectionPoolFactory(new PortGateFactory());
                    messenger.addQQListener(this);
                    messenger.setLoginServer(connect.getHost());
                    messenger.login();
                }
                catch (Exception exp)
                {
                    System.out.println(exp);
                }
                break;
            case IPresence.LINE:
                break;
            case IPresence.DOWN:
                if (user != null && user.isLoggedIn())
                {
                    messenger.logout();
                }
                messenger.release();
                break;
            default:
                break;
        }
    }

    @Override
    public void exit()
    {
    }

    @Override
    public IConnect getConnect()
    {
        return connect;
    }

    @Override
    public IContact getContact(String user)
    {
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        return null;
    }

    @Override
    public void qqEvent(QQEvent evt)
    {
        switch (evt.type)
        {
            case QQEvent.IM_RECEIVED:
                ReceiveIMPacket packet = (ReceiveIMPacket) evt.getSource();
                String message = parseIMMessage(packet.normalIM.messages);
                Control.getInstance().instantMessageReceived(getSession(""), new Message(message));
                break;

            case QQEvent.SYS_TIMEOUT: // 系统超时
            case QQEvent.LOGIN_UNKNOWN_ERROR: // 登录错误
                logout();
                break;
            case QQEvent.USER_GET_INFO_OK: // 得到用户信息成功
                ContactInfo contactInfo = ((GetUserInfoReplyPacket) evt.getSource()).contactInfo;
                if (contactInfo.qq != user.getQQ())
                {
                    IContact friend = contacts.get(contactInfo.qq);
                    if (friend != null)
                    {
                        ((Contact) friend).setContactInfo(contactInfo);
                    }
                }
                break;
            case QQEvent.FRIEND_GET_GROUP_NAMES_OK: // 下载分组名称成功，发送LoginGetListPacket
                processGroup((GroupDataOpReplyPacket) evt.getSource());
                // 获取好友和群列表
                loginGetListPosition = 1;
                messenger.loginGetList(0);
                break;
            case QQEvent.LOGIN_GET_LIST_OK:
                LoginGetListReplyPacket lp = (LoginGetListReplyPacket) evt.getSource();
                processLoginGetList(lp);
                if (lp.hasMore)
                {
                    messenger.loginGetList(loginGetListPosition++);
                }
                else
                {
                    // 获取好友信息
                    messenger.getFriendList();

                    if (receiveGroupIm)
                    {
                        // 获得群信息
                        getQQGroupsInfo();
                    }
                }
                break;
            case QQEvent.FRIEND_GET_LIST_OK: // 获得好友列表成功
                GetFriendListReplyPacket fp = (GetFriendListReplyPacket) evt.getSource();
                processFriendList(fp);
                if (fp.position != 0xFFFF)
                {
                    messenger.getFriendList(fp.position);
                }
                else
                {
                    // for (int i=0; i<mChildData.size(); i++) {
                    // Collections.sort(mChildData.get(i),
                    // Comparators.getComparator());
                    // }
                    // //获取在线好友列表
                    // client.user_GetOnline();
                    // 获取好友备注
                    messenger.user_GetRemarks(0);
                }

                break;
            // case QQEvent.FRIEND_GET_REMARKS_OK: //得到好友备注
            // hasRemark =
            // ((FriendDataOpReplyPacket)event.getSource()).hasRemark;
            // if (hasRemark) {
            // friendsRemarkPage ++;
            // client.user_GetRemarks(friendsRemarkPage);
            // }
            // sendHandlerMessage(msg);
            // break;
            case QQEvent.CLUSTER_GET_INFO_FAIL:
            case QQEvent.CLUSTER_GET_INFO_OK: // 得到群信息成功
                processClusterInfo((ClusterCommandReplyPacket) evt.getSource());
                break;
            case QQEvent.CLUSTER_GET_MEMBER_INFO_FAIL:
                break;
            case QQEvent.CLUSTER_GET_MEMBER_INFO_OK: // 得到群成员信息成功
                processMemberInfo((ClusterCommandReplyPacket) evt.getSource());
                break;
            case QQEvent.CLUSTER_GET_CARDS_FAIL:
                break;
            case QQEvent.CLUSTER_GET_CARDS_OK: // 批量获得群名片成功
                processGetCardsOK((ClusterCommandReplyPacket) evt.getSource());
                break;
            case QQEvent.CLUSTER_GET_ONLINE_MEMBER_FAIL:
                break;
            case QQEvent.CLUSTER_GET_ONLINE_MEMBER_OK:
                processGetOnlineMember((ClusterCommandReplyPacket) evt.getSource());
                break;
            case QQEvent.USER_KEEP_ALIVE_FAIL: // 保持连接失败
                logout();
                break;
            case QQEvent.SYS_KICKED: // 被系统踢出
                processSysKicked((ReceiveIMPacket) evt.getSource());
                break;
            case QQEvent.IM_SEND_OK: // 消息发送成功
            case QQEvent.USER_KEEP_ALIVE_OK:
                break;
            case QQEvent.SYS_REQUEST_ADD_EX:
                processSysRequestAdd((SystemNotificationPacket) evt.getSource());
                break;
            case QQEvent.FRIEND_AUTH_SEND_OK: // 对方加我好友，我通过并加对方好友
                int qq = ((AddFriendAuthResponsePacket) evt.getSource()).getTo();
                IContact buddy = contacts.get(qq);
                if (buddy == null)
                {
                    buddy = new Contact();
                    contacts.put(qq, buddy);
                }
                messenger.user_Add(qq);
                break;
            // 错误处理
            case QQEvent.ERROR_CONNECTION_BROKEN:
            case QQEvent.ERROR_NETWORK:
            case QQEvent.ERROR_PROXY:
            case QQEvent.ERROR_RUNTIME:
                logout();
                break;
            case QQEvent.IM_CLUSTER_SEND_EX_FAIL:
                break;
            default:
                break;
        }
    }

    private void logout()
    {
    }

    // 处理好友分组的信息
    private void processGroup(GroupDataOpReplyPacket packet)
    {
        List<String> names = packet.groupNames;
        List<Integer> seqs = packet.groupSeqs;
        // 清空原分组信息
        catalogs.clear();
        catalogs.add(new Catalog("0", "我的好友"));
        for (int i = 0; i < names.size(); i++)
        {
            catalogs.add(new Catalog(seqs.get(i).toString(), names.get(i)));
        }
    }

    /**
     * 处理LoginGetList
     * 
     * @param packet
     */
    private void processLoginGetList(LoginGetListReplyPacket packet)
    {
        List<QQFriend> friends = packet.friends;

        catalogs.clear();
        catalogs.add(new Catalog("0", "我的好友"));
        for (QQFriend friend : friends)
        {
            Contact contact = new Contact();
            contact.friend = friend;
            String group = Integer.toString(contact.friend.groupSeq);
            for (Catalog catalog : catalogs)
            {
                if (group.equals(catalog.getId()))
                {
                    contact.addCatalog(catalog);
                    break;
                }
            }
        }

        if (receiveGroupIm)
        {
            // 如果接收群消息
            // List<ClusterInfo> clusters = packet.clusters;
            // for (int i = 0; i < clusters.size(); i++)
            // {
            // mQQGroups.add(IContact);
            // }
        }

    }

    private void getQQGroupsInfo()
    {
        int size = qqGroups.size();
        for (int i = 0; i < size; i++)
        {
            messenger.cluster_GetInfo(qqGroups.get(i).getClusterId(), 0);
        }
    }

    private void processFriendList(GetFriendListReplyPacket fp)
    {
        List<QQFriend> friends = fp.friends;
        for (int i = 0; i < friends.size(); i++)
        {
            QQFriend friend = friends.get(i);

            IContact contact = contacts.get(friend.qqNum);
            if (contact != null)
            {
                ((Contact) contact).setFriendInfo(friend);
            }
        }
    }

    // 处理群信息
    private synchronized void processClusterInfo(ClusterCommandReplyPacket packet)
    {
        if (packet.replyCode == edu.tsinghua.lumaqq.qq.QQ.QQ_REPLY_OK)
        {
            for (int i = 0; i < qqGroups.size(); i++)
            {
                if (qqGroups.get(i).getClusterId() == packet.clusterId)
                {
                    if (packet.info.status == 3)
                    {
                        qqGroups.get(i).setClusterInfo(packet.info);
                    }
                    qqGroups.get(i).initMembers(packet.members);
                    messenger.cluster_GetMemberInfo(packet.clusterId, packet.members);
                    break;
                }
            }
            // 还有更多的群成员
            if (packet.hasMore)
            {
                messenger.cluster_GetInfo(packet.clusterId, packet.nextStart);
            }
            else
            {
                messenger.cluster_GetCardBatch(packet.clusterId, 0);
                messenger.cluster_GetOnlineMember(packet.clusterId);
            }
        }
    }

    // 处理群成员信息
    private synchronized void processMemberInfo(ClusterCommandReplyPacket packet)
    {
        List<QQFriend> memberInfos = packet.memberInfos;
        for (int i = 0; i < qqGroups.size(); i++)
        {
            if (qqGroups.get(i).getClusterId() == packet.clusterId)
            {
                qqGroups.get(i).setMemberInfos(memberInfos);
                break;
            }
        }
    }

    private synchronized void processGetCardsOK(ClusterCommandReplyPacket packet)
    {
        List<CardStub> cards = packet.cardStubs;
        for (int i = 0; i < qqGroups.size(); i++)
        {
            if (qqGroups.get(i).getClusterId() == packet.clusterId)
            {
                QQGroup group = qqGroups.get(i);
                for (int j = 0; j < cards.size(); j++)
                {
                    QQGroupMember member = group.getMember(cards.get(j).qq);
                    if (member != null)
                    {
                        member.setName(cards.get(j).name);
                    }
                }
                break;
            }
        }
        int next = packet.nextStart;
        if (next > 0)
        {
            messenger.cluster_GetCardBatch(packet.clusterId, next);
        }
    }

    private void processGetOnlineMember(ClusterCommandReplyPacket packet)
    {
        List<Integer> online = packet.onlineMembers;

        for (int i = 0; i < qqGroups.size(); i++)
        {
            if (qqGroups.get(i).getClusterId() == packet.clusterId)
            {
                QQGroup IContact = qqGroups.get(i);
                List<QQGroupMember> members = IContact.getMembers();
                for (int j = 0; j < online.size(); j++)
                {
                    QQGroupMember member = IContact.getMember(online.get(j));
                    if (member != null)
                    {
                        int originalState = Integer.parseInt(member.presence.getImc());
                        if (originalState != edu.tsinghua.lumaqq.qq.QQ.QQ_STATUS_ONLINE)
                        {
                            member.presence.setImc(edu.tsinghua.lumaqq.qq.QQ.QQ_STATUS_ONLINE + "");
                            members.remove(member);
                            members.add(member);
                        }
                    }

                }
                break;
            }
        }
    }

    private void processSysKicked(ReceiveIMPacket packet)
    {
        logout();
    }

    private void processSysRequestAdd(SystemNotificationPacket packet)
    {
        // int qq = packet.from;
        // String text = packet.message;
    }

    private String parseIMMessage(List<IMMessage> messages)
    {
        StringBuffer sb = new StringBuffer();
        int size = messages.size();
        for (int i = 0; i < size; i++)
        {
            IMMessage message = messages.get(i);
            switch (message.getType())
            {
                // case 02:
                // sb.append(getResourceString(context, "face"
                // + message.toString()));
                // break;
                default:
                    sb.append(message);
                    break;
            }
        }
        return sb.toString();
    }

    private ISession getSession(String id)
    {
        Session session = sessions.get(0);
        if (session == null)
        {
            session = new Session();
            session.messenger = messenger;
        }
        return session;
    }
}

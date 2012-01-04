/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.qq;

import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.swing.ImageIcon;
import javax.swing.JOptionPane;

import rmp.irp.c.Control;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;

import edu.tsinghua.lumaqq.qq.QQClient;
import edu.tsinghua.lumaqq.qq.Util;
import edu.tsinghua.lumaqq.qq.beans.CardStub;
import edu.tsinghua.lumaqq.qq.beans.ContactInfo;
import edu.tsinghua.lumaqq.qq.beans.FriendOnlineEntry;
import edu.tsinghua.lumaqq.qq.beans.FriendRemark;
import edu.tsinghua.lumaqq.qq.beans.FriendStatus;
import edu.tsinghua.lumaqq.qq.beans.IMMessage;
import edu.tsinghua.lumaqq.qq.beans.QQFriend;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.events.IQQListener;
import edu.tsinghua.lumaqq.qq.events.QQEvent;
import edu.tsinghua.lumaqq.qq.net.PortGateFactory;
import edu.tsinghua.lumaqq.qq.packets.Packet;
import edu.tsinghua.lumaqq.qq.packets.in.AddFriendExReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.AuthInfoOpReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.ClusterCommandReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.FriendChangeStatusPacket;
import edu.tsinghua.lumaqq.qq.packets.in.FriendDataOpReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GetFriendListReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GetOnlineOpReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GetUserInfoReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.GroupDataOpReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in.ReceiveIMPacket;
import edu.tsinghua.lumaqq.qq.packets.in.SystemNotificationPacket;
import edu.tsinghua.lumaqq.qq.packets.in._09.LoginGetListReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in._09.LoginRequestReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.in._09.LoginVerifyReplyPacket;
import edu.tsinghua.lumaqq.qq.packets.out.AddFriendAuthResponsePacket;
import edu.tsinghua.lumaqq.qq.packets.out.AuthInfoOpPacket;
import edu.tsinghua.lumaqq.qq.packets.out.FriendDataOpPacket;

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
    private Map<String, Session> sessions;
    private QQUser user;
    private QQClient messenger;
    private int lastMsgSeq;
    private int friendsRemarkPage;
    private int loginGetListPosition;
    private List<Catalog> catalogs = new ArrayList<Catalog>();;
    private List<QQGroup> qqGroups;
    private Map<String, IContact> contacts = new HashMap<String, IContact>(); // 好友QQ号与名称对应Map

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
                sessions = new HashMap<String, Session>();
                connect = new Connect();
                connect.load();
                user = new QQUser(Integer.parseInt(connect.getUser()), connect.getPwds());
                LogUtil.log("QQ机器人初始化成功！");
                break;
            case IPresence.SIGN:
                try
                {
                    user.setLoginMode(edu.tsinghua.lumaqq.qq.QQ.QQ_LOGIN_MODE_NORMAL);
                    user.setStatus(edu.tsinghua.lumaqq.qq.QQ.QQ_STATUS_QME);
                    user.setUdp(true);

                    messenger = new QQClient();
                    messenger.setUser(user);
                    messenger.setConnectionPoolFactory(new PortGateFactory());
                    messenger.addQQListener(this);
                    messenger.setLoginServer(connect.getHost());
                    messenger.login();
                    LogUtil.log("QQ机器人登录成功！");
                }
                catch (Exception exp)
                {
                    LogUtil.exception(exp);
                }
                break;
            case IPresence.LINE:
                break;
            case IPresence.DOWN:
                logout();
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
    public IContact getContact(String key)
    {
        return contacts.get(key);
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
                processMessageReceived((ReceiveIMPacket) evt.getSource());
                break;
            // 收到一条重复消息
            case QQEvent.IM_DUPLICATED:
                processMessageReceived((ReceiveIMPacket) evt.getSource());
                break;
            // 群消息
            case QQEvent.IM_CLUSTER_RECEIVED:
                break;
            // 消息发送成功
            case QQEvent.IM_SEND_OK:
                break;
            // 登录需要验证
            case QQEvent.LOGIN_NEED_VERIFY:
                processLoginRequestVerify((LoginRequestReplyPacket) evt.getSource());
                break;
            // 登录成功，请求分组列表
            case QQEvent.LOGIN_OK:
                messenger.user_GetGroupNames();
                break;
            case QQEvent.LOGIN_FAIL:
                LoginVerifyReplyPacket vp = (LoginVerifyReplyPacket) evt.getSource();
                LogUtil.log("登录时发生错误：" + vp.replyCode + "：" + vp.replyMessage);
                break;
            case QQEvent.LOGIN_UNKNOWN_ERROR: // 登录错误
                LogUtil.log("登录时发生未知错误");
                logout();
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

                    // 获得群信息
                    if (receiveGroupIm)
                    {
                        getQQGroupsInfo();
                    }
                }
                break;
            // 获得好友列表成功
            case QQEvent.FRIEND_GET_LIST_OK:
                GetFriendListReplyPacket fp = (GetFriendListReplyPacket) evt.getSource();
                processFriendList(fp);
                if (fp.position != 0xFFFF)
                {
                    messenger.getFriendList(fp.position);
                }
                else
                {
                    // 获取在线好友列表
                    // messenger.user_GetOnline();
                    // 获取好友备注
                    // messenger.user_GetRemarks(0);
                }
                break;
            // 得到在线好友列表成功
            case QQEvent.FRIEND_GET_ONLINE_OK:
                processOnlineFriends((GetOnlineOpReplyPacket) evt.getSource());
                break;
            // 得到好友备注成功
            case QQEvent.FRIEND_GET_REMARKS_OK:
                processFriendsRemark((FriendDataOpReplyPacket) evt.getSource());
                break;
            case QQEvent.USER_STATUS_CHANGE_OK:
                LogUtil.log("在线状态登录成功！");
                break;
            // 好友状态变化
            case QQEvent.FRIEND_STATUS_CHANGED:
                processFriendChangeStatus((FriendChangeStatusPacket) evt.getSource());
                break;
            // 好友属性变化
            case QQEvent.FRIEND_PROPERTY_CHANGED:
                break;
            // 得到用户信息成功
            case QQEvent.USER_GET_INFO_OK:
                ContactInfo contactInfo = ((GetUserInfoReplyPacket) evt.getSource()).contactInfo;
                if (contactInfo.qq != user.getQQ())
                {
                    IContact friend = contacts.get(Integer.toString(contactInfo.qq));
                    if (friend != null)
                    {
                        ((Contact) friend).setContactInfo(contactInfo);
                    }
                }
                break;
            // 添加一个好友成功
            case QQEvent.FRIEND_ADD_OK:
                AddFriendExReplyPacket aferp = (AddFriendExReplyPacket) evt.getSource();
                String qqNum = Integer.toString(aferp.friendQQ);
                Contact buddy = (Contact) contacts.get(qqNum);
                if (buddy != null)
                {
                    switch (buddy.presence.getQQS())
                    {
                        // 对方请求加我好友并允许我加对方好友，我提交通过后把对方加好友，这样就不需要发送
                        case edu.tsinghua.lumaqq.qq.QQ.QQ_AUTH_ALREADY:
                            // AuthInfoOpPacket
                            processFriendAddOk(aferp.friendQQ);
                            break;
                        // 我加对方好友，对方允许任意人加好友，需要发送 AuthInfoOpPacket
                        default:
                            processFriendAddGetAuth((AddFriendExReplyPacket) evt.getSource());
                            break;
                    }
                }
                break;
            case QQEvent.FRIEND_ADD_NO_AUTH:
            case QQEvent.FRIEND_ADD_NEED_AUTH:
                processFriendAddGetAuth((AddFriendExReplyPacket) evt.getSource());
                break;
            case QQEvent.FRIEND_GET_AUTH_INFO_OK:
                sendFriendAddAuthInfo((AuthInfoOpReplyPacket) evt.getSource());
                break;
            case QQEvent.FRIEND_GET_AUTH_INFO_FROM_URL:
                processGetAuthInfoFromUrl((AuthInfoOpReplyPacket) evt.getSource());
                break;
            case QQEvent.FRIEND_SUBMIT_AUTO_INFO_OK:
                sendFriendAddAuthInfo((AuthInfoOpReplyPacket) evt.getSource());
                break;
            // 修改备注成功
            case QQEvent.FRIEND_UPLOAD_REMARKS_OK:
                updateBuddyRemark((FriendDataOpPacket) evt.getSource());
                break;
            // 上传好友分组成功
            case QQEvent.FRIEND_UPLOAD_GROUPS_OK:
                break;
            // 下载分组名称成功，发送LoginGetListPacket
            case QQEvent.FRIEND_GET_GROUP_NAMES_OK:
                processGroup((GroupDataOpReplyPacket) evt.getSource());
                // 获取好友和群列表
                loginGetListPosition = 1;
                messenger.loginGetList(0);
                break;
            case QQEvent.USER_KEEP_ALIVE_FAIL: // 保持连接失败
                logout();
                break;
            case QQEvent.CLUSTER_GET_INFO_FAIL:
                break;
            // 得到群信息成功
            case QQEvent.CLUSTER_GET_INFO_OK:
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
            case QQEvent.SYS_REQUEST_ADD_EX:
                processSysRequestAdd((SystemNotificationPacket) evt.getSource());
                break;
            // 对方加我好友，我通过并加对方好友
            case QQEvent.FRIEND_AUTH_SEND_OK:
                AddFriendAuthResponsePacket aarp = (AddFriendAuthResponsePacket) evt.getSource();
                qqNum = Integer.toString(aarp.getTo());
                buddy = (Contact) contacts.get(qqNum);
                if (buddy == null)
                {
                    buddy = new Contact();
                    contacts.put(qqNum, buddy);
                }
                messenger.user_Add(aarp.getTo());
                break;
            case QQEvent.SYS_TIMEOUT: // 系统超时
                Packet p = (Packet) evt.getSource();
                LogUtil.log(p.getPacketName() + " 操作超时");
                break;
            //
            case QQEvent.SYS_APPROVE_ADD_BIDI:
                processFriendAddOk(((SystemNotificationPacket) evt.getSource()).from);
                break;
            case QQEvent.SYS_KICKED: // 被系统踢出
                javax.swing.JOptionPane.showMessageDialog(null, "您被系统踢了，请重新登录QQ！");
                logout();
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
                LogUtil.log("事件代码：0x" + Integer.toHexString(evt.type));
                break;
        }
    }

    private void logout()
    {
        if (user != null && user.isLoggedIn())
        {
            messenger.logout();
        }
        messenger.release();
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
            contact.presence = new Presence();
            contacts.put(Integer.toString(friend.qqNum), contact);
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
        for (QQFriend friend : fp.friends)
        {
            IContact contact = contacts.get(Integer.toString(friend.qqNum));
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
                            member.presence.setQQS(edu.tsinghua.lumaqq.qq.QQ.QQ_STATUS_ONLINE);
                            members.remove(member);
                            members.add(member);
                        }
                    }

                }
                break;
            }
        }
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

    private void processLoginRequestVerify(LoginRequestReplyPacket in)
    {
        try
        {
            javax.swing.JLabel lbl = new javax.swing.JLabel("请输入验证码!", new ImageIcon(in.pngData), javax.swing.SwingConstants.LEFT);
            String code = JOptionPane.showInputDialog(null, lbl, "登录验证", JOptionPane.INFORMATION_MESSAGE);
            messenger.loginRequest(in.answerToken, code.getBytes(), (byte) 0x0);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private ISession getSession(String id)
    {
        Session session = sessions.get(id);
        if (session == null)
        {
            session = new Session();
            session.contact = (Contact) getContact(id);
            session.messenger = messenger;
            sessions.put(id, session);
        }
        return session;
    }

    private synchronized void processOnlineFriends(GetOnlineOpReplyPacket packet)
    {
        for (FriendOnlineEntry entry : packet.onlineFriends)
        {
            FriendStatus status = entry.status;
            changeFriendStatus(Integer.toString(status.qqNum), status.status);
        }
        if (!packet.finished)
        {
            messenger.user_GetOnline(packet.position);
        }
    }

    private void changeFriendStatus(String qq, byte status)
    {
        // 设置分组的在线好友数量
        Contact contact = (Contact) getContact(qq);
        if (contact == null)
        {
            return;
        }

        if (status != contact.presence.getQQS())
        {
            contact.presence.setQQS(status);
            Control.getInstance().contactPresenceChanged(getSession(qq));
        }
    }

    protected synchronized void processFriendsRemark(FriendDataOpReplyPacket packet)
    {
        if (packet.hasRemark)
        {
            messenger.user_GetRemarks(friendsRemarkPage++);
        }

        Map<Integer, FriendRemark> map = packet.remarks;
        for (Integer qq : map.keySet())
        {
            Contact buddy = (Contact) getContact(qq.toString());
            if (buddy != null)
            {
                buddy.setFriendRemark(map.get(qq));
            }
            else
            {
                // TODO 没有找到，加入陌生人
            }
        }
    }

    protected void processFriendChangeStatus(FriendChangeStatusPacket packet)
    {
        String qq = Integer.toString(packet.friendQQ);
        changeFriendStatus(qq, packet.status);
    }

    private void processFriendAddOk(int qq)
    {
        // 上传好友分组
        messenger.user_AddToList(0, qq);
        // 上传备注
        messenger.user_UploadRemark(qq, new FriendRemark());
        // 获取好友信息
        messenger.user_GetInfo(qq);
    }

    private void processFriendAddGetAuth(AddFriendExReplyPacket packet)
    {
        AuthInfoOpPacket p = new AuthInfoOpPacket(user);
        p.setTo(packet.friendQQ);
        p.setSubCommand(edu.tsinghua.lumaqq.qq.QQ.QQ_SUB_CMD_GET_AUTH_INFO);
        String qqNum = Integer.toString(packet.friendQQ);

        Contact buddy = (Contact) contacts.get(qqNum);
        if (buddy == null)
        {
            buddy = new Contact();
            contacts.put(qqNum, buddy);
        }
        // buddy.setVerifyFlag(packet.authCode);

        messenger.sendPacket(p);
    }

    private void sendFriendAddAuthInfo(AuthInfoOpReplyPacket packet)
    {
        final byte[] authInfo = packet.authInfo;

        // 获取qq号
        AuthInfoOpPacket outPacket = (AuthInfoOpPacket) messenger.retrieveSent(packet);
        int qq = outPacket.getTo();

        Contact buddy = (Contact) contacts.get(Integer.toString(qq));
        if (buddy.presence.getQQS() == edu.tsinghua.lumaqq.qq.QQ.QQ_AUTH_NEED)
        {
            messenger.user_SendAuth(qq, authInfo, "机器人小木");
        }
        else if (buddy.presence.getQQS() == edu.tsinghua.lumaqq.qq.QQ.QQ_AUTH_NO)
        {
            messenger.user_SendAuth(qq, authInfo, "");
        }
    }

    private void processGetAuthInfoFromUrl(AuthInfoOpReplyPacket packet)
    {
        try
        {
            String url = Util.getString(packet.authInfo);

            HttpURLConnection conn = (HttpURLConnection) new URL(url).openConnection();
            conn.setDoInput(true);
            conn.connect();
            String sessionId = conn.getHeaderField("getqqsession");

            AuthInfoOpPacket outPacket = (AuthInfoOpPacket) messenger.retrieveSent(packet);
            int qq = outPacket.getTo();
            // 提交验证信息
            AuthInfoOpPacket p = new AuthInfoOpPacket(user);
            p.setSubCommand(edu.tsinghua.lumaqq.qq.QQ.QQ_SUB_CMD_SUBMIT_AUTH_INFO);
            p.setTo(qq);
            p.setAuthString("");
            p.setCookie(sessionId);
            messenger.sendPacket(p);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private void updateBuddyRemark(FriendDataOpPacket packet)
    {
        Contact friend = (Contact) contacts.get(Integer.toString(packet.getQQ()));
        if (friend != null)
        {
            friend.setName(packet.getRemark().name);
        }
    }

    private void processMessageReceived(ReceiveIMPacket packet)
    {
        if (lastMsgSeq == packet.header.sequence)
        {
            return;
        }
        if (packet.normalIM != null)
        {
            lastMsgSeq = packet.header.sequence;
            String message = parseIMMessage(packet.normalIM.messages);
            Control.getInstance().instantMessageReceived(getSession(Integer.toString(packet.header.sender)), new Message(message));
        }
    }
}

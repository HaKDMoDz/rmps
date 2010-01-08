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

import edu.tsinghua.lumaqq.qq.events.QQEvent;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class QQEvents
{
    public static String getQQEventDesc(int type, Object source)
    {
        String message = "";
        switch (type)
        {
            /*
             * Cluster事件，范围0x0000 ~ 0x0FFF
             */
            /*
             * <code>CLUSTER_ACTIVATE_FAIL</code>
             * 在激活一个群失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_ACTIVATE_FAIL:
                message = "激活群失败";
                break;

            /*
             * <code>CLUSTER_ACTIVATE_OK</code>
             * 在激活一个群成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_ACTIVATE_OK:
                message = "激活群成功";
                break;

            /*
             * <code>CLUSTER_ACTIVATE_TEMP_FAIL</code>事件在激活临时群
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_ACTIVATE_TEMP_FAIL:
                message = "激活临时群失败";
                break;

            /*
             * <code>CLUSTER_ACTIVATE_TEMP_OK</code>事件在激活临时群
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_ACTIVATE_TEMP_OK:
                message = "激活临时群成功";
                break;

            /*
             * <code>CLUSTER_ADDED_TO</code>事件在别人把我加为群中成员时发生，别人可以是一开始就
             * 创建了群并我加入到群中，也可以是先创建了群，后来才加的我，反正都是触发这一个事件，source 是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_ADDED_TO:
                message = "加入XX群";
                break;

            /*
             * <code>CLUSTER_ADMIN_ENTITLED</code>事件在群创建者把自己设为管理员时发生,
             * source是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_ADMIN_ENTITLED:
                message = "成为XX群管理员";
                break;

            /*
             * <code>CLUSTER_ADMIN_WITHDRAWED</code>事件在群创建者把自己的管理员身份撤销时发生,
             * source是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_ADMIN_WITHDRAWED:
                message = "撤销管理员身份";
                break;

            /*
             * <code>CLUSTER_APPROVE_JOIN</code>事件发生在别人同意了我加入他创建的群时，
             * source是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_APPROVE_JOIN:
                message = "通过加入群请求";
                break;

            /*
             * <code>CLUSTER_AUTH_SEND_FAIL</code>在加入群认证信息失败时发生，source
             * 是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_AUTH_SEND_FAIL:
                message = "加入群认证信息失败";
                break;

            /*
             * <code>CLUSTER_AUTH_SEND_OK</code>在发送群认证信息成功时发生，source
             * 是ClusterCommandReplyPacket，这只是一个简单的服务器确认事件，表示认证信息已经被
             * 服务器收到，并非认证已经通过，所以是send success
             */
            case QQEvent.CLUSTER_AUTH_SEND_OK:
                message = "发送群认证信息成功";
                break;

            /*
             * <code>QQ_COMMIT_MEMBER_ORGANIZATON_FAIL</code>事件在提交成员分组
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_COMMIT_MEMBER_ORG_FAIL:
                message = "提交成员分组失败";
                break;

            /*
             * <code>CLUSTER_COMMIT_MEMBER_ORG_OK</code>事件在提交成员分组
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_COMMIT_MEMBER_ORG_OK:
                message = "提交成员分组成功";
                break;

            /*
             * <code>CLUSTER_COMMIT_ORG_FAIL</code>事件在提交组织架构失败时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_COMMIT_ORG_FAIL:
                message = "在提交组织架构失败";
                break;

            /*
             * <code>CLUSTER_COMMIT_ORG_OK</code>事件在提交组织架构成功时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_COMMIT_ORG_OK:
                message = "提交组织架构成功";
                break;

            /*
             * <code>CLUSTER_CREATE_FAIL</code>
             * 在创建一个群失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_CREATE_FAIL:
                message = "创建群失败";
                break;

            /*
             * <code>CLUSTER_CREATE_OK</code>
             * 在创建一个群成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_CREATE_OK:
                message = "创建群成功";
                break;

            /*
             * <code>CLUSTER_CREATE_TEMP_FAIL</code>事件在创建临时群
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_CREATE_TEMP_FAIL:
                message = "创建临时群失败";
                break;

            /*
             * <code>CLUSTER_CREATE_TEMP_OK</code>事件在创建临时群
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_CREATE_TEMP_OK:
                message = "创建临时群成功";
                break;

            /*
             * <code>CLUSTER_DISMISS_FAIL</code>在解散群失败时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_DISMISS_FAIL:
                message = "解散群失败";
                break;

            /*
             * <code>CLUSTER_DISMISS_OK</code>在解散群成功时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_DISMISS_OK:
                message = "解散群成功";
                break;

            /*
             * <code>CLUSTER_EXIT_FAIL</code>在退出群失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_EXIT_FAIL:
                message = "退出群失败";
                break;

            /*
             * <code>CLUSTER_EXIT_OK</code>在退出群成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_EXIT_OK:
                message = "退出群成功";
                break;

            /*
             * <code>CLUSTER_EXIT_TEMP_FAIL</code>事件在退出临时群
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_EXIT_TEMP_FAIL:
                message = "退出临时群失败";
                break;

            /*
             * <code>CLUSTER_EXIT_TEMP_OK</code>事件在退出临时群
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_EXIT_TEMP_OK:
                message = "退出临时群成功";
                break;

            /*
             * <code>CLUSTER_GET_CARD_FAIL</code>事件在得到单个成员群名片
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_CARD_FAIL:
                message = "得到单个成员群名片失败";
                break;

            /*
             * <code>CLUSTER_GET_CARD_OK</code>事件在得到单个成员群名片
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_CARD_OK:
                message = "得到单个成员群名片成功";
                break;

            /*
             * <code>CLUSTER_GET_CARDS_FAIL</code>事件在批量得到群名片
             * 真实姓名失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_CARDS_FAIL:
                message = "批量得到群名片真实姓名失败";
                break;

            /*
             * <code>CLUSTER_GET_CARDS_OK</code>事件在批量得到群名片
             * 真实姓名成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_CARDS_OK:
                message = "批量得到群名片真实姓名成功";
                break;

            /*
             * <code>CLUSTER_GET_INFO_FAIL</code>
             * 在得到群信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_INFO_FAIL:
                message = "得到群信息失败";
                break;

            /*
             * <code>CLUSTER_GET_INFO_OK</code>
             * 在得到群信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_INFO_OK:
                message = "得到群信息成功";
                break;

            /*
             * <code>CLUSTER_GET_MEMBER_INFO_FAIL</code>
             * 在得到群成员信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_MEMBER_INFO_FAIL:
                message = "得到群成员信息失败";
                break;

            /*
             * <code>CLUSTER_GET_MEMBER_INFO_OK</code>
             * 在得到群成员信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_MEMBER_INFO_OK:
                message = "得到群成员信息成功";
                break;

            /*
             * <code>CLUSTER_GET_ONLINE_MEMBER_FAIL</code>
             * 在得到在线群成员失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_ONLINE_MEMBER_FAIL:
                message = "得到在线群成员失败";
                break;

            /*
             * <code>CLUSTER_GET_ONLINE_MEMBER_OK</code>
             * 在得到在线群成员成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_ONLINE_MEMBER_OK:
                message = "得到在线群成员成功";
                break;

            /*
             * <code>CLUSTER_GET_TEMP_INFO_FAIL</code>事件在得到临时群
             * 信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_TEMP_INFO_FAIL:
                message = "得到临时群信息失败";
                break;

            /*
             * <code>CLUSTER_GET_TEMP_INFO_OK</code>事件在得到临时群
             * 信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_GET_TEMP_INFO_OK:
                message = "得到临时群信息成功";
                break;

            /*
             * <code>CLUSTER_JOIN</code>事件发生在有人想加入我创建的群时，source是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_JOIN:
                message = "收到加入群请求";
                break;

            /*
             * <code>CLUSTER_JOIN_DENY</code>在我申请加入群，但是这个群禁止加入成员时发生，source是
             * ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_JOIN_DENY:
                message = "申请加入群，但是这个群禁止加入成员时";
                break;

            /*
             * <code>CLUSTER_JOIN_FAIL</code>在加入群失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_JOIN_FAIL:
                message = "加入群失败时";
                break;

            /*
             * <code>CLUSTER_JOIN_NEED_AUTH</code>在我申请加入群，但是这个群需要认证时发生，source
             * 是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_JOIN_NEED_AUTH:
                message = "申请加入群，但是这个群需要认证";
                break;

            /*
             * <code>CLUSTER_JOIN_OK</code>在加入群成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_JOIN_OK:
                message = "加入群成功";
                break;

            /*
             * <code>CLUSTER_MODIFY_CARD_FAIL</code>事件在修改群名片
             * 信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_CARD_FAIL:
                message = "修改群名片信息失败";
                break;

            /*
             * <code>CLUSTER_MODIFY_CARD_OK</code>事件在修改群名片
             * 信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_CARD_OK:
                message = "修改群名片信息成功";
                break;

            /*
             * <code>CLUSTER_MODIFY_INFO_FAIL</code>
             * 在修改群信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_INFO_FAIL:
                message = "修改群信息失败";
                break;

            /*
             * <code>CLUSTER_MODIFY_INFO_OK</code>
             * 在修改群信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_INFO_OK:
                message = "修改群信息成功";
                break;

            /*
             * <code>CLUSTER_MODIFY_MEMBER_FAIL</code>事件发生在修改群成员列表失败时，其
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_MEMBER_FAIL:
                message = "修改群成员列表失败";
                break;

            /*
             * <code>CLUSTER_MODIFY_MEMBER_OK</code>事件发生在修改群成员列表成功时，
             * 其source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_MEMBER_OK:
                message = "修改群成员列表成功";
                break;

            /*
             * <code>CLUSTER_MODIFY_TEMP_INFO_FAIL</code>事件在修改临时群
             * 信息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_TEMP_INFO_FAIL:
                message = "修改临时群信息失败";
                break;

            /*
             * <code>CLUSTER_MODIFY_TEMP_INFO_OK</code>事件在修改临时群
             * 信息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_TEMP_INFO_OK:
                message = "修改临时群信息成功";
                break;

            /*
             * <code>CLUSTER_MODIFY_TEMP_MEMBER_FAIL</code>事件在修改临时群成员
             * 失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_TEMP_MEMBER_FAIL:
                message = "修改临时群成员失败";
                break;

            /*
             * <code>CLUSTER_MODIFY_TEMP_MEMBER_OK</code>事件在修改临时群成员
             * 成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_MODIFY_TEMP_MEMBER_OK:
                message = "修改临时群成员成功";
                break;

            /*
             * <code>CLUSTER_REJECT_JOIN</code>事件发生在别人拒绝了我加入他创建的群时，
             * source是ReceiveIMPacket
             */
            case QQEvent.CLUSTER_REJECT_JOIN:
                message = "别人拒绝了我加入他创建的群";
                break;

            /*
             * <code>CLUSTER_REMOVED_FROM</code>事件在群的创建者把我删除后发生，
             * source是ReceiveIMPacket。这个事件会在某个人退出群后，或者管理员删除某个人后
             * 发生，在第一种情况下，这个事件传达给管理员，在第二种情况下，这个事件传达给这个用户。 所以，必须判断包中的sender
             * QQ号，如果等于自己的QQ号，说明是自己被删除了，如果不 等于，说明我自己是管理员，有个成员主动退出了
             */
            case QQEvent.CLUSTER_REMOVED_FROM:
                message = "群的创建者把我删除";
                break;

            /*
             * <code>CLUSTER_SEARCH_FAIL</code>事件在搜索群失败时发生，这也许是搜索出错，也许是没有搜到
             * 任何结果等等，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_SEARCH_FAIL:
                message = "搜索群失败";
                break;

            /*
             * <code>CLUSTER_SEARCH_OK</code>
             * 事件在搜索群成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_SEARCH_OK:
                message = "搜索群成功";
                break;

            /*
             * <code>CLUSTER_SET_ROLE_FAIL</code>事件在群创建者设置管理员失败时发生,
             * source是ClusterCommandReplyPacket这个事件不一定是针对自己的，需要 检查接收者是否为自己
             */
            case QQEvent.CLUSTER_SET_ROLE_FAIL:
                message = "群创建者设置管理员失败";
                break;

            /*
             * <code>CLUSTER_SET_ROLE_OK</code>事件在群创建者设置管理员成功时发生,
             * source是ClusterCommandReplyPacket，这个事件不一定是针对自己的，需要 检查接收者是否为自己
             */
            case QQEvent.CLUSTER_SET_ROLE_OK:
                message = "群创建者设置管理员成功";
                break;

            /*
             * <code>QQ_GET_SUBJECT_LIST_FAIL</code>事件在子群操作失败时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_SUB_OP_FAIL:
                message = "子群操作失败";
                break;

            /*
             * <code>QQ_GET_SUBJECT_LIST_SUCCESS</code>事件在子群操作成功时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_SUB_OP_OK:
                message = "子群操作成功";
                break;

            /*
             * <code>CLUSTER_TRANSFER_ROLE_FAIL</code>事件在群创建者转让身份失败时发生,
             * source是ClusterCommandReplyPacket, 这个事件不一定是针对自己的，需要 检查接收者是否为自己
             */
            case QQEvent.CLUSTER_TRANSFER_ROLE_FAIL:
                message = "群创建者转让身份失败";
                break;

            /*
             * <code>CLUSTER_TRANSFER_ROLE_OK</code>事件在群创建者转让身份成功时发生,
             * source是ClusterCommandReplyPacket, 这个事件不一定是针对自己的，需要 检查接收者是否为自己
             */
            case QQEvent.CLUSTER_TRANSFER_ROLE_OK:
                message = "群创建者转让身份成功";
                break;

            /*
             * <code>CLUSTER_UPDATE_ORG_FAIL</code>事件在更新组织架构失败时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_UPDATE_ORG_FAIL:
                message = "更新组织架构失败";
                break;

            /*
             * <code>CLUSTER_UPDATE_ORG_OK</code>事件在更新组织架构成功时发生，
             * source是ClusterCommandReplyPacket
             */
            case QQEvent.CLUSTER_UPDATE_ORG_OK:
                message = "更新组织架构成功";
                break;

            /*
             * 错误事件，0x1000 ~ 0x1FFF
             */

            /*
             * <code>ERROR_CONNECTION_BROKEN</code>事件发生在连接被远程关闭时,
             * Source是ErrorPacket
             */
            case QQEvent.ERROR_CONNECTION_BROKEN:
                message = "连接被远程关闭";
                break;

            /*
             * <code>ERROR_NETWORK</code>事件在网络出错时发生，和QQ协议本身没有关系，其Source为
             * ErrorPacket
             */
            case QQEvent.ERROR_NETWORK:
                message = "网络出错";
                break;

            /*
             * <code>ERROR_PROXY</code>事件是一个代理事件，和QQ协议本身没有关系，其在代理发生错误时触发，
             * 其Source是ErrorPacket
             */
            case QQEvent.ERROR_PROXY:
                message = "代理发生错误";
                break;

            /*
             * <code>ERROR_RUNTIME</code>事件在发生运行时错误时触发，和QQ协议本身没有关系，其Source为
             * ErrorPacket。其portName为空，不可用。其errorMessage为崩溃报告。
             */
            case QQEvent.ERROR_RUNTIME:
                message = "生运行时错误";
                break;

            /*
             * 文件传输事件，0x2000 ~ 0x2FFF
             */

            /*
             * <code>FILE_ACCEPT</code>事件在对方接受了自己的传输文件请求时发生，source是ReceiveIMPacket
             * ， 接到这个包就可以抽出好友的端口开始初始化连接了
             */
            case QQEvent.FILE_ACCEPT:
                message = "对方接受了自己的传输文件请求";
                break;

            /*
             * <code>FILE_CANCEL</code>在用户取消传送文件操作时发生，source是ReceiveIMPacket
             */
            case QQEvent.FILE_CANCEL:
                message = "用户取消传送文件操作";
                break;

            /*
             * <code>FILE_FACE_DATA_RECEIVED</code>事件在接收到表情文件数据时发生，source
             * 是TransferReplyPacket
             */
            case QQEvent.FILE_FACE_DATA_RECEIVED:
                message = "接收到表情文件数据";
                break;

            /*
             * <code>FILE_FACE_INFO_RECEIVED</code>事件在接收到表情文件信息时发生，source
             * 是TransferReplyPacket
             */
            case QQEvent.FILE_FACE_INFO_RECEIVED:
                message = "接收到表情文件信息";
                break;

            /*
             * <code>FILE_NOTIFY_ARGS</code>在发送文件方通知另一方其IP和端口信息时发生，
             * source是ReceiveIMPacket
             */
            case QQEvent.FILE_NOTIFY_ARGS:
                message = "发送文件方通知另一方其IP和端口信息";
                break;

            /*
             * <code>FILE_REJECT</code>事件在对方拒绝了自己的传输文件请求时发生，source是ReceiveIMPacket
             */
            case QQEvent.FILE_REJECT:
                message = "对方拒绝了自己的传输文件请求";
                break;

            /*
             * <code>FILE_REQUEST_AGENT_FAIL</code>事件在请求中转服务器成功时发生，source
             * 是RequestAgentReplyPacket
             */
            case QQEvent.FILE_REQUEST_AGENT_FAIL:
                message = "请求中转服务器成功";
                break;

            /*
             * <code>QQ_REQUEST_AGENT_OK</code>事件在请求中转服务器成功时发生，source
             * 是RequestAgentReplyPacket
             */
            case QQEvent.FILE_REQUEST_AGENT_OK:
                message = "请求中转服务器成功";
                break;

            /*
             * <code>FILE_REQUEST_AGENT_REDIRECT</code>事件在请求中转服务器重定向时发生，source
             * 是RequestAgentReplyPacket
             */
            case QQEvent.FILE_REQUEST_AGENT_REDIRECT:
                message = "在请求中转服务器重定向";
                break;

            /*
             * <code>FILE_REQUEST_BEGIN_OK</code>事件在请求开始传送成功时
             * 发生，source是RequestBeginReplyPacket
             */
            case QQEvent.FILE_REQUEST_BEGIN_OK:
                message = "请求开始传送成功";
                break;

            /*
             * <code>FILE_REQUEST_FACE_OK</code>事件在请求自定义表情文件成功时发生，
             * source是RequestFaceReplyPacket
             */
            case QQEvent.FILE_REQUEST_FACE_OK:
                message = "请求自定义表情文件成功";
                break;

            /*
             * <code>FILE_REQUEST_ME_CONNECT</code>发生在文件传输的连接建立过程完成时，source
             * 是ReceiveIMPacket
             */
            case QQEvent.FILE_REQUEST_ME_CONNECT:
                message = "文件传输的连接建立过程完成";
                break;

            /*
             * <code>FILE_REQUEST_SEND_TO_ME</code>
             * 事件发生在对方请求向我传送文件时，source是ReceiveIMPacket
             */
            case QQEvent.FILE_REQUEST_SEND_TO_ME:
                message = "对方请求向我传送文件";
                break;

            /*
             * <code>FILE_SEND_REQUEST_OK</code>事件在传送文件请求发送成功时发生，source是
             * SendIMPacket
             */
            case QQEvent.FILE_SEND_REQUEST_OK:
                message = "传送文件请求发送成功";
                break;

            /*
             * <code>QQ_TRANSFER_FACE_INFO_SUCCESS</code>事件在传送表情文件信息或数据成功时
             * 发生，source是TransferReplyPacket。到底是对信息的回复还是对数据的回复，需要判断 包中的session
             * id，如果和当前session id相同，则是对信息的回复，否则是对数据的回复
             */
            case QQEvent.FILE_TRANSFER_FACE_OK:
                message = "传送表情文件信息或数据成功";
                break;

            /*
             * 好友事件，0x3000 ~ 0x3FFF
             */

            /*
             * <code>FRIEND_ADD_ALREADY</code>事件发生在我添加一个好友，但是
             * 对方已经是我的好友，source是AddFriendExReplyPacket
             */
            case QQEvent.FRIEND_ADD_ALREADY:
                message = "我添加一个好友，但是对方已经是我的好友";
                break;

            /*
             * <code>FRIEND_ADD_DENY</code>事件发生在我添加一个好友，但是对方设置了
             * 禁止别人把我添加为好友，source是AddFriendExReplyPacket
             */
            case QQEvent.FRIEND_ADD_DENY:
                message = "我添加一个好友，但是对方设置了禁止别人把我添加为好友";
                break;

            /*
             * <code>FRIEND_ADD_FAIL</code>事件发生在请求信息发送失败时，source是AddFriendExPacket
             */
            case QQEvent.FRIEND_ADD_FAIL:
                message = "请求信息发送失败";
                break;

            /*
             * <code>FRIEND_ADD_NEED_AUTH</code>事件发生在我添加一个好友，但是对方需要认证时，
             * source是AddFriendExReplyPacket
             */
            case QQEvent.FRIEND_ADD_NEED_AUTH:
                message = "我添加一个好友，但是对方需要认证";
                break;

            /*
             * <code>FRIEND_ADD_OK</code>事件发生在我添加一个好友成功时，
             * source是AddFriendExReplyPacket
             */
            case QQEvent.FRIEND_ADD_OK:
                message = "我添加一个好友成功";
                break;

            /*
             * <code>FRIEND_AUTH_SEND_FAIL</code>事件在你发送认证信息给别人失败时发生，
             * source是AddFriendAuthResponsePacket
             */
            case QQEvent.FRIEND_AUTH_SEND_FAIL:
                message = "发送认证信息给别人失败";
                break;

            /*
             * <code>FRIEND_AUTH_SEND_OK</code>事件在你发送认证信息给别人成功时发生，
             * source是AddFriendAuthResponsePacket
             * ，注意不是AddFriendAuthReplyPacket，这个包没用
             */
            case QQEvent.FRIEND_AUTH_SEND_OK:
                message = "发送认证信息给别人成功";
                break;

            /*
             * <code>FRIEND_AUTHORIZE_SEND_FAIL</code>在验证消息发送失败时发生，
             * source是AuthorizeReplyPacket
             */
            case QQEvent.FRIEND_AUTHORIZE_SEND_FAIL:
                message = "验证消息发送失败";
                break;

            /*
             * <code>FRIEND_AUTHORIZE_SEND_OK</code>在验证消息发送成功时发生，
             * source是AuthorizeReplyPacket
             */
            case QQEvent.FRIEND_AUTHORIZE_SEND_OK:
                message = "验证消息发送成功";
                break;

            /*
             * <code>FRIEND_CUSTOM_HEAD_CHANGED</code>收到好友自定义头像变化通知时
             * 发生，source是ReceiveIMPacket
             */
            case QQEvent.FRIEND_CUSTOM_HEAD_CHANGED:
                message = "收到好友自定义头像变化通知";
                break;

            /*
             * <code>FRIEND_DELETE_FAIL</code>事件在删除好友失败是发生，
             * source是DeleteFriendPacket
             */
            case QQEvent.FRIEND_DELETE_FAIL:
                message = "删除好友失败";
                break;

            /*
             * <code>FRIEND_DELETE_OK</code>事件在删除好友成功时发生，
             * source是DeleteFriendPacket，注意不是DeleteFriendReplyPacket，
             * 因为Reply包毫无价值
             */
            case QQEvent.FRIEND_DELETE_OK:
                message = "删除好友成功";
                break;

            /*
             * <code>FRIEND_DOWNLOAD_GROUPS_FAIL</code>事件在下载分组中的好友列表失败时发生，source是
             * DownloadGroupFriendReplyPacket
             */
            case QQEvent.FRIEND_DOWNLOAD_GROUPS_FAIL:
                message = "下载分组中的好友列表失败";
                break;

            /*
             * <code>FRIEND_DOWNLOAD_GROUPS_OK</code>事件在下载分组中的好友列表成功时发生，source是
             * DownloadGroupFriendReplyPacket
             */
            case QQEvent.FRIEND_DOWNLOAD_GROUPS_OK:
                message = "下载分组中的好友列表成功";
                break;

            /*
             * <code>FRIEND_GET_GROUP_NAMES_OK</code>
             * 事件在下载分组名称成功时发生，source是GroupNameOpReplyPacket
             */
            case QQEvent.FRIEND_GET_GROUP_NAMES_OK:
                message = "下载分组名称成功";
                break;

            /*
             * <code>FRIEND_GET_LEVEL_OK</code>事件在得到用户级别成功时发生，
             * source是FriendLevelOpPacket
             */
            case QQEvent.FRIEND_GET_LEVEL_OK:
                message = "得到用户级别成功";
                break;

            /*
             * <code>FRIEND_GET_LIST_OK</code>事件发生在得到好友列表成功
             * 时，source是GetFriendListReplyPacket，需要检查回复包的标志来判断是否 还有更多好友需要得到
             */
            case QQEvent.FRIEND_GET_LIST_OK:
                message = "得到好友列表成功";
                break;

            /*
             * <code>FRIEND_GET_ONLINE_OK</code>事件在得到在线好友列表成功时发生，source是
             * GetOnlineOpReplyPacket，用户应该检查position字段判断是否还有更多在线好友
             */
            case QQEvent.FRIEND_GET_ONLINE_OK:
                message = "得到在线好友列表成功";
                break;

            /*
             * <code>FRIEND_GET_REMARK_OK</code>在下载好友备注信息成功时发生，source是
             * FriendDataOpReplyPacket
             */
            case QQEvent.FRIEND_GET_REMARK_OK:
                message = "下载好友备注信息成功";
                break;

            /*
             * <code>FRIEND_GET_REMARKS_OK</code>在批量下载好友备注信息成功时发生，source是
             * FriendDataOpReplyPacket
             */
            case QQEvent.FRIEND_GET_REMARKS_OK:
                message = "批量下载好友备注信息成功";
                break;

            /*
             * <code>FRIEND_PROPERTY_CHANGED</code>收到好友属性变化通知时
             * 发生，source是ReceiveIMPacket
             */
            case QQEvent.FRIEND_PROPERTY_CHANGED:
                message = "收到好友属性变化通知";
                break;

            /*
             * <code>FRIEND_REMOVE_FROM_LIST_OK</code>在把好友从服务器端列表
             * 中删除成功时发生，source是FriendDataOpPacket
             */
            case QQEvent.FRIEND_REMOVE_FROM_LIST_OK:
                message = "把好友从服务器端列表中删除成功";
                break;

            /*
             * <code>FRIEND_REMOVE_SELF_FAIL</code>事件在把自己从别人的好友列表中删除失败时发生，
             * source是RemoveSelfReplyPacket，不过没什么用
             */
            case QQEvent.FRIEND_REMOVE_SELF_FAIL:
                message = "把自己从别人的好友列表中删除失败";
                break;

            /*
             * <code>FRIEND_REMOVE_SELF_OK</code>事件在把自己从别人的好友列表中删除成功时发生，
             * source是RemoveSelfReplyPacket，不过没什么用
             */
            case QQEvent.FRIEND_REMOVE_SELF_OK:
                message = "把自己从别人的好友列表中删除成功";
                break;

            /*
             * <code>FRIEND_SIGNATURE_CHANGED</code>事件在收到系统的个性签名改变通知时发生，
             * source是ReceiveIMPacket
             */
            case QQEvent.FRIEND_SIGNATURE_CHANGED:
                message = "系统的个性签名改变";
                break;

            /*
             * <code>FRIEND_STATUS_CHANGED</code>
             * 事件发生在某个好友的状态改变时，source是FriendChangeStatusPacket
             */
            case QQEvent.FRIEND_STATUS_CHANGED:
                message = "好友的状态改变";
                break;

            /*
             * <code>FRIEND_UPDATE_GROUP_NAMES_OK</code>
             * 事件在上传分组名称成功时发生，source是GroupNameOpReplyPacket, 但是基本没有什么可用信息，通知事件而已
             */
            case QQEvent.FRIEND_UPDATE_GROUP_NAMES_OK:
                message = "上传分组名称成功";
                break;

            /*
             * <code>FRIEND_UPLOAD_GROUPS_FAIL</code>事件在上传分组好友列表失败时发生，source是
             * UploadGroupFriendReplyPacket，通知事件而已
             */
            case QQEvent.FRIEND_UPLOAD_GROUPS_FAIL:
                message = "上传分组好友列表失败";
                break;

            /*
             * <code>FRIEND_UPLOAD_GROUPS_OK</code>事件在上传分组中的好友列表成功时发生，source是
             * UploadGroupFriendPacket，不过没有什么可用信息，通知事件而已
             */
            case QQEvent.FRIEND_UPLOAD_GROUPS_OK:
                message = "上传分组中的好友列表成功";
                break;

            /*
             * <code>FRIEND_UPLOAD_REMARKS_OK</code>在上传好友备注信息成功时发生，source是
             * FriendDataOpPacket
             */
            case QQEvent.FRIEND_UPLOAD_REMARKS_OK:
                message = "上传好友备注信息成功";
                break;

            /*
             * <code>FRIEND_GET_AUTH_INFO_OK</code>
             * 事件在得到验证信息成功后发生，source是AuthInfoOpReplyPacket
             */
            case QQEvent.FRIEND_GET_AUTH_INFO_OK:
                message = "得到验证信息成功";
                break;

            /*
             * <code>FRIEND_GET_AUTH_INFO_FROM_URL</code>在请求验证信息后发生，表明验证码图片需要从一个url获取
             * , source是AuthInfoOpReplyPacket
             */
            case QQEvent.FRIEND_GET_AUTH_INFO_FROM_URL:
                message = "请求验证信息";
                break;

            /*
             * <code>FRIEND_SUBMIT_AUTO_INFO_OK</code>
             * 在c后发生，source是AuthInfoOpReplyPacket
             */
            case QQEvent.FRIEND_SUBMIT_AUTO_INFO_OK:
                message = "请求验证信息";
                break;

            /*
             * <code>FRIEND_SUBMIT_AUTO_INFO_FAIL</code>
             * 事件在提交验证信息失败后发生，source是AuthInfoOpReplyPacket
             */
            case QQEvent.FRIEND_SUBMIT_AUTO_INFO_FAIL:
                message = "提交验证信息失败";
                break;

            /*
             * <cdoe>FRIEND_GET_AUTH_QUESTION_OK</code>事件在得到认证问题成功时发生，
             * source是AuthQuestionOpReplyPacket
             */
            case QQEvent.FRIEND_GET_AUTH_QUESTION_OK:
                message = "得到认证问题成功";
                break;

            /*
             * <code>FRIEND_GET_AUTH_QUESTION_FAIL</code>
             * 事件在得到认证问题失败时发生，source是AuthQuestionOpReplyPacket
             */
            case QQEvent.FRIEND_GET_AUTH_QUESTION_FAIL:
                message = "得到认证问题失败";
                break;

            /*
             * <code>FRIEND_WRONG_ANSWER</code>
             * 事件在认证问题回答错误时发生，source是AuthQuestionOpReplyPacket
             */
            case QQEvent.FRIEND_WRONG_ANSWER:
                message = "认证问题回答错误";
                break;

            /*
             * <code>FRIEND_RIGHT_ANSWER</code>
             * 事件在认证问题回答正确时发生，source是AuthQuestionOpReplyPacket
             */
            case QQEvent.FRIEND_RIGHT_ANSWER:
                message = "认证问题回答正确";
                break;

            /*
             * IM事件, 0x4000 ~ 0x4FFF
             */

            /*
             * <code>IM_CLUSTER_RECEIVED</code>在收到一条固定群消息时发生，source是ReceiveIMPacket
             */
            case QQEvent.IM_CLUSTER_RECEIVED:
                message = "收到一条固定群消息";
                break;

            /*
             * <code>IM_CLUSTER_SEND_EX_FAIL</code>事件在发送扩展群消息失败时
             * 发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.IM_CLUSTER_SEND_EX_FAIL:
                message = "发送扩展群消息失败";
                break;

            /*
             * <code>IM_CLUSTER_SEND_EX_OK</code>事件在发送扩展群消息成功时
             * 发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.IM_CLUSTER_SEND_EX_OK:
                message = "发送扩展群消息成功";
                break;

            /*
             * <code>IM_DUPLICATED</code>事件在收到一个重复的消息时发生，其source是
             * ReceiveIMPacket。添加这个事件是为了解决有些消息的回复服务器收不到的问题
             */
            case QQEvent.IM_DUPLICATED:
                message = "收到一个重复的消息";
                break;

            /*
             * <code>IM_RECEIVED</code>事件在收到一个普通消息是发生， source是ReceiveIMPacket
             */
            case QQEvent.IM_RECEIVED:
                message = "收到一个普通消息";
                break;

            /*
             * <code>IM_SEND_OK</code>事件在发送消息成功时发生，表示消息已经成功发送，source是
             * SendIMPacket，注意不是SendIMReplyPacket，这个没什么用
             */
            case QQEvent.IM_SEND_OK:
                message = "发送消息成功";
                break;

            /*
             * <code>IM_TEMP_CLUSTER_RECEIVED</code>事件在收到一条临时群消息时发生，source
             * 是ReceiveIMPacket
             */
            case QQEvent.IM_TEMP_CLUSTER_RECEIVED:
                message = "收到一条临时群消息";
                break;

            /*
             * <code>IM_TEMP_CLUSTER_SEND_FAIL</code>事件在发送临时群
             * 消息失败时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.IM_TEMP_CLUSTER_SEND_FAIL:
                message = "发送临时群消息";
                break;

            /*
             * <code>IM_TEMP_CLUSTER_SEND_OK</code>事件在发送临时群
             * 消息成功时发生，source是ClusterCommandReplyPacket
             */
            case QQEvent.IM_TEMP_CLUSTER_SEND_OK:
                message = "发送临时群消息成功";
                break;

            /*
             * <code>IM_TEMP_SESSION_RECEIVED</code>事件在收到一条临时会话消息时发生，
             * source是ReceiveIMPacket
             */
            case QQEvent.IM_TEMP_SESSION_RECEIVED:
                message = "收到一条临时会话消息";
                break;

            /*
             * <code>IM_TEMP_SESSION_SEND_FAIL</code>在发送临时会话消息失败时
             * 发生，其source是TempSessionOpReplyPacket
             */
            case QQEvent.IM_TEMP_SESSION_SEND_FAIL:
                message = "发送临时会话消息失败";
                break;

            /*
             * <code>IM_TEMP_SESSION_SEND_OK</code>在发送临时会话消息成功时
             * 发生，其source是TempSessionOpReplyPacket
             */
            case QQEvent.IM_TEMP_SESSION_SEND_OK:
                message = "发送临时会话消息成功";
                break;

            /*
             * <code>IM_UNKNOWN_CLUSTER_TYPE_RECEIVED</code>事件在收到一条未知类型群消息时发生，
             * source是ReceiveIMPacket
             */
            case QQEvent.IM_UNKNOWN_CLUSTER_TYPE_RECEIVED:
                message = "收到一条未知类型群消息";
                break;

            /*
             * <code>IM_UNKNOWN_TYPE_RECEIVED</code>
             * 表示收到了一条目前我不能处理的消息，sourc是ReceiveIMPacket
             */
            case QQEvent.IM_UNKNOWN_TYPE_RECEIVED:
                message = "收到了一条目前我不能处理的消息";
                break;

            /*
             * 登录事件，0x5000 ~ 0x5FFF
             */

            /*
             * <code>QQ_LOGIN_ERROR</code>事件在登录错误时发生，Source是LoginReplyPacket
             */
            case QQEvent.LOGIN_FAIL:
                message = "登录错误";
                break;

            /*
             * <code>LOGIN_GET_TOKEN_FAIL</code>事件在请求得到登录令牌失败时发生，源是
             * GetLoginTokenReplyPacket
             */
            case QQEvent.LOGIN_GET_TOKEN_FAIL:
                message = "请求得到登录令牌失败";
                break;

            /*
             * <code>LOGIN_GET_TOKEN_OK</code>事件在请求得到登录令牌成功时发生，源是
             * GetLoginTokenReplyPacket
             */
            case QQEvent.LOGIN_GET_TOKEN_OK:
                message = "请求得到登录令牌成功";
                break;

            /*
             * <code>LOGIN_NEED_VERIFY</code>事件在请求得到登录令牌需要输入验证码时发生，源是
             * GetLoginTokenReplyPacket
             */
            case QQEvent.LOGIN_NEED_VERIFY:
                message = "请求得到登录令牌需要输入验证码";
                break;

            /*
             * <code>LOGIN_OK</code>事件在登录成功是发生，Source是LoginReplyPacket
             */
            case QQEvent.LOGIN_OK:
                message = "登录成功";
                break;

            /*
             * <code>LOGIN_REDIRECT_NULL</code>事件在重定向到一个0地址时发生，source是
             * LoginReplyPacket
             */
            case QQEvent.LOGIN_REDIRECT_NULL:
                message = "重定向到一个地址";
                break;

            /*
             * <code>LOGIN_UNKNOWN_ERROR</code>事件在登录时发生未知错误时发生，Source是LoginReplyPacket
             */
            case QQEvent.LOGIN_UNKNOWN_ERROR:
                message = "登录时发生未知错误";
                break;

            /*
             * 短信事件，0x6000 ~ 0x6FFF
             */

            /*
             * <code>SMS_RECEIVED</code>事件发生在收到手机短信后，其source是ReceiveIMPacket
             */
            case QQEvent.SMS_RECEIVED:
                message = "收到手机短信";
                break;

            /*
             * <code>SMS_SEND_OK</code>事件发生在短消息发送出去之后，其source是SendSMSReplyPacket
             * 注意这个事件并不说明发送到底成功与否，我们需要检查SendSMSReplyPacket中的信息来判断
             */
            case QQEvent.SMS_SEND_OK:
                message = "短消息发送出去";
                break;

            /*
             * 系统事件，0x7000 ~ 0x7FFF
             */

            /*
             * <code>SYS_ADDED_BY_OTHERS</code>
             * 事件发生在有人将我加为好友时，source是SystemNotificationPacket
             */
            case QQEvent.SYS_ADDED_BY_OTHERS:
                message = "将我加为好友";
                break;

            /*
             * <code>SYS_ADDED_BY_OTHERS_EX</code>
             * 事件发生在有人将我加为好友时，source是SystemNotificationPacket
             */
            case QQEvent.SYS_ADDED_BY_OTHERS_EX:
                message = "有人将我加为好友";
                break;

            /*
             * <code>SYS_APPROVE_ADD</code>事件发生在我请求加一个人，
             * 那个人同意我加的时候，source是SystemNotificationPacket
             */
            case QQEvent.SYS_APPROVE_ADD:
                message = "我请求加一个人，那个人同意我加";
                break;

            /*
             * <code>SYS_APPROVE_ADD_BIDI</code>事件发生在我请求加别人为好友时，那个人同意并且加我
             * 为好友，source是SystemNotificationPacket
             */
            case QQEvent.SYS_APPROVE_ADD_BIDI:
                message = "我请求加别人为好友时，那个人同意并且加我为好友";
                break;

            /*
             * <code>SYS_BROADCAST_RECEIVED</code>事件在收到一条系统广播消息时发生，
             * source是ReceiveIMPacket
             */
            case QQEvent.SYS_BROADCAST_RECEIVED:
                message = "收到一条系统广播消息";
                break;

            /*
             * <code>SYS_KICKED</code>事件在收到你的QQ号在其他地方登陆导致你被系统踢出时发生，
             * source是ReceiveIMPacket。系统通知和系统消息是不同的两种事件，系统通知是对你一个人发
             * 出的（或者是和你相关的），系统消息是一种广播式的，每个人都会收到，要分清楚这两种事件。此外
             * 系统通知的载体是SystemNotificationPacket
             * ，而系统消息是ReceiveIMPacket，ReceiveIMPacket的功
             * 能和格式很多。这也是一个区别。注意其后的我被其他人加为好友，验证被通过被拒绝等等，都是系统 通知范畴
             */
            case QQEvent.SYS_KICKED:
                message = "被系统踢出";
                break;

            /*
             * <code>SYS_REJECT_ADD</code>事件发生在我请求加一个人，那个人拒绝时，
             * source是SystemNotificationPacket
             */
            case QQEvent.SYS_REJECT_ADD:
                message = "请求加好友被拒绝";
                break;

            /*
             * <code>SYS_REQUEST_ADD</code>事件发生在有人请求加我为好友时，上面的是我没有设置验证
             * 是发生的，这个事件是我如果设了验证时发生的，两者不会都发生。source是SystemNotificationPacket
             */
            case QQEvent.SYS_REQUEST_ADD:
                message = "有人请求加我为好友，需要验证";
                break;

            /*
             * <code>SYS_REQUEST_ADD_EX</code>
             * 事件发生在有人请求加我为好友时，source是SystemNotificationPacket。
             * 这是QQ_REQUEST_ADD_ME的扩展事件，在2005中使用
             */
            case QQEvent.SYS_REQUEST_ADD_EX:
                message = "有人请求加我为好友";
                break;

            /*
             * <code>SYS_TIMEOUT</code>事件在操作超时时发生，也就是请求包没有能收到回复，
             * source是要发送的那个包，通知QQEvent的operation字段表示了操作的类型。要注意超时事件和
             * Fail事件的不同，超时是指包没有收到任何确认，fail是指确认收到了，并且根据确认包的内容， 操作失败了
             */
            case QQEvent.SYS_TIMEOUT:
                message = "操作超时";
                break;

            /*
             * <code>SYS_TIMEOUT_03</code>在03协议族操作超时时发生，也就是请求包没有能收到回复，
             * source是要发送的那个包，通知QQEvent的operation字段表示了操作的类型。要注意超时事件和
             * Fail事件的不同，超时是指包没有收到任何确认，fail是指确认收到了，并且根据确认包的内容，
             * 操作失败了。由于不同的协议族中的命令可能值相同，所以目前只好为不同协议族的超时加上不同的事件
             */
            case QQEvent.SYS_TIMEOUT_03:
                message = "03协议族操作超时";
                break;

            /*
             * <code>SYS_TIMEOUT_05</code>在05协议族操作超时时发生，也就是请求包没有能收到回复，
             * source是要发送的那个包，通知QQEvent的operation字段表示了操作的类型。要注意超时事件和
             * Fail事件的不同，超时是指包没有收到任何确认，fail是指确认收到了，并且根据确认包的内容，
             * 操作失败了。由于不同的协议族中的命令可能值相同，所以目前只好为不同协议族的超时加上不同的事件
             */
            case QQEvent.SYS_TIMEOUT_05:
                message = "05协议族操作超时";
                break;

            /*
             * 用户事件，0x8000 ~ 0x8FFF
             */

            /*
             * <code>USER_ADVANCED_SEARCH_END</code>事件在高级搜索结束时发生，源是
             * AdvancedSearchUserReplyPacket
             */
            case QQEvent.USER_ADVANCED_SEARCH_END:
                message = "高级搜索结束";
                break;

            /*
             * <code>USER_ADVANCED_SEARCH_OK</code>事件在高级搜索成功时发生，源是
             * AdvancedSearchUserReplyPacket
             */
            case QQEvent.USER_ADVANCED_SEARCH_OK:
                message = "高级搜索成功";
                break;

            /*
             * <code>USER_DELETE_SIGNATURE_FAIL</code>事件在删除个性签名失败时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_DELETE_SIGNATURE_FAIL:
                message = "删除个性签名失败";
                break;

            /*
             * <code>USER_DELETE_SIGNATURE_OK</code>事件在删除个性签名成功时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_DELETE_SIGNATURE_OK:
                message = "删除个性签名成功";
                break;

            /*
             * <code>USER_GET_CUSTOM_HEAD_DATA_OK</code>在收到自定义头像数据
             * 成功时发生，source是GetCustomHeadDataReplyPacket
             */
            case QQEvent.USER_GET_CUSTOM_HEAD_DATA_OK:
                message = "收到自定义头像数据";
                break;

            /*
             * <code>USER_GET_CUSTOM_HEAD_INFO_OK</code>在收到自定义头像信息
             * 成功时发生，source是GetCustomHeadInfoReplyPacket
             */
            case QQEvent.USER_GET_CUSTOM_HEAD_INFO_OK:
                message = "收到自定义头像信息";
                break;

            /*
             * <code>USER_GET_INFO_OK</code>事件发生在得到用户信息成功时，source是GetUserInfoReplyPacket
             */
            case QQEvent.USER_GET_INFO_OK:
                message = "得到用户信息成功";
                break;

            /*
             * <code>USER_GET_PROPERTY_OK</code>事件在得到用户属性成功时发生，
             * source是UserPropertyOpReplyPacket
             */
            case QQEvent.USER_GET_PROPERTY_OK:
                message = "得到用户属性成功";
                break;

            /*
             * <code>USER_GET_SIGNATURE_FAIL</code>事件在得到个性签名失败时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_GET_SIGNATURE_FAIL:
                message = "得到个性签名失败";
                break;

            /*
             * <code>USER_GET_SIGNATURE_OK</code>事件在得到个性签名成功时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_GET_SIGNATURE_OK:
                message = "得到个性签名成功";
                break;

            /*
             * <code>USER_KEEP_ALIVE_FAIL</code>事件在连接失去时发生，这种情况一般时Keep
             * Alive包没有反应 时触发的，source无用处
             */
            case QQEvent.USER_KEEP_ALIVE_FAIL:
                message = "失去连接";
                break;

            /*
             * <code>USER_KEEP_ALIVE_OK</code>事件在Keep
             * Alive包收到确认时发生，source是KeepAliveReplyPacket
             */
            case QQEvent.USER_KEEP_ALIVE_OK:
                message = "保持连接成功";
                break;

            /*
             * <code>USER_MEMBER_LOGIN_HINT_RECEIVED</code>
             * 在收到会员登录提示时发生，source是ReceiveIMPacket
             */
            case QQEvent.USER_MEMBER_LOGIN_HINT_RECEIVED:
                message = "收到会员登录提示";
                break;

            /*
             * <code>USER_MODIFY_INFO_FAIL</code>事件在修改用户信息失败时发生，
             * source是ModifyInfoPacket，注意不是ModifyInfoReplyPacket，因为 Reply包毫无价值
             */
            case QQEvent.USER_MODIFY_INFO_FAIL:
                message = "修改用户信息失败";
                break;

            /*
             * <code>USER_MODIFY_INFO_OK</code>事件在修改用户信息成功是发生，source是
             * ModifyInfoPacket
             */
            case QQEvent.USER_MODIFY_INFO_OK:
                message = "修改用户信息成功";
                break;

            /*
             * <code>USER_MODIFY_SIGNATURE_FAIL</code>事件在修改个性签名失败时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_MODIFY_SIGNATURE_FAIL:
                message = "修改个性签名失败";
                break;

            /*
             * <code>USER_MODIFY_SIGNATURE_OK</code>事件在修改个性签名成功时发生,
             * source是SignatureOpReplyPacket
             */
            case QQEvent.USER_MODIFY_SIGNATURE_OK:
                message = "修改个性签名成功";
                break;

            /*
             * <code>USER_PRIVACY_DATA_OP_OK</code>在隐私数据操作失败时发生，
             * source是PrivacyDataOpReplyPacket。为了知道具体是什么操作，用户需要
             * 判断source中的subCommand字段
             */
            case QQEvent.USER_PRIVACY_DATA_OP_FAIL:
                message = "隐私数据操作失败";
                break;

            /*
             * <code>USER_PRIVACY_DATA_OP_OK</code>在隐私数据操作成功时发生，
             * source是PrivacyDataOpReplyPacket。为了知道具体是什么操作，用户需要
             * 判断source中的subCommand字段
             */
            case QQEvent.USER_PRIVACY_DATA_OP_OK:
                message = "隐私数据操作成功";
                break;

            /*
             * <code>USER_REQUEST_KEY_FAIL</code>事件在请求密钥失败之后发生，其source是RequestKeyPacket
             */
            case QQEvent.USER_REQUEST_KEY_FAIL:
                message = "请求密钥失败";
                break;

            /*
             * <code>USER_REQUEST_KEY_OK</code>
             * 事件在请求密钥成功之后发生，其source是RequestKeyReplyPacket
             */
            case QQEvent.USER_REQUEST_KEY_OK:
                message = "请求密钥成功";
                break;

            /*
             * <code>USER_SEARCH_OK</code>事件在搜索在线用户成功时发生，source是SearchUserReplyPacket
             */
            case QQEvent.USER_SEARCH_OK:
                message = "搜索在线用户成功";
                break;

            /*
             * <code>USER_STATUS_CHANGE_FAIL</code>
             * 事件发生你自己的状态改变失败时，source是ChangeStatusReplyPacket
             */
            case QQEvent.USER_STATUS_CHANGE_FAIL:
                message = "状态改变失败";
                break;

            /*
             * <code>USER_STATUS_CHANGE_OK</code>
             * 事件发生你自己的状态改变成功时，source是ChangeStatusReplyPacket
             */
            case QQEvent.USER_STATUS_CHANGE_OK:
                message = "状态改变成功";
                break;

            /*
             * <code>USER_WEATHER_GET_FAIL</code>在得到天气预报失败时发生，source
             * 是WeatherOpReplyPacket，但是这种情况下这个包无可用信息
             */
            case QQEvent.USER_WEATHER_GET_FAIL:
                message = "得到天气预报失败";
                break;

            /*
             * <code>USER_WEATHER_GET_OK</code>在得到天气预报成功时发生，source
             * 是WeatherOpReplyPacket
             */
            case QQEvent.USER_WEATHER_GET_OK:
                message = "得到天气预报成功";
                break;

            default:
                message = "未知事件";
        }

        return message;
    }
}

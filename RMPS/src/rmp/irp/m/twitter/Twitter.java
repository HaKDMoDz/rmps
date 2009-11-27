/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.twitter;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import cons.irp.ConsEnv;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import rmp.irp._comn.Step;
import rmp.util.Logs;
import twitter4j.DirectMessage;
import twitter4j.Query;
import twitter4j.QueryResult;
import twitter4j.Tweet;
import twitter4j.TwitterException;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Twitter implements IService
{
    private twitter4j.Twitter messenger;

    public void sign(int status)
    {
        try
        {
            messenger = new twitter4j.Twitter("", "");
            twitter4j.Status tStatus = messenger.updateStatus("");
        }
        catch (Exception exp)
        {
            Logs.log(exp);
        }
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        String msg = "选择您要进行的操作：";
        msg += "1、更新您的状态；";
        msg += "2、查看发贴信息；";
        msg += "3、发布消息；";
        msg += "4、接收消息；";
        msg += "5、搜索；";
        msg += ".. 返回上一级；";
        msg += "/ 返回根目录；";
        session.send(msg);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        // 判断用户会话信息是否存在
        Step step = (Step) session.getAttribute(ConsEnv.SESSION);
        if (step == null)
        {
            return;
        }

        // 判断是不为当前功能
        if (step.getFunc() != ConsFun.FUNCTION)
        {
            return;
        }

        String msg = message.getContent();
        switch (step.getStep())
        {
            case ConsFun.STEP_0:
                session.send("请选择您要使用的功能编号：");
                break;
            case ConsFun.STEP_1:
                try
                {
                    // 状态更新
                    messenger.updateStatus(msg);
                }
                catch (TwitterException ex)
                {
                }
                break;
            case ConsFun.STEP_2:
                try
                {
                    // 获取Timeline
                    List statuses = messenger.getFriendsTimeline();
                    messenger.sendDirectMessage("id", "message");
                    List<DirectMessage> messages = messenger.getDirectMessages();
                    for (DirectMessage dm : messages)
                    {
                        System.out.println("Sender:" + dm.getSenderScreenName());
                        System.out.println("Text:" + dm.getText() + "\n");
                    }
                }
                catch (TwitterException ex)
                {
                    Logger.getLogger(Twitter.class.getName()).log(Level.SEVERE, null, ex);
                }
            case ConsFun.STEP_3:
                try
                {
                    Query query = new Query("wenwu");
                    QueryResult result = messenger.search(query);
                    for (Tweet tweet : result.getTweets())
                    {
                        //print(tweet.getFromUser() + ":" + tweet.getText());
                    }
                }
                catch (TwitterException ex)
                {
                    Logger.getLogger(Twitter.class.getName()).log(Level.SEVERE, null, ex);
                }
            default:
                // 容错处理，显示使用帮助
                doHelp(session, message);
                break;
        }
    }
}

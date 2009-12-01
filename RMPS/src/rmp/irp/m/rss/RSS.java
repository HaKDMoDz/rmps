/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.rss;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import com.sun.syndication.feed.synd.SyndCategory;
import com.sun.syndication.feed.synd.SyndEnclosure;
import com.sun.syndication.feed.synd.SyndEntry;
import com.sun.syndication.feed.synd.SyndFeed;
import com.sun.syndication.io.SyndFeedInput;
import com.sun.syndication.io.XmlReader;
import java.net.URL;
import com.amonsoft.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class RSS implements IService
{
    public void init()
    {
        try
        {
            // 指定Rss源
            URL feedUrl = new URL("http://amonsoft.com/blog/feed.php");

            // 得到SyndFeed对象，即得到Rss源里的所有信息
            SyndFeedInput input = new SyndFeedInput();
            SyndFeed feed = input.build(new XmlReader(feedUrl));

            // 循环生理Rss子项列表
            for (Object object : feed.getEntries())
            {
                if (object instanceof SyndEntry)
                {
                    SyndEntry entry = (SyndEntry) object;
                    // 标题、连接地址、标题简介、时间是一个Rss源项最基本的组成部分
                    System.out.println("标题：" + entry.getTitle());
                    System.out.println("连接地址：" + entry.getLink());
                    System.out.println("标题简介：" + entry.getDescription().getValue());
                    System.out.println("发布时间：" + entry.getPublishedDate());
                    System.out.println("标题的作者：" + entry.getAuthor());

                    // 此标题所属的范畴
                    for (Object obj2 : entry.getCategories())
                    {
                        if (obj2 instanceof SyndCategory)
                        {
                            SyndCategory category = (SyndCategory) obj2;
                            System.out.println("此标题所属的范畴：" + category.getName());
                        }
                    }

                    // 得到流媒体播放文件的信息列表
                    for (Object obj3 : entry.getEnclosures())
                    {
                        if (obj3 instanceof SyndEnclosure)
                        {
                            SyndEnclosure enclosure = (SyndEnclosure) obj3;
                            System.out.println("流媒体播放文件：" + enclosure.getUrl());
                        }
                    }
                }
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}

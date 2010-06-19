/******************************************************************************
 * Javascript Document
 * iBookObj v2.0
 * http://www.amonsoft.cn/code/iBookObj/
 * Copyright (c) 2008 Amonsoft.cn
 ******************************************************************************/
///////////////////////////////////////////////////////////
// [0]: hwnd 网摘打开窗口句柄
// [1]: link 网摘链接地址
// [2]: tips 网摘链接提示信息
// [3]: text 网摘链接显示文本
// [4]: icon 网摘链接徽标
// [5]: escp 网络链接地址转换
// [6]: widh 打开窗口宽度
// [7]: high 打开窗口高度
// ibo.IBMS.push(new Array(hwnd,link+'?title={0}&url={1}&desc={2}', tips, text, icon, escp, widh, high));
///////////////////////////////////////////////////////////
ibo.IBMS.push(new Array('favorites','', '本地收藏', '本地收藏', 'favorites.png', '', 600, 450));
ibo.IBMS.push(new Array('icio_us','http://del.icio.us/post?v=4&noui&jump=close&url={1}&title={0}', 'del.icio.us', 'del.icio.us', 'icio.us.gif', 'encodeURIComponent', 700, 400));
ibo.IBMS.push(new Array('baidu_com','http://cang.baidu.com/do/add?it={0}&iu={1}&fr=ien#nw=1', '百度收藏', '百度收藏', 'baidu.com.gif', 'encodeURIComponent', 600, 450));
ibo.IBMS.push(new Array('qq_com','http://shuqian.qq.com/post?title={0}&uri={1}', 'QQ书签', 'QQ书签', 'qq.com.gif', 'encodeURIComponent', 930, 470));
ibo.IBMS.push(new Array('yesky_com','http://hot.yesky.com/dp.aspx?t={0}&u={1}&c={2}&st=2', '天极网摘', '天极网摘', 'yesky.com.gif', 'escape', 400, 480));
ibo.IBMS.push(new Array('yahoo_com','http://myweb.cn.yahoo.com/popadd.html?title={0}&url={1}', '雅虎中国', '雅虎中国', 'cn.yahoo.com.gif', '', 480, 560));
ibo.IBMS.push(new Array('hexun_com','http://bookmark.hexun.com/post.aspx?title={0}&url={1}&excerpt={2}', '和讯网摘', '和讯网摘', 'hexun.com.gif', 'escape', 600, 450));
ibo.IBMS.push(new Array('fanfou_com','http://fanfou.com/sharer?t={0}?u={1}?d={2}?s=bl', '饭否', '饭否', 'fanfou.com.gif', 'escape', 600, 400));
ibo.IBMS.push(new Array('sina_com_cn','http://vivi.sina.com.cn/collect/icollect.php?title={0}&url={1}&desc={2}', '新浪VIVI', '新浪VIVI', 'sina.com.cn.gif', 'escape', 480, 560));
ibo.IBMS.push(new Array('poco_cn','http://my.poco.cn/fav/storeIt.php?t={0}&u={1}&c={2}', 'Poco网摘', 'Poco网摘', 'poco.cn.gif', 'escape', 475, 575));
ibo.IBMS.push(new Array('_365key_com','http://www.365key.com/storeit.aspx?t={0}&u={1}&c={2}', '天天网摘', '天天网摘', '365key.com.gif', 'escape', 475, 575));
ibo.IBMS.push(new Array('sohu_com','http://z.sohu.com/storeit.do?t={0}&u={1}&c={2}', '搜狐网摘', '搜狐网摘', '0.png', 'escape', 475, 575));
ibo.IBMS.push(new Array('blogchina_com','http://blogmark.blogchina.com/jsp/key/quickaddkey.jsp?k={0}&u={1}&c={2}', '博客中国', '博客中国', '0.png', 'escape', 500, 430));
ibo.IBMS.push(new Array('nizhai_com','http://www.nizhai.com/icollect.asp#t={0}&u={1}&c={2}', '你摘', '你摘', '0.png', 'escape', 480, 420));
ibo.IBMS.push(new Array('younote_com','http://www.YouNote.com/NoteIt.aspx?t={0}&u={1}&c={2}', 'YouNote', 'YouNote', '0.png', 'escape', 475, 575));
ibo.IBMS.push(new Array('qihoo_com','http://rrwz.qihoo.com/user/AddWebSnip.aspx?t={0}&u={1}&c={2}', '奇虎网摘', '奇虎网摘', '0.png', 'escape', 480, 560));
ibo.IBMS.push(new Array('live.com','https://favorites.live.com/quickadd.aspx?marklet=1&mkt=en-us&title={0}&url={1}&top={2}', 'Live.com', 'Live.com', 'live.com.gif', 'escape', 480, 560));
ibo.IBMS.push(new Array('google.com','http://www.google.com/bookmarks/mark?op=add&title={0}&bkmk={1}', 'Google.com', 'Google.com', 'google.com.gif', 'encodeURIComponent', 480, 560));
ibo.IBMS.push(new Array('favorites','', 'http://www.shouker.com/mc/col/post2.aspx?title={0}&surl={1}', '收客收藏', 'favorites.png', '', 600, 450));
ibo.IBMS.push(new Array('favorites','', 'http://www.google.com/bookmarks/mark?op=edit&bkmk={1}&title={0}', 'google收藏', 'favorites.png', '', 600, 450));



ibo.IBMS.push(new Array('Ask','ask.png', 'Ask', 'Ask'));
ibo.IBMS.push(new Array('Del.icio.us','delicious.png', 'Del.icio.us', 'Del.icio.us'));
ibo.IBMS.push(new Array('Digg','digg.png', 'Digg', 'Digg'));
ibo.IBMS.push(new Array('Email','email.png'));
ibo.IBMS.push(new Array('Favorites','favorites.png'));
ibo.IBMS.push(new Array('Facebook','facebook.gif'));
ibo.IBMS.push(new Array('Fark','fark.png'));
ibo.IBMS.push(new Array('Furl','furl.gif'));
ibo.IBMS.push(new Array('Google','goog.png'));
ibo.IBMS.push(new Array('Live','live.gif'));
ibo.IBMS.push(new Array('MySpace','myspace.png'));
ibo.IBMS.push(new Array('Yahoo MyWeb','yahoo-myweb.png'));
ibo.IBMS.push(new Array('Newsvine','newsvine.png'));
ibo.IBMS.push(new Array('Reddit','reddit.gif'));
ibo.IBMS.push(new Array('Sk*rt','skrt.gif'));
ibo.IBMS.push(new Array('Slashdot','slashdot.png'));
ibo.IBMS.push(new Array('StumbleUpon','su.png'));
ibo.IBMS.push(new Array('Stylehive','stylehive.gif'));
ibo.IBMS.push(new Array('Tailrank','tailrank2.png'));
ibo.IBMS.push(new Array('Technorati','technorati.png'));
ibo.IBMS.push(new Array('ThisNext','thisnext.gif'));
ibo.IBMS.push(new Array('Twitter','twitter.gif'));
ibo.IBMS.push(new Array('BallHype','ballhype.png'));
ibo.IBMS.push(new Array('Yardbarker','yardbarker.png'));
ibo.IBMS.push(new Array('Kaboodle','kaboodle.gif'));
<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet1003.aspx.cs" Inherits="inet_inet1003" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;RSS是2004年最热门的互联网词汇之一，不过，相对于博客（BLOG）来说，RSS的知名度相应会低很多，而且至今还没有一个非常贴切的中文词汇，也许以后无需中文名，大家都习惯于直接叫RSS了。RSS之所以同BLOG一样会被认为是热门词汇的一个原因，个人推测，应该是许多分析人士认识到RSS将要对互联网内容的浏览方法所产生的巨大影响。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                一、什么是RSS？
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;RSS(Really Simple Syndication)是一种描述和同步网站内容的格式，是目前使用最广泛的XML应用。RSS搭建了信息迅速传播的一个技术平台，使得每个人都成为潜在的信息提供者。发布一个RSS文件后，这个RSS Feed中包含的信息就能直接被其他站点调用，而且由于这些数据都是标准的XML格式，所以也能在其他的终端和服务中使用。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;如果从RSS阅读者的角度来看，完全不必考虑它到底是什么意思，只要简单地理解为一种方便的信息获取工具就可以了。RSS获取信息的模式与加入邮件列表（如电子杂志和新闻邮件）获取信息有一定的相似之处，也就是可以不必登录各个提供信息的网站而通过客户端浏览方式（称为“RSS阅读器”）或者在线RSS 阅读方式这些内容。例如，通过一个RSS阅读器，可以同时浏览新浪新闻，也可以浏览搜狐或者百度的新闻（如果你采用了RSS订阅的话）。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;在许多新闻信息服务类网站，会看到这样的按钮<img src="_i/rss.gif" alt="RSS" width="36" height="14" />
                <img src="_i/xml.gif" alt="XML" width="36" height="14" />,有的网站使用一个图标，有的同时使用两个，这就是典型的提供RSS订阅的标志，这个图标一般链接到订阅RSS信息源的URL。当然，即使不用这样的图标也是可以的，只要提供订阅RSS信息源的URL即可。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                二、RSS的历史
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;那么RSS究竟代表什么呢？比较普遍的有两种说法，一种是“Rich Site Summary”或“RDF Site Summary”，另一种是“Really Simple Syndication”，之所以有这些分歧，需要从RSS发展的历史说起。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;最初的0.90版本RSS是由Netscape公司设计的，目的是用来建立一个整合了各主要新闻站点内容的门户，但是0.90版本的RSS规范过于复杂，而一个简化的RSS 0.91版本也随着Netscape公司对该项目的放弃而于2000年暂停。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;不久，一家专门从事博客写作软件开发的公司UserLand接手了RSS 0.91版本的发展，并把它作为其博客写作软件的基础功能之一继续开发，逐步推出了0.92、0.93和0.94版本。随着网络博客的流行，RSS作为一种基本的功能也被越来越多的网站和博客软件支持。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;在UserLand公司接手并不断开发RSS的同时，很多的专业人士认识到需要通过一个第三方、非商业的组织，把RSS发展成为一个通用的规范，并进一步标准化。于是2001年一个联合小组在0.90版本RSS的开发原则下，以W3C新一代的语义网技术RDF（Resource Description Framework）为基础，对RSS进行了重新定义，发布RSS1.0，并将RSS定义为“RDF Site Summary”。但是这项工作没有与UserLand公司进行有效的沟通，UserLand公司也不承认RSS 1.0的有效性，并坚持按照自己的设想进一步开发出RSS的后续版本，到2002年9月发布了最新版本RSS 2.0，UserLand公司将RSS定义为“Really Simple Syndication”。 &nbsp;&nbsp;&nbsp;&nbsp;目前RSS已经分化为RSS 0.9x/2.0和RSS 1.0两个阵营，由于分歧的存在和RSS 0.9x/2.0的广泛应用现状，RSS 1.0还没有成为标准化组织的真正标准。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                三、RSS目前的版本和推荐
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;到目前为止，RSS共有七种版本，推荐使用的是RSS 1.0和RSS 2.0，对于一些基本的站点同步，也可以选用RSS 0.91。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                四、RSS的语法介绍
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;一个RSS文件就是一段规范的XML数据，该文件一般以rss，xml或者rdf作为后缀。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                五、RSS的联合（Syndication）和聚合（Aggregation）
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;发布一个RSS文件（一般称为RSS Feed）后，这个RSS Feed中包含的信息就能直接被其他站点调用，而且由于这些数据都是标准的XML格式，所以也能在其他的终端和服务中使用，如PDA、手机、邮件列表等。而且一个网站联盟（比如专门讨论旅游的网站系列）也能通过互相调用彼此的RSS Feed，自动的显示网站联盟中其他站点上的最新信息，这就叫着RSS的联合。这种联合就导致一个站点的内容更新越及时、RSS Feed被调用的越多，该站点的知名度就会越高，从而形成一种良性循环。<br />
                &nbsp;&nbsp;&nbsp;&nbsp;而所谓RSS聚合，就是通过软件工具的方法从网络上搜集各种RSS Feed并在一个界面中提供给读者进行阅读。这些软件可以是在线的WEB工具，如http://my.netscape.com ，http://my.userland.com ， http://www.xmltree.com ，http://www.moreover.com ，http://www.oreillynet.com/meerkat 等，也可以是下载到客户端安装的工具。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                六、RSS的未来发展
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;随着越来越多的站点对RSS的支持，RSS已经成为目前最成功的XML应用。RSS搭建了信息迅速传播的一个技术平台，使得每个人都成为潜在的信息提供者。相信很快我们就会看到大量基于RSS的专业门户、聚合站点和更精确的搜索引擎。
            </td>
        </tr>
    </table>
</asp:Content>

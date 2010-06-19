<%@ Page Language="C#" MasterPageFile="~/myim/myim.master" AutoEventWireup="true" CodeFile="myim0002.aspx.cs" Inherits="myim_myim0002" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;什么是即时通讯？IM是英文Instant Messaging的缩写，中文翻译成“即时通讯”，根据美国著名的互联网术语在线词典NetLingo的解释，其定义如下：“Instant Messaging（读成I-M）缩写为IM或IMing，它是一种使人们能在网上识别在线用户并与他们实时交换消息的技术，被很多人称为电子邮件发明以来最酷的在线通讯方式，典型的 IM是这样工作的：当好友列表（buddy list）中的某人在任何时候登录上线并试图通过你的计算机联系你时，IM系统会发一个消息提醒你，然后你能与他建立一个聊天会话并键入消息文字进行交流。 IM被认为比电子邮件和聊天室更具有自发性，甚至你能在进行实时文本对话的同时一起进行WEB冲浪（surf）。目前有多种竞争的IM服务，不幸的是没有标准：即你想与之进行即时通讯对话的人必须使用和你一样的IM系统。另一个不利因素是IM还没有为安全性使用目的而设计。”
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;除NetLingo的定义之外，还有一些其他定义，但由于NetLingo在互联网专业词汇释义方面具有比较大的影响，因此基本上都以此定义作为基础，同时NetLingo是在线更新的词典，它会经常针对互联网技术的变化对词汇释义进行修改，在本文中对即时通讯的定义就是最新的，以前的定义中并没有对标准化或者安全问题进行过相关说明。考虑到这些因素，本文将基于此定义进行研究。
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;即时通讯的出现和互联网有着密不可分的关系，从技术上来说，IM完全基于TCP/IP网络协议族实现，而TCP/IP协议族是整个互联网得以实现的技术基础，最早期的即时通讯雏形可以追溯到芬兰人Jarkko Oikarinen于1988年发明的一种网络聊天协议IRC（Internet Relay Chat），该协议仅支持文本聊天，并且也不支持好友列表的概念，1996年第一个 IM产品ICQ发明后，即时通讯的技术和功能开始基本成型，其工作原理开始被人们所了解，但不同厂商实现即时通讯技术原理时采用的协议却有较大的差异，甚至到目前为止世界主要的 IM服务运营商AOL（American Online：美国在线）仍然没有公布其主要即时通讯产品AIM（American Instant Messenger）的专用协议。虽然如此，但我们仍然可以从一个提供最基本服务的 IM系统开始来描述IM的技术原理，不管目前产品的新功能如何丰富，它必须遵循这些基本原理和结构。
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;首先，用户A输入自己的用户名和密码登录即时通讯服务器，服务器通过读取用户数据库来验证用户身份，如果用户名、密码都正确，就登记用户A的IP地址、IM客户端软件的版本号及使用的TCP/UDP端口号，然后返回用户A登录成功的标志，此时用户A在 IM系统中的状态为在线（Online Presence）。
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;其次，根据用户A存储在IM服务器上的好友列表（Buddy List），服务器将用户A在线的相关信息发送到也同时在线的即时通讯好友的PC机，这些信息包括在线状态、IP地址、 IM客户端使用的TCP端口（Port）号等，即时通讯好友PC机上的即时通讯软件收到此信息后将在PC桌面上弹出一个小窗口予以提示。
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;第三步，即时通讯服务器把用户A存储在服务器上的好友列表及相关信息回送到他的PC机，这些信息包括也在线状态、IP地址、IM客户端使用的TCP端口（Port）号等信息，用户A的PC机上的IM客户端收到后将显示这些好友列表及其在线状态。
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;接下来，如果用户A想与他的在线好友用户B聊天，他将直接通过服务器发送过来的用户B的IP地址、TCP端口号等信息，直接向用户B的PC机发出聊天信息，用户B的IM客户端软件收到后显示在屏幕上，然后用户B再直接回复到用户A的PC机，这样双方的即时文字消息就不通过 IM服务器中转，而是通过网络进行点对点的直接通讯，这称为对等通讯方式（Peer To Peer）。在<a href="http://www.linkstalk.com/">商用即时通讯系统</a>中，如果用户A与用户B的点对点通讯由于防火墙、网络速度等原因难以建立或者速度很慢， IM服务器还提供消息中转服务，即用户A和用户B的即时消息全部先发送到IM服务器，再由服务器转发给对方。早期的IM系统，在IM客户端和IM服务器之间通讯采用采用UDP协议，UDP协议是不可靠的传输协议，而在 IM客户端之间的直接通讯中，采用具备可靠传输能力的TCP协议。随着用户需求和技术环境的发展，目前主流的即时通讯系统倾向于在即时通讯客户端之间、即时通讯客户端和即时通讯服务器之间都采用TCP协议。
                </p>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;·<a href="myim1000.aspx">国外软件</a>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;·<a href="myim2000.aspx">国内软件</a>
            </td>
        </tr>
    </table>
</asp:Content>

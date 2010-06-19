<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts1001.aspx.cs" Inherits="exts_exts1001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                <strong>DOS环境下的文件名</strong>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;在DOS下，文件名采用8.3结构，即：最长8位的文件名，由小数点分隔后再跟上最长3位的后缀名，如：READ.ME、SETUP.EXE，一般情况下文件名不允许使用汉字，只能由字母、数字和一些符号组成。如READ.ME用中文理解就是&quot;读我&quot;，即提示用户在使用软件前先看看这个文件的内容，以获取更多的提示信息。而更重要的是，DOS下规定用后缀名来区分各种不同的文件。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;在DOS下最容易遇到的首先是可执行文件，后缀名有两类：*.exe、*.com（此处的<br />
                *表示文件名任意），它们是由汇编语言或其它高级语言编出的程序经过编译后直接在DOS下运行的文件。有时由于软件功能多、内存偏小，不能一次性全部调入内存还可能有同文件名的ovl文件，如ws.exe、ws.ovl。另外还有一种文件可以直接运行， *.bat,即批处理文件，其中有许多命令或可执行文件名，主要用于提高工作效率，其中最有用的是Autoexec.bat，这个文件在开机时会被自动执行（自动执行在英文中就是Automaticallyexecute）。而另外一种可以加载但不能直接运行的文件即是系统扩展管理文件*.sys（sys 即系统system），它主要提供某些非标准设备如鼠标、扩充内存等的驱动程序，如mouse.sys、himem.sys。为了统一管理还专门规定了一个config.sys的文本文件来一次性地在开机时自动调入这些必需的设备驱动程序，这些文件一旦被误删或换名或被病毒侵袭则将直接导致系统工作不正常。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;DOS下字处理产生的文件原本是可以不用后缀的，但人们常用*.txt表示（txt即文本text）。被所有的平台和所有应用程序支持。而为了管理方便，人们也可以用自己的名字做后缀来表示是自己建的文本文件，如我输入的很多文章即为*.mcj，为了便于用户在意外删掉原文件的情况下能尽快恢复原文件，许多字处理系统都提供了一种自动备份的功能，如我第二次编辑JIHUA.MCJ时（JIHUA:计划的汉语拼音），系统会先拷贝一份原文件为JIHUA.BAK。使用具有特殊格式功能的字处理软件，如求伯君先生早年推出的WPS，就会规定其后缀为.wps，用以标识是用WPS 生成的文本文件。当使用字处理软件编辑高级语言程序时，后缀通常为相应语言的前三个字母（如：*.BAS即BASIC语言源程序，*.PAS为PASCAL语言程序，*.FOR为Fortran语言程序，*.C即为C语言，*.ASM即为汇编语言程序）。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;伴随着可执行文件常附有以下几类文件：*.HLP即帮助文件（help）、*.CFG即配置文件（config）、*.DAT即数据文件（data）、*.LOG即日志文件（log）、*.TMP为临时文件（temporal）。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>Windows环境下的文件名</strong>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;绝大多数DOS文件名后缀在Windows下继续有效，但Windows本身也引出了许多种崭新的后缀名，如：*.drv为设备驱动程序（Driver）、*.fon和*.fot都是字库文件、*.grp为分组文件（Group）、*.ini为初始化信息文件（Initiation）、*.pif为DOS环境下的可执行文件在Windows下执行时所需要的文件格式、*.crd即卡片文件（Card）、*.rec即记录器宏文件（Record）、*.wri即文本文件（Write），它是字处理write.exe生成的文件、*.doc和*.rtf也是文本文件（Document），它们是Word产生的文件、*.cal为日历文件、*.clp是剪贴板中的文件格式、*.htm和
                *.html即主页文件、*.par为交换文件、*.pwl为口令文件（Password）等等。
            </td>
        </tr>
    </table>
</asp:Content>

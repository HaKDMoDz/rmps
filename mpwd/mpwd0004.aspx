<%@ Page Language="C#" MasterPageFile="~/mpwd/mpwd.master" AutoEventWireup="true" CodeFile="mpwd0004.aspx.cs" Inherits="mpwd_mpwd0004" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table>
        <tr>
            <td align="left">
                《魔方密码》中使用的几个名词：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;记录：用户每次添加的数据信息，包括登录用户、登录口令及其它信息等。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;属性：口令数据中的一个信息名值对，如标题”登录用户“及对应的内容信息；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;口令：用户系统中用于身份认证的字符串，即我们平时所有说的密码。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                《魔方密码》防止误操作措施：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;为了充分保障用户数据安全，软件采取了以下几个措施以尽可能的避免用户的误操作所造成的影响：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;1、用户每修改了<a href="">记录</a>的一个<a href="">属性</a>，必需点击属性栏的【应用】按钮，以确认对此<a href="">属性</a>的修改；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;2、用户确认修改了<a href="">记录</a>的内容后，需要点击【文件】->【保存】（或者Ctrl+S）进行最后的入库保存操作；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;3、用户删除<a href="">记录</a>时，软件会进行两次询问：一次确认询问及一次否认询问，提醒用户慎重执行数据的删除操作；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;4、软件会记录用户每次对<a href="">记录</a>数据的修改，以方便用户以后的查找或恢复，但删除<a href="">记录</a>的操作将会连带历史记录一同清除。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                《魔方密码》的操作方法：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;一、使用【文件】->【新建】（或者Ctrl+N）新建一个记录；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;二、选择您要使用的【模板】信息，点击【应用】按钮进入下一步；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;三、输入【标题】信息，此内容为必填信息，主要用于展示您的记录的概要内容；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;四、输入【搜索】信息，此内容为非必要信息，但有助于您在以后的数据查找时进行快速定位，建议输入一些简短的字、词等描述信息（请不要把您的重要信息如<a href="">口令</a>等填写于此处）。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;五、提醒信息，此内容为非必要信息，如果您在此处填写了具体的日期信息，则软件会在日期到达时在状态栏显示您的提醒信息；
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;六、下面开始录入必要的<a href="">属性</a>数据了，软件默认提供了一些常用的属性数据（如登录用户、登录口令等），您可以按照格式进行填写。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1）、添加一条属性：您可以通过右击属性表格，然后选择添加属性，并选择对应的属性类型即可；您也可以通过与编辑菜单中对应的Ctrl+数字键来快速添加一个属性。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2）、修改一条属性：选择您要修改的属性并右击属性表格，然后选择转换类型，选择目标属性类型即可。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3）、删除一条属性：选择您要删除的属性并右击属性表格，然后选择删除属性，您也可以通过Alt+D键删除选择的属性。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4）、属性排序：您可以通过编辑菜单中的上移一行及下移一行选项或者Ctrl+Up、Ctrl+Down快捷键对属性进行排序。
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;七、您可以根据需要添加、删除或修改某条<a href="">属性</a>数据，以更符合您的需要；
            </td>
        </tr>
    </table>
</asp:Content>

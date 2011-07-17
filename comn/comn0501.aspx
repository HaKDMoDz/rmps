<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0501.aspx.cs" Inherits="comn_comn0501" Title="无标题页" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            文件名称
                        </th>
                        <th>
                            最后更新
                        </th>
                        <th>
                            管理
                        </th>
                    </tr>
                    <% 
                        for (int i = 0; i < fileList.Length; i += 1)
                        { 
                    %>
                    <tr>
                        <td align="left">
                            <a href="data/<%= System.IO.Path.GetFileName(fileList[i]) %>" title="点击下载">
                                <%= System.IO.Path.GetFileName(fileList[i]) %>
                            </a>
                        </td>
                        <td align="center">
                            <%= System.IO.File.GetLastWriteTime(fileList[i]).ToString() %>
                        </td>
                        <td align="center">
                            <a href="<%= System.IO.Path.GetFileName(fileList[i]) %>" onclick="return doDelt();" title="点击删除，此操作将不可恢复！">删除</a>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask13A4.aspx.cs" Inherits="iask_iask13A4" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;&nbsp;通过本页面您可以查看您的浏览器的一些详细信息：
            </td>
        </tr>
        <tr>
            <td align="right">
                <input id="ck_HideDesp" type="checkbox" accesskey="H" onclick="hideDesp(this)" />隐藏简介(H)
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <%
            for (int i = 0; i < w3cProp.Count; i += 1)
            {
        %>
        <tr>
            <td align="left">
                <a id="a<%= i %>"></a><strong>
                    <%= w3cName[i] %>
                </strong>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="460" style="border-top: dashed 1px #CCCCCC; border-left: dashed 1px #CCCCCC; background-color: #FAFAFA;">
                    <tr>
                        <th style="height: 24px;">
                            属性
                        </th>
                        <th style="height: 24px; border-right: dashed 1px #CCCCCC;">
                            描述
                        </th>
                    </tr>
                    <%
                        foreach (rmp.bean.K1V3 item in (ArrayList)w3cProp[i])
                        {
                    %>
                    <tr>
                        <td align="left" style="width: 120px; border-top: dashed 1px #CCCCCC;">
                            <%=item.K%>
                        </td>
                        <td align="left" style="border-top: dashed 1px #CCCCCC; border-right: dashed 1px #CCCCCC;">
                            <%
                                if (item.V1 == "link")
                                {
                            %>
                            参见：<a href="<%=item.V2%>" target="_self"><%=item.K%>属性</a>。
                            <%
                                }
                                else
                                {
                            %>
                            <input type="text" id="<%=item.V2%>" size="50" style="width: 300px;" />
                            <%
                                }
                            %>
                        </td>
                    </tr>
                    <tr id="tr_1">
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" style="border-right: dashed 1px #CCCCCC;">
                            <div style="border: dashed 1px #FFC0A0; background-color: #FFFFEA; width: 300px;">
                                〖简介〗：<br />
                                <%= item.V3%>
                            </div>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="460" style="border-left: dashed 1px #CCCCCC; border-bottom: dashed 1px #CCCCCC; background-color: #FAFAFA;">
                    <%
                        foreach (rmp.bean.K1V3 item in (ArrayList)spcProp[i])
                        {
                    %>
                    <tr>
                        <td align="left" style="width: 120px; border-top: dashed 1px #CCCCCC;">
                            <%=item.K%>
                        </td>
                        <td align="left" style="border-top: dashed 1px #CCCCCC; border-right: dashed 1px #CCCCCC;">
                            <%
                                if (item.V1 == "link")
                                {
                            %>
                            参见：<a href="<%=item.V2%>" target="_self"><%=item.K%>属性</a>。
                            <%
                                }
                                else
                                {
                            %>
                            <input type="text" id="Text1" size="50" style="width: 300px;" />
                            <%
                                }
                            %>
                        </td>
                    </tr>
                    <tr id="tr2">
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" style="border-right: dashed 1px #CCCCCC;">
                            <div style="border: dashed 1px #FFC0A0; background-color: #FFFFEA; width: 300px;">
                                〖简介〗：<br />
                                <%= item.V3%>
                            </div>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px;">
                <a href="#a0">返回顶部</a>
            </td>
        </tr>
        <%
            }
        %>
        <tr>
            <td align="left">
                <a id="a<%= w3cProp.Count %>"></a><strong>MIME Types：</strong>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="mimeTypes">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px;">
                <a href="#a0">返回顶部</a>
            </td>
        </tr>
    </table>
</asp:Content>

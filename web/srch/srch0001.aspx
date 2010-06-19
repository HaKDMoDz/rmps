<%@ Page Language="C#" MasterPageFile="~/srch/srch.master" AutoEventWireup="true" CodeFile="srch0001.aspx.cs" Inherits="srch_srch0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <div id="net_amonsoft_iSearch">
    </div>

    <script type="text/javascript" src="srch0001.ashx?sid=<%=rmp.comn.user.UserInfo.Current(Session).UserCode%>"></script>

    <script type="text/javascript">
            iSearcher.init('net_amonsoft_iSearch',420);
    </script>

</asp:Content>

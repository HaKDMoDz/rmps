<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1306.aspx.cs" Inherits="tool_tool1306" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
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
                        <td align="center">
                            <asp:TextBox ID="ta_MathExps" runat="server" Rows="5" TextMode="MultiLine" Width="96%"></asp:TextBox>
                            <asp:HiddenField ID="hd_MathExps" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:TextBox ID="tf_Decimals" runat="server" Columns="6" CssClass="TF_MATH" ToolTip="设置运算精度">8</asp:TextBox>
                            <input id="bt_V0" type="button" value=" CR " onclick="ito.clear()" title="清除运算结果" />
                            <input id="bt_V1" type="button" value=" <- " onclick="ito.remove(true)" title="删除一个字符" />
                            <input id="bt_V2" type="button" value=" >> " title="显示运算过程" onclick="return showExps()" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="10%" align="center">
                            <input type="button" name="button" id="bt_N7" value="7" class="BT_MATH" onclick="ito.append('7', 0)" title="数值7" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button2" id="bt_N8" value="8" class="BT_MATH" onclick="ito.append('8', 0)" title="数值8" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button3" id="bt_N9" value="9" class="BT_MATH" onclick="ito.append('9', 0)" title="数值9" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button4" id="bt_S3" value="/" class="BT_MATH" onclick="ito.append('/', 0)" title="除法运算" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button5" id="bt_P4" value="(" class="BT_MATH" onclick="ito.append('(', 0)" title="左小括号" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button6" id="bt_P5" value=")" class="BT_MATH" onclick="ito.append(')', 0)" title="右小括号" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button7" id="bt_A3" value="x^y" class="BT_MATH" onclick="ito.append('^', 0)" title="次幂运算" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button8" id="bt_T2" value="sin" class="BT_MATH" onclick="ito.append('sin()', -1)" title="正弦" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button9" id="bt_T5" value="csc" class="BT_MATH" onclick="ito.append('csc()', -1)" title="余割" />
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" align="center">
                            <input type="button" name="button6" id="bt_N4" value="4" class="BT_MATH" onclick="ito.append('4', 0)" title="数值4" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button18" id="bt_N5" value="5" class="BT_MATH" onclick="ito.append('5', 0)" title="数值5" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button19" id="bt_N6" value="6" class="BT_MATH" onclick="ito.append('6', 0)" title="数值6" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button20" id="bt_S2" value="*" class="BT_MATH" onclick="ito.append('*', 0)" title="乘法运算" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button21" id="bt_P2" value="[" class="BT_MATH" onclick="ito.append('[', 0)" title="左中括号" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button22" id="bt_P3" value="]" class="BT_MATH" onclick="ito.append(']', 0)" title="右中括号" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button23" id="bt_A2" value="√" class="BT_MATH" onclick="ito.append('√', 0)" title="方根运算" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button24" id="bt_T1" value="cos" class="BT_MATH" onclick="ito.append('cos()', -1)" title="余弦" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button25" id="bt_T4" value="sec" class="BT_MATH" onclick="ito.append('sec()', -1)" title="正割" />
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" align="center">
                            <input type="button" name="button11" id="bt_N1" value="1" class="BT_MATH" onclick="ito.append('1', 0)" title="数值1" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button26" id="bt_N2" value="2" class="BT_MATH" onclick="ito.append('2', 0)" title="数值2" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button27" id="bt_N3" value="3" class="BT_MATH" onclick="ito.append('3', 0)" title="数值3" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button28" id="bt_S1" value="-" class="BT_MATH" onclick="ito.append('-', 0)" title="减法运算" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button29" id="bt_P0" value="{" class="BT_MATH" onclick="ito.append('{', 0)" title="左大括号" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button30" id="bt_P1" value="}" class="BT_MATH" onclick="ito.append('}', 0)" title="右大括号" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button31" id="bt_A1" value="log" class="BT_MATH" onclick="ito.append('log()', -1)" title="10的对数" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button32" id="bt_T0" value="tan" class="BT_MATH" onclick="ito.append('tan()', -1)" title="正切" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button33" id="bt_T3" value="cot" class="BT_MATH" onclick="ito.append('cot()', -1)" title="余切" />
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" align="center">
                            <input type="button" name="button10" id="bt_N0" value="0" class="BT_MATH" onclick="ito.append('0', 0)" title="数值0" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button11" id="bt_S5" value="." class="BT_MATH" onclick="ito.append('.', 0)" title="小数点" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button12" id="bt_S4" value="%" class="BT_MATH" onclick="ito.append('%', 0)" title="求模（取余）运算" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button13" id="bt_S0" value="+" class="BT_MATH" onclick="ito.append('+', 0)" title="加法运算" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button14" id="bt_A6" value="π" class="BT_MATH" onclick="ito.append('π', 0)" title="圆周率" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button15" id="bt_A5" value="ê" class="BT_MATH" onclick="ito.append('ê', 0)" title="自然数" />
                        </td>
                        <td width="5%" align="center">
                            &nbsp;
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button16" id="bt_A0" value="ln" class="BT_MATH" onclick="ito.append('ln()', -1)" title="自然对数" />
                        </td>
                        <td width="10%" align="center">
                            <input type="button" name="button17" id="bt_A4" value="n!" class="BT_MATH" onclick="ito.append('!', 0)" title="阶乘" />
                        </td>
                        <td width="10%" align="center">
                            <asp:Button ID="bt_S6" runat="server" Text="=" CssClass="BT_MATH" OnClientClick="return R();" OnClick="bt_S6_Click" ToolTip="求值" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="dv_MathExps" style="display: none;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" height="20">
                                运算过程
                            </td>
                            <td align="center" width="20">
                                <input type="image" src="/_images/exit.png" alt=" X " onclick="return hideExps();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div id="dv_TextArea">
                        <table id="tb_MathExps" width="100%" border="0" cellspacing="0" cellpadding="1">
                            <%
                                rmp.bean.K1V2 item;
                                for (int i = 0; i < mathList.Count; i += 1)
                                {
                                    item = (rmp.bean.K1V2)mathList[i];
                            %>
                            <tr id="tr_MathStep<%= i %>" style="display: none">
                                <th width="20">
                                    =
                                </th>
                                <td align="left">
                                    <%=item.K.Replace(item.V1, String.Format("<span class=\"TEXT_NOTE1\">{0}</span>", item.V1))%>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <a href="#" class="exp" id="hl_LastStep" onclick="return lastStep();" style="display: none" title="显示上一步运算过程">上一步</a>&nbsp;<a href="#" class="exp" id="hl_NextStep" onclick="return nextStep();" title="显示下一步运算过程">下一步</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript" src="/<%= cons.EnvCons.PRE_URL %>code/iTextObj/c/iTextObj.js"></script>

    <script type="text/javascript" src="/<%= cons.EnvCons.PRE_URL %>code/iTextObj/c/iTextDat.js"></script>

    <script type="text/javascript">
        var mathStep = <%= mathList.Count %>;
        var currStep = 0;
    </script>

</asp:Content>

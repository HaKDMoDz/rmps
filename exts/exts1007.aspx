<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts1007.aspx.cs" Inherits="exts_exts1007" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;一、指定地址搜索：
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【说明】：
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;此方案比较灵活，适用于定制更加适合您的界面风格的网站或者应用程序。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【操作】：
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您只需要在显示查询结果时，访问如下地址即可：<br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="DV_TEXT1">
                                http://www.amonsoft.cn/tool/tool1301.aspx?exts={0}&case={1}
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="DV_TEXT1">
                                &nbsp;&nbsp;其中：<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;为您要查询的后缀名称，形如：.PDF 或 PDF；<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;{1}&nbsp;为后缀数据查询的方式：其取值如下：<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;0：大小写敏感（默认）；<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1：大写；<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2：小写；<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3：模糊查询；<br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【代码】：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <textarea id="TextArea1" readonly="readonly" rows="8" cols="44" wrap="off">
&lt;table border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot;&gt;
&nbsp;&nbsp;&lt;tr&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;q&quot; type=&quot;text&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;b&quot; accesskey=&quot;Q&quot; type=&quot;button&quot; value=&quot;查询(Q)&quot; onclick=&quot;query()&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&lt;/tr&gt;
&lt;/table&gt;
&lt;script type=&quot;text/javascript&quot;&gt;
&nbsp;&nbsp;function query()
&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;var q = document.getElementById('q').value;
&nbsp;&nbsp;&nbsp;&nbsp;var url = 'http://www.amonsoft.cn/tool/tool1301.aspx?exts=' + q + '&amp;case=0';
&nbsp;&nbsp;&nbsp;&nbsp;var wnd = 'height=400,width=520,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes';
&nbsp;&nbsp;&nbsp;&nbsp;var sub = window.open(url, 'exts', wnd);
&nbsp;&nbsp;&nbsp;&nbsp;sub.focus();
&nbsp;&nbsp;}
&lt;/script&gt;</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【示例】：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table border="0" cellspacing="0" cellpadding="3" style="border: #a3a3a3 solid 1px">
                                <tr>
                                    <td>
                                        <input id="q" type="text" value=".PDF" />
                                        <input id="b" accesskey="Q" type="button" value="查询(Q)" onclick="query1()" />

                                        <script type="text/javascript">
                                            function query1()
                                            {
                                                var url = 'http://www.amonsoft.cn/tool/tool1301.aspx?exts=' + document.getElementById('q').value + '&case=0';
                                                var wnd = 'height=400,width=520,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes';
                                                var sub = window.open(url, 'exts', wnd);
                                                sub.focus();
                                            }
                                        </script>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;二、&lt;form&gt;格式搜索：
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【代码一】：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <textarea id="TextArea2" readonly="readonly" rows="8" cols="44" wrap="off">&lt;form action=&quot;http://www.amonsoft.cn/tool/tool1301.aspx&quot; method=&quot;get&quot; name=&quot;Extparse&quot; target=&quot;_blank&quot; id=&quot;Extparse&quot;&gt;
&nbsp;&nbsp;&lt;table border=&quot;0&quot; cellspacing=&quot;0&quot; cellpadding=&quot;3&quot; style=&quot;border: #a3a3a3 solid 1px&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span style=&quot;font-size: 12px; font-family: '宋体', 'simsun', 'Arial','Times New Roman';&quot;&gt;后缀解析&lt;/span&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input name=&quot;exts&quot; type=&quot;text&quot; id=&quot;exts&quot; accesskey=&quot;X&quot; size=&quot;12&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input name=&quot;type&quot; type=&quot;submit&quot; id=&quot;type&quot; accesskey=&quot;Q&quot; value=&quot;查询(Q)&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;
&nbsp;&nbsp;&lt;/table&gt;
&lt;/form&gt;</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【示例一】：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table border="0" cellspacing="0" cellpadding="3" style="border: #a3a3a3 solid 1px">
                                <tr>
                                    <td>
                                        <span style="font-size: 12px; font-family: '宋体', 'simsun', 'Arial','Times New Roman';">后缀解析</span>
                                    </td>
                                    <td>
                                        <input name="exts1" type="text" id="exts1" accesskey="X" size="12" value=".PDF" />
                                    </td>
                                    <td>
                                        <input name="type1" type="button" id="type1" accesskey="Q" value="查询(Q)" onclick="query2()" />
                                    </td>
                                </tr>
                            </table>

                            <script type="text/javascript">
                                function query2()
                                {
                                    var url = 'http://www.amonsoft.cn/tool/tool1301.aspx?exts=' + document.getElementById('exts1').value + '&case=0';
                                    var wnd = 'height=400,width=520,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes';
                                    var sub = window.open(url, 'exts', wnd);
                                    sub.focus();
                                }
                            </script>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【代码二】：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <textarea id="TextArea3" readonly="readonly" rows="8" cols="44" wrap="off">&lt;form action=&quot;http://www.amonsoft.cn/tool/tool1301.aspx&quot; method=&quot;get&quot; name=&quot;Extparse&quot; target=&quot;_blank&quot; id=&quot;Extparse&quot;&gt;
&nbsp;&nbsp;&lt;table border=&quot;0&quot; cellspacing=&quot;0&quot; cellpadding=&quot;3&quot; style=&quot;border: #a3a3a3 solid 1px&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input name=&quot;exts&quot; type=&quot;text&quot; id=&quot;exts&quot; accesskey=&quot;X&quot; size=&quot;16&quot; style=&quot;background-image:url(http://www.amonsoft.cn/logo/logo10.png);background-position:left;background-repeat:no-repeat;padding-left:17px;&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input name=&quot;type&quot; type=&quot;submit&quot; id=&quot;type&quot; accesskey=&quot;Q&quot; value=&quot;查询(Q)&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;
&nbsp;&nbsp;&lt;/table&gt;
&lt;/form&gt;</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;【示例二】：
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table border="0" cellspacing="0" cellpadding="3" style="border: #a3a3a3 solid 1px">
                                <tr>
                                    <td>
                                        <input name="exts2" type="text" id="exts2" accesskey="X" size="16" style="background-image: url(http://www.amonsoft.cn/logo/logo10.png); background-position: left; background-repeat: no-repeat; padding-left: 17px;" value=".PDF" />
                                    </td>
                                    <td>
                                        <input name="type2" type="button" id="type2" accesskey="Q" value="查询(Q)" onclick="query3()" />
                                    </td>
                                </tr>
                            </table>

                            <script type="text/javascript">
                                function query3()
                                {
                                    var url = 'http://www.amonsoft.cn/tool/tool1301.aspx?exts=' + document.getElementById('exts2').value + '&case=0';
                                    var wnd = 'height=400,width=520,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes';
                                    var sub = window.open(url, 'exts', wnd);
                                    sub.focus();
                                }
                            </script>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

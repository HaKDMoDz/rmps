<%@ Page Language="C#" MasterPageFile="~/math/math.master" AutoEventWireup="true" CodeFile="math0002.aspx.cs" Inherits="math_math0002" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tb_NormMath">
                    <tr class="TH_MATH">
                        <td align="center">
                            <table width="450" border="0" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td align="center" style="height: 30px;">
                                        <input type="text" id="tf_Dsp" style="width: 98%;" readonly="readonly" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="TR_MATH">
                        <td align="center">
                            <table width="450" border="0" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td style="width: 70%" align="left">
                                        <input type="radio" id="rb_C16" name="carry" value="16" onclick="inputChangCarry(16)" />十六进制
                                        <input type="radio" id="rb_C10" name="carry" value="10" onclick="inputChangCarry(10)" checked="checked" />十进制
                                        <input type="radio" id="rb_C08" name="carry" value="8" onclick="inputChangCarry(8)" />八进制
                                        <input type="radio" id="rb_C02" name="carry" value="2" onclick="inputChangCarry(2)" />二进制
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <input type="radio" id="rb_Dag" name="angle" value="d" onclick="inputChangAngle('d')" checked="checked" />角度
                                        <input type="radio" id="rb_Aag" name="angle" value="r" onclick="inputChangAngle('r')" />弧度
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="TR_MATH">
                        <td align="center">
                            <table width="450" border="0" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td style="width: 60%" align="left">
                                        <input type="checkbox" id="ck_Inv" title="上档运算" onclick="inputshift()" />Inv
                                        <input type="checkbox" id="ck_Hyp" title="双曲函数" onclick="inputshift()" />Hyp
                                        <input type="text" id="tf_Bkt" size="3" title="括号运算符" readonly="readonly" />
                                        <input type="text" id="tf_Mem" size="3" title="存储区域" readonly="readonly" />
                                        <input type="text" id="tf_Opr" size="3" title="算术运算符" readonly="readonly" />
                                    </td>
                                    <td style="width: 40%" align="right">
                                        <input type="button" id="bt_Ebs" value="退格" title="删除一个字符" onclick="bs();" />
                                        <input type="button" id="bt_Ecs" value="清屏" title="清除显示数值" onclick="cs();" />
                                        <input type="button" id="bt_Eca" value="全清" title="清除显示及存储数值" onclick="ca();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="TR_MATH">
                        <td align="center">
                            <table width="450" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_P" class="BT_MATH" value="π" title="圆周率" onclick="fs('pi','pi')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_E" class="BT_MATH" value="ê" title="自然数" onclick="fs('e','e')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Dms" class="BT_MATH" value="dms" title="将显示数值转换为“度-分-秒”格式" onclick="fs('dms','deg')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Mmc" class="BT_MATH" value="MC" title="清除存储区域数值！" onclick="mc()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_7" class="BT_MATH" value="7" title="数值 7" onclick="no('7')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_8" class="BT_MATH" value="8" title="数值 8" onclick="no('8')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_9" class="BT_MATH" value="9" title="数值 9" onclick="no('9')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op2" class="BT_MATH" value="/" title="除法运算符" onclick="op('/',6)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op3" class="BT_MATH" value="Mod" title="取余数运算" onclick="op('%',6)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op4" class="BT_MATH" value="And" title="逻辑与运算" onclick="op('&amp;',3)" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op5" class="BT_MATH" value="(" title="左括号" onclick="addbracket()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op6" class="BT_MATH" value=")" title="右括号" onclick="disbracket()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Lne" class="BT_MATH" value="ln" title="自然对数" onclick="fs('ln','exp')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Mmr" class="BT_MATH" value="MR" title="将存储数值显示在显示区域，覆盖已有显示数值！" onclick="mr()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_4" class="BT_MATH" value="4" title="数值 4" onclick="no('4')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_5" class="BT_MATH" value="5" title="数值 5" onclick="no('5')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_6" class="BT_MATH" value="6" title="数值 6" onclick="no('6')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op8" class="BT_MATH" value="*" title="乘法运算符" onclick="op('*',6)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Int" class="BT_MATH" value="Int" title="取整数运算" onclick="fs('floor','deci')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Op9" class="BT_MATH" value="Or" title="逻辑或运算" onclick="op('|',1)" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Sin" class="BT_MATH" value="sin" title="正弦函数" onclick="tg('sin','arcsin','hypsin','ahypsin')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button13" class="BT_MATH" value="x^y" title="n次方运算" onclick="op('^',7)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Log" class="BT_MATH" value="log" title="常用对数" onclick="fs('log','expdec')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Mms" class="BT_MATH" value="MS" title="将显示数值保存在存储区域，覆盖已有存储数值！" onclick="ms()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_1" class="BT_MATH" value="1" title="数值 1" onclick="no('1')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_2" class="BT_MATH" value="2" title="数值 2" onclick="no('2')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_3" class="BT_MATH" value="3" title="数值 3" onclick="no('3')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button39" class="BT_MATH" value="-" title="减法运算符" onclick="op('-',5)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button40" class="BT_MATH" value="Lsh" title="左移位运算" onclick="op('&lt;',4)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button41" class="BT_MATH" value="Not" title="逻辑非运算" onclick="fs('~','~')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Cos" class="BT_MATH" value="cos" title="余弦函数" onclick="tg('cos','arccos','hypcos','ahypcos')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Cub" class="BT_MATH" value="x^3" title="3次方运算" onclick="fs('cube','cubt')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button18" class="BT_MATH" value="n!" title="阶乘运算" onclick="fs('!','!')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Mma" class="BT_MATH" value="M+" title="将显示数值与存储数值相加，并保存在存储区域！" onclick="ma()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_0" class="BT_MATH" value="0" title="数值 0" onclick="no('0')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button43" class="BT_MATH" value="+/-" title="改变显示数值的正负号" onclick="changeSign()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_D" class="BT_MATH" value="." title="小数点" onclick="no('.')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button45" class="BT_MATH" value="+" title="加法运算符" onclick="op('+',5)" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button46" class="BT_MATH" value="=" title="求值" onclick="result()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button47" class="BT_MATH" value="Xor" title="逻辑异或运算" onclick=" op('x',2)" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Tan" class="BT_MATH" value="tan" title="正切函数" onclick="tg('tan','arctan','hyptan','ahyptan')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Sqr" class="BT_MATH" value="x^2" title="2次方运算" onclick="fs('sqr','sqrt')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="button22" class="BT_MATH" value="1/x" title="倒数运算" onclick="fs('recip','recip')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_Mmm" class="BT_MATH" value="M*" title="将显示数值与存储数值相乘，并保存在存储区域！" onclick="mm()" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_a" class="BT_MATH" value="A" title="十六进制数 A" disabled="disabled" onclick="no('a')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_b" class="BT_MATH" value="B" title="十六进制数 B" disabled="disabled" onclick="no('b')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_c" class="BT_MATH" value="C" title="十六进制数 C" disabled="disabled" onclick="no('c')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_d" class="BT_MATH" value="D" title="十六进制数 D" disabled="disabled" onclick="no('d')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_e" class="BT_MATH" value="E" title="十六进制数 E" disabled="disabled" onclick="no('e')" />
                                    </td>
                                    <td align="center" style="width: 10%">
                                        <input type="button" id="bt_f" class="BT_MATH" value="F" title="十六进制数 F" disabled="disabled" onclick="no('f')" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="TR_MATH">
                        <td style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

// JScript 文件
function ipQry()
{
    var o=$E('tf_IpText');
    var e=$E('lb_IpInfo');
    var v=o.value;
    if(v==null||v=='')
    {
        e.innerHTML='请输入您要查询的IP地址！';
        o.focus();
        return false;
    }
    e.innerHTML=iask_iask130C.IpSearch(v).value;
    o.focus();
    return false;
}
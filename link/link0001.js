// JScript File
//var scs='TD_TopType_C';
//var lid=$X('tt_'+$E('hd_SID').value);
//var lcs='TD_TopType_H';
//if(lid)
//{
//    lcs=lid.className;
//    lid.className=scs;
//}

/**
 * 读取左侧类别数据
 * sid:当前类别
 * uid:当前用户
 */
function topType(tid,uid)
{
    var tmp='<table border="0" cellpadding="3" cellspacing="2" class="TB_TopType" width="100%">';
    if(trg.test(tid) && urg.test(uid))
    {
    }

    tmp+='<tr>';
    tmp+='<td align="center" class="TD_TopType_H" id="tt_'+tid+'">';
    if(trg.test(tid))
    {
        tmp+='<a href="link0001.aspx" title="返回上一级目录" onclick="return preAction(\''+tid+'\',\''+uid+'\');">上级类型</a>';
    }
    else
    {
        tmp+='<a href="link0001.aspx" title="我的导航">我的导航</a>';
    }
    tmp+='</td>';
    tmp+='</tr>';
    tmp+='</table>';

    $E('dv_TopType').innerHTML=tmp;
    $E('hd_TOP').value=tid;
    return false;
}
/**
 * 读取右侧类别数据
 * sid:当前类别
 * uid:当前用户
 */
function subType(sid,uid)
{
    var div=$E('dv_SubType');
    div.innerHTML='<img src="/_images/loading.gif"/><br />数据加载中……';
    div.innerHTML=link_link0001.readSubType(sid,uid,sys).value;
    $E('hd_SID').value=sid;
    return false;
}
/**
 * 读取当前类别链接
 * sid:当前类别
 * uid:当前用户
 */
function curLink(sid,uid)
{
    var div=$E('dv_CurLink');
    div.innerHTML='<img src="/_images/loading.gif"/><br />数据加载中……';
    div.innerHTML=link_link0001.readCurLink(sid,uid,5,sys).value;
    return false;
}
/**
 * 读取当前类别下的链接数据
 * sid:当前类别
 * uid:当前用户
 */
function topAction(sid,uid)
{
    if(lid)lid.className=lcs;
    tabShow(sid);
    subType(sid,uid);
    curLink(sid,uid);
    return false;
}
function subAction(sid,uid)
{
    var tid=$E('hd_SID').value;
    topType(tid,uid);
    tabShow(sid);
    subType(sid,uid);
    curLink(sid,uid);
    return false;
}
/**
 * 读取上一级类别数据
 * sid:当前类别
 * uid:当前用户
 */
function preAction(sid,uid)
{
    var tid=link_link0001.readPreType(sid,uid).value;
    topType(tid,uid);
    tabShow(sid);
    subType(sid,uid);
    curLink(sid,uid);
    return false;
}
function sysAction(uid)
{
    sys=$E('ck_A0000000').checked;
    var tid=$E('hd_TOP').value;
    var sid=$E('hd_SID').value;
    var uid=$E('hd_UID').value;
    topType(tid,uid);
    tabShow(sid);
    subType(sid,uid);
    curLink(sid,uid);
}
/**
 * 导航显示事件
 */
function tabShow(sid)
{
    lid=$X('tt_'+sid);
    if(lid)
    {
        lcs=lid.className;
        lid.className=scs;
    }
}
/*打开链接*/
function openLink(sid)
{
    link_link0001.updtLinkSeqs(sid);
    return true;
}
function editLink()
{
    $W().location.href='link0103.aspx?uri='+$E('hd_SID').value;
    return false;
}
function editType()
{
    $W().location.href='link0203.aspx?uri='+$E('hd_SID').value;
    return false;
}
var trg= /^[A-Z]{16}$/ ;
var urg= /^[A-Z]{8}$/ ;
var t=$E('hd_TOP').value,s=$E('hd_SID').value,u=$E('hd_UID').value;
topType(t,u);
subType(s,u);
curLink(s,u);
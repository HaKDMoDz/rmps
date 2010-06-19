// JScript 文件
var http;
function $X(o)
{
    return document.getElementById(o);
}
/**
 * 界面初始化
 */
function init()
{
    var user={'link':['user','http://amonsoft.cn/logo/logo10.png','网络导航','网络导航','网络导航','','','link({0})'],
              'host':['user','http://amonsoft.cn/logo/logo10.png','ＩＰ查询','ＩＰ查询','ＩＰ查询','','','host({0})']};
    iSearcher.init('AmonHome',420,66,'home','','',user);

    // 创建适合其他浏览器的XMLRequest
    if(window.XMLHttpRequest)
    {
        http=new XMLHttpRequest();
    }
    // 创建适合IE的 XMLHttpRequest
    if(!http)
    {
        try
        {
            http=new ActiveXObject('Msxml2.XMLHTTP');
        }
        catch(exception)
        {
            try
            {
                http=new ActiveXObject('Microsoft.XMLHTTP');
            }
            catch(exception)
            {
                http=null;
            }
        }
    }
}
/**
 * 网络导航
 */
function link(o)
{
    if(o=='engine'||o=='option')
    {
        $X('q').focus();
        return false;
    }
    if(o=='search')
    {
        var q=$X('q');
        var v=q.value;
        if(!v)
        {
            alert('请输入您要查询的链接信息（标题或网址）！');
            q.focus();
            return false;
        }
        v=v.trim();
        if(!v)
        {
            alert('请输入您要查询的链接信息（标题或网址）！');
            q.focus();
            return false;
        }

        $X('AmonGuid').innerHTML='<img src="_images/loading.gif"/><br />数据加载中……';
        http.onreadystatechange=linkAjax;
        http.open('GET','link/link0001.ashx?sid='+$X('hd_UserInfo').value+'&uri='+encodeURIComponent(v),true);
        http.send(null);
        return false;
    }
    return false;
}
/**
 * 网络导航数据处理
 */
function linkAjax()
{
    if(http.readyState==4&&http.status==200)
    {
        var htm='<table border="0" cellpadding="0" cellspacing="0" width="100%">';
        
        htm+='<tr>';
        htm+='<th align="left" style="height: 25px;"><img src="_images/1307srch.png" alt="" width="16" height="16" style="vertical-align: middle;" />&nbsp;导航搜索</th>';
        htm+='<td align="right"><img src="_images/exit.png" alt="关闭" title="关闭搜索结果" width="16" height="16" style="cursor: pointer;" onclick="return hide();" /></td>';
        htm+='</tr>';
        
        htm+='<tr>';
        htm+='<td colspan="2">';
        htm+=http.responseText;
        htm+='</td>';
        htm+='</tr>';
        
        htm+='</table>';

        $X('AmonGuid').innerHTML=htm;
    }
}
/**
 * IP查询
 */
function host(o)
{
    if(o=='engine'||o=='option')
    {
        $X('q').focus();
        return false;
    }
    if(o=='search')
    {
        var q=$X('q');
        var v=q.value;
        if(!v)
        {
            alert('请输入您要查询的IP地址！');
            q.focus();
            return false;
        }
        window.open('/tool/tool130C.aspx?sid='+encodeURIComponent(v),'amonsoft','width=500,height=200,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes');
    }
    return false;
}
init();
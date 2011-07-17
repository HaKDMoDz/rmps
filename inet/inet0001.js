// JScript File
/*分页索引*/
if(_X('Net_Amonsoft_NetHelper_TAB'+_X('hd_I').value))_X('Net_Amonsoft_NetHelper_TAB'+_X('hd_I').value).className='Net_Amonsoft_NetHelper_TABS';
if(_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR'))_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR').style.display='';
_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_DV').style.display='';
var http;
var xFun;

/**
 * TAB鼠标进入事件
 */
function tabO(obj,idx)
{
    if(_X('hd_I').value!=idx)
    {
        obj.className='Net_Amonsoft_NetHelper_TABO';
    }
}
/**
 * TAB鼠标退出事件
 */
function tabX(obj,idx)
{
    if(_X('hd_I').value!=idx)
    {
        obj.className='Net_Amonsoft_NetHelper_TABD';
    }
}
/**
 * TAB鼠标选择事件
 */
function tabS(obj,idx)
{
    if(_X('hd_I').value!=idx)
    {
        _X('Net_Amonsoft_NetHelper_HEAD').innerHTML='Amon&nbsp;'+DVNM[idx];

        _X('Net_Amonsoft_NetHelper_TAB'+_X('hd_I').value).className='Net_Amonsoft_NetHelper_TABD';
        if(_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR'))_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR').style.display='none';
        _X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_DV').style.display='none';
        _X('hd_I').value=idx;
        _X('Net_Amonsoft_NetHelper_TAB'+_X('hd_I').value).className='Net_Amonsoft_NetHelper_TABS';
        if(_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR'))_X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_TR').style.display='';
        _X('Net_Amonsoft_NetHelper_'+DVID[_X('hd_I').value]+'_DV').style.display='';
    }
}
function openLink(a)
{
    var sid=_N(a,'s','0');
    var sts='width='+_N(a,'w','480')+',height='+_N(a,'h','560')+',menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=yes';
	var url='/inet/inet0002.aspx?sid='+sid+'&f='+_X('hd_F').value+'&i='+_X('hd_I').value+'&t='+encodeURIComponent(_X('hd_T').value)+'&u='+encodeURIComponent(_X('hd_U').value)+'&d='+encodeURIComponent(_X('hd_D').value); 
    a.href=url;
    if(window.open)
    {
        window.open(url,sid,_N(a,'k','')=='bms'?sts:'');
        return false;
    }
    return true;
}
function openFull()
{
    var url='http://amonsoft.net/inet/inet0001.aspx?f='+_X('hd_F').value+'&i='+_X('hd_I').value+'&t='+encodeURIComponent(_X('hd_T').value)+'&u='+encodeURIComponent(_X('hd_U').value)+'&d='+encodeURIComponent(_X('hd_D').value);
    open(url,'amonsoft_net','width=420,height=300,menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=yes');
    return false;
}
function siteView(o,v)
{
    if(!o.checked)
    {
        _X(v+'_Site').innerHTML='……';
        _X(v+'_Link').innerHTML='……';
        return false;
    }

    var url=_X('hd_U').value;
    if(!url||url=='')
    {
        alert('无法获取您要查看的网站地址！');
        return false;
    }
    
    if(!http)
    {
        // 创建适合其他浏览器的XMLRequest
        if (window.XMLHttpRequest)
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
    if(!http)
    {
        alert('无法连接服务器！');
        return false;
    }

    try
    {
        http.open('GET','/inet/inet0031.ashx?sid='+v+'&uri='+url,true);
        http.onreadystatechange=siteResp;
        http.send(null);
        xFun=window.setTimeout('siteTout',10000);
    }
    catch(exception)
    {
        alert('服务器请求发送失败！');
    }
    return false;
}
function siteResp(data)
{
    if(http.readyState==4)
    {
        if(http.status==200)
        {
            var data=http.responseText;
            var a=data.indexOf(':');
            var b=data.indexOf(';');
            var c=data.substring(0,a);
            a=data.substring(a+1,b);
            b=data.substring(b+1);
            _X(c+'_Site').innerHTML='<a href="#" target="_blank" title="点击查看详细信息">'+a+'</a>';
            _X(c+'_Link').innerHTML='<a href="#" target="_blank" title="点击查看详细信息">'+b+'</a>';
        }
        window.clearTimeout(xFun);
        xFun=null;
    }
}
function siteTout()
{
    alert('服务器繁忙，请稍后再试！');
    window.clearTimeout(xFun);
    xFun=null;
}
function _N(obj,sid,def)
{
    obj=obj.attributes[sid];
    return obj?obj.nodeValue:def;
}
function _X(obj)
{
    return document.getElementById(obj);
}
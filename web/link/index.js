var http;
function mDim(odst,xi,yi,oimg,icnt)
{
	odst.style.backgroundPosition=(-48)*(yi-1)+'px '+(-48)*(xi-1)+'px';
	oimg.style.display=yi==icnt?'':'none';
}
/**
 * inum：动画总侦数
 */
function mAni(osrc,odst,oimg,inum,duration)
{
	// t：延时ID，c：当前第几步动画；n：动画方向（1进入，-1退出）
	var t=null,c=1,d=0,n=0,r=/over/;
	osrc.onmouseover=osrc.onmouseout=function(e)
  	{
  	    var b=r.test((e||event).type);
		osrc.style.backgroundColor=b?'#FAFAFA':'#FFFFFF';
		n=b?1:-1;
		if(!t) t=setInterval(function()
		{
			if((c==1||c==inum)&&((d==n||c+n<1)||!(d=n)))
			{
				return clearInterval(t),t=null;
			}
			mDim(odst,1,c+=d,oimg,inum);
		},
		Math.floor((duration||300)/inum));
	};
}
/**
 * 用户访问频率统计
 * sid:链接ID
 * uri:类别ID
 */
function feqs(sid,uri)
{
    if(!http)
    {
        return true;
    }
    try
    {
        http.open('GET','/link/link0002.ashx?sid='+sid+'&uri='+uri,true);
        http.onreadystatechange=function(){};
        http.send(null);
        return true;
    }
    catch(exception)
    {
        return true;
    }
}
/**
 * 我的链接：打开链接事件
 * obj:DIV对象
 * sid:链接索引
 */
function hurl(obj,sid)
{
    $W().open(obj.attributes['href'].nodeValue);
    feqs(sid);
}
/**
 * 导航查询
 */
function link(o)
{
    if(o=='search')
    {
        var q=$X('q');
        var v=q.value;
        if(v==null)
        {
            alert('请输入您要查询的链接信息（标题或网址）！');
            q.focus();
            return false;
        }
        v=v.trim();
        if(v=='')
        {
            alert('请输入您要查询的链接信息（标题或网址）！');
            q.focus();
            return false;
        }

        $X('tr_User0001').style.display='';
        $X('tr_User0002').style.display='';
        $X('tr_User0003').style.display='';
        var obj=$X('td_UserSrch');
        obj.innerHTML='<img src="/_images/loading.gif"/><br />数据加载中……';
        http.onreadystatechange=function()
        {
            if(http.readyState==4&&http.status==200)
            {
                obj.innerHTML=http.responseText;
            }
        };
        http.open('GET','/link/link0001.ashx?sid='+$E('hd_UserCode').value+'&uri='+encodeURIComponent(v),true);
        http.send(null);
    }
    return false;
}
/**
 * 隐藏搜索结果
 */
function hide()
{
    $X('tr_User0001').style.display='none';
    $X('tr_User0002').style.display='none';
    $X('tr_User0003').style.display='none';
    return false;
}
iSearcher.init('AmonSrch',420,60,'link','','link',{'link':['user','http://amonsoft.cn/logo/logo10.png','网络导航','网络导航','网络导航！','','','link({0})']});
var usr=$X('TB_LinkUser');
for(var i=0;i<usr.rows.length;i+=1)
{
    row=usr.rows[i];
    for(var j=0;j<row.cells.length;j+=1)
    {
        cel=row.cells[j];
        mAni(cel,cel.getElementsByTagName('div')[0],cel.getElementsByTagName('img')[0],7);
    }
}
    
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
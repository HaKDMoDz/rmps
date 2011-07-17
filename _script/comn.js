/**
 * 获取文档中document对象的引用。
 */
function $D()
{
    return document;
}
/**
 * 获取文档中window对象的引用。
 */
function $W()
{
    return window;
}
/**
 * 获取文档中指定ID的（含有MasterPage中ASP.net）对象的引用。
 */
function $E(obj)
{
    return $D().getElementById(_PRE+obj);
}
/**
 * 获取文档中指定ID的（非ASP.net）对象的引用。
 */
function $X(obj)
{
    return $D().getElementById(obj);
}
/**
 * 获取事件对象的事件源。
 */
function $O(evt)
{
    return evt.srcElement||evt.target;
}
function $K(evt)
{
    return evt.keyCode||evt.witch;
}
/**
 * 获取页面中AmonForm对象的引用。
 */
function $F()
{
    return $E('AmonForm');
}
function $A(url)
{
    if(url==null||url=='')
    {
        return;
    }
    if(url.toLowerCase().indexOf('http://')!=0)
    {
        url='http://'+url;
    }
    window.open(url,'AmonLink');
}

function $H(src,dst)
{
    $D().onkeypress=function(evt)
    {
        if(!evt)
        {
            evt=$W().event;
        }
        if(evt.keyCode!=13)
        {
            return evt.keyCode;
        }
        var src=evt.srcElement||evt.target;
        if(src.id==_PRE+src)
        {
            return $E(dst).click();
        }
        return false;
    }
}

/**
 * 获取指定元素的页面偏移位置
 */
function $L(obj)
{
	var a=0;
	var b=0;
	do
	{
		a+=obj.offsetLeft||0;
		b+=obj.offsetTop||0;
		obj=obj.offsetParent;
	}while(obj);
	return [a,b];
}

/**
 * 获取元素的自定义属性
 * o:DOM节点
 * n:自定义属性名称
 * d:默认返回值
 */
function $N(o,n,d)
{
	if(o)
	{
		o=o.getAttribute(n);
	}
	return o?o:d;
}

/**
 * 获取页面可视区域大小
 */
function $P()
{
	if(typeof ($W().innerWidth)=='number')
	{
		return [$W().innerWidth,$W().innerHeight];
	}

	var o =$D().documentElement;
	if(o&&(o.clientWidth||o.clientHeight))
	{
		return [o.clientWidth,o.clientHeight];
	}

	o=$D().body;
	if(o&&(o.clientWidth||o.clientHeight))
	{
		return [o.clientWidth,o.clientHeight];
	}

	return [0,0];
}

/**
 * 页面偏移位置
 */
function $R()
{
	if(typeof ($W().pageYOffset)=='number')
	{
		return [$W().pageXOffset,$W().pageYOffset];
	}

	var o=$D().documentElement;
	if(o&&(o.scrollLeft||o.scrollTop))
	{
		return [o.scrollLeft,o.scrollTop];
	}

	o=$D().body;
	if(o&&(o.scrollLeft||o.scrollTop))
	{
		return [o.scrollLeft,o.scrollTop];
	}

	return [0,0];
}
String.prototype.trim=function()
{
	return this.replace(/(^\s*)|(\s*$)/g,'');
};
String.prototype.ltrim=function()
{
	return this.replace(/(^\s*)/g,'');
};
String.prototype.rtrim=function()
{
	return this.replace(/(\s*$)/g,'');
};
String.prototype.trimc=function(src,dst)
{
	if(!src||src=='')
	{
		src='\\s';
	}
	if(!dst)
	{
		dst='';
	}
	return this.replace(new RegExp('^('+src+')*|('+src+')*$','g'),dst);
};
String.prototype.ltrimc=function(src,dst)
{
	if(!src||src=='')
	{
		src='\\s';
	}
	if(!dst)
	{
		dst='';
	}
	return this.replace(new RegExp('^('+src+')*','g'),dst);
};
String.prototype.rtrimc=function(src,dst)
{
	if(!src||src=='')
	{
		src='\\s';
	}
	if(!dst)
	{
		dst='';
	}
	return this.replace(new RegExp('('+src+')*$','g'),dst);
};
/**
 * 设置读取Cookie
 * n-name Cookie存取名称
 */
function cg(n,d)
{
	var k=$D().cookie;
	if(k)
	{
		k=k.match(new RegExp("(^| )"+n+"=([^;]*)(;|$)"));
	}
	return k ? unescape(k[2]) : d;
}

/**
 * 设置Cookie
 * n-name Cookie存取名称
 * v-value Cookie数据
 * x-expires Cookie过期时间
 * p-path
 * d-domain
 * s-secure
 */
function cs(n,v,x,p,d,s)
{
    if(x)
    {
        /*1000 * 60 * 60 * 24;*/
        x=x*86400000;
    }

    var t=new Date();
    t.setTime(t.getTime()+(x));
    $D().cookie=n+'='+escape(v)+((x)?';expires='+t.toGMTString():'')+((p)?';path='+p:'')+((d)?';domain='+d:'')+((s)?';secure':'');
}

/**
 * 删除Cookie
 * n-name Cookie存取名称
 * p-path
 * d-domain
 */
function cd(n,p,d)
{
    if(cg(n))
    {
        $D().cookie=n+'='+((p)?';path='+p:'')+((d)?';domain='+d:'')+';expires=Thu,01-Jan-1970 00:00:01 GMT';
    }
}
/**
 * 安装Google Gears。
 * sid:Amon软件ID
 * url:Gears路径
 * name:Gears名称
 * desp:Gears提示
 */
function GG(sid,url,name,desp)
{
	if (!window.google||!google.gears)
	{
	    if($W().confirm('您的浏览器尚未安装Google Gears，现在要安装吗？'))
	    {
		    location.href='http://gears.google.com/?action=install&message=your welcome message&return='+url;
		}
		return false;
	}
	// Cookie判断是否没有
	if(cg('com_amonsoft_gears_'+sid,false)&&!$W().confirm('您已经安装过名称为 '+name+' 的Google Gears，确认要重新安装吗？'))
    {
        return false;
    }
	google.gears.factory.create('beta.desktop').createShortcut(name,url,{'48x48': 'http://amonsoft.cn/logo/logo30.png','32x32': 'http://amonsoft.cn/logo/logo20.png','24x24': 'http://amonsoft.cn/logo/logo18.png','16x16': 'http://amonsoft.cn/logo/logo10.png'},desp);
	// 记录Cookie
	cs('com_amonsoft_gears_'+sid,1,365);
	return true;
}

/**
 * 根据元素ID获取元素左上角所在页面偏移位置
 */
function getElementPos(elementId)
{
    var ua=navigator.userAgent.toLowerCase();
    var isOpera=(ua.indexOf('opera')!=-1);
    var isIE=(ua.indexOf('msie')!=-1 && !isOpera);
    var el=document.getElementById(elementId);
    if(el.parentNode === null||el.style.display=='none')
    {
        return false;
    }
    var parent=null;
    var pos=[];
    var box;
    if(el.getBoundingClientRect)
    {
        //IE
        box=el.getBoundingClientRect();
        var scrollTop=Math.max(document.documentElement.scrollTop,document.body.scrollTop);
        var scrollLeft=Math.max(document.documentElement.scrollLeft,document.body.scrollLeft);
        return {x:box.left+scrollLeft,y:box.top+scrollTop};
    }
    else if(document.getBoxObjectFor)
    {
        // gecko
        box=document.getBoxObjectFor(el);
        var borderLeft=(el.style.borderLeftWidth)?parseInt(el.style.borderLeftWidth):0;
        var borderTop=(el.style.borderTopWidth)?parseInt(el.style.borderTopWidth):0;
        pos=[box.x-borderLeft,box.y-borderTop];
    }
    else
    {
        // safari & opera
        pos=[el.offsetLeft,el.offsetTop];  
        parent=el.offsetParent;     
        if(parent!=el)
        {
            while(parent)
            {
                pos[0]+=parent.offsetLeft;
                pos[1]+=parent.offsetTop;
                parent=parent.offsetParent;
            }
        }
        if(ua.indexOf('opera')!=-1||( ua.indexOf('safari')!=-1 && el.style.position=='absolute' ))
        {
            pos[0] -= document.body.offsetLeft;
            pos[1] -= document.body.offsetTop;
        }
    }
    if(el.parentNode)
    {
        parent=el.parentNode;
    }
    else
    {
        parent=null;
    }
    
    while (parent && parent.tagName!='BODY' && parent.tagName!='HTML')
    {
        // account for any scrolled ancestors
        pos[0] -= parent.scrollLeft;
        pos[1] -= parent.scrollTop;
        if(parent.parentNode)
        {
            parent=parent.parentNode;
        }
        else
        {
            parent=null;
        }
    }
    return {x:pos[0],y:pos[1]};
}
function showMesg(msg)
{
    $E('lb_ErrMsg').innerHTML=msg;
}
/**
 *
 */
function addFavorite(url,name,desc)
{
    name='Amon在线-'+name;
    if(navigator.userAgent.indexOf('MSIE')>=0)
    {
        if(window.external)
        {
            window.external.AddFavorite(url,name);
        }
        else
        {
            alert('无法访问您的收藏夹，请手动保存下面的地址：\n'+url);
        }
    }
    else if(navigator.userAgent.indexOf('Firefox')>=0)
    {
        if(window.sidebar)
        {
            window.sidebar.addPanel(name,url,desc);
        }
        else
        {
            alert('无法访问您的收藏夹，请手动保存下面的地址：\n'+url);
        }
    }
    else if(navigator.userAgent.indexOf('Safari')>=0)
    {
        if(window.sidebar)
        {
            window.sidebar.addPanel(name,url,desc);
        }
        else
        {
            alert('无法访问您的收藏夹，请手动保存下面的地址：\n'+url);
        }
    }
    else
    {
        alert('无法打开您浏览器的收藏夹，请手动添加本页面，对此引起的不便，作者深表歉意！');
    }
    return false;
}
function openWnd(s,w,h)
{
    var f=$W().open(s,'amonsoft','width='+w+',height='+h+',toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=yes');
    f.focus();
    return false;
}
function isHash(t)
{
    if(!t)
    {
        return false;
    }
    var reg=/^[A-Za-z]{4},([0-9]{4},[0-9A-Za-z]{16}|_[A-Z]{3})$/;
    return reg.test(t);
}
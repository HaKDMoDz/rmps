/**
 * t:搜索引擎提示，用于显示当前使用的搜索引擎，与p对应。
 * 
 * p:搜索引擎协议，如google,baidu,yahoo等。
 * a:协议选择按钮，触发m菜单
 * m:搜索引擎菜单，用于选择不同的搜索引擎
 *
 * u:用户可配置DIV
 * q:用户录入内容，对应为文本框
 *
 * i:搜索按钮DIV 
 * s:执行搜索按钮
 *
 * f:搜索引擎功能，如web,news,image等。
 * b:功能选择按钮，触发o菜单
 * o:功能选项，用于不同的功能，与f对应。
 *
 */
if(!iSearcher)
{
    String.prototype.trim=function()
    {
        return this.replace(/(^\s*)|(\s*$)/g,'');
    };
    var iSearcher=new(function()
    {
        var _DOC=document;
        var _WIN=window;

        var DCLN='\uff1a';
        var DEFP='amon';
        var DEFO='';
		var DEFC='';

        /*类自身引用*/
        var THIS=this;

        /*服务器路径*/
        var HOST='http://amonsoft.net/';
        //var HOST='http://localhost:5606/web/';
        var PATH=HOST+'srch/';
        var NAME='iSearcher';
        var _PRE='Net_Amonsoft_';
        var _REG=/^0|[a-z]{16}$/;
        
        /*上一次显示A菜单*/
        var preA;
        /*上一次显示O菜单*/
        var preO;
        /*搜索引擎协议*/
        var srcP;
        /*搜索引擎功能*/
        var srcO;
        /*ALT键按下标记*/
        var altk;

        // 数据格式
        {$DATA$}

        /**
         * 全能搜索初始化
         */
        THIS.init=function()
        {
            // 0:容器 DIV
            var sid=_M(arguments[0],'');

            // 1:搜索区域宽度
            var w=_M(arguments[1],300);
            if(w<300)
            {
                w=300;
            }

            // 2:搜索区域高度
            var h=_M(arguments[2]);

            // 3:默认Cookie标记值
            DEFC=_M(arguments[3],'');

            // 4:默认搜索引擎
            DEFP=_M(arguments[4],'amon');

			// 5:默认功能选项
            DEFO=_M(arguments[5],'');
			
            // 6:用户选项
            var u=_M(arguments[6]);
            var o=DVDT['amon'];
            o['exts']=['user','http://amonsoft.cn/logo/logo10.png','后缀解析','后缀解析','后缀解析，为您提供更为详细的文件扩展名信息！','','','iSearcher.exts({0})'];
            o['math']=['user','http://amonsoft.cn/logo/logo10.png','计算助理','计算助理','计算助理','','','iSearcher.math({0})'];
            if(u)
            {
                for(var i in u)
                {
                    if(!o[i])
                    {
                        o[i]=u[i];
                    }
                }
            }

            // 读取用户偏好
            srcP=cg('srcP',DEFP);
            srcO=cg('srcO',DEFO);

            THIS.styles(_PRE+NAME+'_CSS', PATH+'c/'+NAME+'.css');
            var t='<div id="'+_PRE+NAME+'">'+divS(w,h);
            t+='<div id="'+_PRE+NAME+'_m" class="pop" style="display:none;width:'+(w-104)+'px;height:260px;overflow:auto;">'+divM()+'</div>';
            t+='<div id="'+_PRE+NAME+'_o" class="pop" style="display:none;width:77px;">'+divO(srcP,srcO)+'</div>';
            t+='</div>';
            THIS.append(sid, t);

            _A(_DOC,'keypress',keyp);
            _A(_DOC,'keydown',keyp);
            _A(_DOC,'keyup',keyp);

            THIS.blur(_PRE+NAME+'_m');
            THIS.blur(_PRE+NAME+'_o');

            preA=_X(_PRE+NAME+'_m_user');
			preA.style.display='';
            o=DVDT[srcP];
            if(o)
            {
                o=o[srcO];
                if(o)
                {
                    t=_X(_PRE+NAME+'_t');
                    if(t)
                    {
                        t.innerHTML=o[2]+DCLN;
                        t.title=o[4];
                    }
                    preO=_X(_PRE+NAME+'_o_'+srcO);
                    if(o[7])
                    {
                        eval(o[7].replace('{0}','"engine"'));
                    }
                }
            }
        };

        /**
         * 向指定ID的DIV标签内添加HTML内容
         * sid:DIV标记ID，若为空则添加内容到BODY子节点列表末尾；若不存在，则创建对应ID的DIV
         * txt:HTML文本
         */
        THIS.append=function(sid,txt)
        {
            var obj;
            if(!sid)
            {
                obj=_DOC.getElementsByTagName('body')[0];
            }
            else
            {
                obj=_X(sid);
                if(!obj||obj.tagName.toLowerCase()!='div')
                {
                    obj=_DOC.createElementNS?_DOC.createElementNS('http://www.w3.org/1999/xhtml','div'):_DOC.createElement('div');
                    obj.id=sid;
                    var tag=_DOC.getElementsByTagName('body');
                    if(tag&&tag[0])
                    {
                        tag[0].appendChild(obj);
                    }
                }
            }
            if(obj)
            {
                obj.innerHTML+=txt;
                return true;
            }
            return false;
        };

        /**
         * 动态添加CSS样式文件引用
         * sid:样式标签ID
         * url:样式文件路径
         */
        THIS.styles=function(sid,url)
        {
            if(_X(sid))
            {
                return true;
            }
            var docHead=_DOC.getElementsByTagName('head');
            if(docHead&&docHead[0])
            {
                var css=_DOC.createElementNS?_DOC.createElementNS('http://www.w3.org/1999/xhtml','link'):_DOC.createElement('link');
                css.id=sid;
                css.rel='stylesheet';
                css.type='text/css';
                css.href=url;
                docHead[0].appendChild(css);
                return true;
            }
            return false;
        };

        /**
         * 键盘快捷键事件
         * evt:键盘事件
         */
        function keyp(evt)
        {
            evt=_E(evt);
            var own;

            if(evt.type=="keydown")
            {
                var key=_K(evt);
                if(altk)
                {
                    switch(key)
                    {
                        case 77:
                        case 109:THIS.showM();own=true;break;
                        case 79:
                        case 111:THIS.showO();own=true;break;
                        case 81:
                        case 113:THIS.srch();own=true;break;
                        default:break;
                    }
                }
                else
                {
                    if(key==18)
                    {
                        altk=true;
                        return false;
                    }
                    // IE下回车事件
                    if("\v"=="v"&&key==13&&_C(evt).id=='q')
                    {
                        THIS.srch();
                        return false;
                    }
                }
            }
            if(evt.type=="keyup")
            {
                if(altk)altk=false;
                return false;
            }
            if(evt.type=="keypress")
            {
                if(altk)
                {
                    //key=_K(evt);
                    own=true;
                }
            }

            if (own)
            {
                if(evt.preventDefault)
                {
                    evt.preventDefault();
                }
                evt.returnValue = false;
                evt.keyCode = 0;
                return false;
            }
            return evt;
        }

        /**
         * 搜索交互区域
         * w:全能搜索宽度
         * h:全能搜索高度
         */
        function divS(w,h)
        {
            if(h&&h>24)
            {
                h=(h-24)/2;
            }
            var t='<table border="0" cellpadding="0" cellspacing="0" width="'+w+'">';

            // 用户自定义功能1
            t+='<tr id="'+_PRE+NAME+'_tr">';
            t+='<td id="'+_PRE+NAME+'_td" align="center" colspan="2" '+(h?'style="height:'+h+'px;"':'')+'>&nbsp;</td>';
            t+='</tr>';

            // 全能搜索功能区域
            t+='<tr id="'+_PRE+NAME+'_s">';

            // 搜索内容输入区域
            t+='<td id="'+_PRE+NAME+'_q" align="center" class="tqd">';
            t+='<table cellpadding="0" cellspacing="0" width="100%" class="tbq">';
            t+='<tr>';
            t+='<td class="tdt" align="right"><div id="'+_PRE+NAME+'_t">全能搜索：</div></td>';
            t+='<td class="tdq" align="center"><input type="text" id="q" name="q" style="width:'+(w-230)+'px;" onfocus="iSearcher.gf();" onblur="iSearcher.lf();" /></td>';
            t+='<td class="tda" align="center"><img id="'+_PRE+NAME+'_a" alt="▼" src="'+PATH+'_i/a.gif" style="cursor:pointer;" title="显示搜索引擎" width="16" height="16" onmouseover="" onmouseout="" onclick="iSearcher.showM();" /></td>';
            t+='</tr>';
            t+='</table>';
            t+='</td>';

            t+='<td id="'+_PRE+NAME+'_i" align="center">';
            t+='<input type="image" id="'+_PRE+NAME+'_s" alt="搜索(S)" src="'+PATH+'_i/s.gif" title="搜索" onclick="return iSearcher.srch();" />';
            t+='<img id="'+_PRE+NAME+'_b" alt="▼" src="'+PATH+'_i/b.gif" style="cursor:pointer;" title="切换功能选项" width="14" height="22" onmouseover="" onmouseout="" onclick="iSearcher.showO();" />';
            t+='</td>';

            t+='</tr>';

            // 用户自定义功能1
            t+='<tr id="'+_PRE+NAME+'_br">';
            t+='<td id="'+_PRE+NAME+'_bd" align="center" colspan="2" '+(h?'style="height:'+h+'px;"':'')+'>&nbsp;</td>';
            t+='</tr>';

            t+='</table>';

            return t;
        }

        /**
         * 功能菜单
         */
        function divM()
        {
            var t='<table border="0" cellpadding="0" cellspacing="0" width="100%">';
            t+='<tr><td id="'+_PRE+NAME+'_k" valign="top" style="width:24px;">'+divK()+'</td><td id="'+_PRE+NAME+'_a" valign="top">';
            for(var i in DVID)
            {
                t+=divA(i);
            }
            t+='</td></tr>';
            t+='</table>';

            return t;
        }

        /**
         * 用户配置类别导航
         */
        function divK()
        {
            var t='<table border="0" cellpadding="0" cellspacing="0" width="100%">';
            var o;
            var j=0;
            for(var i in DVID)
            {
                o=DVID[i];
                if(!o)
                {
                    continue;
                }
                t+='<tr class="tkd" onmouseover="this.className=\'tko\';" onmouseout="this.className=\'tkd\';" onclick="iSearcher.showA('+(j++)+',\''+i+'\');">';
                t+='<td align="center" title="'+o[1]+'" style="height:24px;"><img src="'+PATH+'_i/'+(o[0]||'0')+'.gif" width="16" height="16" alt="" /></td>';
                t+='</tr>';
            }
            t+='</table>';

            return t;
        }

        /**
         * 用户配置数据菜单
         * k:类别索引
         */
        function divA(k)
        {
            var t='<table id="'+_PRE+NAME+'_m_'+k+'" border="0" cellpadding="1" cellspacing="1" width="100%" style="display:none;">';
            for (var i in DVDT)
            {
                for(var j in DVDT[i])
                {
                    var o=DVDT[i][j];
                    if(o&&o[0]==k)
                    {
                        t+='<tr class="tid" title="'+o[4]+'" onmouseover="this.className=\'tio\';" onmouseout="this.className=\'tid\';" onclick="return iSearcher.chngA(\''+i+'\',\''+j+'\');">';
                        t+='<td height="20" align="left"><img src="'+(_REG.test(o[1])?PATH+'srch0002.ashx?sid=':'')+o[1]+'" width="16" height="16" alt="" />'+o[2]+'</td>';
                        t+='</tr>';
                    }
                }
            }
            t+='</table>';

            return t;
        }

        /**
         * 选项菜单
         * p:搜索引擎
         * f:默认选项
         */
        function divO(p,f)
        {
            var t='<table border="0" cellpadding="1" cellspacing="0" width="100%">';
            p=DVDT[p];
            if(p)
            {
                var o;
                for(var i in p)
                {
                    o=p[i];
                    t+='<tr class="tid" title="'+o[4]+'" onmouseover="this.className=\'tio\';" onmouseout="this.className=\'tid\';" onclick="return iSearcher.chngO(\''+i+'\');">';
                    t+='<td align="center" style="width:18px;"><img id="'+_PRE+NAME+'_o_'+i+'" src="'+PATH+'_i/'+(i==f?'c':'d')+'.gif" alt="" width="16" height="16"/></td><td align="left">'+o[2]+'</td>';
                    t+='</tr>';
                }
            }
            t+='</table>';

            return t;
        }

        /**
         * 设置读取Cookie
         * n:name Cookie存取名称
         * d:default value默认返回值
         */
        function cg(n,d)
        {
			n+='_'+DEFC;
            var k=_DOC.cookie;
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
			n+='_'+DEFC;
            if(x)
            {
                /*1000 * 60 * 60 * 24;*/
                x=x*86400000;
            }

            var t=new Date();
            t.setTime(t.getTime()+(x));
            _DOC.cookie=n+'='+escape(v)+((x)?';expires='+t.toGMTString():'')+((p)?';path='+p:'')+((d)?';domain='+d:'')+((s)?';secure':'');
        }
        
        /**
         * 显示功能菜单
         */
        THIS.showM=function()
        {
            var o=_X(_PRE+NAME+'_m');
            if(o.style.display=='none')
            {
                var l=_L(_X(_PRE+NAME+'_q'));
                o.style.top=(l[1]+21)+'px';
                o.style.left=l[0]+'px';
                o.style.display='';
            }
            else
            {
                o.style.display='none';
            }
        };

        /**
         * 显示搜索引擎
         * i:偏移量
         * f:功能ID
         */
        THIS.showA=function(i,f)
        {
            // 隐藏上一个选项列表
            if(preA)
            {
                preA.style.display='none';
            }
            
            // 显示当前选项列表
            preA=_X(_PRE+NAME+'_m_'+f);
            if(preA)
            {
                preA.style.display='';
            }
            
            _X(_PRE+NAME+'_k').style['backgroundPosition']='0px '+24*i+'px';
        };

        /**
         * 显示选项菜单
         */
        THIS.showO=function()
        {
            var o=_X(_PRE+NAME+'_o');
            if(o.style.display=='none')
            {
                var l=_L(_X('s'));
                o.style.top=(l[1]+20)+'px';
                o.style.left=l[0]+'px';
                o.style.display='';
            }
            else
            {
                o.style.display='none';
            }
        };
        
        /**
         * 搜索引擎切换
         * p:搜索引擎索引
         * o:搜索引擎功能
         */
        THIS.chngA=function(p,o)
        {
            _X(_PRE+NAME+'_m').style.display='none';
            _X(_PRE+NAME+'_td').innerHTML='&nbsp;';
            _X(_PRE+NAME+'_bd').innerHTML='&nbsp;';

            srcP=p;
            srcO=o;
            var t=DVDT[p][o];
            
            // 显示搜索引擎信息
            if(t)
            {
                o=_X(_PRE+NAME+'_t');
                o.innerHTML=t[2]+DCLN;
                o.title=t[4];
                t=t[7];
            }
            
            // 显示选项菜单
            _X(_PRE+NAME+'_o').innerHTML=divO(srcP,srcO);
            
            // 记录Cookie
            cs('srcP',srcP,365);
            cs('srcO',srcO,365);
            
            // 回调函数
            if(t)
            {
                //搜索引擎切换
                eval(t.replace('{0}','"engine"'));
            }
        };
        
        /**
         * 搜索功能切换
         * o:搜索引擎功能
         */
        THIS.chngO=function(o)
        {
            // 功能菜单隐藏
            _X(_PRE+NAME+'_o').style.display='none';

            // 记录选项索引
            srcO=o;
            
            // 显示搜索引擎功能
            var t=DVDT[srcP][srcO];
            if(t)
            {
                o=_X(_PRE+NAME+'_t');
                o.innerHTML=t[2]+DCLN;
                o.title=t[4];
                t=t[7];
            }
            
            // 改变功能的选中状态
            if(preO)
            {
                preO.src=PATH+'_i/d.gif';
            }
            preO=_X(_PRE+NAME+'_o_'+srcO);
            if(preO)
            {
                preO.src=PATH+'_i/c.gif';
            }

            // 记录Cookie
            cs('srcO',srcO,365);
            
            // 回调函数
            if(t)
            {
                //功能选项切换
                eval(t.replace('{0}','"option"'));
            }
        };

        /**
         * 执行搜索
         */
        THIS.srch=function()
        {
            var q=_X('q');
            var v=q.value;
            if(!v)
            {
                alert('请输入您要查询的内容！');
                q.focus();
                return false;
            }
            v=v.trim();
            if(v=='')
            {
                alert('请输入您要查询的内容！');
                q.focus();
                return false;
            }
            if(!srcP||!srcO)
            {
                alert('请选择您要使用的搜索引擎！');
                q.focus();
                return false;
            }
            
            q=DVDT[srcP][srcO];
            if(q[7])
            {
                try
                {
                    // 执行搜索功能
                    eval(q[7].replace('{0}','"search"'));
                }
                catch(exception)
                {
                }
            }
            else
            {
                if(q[6])
                {
                    v=eval(q[6]+"('"+v+"')");
                }
                _WIN.open(q[5].replace('{0}',v),'net_amonsoft');
            }
            
            // 统计
            new Image().src=PATH+'srch0003.ashx?sid='+srcO+'&uri='+USER;
            return false;
        };
        
        /**
         * Amon专用搜索引擎
         * o:选项，engine表示搜索引擎切换；option表示功能选项切换；search表示执行数据查询
         */
        THIS.exts=function(o)
        {
            if(o=='engine'||o=='option')
            {
                var htm='<input accesskey="R" id="ExtparseB" value="3" type="radio" name="ExtsCase" /><label for="ExtparseB">模糊查询(R)</label>';
                htm+='<input accesskey="H" id="ExtparseH" value="0" type="radio" name="ExtsCase" checked="checked" /><label for="ExtparseH">大小敏感(H)</label>';
                htm+='<input accesskey="U" id="ExtparseU" value="1" type="radio" name="ExtsCase" /><label for="ExtparseU">大写(U)</label>';
                htm+='<input accesskey="L" id="ExtparseL" value="2" type="radio" name="ExtsCase" /><label for="ExtparseL">小写(L)</label>';
                _X(_PRE+NAME+'_td').innerHTML=htm;
                var q=_X('q');
                if(!(q.value.trim()))
                {
                    q.value='.PDF';
                }
                q.focus();
                return false;
            }
            if(o=='search')
            {
                var exts=_X('q').value.toString().trim();
                if(exts.indexOf('.')!=0)
                {
                    exts='.'+exts;
                }
                var caze='0';
                if(_X('ExtparseU').checked)
                {
                    caze='1';
                }
                else if(_X('ExtparseL').checked)
                {
                    caze='2';
                }
                else if(_X('ExtparseB').checked)
                {
                    caze='3';
                }
                _WIN.open('http://amonsoft.cn/exts/exts0001.aspx?exts='+encodeURIComponent(exts)+'&case='+caze,'net_amonsoft');
                return false;
            }
            return false;
        };
        
        /**
         * 计算助理
         */
        THIS.math=function(o)
        {
            if(o=='engine'||o=='option')
            {
                return false;
            }
            if(o=='search')
            {
                return false;
            }
            return false;
        };

        /**
         * 鼠标点击时隐藏指定名称的对象。
         * sid:DIV名称
         * clk:true鼠标点击对象不为指定对象或其子对象时退出；
         *     false鼠标退出对象或其子对象时退出。
         */
        THIS.blur=function(sid)
        {
            _A(_DOC,'mouseup',function(evt)
            {
                evt=_E(evt);
                // 判断是否为鼠标左键
                if(!_B(evt).left)
                {
                    return;
                }
                var src=_C(evt);
                var out=true;
                while(src)
                {
                    if(src.id==sid)
                    {
                        out=false;
                        break;
                    }
                    src=src.offsetParent;
                }
                if(out)_X(sid).style.display='none';
            });
        };
        
        /**
         * 搜索区域获取焦点事件
         */
        THIS.gf=function()
        {
            _X(_PRE+NAME+'_q').className='tqo';
        };
        
        /**
         * 搜索区域失去焦点事件
         */
        THIS.lf=function()
        {
            _X(_PRE+NAME+'_q').className='tqd';
        };

        /**
         * 为对象添加事件
         * o:DOM对象
         * e:事件
         * f:方法
         */
        function _A(o,e,f)
        {
            if(o.addEventListener)
            {
                o.addEventListener(e,f,false);
            }
            else if(o.attachEvent)
            {
                o.attachEvent('on'+e,f);
            }
            else
            {
                o['on'+e]=f;
            }
        }

        /**
         * 鼠标键盘事件判断
         */
        function _B(evt)
        {
            var btn={};
            if(!+"\v1")
            {
                switch(evt.button)
                {
                    case 1:btn.left = true;
                        break;
                    case 2:btn.right = true;
                        break;
                    case 4:btn.middle = true;
                        break;
                }
            }
            else
            {
                switch(evt.which)
                {
                    case 1:btn.left = true;
                        break;
                    case 2:btn.middle = true;
                        break;
                    case 3:btn.right = true;
                        break;
                }
            }
            return btn;
        }

        /**
         * 获取事件源
         */
        function _C(evt)
        {
            return evt.target||evt.srcElement;
        }

        /**
         * 获取鼠标事件对象
         */
        function _E(evt)
        {
            return evt||_WIN.event;
        }

        /**
         * 计算给定元素在页面中的偏移位置
         */
        function _L(obj)
        {
            var x=0;
            var y=0;
            do
            {
                x+=obj.offsetLeft||0;
                y+=obj.offsetTop||0;
                obj=obj.offsetParent;
            }while(obj);
            return [x,y];
        }
            
        /**
         * 判断给定字符串是否为空，若为空，则返回默认字符串
         */
        function _M(str,def)
        {
            return (str==null||str=='')?def:str;
        }

        function _K(evt)
        {
            return evt.which||evt.keyCode;
        }

        /**
         * 获取页面指定元素
         */
        function _X(id)
        {
            if(!id)
            {
                return null;
            }
            if (typeof(id)=='string')
            {
                return _DOC.getElementById(id);
            }
            return id;
        }
    })();
}
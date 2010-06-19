/******************************************************************************
 * Javascript Document
 * NetHelper v3.4.0.0 Build 2009-09-01
 * http://amonsoft.net/
 * Copyright (c) 2009 Amonsoft.net
 ******************************************************************************/
if(!iNetHelper)
{
    String.prototype.trim=function()
    {
        return this.replace(/(^\s*)|(\s*$)/g,'');
    };
    String.prototype.lPad=function(size,fill)
    {
        var text=this;
        while(text.length<size)
        {
            text=fill+text;
        }
        if(text.length>size)
        {
            text=text.substring(text.length-size);
        }
        return text;
    };

    var iNetHelper=new(
        function()
        {
            ///////////////////////////////////////////////////////////////////////////////////////
            // 系统成员区域
            ///////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////
            // 系统常量
            ///////////////////////////////////////////////////////////////////            
            var _DOC=document;
            var _WIN=window;

            /*类自身引用*/
            var THIS=this;
            
            /*服务器路径*/
            var HOST='http://amonsoft.net/';
            var PATH=HOST+'inet/';
            var NAME='NetHelper';
            var _PRE='Net_Amonsoft_';

            ///////////////////////////////////////////////////////////////////
            // 共用变量
            ///////////////////////////////////////////////////////////////////
            /*用户配置参数：显示DIV层的左偏移量*/
            var offL=1;
            /*用户配置参数：显示DIV层的上偏移量*/
            var offT=1;
            
            /////////////////////////////////////////////////////////////////////////////
            // 页面参数
            /////////////////////////////////////////////////////////////////////////////
            /*页面参数：主机地址*/
            var xHst='';
            /*页面参数：页面地址*/
            var xUrl='';
            /*页面参数：页面标题*/
            var xTtl='';
            /*页面参数：页面摘要*/
            var xDsc='';
            
            /////////////////////////////////////////////////////////
            // 助理模块参数
            /////////////////////////////////////////////////////////
            /**
             * 用户配置：链接显示方式
             *     icon_text:图标与文本
             *     icon:图标
             *     text:文本
             */
            var xViw='icon_text';
            /*分页索引*/
            var tabi=0;
            /*分页索引*/
            var tabc;
            /*Ajax对象*/
            var http;
            
            /////////////////////////////////////////////////////////
            // 划词搜索参数
            /////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////
            // 日历模块参数
            /////////////////////////////////////////////////////////
            /*日历显示方式（menu：菜单；link：文本）*/
            var xMod;
            /*用户配置：一周中第一天（0表示星期日，1表示星期一，依此递推）*/
            var xWfd=0;
            /*日历关联组件名称*/
            var xCdc;
            /*用户配置：日历控件显示格式*/
            var xCdf='yyyy-MM-dd';
            /*时间关联组件名称*/
            var xCtc;
            /*用户配置：日期控件显示格式（Datetime Format） */
            var xCtf='yyyy\u5e74MM月dd日 HH:mm:ss wwww';

            /////////////////////////////////////////////////////////////////////////////
            // 运行时变量
            /////////////////////////////////////////////////////////////////////////////
            /*定时变量，用于DIV层的显示及隐藏*/
            var zFun=null;
            /*日历时间系统：年份*/
            var zDty;
            /*日历时间系统：月份*/
            var zDtm;
            /*日历时间系统：日期*/
            var zDtd;
            /*日历时间系统：今日*/
            var zCtd;

            /*内嵌窗口系统：鼠标移动事件*/
            var zMme;
            /*内嵌窗口系统：鼠标拖动事件*/
            var zMde;
            /*内嵌窗口系统：文本选择事件*/
            var zMse;
            /*内嵌窗口系统：文档选择事件*/
            var zDse;
            /*内嵌窗口系统：鼠标弹起事件*/
            var zMue;
            /*内嵌窗口系统：移动过程变更：窗口X方向偏移*/
            var zFox;
            /*内嵌窗口系统：移动过程变更：窗口Y方向偏移*/
            var zFoy;
            /*内嵌窗口系统：移动过程变更：窗口是否在拖动过程中*/
            var zFcm;
            /*内嵌窗口系统：系统内置窗口个数*/
            var zFds;

            /*划词搜索：默认搜索引擎*/
            var zPds;
            /*划词搜索：用户选择起始对象*/
            var zPso;
            /*划词搜索：用户选择结束对象*/
            var zPeo;
            /*划词搜索：用户双击鼠标事件*/
            var zPdc;
            /*划词搜索：鼠标进入交互组件*/
            var zPmo;
            
            /*模式对话框：窗口状态*/
            var mMod;
            /*模式对话框：上传页面参数*/
            var mPup;
            /*模式对话框：下传页面参数*/
            var mPdn;
            /*模式对话框：页面回调函数*/
            var mCbk;
            /*模式对话框：模式子窗口*/
            var mSub;

            ///////////////////////////////////////////////////////////////////////////////////////
            // 系统方法区域
            ///////////////////////////////////////////////////////////////////////////////////////
            /**
             * 此处为系统数据，默认数据存储格式如下（数组）：
             * 0:ID，网摘标记ID，同时也用作打开窗口的ID
             * 1:icon，链接图标索引
             * 2:text，链接显示文本
             * 3:tips，链接快捷提示
             * 4:encode，编码转换方式
             * 5:width，窗口宽度
             * 6:height，窗口调度
             */
            {$DATA$}
            
            ///////////////////////////////////////////////
            // 月份名称
            ///////////////////////////////////////////////
            // 月份简称
            var DMAN=['一','二','三','四','五','六','七','八','九','十','冬','腊'];
            // 月份全称
            var DMFN=['一月','二月','三月','四月','五月','六月','七月','八月','九月','十月','十一月','十二月'];
            ///////////////////////////////////////////////
            // 日期名称
            ///////////////////////////////////////////////
            // 日期简称
            var DDAN=new Array();
            // 日期全称
            var DDFN=new Array();
            ///////////////////////////////////////////////
            // 小时名称
            ///////////////////////////////////////////////
            // 小时简称
            var THAN=new Array();
            // 小时全称
            var THFN=new Array();

            ///////////////////////////////////////////////
            // 标记名称
            ///////////////////////////////////////////////
            // 早晚简称
            var MTAN=['上','下'];
            // 早晚全称
            var MTFN=['上午','下午'];
            // 星期简称
            var MWAN=['日','一','二','三','四','五','六'];
            // 星期全称
            var MWFN=['星期日','星期一','星期二','星期三','星期四','星期五','星期六'];
            // 时区简称
            var MZFN=new Array();
            // 时区全称
            var MZAN=new Array();

            ///////////////////////////////////////////////////////////////////
            // 接口区域
            ///////////////////////////////////////////////////////////////////
            /**
             * type: 要显示的网摘的类型
             *      menu 按钮
             *      link 文本
             *      list 列表
             *      date 日历
             *      time 时间
             * hide: 是否需要隐藏界面，此功能主要用于外部页面调用类的内部方法，其值为为'view'时都将会隐藏。
             */
            THIS.init=function()
            {
                // 参数为空判断
                if(arguments==null||arguments.length<2)
                {
                    return;
                }

                // 容器 DIV
                var sid=_M(arguments[0],_PRE+NAME+'_DIV');

                // 引入样式表
                THIS.styles(_PRE+NAME+'_CSS', PATH+'c/'+NAME+'.css');

                // 显示正确类别
                switch(arguments[1].toLowerCase())
                {
                    // 菜单综合显示
                    case 'help':
                    {
                        // 2：显示方式，可选值如下：
                        //    icon_text:图标及文本（默认）
                        //    icon: 仅图标
                        //    text: 仅文本
                        xViw=_M(arguments[2],'icon_text');
                        // 3：窗口标题，默认为用户浏览页面的标题
                        xTtl=_M(arguments[3],_DOC.title);
                        // 4：页面地址，默认为用户浏览页面的地址
                        xUrl=_M(arguments[4],_WIN.location.href);
                        // 5：概要介绍，默认为用户浏览页面时所选择的文本
                        xDsc=_M(arguments[5],'');

                        // 6：激发组件
                        var t;
                        if(_M(arguments[6],'')!='')
                        {
                            t=_X(arguments[6]);
                            if(t.tagName=='A'||t.tagName=='INPUT'||t.tagName=='IMG')
                            {
                                t.onmouseover=iNetHelper.showHelp(t);
                                t.onmouseout=iNetHelper.hideHelp(t);
                            }
                            else
                            {
                                t=null;
                            }
                        }
                        // 软件徽标
                        var txt=t?'':'<a href="#" onmouseover="iNetHelper.showHelp(this);" onmouseout="iNetHelper.hideHelp(this);" onclick="javascript:return false;" title="网页精灵"><img src="'+PATH+'_i/'+NAME+'.png" alt="网页精灵" style="border-width:0px;" /></a>';
                        // 弹出菜单
                        txt+=divHelp(rows,cols);
                        THIS.append(sid, txt);

                        // 显示默认DIV界面
                        tabc=_X(_PRE+NAME+'_TAB0');
                        tabv();
                        break;
                    }

                    // 列表链接
                    case 'link':
                    {
                        // 2：显示类别，显示的面板内容，可选值如下：
                        //    bms 书签（默认）
                        //    rss 阅读
                        //    wse 搜索
                        //    ssl 收录
                        //    wmi 关于
                        var kind=_M(arguments[2],'bms');
                        // 3：显示方式，可选值如下：
                        //    icon_text:图标及文本（默认）
                        //    icon: 仅图标
                        //    text: 仅文本
                        xViw=_M(arguments[3],'icon_text');
                        // 4：显示行数，默认为1行
                        var rows=_M(arguments[4],1);
                        // 5：显示列数，默认为8列
                        var cols=_M(arguments[5],8);
                        // 6：窗口标题，默认为用户浏览页面的标题
                        xTtl=_M(arguments[6],_DOC.title);
                        // 7：页面地址，默认为用户浏览页面的地址
                        xUrl=_M(arguments[7],_WIN.location.href);
                        // 8：概要介绍
                        xDsc=_M(arguments[8],'');

                        THIS.append(sid, divLink(rows,cols,kind.toLowerCase()));
                        break;
                    }

                    // 下拉列表
                    case 'list':
                    {
                        // 2：显示类别，显示的面板内容，可选值如下：
                        //    bms 书签（默认）
                        //    rss 阅读
                        //    wse 搜索
                        //    ssl 收录
                        //    wmi 关于
                        var kind=_M(arguments[2],'bms');
                        // 3：显示方式，可选值如下：
                        //    icon_text:图标及文本（默认）
                        //    icon: 仅图标
                        //    text: 仅文本
                        xViw=_M(arguments[3],'icon_text');
                        // 4：显示个数，默认为8个
                        var size=_M(arguments[4],8);
                        // 5：窗口标题，默认为用户浏览页面的标题
                        xTtl=_M(arguments[5],_DOC.title);
                        // 6：页面地址，默认为用户浏览页面的地址
                        xUrl=_M(arguments[6],_WIN.location.href);
                        // 7：概要介绍，默认为用户浏览页面时所选择的文本
                        xDsc=_M(arguments[7],'');

                        THIS.append(sid, divList(size,kind.toLowerCase()));
                        break;
                    }

                    // 搜索
                    case 'pbse':
                    {
                        // 搜索引擎个数
                        var size=xMod=_M(arguments[2],'8');

                        var dom=THIS.isIE()?_DOC:_WIN;
                        _A(dom,'mousedown',psso);
                        _A(dom,'dblclick',function(evt){zPdc=true;THIS.exitPbse();});
                        _A(dom,'mouseup',pseo);

                        THIS.append(sid, divPbse(size));
                        THIS.blur(_PRE+NAME+'_Menu_Pbse', true);
                        break;
                    }
                    
                    // 日历
                    case 'date':
                    {
                        // 2：显示方法，可选值如下：
                        //    menu：菜单
                        //    link：文本
                        //    tabs：预留（网摘）
                        xMod=_M(arguments[2],'link');
                        // 3：日期返回格式，默认为yyyy-MM-dd格式
                        xCdf=_M(arguments[3],'yyyy-MM-dd');
                        // 4：日历宽度，默认为160像素
                        // 5：日历高度，默认为120像素
                        THIS.append(sid, divDate(_M(arguments[4],160),_M(arguments[5],120)));
                        // 6：关联组件，日历控件与用户交互后所影响的组件对象
                        xCdc=_X(arguments[6]);
                        if(xMod=='menu')
                        {
                            // 7：激发组件，日历控件为弹出窗口时，激发日历弹出显示的用户交互组件
                            var t=_X(arguments[7]);
                            if (t)
                            {
                                _A(t,'click',function(evt)
                                {
                                    iNetHelper.showDate(_C(_E(evt)),false);
                                    return false;
                                });
                                THIS.blur(_PRE+NAME+'_40cal_DV',true);
                            }
                        }

                        // 显示当前月份日历视图
                        THIS.showDate(null,false);
                        break;
                    }
                    
                    // 时间
                    case 'time':
                    {
                        // 2：时间格式，默认为yyyy年MM月dd日 HH:mm:ss wwww
                        xCtf=_M(arguments[2],'yyyy年MM月dd日 HH:mm:ss wwww');
                        // 3：关联组件，时间显示的组件对象，默认系统会生成一个DIV并显示
                        xCtc=_X(arguments[3]);
                        if(!xCtc)
                        {
                            THIS.append(sid, divTime());
                        }

                        // 每间隔800毫秒自动调用时间显示一次
                        setInterval('iNetHelper.openTime()',100);
                        break;
                    }
                    
                    // 窗口
                    case 'form':
                    {
                        var s=_D();
                        var sdiv='<div';

                        // 2：窗口名称标记
                        var id=_M(arguments[2],'');
                        sdiv+=' id="'+_PRE+NAME+'_80wif_'+id+'_DV" style="position:absolute;';
                        // 3：窗口宽度，默认为120像素
                        var w=_M(arguments[3],120);
                        sdiv+='width:'+w+'px;';
                        // 4：窗口高度，默认为100像素
                        var h=_M(arguments[4],100);
                        sdiv+='height:'+h+'px;';
                        // 5：横向偏移，默认为0像素
                        var sw=_M(arguments[5],0);
                        // 6：竖向偏移，默认为0像素
                        var sh=_M(arguments[6],0);
                        // 7：水平位置，可选值有：
                        //    left：左对齐
                        //    center：居中对齐
                        //    right：右对齐（默认）
                        var rh=_M(arguments[7],'left').toLowerCase();
                        if(rh=='center')
                        {
                            rh='left';
                            sw=Math.round((s[0]-w)/2)+sw;
                        }
                        sdiv+=' '+rh+':'+sw+'px;';
                        // 8：垂直位置，可选值有：
                        //    top：项对齐
                        //    middle：居中对齐
                        //    bottom：底对齐（默认）
                        var rv=_M(arguments[8],'top').toLowerCase();
                        if(rv=='middle')
                        {
                            rv='top';
                            sh=Math.round((s[1]-h)/2)+sh;
                        }
                        sdiv+=' '+rv+':'+sh+'px;';
                        // 9：可最小化，默认true
                        var mi=_M(arguments[9],true);
                        // 10：可关闭，默认true
                        var mx=_M(arguments[10],true);

                        // 窗口Z轴坐标
                        if(zFds==null)
                        {
                            zFds=0;
                        }
                        zFds+=1;
                        sdiv+='z-index:'+zFds+';"';
                        sdiv+=' class="'+_PRE+NAME+'_80wif_Form">';

                        THIS.append(sid, sdiv+divForm(id,mx,mi)+'</div>');
                        _A(_WIN,'resize',_D);
                        break;
                    }
                    
                    // 模式对话框
                    case 'mdlg':
                    {
                        if(arguments.length<3)
                        {
                            alert('请输入模式对话框的参数！');
                            return;
                        }

                        // 2：窗口状态
                        mMod=_M(arguments[2],'');

                        // 来源窗口
                        if(mMod=='own')
                        {
                            THIS.append(sid, '<div id="'+_PRE+NAME+ '_MDLG" onmouseup="iNetHelper.mDlgBlur();return false;" style="position:absolute;z-index:10000;display:none;top:0;left:0;background-color:#666666;-moz-opacity:0.5;filter:alpha(opacity=50);opacity:0.5;"></div>');
                        }
                        
                        // 模式窗口
                        if(mMod=='sub')
                        {
                            _A(_WIN,'close', mDlgLoad);
                        }
                        break;
                    }
                    
                    // 右键菜单
                    case 'menu':
                    {
                        // 2:激发组件
                        var src=_M(arguments[2],'');
                        // 3:菜单ID
                        var mid=_M(arguments[3],'Menu');
                        // 4:菜单项数据
                        // 5:事件响应函数
                        THIS.append(sid, divMenu(mid,arguments[4],arguments[5]));
                        
                        // 右键事件处理
                        _DOC.oncontextmenu=function(evt)
                        {
                            evt=_E(evt);
                            // 判断事件源是否为目标对象
                            if(src?_C(evt).id==src:true)
                            {
                                THIS.showMenu(_P(evt));
                                return false;
                            }
                            return evt;
                        };
                        THIS.blur(_PRE+NAME+'_Menu_'+mid,true);
                        break;
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

            ///////////////////////////////////////////////////////////////////
            // 显示风格区域
            ///////////////////////////////////////////////////////////////////
            /**
             * 级联菜单风格
             * rows:显示行数
             * cols:显示列数
             */
            function divHelp(rows,cols)
            {
                var sdiv='<div id="'+_PRE+NAME+'_HELP" class="'+_PRE+NAME+'_Form" onmouseover="iNetHelper.showHelp(this);" onmouseout="iNetHelper.hideHelp(this);" style="position:absolute;width:200px;z-index:32767;display:none;">';
                sdiv+='<table id="'+_PRE+NAME+'_BODY" class="'+_PRE+NAME+'_BODY" width="100%" border="0" cellspacing="0" cellpadding="0">';

                // 标题
                sdiv+='<tr><th id="'+_PRE+NAME+'_HEAD" align="left" style="height:22px;padding-left:4px;"></th>';
                sdiv+='<th id="'+_PRE+NAME+'_USER" align="right" style="height:22px;padding-right:4px;"></th></tr>';

                // 标签
                sdiv+='<tr><td colspan="2">';
                sdiv+='<table width="100%" border="0" cellspacing="0" cellpadding="0">';
                sdiv+='<tr align="center">';
                sdiv+='<td id="'+_PRE+NAME+'_TAB0" align="center" valign="middle" class="'+_PRE+NAME+'_TABS" onMouseOver="iNetHelper.tabo(this,0)" onMouseOut="iNetHelper.tabx(this,0)" onMouseUp="iNetHelper.tabs(this,0)" style="width:40px;height:16px;"><a href="" onclick="javascript: return false">'+DVID[0][1]+'</a></td>';
                for(var k=1;k<DVID.length;k+=1)
                {
                    sdiv+='<td id="'+_PRE+NAME+'_TAB'+k+'" align="center" valign="middle" class="'+_PRE+NAME+'_TABD" onMouseOver="iNetHelper.tabo(this,'+k+')" onMouseOut="iNetHelper.tabx(this,'+k+')" onMouseUp="iNetHelper.tabs(this,'+k+')" style="width:40px;height:16px;"><a href="" onclick="javascript: return false">'+DVID[k][1]+'</a></td>';
                }
                sdiv+='<td class="'+_PRE+NAME+'_TABN" style="height:16px;">&nbsp;</td>';
                sdiv+='</tr>';
                sdiv+='</table>';
                sdiv+='</td></tr>';

                // 内容
                sdiv+='<tr><td colspan="2">';
                for(var k=0;k<DVID.length;k+=1)
                {
                    sdiv+='<div style="height:100px;'+(k!=0?'display:none;':'')+'" id="'+DVID[k][0]+'_DV" class="'+_PRE+NAME+'_Help">';
                    sdiv+=eval(DVID[k][0]+'_div')();
                    sdiv+='</div>';
                }
                sdiv+='</td></tr>';

                // 版权
                sdiv+='<tr><td align="left" height="18"></td><td align="right" height="18">';
                sdiv+='<a href="'+HOST+'" target="_blank" title="关于网页精灵">Amonsoft</a>&nbsp;';
                sdiv+='<a href="'+PATH+'inet0001.aspx" target="_blank" onclick="return iNetHelper.openMore();" title="显示更多网摘">更多…</a>&nbsp;';
                sdiv+='</td></tr>';

                sdiv+='</table>';
                sdiv+='</div>';

                return sdiv;
            }
            
            /**
             * 链接标签风格
             */
            function divLink(rows,cols,kind)
            {
                if(!cols||cols=='')
                {
                    cols=8;
                }
                if(!rows||rows=='')
                {
                    rows=1;
                }

                var idx=_I(kind);
                if(idx<0)
                {
                    return '网页精灵出现配置错误：请确认您的调用参数是否正确！';
                }
                var list=DVDT[DVID[idx][0]];
                var labl=DVID[idx][1];

                var sdiv='<table border="0" cellspacing="0" cellpadding="2">';

                var k=_S(list,cols,rows);
                var i=0;
                var j=0;
                sdiv+='<tr>';
                sdiv+='<td rowspan="'+rows+'"><a href="'+HOST+'" target="_blank" title="关于网页精灵">Amon</a>&nbsp;<a href="'+PATH+'inet0001.aspx" target="_blank" onclick="return iNetHelper.openMore();" title="显示更多网摘">'+labl+'</a>：</td>';
                while(j++ <cols)
                {
                    sdiv+='<td align="left" height="20">';
                    sdiv+=THIS.link(list[i++],xViw,kind);
                    sdiv+='</td>';
                }
                sdiv+='</tr>';
                    
                while (i<k)
                {
                    sdiv+='<tr>';
                    j=0;
                    while(j++ <cols)
                    {
                        sdiv+='<td align="left" height="20">';
                        sdiv+=THIS.link(list[i++],xViw,kind);
                        sdiv+='</td>';
                    }
                    sdiv+='</tr>';
                }

                sdiv+='</table>';
                
                return sdiv;
            }
            
            /**
             * 下拉列表风格
             */
            function divList(size,kind)
            {
                if(!size||size=='')
                {
                    size=8;
                }

                var idx=_I(kind);
                if(idx<0)
                {
                    return '网页精灵出现配置错误：请确认您的调用参数是否正确！';
                }
                var list=DVDT[DVID[idx][0]];
                var labl=DVID[idx][1];
                
                if (size>list.length)
                {
                    size=list.length;
                }

                var sdiv='<select name="select" onchange="iNetHelper.openHelp(document.getElementById(\''+_PRE+NAME+'_'+kind+'_OP\'+this.value));this.value=\'-1\';">';
                sdiv+='<option value="-1">Amon&nbsp;'+labl+'</option>';
                var o;
                for (var i=0;i<size;i+=1)
                {
                    o=list[i];
                    sdiv+='<option id="'+_PRE+NAME+'_'+kind+'_OP'+i+'" value="'+i+'" s="'+o[0]+'" w="'+o[5]+'" h="'+o[6]+'" k="'+kind+'" title="'+o[3]+'">'+o[2]+'</option>';
                }
                sdiv+='</select>';

                return sdiv;
            }
            
            /**
             * 划词搜索
             * size 默认显示搜索引擎个数
             */
            function divPbse(size)
            {
                // 用户默认使用搜索引擎
                var o=DVDT['iNetHelper_30wse'];
                if(!o||!o.length)
                {
                    return '';
                }

                if(size>o.length)
                {
                    size=o.length;
                }
                var t,i=0,j=0,d=cg(_PRE+NAME+'_32pbs');
                while(i<size)
                {
                    t=o[i];
                    if(t[0]==d)
                    {
                        j=i;
                        t[4]=true;
                        break;
                    }
                    i+=1;
                }
                var sdiv=THIS.menu('Pbse',o,'THIS.savePfav');

                sdiv+='<div id="'+_PRE+NAME+'_32pbs_DV" style="position: absolute;z-index: 32766px;width: 35px;height: 22px;display: none;">';

                sdiv+='<table border="0" cellpadding="0" cellspacing="0" width="35">';
                sdiv+='<tr><td id="'+_PRE+NAME+'_32pbs_TD" width="22" height="22" align="center" style="background-image: url(\''+PATH+'/_i/pbslD.png\');" onmouseover="iNetHelper.pbseOver(this,\'pbslE.png\');" onmouseout="iNetHelper.pbseExit(this,\'pbslD.png\');">';
                sdiv+=THIS.link(o[j],'icon','pbs',true);
                sdiv+='</td><td width="13">';
                sdiv+='<img id="'+_PRE+NAME+'_32pbs_PFAV" name="'+_PRE+NAME+'" src="'+PATH+'/_i/pbsrD.png" alt="\u25bc" title="切换搜索引擎" onmouseover="iNetHelper.pbsmOver(this,\'pbsrE.png\');" onmouseout="iNetHelper.pbsmExit(this,\'pbsrD.png\');" onclick="return iNetHelper.showPfav(this);" style="cursor: pointer;" />';
                sdiv+='</td></tr></table>';

                sdiv+='</div>';

                return sdiv;
            }
            
            /**
             * 日历组件
             */
            function divDate(w,h)
            {
                var sdiv='<div id="'+_PRE+NAME+'_40cal_DV" class="'+_PRE+NAME+'_Form" style="padding:1px;width:'+(w+6)+'px;';
                if(xMod=='menu')
                {
                    sdiv+=' position:absolute;z-index:32767;display:none;"';
                }
                sdiv+='">';
                sdiv+='<div class="'+_PRE+NAME+'_BODY" style="width:'+w+'px;height:'+h+'px;">';
                sdiv+=iNetHelper_40cal_div(h);
                sdiv+='</div>';
                sdiv+='</div>';

                return sdiv;
            }
            
            /**
             * 时间组件
             */
            function divTime()
            {
                var sdiv='<div id="'+_PRE+NAME+'_41dts_DV">';
                sdiv+=iNetHelper_41dts_div();
                sdiv+='</div>';
                
                return sdiv;
            }
            
            /**
             * 窗口组件
             * sid:窗口区分名称
             * mx:是否可关闭
             * ma:是否可最大化
             * mi:是否可最小化
             */
            function divForm(sid,mx,mi)
            {
                var sdiv='<table border="0" cellspacing="0" cellpadding="0" width="100%">';
                sdiv+='<tr id="'+_PRE+NAME+'_80wif_'+sid+'_HEAD_TR"><td><div id="'+_PRE+NAME+'_80wif_'+sid+'_HEAD" class="'+_PRE+NAME+'_80wif_Form_Head">';

                sdiv+='<table width="100%" border="0" cellspacing="0" cellpadding="0"><tr>';
                sdiv+='<td id="'+_PRE+NAME+'_80wif_'+sid+'_NAME" align="left" onMouseDown="iNetHelper.dragForm(event,\''+_PRE+NAME+'_80wif_'+sid+'_DV\');" onMouseUp="iNetHelper.dropForm(event,\''+_PRE+NAME+'_80wif_'+sid+'_DV\');"></td>';
                if(mi)
                {
                    sdiv+='<td id="'+_PRE+NAME+'_80wif_'+sid+'_HIDE" width="14" align="center"><a onmouseout="iNetHelper.swapImage(this,\''+PATH+'/_i/hideD.gif\')" onmouseover="iNetHelper.swapImage(this,\''+PATH+'/_i/hideE.gif\')" onmouseup="iNetHelper.hideForm(\''+_PRE+NAME+'_80wif_'+sid+'_BODY_TR\',\''+_PRE+NAME+'_80wif_'+sid+'\');"><img src="'+PATH+'/_i/hideD.gif" width="10" height="10" border="0"></a></td>';
                    sdiv+='<td id="'+_PRE+NAME+'_80wif_'+sid+'_SHOW" width="14" align="center" style="display: none;"><a onmouseout="iNetHelper.swapImage(this,\''+PATH+'/_i/viewD.gif\')" onmouseover="iNetHelper.swapImage(this,\''+PATH+'/_i/viewE.gif\')" onmouseup="iNetHelper.showForm(\''+_PRE+NAME+'_80wif_'+sid+'_BODY_TR\',\''+_PRE+NAME+'_80wif_'+sid+'\');"><img src="'+PATH+'/_i/viewD.gif" width="10" height="10" border="0"></a></td>';
                }
                if(mx)
                {
                    sdiv+='<td id="'+_PRE+NAME+'_80wif_'+sid+'_EXIT" width="14" align="center"><a onMouseOut="iNetHelper.swapImage(this,\''+PATH+'/_i/exitD.gif\')" onMouseOver="iNetHelper.swapImage(this,\''+PATH+'/_i/exitE.gif\')" onMouseUp="iNetHelper.exitForm(\''+_PRE+NAME+'_80wif_'+sid+'_DV\');"><img src="'+PATH+'/_i/exitD.gif" width="10" height="10" border="0"></a></td>';
                }
                sdiv+='</tr></table>';

                sdiv+='</div></td></tr>';

                sdiv+='<tr id="'+_PRE+NAME+'_80wif_'+sid+'_BODY_TR"><td><div id="'+_PRE+NAME+'_80wif_'+sid+'_BODY"></div></td></tr>';
                sdiv+='</table>';
                
                return sdiv;
            }
            
            ///////////////////////////////////////////////////////////////////
            // 助理模块
            ///////////////////////////////////////////////////////////////////            
            /**
             * 显示网页助理
             */
            THIS.showHelp=function(obj)
            {
                THIS.show(_L(obj),_O(obj),_PRE+NAME+'_HELP');
                return false;
            };

            /**
             * 窗口退出事件处理，此方法会等待0.5秒，以确定用户是在窗口之间切换动作（0.5秒之内），还是确定退出（0.5秒之外）。
             */
            THIS.hideHelp=function(obj)
            {
                THIS.hide(_PRE+NAME+'_HELP');
            };

            /**
             * 打开链接，方案：
             * 系统默认打开一个窗口，其地址指向http://amonsoft.net/inet/inet0002.aspx，然后以POST方式将页面信息传送到此页面，
             * inet0002.aspx页面在后台进行处理后，返回书签地址。
             * A标签中应存在以下几个处定义属性：
             * s:链接索引
             * w:窗口宽度
             * h:窗口高度
             * k:链接类别，如bms、rss等
             */
            THIS.openHelp=function(a)
            {
                var dsp=xDsc;
                if(!dsp||dsp=='')
                {
                    dsp=_T();
                }

                var sid=_N(a,'s','0');
                if(sid&&sid!='')
                {
                    var sts='width='+_N(a,'w','480')+',height='+_N(a,'h','560')+',menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=yes';
                    var win=_WIN.open("",sid,_N(a,'k','')=='bms'?sts:'');
                    win.document.write('<html><head><meta http-equiv="Content-Type" content="text/html;charset=utf-8" /><title>Amon网页精灵</title></head><body><form id="AmonForm" name="AmonForm" method="post" action="'+PATH+'inet0002.aspx" accept-charset="UTF-8">');
                    win.document.write('<input type="hidden" id="sid" name="sid" value="'+sid+'" /><input type="hidden" id="f" name="f" value="'+USER+'" /><input type="hidden" id="t"  name="t" value="'+xTtl+'" /><input type="hidden" id="u" name="u" value="'+xUrl+'" /><input type="hidden" id="d" name="d" value="'+dsp+'" />');
                    win.document.write('<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="center" style="height: 200px;font-family: simsun,Arial;font-size: 9pt;"><img src="'+HOST+'data/inet/Loading.gif" alt="页面载入中..." /><br /><br />页面载入中，请稍候...</td></tr></table></form></body></html>');
                    win.document.forms[0].submit();

                    // 隐藏主窗口
                    THIS.hideHelp();
                }
                return false;
            };
            
            /**
             * 显示更多
             */
            THIS.openMore=function()
            {
                var dsp=xDsc;
                if(!dsp||dsp=='')
                {
                    dsp=_T();
                }
                var win=_WIN.open("",NAME,'width=440,height=300,menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=no');
                win.document.write('<html><head><meta http-equiv="Content-Type" content="text/html;charset=utf-8" /><title>Amon网页精灵</title></head><body><form id="AmonForm" name="AmonForm" method="post" action="'+PATH+'inet0001.aspx" accept-charset="UTF-8">');
                win.document.write('<input type="hidden" id="sid" name="sid" value="'+USER+'" /><input type="hidden" id="t"  name="t" value="'+xTtl+'" /><input type="hidden" id="u" name="u" value="'+xUrl+'" /><input type="hidden" id="d" name="d" value="'+dsp+'" />');
                win.document.write('<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="center" style="height: 200px;font-family: simsun,Arial;font-size: 9pt;"><img src="'+HOST+'data/inet/Loading.gif" alt="页面载入中..." /><br /><br />页面载入中，请稍候...</td></tr></table></form></body></html>');
                win.document.forms[0].submit();
                return false;
            };

            /**
             * TAB鼠标进入事件
             */
            THIS.tabo=function(obj,idx)
            {
                if(tabi!=idx)
                {
                    obj.className=_PRE+NAME+'_TABO';
                }
            };
            
            /**
             * TAB鼠标退出事件
             */
            THIS.tabx=function(obj,idx)
            {
                if(tabi!=idx)
                {
                    obj.className=_PRE+NAME+'_TABD';
                }
            };
            
            /**
             * TAB鼠标选择事件
             */
            THIS.tabs=function(obj,idx)
            {
                if(tabi!=idx)
                {
                    if(tabc)
                    {
                        tabc.className=_PRE+NAME+'_TABD';
                    }
                    tabc=obj;
                    tabc.className=_PRE+NAME+'_TABS';
                    tabi=idx;
                    tabv();
                }
            };
            
            /**
             * 判断浏览器是否为Microsoft Internet Explorer浏览器
             */
            THIS.isIE=function()
            {
                return navigator.userAgent.indexOf('MSIE')>=0;
            };
            
            /**
             * 判断浏览器是否为Mozilla Firefox浏览器
             */
            THIS.isFF=function()
            {
                return navigator.userAgent.indexOf('Firefox')>=0;
            };
            
            /**
             * 判断浏览器是否为Apple Safari浏览器
             */
            THIS.isAS=function()
            {
                return navigator.userAgent.indexOf('Safari')>=0;
            };
            
            /**
             * 获取主机地址
             */
            THIS.host=function()
            {
                if(!xHst)
                {
                    var reg=/(^\w+:\/\/)((\w|\.)+)(:\d+)?\//;
                    var tmp=reg.exec(xUrl+'/');
                    xHst=tmp?tmp[2]:xUrl;
                }
                return xHst;
            //return 'amonsoft.net';
            };
            
            /**
             * 获取搜索引擎的详细访问地址。
             * se:搜索引擎标记索引
             * 返回结果：[site,link]
             */
            THIS.hostNav=function(se)
            {
                var obj;
                for(var i=0;i<DVDT[2].length;i+=1)
                {
                    obj=DVDT[2][i];
                    if(obj[0]==se)
                    {
                        return [obj[2]+obj[3].replace('{0}',THIS.host()),obj[2]+obj[6].replace('{0}',THIS.host())];
                    }
                }
                return '';
            };
            
            /**
             * 打开搜索引擎
             * se:搜索引擎名称
             * idx:搜索关键它索引：0表示site，1表示link
             * obj:调用此方法的链接对象，可以为空
             */
            THIS.openWnd=function(se,idx,obj)
            {
                if(obj)
                {
                    if(obj.href.indexOf('#')+1==obj.href.length)
                    {
                        return false;
                    }
                }

                _WIN.open(THIS.hostNav(se)[idx]);
                return false;
            };

            /**
             * 网站收录信息，显示或隐藏收录信息
             * obj:Input对象
             * sid:搜索引擎ID
             */
            THIS.siteView=function(obj,sid)
            {
                if(obj.value=='1')
                {
                    obj.src=PATH+'_i/cbox0d.gif';
                    _X(_PRE+NAME+'_31ssl_'+sid+'_Site').innerHTML='\u6536\u5f55：...';
                    _X(_PRE+NAME+'_31ssl_'+sid+'_Link').innerHTML='\u94fe\u5165：...';
                    obj.value='0';
                    return false;
                }

                obj.src=PATH+'_i/cbox1d.gif';
                var url='/inet/inet0031.ashx?sid='+sid+'&uri='+encodeURIComponent(THIS.host());
                THIS.ajax(url,THIS.siteResp,10000,THIS.siteTout);
                obj.value='1';
                return false;
            };

            /**
             * 网站收录信息AJAX回调方法
             */
            THIS.siteResp=function(data)
            {
                if(http.readyState==4)
                {
                    if(http.status==200)
                    {
                        var dat=http.responseText;
                        var i1=dat.indexOf(':');
                        var i2=dat.indexOf(';',i1);
                        var sid=dat.substring(0,i1);

                        _X(_PRE+NAME+'_31ssl_'+sid+'_Site').innerHTML='\u6536\u5f55：'+dat.substring(i1+1,i2);
                        _X(_PRE+NAME+'_31ssl_'+sid+'_Link').innerHTML='\u94fe\u5165：'+dat.substring(i2+1);

                        clearTimeout(zFun);
                    }
                }
            };
            
            /**
             * 超时处理
             */
            THIS.siteTout=function()
            {
                clearTimeout(zFun);

                _X(_PRE+NAME+'_31ssl_'+sid+'_Site').innerHTML='\u6536\u5f55：...';
                _X(_PRE+NAME+'_31ssl_'+sid+'_Site').innerHTML='\u94fe\u5165：...';
            };
            
            /**
             * 图像变更
             * obj:INPUT组件
             * def:是否显示为默认图像
             */
            THIS.siteSwap=function(obj,def)
            {
                obj.src=PATH+'_i/cbox'+obj.value+(def?'d':'e')+'.gif';
            };
            
            /**
             * AJAX事件调用公共方法
             * url:AJAX事件地址
             * res:AJAX回调事件方法
             * sec:超时设置，单位：毫秒
             * out:超时回调方法
             */
            THIS.ajax=function(url,res,sec,out)
            {
                if(!http)
                {
                    // 创建适合其他浏览器的XMLRequest
                    if (_WIN.XMLHttpRequest)
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
                                return false;
                            }
                        }
                    }
                }

                http.onreadystatechange=res;
                http.open('GET',url,true);
                http.send(null);
                if(sec&&sec>0&&out)
                {
                    zFun=setTimeout(out,sec);
                }
                return true;
            };
            
            /**
             * 设置指定组件的可视性
             */
            function tabv()
            {
                for(var i=0;i<DVID.length;i+=1)
                {
                    _X(DVID[i][0]+'_DV').style.display=(tabi==i?'':'none');
                }
                _X(_PRE+NAME+'_HEAD').innerHTML='Amon '+DVID[tabi][1];
            }
            
            ///////////////////////////////////////////////////////////////////
            // 划词搜索
            ///////////////////////////////////////////////////////////////////
            /**
             * 显示划词搜索面板
             */
            THIS.showPbse=function(evt)
            {
                if(!xDsc||xDsc.length<1||xDsc.indexOf('\n')>=0||xDsc.length>64)
                {
                    return false;
                }

                var xPos=-30;
                var yPos=5;
                if(THIS.isFF())
                {
                    xPos+=_DOC.body.scrollTop+evt.pageY;
                    yPos+=_DOC.body.scrollLeft+evt.pageX;
                }
                else if(THIS.isAS())
                {
                    xPos+=evt.pageY;
                    yPos+=evt.pageX;
                }
                else
                {
                    xPos+=_DOC.documentElement.scrollTop+evt.y;
                    yPos+=_DOC.documentElement.scrollLeft+evt.x;
                }
                
                // 显示窗口
                var d=_X(_PRE+NAME+'_32pbs_DV');
                if(d)
                {
                    d.style.top=xPos+'px';
                    d.style.left=yPos+'px';
                    d.style.display='';
                
                    // 隐藏菜单
                    _X(_PRE+NAME+'_Menu_Pbse').style.display='none';
                }
                return true;
            };
            
            /**
             * 隐藏划词搜索面板
             */
            THIS.hidePbse=function()
            {
                THIS.hide(_PRE+NAME+'_32pbs_DV');
            };
            
            /**
             * 直接退出搜索引擎菜单
             */
            THIS.exitPbse=function()
            {
                THIS.exit(_PRE+NAME+'_32pbs_DV');
            };

            /**
             * 隐藏偏好搜索引擎菜单
             */
            THIS.hidePfav=function()
            {
                THIS.hide(_PRE+NAME+'_Menu_Pbse');
            };
            
            /**
             * 显示偏好搜索引擎菜单
             */
            THIS.showPfav=function(obj)
            {
                if(!obj)
                {
                    obj=_X(_PRE+NAME+'_32pbs_PFAV');
                }

                // 获取当前搜索引擎单元行
                // var tmp=_X(_PRE+NAME+'_Menu_Pbse_IM_'+cg(_PRE+NAME+'_32pbs'));
                // 设置搜索引擎选中提示
                // if(tmp)tmp.src=PATH+'_i/menuS.gif';
                // 显示搜索引擎菜单
                THIS.show(_L(obj),_O(obj),_PRE+NAME+'_Menu_Pbse');
                return false;
            };
            
            /**
             * 保存用户偏好搜索引擎
             * sid:搜索引擎索引
             */
            THIS.savePfav=function(sid)
            {
                // 隐藏菜单
                THIS.exit(_PRE+NAME+'_Menu_Pbse');

                // 更换搜索引擎图标
                var o,t=DVDT['iNetHelper_30wse'];
                for(var i=0;i<t.length;i+=1)
                {
                    o=t[i];
                    if(o[0]==sid)
                    {
                        break;
                    }
                }
                _X(_PRE+NAME+'_32pbs_TD').innerHTML=THIS.link(o,'icon','pbs');

                // 设置Cookie值
                cs(_PRE+NAME+'_32pbs',sid,360);

                // 恢复默认图标
                // _X(_PRE+NAME+'_Menu_Pbse_IM_'+cg(_PRE+NAME+'_32pbs')).src=PATH+'_i/menuS.gif';

                return false;
            };
            
            /**
             * 鼠标进入划词搜索搜索引擎区域
             */
            THIS.pbseOver=function(obj,img)
            {
                obj.style.backgroundImage='url('+PATH+'/_i/'+img+')';
                zPmo=true;
                return false;
            };
            
            /**
             * 鼠标退出划词搜索搜索引擎区域
             */
            THIS.pbseExit=function(obj,img)
            {
                obj.style.backgroundImage='url('+PATH+'/_i/'+img+')';
                zPmo=false;
                return false;
            };
            
            /**
             * 鼠标进入划词搜索菜单选择区域
             */
            THIS.pbsmOver=function(obj,img)
            {
                obj.src=PATH+'/_i/'+img;
                zPmo=true;
                return false;
            };
            
            /**
             * 鼠标退出划词搜索菜单选择区域
             */
            THIS.pbsmExit=function(obj,img)
            {
                obj.src=PATH+'/_i/'+img;
                zPmo=false;
                return false;
            };

            /**
             * 记录用户选择起始对象
             */
            function psso(evt)
            {
                evt=_E(evt);
                if (evt)
                {
                    zPso=_C(evt);
                }
            }

            /**
             * 记录用户选择结束对象
             */
            function pseo(evt)
            {
                evt=_E(evt);
                if (!evt)
                {
                    return false;
                }
                
                // 自身事件源排除
                zPeo=_C(evt);
                var tmp=zPeo;
                while(tmp)
                {
                    if(_N(tmp,'name','')==_PRE+NAME)
                    {
                        return false;
                    }
                    tmp=tmp.offsetParent;
                }

                THIS.exitPbse();

                zPdc=false;
                if(!zPdc&&!zPmo)
                {
                    tmp=zPeo.tagName.toLowerCase();
                    if(zPeo==zPso&&tmp!='a'&&tmp!='input')
                    {
                        xDsc=_T();
                        if(xDsc!='')
                        {
                            THIS.showPbse(evt);
                        }
                    }
                }
                return false;
            }

            ///////////////////////////////////////////////////////////////////
            // 模式窗口
            ///////////////////////////////////////////////////////////////////
            /**
             * 打开模式窗口
             * u：要打开的页面地址
             * w：打开的页面宽度
             * h：打开的页面高度
             * f：页面回调函数
             * p：向打开页面传递的参数
             */
            THIS.mDlgOpen=function(u,w,h,f,p)
            {
                if(mMod!='own')
                {
                    return;
                }
                
                // 传入参数引用
                if(!w)
                {
                    w=400;
                }
                if(!h)
                {
                    h=300;
                }
                mCbk=f;
                mPup=p;

                // 关闭已打开窗口
                if(mSub!=null)
                {
                    mSub.close();
                }

                // 打开新窗口
                var size=_W();
                mSub=_X(_PRE+NAME+'_MDLG');
                mSub.style.width=size.ScrW+'px';
                mSub.style.height=size.ScrH+'px';
                mSub.style.display='';
                mSub=_WIN.open(u,_PRE+NAME+ '_MDLG', 'menubar=0,location=0,status=yes,dialog=yes,modal=yes,scrollbars=1,resizable=1,width='+w+',height='+h+',left='+((screen.availWidth-w)/2)+',top='+((screen.availHeight-h)/2));
                mSub.focus();
            };
            
            /**
             * 模式窗口推动焦点事件
             */
            THIS.mDlgBlur=function()
            {
                if(!mSub||mSub.closed)
                {
                    _X(_PRE+NAME+'_MDLG').style.display='none';
                    return;
                }
                //if (navigator.appName.indexOf('icrosoft')>0)
                //{
                //mSub.open().close();
                //}
                mSub.focus();
            };
            
            /**
             * 模式窗口关闭事件
             * b:是否需要执行回调函数
             * g:回调函数参数
             */
            THIS.mDlgExit=function(b,c)
            {
                _X(_PRE+NAME+'_MDLG').style.display='none';
                if(mSub!=null)
                {
                    mSub.close();
                    mSub=null;
                }
                if(b)
                {
                    mCbk(c);
                }
            };

            /**
             * 获取模式窗口上传参数
             */
            THIS.mDlgArgs=function()
            {
                return mPup;
            };
            
            /**
             * 模式窗口关闭善后处理
             */
            function mDlgLoad(evt)
            {
                evt=_E(evt);
                if(!evt.clientX||!evt.clientY||evt.clientX>_DOC.body.clientWidth&&evt.clientY<0||evt.altKey)
                {
                    _WIN.opener.iNetHelper.mDlgExit(false);
                    _WIN.opener.focus();
                }
            }

            ///////////////////////////////////////////////////////////////////
            // 日历模块
            ///////////////////////////////////////////////////////////////////
            /**
             * 获取当前日历信息
             */
            THIS.date=function()
            {
                return cdtf(xCdf,new Date(zDty,zDtm,zDtd));
            };

            /**
             * 显示日历弹出菜单
             * obj:日历显示位置参照对象
             * def:是否显示日期信息
             */
            THIS.showDate=function(obj,def)
            {
                // 是否需要显示弹出窗口
                if(obj)
                {
                    THIS.show(_L(obj),_O(obj),_PRE+NAME+'_40cal_DV');
                }

                var now=new Date();

                // 显示当前月份信息
                if(!zDty||zDty==0||zDty=='')
                {
                    zDty=now.getFullYear();
                    zDtm=now.getMonth()+1;
                    zDtd=now.getDate();
                }
                _X('iNetHelper_40cal_TB').style.backgroundImage='url('+PATH+'inet0003.ashx?t='+zDty+'/'+(zDtm<10?'0':'')+zDtm+')';

                var t;

                ///////////////////////////////////////////
                // 显示日历标题
                ///////////////////////////////////////////
                for(var i=0;i<7;i+=1)
                {
                    t=(i+xWfd)%7;
                    _X(_PRE+NAME+'_Date_TH'+(i)).innerHTML='<a title="'+MWFN[t]+'" onclick="return iNetHelper.changeW('+t+');" style="cursor:pointer;">'+MWAN[t]+'</a>';
                }
                
                ///////////////////////////////////////////
                // 显示日历内容
                ///////////////////////////////////////////
                // 计算每月1号为星期几，并根据用户偏好设置偏移量计算出第一天的显示位置
                t=dtwd(zDty,zDtm,1)-xWfd;
                if(t<0)
                {
                    t+=7;
                }

                var d=1;
                // 前置空白处理
                while(d<=t)
                {
                    _X(_PRE+NAME+'_Date_TD'+(d++)).innerHTML='\u3000';
                }
                // 月历视图显示
                for(var i=1,j=dtmd(zDty,zDtm)[zDtm];i<=j;i+=1)
                {
                    _X(_PRE+NAME+'_Date_TD'+(d++)).innerHTML='<a href="" title="'+zDty+'-'+(zDtm<10?'0':'')+zDtm+'-'+(i<10?'0':'')+i+'" onclick="return iNetHelper.openDate('+i+');">'+i+'</a>';
                }
                // 后置空白处理
                while(d<=37)
                {
                    _X(_PRE+NAME+'_Date_TD'+(d++)).innerHTML='\u3000';
                }
                
                ///////////////////////////////////////////
                // 显示今日
                ///////////////////////////////////////////
                // 恢复上一次选择组件为默认状态
                if(zCtd)
                {
                    if (zCtd.attributes['precss'])
                    {
                        zCtd.className=zCtd.attributes['precss'].nodeValue;
                    }
                }
                // 设置今日组件为醒目状态
                if((zDty==now.getFullYear())&&(zDtm==now.getMonth()+1))
                {
                    zCtd=_X(_PRE+NAME+'_Date_TD'+(t+zDtd));
                    if (zCtd.attributes['precss'])
                    {
                        zCtd.attributes['precss'].nodeValue=zCtd.className;
                    }
                    zCtd.className=_PRE+NAME+'_Date_R';
                }
                // 显示日期格式化信息
                if(!def)
                {
                    _X(_PRE+NAME+'_Date_TD0').innerHTML=cdtf(xCdf,new Date(zDty,zDtm-1,zDtd));
                }
                
                ///////////////////////////////////////////
                // 显示周次信息
                ///////////////////////////////////////////
                // 显示周次信息
                if(xMod!='tabs')
                {
                    t=dtyw(zDty,zDtm,1);
                    for(var i=1;i<6;i+=1)
                    {
                        _X(_PRE+NAME+'_Date_TW'+(i)).innerHTML='<a title="'+zDty+'年第 '+t+' 周">'+t+'</a>';
                        t+=1;
                    }
                    if(!def)
                    {
                        _X(_PRE+NAME+'_Date_TW6').innerHTML='<a title="显示交互组件" onclick="return iNetHelper.openDate(-1);" style="cursor:pointer;">\u25c4</a>';
                    }
                }
                // 显示关闭按钮
                if(xMod=='menu')
                {
                    _X(_PRE+NAME+'_Date_TW0').innerHTML='<a title="关闭日历菜单" onclick="return iNetHelper.hideDate(this);" style="cursor:pointer;">×</a>';
                }
                return false;
            };

            /**
             * 隐藏日历弹出菜单
             */
            THIS.hideDate=function(obj)
            {
                THIS.hide(_PRE+NAME+'_40cal_DV');
            };
            
            /**
             * 用户选择日期事件处理
             * d：为正整数时表示，用户选择的日期；
             * 为负整数时表示特殊意义的处理，目前支持功能如下：
             */
            THIS.openDate=function(d)
            {
                // 显示日历弹出菜单
                if(d==0)
                {
                    zDty=0;
                    THIS.showDate(xCdc,false);
                    return false;
                }
                // 用户选择日期事件处理，显示或返回指定格式的日期信息
                if (d>0)
                {
                    var s=cdtf(xCdf,new Date(zDty,zDtm-1,d));
                    _X(_PRE+NAME+'_Date_TD0').innerHTML=s;
                    if(xMod=='menu')
                    {
                        _X(_PRE+NAME+'_40cal_DV').style.display='none';
                    }

                    if(xCdc)
                    {
                        if(xCdc.tagName=='INPUT')
                        {
                            xCdc.value=s;
                        }
                        else if(xCdc.tagName=='SELECT')
                        {
                            var op=xCdc.options[0];
                            if(!op||op.value!=_PRE+NAME+'_40cal_OP')
                            {
                                op=new Option('',_PRE+NAME+'_40cal_OP');
                                xCdc.options.add(op,0);
                            }
                            op.text=s;
                            xCdc.value=_PRE+NAME+'_41dts_OP';
                        }
                        else
                        {
                            xCdc.innerHTML=s;
                        }
                    }
                    zDtd=d;
                    return false;
                }
                // 显示日历交互组件
                if(d==-1)
                {
                    _X(_PRE+NAME+'_Date_TW6').innerHTML='<a title="隐藏交互组件" onclick="return iNetHelper.openDate(-2);" style="cursor:pointer;">\u25ba</a>';
                    THIS.showComp(0);
                    
                    return false;
                }
                // 隐藏日历交互组件
                if(d==-2)
                {
                    _X(_PRE+NAME+'_Date_TW6').innerHTML='<a title="显示交互组件" onclick="return iNetHelper.openDate(-1);" style="cursor:pointer;">\u25c4</a>';
                    THIS.hideComp(0);
                    
                    return false;
                }

                return false;
            };
            
            /**
             * 动态显示日历交互组件
             */
            THIS.showComp=function(i)
            {
                switch(i)
                {
                    case 0:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML='';
                        setTimeout('iNetHelper.showComp(1);',150);
                        break;

                    case 1:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML+='<a title="上一年" onclick="return iNetHelper.changeY(-1);" style="cursor:pointer;">&lt;&lt;</a>&nbsp;';
                        setTimeout('iNetHelper.showComp(2);',150);
                        break;
                    
                    case 2:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML+='<a title="上一月" onclick="return iNetHelper.changeM(-1);" style="cursor:pointer;">&lt;</a>&nbsp;';
                        setTimeout('iNetHelper.showComp(3);',150);
                        break;

                    case 3:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML+='<a title="转到今日" onclick="return iNetHelper.openDate(0);" style="cursor:pointer;">※</a>&nbsp;';
                        setTimeout('iNetHelper.showComp(4);',150);
                        break;

                    case 4:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML+='<a title="下一月" onclick="return iNetHelper.changeM(1);" style="cursor:pointer;">&gt;</a>&nbsp;';
                        setTimeout('iNetHelper.showComp(5);',150);
                        break;

                    case 5:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML+='<a title="下一年" onclick="return iNetHelper.changeY(1);" style="cursor:pointer;">&gt;&gt;</a>';
                        setTimeout('iNetHelper.showComp(6);',150);
                        break;

                    default:
                        break;
                }
            };
            
            /**
             * 动态隐藏日历交互组件
             */
            THIS.hideComp=function(i)
            {
                var sdiv='';
                switch(i)
                {
                    case 0:
                        sdiv='<a title="下一年" onclick="return iNetHelper.changeY(1);" style="cursor:pointer;">&gt;&gt;</a>'+sdiv;

                    case 1:
                        sdiv='<a title="下一月" onclick="return iNetHelper.changeM(1);" style="cursor:pointer;">&gt;</a>&nbsp;'+sdiv;

                    case 2:
                        sdiv='<a title="转到今日" onclick="return iNetHelper.openDate(0);" style="cursor:pointer;">※</a>&nbsp;'+sdiv;

                    case 3:
                        sdiv='<a title="上一月" onclick="return iNetHelper.changeM(-1);" style="cursor:pointer;">&lt;</a>&nbsp;'+sdiv;

                    case 4:
                        sdiv='<a title="上一年" onclick="return iNetHelper.changeY(-1);" style="cursor:pointer;">&lt;&lt;</a>&nbsp;'+sdiv;
                        _X(_PRE+NAME+'_Date_TD0').innerHTML=sdiv;
                        setTimeout('iNetHelper.hideComp('+(i+1)+');',150);
                        break;

                    case 5:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML='';
                        setTimeout('iNetHelper.hideComp('+(i+1)+');',150);
                        break;

                    default:
                        _X(_PRE+NAME+'_Date_TD0').innerHTML=cdtf(xCdf,new Date(zDty,zDtm-1,zDtd));
                        break;
                }
            };

            /**
             * 年份信息调整
             * s：步增量
             */
            THIS.changeY=function(s)
            {
                zDty+=s;
                if(zDty==0)
                {
                    zDty=s>0?1 :-1;
                }
                THIS.showDate(null,true);
                return false;
            };
            
            /**
             * 月份信息调整
             * s：步增量
             */
            THIS.changeM=function(s)
            {
                zDtm+=s;
                if(zDtm<1)
                {
                    zDty-=zDtm%12;
                    zDtm=Math.round(zDtm/12)+12;
                }
                else if(zDtm>12)
                {
                    zDty+=zDtm%12;
                    zDtm=Math.round(zDtm/12);
                }
                THIS.showDate(null,true);
                return false;
            };
            
            /**
             * 一周第一天偏好设定
             * s：要显示的索引
             */
            THIS.changeW=function(s)
            {
                if(xWfd!=s)
                {
                    xWfd=s;
                    THIS.showDate(null,false);
                }
                return false;
            };
            
            /**
             * 计算指定日期为一年中的第几周(Year of Week)
             */
            function dtyw(y,m,d)
            {
                var days=dtmd(y,m);
                var c=0;
                for(var i=1;i<m;i+=1)
                {
                    c+=days[i];
                }
                c+=d;

                var w=dtwd(y,1,1)-xWfd;
                if(w<0)
                {
                    w+=7;
                }
                return Math.round(c/7)+(w<4?1:0);
            }

            /**
             * 获取指定年份中指定月份的总天数信息(Montth Days)
             * y：公历年份，如2000表示2000年
             * m：月份数值，1表示一月、2表示二月，依此递推
             */
            function dtmd(y,m)
            {
                var days=new Array(0,31,28,31,30,31,30,31,31,30,31,30,31);
                if (m==2)
                {
                    if((y%400==0)||(y%4==0)&&(y%100!=0))
                    {
                        days[2]+=1;
                    }
                }
                return days;
            }

            /**
             * 计算指定日期为星期几(Week Days)
             * y：公历年份，如2000表示2000年
             * m：月份数值，1表示一月、2表示二月，依此递推
             * d：日期数值，1表示1号、2表示2号，依此递推
             */
            function dtwd(y,m,d)
            {
                var arrY=new Array(0,1,2,3,5,6,0,1,3,4,5,6,1,2,3,4,6,0,1,2,4,5,6,0,2,3,4,5);
                var arrM=new Array(0,3,3,6,1,4,6,2,5,0,3,5);

                var tmpY=arrY[y%28-1];
                var tmpM=arrM[m-1];
                var tmpD=d-1;
                var leap=(y%400==0)||(y%4==0&&y%100!=0);
                if (leap&&m>2)
                {
                    tmpM+=1;
                }
                return (tmpY+tmpM+tmpD)%7;
            }

            ///////////////////////////////////////////////////////////////////
            // 时间模块
            ///////////////////////////////////////////////////////////////////
            /**
             * 获取当前时间信息
             */
            THIS.time=function()
            {
                return cdtf(xCtf,new Date());
            };
            
            THIS.showTime=function()
            {
            };
            
            THIS.hideTime=function()
            {
            };
            
            THIS.openTime=function()
            {
                var s=cdtf(xCtf,new Date());
                if(xCtc)
                {
                    if(xCtc.tagName=='INPUT')
                    {
                        xCtc.value=s;
                    }
                    else if(xCtc.tagName=='SELECT')
                    {
                        var op=xCtc.options[0];
                        if(!op||op.value!=_PRE+NAME+'_41dts_OP')
                        {
                            op=new Option('',_PRE+NAME+'_41dts_OP');
                            xCtc.options.add(op,0);
                        }
                        op.text=s;
                        xCtc.value=_PRE+NAME+'_41dts_OP';
                    }
                    else
                    {
                        xCtc.innerHTML=s;
                    }
                    return;
                }

                _X(_PRE+NAME+'_41dts_DV').innerHTML=s;
            };
            
            ///////////////////////////////////////////////////////////////////
            // 内嵌窗口模块
            ///////////////////////////////////////////////////////////////////
            THIS.initForm=function(sid,title,content)
            {
                if(title!=null)
                {
                    _X(_PRE+NAME+'_80wif_'+sid+'_NAME').innerHTML=title;
                }
                if(content!=null)
                {
                    _X(_PRE+NAME+'_80wif_'+sid+'_BODY').innerHTML=content;
                }
            };

            /**
             * 窗口拖动开始事件处理
             * evt:鼠标事件对象
             * sid:要操作的目标对象
             */
            THIS.dragForm=function(evt,sid)
            {
                evt=_E(evt);
                if(evt.button==0||evt.button==1)
                {
                    var win=_X(sid);
                    win.className=_PRE+NAME+'_80wif_Form_Drag';
                    zFds+=1;
                    win.style.zIndex=zFds;

                    // 记录偏移位置
                    zFox=(parseInt(win.style.left)||0)-evt.clientX;
                    zFoy=(parseInt(win.style.top)||0)-evt.clientY;

                    //改变风格;
                    _DOC.body.style.cursor="move";
                    zMme=_DOC.onmousemove;
                    zMde=_DOC.ondragstart;
                    zMse=_DOC.onselectstart;
                    zDse=_DOC.onselect;
                    zMue=_DOC.onmouseup;
                    _DOC.onmousemove=function(evt){
                        iNetHelper.moveForm(evt,sid);
                    };
                    _DOC.ondragstart=function(evt){
                        _E(evt).returnValue=false;
                    };
                    _DOC.onselectstart=function(evt){
                        _E(evt).returnValue=false;
                    };
                    _DOC.onselect=function(evt){
                        return false
                        };
                    _DOC.onmouseup=function(evt){
                        iNetHelper.dropForm(evt,sid);
                    };
                    zFcm=true;
                }
            };
            
            /**
             * 窗口移动过程事件处理
             * evt:鼠标事件对象
             * sid:要操作的目标对象
             */
            THIS.moveForm=function(evt,sid)
            {
                evt=_E(evt);
                if(zFcm)
                {
                    var win=_X(sid);
                    win.style.top=(evt.clientY+zFoy)+'px';
                    win.style.left=(evt.clientX+zFox)+'px';
                }
            };

            /**
             * 窗口拖动结束事件处理
             * evt:鼠标事件对象
             * sid:要操作的目标对象
             */
            THIS.dropForm=function(evt,sid)
            {
                evt=_E(evt);
                if(zFcm)
                {
                    var win=_X(sid);
                    win.style.left=(evt.clientX+zFox)+'px';
                    win.style.top=(evt.clientY+zFoy)+'px';
                    win.className=_PRE+NAME+'_80wif_Form';
                    _DOC.onmousemove=zMme;
                    _DOC.ondragstart=zMde;
                    _DOC.onselectstart=zMse;
                    _DOC.onselect=zDse;
                    _DOC.onmouseup=zMue;
                    _DOC.body.style.cursor='';
                    zFcm=false;
                }
            };
            
            /**
             * 窗口隐藏
             * 要隐藏的窗口ID
             */
            THIS.hideForm=function(sid,pre)
            {
                _X(sid).style.display='none';
                if(pre)
                {
                    var h=_X(pre+'_HIDE');
                    if(h)
                    {
                        h.style.display='none';
                    }
                    var v=_X(pre+'_SHOW');
                    if(v)
                    {
                        v.style.display='';
                    }
                }
            };
            
            /**
             * 显示窗口
             */
            THIS.showForm=function(sid,pre)
            {
                _X(sid).style.display='';
                if(pre)
                {
                    var h=_X(pre+'_HIDE');
                    if(h)
                    {
                        h.style.display='';
                    }
                    var v=_X(pre+'_SHOW');
                    if(v)
                    {
                        v.style.display='none';
                    }
                }
            };

            /**
             * 窗口关闭
             */
            THIS.exitForm=function(sid)
            {
                THIS.exit(sid);
            };
            
            /**
             *
             */
            THIS.swapImage=function(obj,img)
            {
                obj=_X(obj);
                while(obj.tagName!='IMG')
                {
                    obj=obj.getElementsByTagName('img');
                    if(!obj)
                    {
                        return;
                    }
                    if(obj.length)
                    {
                        obj=obj[0];
                    }
                }
                obj.src=img;
            };

            ///////////////////////////////////////////////////////////////////
            // 界面显示模块
            ///////////////////////////////////////////////////////////////////
            /**
             * 收藏DIV
             */
            function iNetHelper_10bms_div()
            {
                var sid='iNetHelper_10bms';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'bms');
                sdiv+='</table>';

                return sdiv;
            }
            
            /**
             * 阅读DIV
             */
            function iNetHelper_20rss_div()
            {
                var sid='iNetHelper_20rss';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'rss');
                sdiv+='</table>';
                
                return sdiv;
            }
            
            /**
             * 搜索DIV
             */
            function iNetHelper_30wse_div()
            {
                var sid='iNetHelper_30wse';

                var sdiv='<table width="100%" border="0" cellpadding="0" cellspacing="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'wse');
                sdiv+='</table>';
                sdiv+='</div>';
                
                return sdiv;
            }
            
            /**
             * 收录DIV
             */
            function iNetHelper_31ssl_div()
            {
                var sid='iNetHelper_31ssl';

                var sdiv='<table width="100%" border="0" cellpadding="0" cellspacing="0" id="'+sid+'_TB">';
                var size=DVDT[sid].length<5?DVDT[sid].length:5;
                var obj;
                for(var i=0;i<size;i+=1)
                {
                    obj=DVDT[sid][i];
                    sdiv+='<tr>';
                    sdiv+='<td align="left" height="20" title="'+obj[2]+'\u6536\u5f55查询"><input type="image" src="'+PATH+'_i/cbox0d.gif" value="0" width="15" height="15" onmouseover="iNetHelper.siteSwap(this,false);" onmouseout="iNetHelper.siteSwap(this,true);" onclick="return iNetHelper.siteView(this,\''+obj[0]+'\')"/></td>';
                    sdiv+='<td align="left" height="20" width="75" id="'+_PRE+NAME+'_31ssl_'+obj[0]+'_Site">\u6536\u5f55：...</td>';
                    sdiv+='<td align="left" height="20" width="75" id="'+_PRE+NAME+'_31ssl_'+obj[0]+'_Link">\u94fe\u5165：...</td>';
                    sdiv+='</tr>';
                }
                sdiv+='</table>';
                
                return sdiv;
            }
            
            /**
             * 地图
             */
            function iNetHelper_32map_div()
            {
                var sid='iNetHelper_32map';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'map');
                sdiv+='</table>';

                return sdiv;
            }

            /**
             * 划词搜索
             */
            function iNetHelper_33pbs_div()
            {
                var sid='iNetHelper_32pbs';

                return '';
            }
            
            /**
             * 网络求职
             */
            function iNetHelper_34job_div()
            {
                var sid='iNetHelper_34job';

                return '';
            }
            
            /**
             * 日历DIV
             */
            function iNetHelper_40cal_div()
            {
                var h=arguments[0]||100;
                var h1=Math.floor(h*0.14);
                var h2=h-h1*6;

                var sid='iNetHelper_40cal';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB" style="background-position:center; background-repeat:no-repeat;">';

                // 日期标题
                sdiv+='<tr>';
                sdiv+='<th id="'+_PRE+NAME+'_Date_TH0" height="'+h2+'" width="12%" align="center" class="'+_PRE+NAME+'_Date_B">&nbsp;</th>';
                for(var col=1;col<6;col+=1)
                {
                    sdiv+='<th id="'+_PRE+NAME+'_Date_TH'+col+'" height="'+h2+'" width="12%" align="center">&nbsp;</th>';
                }
                sdiv+='<th id="'+_PRE+NAME+'_Date_TH6" height="'+h2+'" width="12%" align="center" class="'+_PRE+NAME+'_Date_G">&nbsp;</th>';
                sdiv+='<th id="'+_PRE+NAME+'_Date_TW0" height="'+h2+'" width="16%">&nbsp;</th>';
                sdiv+='</tr>';

                // 日期内容
                var num=1;
                for(var row=0;row<5;row+=1)
                {
                    sdiv+='<tr>';
                    sdiv+='<td id="'+_PRE+NAME+'_Date_TD'+(num++)+'" height="'+h1+'" align="center" class="'+_PRE+NAME+'_Date_B" precss="">&nbsp;</td>';
                    for(var col=1;col<6;col+=1)
                    {
                        sdiv+='<td id="'+_PRE+NAME+'_Date_TD'+(num++)+'" height="'+h1+'" align="center" class="'+_PRE+NAME+'_Date_D" precss="">&nbsp;</td>';
                    }
                    sdiv+='<td id="'+_PRE+NAME+'_Date_TD'+(num++)+'" height="'+h1+'" align="center" class="'+_PRE+NAME+'_Date_G" precss="">&nbsp;</td>';
                    sdiv+='<td id="'+_PRE+NAME+'_Date_TW'+(row+1)+'" height="'+h1+'" align="center">&nbsp;</td>';
                    sdiv+='</tr>';
                }

                sdiv+='<tr>';
                sdiv+='<td id="'+_PRE+NAME+'_Date_TD'+(num++)+'" height="14" align="center" class="'+_PRE+NAME+'_Date_B">&nbsp;</td>';
                sdiv+='<td id="'+_PRE+NAME+'_Date_TD'+(num++)+'" height="14" align="center">&nbsp;</td>';
                sdiv+='<td id="'+_PRE+NAME+'_Date_TD0" height="14" align="right" colspan="5">&nbsp;</td>';
                sdiv+='<td id="'+_PRE+NAME+'_Date_TW6" height="14" align="center">&nbsp;</td>';
                sdiv+='<tr>';

                sdiv+='</table>';

                return sdiv;
            }
            
            /**
             * 时间DIV
             */
            function iNetHelper_41dts_div()
            {
                var sid='iNetHelper_41dts';

                return '';
            }
            
            /**
             * 翻译DIV
             */
            function iNetHelper_50wlt_div()
            {
                var sid='iNetHelper_50wlt';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'wlt');
                sdiv+='</table>';

                return sdiv;
            }
            
            /**
             * 邮件DIV
             */
            function iNetHelper_60wmc_div()
            {
                var sid='iNetHelper_60wmc';

                var sdiv='<table width="100%" border="0" cellspacing="0" cellpadding="0" id="'+sid+'_TB">';
                sdiv+=cdiv(DVDT[sid],2,5,'wmc');
                sdiv+='</table>';

                return sdiv;
            }
            
            /**
             * 窗口DIV
             */
            function iNetHelper_80wif_div()
            {
                var sid='iNetHelper_80wif';

                return '';
            }
            
            /**
             * 信息DIV
             */
            function iNetHelper_90wmi_div()
            {
                var sid='iNetHelper_90wmi';

                var obj;
                var idx=0;
                var size=_S(DVDT[sid],2,5);

                var sdiv='<table width="100%" border="0" cellpadding="0" cellspacing="0" id="'+sid+'_TB">';
                while(idx<size)
                {
                    sdiv+='<tr>';
                    sdiv+='<td align="left" height="20" width="50%">'+THIS.link(DVDT[sid][idx++],xViw,'wmi')+'</td>';
                    sdiv+='<td align="left" height="20" width="50%">'+THIS.link(DVDT[sid][idx++],xViw,'wmi')+'</td>';
                    sdiv+='</tr>';
                }
                sdiv+='</table>';

                return sdiv;
            }
            
            ///////////////////////////////////////////////////////////////////
            // 模块共用方法
            ///////////////////////////////////////////////////////////////////
            /**
             * DIV层关闭处理：如果用户在指定时间内鼠标在<a>标签和<div>标签之间移动，则不进行DIV层的关闭操作。
             * loc:菜单显示定位
             * off:菜单显示偏移
             * cmp:菜单名称，用于控制指定菜单的显示
             * hov:是在水平方向进行偏移还是在竖直方向进行偏移
             */
            THIS.show=function(loc,off,cmp,hov)
            {
                // 若窗口处于隐藏过渡期，则取消窗口隐藏
                if(zFun!=null)
                {
                    clearTimeout(zFun);
                    zFun=null;
                    return false;
                }

                var ofx=loc[0]+offL+(hov?off[0]:0);
                var ofy=loc[1]+offT+(hov?0:off[1]);
                var d=_D();
                var r=_R();

                cmp=_X(cmp);
                cmp.style.display='';
                if(ofx-r[0]+cmp.clientWidth+20>d[0])
                {
                    //ofx=loc[0]-offL-cmp.clientWidth;
                    ofx=loc[0]-offL-off[0];
                }
                if(ofy-r[1]+cmp.clientHeight+off[1]+20>d[1])
                {
                    ofy=loc[1]-offT-cmp.clientHeight;
                }
                cmp.style.left=ofx+'px';
                cmp.style.top=ofy+'px';

                return false;
            };

            /**
             * div层隐藏事件处理，此方法主要用于在窗口过渡期调用。
             */
            THIS.hide=function(obj)
            {
                zFun=setTimeout(function(){iNetHelper.exit(obj);},500);
            };
            
            /**
             * DIV层隐藏事件处理，此方法将会不等待面直接隐藏窗口。
             */
            THIS.exit=function(obj)
            {
                var o=_X(obj);
                if(o)
                {
                    o.style.display='none';
                    zFun=null;
                }
                return false;
            };

            /**
             * 鼠标点击时隐藏指定名称的对象。
             * sid:DIV名称
             * clk:true鼠标点击对象不为指定对象或其子对象时退出；
             *     false鼠标退出对象或其子对象时退出。
             */
            THIS.blur=function(sid,clk)
            {
                _A(clk?_DOC:_X(sid),clk?'mouseup':'mouseout',function(evt)
                {
                    evt=_E(evt);
                    // 点击事件：判断是否为鼠标左键
                    if(clk&&!_B(evt).left)
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
                    if(out)THIS.exit(sid);
                });
            };

            /**
             * 生成弹出菜单
             * sid:菜单ID
             * dat:菜单项数据，格式：[[id,图像,文本,提示,'',宽度,高度],[id,图像,文本,提示,'',宽度,高度],...]
             * fun:响应事件的方法
             * zpi:zIndex数值，默认127
             */
            THIS.menu=function(sid,dat,fun,zpi)
            {
                if(!sid||!dat||!dat.length)
                {
                    return '';
                }
                var div='<div id="'+_PRE+NAME+'_Menu_'+sid+'" name="'+_PRE+NAME+'" class="'+_PRE+NAME+'_Menu" style="position:absolute;z-index:'+(zpi||127)+';overflow:hidden;border:1px solid #A0A0A0;width:180px;display:none;">';
                div+='<table width="180" border="0" cellspacing="0" cellpadding="1">';
                div+='<tr><td width="18" valign="bottom" class="'+_PRE+NAME+'_Menu_SL"><img src="'+PATH+'_i/rpopL.gif" width="18" height="160" /></td>';
                div+='<td class="'+_PRE+NAME+'_Menu_SR">';
                div+='<table width="100%" border="0" cellspacing="0" cellpadding="0">';
                var tmp;
                for(var i=0;i<dat.length;i+=1)
                {
                    tmp=dat[i];
                    if(tmp)
                    {
                        div+='<tr menu="'+fun+'(\''+tmp[0]+'\')" title="'+tmp[3]+'" onmouseover="iNetHelper.menuOver(this);" onmouseout="iNetHelper.menuExit(this);" onclick="iNetHelper.menuOpen(this);">';
                        div+='<td width="18" align="center"><img id="'+_PRE+NAME+'_Menu_'+sid+'_IM_'+tmp[0]+'" src="'+HOST+(tmp[1]?'data/inet/'+tmp[1]:'inet/_i/menuD')+'.gif" alt="" style="border:0px;width:16px;height:16px;"></td>';
                        div+='<td height="20" align="left"'+(tmp[7]?' class="'+_PRE+NAME+'_Menu_RA"':'')+'>'+(tmp[2]||'&nbsp;')+'</td>';
                        div+='</tr>';
                    }
                    else
                    {
                        div+='<tr name="'+_PRE+NAME+'">';
                        div+='<td height="20" align="center" colspan="2"><hr width="98%" class="'+_PRE+NAME+'_Menu_HR" /></td>';
                        div+='</tr>';
                    }
                }
                div+='</table>';
                div+='</td></tr></table></div>';
                return div;
            };

            /**
             * 共用DIV
             */
            function cdiv(list,cols,rows,kind)
            {
                if(!cols||cols<0)
                {
                    cols=2;
                }
                if(!list)
                {
                    list=new Array();
                }
                var k=_S(list,cols,rows);

                var sdiv='';
                var i=0;
                var j=0;
                while (i<k)
                {
                    sdiv+='<tr>';
                    j=0;
                    while(j++ <cols)
                    {
                        sdiv+='<td align="left" height="20">';
                        sdiv+=THIS.link(list[i++],xViw,kind);
                        sdiv+='</td>';
                    }
                    sdiv+='</tr>';
                }

                return sdiv;
            }

            /**
             * 生成链接字符串
             * o:模型数组
             * v:链接显示方式，其值为：icon_text、icon、text
             * k:链接类型，其值为:bms、rss等。
             * n:是否添加name属性，以控制组件不隐藏
             */
            THIS.link=function(o,v,k,n)
            {
                var name=n?'name="'+_PRE+NAME+'"':'';
                //链接显示文本
                var text=o[2];
                if(v!='text')
                {
                    text='<img src="'+HOST+'data/inet/'+o[1]+'.gif" alt="'+o[2]+'" style="border:0px;width:16px;height:16px;" '+name+'>';
                    if(v!='icon')
                    {
                        text+=o[2];
                    }
                }
                
                return '<a href="'+PATH+'inet0002.aspx?sid='+o[0]+'" s="'+o[0]+'" w="'+o[5]+'" h="'+o[6]+'" k="'+k+'" title="'+o[3]+'" onclick="return iNetHelper.openHelp(this);" '+name+'>'+text+'</a>';
            };

            /**
             * 格式化日期/时间字符串并返回
             * txt：日期格式字符串
             * now：日期对象引用
             */
            function cdtf(txt,now)
            {
                //数值型临时变量
                var ti;
                //字符型临时变量
                var ts;

                // ----------------------------------------
                // 年份显示
                // 定义：返回一个表示年份的 4 位数字。
                // 语法：dateObject.getFullYear()
                // 返回：当 dateObject 用本地时间表示时返回的年份。返回值是一个四位数，表示包括世纪值在内的完整年份，而不是两位数的缩写形式。
                // ----------------------------------------
                ti=now.getFullYear();
                ts=ti.toString();
                //数值年份（4位）
                if(ts.length>4)ts=ts.substring(ts.length-4);
                txt=txt.replace('yyyy',ts);
                //数值年份（3位）
                txt=txt.replace('yyy',ti-1900);
                //数值年份（2位）
                if(ts.length>2)ts=ts.substring(ts.length-2);
                txt=txt.replace('yy',ts);
                //数值年份（1位）
                if(ts.length>1)ts=ts.substring(ts.length-1);
                txt=txt.replace('y',ts);

                // ----------------------------------------
                // 年份显示
                // 定义：返回表示月份的数字(0 ~ 11)。
                // 语法：dateObject.getMonth()
                // 返回值：dateObject 的月份字段，使用本地时间。返回值是 0（一月） 到 11（十二月） 之间的一个整数。
                // ----------------------------------------
                ti=now.getMonth();
                ts=(ti+1).toString();
                //月分全称
                txt=txt.replace('MMMM',DMFN[ti]);
                //月份简称
                txt=txt.replace('MMM',DMAN[ti]);
                //数值月份（定长2位）
                txt=txt.replace('MM',ts.lPad(2,'0'));
                //数值月份（可变）
                txt=txt.replace('M',ts);

                // ----------------------------------------
                // 定义：返回月份的某一天(1 ~ 31)。
                // 语法：dateObject.getDate()
                // 返回值：dateObject 所指的月份中的某一天，使用本地时间。返回值是 1 ~ 31 之间的一个整数。
                // ----------------------------------------
                ti=now.getDate()-1;
                ts=(ti+1).toString();
                //日期全称
                txt=txt.replace('dddd',DDFN[ti]);
                //日期简称
                txt=txt.replace('ddd',DDAN[ti]);
                //定长数值日期
                txt=txt.replace('dd',ts.lPad(2,'0'));
                //变长数值日期
                txt=txt.replace('d',ts);
                
                // ----------------------------------------
                // 定义：返回时间的小时字段(0 ~ 23)。
                // 语法：dateObject.getHours()
                // 返回值：dateObject 的小时字段，以本地时间显示。返回值是 0 （午夜） 到 23 （晚上 11 点）之间的一个整数。
                // ----------------------------------------
                ti=now.getHours();
                ts=ti.toString();
                //24时制时全称
                txt=txt.replace('HHHH',THFN[ti]);
                //24时制时简称
                txt=txt.replace('HHH',THAN[ti]);
                //定长24时制
                txt=txt.replace('HH',ts.lPad(2,'0'));
                //变长24时制
                txt=txt.replace('H',ts);

                var t=0;
                if(ti>11)
                {
                    ti-=12;
                    ts=ti.toString();
                    t=1;
                }
                //上下午全称
                txt=txt.replace('zzzz',MTFN[t]);
                //上下午简称
                txt=txt.replace('zzz',MTAN[t]);
                //上下午全称
                txt=txt.replace('zz',t==0?'AM':'PM');
                //上下午简称
                txt=txt.replace('z',t==0?'A':'P');
    
                //12时制时全称
                txt=txt.replace('hhhh',THFN[ti]);
                //12时制时简称
                txt=txt.replace('hhh',THAN[ti]);
                txt=txt.replace('hh',ts.lPad(2,'0'));
                txt=txt.replace('h',ts);

                // ----------------------------------------
                // 定义：返回时间的分钟字段(0 ~ 59)。
                // 语法：dateObject.getMinutes()
                // 返回值：dateObject 的分钟字段，以本地时间显示。返回值是 0 ~ 59 之间的一个整数。
                // ----------------------------------------
                ti=now.getMinutes();
                ts=ti.toString();
                txt=txt.replace('mm',ts.lPad(2,'0'));
                txt=txt.replace('m',ts);

                // ----------------------------------------
                // 定义：返回时间的秒(0 ~ 59)。
                // 语法：dateObject.getSeconds()
                // 返回值：dateObject 的分钟字段，以本地时间显示。返回值是 0 ~ 59 之间的一个整数。
                // ----------------------------------------
                ti=now.getSeconds();
                ts=ti.toString();
                txt=txt.replace('ss',ts.lPad(2,'0'));
                txt=txt.replace('s',ts);

                // ----------------------------------------
                // 定义：返回表示星期的某一天的数字(0 ~ 6)。
                // 语法：dateObject.getDay()
                // 返回值：dateObject 所指的星期中的某一天，使用本地时间。返回值是 0（周日） 到 6（周日） 之间的一个整数。
                // ----------------------------------------
                ti=now.getDay();
                ts=(ti!=0?ti.toString():'7');
                //星期全称
                txt=txt.replace('wwww',MWFN[ti]);
                //星期简称
                txt=txt.replace('www',MWAN[ti]);
                //2位数值星期
                txt=txt.replace('ww',ts.lPad(2,'0'));
                //1位数值星期
                txt=txt.replace('w',ts);

                // ----------------------------------------
                // ----------------------------------------
                ti=Math.round(now.getTimezoneOffset()/-60);
                ts=Math.abs(ti).toString();
                t='';
                if(ti>0)
                {
                    t='+';
                }
                else if (ti<0)
                {
                    t='-';
                }
                ti+=12;
                txt=txt.replace('ZZZZ',MZFN[ti]);
                txt=txt.replace('ZZZ',MZAN[ti]);
                txt=txt.replace('ZZ',t+ts.lPad(2,'0'));
                txt=txt.replace('Z',t+ts);
    
                return txt;
            }
            
            ///////////////////////////////////////////////
            // 右键菜单
            ///////////////////////////////////////////////
            /**
             * 初始化右键菜单
             * sid:菜单ID
             * obj格式：{'text':'','tips':'','icon':'subs':'','checked':'','events':{'onclick':''}}
             * fun:事件响应函数
             */
            function divMenu(sid,obj,fun)
            {
                return THIS.menu(sid||'Menu',obj||[['last','','后退','后退','',0,0],
                    ['next','','前进','前进','',0,0],
                    ['load','','重新载入','重新载入','',0,0],
                    null,
                    ['home','','网站首页','网站首页','',0,0],
                    ['chat','','与作者对话','与作者对话','',0,0],
                    ['mail','','给作者发邮件','给作者发邮件','',0,0],
                    null,
                    ['prin','','打印','打印','',0,0],
                    ['text','','查看页面源代码','查看页面源代码','',0,0],
                    ['exit','','关闭','关闭','',0,0]
                    ],fun||'iNetHelper.menuEvnt');
            }

            /**
             * 单元行鼠标点击事件
             */
            THIS.menuOpen=function(obj)
            {
                _X(_PRE+NAME+'_Menu_Menu').style.display='none';
                if(!obj)
                {
                    return false;
                }
                var tmp=obj.attributes['menu'];
                if(!tmp)
                {
                    return false;
                }
                tmp=tmp.nodeValue;
                if(!tmp||tmp=='')
                {
                    return false;
                }
                return eval(tmp);
            };
            /**
             * 单元行鼠标进入事件
             */
            THIS.menuOver=function(obj)
            {
                obj.className=_PRE+NAME+'_Menu_OV';
                var tmp=obj.attributes['subs'];
                if(!tmp)
                {
                    return;
                }
                tmp=tmp.nodeValue;
                if(tmp=='')
                {
                    return;
                }
                tmp=_X(tmp);
                var loc=_L(obj);
                tmp.style.top=loc[1]+'px';
                tmp.style.left=loc[0]+_O(obj)[0]+'px';
                tmp.style.zIndex=obj.style.zIndex+1;
                tmp.style.display='';
            };
            /**
             * 单元行鼠标退出事件
             */
            THIS.menuExit=function(obj)
            {
                var tmp=obj.attributes['exit'];
                if(!tmp||tmp.nodeValue=='')
                {
                    obj.className='';
                }
            };
            /**
             * 显示右键菜单
             */
            THIS.showMenu=function(loc)
            {
                THIS.show(loc,[0,0],_PRE+NAME+'_Menu_Menu');
                return false;
            };
            /**
             * 隐藏右键菜单
             */
            THIS.hideMenu=function()
            {
                THIS.exit(_PRE+NAME+'_Menu_Menu');
                return false;
            };
            /**
             * 菜单项事件
             * sid:响应菜单项事件ID
             */
            THIS.menuEvnt=function(sid)
            {
                switch(sid)
                {
                    case 'last':
                        _WIN.history.back();
                        break;
                    case 'next':
                        _WIN.history.forward();
                        break;
                    case 'load':
                        _WIN.location.reload();
                        break;
                    case 'text':
                        _WIN.open('http://amonsoft.net/edit/edit0001.aspx?uri='+encodeURIComponent(_WIN.location.href));
                        break;
                    case 'prin':
                        _WIN.print();
                        break;
                    case 'exit':
                        _WIN.close();
                        break;
                    case 'mail':
                        _WIN.location.href='mailto:amonsoft@163.com?subject=Hello Amon!&body=Hi Amon:';
                        break;
                    case 'home':
                        _WIN.open(HOST);
                        break;
                    case 'chat':
                        _WIN.open(HOST+'info/info0001.html','info','width=200,height=300');
                        break;
                }
            };
            
            ///////////////////////////////////////////////
            // Cookie信息
            ///////////////////////////////////////////////
            /**
             * 设置读取Cookie
             * n-name Cookie存取名称
             */
            function cg(n)
            {
                var d='sctvzeyegqzrcbzz';
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
             * 删除Cookie
             * n-name Cookie存取名称
             * p-path
             * d-domain
             */
            function cd(n,p,d)
            {
                if(cg(n))
                {
                    _DOC.cookie=n+'='+((p)?';path='+p:'')+((d)?';domain='+d:'')+';expires=Thu,01-Jan-1970 00:00:01 GMT';
                }
            }
            /**
             * 为对象添加事件
             * o:DOM对象
             * e:事件
             * f:方法
             */
            function _A(o,e,f)
            {
                if(o&&e)
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
             * 获取窗口可视区域大小
             */
            function _D()
            {
                if(typeof (_WIN.innerWidth)=='number')
                {
                    return [_WIN.innerWidth,_WIN.innerHeight];
                }
            
                var o=_DOC.documentElement;
                if(o&&(o.clientWidth||o.clientHeight))
                {
                    return [o.clientWidth,o.clientHeight];
                }
            
                o=_DOC.body;
                if(o&&(o.clientWidth||o.clientHeight))
                {
                    return [o.clientWidth,o.clientHeight];
                }
            
                return [0,0];
            }

            /**
             * 获取窗口滚动区域大小
             * 返回值格式：
             * ScrW：可滚动宽度
             * ScrH：可滚动高度
             * WinW：窗口宽度
             * WinH：窗口高度
             */
            function _W()
            {
                var scrW,scrH;
                if(_WIN.innerHeight&&_WIN.scrollMaxY)
                {
                    // Mozilla
                    scrW=_WIN.innerWidth+_WIN.scrollMaxX;
                    scrH=_WIN.innerHeight+_WIN.scrollMaxY;
                }
                else if(_DOC.body.scrollHeight>_DOC.body.offsetHeight)
                {
                    // all but IE Mac
                    scrW=_DOC.body.scrollWidth;
                    scrH=_DOC.body.scrollHeight;
                }
                else if(_DOC.body)
                {
                    // IE Mac
                    scrW=_DOC.body.offsetWidth;
                    scrH=_DOC.body.offsetHeight;
                }

                var winW,winH;
                if(_WIN.innerHeight)
                {
                    // all except IE
                    winW=_WIN.innerWidth;
                    winH=_WIN.innerHeight;
                }
                else if(_DOC.documentElement&&_DOC.documentElement.clientHeight)
                {
                    // IE 6 Strict Mode
                    winW=_DOC.documentElement.clientWidth;
                    winH=_DOC.documentElement.clientHeight;
                }
                else if(_DOC.body)
                {
                    // other
                    winW=_DOC.body.clientWidth;
                    winH=_DOC.body.clientHeight;
                }

                // for small pages with total size less then the viewport
                if(scrW<winW)scrW=winW;
                if(scrH<winH)scrH=winH;

                return {
                    ScrW:scrW,
                    ScrH:scrH,
                    WinW:winW,
                    WinH:winH
                };
            }
            
            /**
             * 获取鼠标事件对象
             */
            function _E(evt)
            {
                return evt?evt:_WIN.event;
            }
            
            /**
             * 获取事件源
             */
            function _C(evt)
            {
                return evt.target||evt.srcElement;
            }
            
            /**
             * 获取用户输入类别实际对应的类别ID数组中的索引
             * sid:类别键值，如bms、rss、ses等。
             */
            function _I(sid)
            {
                for(var i=0;i<DVID.length;i+=1)
                {
                    if(DVID[i][0].indexOf(sid)>0)
                    {
                        return i;
                    }
                }
                return -1;
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
                if(str==null||str=='')
                {
                    return def;
                }
                return str;
            }

            /**
             * 取得页面对象的自定义属性
             * obj:页面HTML元素对象
             * sid:要取得的自定义属性名称
             * def:自定义元素属性默认值
             */
            function _N(obj,sid,def)
            {
                return obj?(obj.getAttribute(sid)||def):def;
            }
            
            /**
             * 校正事件源偏移量
             * obj 事件激发源
             */
            function _O(obj)
            {
                // 获取链接内的图片对象<a><img></a>
                var ofh=16;
                var ofw=12;
                if (obj.tagName=='A')
                {
                    ofw=12*obj.innerHTML.length;
                    var img=obj.getElementsByTagName('img');
                    if(img&&img[0])
                    {
                        obj=img[0];
                        ofh=parseInt(obj.height)||16;
                        ofw=parseInt(obj.width)||12;
                    }
                }
                else if (obj.tagName=='INPUT')
                {
                    ofh=parseInt(obj.style.height)||18;
                    ofw=parseInt(obj.style.width)||18;
                }
                else if (obj.tagName=='IMG')
                {
                    ofh=parseInt(obj.height)||16;
                    ofw=parseInt(obj.width)||16;
                }

                return [ofw,ofh];
            }
            
            /**
             * 获取鼠标位置
             */
            function _P(evt)
            {
                if(evt.pageX||evt.pageY)
                {
                    return [evt.pageX,evt.pageY];
                }
                return [evt.clientX+_DOC.body.scrollLeft-_DOC.body.clientLeft,evt.clientY+_DOC.body.scrollTop-_DOC.body.clientTop];
            }
            
            /**
             * 页面偏移位置
             */
            function _R()
            {
                if(typeof (_WIN.pageYOffset)=='number')
                {
                    return [_WIN.pageXOffset,_WIN.pageYOffset];
                }
            
                var o=_DOC.documentElement;
                if(o&&(o.scrollLeft||o.scrollTop))
                {
                    return [o.scrollLeft,o.scrollTop];
                }
            
                o=_DOC.body;
                if(o&&(o.scrollLeft||o.scrollTop))
                {
                    return [o.scrollLeft,o.scrollTop];
                }
            
                return [0,0];
            }
            
            /**
             * 调整数组长度，使其能够整行显示。
             */
            function _S(list,cols,rows)
            {
                var size=cols*rows;
                if(list.length<size)
                {
                    var o=size-list.length;
                    while(o-- >0)
                    {
                        list.push(new Array('','0','','','','',''));
                    }
                }
                return size;
            }
            
            /**
             * 获取用户选择的页面文本
             */
            function _T()
            {
                if(_WIN.getSelection)
                {
                    return _WIN.getSelection().toString();
                }
                if(_DOC.selection)
                {
                    return _DOC.selection.type!='None'?_DOC.selection.createRange().text:''
                }
                if(_DOC.getSelection)
                {
                    return _DOC.getSelection();
                }
                return '';
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
        }
    )();
}